using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    internal class Company
    {
        public string companyName;
        //public List<Department> departments;
        public List<Employee> employees = new List<Employee>();
        //public Payroll payroll;
        //public Schedule schedule;
    }
}
