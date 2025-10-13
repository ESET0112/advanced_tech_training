namespace Model
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataIngestor dlmsWithOutages = new RandomOutageDecorator(new DlmsIngestor());

            
            Console.WriteLine(dlmsWithOutages.Name);
            var batch = dlmsWithOutages.ReadBatch(10);

            foreach (var (ts, kwh) in batch)
            {
                Console.WriteLine($"{ts:yyyy-MM-dd HH:mm} -> {kwh}");
            }
        }
    }

    public interface IDataIngestor
    {
        string Name { get; }
        IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count);
    }

    public class DlmsIngestor : IDataIngestor
    {
        private DateTime _currentTime;
        private readonly Random _random;

        public string Name => "DLMS Ingestor";

        public DlmsIngestor()
        {
            _currentTime = DateTime.Now.Date.AddHours(8); 
            _random = new Random();
        }

        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int kwh = _random.Next(1, 6); 
                yield return (_currentTime, kwh);
                _currentTime = _currentTime.AddHours(1);
            }
        }
    }

    public class RandomOutageDecorator : IDataIngestor
    {
        private readonly IDataIngestor _decoratedIngestor;
        private readonly Random _random;

        public string Name => $"[{_decoratedIngestor.Name}+Outage]";

        public RandomOutageDecorator(IDataIngestor ingestor)
        {
            _decoratedIngestor = ingestor;
            _random = new Random();
        }

        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            foreach (var (ts, kwh) in _decoratedIngestor.ReadBatch(count))
            {
                
                if (_random.Next(0, 5) == 0)
                {
                    yield return (ts, 0);
                }
                else
                {
                    yield return (ts, kwh);
                }
            }
        }
    }
}
