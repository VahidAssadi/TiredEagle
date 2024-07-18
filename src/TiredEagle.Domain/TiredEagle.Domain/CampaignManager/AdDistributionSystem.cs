using TiredEagle.Domain.CampignOwner.Entities;
using TiredEagle.Domain.ChannelOwner.Entities;
using TiredEagle.Domain.SharedKernel;

namespace TiredEagle.Domain.CampaignManager
{
    public class AdDistributionSystem: IAdDistributionSystem
    {
        private List<TelegramChannelOwner> channelOwners; //must be retrive from repository

        public TelegramChannel? SuggestChannel(Campaign campaign)
        {
            // پیشنهاد کانال بر اساس تطابق دسته‌بندی‌ها و موجود بودن بازه زمانی مناسب
            foreach (var owner in channelOwners)
            {
                foreach (var channel in owner.TelegramChannels)
                {
                    if (channel.Categories.Any(category => campaign.Categories.Contains(category)) &&
                        channel.AvailableTimeSlots.Any(slot => campaign.EffectiveTimeRange.StartTime >= slot.Start && campaign.EffectiveTimeRange.EndTime <= slot.End))
                    {
                        return channel;
                    }
                }
            }

            return null; // کانال مناسبی پیدا نشد
        }

        public void AdByView(Campaign campaign, TelegramChannel channelOwner)
        {
            if (campaign.RemainingBudget.Amount <= 0)
            {
                throw new InvalidOperationException("Insufficient campaign budget.");
            }

            var cost = new PerView(10.0m);
            campaign.DecreaseBudget(cost);
            channelOwner.IncreaseRevenue(cost);

            Console.WriteLine($"Ad displayed. Campaign budget: {campaign.RemainingBudget.Amount}, Channel owner revenue: {channelOwner.ChannelRevenue.Revenue}");
        }

        public void AdByClick(Campaign campaign, TelegramChannel channel)
        {
            if (campaign.RemainingBudget.Amount <= 0)
            {
                throw new InvalidOperationException("Insufficient campaign budget.");
            }

            var cost = new PerClick(100.0m);
            campaign.DecreaseBudget(cost);
            channel.IncreaseRevenue(cost);

            Console.WriteLine($"Ad clicked. Campaign budget: {campaign.RemainingBudget.Amount}, Channel owner revenue: {channel.ChannelRevenue.Revenue}");
        }
    }
}
