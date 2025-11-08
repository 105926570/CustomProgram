using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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

        /// <summary>returns weather or not a user is active.</summary>
        /// <example>if the active user is null [no one is active], false is returned. otherwise it returns true</example>
        /// <returns>True or false, depending on the presence of a active user.</returns>
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
        /// active employee.
        /// OUTPUT CAN BE NULL IF NO EMPLOYEE IS LOGGED IN
        /// </returns>
        public static Employee activeEmployee
        {
            get
            {
                return _activeEmployee;
            }
        }

        /// <returns>Root folder directery as a string</returns>
        public static string RootFolder
        {
            get { return _rootFolder; }
        }

        /// <summary>temp function name</summary>
        /// <returns>company loaded in from files.</returns>
        public static Company CompanyLoadedInFromFiles
        {
            get { return _companyLoadedInFromFiles; }
        }

    #endregion

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