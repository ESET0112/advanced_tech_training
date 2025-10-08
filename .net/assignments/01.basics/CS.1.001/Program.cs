namespace Readings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Meter Serial No.:  ");
            string meterSerial = Console.ReadLine();
            Console.Write("Enter Previous Reading:  ");
            int prevReading = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter Current Reading:  ");
            int currReading = Convert.ToInt32(Console.ReadLine());

            if (prevReading < 0 || currReading < 0)
            {
                Console.WriteLine("Negative Reading Not Allowed");
                return;
            }

            int units = currReading - prevReading;
            double energyCharge = 0;
            double tax = 0;
            double total = 0;
            if (units <= 0)
            {
                Console.WriteLine("Error");
                return;
            }  
            else
            {
                if (units > 500)
                    Console.WriteLine("High Usage!!!");
                energyCharge = units * 6.5;
                tax = 0.05 * energyCharge;
                total = energyCharge + tax;
            }
            Console.WriteLine($"Meter: {meterSerial} | Units: {units} | Energy: ₹{energyCharge.ToString("F2")} | Tax(5%): ₹{tax.ToString("F2")} | Total: ₹{total.ToString("F2")}");
        }
    }
}
