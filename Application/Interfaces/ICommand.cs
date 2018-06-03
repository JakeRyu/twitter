namespace Twitter.Application.Interfaces
{
    public interface ICommand
    {
        void Execute(dynamic args);
    }
}