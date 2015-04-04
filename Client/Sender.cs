using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;
using WCFCallbacks;

namespace MessageSender
{
    /// <summary>
    /// Obiecte din aceasta clasa apeleaza metoda AddMessage din serviciu.
    /// Initiatorul conversatiei
    /// </summary>
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    class Sender : IMessageCallback, IDisposable
    {
        // Creez obiect de pe server
        private MessageClient messageClient;
        public static List<int> friends;
        public void Go()
        {
            // Reprezinta informatia de context pentru instanta serviciului
            // Cu acest context din proxy generat - clasa MessageClient -
            // se construieste un obiect
            // folosind un ctor cu doi parametri
            // In app.config din client veti gasi
            /*
           <endpoint
            address="net.tcp://localhost:9191/WCFCallbacks/Message"
            binding="netTcpBinding"
            bindingConfiguration="NetTcpBinding_IMessage"
            contract="IMessage" name="NetTcpBinding_IMessage"
           >
            */
            // al doilea parametru fiind bindingConfiguration
            // context e necesar in procesul callback
            InstanceContext context = new InstanceContext(this);
            messageClient = new MessageClient(context, "NetTcpBinding_IMessage");
            // atentie: e case sensitive "NetTcpBinding"
            friends = new List<int>();
            //
            // Daca decomentam linia ce urmeaza atunci se va executa
            // IMessageCallback.OnMessageAdded(...) implementata
            // in aceasta clasa.
             
            //
            for (int i = 0; i < 5; i++)
            {
                string message = string.Format("message #{0}", i);
                Console.WriteLine(">>> Sending -> " + message);
                messageClient.AddMessage(message);
            }
            //WCFCallbacks.User[] list = new WCFCallbacks.User[100];
            //list = messageClient.GetFriendList(1);

        }

        public int LogIn(string name, string pass)
        {
            InstanceContext context = new InstanceContext(this);
            messageClient = new MessageClient(context, "NetTcpBinding_IMessage");
            int id = messageClient.LogIn(name, pass);
            messageClient.Subscribe(id);
            return id;
        }
        public void LogOut(int userId)
        {
              InstanceContext context = new InstanceContext(this);
              messageClient = new MessageClient(context, "NetTcpBinding_IMessage");
              messageClient.LogOut(userId);
        }



        public void AddFriend(int userID, int friendId)
        {
            InstanceContext context = new InstanceContext(this);
            messageClient = new MessageClient(context, "NetTcpBinding_IMessage");
            messageClient.AddFriend(userID, friendId);

        }

        public int Register(string name, string surname, string email, string phone, string username, string pass)
        {
            InstanceContext context = new InstanceContext(this);
            messageClient = new MessageClient(context, "NetTcpBinding_IMessage");
            int id = messageClient.Register(name, surname, email, phone, username, pass);
            return id;
        }

        public List<User> GetFriendList(int userId){

            InstanceContext context = new InstanceContext(this);
            messageClient = new MessageClient(context, "NetTcpBinding_IMessage");
            User[] Users;
            Users = messageClient.GetFriendList(userId);
            return Users.ToList();

        }

        public List<Message> GetMessages(int from, int to)
        {
            Message[] mesage;
            mesage = messageClient.GetMessages(to, from);
            return mesage.ToList();
        }

        public void SendMessage(int from, int to, string message)
        {
            InstanceContext context = new InstanceContext(this);
            messageClient = new MessageClient(context, "NetTcpBinding_IMessage");
            messageClient.SendMessage(from, to, message);
            
        }
        void IMessageCallback.OnMessageAdded(string message, DateTime timestamp)
        {
            Console.WriteLine("<<< [Sender OnMessageAdded] => Recieved {0} with a timestamp of {1}",
            message, timestamp);
            Client.interfata.richTextBox1.Text += "<<< [Sender OnMessageAdded] => Recieved {0} with a timestamp of {1}";
        }

        void IMessageCallback.OnMessageSent(int from, int to, string message, DateTime timestamp)
        {
            Client.workSpace.TextBoxFriend.Text += (getName(from) != null) ? getName(from) + ": " + message + Environment.NewLine : "Me" + ": " + message + Environment.NewLine;
        }

        void IMessageCallback.OnFriendConnected(int id, DateTime timestamp)
        {
            Client.interfata.richTextBox1.Text += id.ToString() + " conectat\n";
            friends.Add(id);
            if (Client.workSpace.Visible == true)
            {
                FillFriends();
            }
        }

        public string getName(int id)
        {
            List<User> Users = Client.GetFriendList(WorkSpace.userId);

            foreach (var us in Users)
            {
                if (us.UserId == id)
                {
                    return us.UserName;
                }
            }
            return null;
        }
        public static void FillFriends()
        {
            List<User> Users = Client.GetFriendList(WorkSpace.userId);
            Client.workSpace.friendsGrid.Rows.Clear();
            foreach (var us in Users)
            {
                int n = Client.workSpace.friendsGrid.Rows.Add();
                if (n >= 0)
                {
                    Client.workSpace.friendsGrid.Rows[n].Cells[0].Value = us.UserName;
                    if (us.Phone == "1")
                        Client.workSpace.friendsGrid.Rows[n].Cells[1].Value = "online";
                    else
                        Client.workSpace.friendsGrid.Rows[n].Cells[1].Value = "offline";
                    Client.workSpace.friendsGrid.Rows[n].Cells[2].Value = us.UserId;
                }
            }
        }

        void IMessageCallback.OnFriendDisconnected(int id, DateTime timestamp)
        {
            foreach (System.Windows.Forms.DataGridViewRow row in Client.workSpace.friendsGrid.Rows)
            {
                if (row.Cells[2].Value.ToString() == id.ToString())
                {
                    row.Cells[1].Value = "offline";
                    break;
                }
            }
        }

        void IMessageCallback.OnFriendAdd(int from, int target)
        {
            if (target == WorkSpace.userId)
            {
                List<User> Users = Client.GetFriendList(WorkSpace.userId);
                int n = Client.workSpace.friendsGrid.Rows.Add();
                if (n >= 0)
                {
                    User us = Users.Find(x => x.UserId == from);
                    Client.workSpace.friendsGrid.Rows[n].Cells[0].Value = us.UserName;
                    if (us.Phone == "1")
                        Client.workSpace.friendsGrid.Rows[n].Cells[1].Value = "online";
                    else
                        Client.workSpace.friendsGrid.Rows[n].Cells[1].Value = "offline";
                    Client.workSpace.friendsGrid.Rows[n].Cells[2].Value = us.UserId;
                }
            }
        }
       

        public void Dispose()
        {
            messageClient.Close();
        }
    }

}
