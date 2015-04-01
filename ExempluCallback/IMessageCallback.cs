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
    interface IMessageCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnMessageAdded(string message, DateTime timestamp);
    }
}
