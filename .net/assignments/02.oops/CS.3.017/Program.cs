namespace Alarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testday1 = new LoadProfileDay(
                new DateTime(2025,10,1),
                new List<double> { 150, 200, 180, 0, 0, 0, 0, 160, 220, 300, 400, 350,
                              280, 250, 200, 180, 220, 300, 450, 500, 480, 400, 300, 200 }
            );
            var testday2 = new LoadProfileDay(
                new DateTime(2025, 10, 2),
                new List<double> { 0, 0, 0, 0, 0, 0, 50, 100, 150, 120, 110, 100,
                              90, 80, 70, 60, 50, 40, 30, 20, 10, 0, 0, 0 }
            );
            var testdays = new[] {testday1,testday2 };
            var rules = new List<AlarmRule> {
                new PeakOveruseRule(threshold: 5000),
                new SustainedOutageRule(min:4)
                };

            foreach (var testday in testdays)
            {
                foreach(var rule in rules)
                {
                    if (rule.IsTriggered(testday))
                    {
                        Console.WriteLine($"{rule.Message(testday)}");
                    }
                }

            }
        }
    }
    abstract class AlarmRule
    {
        public string Name { get; }
        protected AlarmRule(string name) => Name = name;
        public abstract bool IsTriggered(LoadProfileDay day);
        public virtual string Message(LoadProfileDay day)
            => $"{Name} triggered on {day.Date:yyyy-MM-dd}";
    }

    class PeakOveruseRule : AlarmRule
    {   // trigger if day.Total > threshold
        private readonly int _threshold;
        public PeakOveruseRule(int threshold) : base("PeakOveruse") => _threshold = threshold;
        public override bool IsTriggered(LoadProfileDay day) => day.Total > _threshold;
    }

    class SustainedOutageRule : AlarmRule
    {   // trigger if consecutive zero hours >= N
        private readonly int _minConsecutive;
        public SustainedOutageRule(int min) : base("SustainedOutage") => _minConsecutive = min;
        public override bool IsTriggered(LoadProfileDay day) 
        {
            int currentConsecutive = 0;

            foreach (var load in day.HourlyLoad)
            {
                if (load == 0)
                {
                    currentConsecutive++;
                    if (currentConsecutive >= _minConsecutive)
                        return true;
                }
                else
                {
                    currentConsecutive = 0;
                }
            }

            return false;
        }
    }
    
    public class LoadProfileDay
    {
        public DateTime Date { get;}
        public List<double> HourlyLoad { get; set;}
        public LoadProfileDay(DateTime date, List<double> hourlyLoad)
        {
            Date = date;
            HourlyLoad = hourlyLoad;
        }

        public double Total => HourlyLoad.Sum();
        
    }
}
