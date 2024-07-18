namespace TiredEagle.Application.Features.Commands.DistributionSystem
{
    public class ClickAdCommand
    {
        public Guid CampaignId { get; set; }
        public Guid ChannelOwnerId { get; set; }

        public ClickAdCommand(Guid campaignId, Guid channelOwnerId)
        {
            CampaignId = campaignId;
            ChannelOwnerId = channelOwnerId;
        }
    }
}
