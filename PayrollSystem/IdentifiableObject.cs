using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class IdentifiableObject
    {
        private int _id;

        public IdentifiableObject() //default constructor
        {
            _id = 0; //should be application.generateuniqeid
        }

        public IdentifiableObject(int id) //to be used when loading something from a json for example
        {
            _id = id;
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}