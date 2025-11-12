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
        private PayHistory PayHist;
        public PayHistory PayHistory { get { return PayHist;  } set { PayHist = value;  } }
        private DateTime _birthDate; //to be inputted when creating employee
        [JsonIgnore]
        public string FullName { get { return FirstName + " " + LastName; } }


        /****************************************************/

        //Defaul Constructor
        public Employee() : base()
        {
            FirstName = RandomFirstName();
            LastName = RandomLastName();
            EmployeeTaxInfo = new EmployeeTaxInfo();
            PayHistory = new PayHistory(this);
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
            Console.WriteLine($"Schedule: {PayHistory}");
            foreach (PayCheck pc in PayHistory.PayChecks)
            {
                Console.WriteLine($"Paychecks {pc.Rate}");
            }
        }

        public void Save()
        {
            Save(employeesDirectory);
        }

        public void Save(string employeesDirectory)
        {
            CreateJsonFromObject(this, $"{employeesDirectory}\\emp{this.ID}.json");
        }

        public float Rate
        {
            get
            {
                float ageInYears = DateTime.Now.Year - _birthDate.Year;

                switch (ageInYears)
                {
                    case 16:
                        return federalMinimumWage * 0.473f;
                    case 17:
                        return federalMinimumWage * 0.578f;
                    case 18:
                        return federalMinimumWage * 0.683f;
                    case 19:
                        return federalMinimumWage * 0.825f;
                    case 20:
                        return federalMinimumWage * 0.977f;
                    default:
                        if (ageInYears < 16) { return federalMinimumWage * 0.368f; }
                        else { return federalMinimumWage; }
                }
            }
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