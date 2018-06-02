using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Twitter.Application.Users.Commands.CreateUser;
using Twitter.Application.Users.Quries.GetUserDetail;

namespace Twitter.Application.Tweets.Commands.Post
{
    [TestFixture]
    class PostCommandTests
    {
        private string _username;
        private string _message;
        private Mock<IGetUserDetailQuery> _getUserDetailQuery;
        private Mock<ICreateUserCommand> _createUserCommand;
        private Mock<ICreateTweetCommand> _createTweetCommand;
        private PostCommand _postCommand;


        [SetUp]
        public void SetUp()
        {
            _username = "a";
            _message = "b";
            _getUserDetailQuery = new Mock<IGetUserDetailQuery>();
            _createUserCommand = new Mock<ICreateUserCommand>();
            _createUserCommand.Setup(c => c.Execute(It.IsAny<CreateUserModel>()));
            _createTweetCommand = new Mock<ICreateTweetCommand>();
            _createTweetCommand.Setup(c => c.Execute(It.IsAny<CreateTweetModel>()));
            _postCommand = new PostCommand(_username, _message)
            {
                GetUserDetailQuery = _getUserDetailQuery.Object,
                CreateUserCommand = _createUserCommand.Object,
                CreateTweetCommand = _createTweetCommand.Object
            };
        }
        [Test]
        public void Execute_UserExists_NotCallCreateUserCommand()
        {
            _getUserDetailQuery.Setup(q => q.Execute(_username))
                .Returns(new UserDetailModel { Name = _username });
            
            _postCommand.Execute();

            _createUserCommand.Verify(c => c.Execute(It.IsAny<CreateUserModel>()), Times.Never);
        }

        [Test]
        public void Execute_UserNotExist_CallCreateUserCommand()
        {
            _getUserDetailQuery.Setup(q => q.Execute(_username))
                .Returns(() => null);
            
            _postCommand.Execute();

            _createUserCommand.Verify(c => c.Execute(It.IsAny<CreateUserModel>()));
        }
    }
}
