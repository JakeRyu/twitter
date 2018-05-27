namespace Twitter.Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        void Execute(CreateUserModel model);
    }
}
