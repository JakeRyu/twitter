using System.Collections.Generic;
using System.Linq;
using Twitter.Application.Interfaces;
using Twitter.Domain.Posts;
using Twitter.Domain.Users;

namespace Twitter.Application.Posts.Queries.GetPostListByUser
{
    public class GetPostListByUserQuery : IGetPostListByUserQuery
    {
        private readonly IPostRepository _postRepository;

        public GetPostListByUserQuery(
            IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<PostListItemModel> Execute(string username)
        {
            return _postRepository.ListByUser(username)
                .Select(p => new PostListItemModel
                {
                    Message = p.Message,
                    WhenPosted = p.At.ToString("f")
                });
        }
    }
}