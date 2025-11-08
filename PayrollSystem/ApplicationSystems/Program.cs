using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreen());
        }

        /// <summary>returns weather or not a user is active.</summary>
        /// <returns>if the active user is null [no one is active], false is returned. otherwise it returns true.</returns>
        public static bool isLoggedIn
        {
            get
            {
                if (_activeEmployee == null) _isLoggedIn = false;
                else _isLoggedIn = true;
                return _isLoggedIn;
            }
        }

        /// <returns>
        /// returns active employee.
        /// OUTPUT CAN BE NULL IF NO EMPLOYEE IS LOGGED IN
        /// </returns>
        public static Employee activeEmployee
        {
            get
            {
                return _activeEmployee;
            }
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



        #region Functions for reading in values into memory
        /// <summary>
        /// reads in the login file and saves the employees to company.
        /// </summary>
        public static void readLoginFile()
        {
            CheckFileExistance(_rootFolder, "\\accounts.txt");
            StreamReader reader = new StreamReader(_rootFolder + "\\accounts.txt");

            List<Employee> employees = _companyLoadedInFromFiles.Employees; //***
            try
            {
                int i = File.ReadAllLines(_rootFolder + "\\accounts.txt").Count();
                int count = 0;

                while (i > count)
                {
                    int ID = int.Parse(reader.ReadLine());
                    string username = reader.ReadLine();
                    string password = reader.ReadLine();
                    string firstname = reader.ReadLine();
                    string lastname = reader.ReadLine();

                    Console.WriteLine($"Read employee with this info: {ID}, {username}, {password}, {firstname} {lastname}");

                    Employee emp = new Employee(ID, username, password, firstname, lastname);
                    employees.Add(emp); //&&&

                    count += 5;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error when reading employee file: " + ex); }
            finally { reader.Close(); }
            reader.Close();// incase not closed allready
        }

        /// <summary>
        /// overites the employee.txt file with all of the employees provided.
        /// </summary>
        /// <param name="EmployeesToBeSaved">the list of the employees that must be saved to the file.</param>
        public static void saveLoginFile(List<Employee> EmployeesToBeSaved)
        {
            CheckFileExistance(_rootFolder, "\\accounts.txt");
            StreamWriter writer = new StreamWriter(_rootFolder + "\\accounts.txt");

            try
            {
                foreach (Employee emp in EmployeesToBeSaved)
                {
                    writer.WriteLine(emp.ID);
                    writer.WriteLine(emp.Username);
                    writer.WriteLine(emp.Password);
                    writer.WriteLine(emp.FirstName);
                    writer.WriteLine(emp.LastName);
                }
            }
            catch (Exception ex) { Console.WriteLine("Error when writing employee file: " + ex); }
            finally { writer.Close(); }
            writer.Close(); //incase not closed allready
        }

        /// <summary>Checks that a file exists</summary>
        /// <param name="inDirectory">directery the file is in</param>
        /// <param name="Filename">name of file</param>
        /// <example>("C:\\Location\\Folder", "fileToCheckTheExistanceOf.txt") *notice that the '.txt' is included...</example>
        public static void CheckFileExistance(string inDirectory, string Filename)
        {
            string fullDirectory = inDirectory + Filename;

            if (!Directory.Exists(inDirectory))
            {
                try
                {
                    Console.WriteLine($"Directory {inDirectory} does not exist. Creating...");
                    Directory.CreateDirectory(inDirectory);
                }
                catch (Exception ex) { Console.WriteLine($"Failed to create directory: {ex}"); }
                finally { Console.WriteLine("Done"); }

            }
            if (!File.Exists(fullDirectory))
            {
                try
                {
                    Console.WriteLine($"The file {Filename} does not exist in directory {inDirectory} creating it now...");
                    File.Create(fullDirectory).Dispose();
                }
                catch (Exception ex) { Console.WriteLine($"Failed to create file: {ex}"); }
                finally { Console.WriteLine("Done"); }
            }
        }
        #endregion

        #region encryption functions - initially coppied from ProgramSystem.cs
        //------------------------------------//
        // ALL OF THESE FUNCTIONS, AS OF NOW  //
        //    WERE DIRECTLY COPIED FROM       //
        // PROGRAM SYSTEM, AND MODIFIED SO    //
        //    THAT IT IS COMPILEABLE          //
        //------------------------------------//
        public static void EncryptData()
        {
            // Placeholder for encryption logic
            Console.WriteLine("Data encrypted using root file path: " + _rootFolder);
        }

        public static void DecryptData()
        {
            // Placeholder for decryption logic
            Console.WriteLine("Data decrypted using root file path: " + _rootFolder);
        }

        public static void SaveData()
        {
            // Placeholder for save logic
            Console.WriteLine("Data saved to root file path: " + _rootFolder);
        }

        public static void LoadData()
        {
            // Placeholder for load logic
            Console.WriteLine("Data loaded from root file path: " + _rootFolder);
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