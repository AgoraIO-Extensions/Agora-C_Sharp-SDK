using NUnit.Framework;
using Agora.Rtc;
using uid_t = System.UInt32;
namespace Agora.Rtc.Ut
{
    public class UnitTest_IH265Transcoder
    {
        public IRtcEngine Engine;
        public IH265Transcoder H265Transcoder;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            rtcEngineContext.logConfig.level = LOG_LEVEL.LOG_LEVEL_API_CALL;
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            H265Transcoder = Engine.GetH265Transcoder();
            Assert.AreEqual(H265Transcoder != null, true);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

        #region terra IH265Transcoder
        [Test]
        public void Test_EnableTranscode()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channel = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = H265Transcoder.EnableTranscode(token, channel, uid);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_QueryChannel()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channel = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = H265Transcoder.QueryChannel(token, channel, uid);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_TriggerTranscode()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channel = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = H265Transcoder.TriggerTranscode(token, channel, uid);
            Assert.AreEqual(0, nRet);
        }


        #endregion terra IH265Transcoder
    }
}
