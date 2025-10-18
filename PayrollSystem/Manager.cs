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

        public Manager() : base() //Default constructor / Test constructor
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

        public Manager(int userID, string username, string password, string firstName, string lastName) : base(userID, username, password, firstName, lastName) //All values provided except employees
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

        public Manager(List<Employee> employees, int userID, string username, string password, string firstName, string lastName) : base(userID, username, password, firstName, lastName) // All values provided
        {
            managedEmployees = employees;
        }
    }
}
