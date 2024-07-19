using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
