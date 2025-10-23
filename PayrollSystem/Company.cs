using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PayrollSystem.UsefullUniversalCommands;

namespace PayrollSystem
{
    internal class Company
    {
        private string _companyName;
        private List<Department> _departments = new List<Department>();
        private List<Employee> _employees = new List<Employee>();
        private Image _companyLogo;
        public Color _secondaryColor, _primaryColor, _accentColur;
        private Payroll _payroll;
        private Schedule _companySchedule;

        public Company()
        {
            _companyName = "The Big Company that needs a better name, and also a payroll system";
        }

        public Company(string name)
        {
            _companyName = name; //im not sure why anyone would want to name their company anything but "The Big Company that needs a better name, and also a payroll system", but ok.
        }

        public string Name
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public List<Department> Departments
        {
            get { return _departments; }
            set { _departments = value; }
        }

        public List<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        public Image Logo
        {
            get { return _companyLogo; }
            set { _companyLogo = value; }
        }

        public Payroll CompanyPayroll
        {
            get { return _payroll; }
            set { _payroll = value; }
        }

        public Schedule CompanySchedule
        {
            get { return _companySchedule; }
            set { _companySchedule = value; }
        }   

        public void CreateEmployee(Employee emp) //This should be the only way to add and create employees
        {
            bool matchingId = false;
            bool newIdMatching = false;
            int randomID = GenerateRandomNumber(9999999);
            foreach (Employee e in _employees)
            {
                if(e.ID == emp.ID)
                {
                   matchingId = true;
                }
            }

            while (matchingId == true)
            {
                foreach (Employee e in _employees)
                {
                    if (e.ID == randomID)
                    {
                        newIdMatching = true;
                    }
                }

                if (newIdMatching == true)
                {
                    matchingId = true;
                    randomID = GenerateRandomNumber(9999999);
                }
                else
                {
                    matchingId = false;
                }

                emp.ID = randomID;
            }
            _employees.Add(emp);
        }
    }
}

/// TODO:
/// Change it so it is just the largest employee ID + 1 instead of a stupid random number that is annoying and stupid (why didnt i think of that XD)