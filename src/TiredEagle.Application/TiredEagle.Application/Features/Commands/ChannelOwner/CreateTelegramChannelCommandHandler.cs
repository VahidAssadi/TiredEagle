using TiredEagle.Domain.CampaignManager;
using TiredEagle.Domain.ChannelOwner.Entities;

namespace TiredEagle.Application.Features.Commands.ChannelOwner
{
    public class CreateTelegramChannelCommandHandler
    {

        public CreateTelegramChannelCommandHandler()
        {
           
        }

        public void Handle(CreateTelegramChannelCommand command)
        {
            var owner = _channelOwnerRepository.FirstOrDefault(o => o.Id == command.OwnerId);
            if (owner == null)
            {
                throw new InvalidOperationException("Owner not found.");
            }

            var telegramChannel = new TelegramChannel("channelId",owner.Id,"channel title",command.ChannelName, command.Categories, command.AvailableTimeSlots);
            telegramChannel = telegramChannel.WithCostingStrategy(command.AcceptedCostType);

            owner.AddTelegramChannel(telegramChannel);
        }
    }
}
