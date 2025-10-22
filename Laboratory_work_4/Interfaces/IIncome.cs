namespace Laboratory_work_4.Interfaces
{
    public interface IIncomeStrategy
    {
        // Calculates and returns the net income for the period
        decimal GetIncome(decimal currentWealth);
        string StrategyName { get; }
        string IncomeType { get; } // For Observer: "White", "Black", "Other"
    }
}
