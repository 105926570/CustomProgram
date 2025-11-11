using System;
using System.Windows.Forms;

namespace PayrollSystem.Forms
{
    public partial class EmployeeForm : Form
    {
        /// <summary>
        /// Initialise with the default name [User]
        /// </summary>
        public EmployeeForm()
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome {Program.activeEmployee.FirstName}";
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
