using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCFCallbacks
{
    using System;
    using System.ServiceModel;
    public interface IMessageCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnMessageAdded(string message, DateTime timestamp);
        [OperationContract(IsOneWay = true)]
        void OnFriendConnected(int friendId, DateTime timestamp);
        [OperationContract(IsOneWay = true)]
        void OnFriendDisconnected(int friendId, DateTime timestamp);
        [OperationContract(IsOneWay = true)]
        void OnMessageSent(int from, int to, string message, DateTime timestamp);
    }
}
