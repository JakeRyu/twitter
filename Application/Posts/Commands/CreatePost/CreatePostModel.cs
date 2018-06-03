using Twitter.Domain.Users;

namespace Twitter.Application.Posts.Commands.CreatePost
{
    public class CreatePostModel
    {
        public string Username { get; set; }
        public string Message { get; set; }
    }
}