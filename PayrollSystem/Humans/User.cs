using System;
using static PayrollSystem.UsefullUniversalCommands;

namespace PayrollSystem
{
    public class User : IdentifiableObject
    {
        private string _username, _password, _email;
        private int _privliage;

        public User() : base() //Default constructor
        {
            Privliage = 0; //starts off as 0
            Username = $"user{ID}";
            Password = "password123"; //make it random
            Email = $"{ID}@company.com"; //make it company name from application perhaps?
        }
        public User(string username) : this()
        {
            Username = username;
        }

        public User(string username, string password) : this(username)
        {
            Password = password;
        }

        public User(string username, string password, string email) : this(username, password)
        {
            // add a check to see if it's a valid email.
            Email = email;
        }

        public int Privliage
        {
            get { return _privliage; }
            set { _privliage = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string ReturnUserInfoAsString()
        {
            return $"Employee ID: {ID}\n" +
                   $"Username: {Username}\n" +
                   $"Password: {Password}\n" +
                   $"Email: {Email}";
        }
    }
}


//[PREFERABLY]: $"{_FirstName}+{new Random().Next(999)}"; //Generates a username based on first name and a random 3 digit number. Add a check to ensure there is no other username