using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PayrollSystem.Program;
using static PayrollSystem.ApplicationSystems.Miscf;
using static PayrollSystem.UsefullUniversalCommands;

namespace PayrollSystem.ApplicationSystems
{
    internal static class TestingFunctions
    {
        #region Tests - To be deleted at the end of project

        private static void jsonTesting(string _rootFolder)
        {
            Console.WriteLine("Starting Test 1");

            CreateJsonFromObject(new User(), _rootFolder + "\\jsons\\testUserJson.json");
            CreateJsonFromObject(new Employee(), _rootFolder + "\\jsons\\testEmployeeJson.json");
            Employee test1 = new Employee("Bob", "lastname", "bob123", "bobssupersecretpassword123");
            Employee test2 = new Employee("firstName", "lastName", "username123", "password123");
            List<Employee> h = new List<Employee> { test1, test2 };
            Company company = new Company() { Name = "the big company lol", Employees = h };
            Console.WriteLine("Now... The big boy test...");
            CreateJsonFromObject(company, _rootFolder + "\\jsons\\BigBoyTest.json");

            //Test reading a JSON then saving what is read
            string testamondo = Path.GetDirectoryName(_rootFolder + "\\jsons\\BigBoyTest.json");
            testamondo = testamondo + "\\bigFatTestBruv.json";
            CreateJsonFromObject(JsonConvert.DeserializeObject(File.ReadAllText(_rootFolder + "\\jsons\\BigBoyTest.json")), testamondo);

            //test getting file directories.
            string[] files = Directory.GetFiles($"{_rootFolder}\\jsons");
            foreach (string file in files)
            {
                Console.WriteLine($"{file}");
            }
        }

        public static void fullProgramTesting()
        {
            Department departmentDefault = new Department();
            Department departmentCleaning = new Department("Cleaning");
            Department departmentSales = new Department("Sales");
            Department departmentHR = new Department("HR");

            Employee emp1 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");
            Employee emp2 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");
            Employee emp3 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");
            Employee emp4 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");
            Employee emp5 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");
            Employee emp6 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");
            Employee emp7 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");
            Employee emp8 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");
            Employee emp9 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");
            Employee emp10 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");
            Employee emp11 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");
            Employee emp12 = new Employee(RandomFirstName(), RandomLastName(), $"username123{GenerateRandomNumber(99)}", $"password123{GenerateRandomNumber(99)}");

            // Add employees to the departments
            departmentDefault.Employees.Add(emp1);
            departmentDefault.Employees.Add(emp2);
            departmentDefault.Employees.Add(emp3);

            departmentCleaning.Employees.Add(emp4);
            departmentCleaning.Employees.Add(emp5);
            departmentCleaning.Employees.Add(emp6);

            departmentSales.Employees.Add(emp7);
            departmentSales.Employees.Add(emp8);
            departmentSales.Employees.Add(emp9);

            departmentHR.Employees.Add(emp10);
            departmentHR.Employees.Add(emp11);
            departmentHR.Employees.Add(emp12);

            Company company = new Company("TestCompany", new List<Department> { departmentDefault, departmentCleaning, departmentSales, departmentHR });

            SaveCompany(company);


            Console.WriteLine("saved everyting");
        }

        #endregion
    }
}
