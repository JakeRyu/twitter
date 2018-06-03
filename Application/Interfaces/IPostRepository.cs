using System.Collections.Generic;
using Twitter.Domain.Posts;
using Twitter.Domain.Users;

namespace Twitter.Application.Interfaces
{
    public interface IPostRepository
    {
        void Add(Post post);

        IEnumerable<Post> ListByUser(string username);
    }
}
