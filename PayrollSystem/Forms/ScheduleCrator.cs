using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PayrollSystem.Program;

namespace PayrollSystem
{
    public partial class ScheduleCrator : Form
    {
        private List<Employee> EmployeesFromActive = new List<Employee>() { };

        public ScheduleCrator()
        {
            InitializeComponent();
        }

        private void ScheduleCrator_Load(object sender, EventArgs e)
        {
            cmbxEmployees.Items.Clear();
            EmployeesFromActive = ActiveCompany.Employees;
            foreach (Employee emp in EmployeesFromActive)
            {
                cmbxEmployees.Items.Add(emp.ID);
            }
        }

        private void cmbxEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee emp = EmployeesFromActive[cmbxEmployees.SelectedIndex];
            lblFirstName.Text = emp.FirstName;
            lblLastName.Text = emp.LastName;
            lblPassword.Text = emp.Password;
            lblUsername.Text = emp.Username;
        }
    }
}
