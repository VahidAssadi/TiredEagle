using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.ChannelOwner.ValueObjects
{
    public class TimeSlot : ValueObject
    {
        public TimeSpan Start { get; private set; }
        public TimeSpan End { get; private set; }

        public TimeSlot(TimeSpan start, TimeSpan end)
        {
            if (start >= end) throw new ArgumentException("Start time must be before end time.");
            Start = start;
            End = end;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
