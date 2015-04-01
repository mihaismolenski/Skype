using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageSender
{
    public partial class InterfataClient : Form
    {
        public InterfataClient()
        {
            InitializeComponent();
        }

        private void InterfataClient_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client.Connect();
        }
    }
}
