using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PayrollSystem
{
    public class Employee
    {
        string Username, Password, FirstName, LastName, FullName;
        int UserID;
        //Department department;
        //Schedule schedule;
        //PaycheckHistory paycheckHistory;
        //TaxInfo EmployeeTaxInfo;

        public Employee() //Constructor with default values
        {
            FirstName = "Jhon";
            LastName = "Doe";
            FullName = FirstName + " " + LastName;
            Username = "DefaultEmployee";
            Password =  "password123";
            UserID = new Random().Next(9999999); //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
        }

        public Employee(string firstName, string lastName) //Constructor with all peramaters given manually
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = firstName + " " + lastName;
            Username = $"{FirstName}+{new Random().Next(999)}"; //Generates a username based on first name and a random 3 digit number. Add a check to ensure there is no other username
            Password = "password123";
            UserID = new Random().Next(9999999); //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
        }

        public Employee(int userID, string username, string password, string firstName, string lastName) //Constructor with all peramaters given manually
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = firstName + " " + lastName;       
            Username = username;
            Password = password;
            UserID = userID; //User ID should be a random number generated when creating a new employee, and not equal to any other existing User ID.
        }
    }
}
