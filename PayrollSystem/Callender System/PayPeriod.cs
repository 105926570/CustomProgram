using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace PayrollSystem.CallenderSystem
{
    internal class PayPeriod
    {
        private DateTime _startDate, _endDate;
        private List<WorkedShift> _workedShifts;

        public PayPeriod()
        {
            _startDate = DateTime.Now;
            _startDate = findStartOfWeekGivenAnyDateTime(_startDate);
            _endDate = _startDate.AddDays(7);
        }

        public PayPeriod(DateTime startDate)
        {
            _startDate = findStartOfWeekGivenAnyDateTime(startDate);
            _endDate = _startDate.AddDays(7);
        }

        //this is problemattic, as endDate must ALLWAYS ve startDate + 7 days. --- possibly remove?
        public PayPeriod(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        private DateTime findStartOfWeekGivenAnyDateTime(DateTime startDate)
        {
            DateTime d = startDate;
            DayOfWeek currentDay = d.DayOfWeek;

            // Assuming Monday is the start of the week:
            int daysSinceMonday = (int)currentDay - (int)DayOfWeek.Monday;
            if (daysSinceMonday < 0)
                daysSinceMonday += 7; // handle Sunday correctly

            d = d.Date.AddDays(-daysSinceMonday);
            return d;
        }
    }
}
