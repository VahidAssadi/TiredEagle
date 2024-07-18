using TiredEagle.Domain.CampignOwner.Entities;
using TiredEagle.Domain.ChannelOwner.Entities;

namespace TiredEagle.Domain.CampaignManager
{
    public interface IAdDistributionSystem
    {
        void AdByClick(Campaign campaign, TelegramChannel channel);
        void AdByView(Campaign campaign, TelegramChannel channelOwner);
        TelegramChannel? SuggestChannel(Campaign campaign);
    }
}
