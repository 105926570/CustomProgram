using System;

namespace PayrollSystem
{
    public class Employee : User
    {
        private string _FirstName, _LastName;
        private EmployeeTaxInfo _employeeTaxInfo;
        //Department department;
        private Schedule _schedule;
        private PayHistory _payHistory;
        private int _privilege; // Privilege level of a regular employee is level 0

        public Employee() : base() //Constructor with default values
        {
            _FirstName = "Jhon";
            _LastName = "Doe";
            _employeeTaxInfo = new EmployeeTaxInfo();
            _payHistory = new PayHistory();
            _privilege = 0;
            _schedule = new Schedule();
        }

        //Read only Property
        public string FullName
        {
            get
            {
                string s = FirstName + " " + LastName;
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

        public int Privilege
        {
            get { return _privilege; }
            set { _privilege = value; }
        }

        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Name: {FullName} - ID: {ID}");
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