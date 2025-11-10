using System;
using System.Windows.Forms;
using static PayrollSystem.Program;
using static PayrollSystem.UsefullUniversalCommands;

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
            passwordInputBox.PasswordChar = '\0';
            if (hidePasswordCheck.Checked == true)
                passwordInputBox.PasswordChar = '*';
        }

        private void hideUserCheck_CheckedChanged(object sender, EventArgs e)
        {
            usernameInputBox.PasswordChar = '\0';
            if (hideUserCheck.Checked == true)
                usernameInputBox.PasswordChar = '*';
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
            Company companyToSearch = LoadCompany();

            foreach (Employee employee in companyToSearch.Employees)
            {
                if (employee.Username == usernameInputBox.Text)
                {
                    if (employee.Password == passwordInputBox.Text)
                    {
                        MessageBox.Show("Username and password correct!");
                        ChangeActiveEmployee(employee.Privliage, employee);
                        pageOpenner(employee);
                    }
                    else MessageBox.Show("Password was incorrect");
                }
                else MessageBox.Show("Could not find someone with that username.");
            } 
        }

        private void pageOpenner(Employee emp)
        {
            switch (emp.Privliage)
            {
                case 0:
                    Console.Write($"Loading {emp.FullName} as a Standard Employee");
                    //Open Employee Form
                    break;
                case 1:
                    Console.Write($"Loading {emp.FullName} as a Manager");
                    //Open Manager Form
                    break;
                case 2:
                    Console.Write($"Loading {emp.FullName} as an Admin");
                    //Open Admin Form
                    break;
                default:
                    shMsgBox($"INVALID PRIVLIAGE: {emp.Privliage}\n" +
                             $"Privliage must be between 0 - 2\n" +
                             $"\n" +
                             $"Loading as Standard Employee...");
                    break;
            }
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

        private void btnTesting_Click(object sender, EventArgs e)
        {
            TestingPageHub newForm = new TestingPageHub();
            newForm.Show();
        }
    }
}

/// IDEAS:
/// If login text and password text contain something, show login button. otherwise make it invisible.