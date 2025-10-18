using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Month
    {
        private DateTime _startDate, EndDate;
        public List<Week> _weeks;

        // Constructor to initialize the Month with empty weeks

        public List<Week> Weeks
        {
            get { return _weeks; }
            set { _weeks = value; }
        }
    }
}
