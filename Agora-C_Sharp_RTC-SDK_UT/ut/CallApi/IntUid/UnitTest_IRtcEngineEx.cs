using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc.Ut
{
    using uid_t = System.UInt32;
    [TestFixture]
    public partial class UnitTest_IRtcEngineEx
    {

        public IRtcEngineEx @interface;

        [SetUp]
        public void Setup()
        {
            @interface = Rtc.RtcEngine.CreateAgoraRtcEngineEx(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = @interface.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { @interface.Dispose(); }

    }

}