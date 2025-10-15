namespace Meter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] status = { "OK", "OUTAGE", "OK", "TAMPER", "OUTAGE", "OK", "LOW_VOLT" };

            int okCount = 0;
            int outageCount = 0;
            int tamperCount = 0;
            int lowVoltCount = 0;
            bool suspiciousPattern = false;

            for (int i = 0; i < status.Length; i++)
            {
                switch (status[i])
                {
                    case "OK":
                        okCount++;
                        break;
                    case "OUTAGE":
                        outageCount++;
                        break;
                    case "TAMPER":
                        tamperCount++;
                        break;
                    case "LOW_VOLT":
                        lowVoltCount++;
                        break;
                }

                if (i > 0 && status[i] == "TAMPER" && status[i - 1] == "OUTAGE")
                    suspiciousPattern = true;
            }

            Console.WriteLine($"OK: {okCount} | OUTAGE: {outageCount} | TAMPER: {tamperCount} | LOW_VOLT: {lowVoltCount}");

            if (outageCount > 2 || tamperCount > 1)
                Console.WriteLine("Maintenance required");
            else
                Console.WriteLine("Meter healthy");

            if (suspiciousPattern)
                Console.WriteLine("Suspicious Pattern");
        }
    }
}
