using TiredEagle.Domain.CampaignManager;
using TiredEagle.Domain.CampignOwner.Entities;
using TiredEagle.Domain.CampignOwner.ValueObjects;

namespace TiredEagle.Application.Features.Commands.BusinessOwner
{
    public class CreateAdCampaignCommandHandler
    { 
        public CreateAdCampaignCommandHandler()
        {
        }

        public void Handle(CreateAdCampaignCommand command)
        {
            var budget = new Budget(command.MaximumBudget);
            var campaign = new Campaign("campaign name", command.Categories, budget, command.AdContent, command.TimeRange, command.CostStrategy, command.TelegramChannelId);

            //telegramChannel.AddCampaign(campaign); some where must relate campign to the channel

        }
    }
}
