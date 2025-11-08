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
        /// <summary>Reads a file as a byte. convert to whatever format you need after reading.</summary>
        /// <returns>Array of bytes that is the contents of tile file.</returns>
        /// <param name="filePath">The path of the file. eg: <example>"C:\\Folder\\OtherFolder\\file.txt"</example></param>
        /// <param name="fileData">The output byte. Put here the variable you want to equal to the file.</param>
        public static void ReadFileContents(string filePath, out byte[] fileData)
        {
            fileData = Array.Empty<byte>();

            //Check if filePath input is null
            if (string.IsNullOrEmpty(filePath)) //then file doesn't exist
            {
                Console.WriteLine($"file path {filePath} is null or empty"); return;
            }

            //try reading the file
            try
            {
                string directoryPath = Path.GetDirectoryName(filePath);

                //ensure the directory exists
                if (!string.IsNullOrWhiteSpace(directoryPath) && !Directory.Exists(directoryPath))//if ( the directory path given is valid... ...and...  the directory does not exist)
                {
                    Console.WriteLine($"Directory '{directoryPath}' does not exist. Creating...");
                    Directory.CreateDirectory(directoryPath);
                    Console.WriteLine("Directory created successfully.");
                }

                //ensire the file exists
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File '{filePath}' does not exist. Creating empty file...");
                    using (File.Create(filePath)) { } // safely create & close
                    Console.WriteLine("File created successfully.");
                }

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

        /// <summary>Writes data to a given filepath</summary>
        /// <param name="filePath">The path of the file you wish to write too. eg: <example>"C:\\Folder\\OtherFolder\\file.txt"</example></param>
        /// <param name="data">The data you wish to be written to the file.</param>
        public static void WriteDataToFile(string filePath, byte[] data)
        {
            //Check if filePath input is null
            if (string.IsNullOrEmpty(filePath)) //then file doesn't exist
            {
                Console.WriteLine($"file path {filePath} is null or empty"); return;
            }

            try
            {
                string directoryPath = Path.GetDirectoryName(filePath);

                //ensure the directory exists
                if (!string.IsNullOrWhiteSpace(directoryPath) && !Directory.Exists(directoryPath))//if ( the directory path given is valid... ...and...  the directory does not exist)
                {
                    Console.WriteLine($"Directory '{directoryPath}' does not exist. Creating...");
                    Directory.CreateDirectory(directoryPath);
                    Console.WriteLine("Directory created successfully.");
                }

                // Write the data
                File.WriteAllBytes(filePath, data);
                Console.WriteLine($"Successfully wrote {data.Length} bytes to file '{filePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error writing file '{filePath}': {ex.Message}");
            }
        }
        #endregion

        /// <summary>reads the bytes of data, and spits it out as a string.</summary>
        /// <param name="dataBytes">the data to be converted to a string.</param>
        /// <returns>string in UTF8 Encoding</returns>
        public static string BytesToString(byte[] dataBytes)
        {
            return System.Text.Encoding.UTF8.GetString(dataBytes);
        }

        /// <summary>changes active employee to whatever is given</summary>
        /// <param name="privliage">level of priviliage of the executor. must be => 2.</param>
        /// <param name="newActiveEmployee">the desired employee to become the active employee.</param>
        public static void ChangeActiveEmployee(int privliage, Employee newActiveEmployee)
        {
            if (privliage >= 2) _activeEmployee = newActiveEmployee;
            else MessageBox.Show("Privliage isnt high enought. Active Employee not changing...");
        }

        /// <summary>removes active employee.</summary>
        /// <output>sets the active employee to null</output>
        /// <example>could be used for logging-out.</example>
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