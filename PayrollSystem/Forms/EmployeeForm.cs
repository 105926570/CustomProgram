using System;
using System.Windows.Forms;

namespace PayrollSystem.Forms
{
    public partial class EmployeeForm : Form
    {
        private string _welcomeName = "User";
        private Employee _activeEmployee;

        /// <summary>
        /// Initialise with the default name [User]
        /// </summary>
        public EmployeeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialise by assigning an active employee, and setting the name to the employees name.
        /// </summary>
        public EmployeeForm(Employee employee)
        {
            _activeEmployee = employee;
            _welcomeName = employee.FirstName;
            InitializeComponent();
        }

        /// <summary>
        /// Initialise with a given name [User]
        /// </summary>
        /// <param name="name"></param>
        public EmployeeForm(string name) : this() //Users name should be included when the menu is launched from the login.
        {
            _welcomeName = name;
        }

        // Upon load, change the welcome text to include the users name.
        private void Employee_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome {_welcomeName}";
        }

        // Suposed to close the window, and "sign out" of the active user.
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //suposed to view the schedule.
        //this can be done by either openning it in a new window, or displaying it on this window.
        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                            // Body Text
                            $"{e}\n" +
                            $"{sender}\n" +
                            $"\n" +
                            $"{btnViewSchedule.Name}'s function not yet implimented.\n" +
                            $"this dialoguebox aims to demonstrate that the button works, by having it being shown as a temporary output." +
                            $"Press 'OK' to continue...",
                            // alt text
                            $"Temporary Output for {btnViewSchedule.Text}");
        }
    }
}
