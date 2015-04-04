using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageSender;
using System.ServiceModel;
using WCFCallbacks;

namespace MessageSender
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class WorkSpace : Form
    {
        InterfataClient interfata= new InterfataClient() ;
        public static int userId = 0;
        public int friendid=0;
        public string friendName = "";
        public WorkSpace(string username)
        {
            InitializeComponent();
          //  button1.Enabled = false;
            BackColor = Color.LightSteelBlue;
            welcome.Text += username + "!";
        }


        private void TextBoxFriend_TextChanged(object sender, EventArgs e)
        {

        }

        ///send message button
        private void button1_Click(object sender, EventArgs e)
        {
            int from = userId;
            string message = textBox1.Text;
            TextBoxFriend.Text += "Me: " + message + " " + Environment.NewLine;
            Client.SendMessage(from, friendid, message);
        }

        private void WorkSpace_Load(object sender, EventArgs e)
        {
            FillFriends(Client.GetFriendList(userId));
        }

        public  void FillFriends(List<User> friends)
        {
            friendsGrid.Rows.Clear();
            foreach (var us in friends)
            {
                int n = friendsGrid.Rows.Add();
                if (n >= 0)
                {
                    friendsGrid.Rows[n].Cells[0].Value = us.UserName;
                    if (us.Phone == "1")
                        friendsGrid.Rows[n].Cells[1].Value = "online";
                    else
                        friendsGrid.Rows[n].Cells[1].Value = "offline";
                    friendsGrid.Rows[n].Cells[2].Value = us.UserId;
                }

            }
        }

        //add new friend button
        private void button2_Click(object sender, EventArgs e)
        {
            Client.AddFriend(userId, Convert.ToInt32(friedName.Text));
            FillFriends(Client.GetFriendList(userId));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client.LogOut(userId);
            interfata.Show();
            this.Close();
        }

        private void friendsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = friendsGrid.Rows[e.RowIndex];
                friendid = Convert.ToInt32(row.Cells[2].Value.ToString());
                friendName = row.Cells[0].Value.ToString();
                TextBoxFriend.Clear();
                foreach (WCFCallbacks.Message mess in Client.GetMessage(userId, friendid).ToList())
                {
                    string from = "";
                    if (mess.FromUser == userId)
                    {
                        from = "Me";
                    }
                    else
                    {
                        from = friendName;
                    }

                    TextBoxFriend.Text += from + ": " + mess.Text + Environment.NewLine;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
