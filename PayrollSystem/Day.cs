using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Day
    {
        //start dateTime, end dateTime
        public List<TimeFrame> _timeFrames;

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
    }
}
