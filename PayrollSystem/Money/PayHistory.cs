using System.Collections.Generic;

namespace PayrollSystem
{
    public class PayHistory
    {
        public List<PayCheck> PayChecks { get; set; }
        public Employee payHistoriesEmployee { get; set; }
        public PayHistory(Employee employee)
        {
            payHistoriesEmployee = employee;
        }
        public PayHistory(Employee employee, List<PayCheck> payChecks) : this(employee)
        {
            PayChecks = new List<PayCheck> { };
            foreach (PayCheck check in payChecks)
            {
                check.Rate = payHistoriesEmployee.Rate;
            }
        }
        public PayHistory(List<PayCheck> payChecks) //Generate the pay history given there is allready a list of paychecks (likely wont be used)
        {
            PayChecks = payChecks;
        }
    }
}

// how can i make it so this can only exist if it is tied to a specific employee?