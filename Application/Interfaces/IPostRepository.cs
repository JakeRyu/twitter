using System.Collections.Generic;
using Twitter.Domain.Posts;

namespace Twitter.Application.Interfaces
{
    public interface IPostRepository
    {
        void Add(Post post);

        IEnumerable<Post> ListByUser(string username);
        IEnumerable<Post> ListByUsers(string[] usernames);
    }
}
