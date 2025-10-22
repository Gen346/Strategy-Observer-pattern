using Laboratory_work_4.Interfaces;
using Laboratory_work_4.Subjects;
using Laboratory_work_4.Subjects.Helper;

namespace Laboratory_work_4
{
    public class TaxService : IObserver
    {
        private const decimal StandardTaxRate = 0.23m;

        public HashSet<string> PeopleUnderSurveillance { get; } = new HashSet<string>();

        public void Update(Person person)
        {
            // Get the latest income result from the person
            IncomeResult lastIncome = person.LastIncomeResult;

            // Skip check if no income was generated (GrossIncome = 0)
            if (lastIncome == null || lastIncome.GrossIncome <= 0)
                return;

            // Calculate the tax that *should* have been paid (using a simplified standard rate)
            // We use WhiteIncomeStrategy's rate for comparison, excluding special cases like Inheritance
            decimal expectedTax = lastIncome.GrossIncome * StandardTaxRate;

            // The core check: Tax Evasion is detected if expected tax is significantly higher than paid tax
            // We use a small tolerance (0.01m) for floating point safety
            bool isTaxEvasionDetected = expectedTax - lastIncome.TaxPaid > 0.01m;

            // Special case: Ignore if the strategy is Inheritance
            if (lastIncome.StrategyName == "Inheritance")
            {
                isTaxEvasionDetected = false;
            }

            if (isTaxEvasionDetected)
            {
                if (PeopleUnderSurveillance.Add(person.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"*** TAX ALERT: Person '{person.Name}' (Income: {lastIncome.GrossIncome:C}) detected! Expected Tax: {expectedTax:C}, Paid Tax: {lastIncome.TaxPaid:C}. Added to Surveillance List! ***");
                    Console.ResetColor();
                }
            }
            // If they were under surveillance but now pay taxes correctly, they can be removed (optional)
            // else
            // {
            //     PeopleUnderSurveillance.Remove(person.Name); 
            // }
        }
    }
}
