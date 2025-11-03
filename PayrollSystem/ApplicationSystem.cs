using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    internal class ApplicationSystem
    {
        private string _rootFolder; //Root folder where all files are stored
        private Employee[] employees;

        public ApplicationSystem()
        {
            _rootFolder = "C:/PayrollSystem";
        }

        public ApplicationSystem(string rootFolder)
        {
            _rootFolder = rootFolder;
        }

        //When the application launches
        // 1. open the root folder
        // 2. open the accounts.txt file
        // 3. read the accounts.txt file.
        // 4. save the accounts to the application system for access
    }
}
