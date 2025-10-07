using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2
{
    internal class Human
    {
        public string name;
        public int age;
        public Human(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void eat()
        {
            Console.WriteLine(name + " is eating");
        }
        public void sleep()
        {
            Console.WriteLine(name + " is sleeping");
        }
    }
}
