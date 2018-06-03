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

        public void Execute(dynamic model)
        {
            User user = _userRepository.Get(model.Username);
            if (user == null)
            {
                user = new User {Name = model.Username};
                _userRepository.Add(user);
            }

            var post = new Post
            {
                User = user,
                Message = model.Message,
                At = _dateService.GetDate()
            };

            _postRepository.Add(post);
        }
    }
}