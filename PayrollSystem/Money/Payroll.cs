using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    internal class Payroll
    {
        private List<Employee> _employeesOnPayroll = new List<Employee> { };
        private List<PayHistory> payHistories = new List<PayHistory> { };

        /// <summary>
        /// This is just for generating a payroll. run this with company.Employees as the parameter, and it generates the companies payroll. Upoon the creation of an employee, their PayHistory should be created. an Employees payhistory must be consistently updated with schedule, shift, ect. 
        /// </summary>
        /// <param name="employees"></param>
        public Payroll(List<Employee> employees)
        {
            _employeesOnPayroll = employees;
            foreach (Employee e in _employeesOnPayroll)
            {
                payHistories.Add(e.PayHistory);
            }
        }
    }
}
