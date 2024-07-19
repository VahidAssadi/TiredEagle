using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.BusinessOwner.ValueObjects
{
    public class Budget : ValueObject
    {
        public Budget(double amount)
        {
            if (amount <= 0) throw new ArgumentException("Budget amount must be positive.");
        }
        public double Amount { get; set; } // Money value object
        //public string Currency { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            //yield return Currency;
        }
    }
}
