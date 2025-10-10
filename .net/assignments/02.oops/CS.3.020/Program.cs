namespace Model
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var model = new List<Event> {
                new OutageEvent(new DateTime(2025 ,10 , 05, 22,10,0),"AP - 0003",95),
                new TamperEvent(new DateTime(2025 ,10 , 06, 09,20,0), "AP - 0007", "MISMATCH"),
                new VoltageEvent(new DateTime(2025 ,10 , 05,18,00,0), "AP - 0001", 184)

            };

            foreach (var e in model)
            {
                Console.WriteLine(e.Describe());

            }
        }
    }
    abstract class Event
    {
        public DateTime When { get; }
        public string MeterSerial { get; }
        protected Event(DateTime when, string meterSerial) { When = when; MeterSerial = meterSerial; }
        public abstract string Category { get; }
        public abstract int Severity { get; } // 1..5
        public virtual string Describe() => $"{When:yyyy-MM-dd HH:mm} [{Category}] {MeterSerial}";
    }
    class OutageEvent : Event
    {
        int DurationMinutes { get; } 
        public OutageEvent(DateTime when, string meterSerial,int durationMinutes) : base(when, meterSerial)
        {
            DurationMinutes = durationMinutes;
        }

        public override string Category => "OUTAGE";
        public override  int Severity => 3;

        public override string Describe() => $"{When:yyyy-MM-dd HH:mm} [{Category}] {MeterSerial} | Duration: {DurationMinutes} | Severity: {Severity}";
    }
    class TamperEvent : Event
    {
        string Code { get; }
        public TamperEvent(DateTime when, string meterSerial, string code) : base(when, meterSerial)
        {
            Code = code;
        }

        public override string Category => "TAMPER";
        public override int Severity => 5;

        public override string Describe() => $"{When:yyyy-MM-dd HH:mm} [{Category}] {MeterSerial} | Code: {Code} | Severity: {Severity}";
    }
    class VoltageEvent : Event
    {
        int Voltage { get; }
        public VoltageEvent(DateTime when, string meterSerial, int voltage) : base(when, meterSerial)
        {
            Voltage = voltage;
        }

        public override string Category => "VOLTAGE";
        public override int Severity => 2;

        public override string Describe() => $"{When:yyyy-MM-dd HH:mm} [{Category}] {MeterSerial} | V: {Voltage} | Severity: {Severity}";
    }
}
