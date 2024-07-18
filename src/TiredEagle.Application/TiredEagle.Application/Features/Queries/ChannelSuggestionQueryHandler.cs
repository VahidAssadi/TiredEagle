using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiredEagle.Application.Features.Commands;
using TiredEagle.Domain.CampaignManager;
using TiredEagle.Domain.CampignOwner.Entities;
using TiredEagle.Domain.CampignOwner.ValueObjects;

namespace TiredEagle.Application.Features.Queries
{
    public class TelegramChannelDto { }
    public class TopicCategoryDto { }
    internal class ChannelSuggestionQueryHandler
    {
        private readonly IAdDistributionSystem _adDistributionSystem;

        public ChannelSuggestionQueryHandler(AdDistributionSystem adDistributionSystem)
        {
            _adDistributionSystem = adDistributionSystem;
        }

        public TelegramChannelDto Handle(SuggestCampaignQuery query)
        {
            // validate query
            var channel = _adDistributionSystem.SuggestChannel(new Campaign(query.Categories, new Budget((decimal)query.MaximumBudget), new AdsContent(query.Content.Title, query.Content.Media, query.Content.Tags)));
            return channel;
        }
    }
}
