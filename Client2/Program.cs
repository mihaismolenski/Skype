using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace WCFCallbacks
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        public static InterfataClient interfata;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            interfata = new InterfataClient();
            Application.Run(interfata);
        }

        public static void LogIn()
        {
            Listener listener = new Listener();
            listener.Open();
            // Apelez metoda AddMessage din serviciu
            Sender sender = new Sender();
            sender.Go();
            sender.Dispose();
            listener.Dispose();
        }

        /// <summary>
        /// Obiecte din aceasta clasa apeleaza metoda AddMessage din serviciu.
        /// Initiatorul conversatiei
        /// </summary>
        [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
        public class Sender : IMessageCallback, IDisposable
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
                    interfata.richTextBox1.Text += ">>> Sending -> " + i.ToString() + "\n";
                    messageClient.AddMessage(message);
                }
                WCFCallbacks.User[] list = new WCFCallbacks.User[100];
                list = messageClient.GetFriendList(1);
                LogIn();
            }

            public void LogIn()
            {
                InstanceContext context = new InstanceContext(this);
                messageClient = new MessageClient(context, "NetTcpBinding_IMessage");
                int id = messageClient.LogIn("mihai", "mihai");
            }

            void IMessageCallback.OnMessageAdded(string message,  DateTime timestamp)
            {
                //Console.WriteLine("<<< [Sender OnMessageAdded] => Recieved {0} with a timestamp of {1}",
                //message, timestamp);
                //MessageBox.Show("ura");
                interfata.richTextBox1.Text += "<<< [Sender OnMessageAdded] => Recieved {0} with a timestamp of {1}";
            }

            public void Dispose()
            {
                messageClient.Close();
            }
        }
        /// <summary>
        /// Aceasta clasa e folosita pentru a indica metoda din client
        /// ce va fi apelata din cadrul serviciului.
        /// Observati ca se implementeaza interfata IMessageCallback.
        /// </summary>
        [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
        public class Listener : IMessageCallback, IDisposable
        {
            private MessageClient messageClient;
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
                InstanceContext context = new InstanceContext(this);
                messageClient = new MessageClient(context,  "NetTcpBinding_IMessage");
                messageClient.Subscribe();
            }

            void IMessageCallback.OnMessageAdded(string message, DateTime timestamp)
            {
                Console.WriteLine("<<< [Listner OnMessageAdded] >>> Recieved {0} with a timestamp of {1}", message, timestamp);
            }

            public void Dispose()
            {
                messageClient.Unsubscribe();
                messageClient.Close();
            }
        }
    }
}
