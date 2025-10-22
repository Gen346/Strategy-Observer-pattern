using Laboratory_work_4.Interfaces;

namespace Laboratory_work_4.Subjects
{
    public class MiddleClassPerson : Person
    {
        public MiddleClassPerson(string name, IIncomeStrategy strategy) : base(name, 50000m, strategy) { }
    }
}
