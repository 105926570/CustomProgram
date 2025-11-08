using System;

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

        public void EncryptData()
        {
            // Placeholder for encryption logic
            Console.WriteLine("Data encrypted using root file path: " + _rootFilePath);
        }

        public void DecryptData()
        {
            // Placeholder for decryption logic
            Console.WriteLine("Data decrypted using root file path: " + _rootFilePath);
        }

        public void SaveData()
        {
            // Placeholder for save logic
            Console.WriteLine("Data saved to root file path: " + _rootFilePath);
        }

        public void LoadData()
        {
            // Placeholder for load logic
            Console.WriteLine("Data loaded from root file path: " + _rootFilePath);
        }
    }
}
