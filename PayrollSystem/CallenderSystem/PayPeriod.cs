using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.CallenderSystem
{
    internal class PayPeriod
    {
        private DateTime _startDate, _endDate;
        private List<WorkedShifts> _workedShifts;

        public PayPeriod(DateTime startDate)
        {
            _startDate = startDate;
            _endDate = startDate.AddDays(7);
        }
        public PayPeriod(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }
    }
}
