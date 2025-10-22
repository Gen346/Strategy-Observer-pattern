using Laboratory_work_4;
using Laboratory_work_4.Interfaces;
using Laboratory_work_4.Strategies;
using Laboratory_work_4.Subjects;


public class Program
{
    private static readonly Random Rnd = new Random();

    // Метод для випадкового вибору типу людини та створення її екземпляра
    private static Person CreateRandomPerson(string name)
    {
        // 1. Випадковий вибір стратегії доходу
        IIncomeStrategy randomStrategy = GetRandomStrategy();

        // 2. Випадковий вибір типу людини
        int typeIndex = Rnd.Next(3);
        switch (typeIndex)
        {
            case 0:
                // Створити Бідняка, але з випадковою стратегією, а не дефолтною
                return new Person(name, 5000m, randomStrategy);
            case 1:
                // Створити Середній клас, але з випадковою стратегією, а не дефолтною
                return new Person(name, 50000m, randomStrategy);
            case 2:
            default:
                // Створити Заможну людину, але з випадковою стратегією, а не дефолтною
                return new Person(name, 500000m, randomStrategy);
        }
    }

    // Метод для випадкового вибору однієї з трьох стратегій
    private static IIncomeStrategy GetRandomStrategy()
    {
        int strategyIndex = Rnd.Next(3);
        switch (strategyIndex)
        {
            case 0:
                return new WhiteIncomeStrategy();
            case 1:
                return new BlackIncomeStrategy();
            case 2:
            default:
                return new InheritanceStrategy();
        }
    }

    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("--- Strategy and Observer Patterns Demonstration: 10 Random People ---");

        // 1. Create the Observer (Tax Service)
        var taxService = new TaxService();
        Console.WriteLine($"\n[INFO] Tax Service is ready for surveillance.");

        // 2. Generate 10 random people
        List<Person> peopleList = new List<Person>();
        string[] names = { "Liam", "Olivia", "Noah", "Emma", "Oliver", "Ava", "Elijah", "Sophia", "William", "Isabella" };

        for (int i = 0; i < 10; i++)
        {
            string name = names[i];
            Person person = CreateRandomPerson(name);
            person.Attach(taxService);
            peopleList.Add(person);
            Console.WriteLine($"- Created '{person.Name}': Initial Wealth {person.CurrentWealth:C}, Strategy: {person.CurrentStrategy.StrategyName}");
        }

        // --- SCENARIO 1: First Income Cycle ---

        Console.WriteLine("\n================ SCENARIO 1: First Income Cycle ================");

        foreach (var person in peopleList)
        {
            person.ReceiveIncome();
        }

        // --- SCENARIO 2: Check Surveillance Database ---

        Console.WriteLine("\n================ SCENARIO 2: Surveillance Check ================");
        Console.WriteLine($"Tax Service 'People Under Surveillance' Database ({taxService.PeopleUnderSurveillance.Count} people):");
        if (taxService.PeopleUnderSurveillance.Count == 0)
        {
            Console.WriteLine("  - Database is empty.");
        }
        else
        {
            foreach (var name in taxService.PeopleUnderSurveillance)
            {
                Console.WriteLine($"  - {name}");
            }
        }

        // --- SCENARIO 3: Second Income Cycle (Some people switch strategy) ---

        Console.WriteLine("\n================ SCENARIO 3: Strategy Switching and Second Income ================");

        foreach (var person in peopleList)
        {
            // 30% chance to switch to Black Income
            if (Rnd.Next(100) < 30)
            {
                person.ChangeStrategy(new BlackIncomeStrategy());
            }
            // 10% chance to switch to White Income
            else if (Rnd.Next(100) < 10)
            {
                person.ChangeStrategy(new WhiteIncomeStrategy());
            }

            person.ReceiveIncome();
        }

        // --- SCENARIO 4: Final Surveillance Check ---

        Console.WriteLine("\n================ SCENARIO 4: Final Surveillance Check ================");
        Console.WriteLine($"Tax Service 'People Under Surveillance' Database ({taxService.PeopleUnderSurveillance.Count} people):");
        foreach (var name in taxService.PeopleUnderSurveillance.OrderBy(n => n))
        {
            // Check if the person's current income is still Black for deeper analysis
            var finalPerson = peopleList.FirstOrDefault(p => p.Name == name);
            string status = finalPerson.CurrentStrategy.IncomeType == "Black" ? " (Currently Black)" : " (Switched Away)";
            Console.WriteLine($"  - {name}{status}");
        }
    }
}