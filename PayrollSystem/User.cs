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
        int _UserID;

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
            get { return UserID; }
            set { UserID = value; }
        }
    }
}
