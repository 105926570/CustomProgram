using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Week
    {
        private DateTime _startDate, EndDate;
        public List<Day> _Days; //must have 7 days

        // Constructor to initialize the Week with empty days

        public List<Day> Days
        {
            get { return _weeks; }
            set { _weeks = value; }
        }
    }
}
