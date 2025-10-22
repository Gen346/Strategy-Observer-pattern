using Laboratory_work_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_work_4.Strategies
{
    public class BlackIncomeStrategy : IIncomeStrategy
    {
        private const decimal ProfitFactor = 0.10m; // Higher profit margin

        public string StrategyName => "Black Income";
        public string IncomeType => "Black";

        public decimal GetIncome(decimal currentWealth)
        {
            decimal income = Math.Max(2000, currentWealth * ProfitFactor);
            // No taxes paid
            Console.WriteLine($"  - [Black] Gross: {income:C}, Tax: 0.00C, Net: {income:C}");
            return income;
        }
    }
}
