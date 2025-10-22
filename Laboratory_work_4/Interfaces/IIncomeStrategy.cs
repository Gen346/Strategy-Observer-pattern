using Laboratory_work_4.Subjects.Helper;

namespace Laboratory_work_4.Interfaces
{
    public interface IIncomeStrategy
    {
        IncomeResult GetIncome(decimal currentWealth);
        string StrategyName { get; }
    }
}
