using Newtonsoft.Json;
using System;
using static PayrollSystem.Program;

namespace PayrollSystem
{
    public class Employee : User
    {

/******************** PROPERTIES ********************/

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeTaxInfo EmployeeTaxInfo { get; set; }
        public Schedule Schedule { get; set; }
        public PayHistory PayHistory { get; set; }
        [JsonIgnore]
        public string FullName { get { return FirstName + " " + LastName; } }

/****************************************************/

        //Defaul Constructor
        public Employee() : base()
        {
            FirstName = RandomFirstName();
            LastName = RandomLastName();
            EmployeeTaxInfo = new EmployeeTaxInfo();
            PayHistory = new PayHistory();
            Schedule = new Schedule();
        }

        public Employee(string firstName, string lastName, string Username, string Password) : base(Username, Password)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Employee(string firstName, string lastName, string Username, string Password, EmployeeTaxInfo taxInfo, Schedule schedule, PayHistory payHistory) : this(firstName, lastName, Username, Password)
        {
            EmployeeTaxInfo = taxInfo;
            PayHistory = payHistory;
            Schedule = schedule;
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