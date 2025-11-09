using System;

namespace PayrollSystem
{
    public class Employee : User
    {
        private string _firstName, _lastName;
        private EmployeeTaxInfo _employeeTaxInfo;
        //Department department;
        private Schedule _schedule;
        private PayHistory _payHistory;
        private int _privilege; // Privilege level of a regular employee is level 0

        public Employee() : base() //Constructor with default values
        {
            _firstName = "Jhon";
            _lastName = "Doe";
            _employeeTaxInfo = new EmployeeTaxInfo();
            _payHistory = new PayHistory();
            _privilege = 0;
            _schedule = new Schedule();
        }

        public Employee(string firstName, string lastName, string Username, string Password) : base(Username, Password)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        // Read only Property - as in can only be changed by the class and not by a function.
        // FullName should ALLWAYS reflect: $"{FirstName} {LastName}"
        public string FullName
        {
            get { return _firstName + " " + _lastName; } //test if this updates every time its ran.
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public PayHistory PayHistory
        {
            get { return _payHistory; }
            set { _payHistory = value; }
        }

        public int Privilege
        {
            get { return _privilege; }
            set { _privilege = value; }
        }

        // Maybe change to string so that its up to the caller to print it?
        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Name: {FullName} - ID: {ID}");
        }

        // Maybe change to string so that its up to the caller to print it?
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