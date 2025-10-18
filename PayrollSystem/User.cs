using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    internal class User
    {
        string Username, Password;
        int UserID;

        public User()
        {
        
        }
        public User(int userID, string username, string password)
        {
        
        }
        public User(int userID)
        {
        
        }

        public string UsernameProperty
        {
            get { return Username; }
            set { Username = value; }
        }

        public string PasswordProperty
        {
            get { return Password; }
            set { Password = value; }
        }

        public int UserIDProperty
        {
            get { return UserID; }
            set { UserID = value; }
        }
    }
}
