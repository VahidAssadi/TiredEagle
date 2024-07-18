using TiredEagle.Domain.Abstraction;
using TiredEagle.Domain.CampignOwner.ValueObjects;
using TiredEagle.Domain.SharedKernel;

namespace TiredEagle.Domain.CampignOwner.Entities
{
    public class Campaign : Entity<Guid>
    {
        public Campaign(string name, IEnumerable<TopicCategory> categories, Budget maximumBudget, AdsContent content, TimeRange activeTime, CostStrategy costStrategy, Guid telegramId)
        {
            Name = name;
            Categories = categories;
            MaximumBudget = maximumBudget;
            RemainingBudget = maximumBudget;
            Content = content;
            EffectiveTimeRange = activeTime;
            CostStrategy = costStrategy;
        }
        public string Name { get; private set; }
        public IEnumerable<TopicCategory> Categories { get; private set; }
        public Budget MaximumBudget { get; private set; } // value object
        public Budget RemainingBudget { get; private set; } // value object
        public int CountOfEngagement { get; private set; } 
        public CostStrategy CostStrategy { get; private set; }
        public AdsContent Content { get; private set; }
        public TimeRange EffectiveTimeRange { get; private set; } // has rule

        public bool ConflictsWith(TimeRange otherTimeRange)
        {
            return EffectiveTimeRange.OverlapsWith(otherTimeRange);
        }
        public Guid TelegramChannelId { get; private set; }
        public void DecreaseBudget(CostStrategy costMethod) // based on costing method must decrease from budget
        {
            RemainingBudget.Amount = RemainingBudget.Amount - costMethod.Cost;
        }
    }
}
