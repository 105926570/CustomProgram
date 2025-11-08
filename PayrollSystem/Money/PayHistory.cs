using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class PayHistory
    {
        public List<PayCheck> payChecks = new List<PayCheck> { } ;
        public PayHistory() { }
        public PayHistory(List<PayCheck> payChecks) //Generate the pay history given there is allready a list of paychecks (likely wont be used)
        {
            this.PayChecks = payChecks;
        }

        public List<PayCheck> PayChecks
        {
            get { return payChecks; }
            set { payChecks = value; }
        }
    }
}

// how can i make it so this can only exist if it is tied to a specific employee?