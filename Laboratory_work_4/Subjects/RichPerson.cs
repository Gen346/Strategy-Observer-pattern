using Laboratory_work_4.Strategies;

namespace Laboratory_work_4.Subjects
{
    public class RichPerson : Person
    {
        public RichPerson(string name)
            : base(name, 500000m, new InheritanceStrategy())
        {
        }
    }
}
