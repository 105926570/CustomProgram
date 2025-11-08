using PayrollSystem.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static PayrollSystem.UsefullUniversalCommands;

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
            ApplicationSystem applicationSystem = new ApplicationSystem("C:\\PayrollSystem");
            Company company = new Company();

            //test reading
            applicationSystem.readLoginFile();
            Console.WriteLine("finsished this test");
        }

        private void cmdTest2_Click(object sender, EventArgs e)
        {
            // setup
            ApplicationSystem applicationSystem = new ApplicationSystem("C:\\PayrollSystem");
            List<Employee> emps = new List<Employee> { new Employee(GenerateRandomNumber(999999999), "bob123", "password123", "Bob", "the fuy") };
            Company company = new Company();
            company.Employees = emps;

            //test writing
            applicationSystem.saveLoginFile(emps);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Generate 100 random numbers
            List<int> randomNumbers = GenerateANumberOfUniqueNumbers(999999999, 100);

            //Print all numbers for testing - to be removed later
            foreach (int i in randomNumbers) Console.WriteLine($"{i}");

            //Create Company
            Company company = new Company();

            //Create Departments
            List<Department> departments = new List<Department> { new Department("Department 1", randomNumbers[0]), new Department("Department 2", randomNumbers[1]) };

            //Create example Employees (10)
            List<Employee> testEmps = new List<Employee>()
            {
                new Employee(), // 1
                new Employee(), // 2
                new Employee(), // 3
                new Employee(), // 4
                new Employee(), // 5
                new Employee(), // 6
                new Employee(), // 7
                new Employee(), // 8
                new Employee(), // 9
                new Employee(), // 10
            };
        }

        // Open the form and close self.
        private void btnOpenEmployeeForm_Click(object sender, EventArgs e)
        {
            string defaultName = "User";
            if (txtUser.Text != "") defaultName = txtUser.Text;            
            new EmployeeForm(defaultName).Show();
            this.Close();
        }
    }
}