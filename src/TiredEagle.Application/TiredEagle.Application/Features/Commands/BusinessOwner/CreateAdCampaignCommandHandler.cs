using TiredEagle.Domain.CampaignManager;
using TiredEagle.Domain.CampignOwner.Entities;
using TiredEagle.Domain.CampignOwner.ValueObjects;

namespace TiredEagle.Application.Features.Commands.BusinessOwner
{
    public class CreateAdCampaignCommandHandler
    {
        private readonly AdDistributionSystem _adDistributionSystem;

        public CreateAdCampaignCommandHandler(AdDistributionSystem adDistributionSystem)
        {
            _adDistributionSystem = adDistributionSystem;
        }

        public void Handle(CreateAdCampaignCommand command)
        {
            var telegramChannel = _adDistributionSystem.ChannelOwners
                .SelectMany(owner => owner.TelegramChannels)
                .FirstOrDefault(channel => channel.Id == command.TelegramChannelId);

            if (telegramChannel == null)
            {
                throw new InvalidOperationException("Telegram channel not found.");
            }

            var budget = new Budget(command.MaximumBudget);
            var campaign = new Campaign("campaign name", command.Categories, budget, command.AdContent, command.TimeRange, command.CostStrategy, command.TelegramChannelId);

            telegramChannel.AddCampaign(campaign);
            _adDistributionSystem.AddCampaign(campaign);
        }
    }
}
