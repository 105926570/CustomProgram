using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PayrollSystem
{
    internal class ApplicationSystem
    {
        private string _rootFolder = "C:\\PayrollSystem"; //Root folder where all files are stored
        private List<Employee> employees = new List<Employee> { };

        public ApplicationSystem() //Default Constructor
        { _rootFolder = "C:\\PayrollSystem"; }

        public ApplicationSystem(string rootFolder) //Constructor given a directory
        { _rootFolder = rootFolder; }

        public void readLoginFile()
        {
            CheckFileExistance(_rootFolder, "\\accounts.txt");
            StreamReader reader = new StreamReader(_rootFolder + "\\accounts.txt");


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
            catch (Exception ex) { Console.WriteLine("Error when reading employee file: " + ex); }
            finally { reader.Close(); }
            reader.Close();// incase not closed allready
        }

        public void saveLoginFile(List<Employee> EmployeesToBeSaved)
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

        public void CheckFileExistance(string inDirectory, string Filename)
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
    }
}