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
        public string _companyName;
        public List<Department> _departments = new List<Department>();
        public List<Employee> _employees = new List<Employee>();
        public Image _companyLogo;
        public Color _secondaryColor, _primaryColor, _accentColur;
        public Payroll _payroll;
        public Schedule _companySchedule;

        public Company()
        {
            _companyName = "The Big Company that needs a better name, and also a payroll system";
        }

        public Company(string name)
        {
            _companyName = name; //im not sure why anyone would want to name their company anything but "The Big Company that needs a better name, and also a payroll system", but ok.
        }

        public void CreateEmployee(Employee emp) //This should be the only way to add and create employees
        {
            bool matchingId = false;
            bool newIdMatching = false;
            int randomID = GenerateRandomNumber(9999999);
            foreach (Employee e in _employees)
            {
                if(e.EmployeeID == emp.EmployeeID)
                {
                   matchingId = true;
                }
            }

            while (matchingId == true)
            {
                foreach (Employee e in _employees)
                {
                    if (e.EmployeeID == randomID)
                    {
                        newIdMatching = true;
                    }
                }

                if (newIdMatching == true)
                {
                    matchingId = true;
                    randomID = new Random(datetime.Millisecond).Next(9999999);
                }
                else
                {
                    matchingId = false;
                }

                emp.EmployeeID = randomID;
            }
            _employees.Add(emp);
        }
    }
}

/// TODO:
/// Change it so it is just the largest employee ID + 1 instead of a stupid random number that is annoying and stupid (why didnt i think of that XD)