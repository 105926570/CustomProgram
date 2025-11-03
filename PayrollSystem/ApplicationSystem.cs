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

        public ApplicationSystem()
        {
            _rootFolder = "C:/PayrollSystem";
        }

        public ApplicationSystem(string rootFolder)
        {
            _rootFolder = rootFolder;
        }
    }
}
