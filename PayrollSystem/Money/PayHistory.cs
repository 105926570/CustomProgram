using System.Collections.Generic;

namespace PayrollSystem
{
    public class PayHistory
    {
        private List<PayCheck> _payChecks;
        public PayHistory()
        {
            PayChecks = new List<PayCheck> { };
        }
        public PayHistory(List<PayCheck> payChecks) //Generate the pay history given there is allready a list of paychecks (likely wont be used)
        {
            PayChecks = payChecks;
        }

        public List<PayCheck> PayChecks
        {
            get { return _payChecks; }
            set { _payChecks = value; }
        }
    }
}

// how can i make it so this can only exist if it is tied to a specific employee?