namespace LoadProfile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hourlyData = {5, 4, 3, 2, 2, 3, 4, 6, 8, 10, 12, 14,
                               15, 16, 17, 18, 20, 22, 25, 8, 6, 5, 4, 3};
            LoadProfileDay lpd = new LoadProfileDay(new DateTime(2025,10,1),hourlyData);
            Console.WriteLine($"{lpd.Date:yyyy-MM-dd} | Total: {lpd.Total} kWh | PeakHour: {lpd.PeakHour}");

        }
    }
    class LoadProfileDay
    {
        public DateTime Date { get; }
        public int[] HourlyKwh { get; } // length 24
        public LoadProfileDay(DateTime date, int[] hourly)
        {
            Date = date;
            HourlyKwh = new int[24];
            Array.Copy(hourly, HourlyKwh, 24);
        }

        public int Total
        {
            get
            {
                int sum = 0;
                foreach (int hourly in HourlyKwh)
                {
                    sum += hourly;
                }
                return sum;
            }
        }

    
        public int PeakHour
        {
            get
            {
                int maxval = 0;
                for (int i = 0; i < 24; i++)
                {
                    if (HourlyKwh[i] > HourlyKwh[maxval])
                    {
                        maxval = i;
                    }
                }
                return maxval+1;
            }
        }
    }
}
