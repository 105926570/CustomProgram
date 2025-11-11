using System.Collections.Generic;

namespace PayrollSystem
{
    public class Schedule
    {
        private List<Month> _months;

        // Constructor to initialize the Schedule with empty months

        public List<Month> Months
        {
            get { return _months; }
            set { _months = value; }
        }

        public Month MonthFromIndex(int index)
        {
            return Months[index];
        }
    }
}
