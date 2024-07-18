using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.CampignOwner.ValueObjects
{
    public class AdsContent : ValueObject // Entity<Guid>
    {
        public AdsContent(string title, string body, MediaContent media, List<string> tags)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException("Title cannot be empty.");
            if (string.IsNullOrWhiteSpace(body)) throw new ArgumentNullException("Body cannot be empty.");
            if (media == null) throw new ArgumentNullException("Body cannot be empty.");
            if (body.Length > 500) throw new ArgumentException("length error");
            Title = title;
            Body = body;
            Media = media;
            Tags = tags;
        }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public List<string> Tags { get; private set; }
        public MediaContent Media { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Title, Body, Media, Tags };
        }
        //public Guid CampaignId { get; private set; }
        //public Campaign Campaign { get; private set; }
    }
}
