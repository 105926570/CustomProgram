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
        EmployeeTaxInfo employeeTaxInfo;
        //Department department;
        //Schedule schedule;
        public PayHistory _payHistory = new PayHistory();
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
            //EmployeeID, username, password are set as their default values in the User default constructor
        }

        public Employee(int employeeID, string username, string password, string firstName, string lastName) : base(employeeID, username, password)//Constructor with all peramaters given manually
        {
            _FirstName = firstName;
            _LastName = lastName;
            //EmployeeID, username, password are set in the base constructor, using values from the employee constructor.
        }

        public Employee(User user, string firstName, string lastName) //Constructor with an allready made user as an input.
        {
            _Username = user.Username;
            _Password = user.Password;
            _EmployeeID = user.ID;
            _FirstName = firstName;
            _LastName = lastName;
            //EmployeeID, username, password are set by a user input.
        }

        public string FullName
        {
            get
            {
                string s = _FirstName + " " + _LastName;
                return s;
            }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public PayHistory PayHistory
        {
            get { return _payHistory; }
            set { _payHistory = value; }
        }

        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Name: {FullName} - ID: {_EmployeeID}");
        }

        public void DisplayAllEmployeeInfo()
        {
            DisplayUserInfo();
            Console.WriteLine("Name: " + FullName);
        }
    }
}

/// TODO:
/// IMPLEMENT PRONOUNS 
///     AS A CLASS?
///     AS TWO STRINGS?