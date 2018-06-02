using Twitter.Application.Interfaces;

namespace Twitter.Application.Commands
{
    public class ReadCommand : Command
    {
        public ReadCommand(string username) : base(username)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}