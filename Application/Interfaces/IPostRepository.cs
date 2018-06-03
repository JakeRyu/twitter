using Twitter.Domain.Posts;

namespace Twitter.Application.Interfaces
{
    public interface IPostRepository
    {
        void Add(Post post);
    }
}
