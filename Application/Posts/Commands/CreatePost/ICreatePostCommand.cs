namespace Twitter.Application.Posts.Commands.CreatePost
{
    public interface ICreatePostCommand
    {
        void Execute(CreatePostModel model);
    }
}
