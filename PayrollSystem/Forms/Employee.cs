using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.Forms
{
    public partial class Employee : Form
    {
        private string _welcomeName = "User";

        /// <summary>
        /// Initialise with the default name [User]
        /// </summary>
        public Employee()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialise with a given name [User]
        /// </summary>
        /// <param name="name"></param>
        public Employee(string name) : this() //Users name should be included when the menu is launched from the login.
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
    }
}
