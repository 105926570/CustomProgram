using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Department
    {
        int _departmentID;
        private string _departmentName;
        private List<Employee> _employees = new List<Employee> { };
        private List<Manager> _managers = new List<Manager> { };
        private DateTime datetime = DateTime.Now;
    }
}
