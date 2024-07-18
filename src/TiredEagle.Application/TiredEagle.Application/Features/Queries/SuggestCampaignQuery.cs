using TiredEagle.Domain.CampignOwner.ValueObjects;
using TiredEagle.Domain.SharedKernel;

namespace TiredEagle.Application.Features.Queries
{
    public class SuggestCampaignQuery
    {
        public string Name { get; private set; }
        public IEnumerable<TopicCategoryDto> Categories { get; set; }
        public double MaximumBudget { get; set; }
        public CostStrategy CostStrategy { get; set; }
        public AdsContent Content { get; set; }
        public TimeRange EffectiveTimeRange { get; set; }
    }
}
