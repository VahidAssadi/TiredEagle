
namespace TiredEagle.Domain.SharedKernel
{
    public class PerHour : CostStrategy
    {
        public double GetCost()
        {
            return 5.0;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
