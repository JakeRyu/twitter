using Moq;
using NUnit.Framework;
using Twitter.Application.Interfaces;

namespace Twitter.Application.Users.Quries.GetUserDetail
{
    [TestFixture()]
    class GetUserDetailQueryTests
    {
        [Test]
        public void GetUserDetailQuery_WhenExecuted_CallGetMethodInUserRepository()
        {
            string name = "Alice";
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(u => u.Get(name));
            var query = new GetUserDetailQuery(userRepo.Object);

            query.Execute(name);

            userRepo.Verify(u => u.Get(name));
        }
    }
}
