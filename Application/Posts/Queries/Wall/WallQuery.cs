using System;
using System.Collections.Generic;
using System.Linq;
using Twitter.Application.Interfaces;
using Twitter.Common.Dates;

namespace Twitter.Application.Posts.Queries.Wall
{
    public class WallQuery : IWallQuery
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IDateService _dateService;

        public WallQuery(
            IUserRepository userRepository,
            IPostRepository postRepository,
            IDateService dateService)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _dateService = dateService;
        }

        public IEnumerable<WallItemModel> Execute(string username)
        {
            var user = _userRepository.Get(username);
            if(user == null) throw new ArgumentException("User not exist");

            var usernames = user.FollowingUsers
                .Select(u => u.Name)
                .ToArray()
                .Concat(new string[] {username})
                .ToArray();

            var posts = _postRepository.ListByUsers(usernames);

            return posts?
                .OrderByDescending(p => p.At)
                .Select(p => new WallItemModel
                {
                    Username = p.User.Name,
                    Message = p.Message,
                    WhenPosted = _dateService.GetTimeAgo(p.At)
                });
        }
    }
}