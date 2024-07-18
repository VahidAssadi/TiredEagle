namespace TiredEagle.Application.Features.Commands
{
    public class DisplayAdCommand
    {
        public Guid CampaignId { get; set; }
        public Guid ChannelOwnerId { get; set; }

        public DisplayAdCommand(Guid campaignId, Guid channelOwnerId)
        {
            CampaignId = campaignId;
            ChannelOwnerId = channelOwnerId;
        }
    }
}
