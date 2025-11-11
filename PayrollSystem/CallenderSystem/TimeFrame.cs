using System;

namespace PayrollSystem
{
    public class TimeFrame
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        //Default Constructor
        public TimeFrame() : this(DateTime.Now, DateTime.Now) { }

        public TimeFrame(DateTime start, float hours)
        {
            StartDateTime = start;
            EndDateTime = start.AddHours(hours);
        }

        public TimeFrame(float hours) : this(DateTime.Now, hours)
        {
            EndDateTime = StartDateTime.AddHours(hours);
        }

        public TimeFrame(DateTime start, DateTime end)
        {
            StartDateTime = start;
            EndDateTime = end;
        }
    }
}