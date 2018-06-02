using Twitter.Application.Interfaces;

namespace Twitter.Application.Commands
{
    public class WallCommand : Command
    {

        public WallCommand(string username) : base(username)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}