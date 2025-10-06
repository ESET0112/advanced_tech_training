using System.Runtime.CompilerServices;

namespace AdvancedTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter the number a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("The first value is : " + a);


            Console.Write("enter the number a: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("The first value is : " + b);


            double c = Math.Sqrt(a * a + b * b);
            Console.WriteLine("The hyposis is: " + c);


            String fullname = "Nilanjan Chakraborty";
            string ph_no = "91/6291344318";
            ph_no = ph_no.Replace('/', '-');
            string username = fullname.Insert(0, "Mr.");
            Console.WriteLine(username);
            Console.WriteLine(ph_no);
            Console.WriteLine(fullname.Length);


            // Reads a key and returns a ConsoleKeyInfo object
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine($"\nYou pressed: {keyInfo.Key}");
            Console.WriteLine($"\nYou pressed: {keyInfo.KeyChar}");

            String firstname = fullname.Substring(0, 10);
            Console.WriteLine(firstname);
            String fi = fullname.Insert(1, "o");
            Console.WriteLine(fi);



            Console.WriteLine("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            if (age >= 27)
                Console.WriteLine("You are not eligible");
            else
                Console.WriteLine("You are eligible");


            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();

            if (name == "")
                Console.WriteLine("Name not available");
            else
                Console.WriteLine("Your name is " + name);

            Console.Write("Enter the temperature: ");
            int temp = Convert.ToInt32(Console.ReadLine());
            string message = (temp <= 15) ? "Temp is too cold" : "Temp is okay";
            Console.WriteLine(message);


            string firstname = "Nilanjan";
            string lastname = "Chakraborty";
            int age = 20;

            Console.WriteLine($"my name is {firstname} and age is {age}");


            Console.WriteLine("What day it is?");
            string day = Console.ReadLine();

            //Switch Case
            switch (day)
            {
                case "monday":
                    Console.WriteLine("Weekday");
                    break;
                case "tuesday":
                    Console.WriteLine("Weekday");
                    break;
                case "wednesday":
                    Console.WriteLine("Weekday");
                    break;
                case "thursday":
                    Console.WriteLine("Weekday");
                    break;
                case "friday":
                    Console.WriteLine("Weekday");
                    break;
                default:
                    Console.WriteLine("Weekend");
                    break;
            }


            //If Else
            Console.Write("Enter the temperature: ");
            int temp = Convert.ToInt32(Console.ReadLine());
            if (temp > 0 & temp <= 25)
                Console.WriteLine("Perfect temperature");
            else if (temp < 0 || temp >= 40)
                Console.WriteLine("Hold your horses");
            else
                Console.WriteLine("Do whatever");


            //While Loop
            string name = "";
            while (name == "")
            {
                Console.WriteLine("Enter name");
                name = Console.ReadLine();
            }

            //For Loop
            int limit = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine(i);
            }


            Console.Write("Enter number of rows: ");
            int rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number of columns: ");
            int columns = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter character to print: ");
            char patternChar = Console.ReadKey().KeyChar;
            Console.WriteLine();


            //Nested For Loop
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(patternChar + " ");
                }
                Console.WriteLine();
            }



            string[] cars = {"BMW","Ford","McLaren","Koeniggsegg","Mustang"};
            Console.WriteLine(cars[0]);
            cars[1] = "DODGE";
            Console.WriteLine(cars[1]);

            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i]);
            }

            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }






        }
    }
}
