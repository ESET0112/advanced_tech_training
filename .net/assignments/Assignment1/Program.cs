namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //Task 1 -> Student Marks Calculator

            Console.WriteLine("Enter student name: ");
            string studentName = Console.ReadLine();
            Console.WriteLine("Subject 1 marks: ");
            int sub1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Subject 2 marks: ");
            int sub2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Subject 3 marks: ");
            int sub3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Subject 4 marks: ");
            int sub4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Subject 5 marks: ");
            int sub5 = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Total marks: " + (sub1 + sub2 + sub3 + sub4 + sub5));
            Console.WriteLine("Average marks: " + (sub1 + sub2 + sub3 + sub4 + sub5) / 5);
            Console.WriteLine("Total percentage: " + (sub1 + sub2 + sub3 + sub4 + sub5) / 5 + "%");


            //Task 2 -> Simple Salary Computation
            Console.WriteLine("Enter basic salary: ");
            double basic = Convert.ToDouble(Console.ReadLine());
            double hra = 0.2 * basic;
            double da = 0.1 * basic;
            double tax = 0.08 * basic;

            double gross = basic + hra + da;
            double netsalary = gross - tax;

            Console.WriteLine("Basic Salary: " + basic);
            Console.WriteLine("HRA: " + hra);
            Console.WriteLine("DA: " + da);
            Console.WriteLine("TAX: " + tax);
            Console.WriteLine("Gross Salary: " + gross);
            Console.WriteLine("Net Salary: " + netsalary);



            //Task 3 -> Currency Converter
            Console.WriteLine("Enter INR: ");
            double inr = Convert.ToDouble(Console.ReadLine());
            double usd = inr / 83.0;
            double eur = inr / 90.5;
            Console.WriteLine("USD: " + usd.ToString("F2"));
            Console.WriteLine("EURO: " + eur.ToString("F2"));



            //Task 4 -> Time Converter
            Console.Write("Enter Minutes: ");
            int min = Convert.ToInt32(Console.ReadLine());
            int hour = min / 60;
            int rem = min % 60;
            Console.Write("Hour: " + hour);
            Console.WriteLine(" Minutes: " + rem);


            //Task 5 -> Print a table of squares and cubes for numbers 1 to 10.
            Console.WriteLine(" Number Square Cube");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i + "         " + i * i + "       " + i * i * i);
            }


            //Task 6 -> Find all “perfect numbers” between 1 and 1000 (numbers equal to the sum of their proper divisors).
            Console.WriteLine("Perfect Numbers between 1 & 1000");
            for (int number = 1; number <= 1000; number++)
            {

                int sum = 0;

                for (int i = 1; i <= number / 2; i++)
                {
                    if (number % i == 0)
                    {
                        sum += i;
                    }
                }

                if (sum == number)
                {
                    Console.WriteLine(number);
                }
            }


            //Task 7 -> Hourglass pattern
            int n = 3;

            Console.WriteLine("Hourglass Pattern:");

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 2; i <= n; i++)
            {

                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }


            //Task 8 -> Diamond of numbers
            int n = 5; // Height of the diamond

            Console.WriteLine("Diamond of Numbers:");

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }
                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }

                Console.WriteLine();
            }


            //Task 9 -> Triangle with alternate numbers:

            int rows = 5;

            Console.WriteLine("Triangle with Alternate Numbers:");

            for (int i = 1; i <= rows; i++)
            {
                int startNumber = (i % 2 == 1) ? 1 : 0;

                for (int j = 1; j <= i; j++)
                {
                    Console.Write(startNumber + " ");
                    startNumber = 1 - startNumber;
                }
                Console.WriteLine();
            }


            //Task 10 -> Display all Armstrong numbers between 100 and 999
            Console.WriteLine("Armstrong Numbers between 100 and 999:");
            int count = 0;

            for (int number = 100; number <= 999; number++)
            {
                int temp = number;
                int sum = 0;

                while (temp > 0)
                {
                    int digit = temp % 10;
                    sum += digit * digit * digit;
                    temp /= 10;
                }

                if (sum == number)
                {
                    Console.WriteLine($" {number}");
                }

            }


            //Task 11 -> Print Fibonacci series in reverse order
            Console.Write("Enter the limit ");
            int limit = Convert.ToInt32(Console.ReadLine());
            Console.Write("Fibonacci series in Reverse Order ");
            int[] arr = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                if (i == 0 || i == 1)
                {
                    arr[i] = i;
                }
                else
                {
                    arr[i] = arr[i - 1] + arr[i - 2];
                }
            }
            for (int i = limit - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + "  ");

            }






            //Task13 -> Count the total digits in a number using a loop.
            Console.Write("enter the number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            int digitcount = 0;
            while (number > 0)
            {
                digitcount++;
                number /= 10;

            }
            Console.WriteLine("digit count: " + digitcount);




            //Task14 -> Diamond pattern with numbers
            int n = 5;

            Console.WriteLine("Diamond of Numbers:");

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }
                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }

                Console.WriteLine();
            }
            for (int i = n - 1; i >= 1; i--)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }
                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }

                Console.WriteLine();
            }







        }
    }
}
