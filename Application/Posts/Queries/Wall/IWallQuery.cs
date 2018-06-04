using System.Collections.Generic;

namespace Twitter.Application.Posts.Queries.Wall
{
    public interface IWallQuery
    {
        IEnumerable<WallItemModel> Execute(string username);
    }
}
