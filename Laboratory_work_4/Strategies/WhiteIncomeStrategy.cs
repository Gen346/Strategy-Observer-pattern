using Laboratory_work_4.Interfaces;
using Laboratory_work_4.Subjects.Helper;

namespace Laboratory_work_4.Strategies
{
    public class WhiteIncomeStrategy : IIncomeStrategy
    {
        private const decimal StandardTaxRate = 0.23m;
        private const decimal SalaryFactor = 0.05m;

        public string StrategyName => "White Income (Tax Compliant)";

        public IncomeResult GetIncome(decimal currentWealth)
        {
            decimal grossIncome = Math.Max(1000, currentWealth * SalaryFactor);
            decimal taxDue = grossIncome * StandardTaxRate;

            decimal netIncome = grossIncome - taxDue;

            Console.WriteLine($"  - [White] Gross: {grossIncome:C}, Paid Tax: {taxDue:C}, Net: {netIncome:C}");

            return new IncomeResult
            {
                GrossIncome = grossIncome,
                TaxPaid = taxDue, // Correct amount is paid
                StrategyName = StrategyName
            };
        }
    }
}
