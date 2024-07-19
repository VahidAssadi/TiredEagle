using TiredEagle.Domain.BusinessOwner.Entities;
using TiredEagle.Domain.ChannelOwner.Entities;

namespace TiredEagle.Domain.CampaignManagement
{
    public interface IAdDistributionSystem
    {
        void AdByClick(Campaign campaign, TelegramChannel channel);
        void AdByView(Campaign campaign, TelegramChannel channelOwner);
        TelegramChannel? SuggestChannel(Campaign campaign);
    }
}
