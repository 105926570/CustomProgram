using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;

namespace PayrollSystem
{
    internal static class Program
    {
        //This is where the active employees informaton is stored.
        //Upon login, the user is read, and saved to this variable in the program.
        private static Employee _activeEmployee;
        private static bool _isLoggedIn;
        //Root folder where all files are stored
        private static string _rootFolder;
        //Company loaded in from class. this is to be done at the start of main.
        private static Company _companyLoadedInFromFiles; // This is the company loaded in from files on startup
        private static Company _activeCompany; // This is what should be changed with ever addition and modification to the company
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

            //testing
            fullProgramTesting();

            //load company into memory
            Startup();

            //ReadObjectFromJson("C:\\CustomProgram\\jsons\\BigBoyTest.json");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreen());
        }

        #region Tests - To be deleted at the end of project

        public static void fullProgramTesting()
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


        #region Functions

        #region reading and writing

        #region reading and writing checks

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

        private static void EnsureFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist. Creating empty file...");
                using (File.Create(filePath)) { } // safely create & close
                Console.WriteLine($"...File '{filePath}' created successfully.");
            }
        }

        #endregion

        #region json

        public static void CreateJsonFromObject(Object obj, string filePath)
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

        public static Object ReadObjectFromJson(string filePath)
        {
            EnsureDirectoryExists(filePath);
            EnsureFileExists(filePath);

            Console.WriteLine($"Deserialising json at {filePath} with the contents:\n{File.ReadAllText(filePath)}");

            return JsonConvert.DeserializeObject(File.ReadAllText(filePath));
        }

        //for loading in their schedule for example, as it would be stored here.
        public static Employee readEmployee(int employeeId, string directory)
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
        public static Employee readEmployee(int employeeId)
        {
            return readEmployee(employeeId, employeesDirectory);
        }

        //when writing this, think from the perspective of an manager viewing their department
        public static Department loadDepartment(int departmentID)
        {
            return loadDepartment(departmentID, employeesDirectory);
        }

        public static Department loadDepartment(int departmentID, string directory)
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
                        emps.Add(readEmployee(ID));
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
                emp.Save();
            }
        }
        #endregion

        public static void ChangeActiveEmployee(Employee newActiveEmployee)
        {
            if (newActiveEmployee.Privliage >= 0 && newActiveEmployee.Privliage <= 2) _activeEmployee = newActiveEmployee;
            else MessageBox.Show("privliage is not acceptable");
        }

        public static void RemoveActiveEmployee()
        {
            _activeEmployee = null;
        }

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

        public static void Startup()
        {
            _companyLoadedInFromFiles = LoadCompany();
            _activeCompany = _companyLoadedInFromFiles;
        }

        public static void Shutdown()
        {
            foreach (Department dep in _activeCompany.Departments) dep.Save(); 
            foreach (Employee emp in _activeCompany.Employees) emp.Save();
        }
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