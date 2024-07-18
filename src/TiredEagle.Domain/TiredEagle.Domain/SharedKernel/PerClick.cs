namespace TiredEagle.Domain.SharedKernel
{
    public class PerClick : CostStrategy
    {
        public PerClick(decimal cost)
        {
            Cost = cost;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Cost };
        }
    }
}
