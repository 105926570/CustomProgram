using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Shift : TimeFrame
    {
        public bool isWeekend { get { return StartDateTime.DayOfWeek == DayOfWeek.Saturday || StartDateTime.DayOfWeek == DayOfWeek.Sunday; } }
        public float HoursScheduled { get { return StartDateTime.CompareTo(EndDateTime); } }
    }
}
