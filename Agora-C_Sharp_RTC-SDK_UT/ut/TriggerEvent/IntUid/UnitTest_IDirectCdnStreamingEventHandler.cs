using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Ut.Event
{
    [TestFixture]
    public class UnitTest_IDirectCdnStreamingEventHandler
    {

        public IRtcEngineEx Engine;
        public UTDirectCdnStreamingEventHandler EventHandler;
        public IntPtr FakeRtcEnginePtr;
        public IrisCApiParam2 ApiParam;
        public Dictionary<string, System.Object> jsonObj = new Dictionary<string, object>();

        [SetUp]
        public void Setup()
        {
            FakeRtcEnginePtr = DLLHelper.CreateFakeRtcEngine();
            Engine = RtcEngine.CreateAgoraRtcEngineEx(FakeRtcEnginePtr);
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            ApiParam.AllocResult();

            EventHandler = new UTDirectCdnStreamingEventHandler();
            Engine.InitEventHandler(EventHandler);

            Engine.StartDirectCdnStreaming("url", new DirectCdnStreamingMediaOptions());
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.InitEventHandler(null);
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IDirectCdnStreamingEventHandler
        [Test]
        public void Test_IDirectCdnStreamingEventHandler_OnDirectCdnStreamingStateChanged()
        {
            ApiParam.@event = AgoraApiType.IDIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATECHANGED_40f1fa3;

            jsonObj.Clear();

            DIRECT_CDN_STREAMING_STATE state = ParamsHelper.CreateParam<DIRECT_CDN_STREAMING_STATE>();
            jsonObj.Add("state", state);

            DIRECT_CDN_STREAMING_REASON reason = ParamsHelper.CreateParam<DIRECT_CDN_STREAMING_REASON>();
            jsonObj.Add("reason", reason);

            string message = ParamsHelper.CreateParam<string>();
            jsonObj.Add("message", message);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnDirectCdnStreamingStateChangedPassed(state, reason, message));
        }

        [Test]
        public void Test_IDirectCdnStreamingEventHandler_OnDirectCdnStreamingStats()
        {
            ApiParam.@event = AgoraApiType.IDIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATS_d50595f;

            jsonObj.Clear();

            DirectCdnStreamingStats stats = ParamsHelper.CreateParam<DirectCdnStreamingStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnDirectCdnStreamingStatsPassed(stats));
        }
        #endregion terra IDirectCdnStreamingEventHandler
    }
}