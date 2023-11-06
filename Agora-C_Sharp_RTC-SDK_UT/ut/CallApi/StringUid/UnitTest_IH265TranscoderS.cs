using NUnit.Framework;
using Agora.Rtc;
using uid_t = System.UInt32;
namespace Agora.Rtc
{
    public class UnitTest_IH265TranscoderS
    {
        public IRtcEngineS Engine;
        public IH265TranscoderS H265TranscoderS;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngineS.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngineS());
            RtcEngineContextS rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            rtcEngineContext.logConfig.level = LOG_LEVEL.LOG_LEVEL_API_CALL;
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            H265TranscoderS = Engine.GetH265Transcoder();
            Assert.AreEqual(H265TranscoderS != null, true);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

        #region terra IH265TranscoderS
        [Test]
        public void Test_EnableTranscode()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channel = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = H265TranscoderS.EnableTranscode(token, channel, userAccount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_QueryChannel()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channel = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = H265TranscoderS.QueryChannel(token, channel, userAccount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_TriggerTranscode()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channel = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = H265TranscoderS.TriggerTranscode(token, channel, userAccount);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IH265TranscoderS
    }
}
