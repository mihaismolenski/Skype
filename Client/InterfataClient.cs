using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.Threading;

namespace MessageSender
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class InterfataClient : Form
    {
        public InterfataClient()
        {
            InitializeComponent();
            //Client._SyncContext = SynchronizationContext.Current;
        }

        private void login_Click(object sender, EventArgs e)
        {
            bool check = Client.Login(name.Text, pass.Text);
            if (!check)
            {
                MessageBox.Show("Numele si parola nu se potrivesc");
            }
        }

        private void register_Click(object sender, EventArgs e)
        {
            Client.Register(name.Text, pass.Text);

        }

        private void InterfataClient_Load(object sender, EventArgs e)
        {
            Client.Connect();
        }
    }
}
