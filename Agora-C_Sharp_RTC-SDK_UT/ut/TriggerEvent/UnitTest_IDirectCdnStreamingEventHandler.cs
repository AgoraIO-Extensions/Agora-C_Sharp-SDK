using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IDirectCdnStreamingEventHandler
    {

        public IRtcEngineEx Engine;
        public UTRtcEngineEventHandler EventHandler;
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

            
            EventHandler = new UTRtcEngineEventHandler();
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

        #region

        [Test]
        public void Test_OnDirectCdnStreamingStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATECHANGED;

            DIRECT_CDN_STREAMING_STATE state;
            ParamsHelper.InitParam(out state);

            DIRECT_CDN_STREAMING_ERROR error;
            ParamsHelper.InitParam(out error);

            string message;
            ParamsHelper.InitParam(out message);

            jsonObj.Clear();
            jsonObj.Add("state", state);
            jsonObj.Add("error", error);
            jsonObj.Add("message", message);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnDirectCdnStreamingStateChangedPassed(state, error, message));
        }

        [Test]
        public void Test_OnDirectCdnStreamingStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATS;

            DirectCdnStreamingStats stats;
            ParamsHelper.InitParam(out stats);

            jsonObj.Clear();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnDirectCdnStreamingStatsPassed(stats));
        }

        #endregion
    }
}