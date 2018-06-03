using Twitter.Application.Interfaces;

namespace Twitter.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommand : ICreatePostCommand
    {
        private readonly IPostRepository _postRepository;
        public CreatePostCommand(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public void Execute(CreatePostModel model)
        {
            var tweet = new Domain.Posts.Post
            {
                User = model.User,
                Message = model.Message
            };

            _postRepository.Add(tweet);
        }
    }
}
