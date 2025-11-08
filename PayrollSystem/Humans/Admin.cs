using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PayrollSystem.UsefullUniversalCommands;

namespace PayrollSystem
{
    internal class Admin : Employee
    {
        private int _privliage;

        public Admin() : base()
        {
            _privliage = 2; //Privliage of an admin is level 2
        }

        public int Privliage
        {
            get { return _privliage; }
        }
    }
}