using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    internal class User
    {
        string _Username, _Password;
        int _EmployeeID;

        public User()
        {
        
        }
        public User(int employeeID, string username, string password)
        {
        
        }
        public User(int employeeID)
        {
        
        }

        public string UsernameProperty
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public string PasswordProperty
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public int UserIDProperty
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
    }
}
