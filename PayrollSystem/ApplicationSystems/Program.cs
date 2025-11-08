using System;
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

        public static bool isLoggedIn
        {
            get
            {
                if (_activeEmployee == null) _isLoggedIn = false;
                else _isLoggedIn = true;
                return _isLoggedIn;
            }
        }

        public static Employee activeEmployee
            { get { return _activeEmployee; } }
            
        public static void ChangeActiveEmployee(int privliage, Employee newActiveEmployee)
        {
            if (privliage >= 2) _activeEmployee = newActiveEmployee;
            else MessageBox.Show("Privliage isnt high enought. Active Employee not changing...");
        }

        public static void RemoveActiveEmployee()
            { _activeEmployee = null; }
    }
}
