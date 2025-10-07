using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2
{
    internal class Company
    {
        string employeeName;
        int employeeId;
        static string companyName = "Esyasoft Tech";

        public Company(string name, int id)
        {
            employeeName = name;
            employeeId = id;
        }
        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Employee ID: {employeeId}");
            Console.WriteLine($"Employee Name: {employeeName}");
            Console.WriteLine($"Works at: {companyName}");
            
        }
    }
}
