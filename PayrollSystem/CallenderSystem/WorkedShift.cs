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

        public WorkedShift(DateTime start, float baseRate, float hoursWorked)
        {
            _startDateTime = start;
            _hoursWorked = hoursWorked;
            _endDateTime = _startDateTime.AddHours(_hoursWorked);
            _baseRate = baseRate;
            _isCasual = false;
            _isTraining = false;
        }

        public WorkedShift(DateTime start, float baseRate, float hoursWorked, bool casual, bool training) : this(start, baseRate, hoursWorked)
        {
            _isCasual = casual;
            _isTraining = training;
        }

        public WorkedShift(DateTime start, DateTime end, float baseRate, float hoursWorked, bool casual, bool training) :this(start, baseRate, hoursWorked, casual, training)
        {
            _endDateTime = end;
            if (start.CompareTo(end) != hoursWorked) 
            { 
                _hoursWorked = start.CompareTo(end);
            }
        }

        public float Earnings
        {
            get 
            {
                float earnings = _baseRate * _hoursWorked;
                if (_isCasual == true) earnings *= 1.25f;
                return earnings;
            }
        }
    }
}
