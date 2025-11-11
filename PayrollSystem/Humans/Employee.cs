using Newtonsoft.Json;
using System;
using static PayrollSystem.Program;

namespace PayrollSystem
{
    public class Employee : User
    {
        private string _firstName, _lastName;
        private EmployeeTaxInfo _employeeTaxInfo;
        //Department department;
        public Schedule Schedule { get; set; }
        private PayHistory _payHistory;

        public Employee() : base() //Constructor with default values
        {
            _firstName = "Jhon";
            _lastName = "Doe";
            _employeeTaxInfo = new EmployeeTaxInfo();
            _payHistory = new PayHistory();
            Schedule = new Schedule();
        }

        public Employee(string firstName, string lastName, string Username, string Password) : base(Username, Password)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        // Read only Property - as in can only be changed by the class and not by a function.
        // FullName should ALLWAYS reflect: $"{FirstName} {LastName}"
        [JsonIgnore]
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

        public void Save()
        {
            Save(employeesDirectory);
        }

        public void Save(string employeesDirectory)
        {
            CreateJsonFromObject(this, $"{employeesDirectory}\\emp{this.ID}.json");
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