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
        private int _privilege; // Privilege level of a manager is level 1

        //Default constructor / Test constructor
        public Manager() : base() 
        {
            _privilege = 1;
        }

        //All values provided except employees
        public Manager(int employeeID, string username, string password, string firstName, string lastName)
        : base(employeeID, username, password, firstName, lastName)
        {
            _privilege = 1;
        }

        // All values provided
        public Manager(List<Employee> employees, int employeeID, string username, string password, string firstName, string lastName)
        : base(employeeID, username, password, firstName, lastName) 
        {
            _managedEmployees = employees;
            _privilege = 1;
        }

        public List<Employee> ManagedEmployees
        {
            get { return _managedEmployees; }
            set { _managedEmployees = value; }
        }

        public int Privilege
        {
            get { return _privilege; }
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
