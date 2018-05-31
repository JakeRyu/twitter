using Twitter.Application.Interfaces;

namespace Twitter.Application.Commands
{
    public class WallCommand : ICommand
    {
        private readonly string _username;

        public WallCommand(string username)
        {
            _username = username;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}