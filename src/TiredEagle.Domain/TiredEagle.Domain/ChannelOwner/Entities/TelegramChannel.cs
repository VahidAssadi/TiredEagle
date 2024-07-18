using TiredEagle.Domain.Abstraction;
using TiredEagle.Domain.CampignOwner.Entities;
using TiredEagle.Domain.ChannelOwner.ValueObjects;
using TiredEagle.Domain.SharedKernel;

namespace TiredEagle.Domain.ChannelOwner.Entities
{
    public class TelegramChannel : Entity<Guid>
    {
        public TelegramChannel(string channelId, string ownerTId, string title, string description, TopicCategory category, List<TimeSlot> timeSlots)
        {
            // validations omitted 
            ChannelId = channelId;
            OwnerTId = ownerTId;
            Title = title;
            Description = description;
            _categories?.Add(category);
            _availableTimeSlots = timeSlots;
        }

        public string ChannelId { get; private set; }
        public string OwnerTId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyList<TopicCategory> Categories => _categories.AsReadOnly();

        private List<TopicCategory> _categories;
        public int Members { get; private set; }
        public ChannelRevenue ChannelRevenue { get; private set; }
        public IReadOnlyList<CostStrategy> CostMethods => _costMethods.AsReadOnly();

        public IReadOnlyList<TimeSlot> AvailableTimeSlots => _availableTimeSlots.AsReadOnly();
        public List<Campaign> AdCampaigns { get; private set; }
        public List<Campaign> ActiveCampaigns {  get; private set; }

        private List<TimeSlot> _availableTimeSlots;

        private List<CostStrategy> _costMethods;

        public void AddCampaign(Campaign campaign)
        {
            if (AdCampaigns.Any(c => c.ConflictsWith(campaign.EffectiveTimeRange)))
            {
                throw new InvalidOperationException("The campaign conflicts with existing campaigns in the selected time range.");
            }
            AdCampaigns.Add(campaign);
        }
        public void AddTimeSlot(TimeSlot timeSlot)
        {
            if (_availableTimeSlots.Any(ts => ts.Start < timeSlot.End && ts.End > timeSlot.Start))
            {
                throw new ArgumentException("Time slot overlaps with an existing slot.");
            }
            _availableTimeSlots.Add(timeSlot);

        }
        public TelegramChannel WithCostingStrategy(CostStrategy costMethod)
        {
            _costMethods.Add(costMethod);
            return this;
        }

        public void IncreaseRevenue(CostStrategy amount)
        {
            ChannelRevenue.Revenue += amount.Cost;
        }
    }
}
