using TiredEagle.Domain.Abstraction;

namespace TiredEagle.Domain.CampignOwner.ValueObjects
{
    public class TimeRange
    {
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public TimeSpan? StartTime { get; private set; }
        public TimeSpan? EndTime { get; private set; }

        private TimeRange(DateTime? startDate, DateTime? endDate, TimeSpan? startTime, TimeSpan? endTime)
        {
            StartDate = startDate;
            EndDate = endDate;
            StartTime = startTime;
            EndTime = endTime;
        }

        public static TimeRange NoLimit()
        {
            return new TimeRange(null, null, null, null);
        }

        public static TimeRange DateLimit(DateTime startDate, DateTime? endDate = null)
        {
            return new TimeRange(startDate, endDate, null, null);
        }

        public static TimeRange DateTimeLimit(DateTime startDate, DateTime endDate, TimeSpan startTime, TimeSpan endTime)
        {
            if (startDate >= endDate) throw new BusinessException("Start date must be before end date.");
            if (startTime >= endTime) throw new BusinessException("Start time must be before end time.");
            return new TimeRange(startDate, endDate, startTime, endTime);
        }
    }
}
