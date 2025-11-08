using System;
using System.IO;
using System.Windows.Forms;

namespace PayrollSystem
{
    internal static class Program
    {
        //This is where the active employees informaton is stored.
        //Upon login, the user is read, and saved to this variable in the program.
        public static Employee _activeEmployee;
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
    }
}


/// NOTE:
///     ANY CODE WITH "// ***"
///     IS THERE TO DENOTE CODE ADDED TO FIX CODE COPIED FROM APPLICATIONSYSTEM.CS
///     AND...
///     ANY CODE WITH "// &&&"
///     IS CODE THAT WAS AN ERROR AS A RESULT OF VARIABLES BEING DIFFERENT FROM APPLICATIONSYSTEM.CS.