using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFCallbacks
{
    class ConversationHelper
    {
        public static void AddConversation(int from, int to, string message)
        {
            using (var dc = new SkypeEntities())
            {
                var conversation = new Message()
                {
                    FromUser = from,
                    ToUser = to,
                    Text = message,
                    Date = DateTime.Now
                };

                dc.Messages.Add(conversation);
                dc.SaveChanges();
            }
        }

        public static List<Message> GetConversation(int userId, int friendId)
        {
            using (var dc = new SkypeEntities())
            {
                var messages = new List<Message>();
                messages = dc.Messages.Where(a=>(a.FromUser == userId && a.ToUser == friendId) || (a.FromUser == friendId && a.ToUser == userId)).OrderBy(a=>a.Date).ToList();

                return messages;
            }
        } 
    }
}
