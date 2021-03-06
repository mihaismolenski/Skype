﻿using System;
using System.ServiceModel;
using System.Windows.Forms;
using System.Collections.Generic;

using System.Threading;
using WCFCallbacks;

// Fisierul Client.cs
namespace MessageSender
{
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
        public static WorkSpace workSpace;
        private static Listener listener;
        private static Sender sender;
        //public static SynchronizationContext _SyncContext = null;
        static void Main(string[] args)
        {

            //pornire interfata
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            interfata = new InterfataClient();
            Application.Run(interfata);
            // Subscribe pe server. Instiintez serviciul pe
            // ce obiect sa apeleze callback.
            // Se va apela callback pe metoda OnMessageAdded
            // din clasa Listner.
            /*Listener listener = new Listener();
            listener.Open();
            listener.LogIn();
            Console.ReadKey();
            // Apelez metoda AddMessage din serviciu
            Sender sender = new Sender();
            sender.Go();
            Console.ReadKey();
            sender.Dispose();
            listener.Dispose();
            Console.WriteLine("Done, press enter to exit");*/

        }

        public static void Connect()
        {
            // Subscribe pe server. Instiintez serviciul pe
            // ce obiect sa apeleze callback.
            // Se va apela callback pe metoda OnMessageAdded
            // din clasa Listner.
            listener = new Listener();
            listener.Open();
            // Apelez metoda AddMessage din serviciu
            sender = new Sender();
            sender.Go();

            Console.WriteLine("Done, press enter to exit");
        }

        public static void Disconnect()
        {
            sender.Dispose();
            listener.Dispose();
        }

        public static bool Login(string name, string pass)
        {
            workSpace = new WorkSpace(name);
            int index = sender.LogIn(name, pass);
            if (index >= 0)
            {
                WorkSpace.userId = index;
                interfata.Hide();
                workSpace.Show();
                return true;
            }

            return false;
        }

        public static void Register(string username, string pass)
        {
            string name = "Aurica";
            string surname = "Degetica";
            string email = "samsonel@yahoo.com";
            string phone = "0323462910";

            sender.Register(name, surname, email, phone, username, pass);
        }
        public static List<User> GetFriendList(int userId)
        {
            List<User> Users = new List<User>();
            Users = sender.GetFriendList(userId);
            return Users;
        }
        public static void SendMessage(int from, int to, string message)
        {
            sender.SendMessage(from, to, message);
        }

        public static List<WCFCallbacks.Message> GetMessage(int from, int to)
        {
            List<WCFCallbacks.Message> messages = sender.GetMessages(from, to);
             return messages;
        }

        public static void LogOut(int userID)
        {
            sender.LogOut(userID);
        }

        public static void AddFriend(int userID, int friendId)
        {
            sender.AddFriend(userID, friendId);
        }
    }
}