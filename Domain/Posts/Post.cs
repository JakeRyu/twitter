using System;
using Twitter.Domain.Users;

namespace Twitter.Domain.Posts
{
    public class Post
    {
        public User User { get; set; }
        public string Message { get; set; }
        public DateTimeOffset At { get; set; }
    }
}
