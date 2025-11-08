using System;
using System.Collections.Generic;

namespace PayrollSystem
{
    public class Week
    {
        private DateTime _startDate, EndDate;
        public List<Day> _Days; //must have 7 days

        // Constructor to initialize the Week with empty days

        public List<Day> Days
        {
            get { return _Days; }
            set { _Days = value; }
        }

        public Day DayOfWeekFromListIndex(int dayOfWeek) //1 = Monday, 2 = Tuesday, ..., 7 = Sunday
        {
            if (dayOfWeek < 0 || dayOfWeek > 7)
            {
                Console.WriteLine("Error: Day of week cannot be less than 0 or greater than 7.\n Please input a number between 1 - 7");
                return null;
            }
            else
            {
                return _Days[dayOfWeek];
            }
        }
    }
}
