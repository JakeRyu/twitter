using System;

namespace Twitter.Common.Dates
{
    public interface IDateService
    {
        DateTimeOffset GetDate();
        string GetWhenPosted(DateTimeOffset datetime);
    }

    public class DateService : IDateService
    {
        public DateTimeOffset GetDate()
        {
            return DateTimeOffset.Now;
        }

        public string GetWhenPosted(DateTimeOffset datetime)
        {
            TimeSpan difference = DateTimeOffset.Now - datetime;

            return $"{difference.Minutes:D2}";
        }
    }
}
