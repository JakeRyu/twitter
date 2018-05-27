using System;
using Twitter.Domain.Users;

namespace Twitter.Domain.Tweets
{
    public class Tweet
    {
        public User User { get; set; }
        public string Content { get; set; }
        public DateTimeOffset At { get; set; }
    }
}
