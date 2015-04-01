// Fisierul Client.cs
namespace MessageSender
{
    using System;
    using System.ServiceModel;
    using System.Windows.Forms;
    using System.Collections.Generic;
    /// <summary>
    /// Clientul implementeaza metoda ce va fi apelata din serviciu
    /// in cadrul unui contract duplex.
    ///
    /// Se folosesc doua clase : Listner si Sender in ideea de a
    /// separa codul si actiunile de trimitere a mesajelor,
    /// de actiunea de executie a metodei callback din client.
    ///
    /// Se poate realiza callback si folosind numai una
    /// din aceste clase. Atentie la metoda Subscribe in acest caz.
    ///
    /// Tipul MessageClient este proxy pentru obiectul din server
    ///
    /// </summary>
    public class Client
    {
        public static InterfataClient interfata;
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter when the server is running.");
            Console.ReadKey();
            
            //pornire interfata
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            interfata = new InterfataClient();
            Application.Run(interfata);*/
            // Subscribe pe server. Instiintez serviciul pe
            // ce obiect sa apeleze callback.
            // Se va apela callback pe metoda OnMessageAdded
            // din clasa Listner.
            Listener listener = new Listener();
            listener.Open();
            // Apelez metoda AddMessage din serviciu
            Sender sender = new Sender();
            sender.Go();
            sender.Dispose();
            listener.Dispose();
            Console.WriteLine("Done, press enter to exit");
            Console.ReadKey();
        }

        public static void Connect() 
        {

        }

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

                messageClient = new MessageClient(context,
               "NetTcpBinding_IMessage");
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
                WCFCallbacks.User[] list = new WCFCallbacks.User[10];
                list = messageClient.GetFriendList(1);

            }
            void IMessageCallback.OnMessageAdded(string message,
           DateTime timestamp)
            {
                Console.WriteLine("<<< [Sender OnMessageAdded] => Recieved {0} with a timestamp of {1}",
                message, timestamp);
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
        class Listener : IMessageCallback, IDisposable
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
                messageClient = new MessageClient(context,
            "NetTcpBinding_IMessage");
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