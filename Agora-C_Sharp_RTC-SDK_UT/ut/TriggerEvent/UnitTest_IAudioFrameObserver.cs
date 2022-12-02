using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IAudioFrameObserver
    {

        public IRtcEngineEx Engine;
        public UTAudioFrameObserver EventHandler;
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

            AudioEncodedFrameObserverConfig config = new AudioEncodedFrameObserverConfig();
            EventHandler = new UTAudioFrameObserver();
            Engine.RegisterAudioFrameObserver(EventHandler);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.UnRegisterAudioFrameObserver();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region

        [Test]
        public void Test_OnRecordAudioFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONRECORDAUDIOFRAME;

            string channelId;
            ParamsHelper.InitParam(out channelId);

            AudioFrame audioFrame;
            ParamsHelper.InitParam(out audioFrame);

            jsonObj.Clear();
            jsonObj.Add("channelId", channelId);
            jsonObj.Add("audioFrame", audioFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRecordAudioFramePassed(channelId, audioFrame));
        }

        [Test]
        public void Test_OnPlaybackAudioFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAME;

            string channelId;
            ParamsHelper.InitParam(out channelId);

            AudioFrame audioFrame;
            ParamsHelper.InitParam(out audioFrame);

            jsonObj.Clear();
            jsonObj.Add("channelId", channelId);
            jsonObj.Add("audioFrame", audioFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlaybackAudioFramePassed(channelId, audioFrame));
        }

        [Test]
        public void Test_OnMixedAudioFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONMIXEDAUDIOFRAME;

            string channelId;
            ParamsHelper.InitParam(out channelId);

            AudioFrame audioFrame;
            ParamsHelper.InitParam(out audioFrame);

            jsonObj.Clear();
            jsonObj.Add("channelId", channelId);
            jsonObj.Add("audioFrame", audioFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMixedAudioFramePassed(channelId, audioFrame));
        }

        [Test]
        public void Test_OnEarMonitoringAudioFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONEARMONITORINGAUDIOFRAME;

            AudioFrame audioFrame;
            ParamsHelper.InitParam(out audioFrame);

            jsonObj.Clear();
            jsonObj.Add("audioFrame", audioFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnEarMonitoringAudioFramePassed(audioFrame));
        }

        [Test]
        public void Test_OnPlaybackAudioFrameBeforeMixing()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING;

            string channelId;
            ParamsHelper.InitParam(out channelId);

            uint userId;
            ParamsHelper.InitParam(out userId);

            AudioFrame audioFrame;
            ParamsHelper.InitParam(out audioFrame);

            jsonObj.Clear();
            jsonObj.Add("channelId", channelId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("audioFrame", audioFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlaybackAudioFrameBeforeMixingPassed(channelId, userId, audioFrame));
        }

        [Test]
        public void Test_GetObservedAudioFramePosition()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_GETOBSERVEDAUDIOFRAMEPOSITION;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.GetObservedAudioFramePositionPassed());
        }

        [Test]
        public void Test_GetPlaybackAudioParams()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_GETPLAYBACKAUDIOPARAMS;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.GetPlaybackAudioParamsPassed());
        }

        [Test]
        public void Test_GetRecordAudioParams()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_GETRECORDAUDIOPARAMS;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.GetRecordAudioParamsPassed());
        }

        [Test]
        public void Test_GetMixedAudioParams()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_GETMIXEDAUDIOPARAMS;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.GetMixedAudioParamsPassed());
        }

        [Test]
        public void Test_GetEarMonitoringAudioParams()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_GETEARMONITORINGAUDIOPARAMS;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.GetEarMonitoringAudioParamsPassed());
        }

        [Test]
        public void Test_OnPlaybackAudioFrameBeforeMixing2()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING2;

            string channelId;
            ParamsHelper.InitParam(out channelId);

            string uid;
            ParamsHelper.InitParam(out uid);

            AudioFrame audioFrame;
            ParamsHelper.InitParam(out audioFrame);

            jsonObj.Clear();
            jsonObj.Add("channelId", channelId);
            jsonObj.Add("uid", uid);
            jsonObj.Add("audioFrame", audioFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlaybackAudioFrameBeforeMixingPassed2(channelId, uid, audioFrame));
        }


        #endregion

    }
}
