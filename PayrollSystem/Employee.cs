using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PayrollSystem
{
    public class Employee : User
    {
        string _FirstName, _LastName;
        //Department department;
        //Schedule schedule;
        //PaycheckHistory paycheckHistory;
        //TaxInfo EmployeeTaxInfo;

        public Employee() : base() //Constructor with default values
        {
            _FirstName = "Jhon";
            _LastName = "Doe";
        }

        public Employee(string firstName, string lastName) :base() //Constructor with all peramaters given manually
        {
            _FirstName = firstName;
            _LastName = lastName;
        }

        public Employee(int employeeID, string username, string password, string firstName, string lastName) : base(employeeID, username, password)//Constructor with all peramaters given manually
        {
            _FirstName = firstName;
            _LastName = lastName;
        }

        public string FullName
        {
            get
            {
                string s = _FirstName + " " + _LastName;
                return s;
            }
        }
    }
}

/// TODO:
/// IMPLEMENT PRONOUNS 
///     AS A CLASS?
///     AS TWO STRINGS?