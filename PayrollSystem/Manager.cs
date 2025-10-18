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
        { }

        //All values provided except employees
        public Manager(int userID, string username, string password, string firstName, string lastName)
        : base(userID, username, password, firstName, lastName)
        { }

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
