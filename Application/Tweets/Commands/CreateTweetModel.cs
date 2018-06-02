using Twitter.Domain.Users;

namespace Twitter.Application.Tweets.Commands
{
    public class CreateTweetModel
    {
        public User User { get; set; }
        public string Message { get; set; }
    }
}