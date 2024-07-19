using TiredEagle.Domain.BusinessOwner.ValueObjects;
using TiredEagle.Domain.SharedKernel;

namespace TiredEagle.Application.Features.Commands.BusinessOwner
{
    public class CreateAdCampaignCommand
    {
        public Guid CampainerId { get; set; }
        public string Name { get; set; }
        public IEnumerable<TopicCategory> Categories { get; set; }
        public double MaximumBudget { get; set; }
        public string Content { get; set; }
        public string CostStrategy { get; set; }
        public Guid TelegramChannelId { get; set; }
        public TimeRange EffectiveTimeRange => TimeRange.DateLimit(DateTime.Now);
    }
}
