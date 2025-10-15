namespace Meter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pattern = { 4, 4, 5, 5, 0, 6, 7, 3, 4, 5 };
            string category = "COMMERCIAL"; 

            
            int[] month = new int[30];
            for (int i = 0; i < 30; i++)
            {
                month[i] = pattern[i % pattern.Length];
            }

            
            int monthlyUnits = 0;
            int outageDays = 0;

            foreach (int units in month)
            {
                monthlyUnits += units;
                if (units == 0)
                {
                    outageDays++;
                }
            }

            
            double energyCharge = 0;
            int remainingUnits = monthlyUnits;

            if (remainingUnits > 100)
            {
                energyCharge += 100 * 4.0;
                remainingUnits -= 100;

                if (remainingUnits > 200)
                {
                    energyCharge += 200 * 6.0;
                    remainingUnits -= 200;
                    energyCharge += remainingUnits * 8.5;
                }
                else
                {
                    energyCharge += remainingUnits * 6.0;
                }
            }
            else
            {
                energyCharge += remainingUnits * 4.0;
            }

            
            double fixedCharge = 0;
            switch (category)
            {
                case "DOMESTIC":
                    fixedCharge = 50;
                    break;
                case "COMMERCIAL":
                    fixedCharge = 150;
                    break;
                default:
                    fixedCharge = 100; 
                    break;
            }

            double rebate = 0;
            double subtotal = energyCharge + fixedCharge;

            if (outageDays == 0)
            {
                rebate = subtotal * 0.02;
            }

            double grandTotal = subtotal - rebate;

            Console.WriteLine($"Category: {category} | Units: {monthlyUnits} | " +
                $"Energy: ₹{energyCharge:F2} | Fixed: ₹{fixedCharge:F2} | Rebate: ₹{rebate:F2} | " +
                $"Total: ₹{grandTotal:F2} | Outages: {outageDays}");
        }
    }
}
