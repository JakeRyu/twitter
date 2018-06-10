using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Twitter.Application.Interfaces;
using Twitter.Application.Posts.Commands.CreatePost;
using Twitter.Application.Posts.Queries.GetPostListByUser;
using Twitter.Application.Posts.Queries.Wall;
using Twitter.Application.Users.Commands.Follow;

namespace Twitter.Application
{
    [TestFixture]
    class CommandHandlerTests
    {
        private Mock<IOutputWriter> _writer;
        private Mock<ICreatePostCommand> _createPostCommand;
        private Mock<IFollowUserCommand> _followUserCommand;
        private Mock<IWallQuery> _wallQuery;
        private Mock<IGetPostListByUserQuery> _getPostListByUserQuery;
        CommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _writer = new Mock<IOutputWriter>();
            _createPostCommand  = new Mock<ICreatePostCommand>();
            _followUserCommand = new Mock<IFollowUserCommand>();
            _wallQuery = new Mock<IWallQuery>(MockBehavior.Strict);
            _getPostListByUserQuery = new Mock<IGetPostListByUserQuery>(MockBehavior.Strict);
            _handler = new CommandHandler(
                _writer.Object,
                _createPostCommand.Object,
                _followUserCommand.Object,
                _wallQuery.Object,
                _getPostListByUserQuery.Object);
        }

        [Test]
        public void ExecuteCommand_WhendInputIsEmpty_ThrowException()
        {
            var input = string.Empty;

            Assert.Throws<ArgumentNullException>(() => _handler.ExecuteCommand(input));
        }

        [Test]
        public void ExecuteCommand_WhenCommandIsNotValid_ThrowException()
        {
            var input = "invalid command";

            var exception = Assert.Throws<Exception>(() => _handler.ExecuteCommand(input));
            Assert.That(exception.Message, Is.EqualTo("Invalid command"));
        }

        [Test]
        public void ExecuteCommand_WhenPost_InvokeExecuteOfCreatePostCommandWithCorrectParameters()
        {
            var username = "Alice";
            var message = "I love the whether today";
            var input = $"{username} -> {message}";
            _createPostCommand.Setup(c => c.Execute(username, message));

            _handler.ExecuteCommand(input);

            _createPostCommand.Verify(c => c.Execute(username, message));
        }

        [Test]
        public void ExecuteCommand_WhenFollow_InvokeExecuteOfFollowUserCommandWithCorrectParameters()
        {
            var username = "Charlie";
            var usernameToFollow = "Alice";
            var input = $"{username} follows {usernameToFollow}";
            _followUserCommand.Setup(c => c.Execute(username, usernameToFollow));

            _handler.ExecuteCommand(input);

            _followUserCommand.Verify(c => c.Execute(username, usernameToFollow));
        }

        [Test]
        public void ExecuteCommand_WhenSeeUsersWall_InvokeExecuteOfWallQueryWithCorrectParameter()
        {
            var username = "Alice";
            var input = $"{username} wall";
            _wallQuery.Setup(q => q.Execute(username)).Returns(new List<WallItemModel>());

            _handler.ExecuteCommand(input);

            _wallQuery.Verify(q => q.Execute(username));
        }

        [Test]
        public void ExecuteCommand_WhenWallHasPosts_WriteThePosts()
        {
            var username = "Alice";
            var input = $"{username} wall";
            _wallQuery.Setup(q => q.Execute(username)).Returns(new List<WallItemModel>
            {
                new WallItemModel { Message = "a", Username = "b", WhenPosted = "c"},
                new WallItemModel { Message = "d", Username = "e", WhenPosted = "f"}
            });
            _writer.Setup(w => w.Write(It.IsAny<string>()));

            _handler.ExecuteCommand(input);

            _writer.Verify(w => w.Write(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void ExecuteCommand_WhenWallHasNoPost_WriteNoPostMessage()
        {
            var username = "Alice";
            var input = $"{username} wall";
            var noPost = "Nothing posted yet";
            _wallQuery.Setup(q => q.Execute(username)).Returns(new List<WallItemModel>());
            _writer.Setup(w => w.Write(noPost));

            _handler.ExecuteCommand(input);

            _writer.Verify(w => w.Write(noPost));
        }

        [Test]
        public void ExecuteCommand_WhenRead_InvokeExecuteMethodInGetPostListByUserQuery()
        {
            var input = "Alice";
            _getPostListByUserQuery.Setup(q => q.Execute(It.IsAny<string>())).Returns(new List<PostListItemModel>());

            _handler.ExecuteCommand(input);

            _getPostListByUserQuery.Verify(q => q.Execute(It.IsAny<string>()));
        }

        [Test]
        public void ExecuteCommand_WhenUserHasPostsToRead_WriteThePosts()
        {
            var input = "Alice";
            _getPostListByUserQuery.Setup(q => q.Execute(It.IsAny<string>())).Returns(new List<PostListItemModel>
            {
                new PostListItemModel{ Message = "a", WhenPosted = "b"},
                new PostListItemModel{ Message = "c", WhenPosted = "d"},
                new PostListItemModel{ Message = "e", WhenPosted = "f"}
            });
            _writer.Setup(w => w.Write(It.IsAny<string>()));

            _handler.ExecuteCommand(input);

            _writer.Verify(w => w.Write(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void ExecuteCommand_WhenUserHasNoPostToRead_WriteNoPostMessage()
        {
            var input = "Alice";
            var noPost = "Nothing posted yet";
            _getPostListByUserQuery.Setup(q => q.Execute(It.IsAny<string>())).Returns(new List<PostListItemModel>());
            _writer.Setup(w => w.Write(noPost));

            _handler.ExecuteCommand(input);

            _writer.Verify(w => w.Write(noPost));
        }
    }
}
