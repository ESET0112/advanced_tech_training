namespace Model
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new BillingContext(new CommercialBillingRule());

            // Add both rebates
            context.Rebates.Add(new NoOutageRebate());
            context.Rebates.Add(new HighUsageRebate());

            // Calculate billing: units=620, outageDays=0
            int units = 620;
            int outageDays = 0;

            double subtotal = context.Rule.Compute(units);
            double finalTotal = context.Finalize(units, outageDays);

            // Print results
            double rate = 8.5;
            double fixedCharge = 150;
            double unitsCost = rate * units;

            Console.WriteLine($"Subtotal: ₹{rate}*{units} + {fixedCharge} = ₹{unitsCost:N0} + {fixedCharge} = ₹{subtotal:N2}");
            Console.Write("Rebates: ");

            bool first = true;
            foreach (var rebate in context.Rebates)
            {
                if (!first) Console.Write(" | ");
                Console.Write($"{rebate.Code}");

                if (rebate is NoOutageRebate && outageDays == 0)
                    Console.Write(" -2%");
                else if (rebate is HighUsageRebate && units > 500)
                    Console.Write(" -3%");

                first = false;
            }
            Console.WriteLine();
            Console.WriteLine($"Final: ₹{finalTotal:N2}");
        }
    }
    public interface IBillingRule
    {
        string Name { get; }
        double Compute(int units);
    }

    // Commercial Billing Rule (example implementation)
    public class CommercialBillingRule : IBillingRule
    {
        public string Name => "Commercial";

        public double Compute(int units)
        {
            double rate = 8.5;
            double fixedCharge = 150;
            return (rate * units) + fixedCharge;
        }
    }

    // New Rebate interface
    public interface IRebate
    {
        string Code { get; }
        double Apply(double currentTotal, int outageDays);
    }

    // Rebate implementations
    public class NoOutageRebate : IRebate
    {
        public string Code => "NO_OUTAGE";

        public double Apply(double currentTotal, int outageDays)
        {
            if (outageDays == 0)
            {
                return -currentTotal * 0.02; // -2%
            }
            return 0;
        }
    }

    public class HighUsageRebate : IRebate
    {
        public string Code => "HIGH_USAGE";

        public double Apply(double currentTotal, int outageDays)
        {
            // Note: We need units to check >500, but interface only has outageDays
            // We'll handle this differently in the BillingContext
            return 0; // This will be overridden in the context
        }
    }

    // Updated HighUsageRebate that works with the current interface
    public class HighUsageRebateWithUnits : IRebate
    {
        private readonly int _units;

        public HighUsageRebateWithUnits(int units)
        {
            _units = units;
        }

        public string Code => "HIGH_USAGE";

        public double Apply(double currentTotal, int outageDays)
        {
            if (_units > 500)
            {
                return -currentTotal * 0.03; // -3%
            }
            return 0;
        }
    }

    // Billing Context
    public class BillingContext
    {
        public IBillingRule Rule { get; }
        public List<IRebate> Rebates { get; } = new();
        public BillingContext(IBillingRule rule) => Rule = rule;

        public double Finalize(int units, int outageDays)
        {
            double total = Rule.Compute(units);

            // Create rebates that need units information
            var rebatesWithUnits = new List<IRebate>();
            foreach (var rebate in Rebates)
            {
                if (rebate is HighUsageRebate)
                {
                    rebatesWithUnits.Add(new HighUsageRebateWithUnits(units));
                }
                else
                {
                    rebatesWithUnits.Add(rebate);
                }
            }

            foreach (var r in rebatesWithUnits)
            {
                total += r.Apply(total, outageDays);
            }
            return total;
        }
    }
}
