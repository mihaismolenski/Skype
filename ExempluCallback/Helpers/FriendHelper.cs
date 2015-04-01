using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFCallbacks
{
    class FriendHelper
    {
        public static void AddFriend(int userID, int friendId)
        {
            using (var dc = new SkypeEntities())
            {
                var friend = new Friend()
                {
                    UserId = userID,
                    FriendId = friendId
                };

                dc.Friends.Add(friend);
                dc.SaveChanges();
            }
        }

        public static void RemoveFriend(int userID, int friendId)
        {
            using (var dc = new SkypeEntities())
            {
                var friend = dc.Friends.DefaultIfEmpty().FirstOrDefault(a=>a.UserId == userID && a.FriendId == friendId);

                dc.Friends.Remove(friend);
                dc.SaveChanges();
            }
        }

        public static List<User> GetFriends(int userId)
        {
            using (var context = new SkypeEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                var friends = new List<User>();
                var list = context.Friends.Where(a=>a.UserId == userId).ToList();
                foreach (var user in list)
                {
                    var u = new User();
                    u = context.Users.Find(user.FriendId);
                    friends.Add(u);
                }
                return friends;
            }
        }
    }
}
