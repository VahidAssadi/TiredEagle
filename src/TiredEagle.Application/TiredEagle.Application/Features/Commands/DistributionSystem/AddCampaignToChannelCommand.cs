namespace TiredEagle.Application.Features.Commands.DistributionSystem
{
    public class AddCampaignToChannelCommand
    {
        public Guid CampaignId { get; set; }
        public Guid ChannelId { get; set; }
        
    }
}
