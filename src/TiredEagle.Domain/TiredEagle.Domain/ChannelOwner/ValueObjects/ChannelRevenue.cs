using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.ChannelOwner.ValueObjects
{
    public class ChannelRevenue : ValueObject
    {
        public decimal Revenue { get; set; }
        public string Currency { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Revenue };
        }
    }
}
