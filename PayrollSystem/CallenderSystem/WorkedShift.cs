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

        public WorkedShift(float baseRate, float hoursWorked, bool casual, bool training)
        {
            _baseRate = baseRate;
            _hoursWorked = hoursWorked;
            _isCasual = casual;
            _isTraining = training;
        }

        public WorkedShift(float baseRate, float hoursWorked)
        {
            _baseRate = baseRate;
            _hoursWorked = hoursWorked;
            _isCasual = false;
            _isTraining = false;
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
