using TiredEagle.Domain.CampaignManagement;

namespace TiredEagle.Application.Features.Commands.DistributionSystem
{
    public class ClickAdCommandHandler
    {
        private readonly IAdDistributionSystem _adDistributionSystem;

        public ClickAdCommandHandler(AdDistributionSystem adDistributionSystem)
        {
            _adDistributionSystem = adDistributionSystem;
        }

        public void Handle(ClickAdCommand command)
        {
            var campaign = _adDistributionSystem.Campaigns.FirstOrDefault(c => c.Id == command.CampaignId);
            var channelOwner = _adDistributionSystem.ChannelOwners.FirstOrDefault(o => o.Id == command.ChannelOwnerId);

            if (campaign != null && channelOwner != null)
            {
                _adDistributionSystem.AdByClick(campaign, channelOwner);
            }
            else
            {
                throw new InvalidOperationException("Campaign or Channel Owner not found.");
            }
        }
    }
}
