using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.SharedKernel
{
    public class AdvertisingSterategy : ValueObject
    {
        public string Title { get; private set; }
        public static readonly AdvertisingSterategy CostPerClick = new AdvertisingSterategy("CostPerClick");
        public static readonly AdvertisingSterategy CostPerView = new AdvertisingSterategy("CostPerView");
        private AdvertisingSterategy(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be empty.");

            Title = name;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
