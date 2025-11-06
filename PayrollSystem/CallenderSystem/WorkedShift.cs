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



        private float baseEarnings { get { return _baseRate * _hoursWorked; } }
        private float casualBonus { get { return this.baseEarnings * 0.25f; } }

        public float Earnings
        {
            get 
            {
                float earnings = this.baseEarnings;
                if (_isCasual == true) earnings += casualBonus;
                return earnings;
            }
        }
    }
}
