using Laboratory_work_4.Interfaces;

namespace Laboratory_work_4.Strategies
{
    public class WhiteIncomeStrategy : IIncomeStrategy
    {
        private const decimal TaxRate = 0.18m;
        private const decimal SalaryFactor = 0.05m;

        public string StrategyName => "White Income";
        public string IncomeType => "White";

        public decimal GetIncome(decimal currentWealth)
        {
            // Income based on current wealth (simplification)
            decimal incomeBeforeTax = Math.Max(1000, currentWealth * SalaryFactor);
            decimal tax = incomeBeforeTax * TaxRate;
            decimal netIncome = incomeBeforeTax - tax;
            Console.WriteLine($"  - [White] Gross: {incomeBeforeTax:C}, Tax: {tax:C}, Net: {netIncome:C}");
            return netIncome;
        }
    }
}
