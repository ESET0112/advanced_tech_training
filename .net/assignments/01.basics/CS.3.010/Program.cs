namespace Multi_Meter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meterIds = { "MTR001", "MTR002", "MTR003" };
            int[][] outageHours = {
            new int[] { 1, 0, 0, 5, 2, 0, 0 },  // MTR001
            new int[] { 0, 0, 0, 0, 0, 0, 0 },   // MTR002
            new int[] { 0, 4, 3, 0, 0, 0, 0 }    // MTR003
        };

            bool validData = true;

            int meterIndex = 0;
            while (meterIndex < outageHours.Length && validData)
            {
                int dayIndex = 0;
                while (dayIndex < outageHours[meterIndex].Length && validData)
                {
                    if (outageHours[meterIndex][dayIndex] < 0)
                    {
                        validData = false;
                        Console.WriteLine("Invalid Data: Negative entry found");
                    }
                    dayIndex++;
                }
                meterIndex++;
            }

            if (validData)
            {
                for (int i = 0; i < meterIds.Length; i++)
                {
                    int totalOutageHours = 0;

                    for (int j = 0; j < outageHours[i].Length; j++)
                        totalOutageHours += outageHours[i][j];

                    string action;
                    if (totalOutageHours > 8)
                        action = "Escalate to field team";
                    else if (totalOutageHours == 0)
                        action = "Stable";
                    else
                        action = "Monitor";

                    Console.WriteLine($"{meterIds[i]} | Outage Hours: {totalOutageHours} | Action: {action}");
                }
            }
        }
    }
}
