using Twitter.Application.Interfaces;
using Twitter.Common.Dates;
using Twitter.Domain.Posts;
using Twitter.Domain.Users;

namespace Twitter.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommand : ICreatePostCommand
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDateService _dateService;

        public CreatePostCommand(
            IPostRepository postRepository,
            IUserRepository userRepository,
            IDateService dateService)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _dateService = dateService;
        }

        public void Execute(string username, string message)
        {
            User user = _userRepository.Get(username);
            if (user == null)
            {
                user = new User {Name = username};
                _userRepository.Add(user);
            }

            var post = new Post
            {
                User = user,
                Message = message,
                At = _dateService.GetDate()
            };

            _postRepository.Add(post);
        }
    }
}