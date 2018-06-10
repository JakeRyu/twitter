using System.Collections.Generic;

namespace Twitter.Application.Posts.Queries.GetPostListByUser
{
    public interface IGetPostListByUserQuery
    {
        IEnumerable<PostListItemModel> Execute(string username);
    }
}
