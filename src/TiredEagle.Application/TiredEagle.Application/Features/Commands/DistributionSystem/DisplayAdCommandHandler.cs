using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiredEagle.Domain.CampaignManager;

namespace TiredEagle.Application.Features.Commands.DistributionSystem
{
    public class DisplayAdCommandHandler
    {
        private readonly IAdDistributionSystem _adDistributionSystem;

        public DisplayAdCommandHandler(AdDistributionSystem adDistributionSystem)
        {
            _adDistributionSystem = adDistributionSystem;
        }

        public void Handle(DisplayAdCommand command)
        {
            var campaign = _adDistributionSystem.Campaigns.FirstOrDefault(c => c.Id == command.CampaignId);
            var channelOwner = _adDistributionSystem.ChannelOwners.FirstOrDefault(o => o.Id == command.ChannelOwnerId);

            if (campaign != null && channelOwner != null)
            {
                _adDistributionSystem.AdByView(campaign, channelOwner);
            }
            else
            {
                throw new InvalidOperationException("Campaign or Channel Owner not found.");
            }
        }
    }
}
