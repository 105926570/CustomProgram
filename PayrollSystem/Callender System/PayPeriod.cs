using System;
using System.Collections.Generic;

namespace PayrollSystem.CallenderSystem
{
    internal class PayPeriod
    {
        private DateTime _startDate, _endDate;
        private List<WorkedShift> _workedShifts;

        public PayPeriod()
        {
            _startDate = DateTime.Now;
            DayOfWeek currentDay = _startDate.DayOfWeek;

            // Assuming Monday is the start of the week:
            int daysSinceMonday = (int)currentDay - (int)DayOfWeek.Monday;
            if (daysSinceMonday < 0)
                daysSinceMonday += 7; // handle Sunday correctly

            _startDate = _startDate.Date.AddDays(-daysSinceMonday);
            _endDate = _startDate.AddDays(7);
        }
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
