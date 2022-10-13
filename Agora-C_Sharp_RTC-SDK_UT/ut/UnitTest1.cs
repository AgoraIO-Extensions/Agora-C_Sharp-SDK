using NUnit.Framework;
using Agora.Rtc;

namespace ut
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           var hell = RtcEngine.CreateAgoraRtcEngine();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
