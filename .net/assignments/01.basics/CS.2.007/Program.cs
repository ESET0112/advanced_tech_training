﻿namespace Meter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string meterCategory = "COMMERCIAL";
            int units = 120;

            double rate = 0;
            bool validCategory = true;

            switch (meterCategory)
            {
                case "DOMESTIC":
                    rate = 6.0;
                    break;
                case "COMMERCIAL":
                    rate = 8.5;
                    break;
                case "AGRICULTURE":
                    rate = 3.0;
                    break;
                default:
                    validCategory = false;
                    Console.WriteLine("Unknown category. Check configuration.");
                    break;
            }

            if (validCategory)
            {
                double totalBill = units * rate;
                Console.WriteLine($"Category: {meterCategory} | Rate: ₹{rate} | Total Bill: ₹{totalBill:F2}");
            }
        }
    }
}
