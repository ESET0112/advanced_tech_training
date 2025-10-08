namespace Readings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime installedDate = new DateTime(2021, 1, 15);
            Meter m1 = new Meter("0001", "Feeder - 12" ,installedDate, 15230);
            installedDate = new DateTime(2022, 4, 10);
            Meter m2 = new Meter("0002", "DTR-9", installedDate , 9800);
            m1.summary();
            m1.AddReading(20);
            Console.WriteLine("After taking deltaKwh 20 for meter 0001");
            m1.summary();
            Console.WriteLine("--------------------------------------------------");
            m2.summary();
            m2.AddReading(0);
            Console.WriteLine("After taking deltaKwh 0 for meter 0002");
            m2.summary();

        }
    }
    internal class Meter
    {
        string MeterSerial, Location;
        DateTime InstalledOn;
        int LastReadingKwh;

        public Meter(string MeterSerial, string Location, DateTime InstalledOn, int LastReadingKwh)
        {
            this.MeterSerial = MeterSerial;
            this.Location = Location;
            this.InstalledOn = InstalledOn;
            this.LastReadingKwh = LastReadingKwh;
        }

        public void AddReading(int deltaKwh)
        {
            if(deltaKwh > 0)
            {
                LastReadingKwh += deltaKwh;
            }
        }
        public void summary()
        {
            Console.WriteLine($"SERIAL: {MeterSerial} Location: {Location} | Reading: {LastReadingKwh}");
        }
    }
}
