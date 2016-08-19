using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vizsga.Vizsga
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            UsernameTextBox.Focus();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if(UsernameTextBox.Text == "admin" && PasswordTextBox.Text == "admin")
                {

                }
                else
                {
                    MessageBox.Show("Sorry");
                    e.Cancel = true;
                }
            }
        }
    }
}
