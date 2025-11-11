using PayrollSystem.CallenderSystem;
using System;

namespace PayrollSystem
{
    public class WorkedShift : Shift
    {
        private float _baseRate;
        private float _hoursWorked;
        private bool _isCasual;
        private bool _isTraining;
        private bool _isPublicHoliday;

        #region Constructors
        //Default constructor
        public WorkedShift()
        {
            startDateTime = DateTime.Now;
            endDateTime = DateTime.Now.AddHours(3);  //make it company minumum shift length
            _baseRate = 24.95f;  //make it update with adult minimum wage
            _hoursWorked = 3;//make it company minumum shift length
            _isCasual = false;
            _isTraining = false;
        }


        #region Hours worked Not Given
        // Hours Not Worked Constructors
        public WorkedShift(DateTime start, float baseRate) : base()
        {
            startDateTime = start;
            endDateTime = startDateTime.AddHours(_hoursWorked);
            _baseRate = baseRate;
        }

        public WorkedShift(DateTime start, float baseRate, bool casual, bool training) : this(start, baseRate)
        {
            _isCasual = casual;
            _isTraining = training;
        }

        public WorkedShift(DateTime start, DateTime end, float baseRate, bool casual, bool training) : this(start, baseRate, casual, training)
        {
            endDateTime = end;
            _hoursWorked = end.CompareTo(start);
        }
        #endregion


        #region Hours worked is given
        // Hours Worked Constructors
        public WorkedShift(DateTime start, float baseRate, float hoursWorked) : base()
        {
            startDateTime = start;
            _baseRate = baseRate;
            _hoursWorked = hoursWorked;
            endDateTime = startDateTime.AddHours(_hoursWorked);
        }

        public WorkedShift(DateTime start, float baseRate, float hoursWorked, bool casual, bool training) : this(start, baseRate, hoursWorked)
        {
            _isCasual = casual;
            _isTraining = training;
        }

        #endregion
        #endregion

        #region Properties
        //Properties of a shift that an employee may want to know
        public DayOfWeek dayOfWeek { get { return startDateTime.DayOfWeek; } }


        #region Properties for calculating earnings
        //Properties for calculating earnings
        private float baseEarnings { get { return _baseRate * _hoursWorked; } }
        private float casualBonus { get { return this.baseEarnings * 0.25f; } }
        private float trainingBonus { get { return this.baseEarnings * 0.25f; } }
        private float weekendBonus { get { return this.baseEarnings * 0.25f; } }
        private float publicHolidayBonus { get { return this.baseEarnings * 0.25f; } }

        public float Earnings
        {
            get
            {
                float earnings = this.baseEarnings;
                if (_isCasual == true) earnings += this.casualBonus;
                if (_isTraining == true) earnings += this.trainingBonus;
                if (isWeekend == true) earnings += this.weekendBonus;
                if (_isPublicHoliday == true) earnings += this.publicHolidayBonus;
                return earnings;
            }
        }
        #endregion
        #endregion
    }
}

/*
 * TODO:
 *  Make it so that the multipliers of base rate, base earnings, ect is stored in the company class and can be eddited by a master admin.
 */