using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayrollSystem
{
    public class Payroll
    {
        public List<PayHistory> PayHistories { get; set; }
        public Payroll() : this(new List<PayHistory>()) { }
        public Payroll(List<PayHistory> payHistories) { PayHistories = payHistories; }
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