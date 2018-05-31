using Twitter.Application.Interfaces;

namespace Twitter.Application.Commands
{
    public class ReadCommand : ICommand
    {
        private readonly string _username;

        public ReadCommand(string username)
        {
            _username = username;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}