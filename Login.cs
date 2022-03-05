using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GodswarHack
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Log_in_Click(object sender, EventArgs e)
        {
            if (username.Text == "admin" && password.Text == "admin")
            {
                base.Hide();
                RPbox.Form1 me = new RPbox.Form1();
                me.Show();
            }
            else
            {
                MessageBox.Show("Incorrect password");
            }
        }
    }
}
