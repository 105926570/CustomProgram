using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Schedule
    {
        public List<Month> _months;

        // Constructor to initialize the Schedule with empty months

        public List<Month> Months
        {
            get { return _months; } 
            set { _months = value; }
        }
        
        public Month MonthFromIndex(int index)
        {
            return _months[index];
        }
    }
}
