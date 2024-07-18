using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiredEagle.Domain.CampaignManager;
using TiredEagle.Domain.ChannelOwner.Entities;
using TiredEagle.Domain.ChannelOwner.ValueObjects;
using TiredEagle.Domain.SharedKernel;

namespace TiredEagle.Application.Features.Commands.ChannelOwner
{
    public class CreateTelegramChannelCommand
    {
        public Guid OwnerId { get; set; }
        public string ChannelName { get; set; }
        public CostStrategy AcceptedCostType { get; set; }
        public double CostPerClick { get; set; }
        public double CostPerView { get; set; }
        public List<TopicCategory> Categories { get; set; }
        public List<TimeSlot> AvailableTimeSlots { get; set; }

        public CreateTelegramChannelCommand(Guid ownerId, string channelName, CostStrategy acceptedCostType, double costPerClick, double costPerView, List<TopicCategory> categories, List<TimeSlot> availableTimeSlots)
        {
            OwnerId = ownerId;
            ChannelName = channelName;
            AcceptedCostType = acceptedCostType;
            CostPerClick = costPerClick;
            CostPerView = costPerView;
            Categories = categories;
            AvailableTimeSlots = availableTimeSlots;
        }
    }

    public class CreateTelegramChannelCommandHandler
    {
        private readonly AdDistributionSystem _adDistributionSystem;

        public CreateTelegramChannelCommandHandler(AdDistributionSystem adDistributionSystem)
        {
            _adDistributionSystem = adDistributionSystem;
        }

        public void Handle(CreateTelegramChannelCommand command)
        {
            var owner = _adDistributionSystem.ChannelOwners.FirstOrDefault(o => o.Id == command.OwnerId);
            if (owner == null)
            {
                throw new InvalidOperationException("Owner not found.");
            }

            var telegramChannel = new TelegramChannel(command.ChannelName, command.Categories, command.AvailableTimeSlots);
            telegramChannel = telegramChannel.WithCostingStrategy(command.AcceptedCostType);

            owner.AddTelegramChannel(telegramChannel);
        }
    }
}
