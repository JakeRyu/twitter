using Twitter.Application.Interfaces;

namespace Twitter.Application.Posts.Commands.CreatePost
{
    public interface ICreatePostCommand
    {
        void Execute(dynamic args);
    }
}
