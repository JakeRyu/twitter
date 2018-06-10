using System;
using Moq;
using NUnit.Framework;
using Twitter.Application.Interfaces;
using Twitter.Domain.Users;

namespace Twitter.Application.Users.Commands.Follow
{
    [TestFixture]
    class FollowUserCommandTests
    {
        [Test]
        public void Execute_WhenUserNotExist_ThrowAnException()
        {
            string existingUser = "a";
            string nonExistingUser = "b";
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.Get(existingUser)).Returns(It.IsAny<User>());
            userRepository.Setup(u => u.Get(nonExistingUser)).Returns(() => null);
            var command = new FollowUserCommand(userRepository.Object);

            Assert.Throws(typeof(ArgumentException), () => command.Execute(existingUser, nonExistingUser));
            Assert.Throws(typeof(ArgumentException), () => command.Execute(nonExistingUser, existingUser));
        }

        [Test]
        public void Execute_WhenCalled_AddAnUserToFollow()
        {
            var userNameA = "a";
            var userNameB = "b";
            var userA = new User {Name = userNameA};
            var userB = new User {Name = userNameB };
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.Get(userNameA)).Returns(userA);
            userRepository.Setup(u => u.Get(userNameB)).Returns(userB);
            var command = new FollowUserCommand(userRepository.Object);

            command.Execute(userNameA, userNameB);

            Assert.That(userA.FollowingUsers.Contains(userB));
        }
    }
}
