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
    public partial class TestingPageHub : Form
    {
        public TestingPageHub()
        {
            InitializeComponent();
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            // setup
            ApplicationSystem applicationSystem = new ApplicationSystem();
            List<Employee> emps = new List<Employee> { new Employee(1029274, "bob123", "password123", "Bob", "the fuy") };
            Company company = new Company();
            company.Employees = emps;

            //test
            try
            {
                applicationSystem.saveLoginFile("C:\\PayrollSystem\\", emps);
            }
            catch (Exception ex) { Console.WriteLine(ex);  }
        }
    }
}
