using Laboratory_work_4.Interfaces;

namespace Laboratory_work_4.Subjects
{
    public class RichPerson : Person
    {
        public RichPerson(string name, IIncomeStrategy strategy) : base(name, 500_000m, strategy) { }
    }
}
