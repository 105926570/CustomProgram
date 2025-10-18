using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PayrollSystem
{
    public class Employee
    {
        string _Username, _Password, _FirstName, _LastName;
        int _EmployeeID;
        //Department department;
        //Schedule schedule;
        //PaycheckHistory paycheckHistory;
        //TaxInfo EmployeeTaxInfo;

        public Employee() //Constructor with default values
        {
            _FirstName = "Jhon";
            _LastName = "Doe";
            _Username = "DefaultEmployee";
            _Password = "password123";
            _EmployeeID = new Random().Next(9999999); //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
        }

        public Employee(string firstName, string lastName) //Constructor with all peramaters given manually
        {
            _FirstName = firstName;
            _LastName = lastName;
            _Username = $"{_FirstName}+{new Random().Next(999)}"; //Generates a username based on first name and a random 3 digit number. Add a check to ensure there is no other username
            _Password = "password123";
            _EmployeeID = new Random().Next(9999999); //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
        }

        public Employee(int employeeID, string username, string password, string firstName, string lastName) //Constructor with all peramaters given manually
        {
            _FirstName = firstName;
            _LastName = lastName;
            _Username = username;
            _Password = password;
            _EmployeeID = employeeID; //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
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