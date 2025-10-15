namespace consumption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] daily = { 4, 5, 6, 0, 7, 8, 5 };

            int total = 0;
            int maxUsage = daily[0];
            int maxDay = 1;
            int outages = 0;

            for (int i = 0; i < daily.Length; i++)
            {
                total += daily[i];

                if (daily[i] > maxUsage)
                {
                    maxUsage = daily[i];
                    maxDay = i + 1;
                }

                if (daily[i] == 0)
                {
                    outages++;
                }
            }
            double average = (double)total / daily.Length;

            Console.WriteLine($"Total: {total} kWh | Avg: {average:F2} kWh | Max: {maxUsage} kWh (Day {maxDay}) | Outages: {outages}");
        }
    }
}
