using System;

namespace PayrollSystem
{
    public class TimeFrame
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        //Default Constructor
        public TimeFrame() : this(DateTime.Now, DateTime.Now) { }

        public TimeFrame(DateTime start, float hours)
        {
            Start = start;
            End = start.AddHours(hours);
        }

        public TimeFrame(float hours) : this(DateTime.Now, hours)
        {
            End = Start.AddHours(hours);
        }

        public TimeFrame(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}