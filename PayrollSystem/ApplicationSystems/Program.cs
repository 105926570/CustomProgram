using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        private static Company _companyLoadedInFromFiles;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _rootFolder = "C:\\CustomProgram";
            jsonTesting();
            ReadJsonObjectFromFile("C:\\CustomProgram\\jsons\\BigBoyTest.json");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreen());
        }

        #region Tests - To be deleted at the end of project
        private static void jsonTesting()
        {
            Console.WriteLine("Starting Test 1");

            CreateJsonFromObjet(new User(), _rootFolder + "\\jsons\\testUserJson.json");
            CreateJsonFromObjet(new Employee(), _rootFolder + "\\jsons\\testEmployeeJson.json");
            Employee test1 = new Employee(124, "username123", "password123", "foist noim", "loist naime");
            Employee test2 = new Employee(187343, "asfasdfasdf", "asdfasdf", "foist sadfasdf", "loist asdfasdf");
            List<Employee> h = new List<Employee> { test1, test2 };
            Company company = new Company() { Name = "the big company lol", Employees = h };
            Console.WriteLine("Now... The big boy test...");
            CreateJsonFromObjet(company, _rootFolder + "\\jsons\\BigBoyTest.json");

            //Test reading a JSON then saving what is read
            string testamondo = Path.GetDirectoryName(_rootFolder + "\\jsons\\BigBoyTest.json");
            testamondo = testamondo + "\\bigFatTestBruv.json";
            CreateJsonFromObjet(JsonConvert.DeserializeObject(File.ReadAllText(_rootFolder + "\\jsons\\BigBoyTest.json")), testamondo);
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


        #region reading and writing
        public static void ReadFileContents(string filePath, out byte[] fileData)
        {
            fileData = Array.Empty<byte>();

            //Check if filePath input is null
            if (string.IsNullOrEmpty(filePath)) //then file doesn't exist
            {
                Console.WriteLine($"file path {filePath} is null or empty");
                return;
            }

            //try reading the file
            try
            {
                EnsureDirectoryExists(filePath);
                EnsureFileExists(filePath);

                //Read the file contents
                fileData = File.ReadAllBytes(filePath);
                Console.WriteLine($"Successfully read {fileData.Length} bytes from file '{filePath}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create directory for file '{filePath}'. Details: {ex.Message}");
                return;
            }
        }

        public static void WriteDataToFile(string filePath, byte[] data)
        {
            //Check if filePath input is null
            if (string.IsNullOrEmpty(filePath)) //then file doesn't exist
            {
                Console.WriteLine($"file path {filePath} is null or empty");
                return;
            }

            try
            {
                EnsureDirectoryExists(filePath);

                // Write the data
                File.WriteAllBytes(filePath, data);
                Console.WriteLine($"Successfully wrote {data.Length} bytes to file '{filePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error writing file '{filePath}': {ex.Message}");
            }
        }

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

        public static string BytesToString(byte[] dataBytes)
        {
            return System.Text.Encoding.UTF8.GetString(dataBytes);
        }

        public static void ChangeActiveEmployee(int privliage, Employee newActiveEmployee)
        {
            if (privliage >= 2) _activeEmployee = newActiveEmployee;
            else MessageBox.Show("Privliage isnt high enought. Active Employee not changing...");
        }

        public static void RemoveActiveEmployee()
        {
            _activeEmployee = null;
        }

        public static void CreateJsonFromObjet(Object obj, string filePath)
        {
            // Serialize the object to a JSON string
            string jsonString = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented); // Formatting.Indented for readability

            string directoryPath = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directoryPath) && !Directory.Exists(directoryPath))//if ( the directory path given is valid... ...and...  the directory does not exist)
            {
                Console.WriteLine($"Directory '{directoryPath}' does not exist. Creating...");
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine("... Directory created");
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist. Creating empty file...");
                using (File.Create(filePath)) { } // safely create & close
                Console.WriteLine("...File created");
            }

            //write the contents to the filepath
            File.WriteAllText(filePath, jsonString);
            System.Console.WriteLine($"created serialised json {Path.GetFileName(filePath)}");
        }

        public static Object ReadJsonObjectFromFile(string filePath)
        {
            EnsureDirectoryExists(filePath);
            EnsureFileExists(filePath);

            Console.WriteLine($"Deserialising json at {filePath} with the contents:\n{File.ReadAllText(filePath)}");

            return JsonConvert.DeserializeObject(File.ReadAllText(filePath));
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