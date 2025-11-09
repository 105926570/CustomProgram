using System.Collections.Generic;
using static PayrollSystem.UsefullUniversalCommands;

namespace PayrollSystem
{
    public class Department
    {
        int _departmentID;
        private string _departmentName;
        private List<Employee> _employees;
        private List<Manager> _managers;

        public Department()
        {
            _departmentID = GenerateRandomNumber(99);
            _departmentName = "Default Department";
            _employees = new List<Employee> { };
            _managers = new List<Manager> { };
        }

        public Department(string name) : this() 
        {
            _departmentName = name;
        }

        public Department(string name, int ID) : this(name) 
        {
            _departmentID = ID;
        }

        public int ID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }
    }
}
