using Laboratory_work_4.Strategies;

namespace Laboratory_work_4.Subjects
{
    public class MiddleClassPerson : Person
    {
        public MiddleClassPerson(string name)
            : base(name, 50000m, new WhiteIncomeStrategy())
        {
        }
    }
}
