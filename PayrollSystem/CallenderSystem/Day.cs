using System;
using System.Collections.Generic;

namespace PayrollSystem
{
    public class Day
    {
        //start dateTime, end dateTime
        private List<TimeFrame> _timeFrames;

        // Constructor to initialize the Day with empty TimeFrames

        public TimeFrame TimeFrameFromListIndex(int index)
        {
            if (_timeFrames[index] == null)
            {
                Console.WriteLine($"Errod: No Time frame found at index {index.ToString()} ");
                return null;
            }
            else
            {
                return _timeFrames[index];
            }
        }

        public List<TimeFrame> TimeFrames
        {
            get { return _timeFrames; }
            set { _timeFrames = value; }
        }
    }
}
