using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.BusinessOwner.ValueObjects
{
    public class MediaContent : ValueObject
    {
        public string Url { get; }

        protected MediaContent(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException("URL cannot be empty.");
            Url = url;
        }
        public override bool Equals(object obj)
        {
            return obj is MediaContent content && Url == content.Url;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Url;
        }
    }
}
