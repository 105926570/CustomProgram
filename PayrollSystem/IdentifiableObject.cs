using static PayrollSystem.Program;

namespace PayrollSystem
{
    public class IdentifiableObject
    {
        private int _id;

        /// <summary>ID is randomly generated with length 7</summary>
        public IdentifiableObject() //default constructor
        {
            ID = rand.Next(9999999); //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
        }

        /// <summary>ID is defined</summary>
        public IdentifiableObject(int id) //to be used when loading something from a json for example
        {
            ID = id;
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}