using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

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

        //folder names for different types of jsons
        private static readonly string userFolderName = "users";         // root/users
        private static readonly string EmployeeFolderName = "employees"; // root/users/employees
        private static readonly string ManagerFolderName = "managers";   // root/users/managers
        private static readonly string AdminFolderName = "admins";       // root/users/admins

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _rootFolder = "C:\\CustomProgram";
            jsonTesting();
            ReadObjectFromJson("C:\\CustomProgram\\jsons\\BigBoyTest.json");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreen());
        }

#region Tests - To be deleted at the end of project

        private static void jsonTesting()
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
                // Serialize the object to a JSON string
                string jsonString = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented); // Formatting.Indented for readability

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
            CreateJsonFromObject(emp, $"{_rootFolder}\\employees\\{emp.ID.ToString()}.json");
        }

        public static Employee LoadEmployeeGivenID(int ID)
        {
            //get all files within folder
            string[] filedirs = Directory.GetFiles($"{_rootFolder}\\employees");
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
                                       if (emp.ID == ID) return emp;   //... and if it does return it.
                }
            }

            //when both checks fail
            return null;
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