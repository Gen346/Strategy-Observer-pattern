using Laboratory_work_4.Interfaces;
using Laboratory_work_4.Subjects;

namespace Laboratory_work_4
{
    public class TaxService : IObserver
    {
        public HashSet<string> PeopleUnderSurveillance { get; } = new HashSet<string>();

        public void Update(Person person)
        {
            // Surveillance condition: if income type is "Black"
            if (person.CurrentStrategy.IncomeType == "Black")
            {
                if (PeopleUnderSurveillance.Add(person.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"*** TAX ALERT: Person '{person.Name}' (Wealth: {person.CurrentWealth:C}) added to 'Surveillance List' due to {person.CurrentStrategy.StrategyName}! ***");
                    Console.ResetColor();
                }
            }
            // Note: For simplicity, the person is not removed if they switch to "White"
        }
    }
}
