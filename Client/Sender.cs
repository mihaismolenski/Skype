using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;

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

            //
            // Daca decomentam linia ce urmeaza atunci se va executa
            // IMessageCallback.OnMessageAdded(...) implementata
            // in aceasta clasa.
            // messageClient.Subscribe();
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
            return id;
        }

        public int Register(string name, string surname, string email, string phone, string username, string pass)
        {
            InstanceContext context = new InstanceContext(this);
            messageClient = new MessageClient(context, "NetTcpBinding_IMessage");
            int id = messageClient.Register(name, surname, email, phone, username, pass);
            return id;
        }

        void IMessageCallback.OnMessageAdded(string message, DateTime timestamp)
        {
            Console.WriteLine("<<< [Sender OnMessageAdded] => Recieved {0} with a timestamp of {1}",
            message, timestamp);
            Client.interfata.richTextBox1.Text += "<<< [Sender OnMessageAdded] => Recieved {0} with a timestamp of {1}";
        }

        void IMessageCallback.OnMessageSent(int from, int to, string message, DateTime timestamp)
        {
            Client.interfata.richTextBox1.Text += message + " - primit de la " + from.ToString() + "\n";
        }

        void IMessageCallback.OnFriendConnected(int id, DateTime timestamp)
        {
            Client.interfata.richTextBox1.Text += id.ToString() + " conectat\n";
        }

        void IMessageCallback.OnFriendDisconnected(int id, DateTime timestamp)
        {
            Client.interfata.richTextBox1.Text += id.ToString() + " deconectat\n";
        }

        public void Dispose()
        {
            messageClient.Close();
        }
    }

}
