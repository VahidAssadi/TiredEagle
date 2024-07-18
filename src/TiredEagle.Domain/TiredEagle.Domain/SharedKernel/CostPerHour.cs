
namespace TiredEagle.Domain.SharedKernel
{
    public class CostPerHour : CostStrategy
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
