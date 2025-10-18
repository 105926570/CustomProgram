using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PayrollSystem.UsefullUniversalCommands;

namespace PayrollSystem
{
    public class Department
    {
        int _departmentID;
        private string _departmentName;
        private List<Employee> _employees = new List<Employee> { };
        private List<Manager> _managers = new List<Manager> { };

        public Department()
        {
            _departmentID = GenerateRandomNumber(99);
            _departmentName = "Default Department";
        }

        public Department(string name)
        {
            _departmentName = name;
        }

        public Department(string name, int ID)
        {
            _departmentID = ID;
            _departmentName = name;
        }

        public int ID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }
    }
}
