namespace Twitter.Application.Users.Commands.Follow
{
    public interface IFollowUserCommand
    {
        void Execute(string username, string usernameToFollow);
    }
}
