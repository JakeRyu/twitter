using Twitter.Domain.Tweets;

namespace Twitter.Application.Interfaces
{
    public interface ITweetRepository
    {
        void Add(Tweet tweet);
    }
}
