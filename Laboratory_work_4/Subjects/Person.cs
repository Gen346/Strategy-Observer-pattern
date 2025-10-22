using Laboratory_work_4.Interfaces;
using Laboratory_work_4.Subjects.Helper;

namespace Laboratory_work_4.Subjects
{
    public class Person : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public string Name { get; }
        public decimal CurrentWealth { get; private set; }
        public IIncomeStrategy CurrentStrategy { get; private set; }
        public IncomeResult LastIncomeResult { get; private set; }

        public Person(string name, decimal initialWealth, IIncomeStrategy strategy)
        {
            Name = name;
            CurrentWealth = initialWealth;
            CurrentStrategy = strategy;
        }

        public void ChangeStrategy(IIncomeStrategy newStrategy)
        {
            CurrentStrategy = newStrategy;
            Console.WriteLine($"  -> Strategy for '{Name}' changed to: {newStrategy.StrategyName}");
        }

        public void ReceiveIncome()
        {
            Console.WriteLine($"\n> '{Name}' ({CurrentStrategy.StrategyName}) before income: {CurrentWealth:C}");

            LastIncomeResult = CurrentStrategy.GetIncome(CurrentWealth);

            decimal netIncome = LastIncomeResult.GrossIncome - LastIncomeResult.TaxPaid;
            CurrentWealth += netIncome;

            Console.WriteLine($"  - Net income: {netIncome:C}, New Wealth: {CurrentWealth:C}");

            Notify(); // Notify the TaxService
        }

        // ISubject methods
        public void Attach(IObserver observer) => _observers.Add(observer);
        public void Detach(IObserver observer) => _observers.Remove(observer);
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
