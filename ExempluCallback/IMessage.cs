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
        bool Subscribe();
        [OperationContract]
        bool Unsubscribe();
        [OperationContract]
        List<ExempluCallback.User> GetFriendList(int userId);
    }
}
