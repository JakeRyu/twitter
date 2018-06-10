using Twitter.Application.Interfaces;
using Twitter.Domain.Users;

namespace Twitter.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(CreateUserModel model)
        {
            var user = new User {Name = model.Name};
            _userRepository.Add(user);
        }
    }
}
