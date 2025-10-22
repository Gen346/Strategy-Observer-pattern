using Laboratory_work_4.Interfaces;

namespace Laboratory_work_4.Subjects
{
    public class PoorPerson : Person
    {
        public PoorPerson(string name, IIncomeStrategy strategy) : base(name, 5000m, strategy) { }
    }
}
