using System.Collections.Generic;

namespace PayrollSystem
{
    public class Schedule
    {
        public TimeFrame[] TimeFrames { get; set; }

        /// <summary>Creates a schedule with a blank time frame </summary>
        public Schedule()
        {
            TimeFrames = new TimeFrame[] { };
        }

        /// <summary> Creates a schedule with an array of given time frames </summary>
        /// <param name="timeFrames"> The time frames witch will be added to the schedule. </param>
        public Schedule(TimeFrame[] timeFrames)
        {
            TimeFrames = timeFrames;
        }
    }
}
