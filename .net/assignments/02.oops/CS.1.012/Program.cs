using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Reading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tariff Domestic = new Tariff("Domestic");
            Tariff Commercial = new Tariff("Commercial",8.0);
            Tariff Agri = new Tariff("Agri",9.0,80);

            Domestic.ComputeBill(120);
            Commercial.ComputeBill(120);
            Agri.ComputeBill(120);
        }
    }
    internal class Tariff
    {
        public string Name { get; set; }
        public double RatePerKwh { get; set; }
        public double FixedCharge {  get; set; }

        public Tariff(string name) 
        {
            Name = name;
            RatePerKwh = 6.0;
            FixedCharge = 50;
        } 

        public Tariff(string name, double rate)
        {
            Name = name;
            RatePerKwh = rate;
            FixedCharge = 50;
        }

        public Tariff(string name, double rate, double fixedCharge)
        {
            Name = name;
            RatePerKwh = rate;
            FixedCharge = fixedCharge;
        }
        public void ComputeBill(int units)
        {
            Console.WriteLine($"{Name}: {units * RatePerKwh + FixedCharge}"); 
        }
    }
}
