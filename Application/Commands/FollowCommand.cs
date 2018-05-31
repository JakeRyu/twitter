using Twitter.Application.Interfaces;

namespace Twitter.Application.Commands
{
    public class FollowCommand : ICommand
    {
        private readonly string _username;
        private readonly string _userToFollow;

        public FollowCommand(string username, string userToFollow)
        {
            _username = username;
            _userToFollow = userToFollow;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}