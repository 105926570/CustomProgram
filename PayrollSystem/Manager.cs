using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Manager : Employee
    {
        private List<Employee> _managedEmployees = new List<Employee> { };

        //Default constructor / Test constructor
        public Manager() : base() 
        { }

        //All values provided except employees
        public Manager(int employeeID, string username, string password, string firstName, string lastName)
        : base(employeeID, username, password, firstName, lastName)
        { }

        // All values provided
        public Manager(List<Employee> employees, int employeeID, string username, string password, string firstName, string lastName)
        : base(employeeID, username, password, firstName, lastName) 
        {
            _managedEmployees = employees;
        }

        public List<Employee> ManagedEmployees
        {
            get { return _managedEmployees; }
            set { _managedEmployees = value; }
        }

        public void DisplayManagedEmployees()
        {
            Console.WriteLine("Managed Employees for Manager: " + FullName);
            foreach (Employee emp in ManagedEmployees)
            {
                emp.DisplayEmployeeInfo();
            }
        }
    }
}
