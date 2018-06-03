namespace Twitter.Application.Posts.Commands
{
    public interface ICreatePostCommand
    {
        void Execute(CreatePostModel model);
    }
}
