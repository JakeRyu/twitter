using NUnit.Framework;

namespace Twitter.Domain.Users
{
    [TestFixture]
    class UserTests
    {
        [Test]
        public void NameProperty_SetName_NameIsSet()
        {
            const string name = "a";
            var user = new User();

            user.Name = name;

            Assert.That(user.Name, Is.EqualTo(name));
        }
    }
}
