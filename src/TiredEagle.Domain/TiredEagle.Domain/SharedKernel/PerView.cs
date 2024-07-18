
namespace TiredEagle.Domain.SharedKernel
{
    public class PerView : CostStrategy
    {
        public PerView(decimal cost)
        {
            Cost = cost;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Cost };
        }
    }
}
