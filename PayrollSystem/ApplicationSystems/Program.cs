using Newtonsoft.Json;
using PayrollSystem.CallenderSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PayrollSystem
{
    internal static class Program
    {
        static bool generateRandomCompany = false; //change this to true to generate a random company and save it to files.
        private static Company _companyLoadedInFromFiles;
        private static Company _activeCompany;
        private static Employee _activeEmployee;
        private static bool _isLoggedIn;
        private static string _rootFolder;
        public static float federalMinimumWage { get; } = 24.95f;

        public static Random rand = new Random();

        public static string employeesDirectory, companyDirectory, departmentDirectory;

        /// <summary>
        /// The main entry point for the appliation.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _rootFolder = "C:\\CustomProgram";

            //initialise subdirectorys from root
            employeesDirectory = $"{_rootFolder}\\employees";
            departmentDirectory = $"{_rootFolder}\\departments";
            companyDirectory = $"{_rootFolder}";

            Shift shift = new Shift();
            StartupFunctions();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreen());
        }



        #region Properties

        public static bool isLoggedIn
        {
            get
            {
                if (_activeEmployee == null)
                { _isLoggedIn = false; return _isLoggedIn; }
                return _isLoggedIn = true;
            }
        }

        public static Employee activeEmployee { get { return _activeEmployee; } }
        public static string RootFolder { get { return _rootFolder; } }
        public static Company CompanyLoadedInFromFiles { get { return _companyLoadedInFromFiles; } }
        public static Company ActiveCompany { get { return _activeCompany; } set { _activeCompany = value; } }

        #endregion




        #region Methods

        #region reading and writing

        #region reading and writing checks

        /// <summary>Ensures a directory exists and creates it if it doesnt </summary>
        /// <param name="directory">file\folder directory</param>
        private static void EnsureDirectoryExists(string directory)
        {
            string directoryPath = Path.GetDirectoryName(directory); //incase the input references a file's path rather than a directory, then get just the directory.

            if (!string.IsNullOrWhiteSpace(directoryPath) && !Directory.Exists(directoryPath))//if ( the directory path given is valid... ...and...  the directory does not exist)
            {
                Console.WriteLine($"Directory '{directoryPath}' does not exist. Creating...");
                Directory.CreateDirectory(directoryPath); //creates directory
                Console.WriteLine($"...Directory '{directoryPath}' created successfully.");
            }
        }

        /// <summary>Ensures a File exists and creates it if it doesnt </summary>
        /// <param name="directory">file\folder directory</param>
        private static void EnsureFileExists(string filePath)
        {
           
            //Add a check to see if the inut actually directs to a file.

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist. Creating empty file...");
                using (File.Create(filePath)) { } // safely create & close
                Console.WriteLine($"...File '{filePath}' created successfully.");
            }
        }

        #endregion

        #region json

        /// <summary>saves an object as a .json file in a given directory</summary>
        /// <param name="obj">the object you wish to save</param>
        /// <param name="filePath">the filepath you want the file to be saved in</param>
        public static void CreateJsonFileFromObject(Object obj, string filePath)
        {
            Console.WriteLine($"Attempting to create json file at {filePath}");

            try
            {
                //create the JSON settings
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.Formatting = Formatting.Indented;

                // Serialize the object to a JSON string
                string jsonString = JsonConvert.SerializeObject(obj, settings); // Formatting.Indented for readability

                EnsureDirectoryExists(filePath);
                EnsureFileExists(filePath);

                //write the contents to the filepath
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"created serialised json {Path.GetFileName(filePath)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n\n{ex}\n\nPress 'OK' to continue...");
                Console.WriteLine($"{DateTime.Now.ToString()} {ex}");
            }
        }

        /// <summary>reads an .json file in a given directory and returns it as a Object</summary>
        /// <param name="filePath">the filepath of the json to be read</param>
        /// <returns>object deserialised from the json</returns>
        public static Object ReadObjectFromJson(string filePath)
        {
            EnsureDirectoryExists(filePath);
            EnsureFileExists(filePath);

            Console.WriteLine($"Deserialising json at {filePath} with the contents:\n{File.ReadAllText(filePath)}");

            return JsonConvert.DeserializeObject(File.ReadAllText(filePath));
        }

        /// <summary>reads a json file and returns it as an employee</summary>
        /// <param name="employeeId">the ID of the employee "Employee.ID" [Employee.User.IdentifiableObject.ID]</param>
        /// <param name="directory">the filepath of the json to be read</param>
        /// <returns>Employee of the json file</returns>
        public static Employee ReadJsonFileOfEmployeeGivenFileDirectory(int employeeId, string directory)
        {
            string[] empDirs = Directory.GetFiles(directory);

            foreach (string dir in empDirs)
            {
                if (dir.Contains(employeeId.ToString()))
                {
                    string json = File.ReadAllText(dir);
                    Employee emp = JsonConvert.DeserializeObject<Employee>(json);
                    return emp;
                }
            }
            return null;
        }

        /// <summary>reads a json file and returns it as an employee in the system assigned directory for employees</summary>
        /// <param name="employeeId">the ID of the employee "Employee.ID" [Employee.User.IdentifiableObject.ID]</param>
        /// <returns>Employee of the json file</returns>
        public static Employee ReadJsonFileOfEmployee(int employeeId)
        {
            return ReadJsonFileOfEmployeeGivenFileDirectory(employeeId, employeesDirectory);
        }

        /// <summary>Loads a json file of a department given its id in the system assigned department directory</summary>
        /// <param name="departmentID">the ID of the department</param>
        /// <returns>Department of the json file</returns>
        public static Department ReadJsonFileOfDepartment(int departmentID)
        {
            return ReadJsonFileOfDepartmentGivenDirectory(departmentID, employeesDirectory);
        }

        /// <summary>Loads a json file of a department given its id in the system assigned department directory</summary>
        /// <param name="departmentID">the ID of the department</param>
        /// <param name="directory">the filepath of the json to be read</param>
        /// <returns>Department of the json file</returns>
        public static Department ReadJsonFileOfDepartmentGivenDirectory(int departmentID, string directory)
        {
            string[] empDirs = Directory.GetFiles(directory);

            foreach (string dir in empDirs)
            {
                if (dir.Contains(departmentID.ToString()))
                {
                    string json = File.ReadAllText(dir);
                    Department dep = JsonConvert.DeserializeObject<Department>(json);

                    List<Employee> emps = new List<Employee>() { };
                    foreach (int ID in dep.EmployeeIDs)
                    {
                        emps.Add(ReadJsonFileOfEmployee(ID));
                    }
                    dep.Employees = emps;
                    return dep;
                }
            }
            return null;
        }

        #endregion

        /// <summary> loads a file in the rootfolder called "company.json" and returns it as a company</summary>
        /// <returns>a company</returns>
        public static Company LoadCompany()
        {
            return LoadCompany(RootFolder);
        }

        /// <summary> loads a file in a given folder called "company.json" and returns it as a company</summary>
        /// <param name="directory">directory witch the json file is stored</param>
        /// <returns>a company</returns>
        public static Company LoadCompany(string directory)
        {
            string json = File.ReadAllText($"{directory}\\company.json");
            Company cmp = JsonConvert.DeserializeObject<Company>(json);
            return cmp;
        }

        public static void FullCompanySave(Company company)
        {
            company.Save();
            foreach (Employee emp in company.Employees)
            {
                emp.SaveEmployeeUsingDefaulSystemDirectory();
            }
            /* untested. plus can change code so this just saves departments, and in dep.save save employees.
                foreach (Department dep in company.Departments)
                {
                    dep.Save();
                }
            */
        }
        #endregion

        #region changing active employees

        /// <summary>Changes the active employee to the employee inputted</summary>
        /// <param name="newActiveEmployee">what the new active employee should be</param>
        public static void ChangeActiveEmployee(Employee newActiveEmployee)
        {
            if (newActiveEmployee.Privliage >= 0 && newActiveEmployee.Privliage <= 2) _activeEmployee = newActiveEmployee;
            else MessageBox.Show("privliage is not acceptable");
        }

        /// <summary>sets active employee to null</summary>
        public static void SetActiveEmployeeAsNull()
        {
            _activeEmployee = null;
        }

        #endregion

        #region error stuff

        public static void SaveErrorToLog(Exception ex)
        {
            //DIRECTORY SHOULD BE LIKE THIS:
            string ErrorLogDirectory = "C:\\CustomPayrollProgramDebug\\errorLog.log";

            //Ensure the directory and the file exists. if it doesnt, create it.
            EnsureDirectoryExists(ErrorLogDirectory);
            EnsureFileExists(ErrorLogDirectory);

            //READ FILE IN THE DIRECTORY [ErrorLogDirectory]

            //ADD [Exception ex] TO THE END OF FILE

            //WHAT SHOULD BE ADDED TO THE FILE SHOULD LOOK LIKE THIS:
            Console.WriteLine($"{DateTime.Now.ToString()} : {ex}");
        }

        #endregion

        #region startup and shutdown methods

        /// <summary>Functions to be run on startup</summary>
        public static void StartupFunctions()
        {
            if (generateRandomCompany == true) GenerateRandomCompany();
            _companyLoadedInFromFiles = LoadCompany();
            _activeCompany = _companyLoadedInFromFiles;
        }

        /// <summary>Functions to be run before the app closes</summary>
        public static void Shutdown()
        {
            foreach (Department dep in _activeCompany.Departments) dep.Save();
            foreach (Employee emp in _activeCompany.Employees) emp.SaveEmployeeUsingDefaulSystemDirectory();
        }

        #endregion

        #region random names

        /// <summary>Generates a random first name from an array of several pre generated names</summary>
        /// <returns>A string of a first name</returns>
        public static string RandomFirstName()
        {
            string[] s = {
            "James", "Mary", "Robert", "Patricia", "John", "Jennifer", "Michael", "Linda", "William", "Elizabeth",
            "David", "Barbara", "Richard", "Susan", "Joseph", "Jessica", "Thomas", "Sarah", "Charles", "Karen",
            "Christopher", "Nancy", "Daniel", "Lisa", "Matthew", "Betty", "Anthony", "Margaret", "Mark", "Sandra",
            "Donald", "Ashley", "Steven", "Kimberly", "Paul", "Emily", "Andrew", "Donna", "Joshua", "Michelle",
            "Kenneth", "Dorothy", "Kevin", "Carol", "Brian", "Amanda", "George", "Melissa", "Timothy", "Deborah",
            "Ronald", "Stephanie", "Edward", "Rebecca", "Jason", "Laura", "Jeffrey", "Sharon", "Ryan", "Cynthia",
            "Jacob", "Kathleen", "Gary", "Amy", "Nicholas", "Shirley", "Eric", "Angela", "Stephen", "Helen",
            "Jonathan", "Anna", "Larry", "Brenda", "Justin", "Pamela", "Scott", "Emma", "Brandon", "Nicole",
            "Frank", "Samantha", "Benjamin", "Katherine", "Gregory", "Christine", "Raymond", "Debra", "Samuel", "Rachel",
            "Patrick", "Catherine", "Alexander", "Carolyn", "Jack", "Janet", "Dennis", "Ruth", "Jerry", "Maria"
            };
            return s[rand.Next(0, s.Length - 1)];

        }

        /// <summary>Generates a random last name from an array of several pre generated names</summary>
        /// <returns>A string of a last name</returns>
        public static string RandomLastName()
        {
            string[] s = {
            "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
            "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
            "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
            "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores",
            "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts",
            "Gomez", "Phillips", "Evans", "Turner", "Diaz", "Parker", "Cruz", "Edwards", "Collins", "Reyes",
            "Stewart", "Morris", "Morales", "Murphy", "Cook", "Rogers", "Gutierrez", "Ortiz", "Morgan", "Cooper",
            "Peterson", "Bailey", "Reed", "Kelly", "Howard", "Ramos", "Kim", "Cox", "Ward", "Richardson",
            "Watson", "Brooks", "Chavez", "Wood", "James", "Bennett", "Gray", "Mendoza", "Ruiz", "Hughes",
            "Price", "Alvarez", "Castillo", "Sanders", "Patel", "Myers", "Long", "Ross", "Foster", "Jimenez"
            };
            return s[rand.Next(0, s.Length - 1)];
        }

        #endregion

        #region Tests - To be deleted at the end of project

        /// <summary> 
        /// Generates a random company with:
        ///     4 Departments
        ///     Each Department has 3 Employees
        /// </summary>
        public static void GenerateRandomCompany()
        {
            Department departmentDefault = new Department();
            Department departmentCleaning = new Department("Cleaning");
            Department departmentSales = new Department("Sales");
            Department departmentHR = new Department("HR");

            Employee emp1 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");
            Employee emp2 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");
            Employee emp3 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");
            Employee emp4 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");
            Employee emp5 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");
            Employee emp6 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");
            Employee emp7 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");
            Employee emp8 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");
            Employee emp9 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");
            Employee emp10 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");
            Employee emp11 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");
            Employee emp12 = new Employee(RandomFirstName(), RandomLastName(), $"username123{rand.Next(99)}", $"password123{rand.Next(99)}");

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

            company.Save();

            Console.WriteLine("saved everyting");
            MessageBox.Show("Saved The New Thing i think");
        }

        #endregion

        #endregion
    }
}


/// NOTE:
///     ANY CODE WITH "// ***"
///     IS THERE TO DENOTE CODE ADDED TO FIX CODE COPIED FROM APPLICATIONSYSTEM.CS
///     AND...
///     ANY CODE WITH "// &&&"
///     IS CODE THAT WAS AN ERROR AS A RESULT OF VARIABLES BEING DIFFERENT FROM APPLICATIONSYSTEM.CS.
///     
/// TODO:
///     Create a function that searches all of the known company data
///     generate a random id that is unique and not equal to any number on the list
///     output the number
///     

/// CREDITS:
/// RandomFirstName and RandomLastName's arrays were generated from CHATGPT and to be used for TESTING PURPOSES ONLY WHILE DEVELOPING.
/// This code is intended to be removed before final release / submittion.
/// https://chatgpt.com/share/69104974-6154-800d-b804-575a2820f3de