using System;

namespace PayrollSystem
{
    public class Employee : User
    {
        private string _FirstName, _LastName;
        private EmployeeTaxInfo _employeeTaxInfo;
        //Department department;
        //Schedule schedule;
        private PayHistory _payHistory;
        //TaxInfo EmployeeTaxInfo;
        private int _privilege; // Privilege level of a regular employee is level 0
        private bool _isResident;

        public Employee() : base() //Constructor with default values
        {
            _FirstName = "Jhon";
            _LastName = "Doe";
            _privilege = 0;
        }

        public Employee(string firstName, string lastName) : base() //Constructor with all peramaters given manually
        {
            _FirstName = firstName;
            _LastName = lastName;
            _privilege = 0;
            //EmployeeID, username, password are set as their default values in the User default constructor
        }

        public Employee(int employeeID, string username, string password, string firstName, string lastName) : base(employeeID, username, password)//Constructor with all peramaters given manually
        {
            _FirstName = firstName;
            _LastName = lastName;
            _privilege = 0;
            //EmployeeID, username, password are set in the base constructor, using values from the employee constructor.
        }

        public Employee(User user, string firstName, string lastName) //Constructor with an allready made user as an input.
        {
            _Username = user.Username;
            _Password = user.Password;
            _EmployeeID = user.ID;
            _FirstName = firstName;
            _LastName = lastName;
            _privilege = 0;
            //EmployeeID, username, password are set by a user input.
        }

        //Read only Property
        public string FullName { get { return _FirstName + " " + _LastName; } }

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

        public int Privilege
        {
            get { return _privilege; }
        }

        public bool IsResident
        {
            get { return _isResident; }
        }

        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Name: {FullName} - ID: {_EmployeeID}");
        }

        public void DisplayAllEmployeeInfo()
        {
            Console.WriteLine(ReturnUserInfoAsString());
            Console.WriteLine("Name: " + FullName);
        }
    }
}

/// TODO:
/// IMPLEMENT PRONOUNS 
///     AS A CLASS?
///     AS TWO STRINGS?
/// ADD CONTACT INFORMATION
///     PHONE NUMBER
///     EMAIL