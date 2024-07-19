using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.CampaignManager.Entities
{
    public class AdsDistribution: Entity<Guid>, IAggregateRoot
    {
        public Guid CampignId { get; set; }
        public Guid TelegramChannelId { get; set; }
        public RequestState RequestState { get; set; }
    }

    public enum RequestState
    {
        Requested,
        Accepted, // ByChannelOwner
        Activated,
        Rejected, // ByChannelOwner
    }
}
