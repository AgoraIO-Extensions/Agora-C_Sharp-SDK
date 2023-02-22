using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IVideoFrameObserver
    {
        public IRtcEngineEx Engine;
        public UTVideoFrameObserver EventHandler;
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


            EventHandler = new UTVideoFrameObserver();
            int ret = Engine.RegisterVideoFrameObserver(EventHandler, OBSERVER_MODE.INTPTR);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.UnRegisterVideoFrameObserver();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region



        [Test]
        public void Test_OnCaptureVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONCAPTUREVIDEOFRAME;

            VIDEO_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);


            jsonObj.Clear();
            jsonObj.Add("type", type);
            jsonObj.Add("videoFrame", videoFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCaptureVideoFramePassed(type, videoFrame));
        }



        [Test]
        public void Test_OnPreEncodeVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONPREENCODEVIDEOFRAME;

            VIDEO_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);


            jsonObj.Clear();
            jsonObj.Add("type", type);
            jsonObj.Add("videoFrame", videoFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPreEncodeVideoFramePassed(type, videoFrame));
        }



        [Test]
        public void Test_OnMediaPlayerVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONMEDIAPLAYERVIDEOFRAME;

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);

            int mediaPlayerId;
            ParamsHelper.InitParam(out mediaPlayerId);


            jsonObj.Clear();
            jsonObj.Add("videoFrame", videoFrame);
            jsonObj.Add("mediaPlayerId", mediaPlayerId);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMediaPlayerVideoFramePassed(videoFrame, mediaPlayerId));
        }



        [Test]
        public void Test_OnRenderVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONRENDERVIDEOFRAME;

            string channelId;
            ParamsHelper.InitParam(out channelId);

            uint remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);


            jsonObj.Clear();
            jsonObj.Add("channelId", channelId);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("videoFrame", videoFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRenderVideoFramePassed(channelId, remoteUid, videoFrame));
        }



        [Test]
        public void Test_OnTranscodedVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONTRANSCODEDVIDEOFRAME;

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);


            jsonObj.Clear();
            jsonObj.Add("videoFrame", videoFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTranscodedVideoFramePassed(videoFrame));
        }

        [Test]
        public void Test_GetVideoFormatPreference()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_GETVIDEOFORMATPREFERENCE;



            jsonObj.Clear();


            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.GetVideoFormatPreferencePassed());
        }

        [Test]
        public void Test_GetObservedFramePosition()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_GETOBSERVEDFRAMEPOSITION;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.GetObservedFramePositionPassed());
        }

        #endregion
    }
}

