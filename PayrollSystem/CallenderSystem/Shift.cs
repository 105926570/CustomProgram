using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Shift : TimeFrame
    {
        // these both should be here and not time frame, as they determine the final pay of shift. this is not needed for leave, or avaliability.
        public bool isWeekend { get { return StartDateTime.DayOfWeek == DayOfWeek.Saturday || StartDateTime.DayOfWeek == DayOfWeek.Sunday; } }
        public float HoursScheduled { get { return StartDateTime.CompareTo(EndDateTime); } }
    }
}
