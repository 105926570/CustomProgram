using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class ProgramSystem
    {
        private String _rootFilePath;

        public ProgramSystem()
        {
            _rootFilePath = "C:/SystemFilesForLeEpicProgram";
        }

        public ProgramSystem(string rootFilePath)
        {
            _rootFilePath = rootFilePath;
        }
    }
}
