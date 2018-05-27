using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Twitter.Application.Interfaces;
using Twitter.Domain.Users;
using Twitter.Persistance;

namespace Twitter.Application.Users.Commands.CreateUser
{
    [TestFixture()]
    public class CreateUserCommandTests
    {
        [Test]
        public void CreateUserCommand_WhenExecuted_AUserIsCreated()
        {
            var model = new CreateUserModel { Name = "a" };
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(u => u.Add(It.IsAny<User>()));
            var sut = new CreateUserCommand(userRepo.Object);

            sut.Execute(model);

            userRepo.Verify(u => u.Add(It.IsAny<User>()));
        }
    }
}
