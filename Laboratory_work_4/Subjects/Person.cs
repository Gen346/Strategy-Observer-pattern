using Laboratory_work_4.Interfaces;

namespace Laboratory_work_4.Subjects
{
    public class Person : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public string Name { get; }
        public decimal CurrentWealth { get; private set; }
        public IIncomeStrategy CurrentStrategy { get; private set; }

        public Person(string name, decimal initialWealth, IIncomeStrategy strategy)
        {
            Name = name;
            CurrentWealth = initialWealth;
            CurrentStrategy = strategy;
        }

        // Method to change the strategy dynamically
        public void ChangeStrategy(IIncomeStrategy newStrategy)
        {
            CurrentStrategy = newStrategy;
            Console.WriteLine($"  -> Strategy for '{Name}' changed to: {newStrategy.StrategyName}");
        }

        // Method that uses the current strategy to receive income
        public void ReceiveIncome()
        {
            Console.WriteLine($"\n> '{Name}' ({CurrentStrategy.StrategyName}) before income: {CurrentWealth:C}");

            decimal income = CurrentStrategy.GetIncome(CurrentWealth);
            CurrentWealth += income;

            Console.WriteLine($"  - New Wealth: {CurrentWealth:C}");

            // Notify observers after the state changes
            Notify();
        }

        // ISubject methods (Observer)
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
