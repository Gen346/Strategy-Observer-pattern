using Laboratory_work_4.Interfaces;
using Laboratory_work_4.Subjects.Helper;

namespace Laboratory_work_4.Strategies
{
    public class BlackIncomeStrategy : IIncomeStrategy
    {
        private const decimal ProfitFactor = 0.10m;

        public string StrategyName => "Black Income (Tax Evasion)";

        public IncomeResult GetIncome(decimal currentWealth)
        {
            decimal grossIncome = Math.Max(2000, currentWealth * ProfitFactor);
            decimal taxDue = 0.00m; // The black income doesn't report/pay taxes

            Console.WriteLine($"  - [Black] Gross: {grossIncome:C}, Paid Tax: {taxDue:C}, Net: {grossIncome:C}");

            return new IncomeResult
            {
                GrossIncome = grossIncome,
                TaxPaid = taxDue, // Zero tax paid, but income was generated
                StrategyName = StrategyName
            };
        }
    }
}
