namespace BillingRule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int units = 120;
            List<IBillingRule> billingRules = new List<IBillingRule>()
            {
                new DomesticRule(),
                new CommercialRule(),
                new AgricultureRule()
            };

            foreach (IBillingRule rule in billingRules)
            {
                BillingEngine bill = new BillingEngine(rule);
                double billAmount = bill.GenerateBill(units);
                Console.WriteLine($"{rule.Category} -> {billAmount:F2}");
            }
        }
    }
    public interface IBillingRule
    {
        public string Category { get; }
        double Compute(int units);
    }
    class DomesticRule : IBillingRule 
    {
        public string Category { get; }
        public DomesticRule()
        {
            Category = "Domestic";
        }
        public double Compute(int units)
        {
            return (6 * units + 50);
        } 
    }
    class CommercialRule : IBillingRule 
    {
        public string Category => "Commercial";
        public double Compute(int units)
        {
            return (8.5 * units + 150);
        } 
    }
    class AgricultureRule : IBillingRule 
    {
        public string Category => "Agriculture";
        public double Compute(int units)
        {
            return (3 * units );
        } 
    }

    class BillingEngine
    {
        public IBillingRule Rule { get; set; }
        public BillingEngine(IBillingRule rule) 
        {
            Rule = rule;
        }
        public double GenerateBill(int units)
        {
            return Rule.Compute(units);
        }
    }
}
