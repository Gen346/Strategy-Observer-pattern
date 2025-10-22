using Laboratory_work_4.Interfaces;
using Laboratory_work_4.Subjects.Helper;

namespace Laboratory_work_4.Strategies
{
    public class InheritanceStrategy : IIncomeStrategy
    {
        private static readonly Random Rnd = new Random();
        private const int MinAmount = 100_000;
        private const int MaxAmount = 1_000_000;
        private const decimal InheritanceTaxRate = 0.05m; // Simplified 5% inheritance tax

        public string StrategyName => "Inheritance";

        public IncomeResult GetIncome(decimal currentWealth)
        {
            decimal grossIncome = Rnd.Next(MinAmount, MaxAmount);
            decimal taxDue = grossIncome * InheritanceTaxRate;

            decimal netIncome = grossIncome - taxDue;

            Console.WriteLine($"  - [Inheritance] Gross: {grossIncome:C}, Paid Tax: {taxDue:C}, Net: {netIncome:C}");

            return new IncomeResult
            {
                GrossIncome = grossIncome,
                TaxPaid = taxDue, // Tax is paid for inheritance
                StrategyName = StrategyName
            };
        }
    }
}
