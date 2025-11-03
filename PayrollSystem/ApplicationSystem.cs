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
            _rootFolder = "C:/PayrollSystem";
        }

        public ApplicationSystem(string rootFolder)
        {
            _rootFolder = rootFolder;
        }

        public void readLoginFile(string rootFolder)
        {
            StreamReader reader = new StreamReader(rootFolder + "accounts.txt");
            try
            {
                int ID = Convert.ToInt16(reader.ReadLine());
                string username = reader.ReadLine();
                string password = reader.ReadLine();
                string firstname = reader.ReadLine();
                string lastname = reader.ReadLine();
                Employee emp = new Employee(ID, username, password, firstname, lastname);
                employees.Add(emp);
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

        public void saveLoginFile(string rootFolder, List<Employee> EmployeesToBeSaved)
        {
            StreamWriter writer = new StreamWriter(rootFolder + "accounts.txt");
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

        //When the application launches
        // 1. open the root folder
        // 2. open the accounts.txt file
        // 3. read the accounts.txt file.
        // 4. save the accounts to the application system for access
    }
}
