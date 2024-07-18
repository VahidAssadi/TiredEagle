using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.CampignOwner.Entities
{
    public class Campaigner : Entity<Guid>, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IReadOnlyList<Campaign> ActiveCampigns => _activeCampigns.AsReadOnly();
        private List<Campaign> _activeCampigns { get; set; }

        //public bool CheckCampaignOverlap(Campaign campaign)
        //{
        //    if (campaign == null) throw new ArgumentNullException(nameof(campaign));

        //    return _activeCampigns.Any(p => p.EffectiveTimeRange.StartTime < campaign.EffectiveTimeRange.EndTime) && _activeCampigns.Any(p => p.EffectiveTimeRange.EndTime > campaign.EffectiveTimeRange.StartTime);

        //}
        public void AddNewCampaign(Campaign campign)
        {
            //if (CheckCampaignOverlap(campign))
            //{
            //    Console.WriteLine("Warning");
            //}

            _activeCampigns.Add(campign);
        }

        public void CloseCampaign()
        {

        }
    }
}
