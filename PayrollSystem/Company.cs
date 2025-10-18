using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    internal class Company
    {
        public string _companyName;
        //public List<Department> departments;
        public List<Employee> _employees = new List<Employee>();
        //public Payroll payroll;
        //public Schedule schedule;

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
            _employees.Add(emp);
        }
    }
}
