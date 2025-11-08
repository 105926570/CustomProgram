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
    }
}
