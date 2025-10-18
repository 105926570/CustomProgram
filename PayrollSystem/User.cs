using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class User
    {
        string _Username, _Password;
        int _EmployeeID;

        public User()
        {
            _Username = "DefaultUser";
            _Password = "password123";
            _EmployeeID = new Random().Next(9999999); //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
        }

        public User(string firstName, string lastName) //Constructor with all peramaters given manually
        {
            _Username = "jhondoe123"; //[PREFERABLY]: $"{_FirstName}+{new Random().Next(999)}"; //Generates a username based on first name and a random 3 digit number. Add a check to ensure there is no other username
            _Password = "password123";
            _EmployeeID = new Random().Next(9999999); //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
        }

        public User(int employeeID, string username, string password, string firstName, string lastName) //Constructor with all peramaters given manually
        {
            _Username = username;
            _Password = password;
            _EmployeeID = employeeID; //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
        }

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
    }
}
