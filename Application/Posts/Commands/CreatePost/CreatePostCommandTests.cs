using System;
using Moq;
using NUnit.Framework;
using Twitter.Application.Interfaces;
using Twitter.Common.Dates;
using Twitter.Domain.Posts;
using Twitter.Domain.Users;

namespace Twitter.Application.Posts.Commands.CreatePost
{
    [TestFixture]
    class CreatePostCommandTests
    {
        private Mock<IPostRepository> _postRepository;
        private Mock<IUserRepository> _userRepository;
        private Mock<IDateService> _dateService;
        private CreatePostCommand _command;
        private string _username = "a";
        private dynamic _args;

        [SetUp]
        public void SetUp()
        {
            _userRepository = new Mock<IUserRepository>();
            _postRepository = new Mock<IPostRepository>();
            _dateService = new Mock<IDateService>();
            _command = new CreatePostCommand(_postRepository.Object, _userRepository.Object, _dateService.Object);

            _postRepository.Setup(p => p.Add(It.IsAny<Post>()));
            _userRepository.Setup(u => u.Add(It.IsAny<User>()));
            _args = new
            {
                Username = _username,
                Message = "b"
            };
        }

        [Test]
        public void Execute_WhenUserNotExist_AddAnUser()
        {
            _userRepository.Setup(u => u.Get(_username)).Returns(() => null);
            
            _command.Execute(_args);

            _userRepository.Verify(u => u.Add(It.IsAny<User>()));
            _postRepository.Verify(p => p.Add(It.IsAny<Post>()));
        }

        [Test]
        public void Execute_WhenUserExists_NotAddAnUser()
        {
            _userRepository.Setup(u => u.Get(_username)).Returns(new User());

            _command.Execute(_args);

            _userRepository.Verify(u => u.Add(It.IsAny<User>()), Times.Never);
            _postRepository.Verify(p => p.Add(It.IsAny<Post>()));
        }
    }
}