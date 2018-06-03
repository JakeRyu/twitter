using System.Collections.Generic;
using Twitter.Domain.Posts;
using Twitter.Domain.Users;

namespace Twitter.Application.Posts.Queries.GetPostListByUser
{
    public interface IGetPostListByUserQuery
    {
        IEnumerable<PostListItemModel> Execute(string username);
    }
}
