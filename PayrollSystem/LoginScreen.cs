using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void hidePasswordCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (hidePasswordCheck.Checked == true)
            {
                passwordInputBox.PasswordChar = '*';
            }
            else
            {
                passwordInputBox.PasswordChar = '\0';
            }
        }

        private void hideUserCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (hideUserCheck.Checked == true)
            {
                usernameInputBox.PasswordChar = '*';
            }
            else
            {
                usernameInputBox.PasswordChar = '\0';
            }
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            capsLockWarningLabel.Visible = false;
        }

        private void CapsLock_KeyDown(object sender, KeyEventArgs e)
        {
            capsLockWarningLabel.Visible = Control.IsKeyLocked(Keys.CapsLock);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Search account database for matching usernames and passwords.
            // if found, load data employee data and add to active employee session.
            // else return error message.
        }

        private void btnLoginAsAdmn_Click(object sender, EventArgs e)
        {
            GeneratedCreateForm newForm = new GeneratedCreateForm();  // create the new form
            newForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

/// IDEAS:
/// If login text and password text contain something, show login button. otherwise make it invisible.