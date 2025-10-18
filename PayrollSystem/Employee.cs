using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Employee(int userID, string username, string password, string firstName, string lastName)
        {
            UserID = userID;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            FullName = firstName + " " + lastName;
        }

    }
}
