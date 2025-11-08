using System;
using static PayrollSystem.UsefullUniversalCommands;

namespace PayrollSystem
{
    public class User
    {
        private string _Username, _Password, _email;
        private int _EmployeeID;

        public User()
        {
            Username = "DefaultUser";
            Password = "password123";
            ID = GenerateRandomNumber(9999999); //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
            Email = $"{_EmployeeID}@company.com";
        }

        public User(string username, string password) : this(username)
        { 
            Password = password;
        }

        public User(string username, string password, string email) 
        {
            //make this please
        }

        public User(string username) : this()
        {
            Username = username;
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


//[PREFERABLY]: $"{_FirstName}+{new Random().Next(999)}"; //Generates a username based on first name and a random 3 digit number. Add a check to ensure there is no other username