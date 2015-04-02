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

namespace Client
{
    public partial class WorkSpace : Form
    {
        
        public WorkSpace(string username)
        {
            InitializeComponent();
            welcome.Text += username + "!";
        }
    }
}
