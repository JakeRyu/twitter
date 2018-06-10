namespace Twitter.Application.Interfaces
{
    public interface ICommandHandler
    {
        void ExecuteCommand(string input);
    }
}
