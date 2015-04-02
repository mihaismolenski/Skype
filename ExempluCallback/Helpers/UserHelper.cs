using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFCallbacks
{
    class UserHelper
    {
        public static int InsertUser(string name, string surname, string phone, string email, string username, string password)
        {
            using (var dc = new SkypeEntities())
            {
                var user = new User()
                {
                    Name = name,
                    Surname = surname,
                    Phone = phone,
                    Email = email,
                    UserName = username,
                    Password = password
                };
                //dc.AddTotest(t);
                dc.Users.Add(user);
                dc.SaveChanges();
                return user.UserId;
            }
        }

        public static void RemoveUser(string username, string password)
        {
            using (var dc = new SkypeEntities())
            {
                var user = dc.Users.DefaultIfEmpty().FirstOrDefault(a=>a.UserName == username && a.Password == password);
                dc.Users.Remove(user);
                dc.SaveChanges();
            }
        }
    }
}
