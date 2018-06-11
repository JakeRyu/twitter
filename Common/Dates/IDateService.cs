using System;

namespace Twitter.Common.Dates
{
    public interface IDateService
    {
        DateTimeOffset GetDate();
        string GetTimeAgo(DateTimeOffset datetime);
    }
}
