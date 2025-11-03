using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace PayrollSystem
{
    internal class ApplicationSystem
    {
        private string _rootFolder; //Root folder where all files are stored
        private List<Employee> employees = new List<Employee> { };

        public ApplicationSystem()
        {
            _rootFolder = "C:\\PayrollSystem";
            checkAllSystemFilesExist();
        }

        public ApplicationSystem(string rootFolder)
        {
            _rootFolder = rootFolder;
            checkAllSystemFilesExist();
        }

        public void readLoginFile()
        {
            if (!Directory.Exists(_rootFolder))
            {
                Directory.CreateDirectory(_rootFolder);
            }

            StreamReader reader = new StreamReader(_rootFolder + "\\accounts.txt");
            checkSystemFileExists(_rootFolder, "\\accounts.txt");

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
                    employees.Add(emp);

                    count += 5;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when reading employee file: " + ex);
            }
            finally
            {
                reader.Close();
            }
        }

        public void saveLoginFile(List<Employee> EmployeesToBeSaved)
        {
            if (!Directory.Exists(_rootFolder))
            {
                Directory.CreateDirectory(_rootFolder);
            }

            StreamWriter writer = new StreamWriter(_rootFolder + "\\accounts.txt");
            checkSystemFileExists(_rootFolder, "\\accounts.txt");
            try
            {
                foreach(Employee emp in EmployeesToBeSaved)
                {
                    writer.WriteLine(emp.ID);
                    writer.WriteLine(emp.Username);
                    writer.WriteLine(emp.Password);
                    writer.WriteLine(emp.FirstName);
                    writer.WriteLine(emp.LastName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when writing employee file: " + ex);
            }
            finally
            {
                writer.Close();
            }
        }


        public void checkAllSystemFilesExist()
        {
            checkSystemFileExists(_rootFolder, "\\accounts.txt");
            //add a file existance checker for each nescecary ffile.
        }

        public void checkSystemFileExists(string filepath, string filename)
        {
            string thingo = filepath + filename;
            if (!File.Exists(thingo))
            {
                File.Create(thingo);
                Console.WriteLine($"The file {filename} does not exist. creating it now...");
            } 
        }
    }
}