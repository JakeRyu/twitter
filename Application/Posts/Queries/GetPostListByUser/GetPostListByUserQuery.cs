using System.Collections.Generic;
using System.Linq;
using Twitter.Application.Interfaces;
using Twitter.Common.Dates;
using Twitter.Domain.Posts;
using Twitter.Domain.Users;

namespace Twitter.Application.Posts.Queries.GetPostListByUser
{
    public class GetPostListByUserQuery : IGetPostListByUserQuery
    {
        private readonly IPostRepository _postRepository;
        private readonly IDateService _dateService;

        public GetPostListByUserQuery(
            IPostRepository postRepository,
            IDateService dateService)
        {
            _postRepository = postRepository;
            _dateService = dateService;
        }

        public IEnumerable<PostListItemModel> Execute(string username)
        {
            return _postRepository.ListByUser(username)
                .OrderByDescending(p => p.At)
                .Select(p => new PostListItemModel
                {
                    Message = p.Message,
                    WhenPosted = _dateService.GetWhenPosted(p.At)
                });
        }
    }
}