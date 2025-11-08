using System;
using System.Collections.Generic;

namespace PayrollSystem
{
    public class Month
    {
        private DateTime _startDate, EndDate;
        private List<Week> _weeks;

        // Constructor to initialize the Month with empty weeks

        public List<Week> Weeks
        {
            get { return _weeks; }
            set { _weeks = value; }
        }
    }
}
