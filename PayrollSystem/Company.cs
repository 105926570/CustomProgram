using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using static PayrollSystem.UsefullUniversalCommands;
using static PayrollSystem.Program;

namespace PayrollSystem
{
    public class Company
    {
        private string _companyName;
        private List<Department> _departments;
        private List<Employee> _employees;
        private Image _companyLogo;
        private Color _secondaryColor, _primaryColor, _accentColur; //NOT PUBLIC IN ANY WAY YET!!!!
        private Payroll _payroll;
        private Schedule _companySchedule;
        private static List<int> _employeeIDs, _departmentIDs; //This is what is saved to a json instead, rather than the whole entire employee info.

        public Company() //Default Constructor
        {
            Name = "The Big Company that needs a better name, and also a payroll system";
            Departments = new List<Department>();
            Employees = new List<Employee>();
            CompanyPayroll = new Payroll();
            CompanySchedule = new Schedule();
        }

        public Company(string companyName) : this()
        {
            Name = companyName; //im not sure why anyone would want to name their company anything but "The Big Company that needs a better name, and also a payroll system", but ok.
        }

        public Company(string companyName, List<Department> departments) : this(companyName)
        {
            Departments = departments;

            List<Employee> emps = new List<Employee> { };
            foreach (Department department in Departments)
            {
                foreach (Employee employee in department.Employees)
                    emps.Add(employee);
            }

            CompanyPayroll = new Payroll(emps);

            //Make it here so that it generates the company Schedule and payroll automatically using the employees from departments.
        }

        public Company(string companyName, List<Department> departments, Schedule companySchedule) : this(companyName, departments)
        {
            CompanySchedule = companySchedule; // Make it so that there is a function, similar to the one above, in witch the company schedule becomes the combined schedule of all of the users within the departments.
                                               // OR make it so that it combines the schedules of the departments only, OF WITCH are just a combination of the employees schedules.
        }

        public Company(string companyName, List<Department> departments, Payroll payroll, Schedule companySchedule) : this(companyName, departments, companySchedule)
        {
            CompanyPayroll = payroll;
        }

        // Privatised, as Employees should be generated from looking through departments.
        private Company(string companyName, List<Department> departments, List<Employee> employees, Payroll payroll, Schedule companySchedule) : this(companyName, departments, payroll, companySchedule)
        {
            Employees = employees;
        }

        public string Name
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public Image Logo
        {
            get { return _companyLogo; }
            set { _companyLogo = value; }
        }

        public List<Department> Departments
        {
            get { return _departments; }
            set { _departments = value; }
        }

        //make it so this just returns each of the employees in the departmeetns
        [JsonIgnore]//ignored, because when loading a company, company data is retrived from the department instead.
        public List<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        public Payroll CompanyPayroll
        {
            get { return _payroll; }
            set { _payroll = value; }
        }

        public Schedule CompanySchedule
        {
            get { return _companySchedule; }
            set { _companySchedule = value; }
        }

        public List<int> EmployeeIDs
        {
            get
            {
                List<int> ids = new List<int> { };
                foreach (Employee emp in Employees) ids.Add(emp.ID);
                return ids;
            }
        }

        public List<int> DepartmentIDs
        {
            get
            {
                List<int> ids = new List<int> { };
                foreach (Department dep in Departments) ids.Add(dep.ID);
                return ids;
            }
        }


        public void CreateEmployee(Employee employee) //This should be the only way to add and create employees
        {
            bool matchingId = false;
            bool newIdMatching = false;
            int randomID = rand.Next(9999999);

            foreach (Employee emp in Employees)
            {
                if (emp.ID == employee.ID) matchingId = true;
            }

            while (matchingId == true)
            {
                foreach (Employee emp in Employees)
                {
                    if (emp.ID == randomID) newIdMatching = true;
                }

                if (newIdMatching == true)
                {
                    matchingId = true;
                    randomID = rand.Next(9999999);
                }
                else matchingId = false;

                employee.ID = randomID;
            }

            Employees.Add(employee);
        }

        public void Save(string companyDirectory)
        {
            CreateJsonFromObject(this, $"{companyDirectory}\\company.json");
        }
    }
}

/// TODO:
/// Change it so it is just the largest employee ID + 1 instead of a stupid random number that is annoying and stupid (why didnt i think of that XD)
/// 
/// Pseudocode for Employees Property:
//
/*        public List<Employee> Employees
        {
            get
            {
                //read the file called "company.json"
                //use the application functions in here to create a list of employees
                //return that list
                return _employees;
            }
            set { _employees = value; }
        }
*/