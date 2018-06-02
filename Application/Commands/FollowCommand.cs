using Twitter.Application.Interfaces;

namespace Twitter.Application.Commands
{
    public class FollowCommand : Command
    {
        private readonly string _userToFollow;

        public FollowCommand(string username, string userToFollow) : base(username)
        {
            _userToFollow = userToFollow;
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}