using System;

namespace Twitter.Common.Dates
{
    public class DateService : IDateService
    {
        public DateTimeOffset GetDate()
        {
            return DateTimeOffset.Now;
        }

        public string GetTimeAgo(DateTimeOffset datetime)
        {
            string result = string.Empty;
            var difference = DateTimeOffset.Now - datetime;
            
            if (difference.Days > 0) return BuildTimeAgoString(difference.Days, "day");
            if (difference.Hours > 0) return BuildTimeAgoString(difference.Hours, "hour");
            if (difference.Minutes > 0) return BuildTimeAgoString(difference.Minutes, "minute");

            return BuildTimeAgoString(difference.Seconds, "second");
        }

        private string BuildTimeAgoString(int time, string unit)
        {
            if(string.IsNullOrEmpty(unit)) throw new ArgumentNullException();

            if (time == 0 && unit == "second") return "now";

            if(time == 1)
                return $"{time} {unit} ago";

            return $"{time} {unit}s ago";
        }
    }
}