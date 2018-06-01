using NUnit.Framework;
using Twitter.Application.Commands;

namespace Twitter.Application
{
    [TestFixture()]
    class CommandLineReaderTests
    {
        [Test]
        public void Parse_PostingActionEntered_ReturnPostCommand()
        {
            var input = "Alicie -> I love the weather today";

            var command = CommandLineReader.Parse(input);

            Assert.That(command, Is.TypeOf<PostCommand>());
        }

        [Test]
        public void Parse_ReadingActionEntered_ReturnReadCommand()
        {
            var input = "Alice";

            var command = CommandLineReader.Parse(input);

            Assert.That(command, Is.TypeOf<ReadCommand>());
        }

        [Test]
        public void Parse_FollowingActionEntered_ReturnFollowCommand()
        {
            var input = "Charlie follows Alice";

            var command = CommandLineReader.Parse(input);

            Assert.That(command, Is.TypeOf<FollowCommand>());
        }

        [Test]
        public void Parse_WallActionEntered_ReturnWallCommand()
        {
            var input = "Charlie wall";

            var command = CommandLineReader.Parse(input);

            Assert.That(command, Is.TypeOf<WallCommand>());
        }
    }
}
