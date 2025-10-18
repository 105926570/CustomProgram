using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    internal class Manager : Employee
    {
        private List<Employee> managedEmployees = new List<Employee> { };

        //Default constructor / Test constructor
        public Manager() : base() 
        {
            //test employees
            Employee testEmployee1 = new Employee("Micheal", "Stevens");
            Employee testEmployee2 = new Employee("Your", "Mum");
            Employee testEmployee3 = new Employee("Lorenzo", "Federico");
            //adding test employees to managed employees list
            managedEmployees.Add(testEmployee1);
            managedEmployees.Add(testEmployee2);
            managedEmployees.Add(testEmployee3);
        }

        //All values provided except employees
        public Manager(int userID, string username, string password, string firstName, string lastName)
        : base(userID, username, password, firstName, lastName)
        {
            //test employees
            Employee testEmployee1 = new Employee("Micheal", "Stevens");
            Employee testEmployee2 = new Employee("Your", "Mum");
            Employee testEmployee3 = new Employee("Lorenzo", "Federico");
            //adding test employees to managed employees list
            managedEmployees.Add(testEmployee1);
            managedEmployees.Add(testEmployee2);
            managedEmployees.Add(testEmployee3);
        }

        // All values provided
        public Manager(List<Employee> employees, int userID, string username, string password, string firstName, string lastName)
        : base(userID, username, password, firstName, lastName) 
        {
            managedEmployees = employees;
        }

        public List<Employee> ManagedEmployees
        {
            get { return managedEmployees; }
            set { managedEmployees = value; }
        }
    }
}
