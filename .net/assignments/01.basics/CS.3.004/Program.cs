namespace Meter
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
                int[][] meters = new int[][] {
                new[] { 4, 5, 0, 0, 6, 7, 3 },
                new[] { 2, 2, 2, 2, 2, 2, 2 },
                new[] { 9, 1, 1, 1, 1, 1, 1 }
               };

                string[] ids = { "A-1001", "B-2001", "C-3001" };


                int globalMaxValue = 0;
                string globalMaxMeter = "";
                int globalMaxDay = 0;


                for (int meterIndex = 0; meterIndex < meters.Length; meterIndex++)
                {
                    string meterId = ids[meterIndex];
                    int[] daily = meters[meterIndex];

                    int total = 0;
                    int maxValue = 0;
                    bool peakAlert = false;
                    bool sustainedOutage = false;


                    for (int dayIndex = 0; dayIndex < daily.Length; dayIndex++)
                    {
                        int usage = daily[dayIndex];
                        total += usage;


                        if (usage > maxValue)
                        {
                            maxValue = usage;
                        }

                        if (usage > 8)
                        {
                            peakAlert = true;
                        }


                        if (dayIndex > 0 && usage == 0 && daily[dayIndex - 1] == 0)
                        {
                            sustainedOutage = true;
                        }


                        if (usage > globalMaxValue)
                        {
                            globalMaxValue = usage;
                            globalMaxMeter = meterId;
                            globalMaxDay = dayIndex + 1;
                        }
                    }


                    double average = (double)total / daily.Length;


                    Console.Write($"{meterId} | Total:{total} Avg:{average:F2} | Peak:{(peakAlert ? "Yes" : "No")} | SustainedOutage:{(sustainedOutage ? "Yes" : "No")}  ");
                }


                Console.WriteLine();
                Console.WriteLine($"Highest Day: {globalMaxValue} kWh | Meter: {globalMaxMeter} | Day: {globalMaxDay}");
            
        }
    }
}
