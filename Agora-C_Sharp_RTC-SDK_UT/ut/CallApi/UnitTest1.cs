using NUnit.Framework;
using Agora.Rtc;

namespace ut
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            var hell = RtcEngine.CreateAgoraRtcEngine();
        }

    }
}
