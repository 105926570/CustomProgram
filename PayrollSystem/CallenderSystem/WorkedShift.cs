using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.CallenderSystem
{
    internal class WorkedShift
    {
        private DateTime _startDateTime, _endDateTime;
        private float _baseRate;
        private float _hoursWorked;
        private bool _isCasual;
        private bool _isTraining;
        private bool _isPublicHoliday;
        private bool _isWeekend;

#region Constructors
        //Default constructor
        public WorkedShift()
        {
            _startDateTime = DateTime.Now;
            _endDateTime = DateTime.Now.AddHours(3);  //make it company minumum shift length
            _baseRate = 24.95f;  //make it update with adult minimum wage
            _hoursWorked = 3;//make it company minumum shift length
            _isCasual = false;
            _isTraining = false;
        }


    #region Hours worked Not Given
        // Hours Not Worked Constructors
        public WorkedShift(DateTime start, float baseRate) : base()
        {
            _startDateTime = start;
            _endDateTime = _startDateTime.AddHours(_hoursWorked);
            _baseRate = baseRate;
        }

        public WorkedShift(DateTime start, float baseRate, bool casual, bool training) : this(start, baseRate)
        {
            _isCasual = casual;
            _isTraining = training;
        }

        public WorkedShift(DateTime start, DateTime end, float baseRate, bool casual, bool training) : this(start, baseRate, casual, training)
        {
            _endDateTime = end;
            _hoursWorked = end.CompareTo(start);
        }
    #endregion


    #region Hours worked is given
        // Hours Worked Constructors
        public WorkedShift(DateTime start, float baseRate, float hoursWorked) :base() 
        {
            _startDateTime = start;
            _baseRate = baseRate;
            _hoursWorked = hoursWorked;
            _endDateTime = _startDateTime.AddHours(_hoursWorked);
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
        public DateTime startDateTime { get { return _startDateTime; } }
        public DateTime endDateTime { get { return _endDateTime; } }


    #region Properties for calculating earnings
        //Properties for calculating earnings
        private float baseEarnings { get { return _baseRate * _hoursWorked; } }
        private float casualBonus { get { return this.baseEarnings * 0.25f; } }
        private float trainingBonus { get { return this.baseEarnings * 0.25f; } }
        private float weekendBonus { get { return this.baseEarnings * 0.25f; } }
        private float publicHolidayBonus { get { return this.baseEarnings * 0.25f;  } }

        public float Earnings
        {
            get 
            {
                float earnings = this.baseEarnings;
                if (_isCasual == true) earnings += this.casualBonus;
                if (_isTraining == true) earnings += this.trainingBonus;
                if (_isWeekend == true) earnings += this.weekendBonus;
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