using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using static PayrollSystem.UsefullUniversalCommands;
using static PayrollSystem.ApplicationSystems.Miscf;
using PayrollSystem.ApplicationSystems;

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
        private static Company _companyLoadedInFromFiles;

        private static string employeesDirectory, companyDirectory;

        private static List<int> _employeeIDs, _departmentIDs; //This is what is saved to a json instead, rather than the whole entire employee info.

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _rootFolder = "C:\\CustomProgram";

            //initialise subdirectorys from root
            employeesDirectory = $"{_rootFolder}\\employees";
            companyDirectory = $"{_rootFolder}";

            TestingFunctions.fullProgramTesting();
            //ReadObjectFromJson("C:\\CustomProgram\\jsons\\BigBoyTest.json");
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
        public static List<int> EmployeeIDs
        {
            get
            {
                List<int> ids = new List<int> { };
                foreach (Employee emp in _companyLoadedInFromFiles.Employees) ids.Add(emp.ID);
                return ids;
            }
        }

        public static List<int> DepartmentIDs
        {
            get
            {
                List<int> ids = new List<int> { };
                foreach (Department dep in _companyLoadedInFromFiles.Departments) ids.Add(dep.ID);
                return ids;
            }
        }


        #endregion


        #region Functions

        #region reading and writing

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

        #region json

        public static void CreateJsonFromObject(Object obj, string filePath)
        {
            Console.WriteLine($"Attempting to create json file at {filePath}");

            try
            {
                //create the JSON settings
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.All;
                settings.Formatting = Formatting.Indented;

                // Serialize the object to a JSON string
                string jsonString = JsonConvert.SerializeObject(obj, settings); // Formatting.Indented for readability

                EnsureDirectoryExists(filePath);
                EnsureFileExists(filePath);

                //write the contents to the filepath
                File.WriteAllText(filePath, jsonString);
                System.Console.WriteLine($"created serialised json {Path.GetFileName(filePath)}");
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

        #endregion

        public static void SaveEmployee(Employee emp)
        {
            CreateJsonFromObject(emp, $"{employeesDirectory}\\{emp.ID.ToString()}.json");
        }

        public static void SaveCompany(Company com)
        {
            CreateJsonFromObject(com, $"{companyDirectory}\\company.json");
        }

        public static Employee LoadEmployeeGivenID(int ID)
        {
            //get all files within folder
            string[] filedirs = Directory.GetFiles(employeesDirectory);
            Employee emp;

            //Check the ID within the files
            foreach (string filedir in filedirs)
            {
                emp = (Employee)ReadObjectFromJson(filedir);
                if (emp.ID == ID) return emp;
            }

            Console.WriteLine("Could not find the ID within the files. checking the names instead...");

            //Check if there is a file with the name of that ID
            foreach (string filedir in filedirs)
            {
                //if the file directory contains the id (if the filename contains the id)
                if (filedir.Contains(ID.ToString()) == true)
                {
                    emp = (Employee)ReadObjectFromJson(filedir);   //check if the files ID also matches the id found...          
                    if (emp.ID == ID) return emp;                  //... and if it does return it.
                }
            }

            return null; //when both checks fail
        }

        public static Company LoadCompany()
        {
            string[] filedirs = Directory.GetFiles(companyDirectory);
            foreach (string filedir in filedirs)
            {
                if (filedir == $"{companyDirectory}\\company.json")
                    return (Company)ReadObjectFromJson(filedir);
            }
            return null;
        }

        public static void FullCompanySave(Company company)
        {
            SaveCompany(company);
            foreach (Employee emp in company.Employees)
            {
                SaveEmployee(emp);
            }
        }
        #endregion

        public static void ChangeActiveEmployee(int privliage, Employee newActiveEmployee)
        {
            if (privliage >= 2) _activeEmployee = newActiveEmployee;
            else MessageBox.Show("Privliage isnt high enought. Active Employee not changing...");
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


        #region startup and shutdown
        public static void Startup()
        {
            _companyLoadedInFromFiles = LoadCompany();
        }

        public static void Shutdown()
        {
            FullCompanySave(_companyLoadedInFromFiles);
        }
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