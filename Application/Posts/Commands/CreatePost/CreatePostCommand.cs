using Twitter.Application.Interfaces;
using Twitter.Domain.Posts;
using Twitter.Domain.Users;

namespace Twitter.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommand : ICreatePostCommand
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public CreatePostCommand(
            IPostRepository postRepository,
            IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
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
                Message = model.Message
            };

            _postRepository.Add(post);
        }
    }
}