namespace Meter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] daily = { 5.2, 6.8, 0.0, 7.5, 6.0, 4.8, 0.0 };

            double total = 0;
            int peakDays = 0;
            int outageDays = 0;

            for (int i = 0; i < daily.Length; i++)
            {
                total += daily[i];

                if (daily[i] > 6.0)
                    peakDays++;
                
                if (daily[i] == 0.0)
                    outageDays++;
            }

            double average = total / daily.Length;

            string performanceStatus = (outageDays <= 1 && peakDays <= 2) ? "Stable" : "Unstable";

            Console.WriteLine($"Total: {total:F1} kWh | Avg: {average:F2} kWh | Peak Days (>6): {peakDays} | Outages: {outageDays}");
            Console.WriteLine($"Performance Status: {performanceStatus}");
        }
    }
}
