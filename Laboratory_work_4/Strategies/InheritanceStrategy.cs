using Laboratory_work_4.Interfaces;

namespace Laboratory_work_4.Strategies
{
    public class InheritanceStrategy : IIncomeStrategy
    {
        private static readonly Random Rnd = new Random();
        private const int MinAmount = 100_000;
        private const int MaxAmount = 1_000_000;

        public string StrategyName => "Inheritance";
        public string IncomeType => "Other";

        public decimal GetIncome(decimal currentWealth)
        {
            // One-time large inheritance
            decimal inheritanceAmount = Rnd.Next(MinAmount, MaxAmount);
            Console.WriteLine($"  - [Inheritance] Person received an inheritance of: {inheritanceAmount:C}");
            return inheritanceAmount;
        }
    }
}
