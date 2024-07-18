using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.SharedKernel
{
    public abstract class CostStrategy : ValueObject
    {
        public virtual double Cost { get; set; }

    }
}
