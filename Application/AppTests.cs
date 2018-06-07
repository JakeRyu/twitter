using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using NUnit.Framework;
using Twitter.Application.Interfaces;
using Twitter.Application.Posts.Commands.CreatePost;

namespace Twitter.Application
{
    [TestFixture]
    class AppTests
    {
        [Test]
        public void ExecuteCommand_WhenPost_InvokeExecuteMethodInCreatePostCommand()
        {
        }
    }
}
