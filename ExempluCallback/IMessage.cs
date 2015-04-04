using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFCallbacks
{
    using System.ServiceModel;
    [ServiceContract(CallbackContract = typeof(IMessageCallback))]
    public interface IMessage
    {
        [OperationContract]
        void AddMessage(string message);
        [OperationContract]
        bool Subscribe(int id);
        [OperationContract]
        bool Unsubscribe(int id);
        [OperationContract]
        List<User> GetFriendList(int userId);
        [OperationContract]
        string Test();
        [OperationContract]
        int LogIn(string username, string password);
        [OperationContract]
        int Register(string name, string surname, string email, string phone, string username, string password);
        [OperationContract]
        void SendMessage(int from, int to, string message);
        [OperationContract]
        List<Message> GetMessages(int userId, int friendId);
        [OperationContract]
        void AddFriend(int userId, int friendId);
        [OperationContract]
        void LogOut(int userId);
    }
}
