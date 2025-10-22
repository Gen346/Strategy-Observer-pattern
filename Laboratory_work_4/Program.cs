using Laboratory_work_4;
using Laboratory_work_4.Interfaces;
using Laboratory_work_4.Strategies;
using Laboratory_work_4.Subjects;

public class Program
{
    private static readonly Random Rnd = new Random();
    private static readonly string[] Names = { "Dima", "Danya", "Eugene", "Maria", "Artem", "Herman", "Nikita", "Vika", "Kolya", "Andrii" };

    private static Person CreateRandomPerson(string name)
    {
        IIncomeStrategy randomStrategy = GetRandomStrategy();

        int typeIndex = Rnd.Next(3);
        switch (typeIndex)
        {
            case 0:
                return new PoorPerson(name, randomStrategy);
            case 1:
                return new MiddleClassPerson(name, randomStrategy);
            case 2:
            default:
                return new RichPerson(name, randomStrategy);
        }
    }

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
        Console.WriteLine("--- Strategy and Observer Patterns Demonstration: Tax Evasion Check ---");

        TaxService taxService = new TaxService();
        Console.WriteLine($"\n[INFO] Tax Service is ready for surveillance.");

        List<Person> peopleList = new List<Person>();
        for (int i = 0; i < 10; i++)
        {
            Person person = CreateRandomPerson(Names[i]);
            person.Attach(taxService);
            peopleList.Add(person);
            Console.WriteLine($"- Created '{person.Name}': Initial Wealth {person.CurrentWealth:C}, Strategy: {person.CurrentStrategy.StrategyName}");
        }

        // --- SCENARIO 1: First Income Cycle ---
        Console.WriteLine("\n================ SCENARIO 1: First Income Cycle ================");

        foreach (Person person in peopleList)
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
            foreach (string name in taxService.PeopleUnderSurveillance.OrderBy(n => n))
            {
                Console.WriteLine($"  - {name}");
            }
        }
    }
}