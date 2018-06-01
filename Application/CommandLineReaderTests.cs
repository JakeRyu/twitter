using System;
using NUnit.Framework;
using Twitter.Application.Commands;

namespace Twitter.Application
{
    [TestFixture()]
    class CommandLineReaderTests
    {
        [Test]
        [TestCase("Alicie -> I love the weather today", typeof(PostCommand))]
        [TestCase("Alicie", typeof(ReadCommand))]
        [TestCase("Charlie follows Alice", typeof(FollowCommand))]
        [TestCase("Charlie wall", typeof(WallCommand))]
        public void Parse_BasedOnInput_ReturnsACommandAccordingly(string input, Type commandType)
        {
            var command = CommandLineReader.Parse(input);

            Assert.That(command, Is.TypeOf(commandType));
        }
    }
}
