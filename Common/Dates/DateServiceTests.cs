using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Twitter.Common.Dates
{
    [TestFixture]
    class DateServiceTests
    {
        [Test]
        public void GetDate_WhenCalled_ReturnNow()
        {
            var sut = new DateService();

            var datetimeFromService = sut.GetDate();
            var now = DateTimeOffset.Now;
            var diff = now - datetimeFromService;

            Assert.That(diff < TimeSpan.FromSeconds(1), Is.True);
        }

        [Test]
        [TestCase(1, "1 second ago")]
        [TestCase(59, "59 seconds ago")]
        public void GetTimeAgo_WhenLessThanAMinute_ReturnSeconds(int sec, string timeAgo)
        {
            var sut = new DateService();
            var now = DateTimeOffset.Now;
            var datetime = now - TimeSpan.FromSeconds(sec);

            var result = sut.GetTimeAgo(datetime);

            Assert.That(result, Is.EqualTo(timeAgo));
        }

        [Test]
        [TestCase(1, "1 minute ago")]
        [TestCase(59, "59 minutes ago")]
        public void GetTimeAgo_WhenLessThanAnHour_ReturnMinutes(int min, string timeAgo)
        {
            var sut = new DateService();
            var now = DateTimeOffset.Now;
            var datetime = now - TimeSpan.FromMinutes(min);

            var result = sut.GetTimeAgo(datetime);

            Assert.That(result, Is.EqualTo(timeAgo));
        }

        [Test]
        [TestCase(1, "1 hour ago")]
        [TestCase(23, "23 hours ago")]
        public void GetTimeAgo_WhenLessThanADay_ReturnHours(int hour, string timeAgo)
        {
            var sut = new DateService();
            var now = DateTimeOffset.Now;
            var datetime = now - TimeSpan.FromHours(hour);

            var result = sut.GetTimeAgo(datetime);

            Assert.That(result, Is.EqualTo(timeAgo));
        }

        [Test]
        [TestCase(1, "1 day ago")]
        [TestCase(2, "2 days ago")]
        public void GetTimeAgo_WhenGreaterThanADay_ReturnDays(double day, string timeAgo)
        {
            var sut = new DateService();
            var now = DateTimeOffset.Now;
            var datetime = now - TimeSpan.FromDays(day);

            var result = sut.GetTimeAgo(datetime);

            Assert.That(result, Is.EqualTo(timeAgo));
        }
    }
}
