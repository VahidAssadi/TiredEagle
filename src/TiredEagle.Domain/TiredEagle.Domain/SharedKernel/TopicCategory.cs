using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.SharedKernel
{
    public class TopicCategory : ValueObject
    {
        public string Name { get; private set; }

        public static readonly TopicCategory Technology = new TopicCategory("Technology");
        public static readonly TopicCategory Health = new TopicCategory("Health");
        public static readonly TopicCategory Education = new TopicCategory("Education");
        public static readonly TopicCategory Finance = new TopicCategory("Finance");
        public static readonly TopicCategory Entertainment = new TopicCategory("Entertainment");

        public TopicCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be empty.");

            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Technology;
            yield return Health;
            yield return Education;
            yield return Finance;
            yield return Entertainment;
        }
    }
}
