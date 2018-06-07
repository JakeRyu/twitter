using Moq;
using NUnit.Framework;
using Twitter.Application.Interfaces;
using Twitter.Common.Dates;

namespace Twitter.Application.Posts.Queries.GetPostListByUser
{
    [TestFixture]
    class GetPostListByUserTests
    {
        [Test]
        public void Execute_WhenCalled_CallListByUserMethodInPostRepository()
        {
            string username = "a";
            var postRepository = new Mock<IPostRepository>();
            var dateService = new Mock<IDateService>();
            postRepository.Setup(p => p.ListByUser(username));
            var query = new GetPostListByUserQuery(postRepository.Object, dateService.Object);

            query.Execute(username);

            postRepository.Verify(p => p.ListByUser(username));
        }
    }
}
