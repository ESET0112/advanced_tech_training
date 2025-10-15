namespace Meter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Previous Reading: ");
            int prev_reading = Convert.ToInt32(Console.ReadLine());
            Console.Write("Current Reading: ");
            int curr_reading = Convert.ToInt32(Console.ReadLine());

            int consumption = curr_reading - prev_reading;

            Console.WriteLine($"Net Consumption: {consumption}");
            if (consumption< 0)
                Console.WriteLine("Invalid");

            else if (consumption == 0)
                Console.WriteLine("Possible outage.");
            else if (consumption < 500)
                Console.WriteLine("Normal outage.");
            else
                Console.WriteLine("High consumption Alert!");

            

        }
    }
}
