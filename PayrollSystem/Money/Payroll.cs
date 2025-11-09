using System.Collections.Generic;

namespace PayrollSystem
{
    internal class Payroll
    {
        private List<Employee> _employeesOnPayroll;
        private List<PayHistory> _payHistories;



        public Payroll()
        {
            PayHistories = new List<PayHistory>() { };
            EmployeesOnPayroll = new List<Employee> { };
        }

        /// <summary>
        /// This is just for generating a payroll. run this with company.Employees as the parameter, and it generates the companies payroll. Upoon the creation of an employee, their PayHistory should be created. an Employees payhistory must be consistently updated with schedule, shift, ect. 
        /// </summary>
        /// <param name="employees"></param>
        public Payroll(List<Employee> employees)
        {
            EmployeesOnPayroll = employees;
            foreach (Employee emp in EmployeesOnPayroll)
            {
                PayHistories.Add(emp.PayHistory);
            }
        }

        public List<Employee> EmployeesOnPayroll
        {
            get { return _employeesOnPayroll; }
            set { _employeesOnPayroll = value; }
        }

        public List<PayHistory> PayHistories
        {
            get { return _payHistories; }
            set { _payHistories = value; }
        }
    }
}






/******************************************************************************

PayHistories Pseuidocode:

        public List<PayHistory> PayHistories
        {
            get {
                //read the files of every user
                //save the payhistories
                //convert them to actual payHistories
                //return them
                return _payHistories;
            }
            set { _payHistories = value; }
        }

******************************************************************************/

/******************************************************************************


EmployeesOnPayroll Pseudocode:

        public List<Employee> EmployeesOnPayroll
        {
            get {
                // just set this equal to the Company.Employee since all of their employees areon the payroll anyway
                // return it
                return _employeesOnPayroll;
            }
            set { _employeesOnPayroll = value; }
        }

******************************************************************************/