using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace assignment2
{
    internal class Employee
    {
        int id;
        string name;
        double basicSalary;
        double hra;
        double da;
        double grossSalary;
        

        public Employee(int id,string name, int basicSalary)
        {
            this.id = id;
            this.name = name;
            this.basicSalary = basicSalary;
            this.hra = 0.1 * basicSalary;
            this.da = 0.5 * basicSalary;
            this.grossSalary = basicSalary + hra + da;
        }
        public void DisplaySalarySlip()
        {
            Console.WriteLine($"Id: {id} , Name: {name}, Basic Salary: {basicSalary}, HRA: {hra}, DA: {da}, Gross: {grossSalary}");
            


        }
        
    }
}
