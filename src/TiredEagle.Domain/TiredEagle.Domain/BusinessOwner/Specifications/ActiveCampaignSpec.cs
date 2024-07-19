using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiredEagle.Domain.BusinessOwner.Entities;

namespace TiredEagle.Domain.BusinessOwner.Specifications
{
    internal class ActiveCampaignSpec
    {
        private readonly DateTime _now;

        public ActiveCampaignSpec(DateTime now)
        {
            _now = now;
        }
        public bool IsSatisfiedBy(Campaign campaign) => campaign.EffectiveTimeRange.EndDate > DateTime.Now;
    }
}
