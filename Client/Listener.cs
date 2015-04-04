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
    /// Aceasta clasa e folosita pentru a indica metoda din client
    /// ce va fi apelata din cadrul serviciului.
    /// Observati ca se implementeaza interfata IMessageCallback.
    /// </summary>
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    class Listener : IMessageCallback, IDisposable
    {
        private MessageClient messageClient;
        public static List<int> friends;
        public void Open()
        {
            // Reprezinta informatia de context pentru instanta serviciului
            // Cu acest context din proxy generat - clasa MessageClient –
            // se construieste un obiect
            // folosind un ctor cu doi parametri
            // In app.config din client veti gasi
            /*
           <endpoint
            address="net.tcp://localhost:9191/WCFCallbacks/Message"
            binding="netTcpBinding"
            bindingConfiguration="NetTcpBinding_IMessage"
            contract="IMessage" name="NetTcpBinding_IMessage">
            */
            // al doilea parametru fiind bindingConfiguration
            // context e necesar in procesul callback

            friends = new List<int>();
            InstanceContext context = new InstanceContext(this);
            messageClient = new MessageClient(context, "NetTcpBinding_IMessage");
        }

        void IMessageCallback.OnMessageAdded(string message, DateTime timestamp)
        {
            Client.interfata.richTextBox1.Text += "<<< [Listner OnMessageAdded] >>> Recieved  + " + message + " with a timestamp of " + timestamp;
            Client.interfata.richTextBox1.Text += Environment.NewLine;
            //Console.WriteLine("<<< [Listner OnMessageAdded] >>> Recieved {0} with a timestamp of {1}", message, timestamp);
        }

        void IMessageCallback.OnMessageSent(int from, int to, string message, DateTime timestamp)
        {
            Console.WriteLine("<<< [Listner OnMessageSent] >>> Recieved {0} with a timestamp of {1}", message, timestamp);
        }

        void IMessageCallback.OnFriendConnected(int friendId, DateTime timestamp)
        {
            Console.WriteLine("<<< [Listner OnFriendConnected] >>> Recieved {0} with a timestamp of {1}", friendId, timestamp);
            Client.workSpace.TextBoxFriend.Text += "OnFriendConnected";
        }

        void IMessageCallback.OnFriendDisconnected(int id, DateTime timestamp)
        {
            Console.WriteLine("<<< [Listner OnFriendDisconnected] >>> Recieved {0} with a timestamp of {1}", id, timestamp);
        }

        void IMessageCallback.OnFriendAdd(int traget, int from)
        {

        }

        public void Dispose()
        {
            messageClient.Unsubscribe();
            messageClient.Close();
        }
    }
}
