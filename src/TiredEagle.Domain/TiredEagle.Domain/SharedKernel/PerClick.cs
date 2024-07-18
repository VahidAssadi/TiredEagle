namespace TiredEagle.Domain.SharedKernel
{
    public class PerClick : CostStrategy
    {
        public PerClick(double cost)
        {
            Cost = cost;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Cost };
        }
    }
}
