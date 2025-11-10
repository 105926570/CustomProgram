using PayrollSystem.Forms;
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
            //Check if username or password is left blank
            if (usernameInputBox.Text == "" && passwordInputBox.Text != "")
            {
                MessageBox.Show("Please enter a username");
                return;
            }
            else if (passwordInputBox.Text == "" && usernameInputBox.Text != "")
            {
                MessageBox.Show("Please enter a password");
                return;
            }
            else if (usernameInputBox.Text == "" && passwordInputBox.Text == "")
            {
                MessageBox.Show("An empty input has been detected.\n" +
                                "Please enter a username AND password");
                return;
            }

            Console.WriteLine("login clicked");
            Company companyToSearch = LoadCompany();
            Console.WriteLine("company to search loaded");

            foreach (Department department in companyToSearch.Departments)
            {
                Console.WriteLine($"looking in {department.Name}");
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine($"looking in {employee.FirstName}");
                    Console.WriteLine($"{employee.Username} = {usernameInputBox.Text}???");
                    if (employee.Username == usernameInputBox.Text)
                    {
                        Console.WriteLine($"yes");
                        Console.WriteLine($"{employee.Password} = {passwordInputBox.Text}???");
                        if (employee.Password == passwordInputBox.Text)
                        {
                            Console.WriteLine($"yes");
                            Console.WriteLine($"changing active employee");
                            ChangeActiveEmployee(employee);
                            pageOpenner(employee);
                            return; //prevent loop from continuing.
                        }
                        else Console.WriteLine("No it does not");
                        MessageBox.Show("incorrect password");
                        return;
                    }
                    else Console.WriteLine($"no");
                }
            }
            Console.WriteLine("looked through all");
            MessageBox.Show("Unable to find a user with that username and password");
        }

        private void pageOpenner(Employee emp)
        {
            Form newForm;
            switch (emp.Privliage)
            {
                case 0:
                    Console.Write($"Loading {emp.FullName} as a Standard Employee");
                    newForm = new EmployeeForm();
                    newForm.Show();
                    break;
                case 1:
                    Console.Write($"Loading {emp.FullName} as a Manager");
                    newForm = new ManagerForm();
                    newForm.Show();
                    break;
                case 2:
                    Console.Write($"Loading {emp.FullName} as an Admin");
                    newForm = new AdminForm();
                    newForm.Show();
                    break;
                default:
                    shMsgBox($"INVALID PRIVLIAGE: {emp.Privliage}\n" +
                             $"Privliage must be between 0 - 2\n" +
                             $"\n" +
                             $"Loading as Standard Employee...");
                    newForm = new EmployeeForm();
                    newForm.Show();
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
            FullCompanySave(CompanyLoadedInFromFiles);
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