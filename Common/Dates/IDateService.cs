using System;
using System.Security.Cryptography;

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
            string result = string.Empty;
            var difference = DateTimeOffset.Now - datetime;

            switch (difference.Minutes)
            {
                case 0:
                    result = "just now";
                    break;
                case 1:
                    result = "1 minute ago";
                    break;
                default:
                    result = $"{difference.Minutes:D} minutes ago";
                    break;
            }

            return result;
        }
    }
}
