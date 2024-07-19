using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.CampignOwner.Entities
{
    public class Campaigner : Entity<Guid>, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IReadOnlyList<Campaign> ActiveCampigns => _activeCampigns.AsReadOnly();
        private List<Campaign> _activeCampigns { get; set; }

        public void AddNewCampaign(Campaign campign)
        {
            _activeCampigns.Add(campign);
        }

        public void CloseCampaign()
        {

        }
    }
}
