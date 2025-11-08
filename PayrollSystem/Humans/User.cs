using System;
using static PayrollSystem.UsefullUniversalCommands;

namespace PayrollSystem
{
    public class User
    {
        public string _Username, _Password, _email;
        public int _EmployeeID;

        public User()
        {
            _Username = "DefaultUser";
            _Password = "password123";
            _EmployeeID = GenerateRandomNumber(9999999); //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
            _email = $"{_EmployeeID}@company.com";
        }

        public User(string firstName, string lastName) //Constructor with all peramaters given manually
        {
            _Username = "jhondoe123"; //[PREFERABLY]: $"{_FirstName}+{new Random().Next(999)}"; //Generates a username based on first name and a random 3 digit number. Add a check to ensure there is no other username
            _Password = "password123";
            _EmployeeID = GenerateRandomNumber(9999999); //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
            _email = $"{_EmployeeID}@company.com";
        }

        public User(int employeeID, string username, string password) //Constructor with all peramaters given manually
        {
            _Username = username;
            _Password = password;
            _EmployeeID = employeeID; //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
            _email = $"{_EmployeeID}@company.com";
        }

        public string Email
        {
            get { return _Username; }
            set { _Username = value; }
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

        public int ID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        public string ReturnUserInfoAsString()
        {
            Console.WriteLine("Displaying user info:");
            return $"Employee ID: {_EmployeeID}\n" +
                   $"Username: {_Username}\n" +
                   $"Password: {_Password}\n" +
                   $"Email: {_email}";
        }
    }
}
