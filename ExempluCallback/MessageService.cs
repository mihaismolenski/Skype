using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFCallbacks
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    public class MessageService : IMessage
    {
        public struct CClient
        {
            public IMessageCallback subscriber;
            public int clientId;
        }
        private static List<CClient> clients = new List<CClient>();
        private static readonly List<IMessageCallback>
       subscribers = new List<IMessageCallback>();
        public void AddMessage(string message)
        {
            // aici se face apelul la metoda callback
            subscribers.ForEach(delegate(IMessageCallback callback)
            {
                if (((ICommunicationObject)callback).State ==
               CommunicationState.Opened)
                {
                    callback.OnMessageAdded(message, DateTime.Now);
                }
                else
                {
                    subscribers.Remove(callback);
                }
            });
        }

        /// <summary>
        /// subscribe pe server a clientului
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Subscribe(int id)
        {
            try
            {
                IMessageCallback callback =
                OperationContext.Current.
               GetCallbackChannel<IMessageCallback>();
                // Inregistrez “tipul” ce implementeaza IMessageCallback
                // Acest tip este pe partea de client

                if (!subscribers.Contains(callback))
                {
                    subscribers.Add(callback);
                    clients.Add(new CClient() { subscriber = callback, clientId = id });
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// unsubscribe de pe server a clientului
        /// </summary>
        /// <returns></returns>
        public bool Unsubscribe()
        {
            try
            {
                IMessageCallback callback =
               OperationContext.Current.
               GetCallbackChannel<IMessageCallback>();
                if (subscribers.Contains(callback))
                {
                    var c = clients.FirstOrDefault(a=>a.subscriber == callback);
                    clients.Remove(c);
                    subscribers.Remove(callback);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// returneaza lista de prieteni
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<User> GetFriendList(int userId)
        {
            return FriendHelper.GetFriends(userId);
        }

        public string Test()
        {
            return "OK";
        }

        /// <summary>
        /// login si notificare prieteni ca s-a conectat
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int LogIn(string username, string password)
        {
            int id = AccountHelper.Login(username, password);
            List<User> friends = new List<User>();
            friends = FriendHelper.GetFriends(id);
            //daca s-a logat cu succes notificam prietenii lui
            if (id > 0)
            {
                subscribers.ForEach(delegate(IMessageCallback callback)
                {
                    if (((ICommunicationObject)callback).State ==
                   CommunicationState.Opened)
                    {
                        var sub = clients.FirstOrDefault(a=>a.subscriber == callback);
                        //daca e prieten
                        var smth = friends.DefaultIfEmpty().FirstOrDefault(a=>a.UserId == sub.clientId);
                        if (smth != null)
                        {
                            callback.OnFriendConnected(id, DateTime.Now);
                        }
                    }
                });
            }
            return id;
        }

        /// <summary>
        /// register la un nou client in baza de date
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Register(string name, string surname, string email, string phone, string username, string password)
        {
            return AccountHelper.Register(name, surname, phone, email, username, password);
        }

        /// <summary>
        /// trimite un mesaj
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="message"></param>
        public void SendMessage(int from, int to, string message)
        {
            List<User> friends = new List<User>();
            friends = FriendHelper.GetFriends(from);
            subscribers.ForEach(delegate(IMessageCallback callback)
            {
                if (((ICommunicationObject)callback).State ==
               CommunicationState.Opened)
                {
                    var sub = clients.FirstOrDefault(a => a.subscriber == callback);
                    //daca e prieten
                    var smth = friends.DefaultIfEmpty().FirstOrDefault(a => a.UserId == sub.clientId);
                    if (smth != null)
                    {
                        callback.OnMessageSent(from, to, message, DateTime.Now);
                    }
                }
            });
            ConversationHelper.AddConversation(from, to, message);
        }

        /// <summary>
        /// Returneaza toate mesajele dintre 2 clienti
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="friendId"></param>
        /// <returns></returns>
        public List<Message> GetMessages(int userId, int friendId)
        {
            return ConversationHelper.GetConversation(userId, friendId);
        }

        /// <summary>
        /// adaugare prieten one-way in baza de date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="friendId"></param>
        public void AddFriend(int userId, int friendId)
        {
            FriendHelper.AddFriend(userId, friendId);
        }

        /// <summary>
        /// notificam prietenii ca s-a deconectat userId
        /// </summary>
        /// <param name="userId"></param>
        public void LogOut(int userId)
        {
            List<User> friends = new List<User>();
            friends = FriendHelper.GetFriends(userId);
            subscribers.ForEach(delegate(IMessageCallback callback)
            {
                if (((ICommunicationObject)callback).State ==
               CommunicationState.Opened)
                {
                    var sub = clients.FirstOrDefault(a => a.subscriber == callback);
                    //daca e prieten
                    var smth = friends.DefaultIfEmpty().FirstOrDefault(a => a.UserId == sub.clientId);
                    if (smth != null)
                    {
                        callback.OnFriendDisconnected(userId, DateTime.Now);
                    }
                }
            });
        }
    }
}
