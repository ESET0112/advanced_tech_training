namespace Meter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Meter m1 = new Meter("AP-0001", new DateTime(2024, 07, 01), 3);
            m1.Describe();
            Gateway g1 = new Gateway("GW-11", new DateTime(2025, 01, 10), "10.0.5.21");
            g1.Describe();
        }   
    }
    internal class device
    {
        public string Id;
        public DateTime InstalledOn;

        public device(string id, DateTime installedOn)
        {
            Id = id;
            InstalledOn = installedOn;
        }
        public virtual void Describe()
        {
            Console.WriteLine($"Meter Id: {Id} |Installed: {InstalledOn:yyyy-MM-dd}");
        }
    }

    internal class Meter : device
    {
        int PhaseCount = 0;
        public Meter(string id, DateTime installedOn,int phaseCount): base(id,installedOn)
        {
            PhaseCount = phaseCount;
        }
        public override void Describe()
        {
            Console.WriteLine($"Meter Id: {Id} |Installed: {InstalledOn:yyyy-MM-dd} | Phases: {PhaseCount}");
        }
    }
    internal class Gateway : device
    {
        string IP ;
        public Gateway(string id, DateTime installedOn, string ip) : base(id,installedOn) 
        {
            IP = ip;
        }
        public override void Describe()
        {
            Console.WriteLine($"Meter Id: {Id} |Installed: {InstalledOn:yyyy-MM-ddn} | IP: {IP}");
        }
    }

}
