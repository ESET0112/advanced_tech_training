namespace Readable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IReadable> readable= new List<IReadable>()
            {
                new DlmsMeter("AP-0001"),
                new ModemGateway("GW-21")
            };
            for (int i = 0; i < 5; i++)
            {
                foreach (var r in readable)
                {
                    Console.WriteLine($"{r.SourceId}: {r.ReadKwh()}");
                }

            }
            
        }
    }

    public interface IReadable
    {
        int ReadKwh();             // returns delta since last poll
        string SourceId { get; }
    }

    public class DlmsMeter : IReadable
    {
        public string SourceId { get; }
        public DlmsMeter(string sourceid)
        {
            this.SourceId = sourceid;
        }
        public int ReadKwh() 
        {
            Random random = new Random();

            // Random integer between 0 and 10
            int randomNumber = random.Next(1,10);
            return randomNumber;
        }


    }
    public class ModemGateway : IReadable
    {
        public string SourceId { get; }
        public ModemGateway(string sourceid)
        {
            this.SourceId = sourceid;
        }
        public int ReadKwh()
        {
            Random random = new Random();

            // Random integer between 0 and 2
            int randomNumber = random.Next(0, 2);
            return randomNumber;
        }


    }
}
