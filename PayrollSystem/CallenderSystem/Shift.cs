using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.CallenderSystem
{
    public class Shift
    {
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }

        public bool isWeekend { get { return startDateTime.DayOfWeek == DayOfWeek.Saturday || startDateTime.DayOfWeek == DayOfWeek.Sunday; } }
        public float HoursScheduled { get { return startDateTime.CompareTo(endDateTime); } }
    }
}
