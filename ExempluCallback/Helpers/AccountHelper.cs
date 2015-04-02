using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WCFCallbacks
{
    class AccountHelper
    {
        public static int Login(string username, string password)
        {
            using (var dc = new SkypeEntities())
            {
                var user = dc.Users.DefaultIfEmpty().FirstOrDefault(a => a.UserName == username && a.Password == password);

                if (user != null)
                {
                    return user.UserId;
                }
                return -1;
            }
        }

        public static int Register(string name, string surname, string phone, string email, string username,string password)
        {
            if (name == String.Empty || surname == String.Empty || phone == String.Empty || email == String.Empty ||
                username == String.Empty || password == String.Empty)
            {
                return -1;
            }
            return UserHelper.InsertUser(name, surname, phone, email, username, password);
        }
    }
}
