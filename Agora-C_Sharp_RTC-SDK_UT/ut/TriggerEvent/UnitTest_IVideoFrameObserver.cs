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
            int ret = Engine.RegisterVideoFrameObserver(EventHandler, VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA,
                                                        VIDEO_MODULE_POSITION.POSITION_POST_CAPTURER | VIDEO_MODULE_POSITION.POSITION_PRE_RENDERER | VIDEO_MODULE_POSITION.POSITION_PRE_ENCODER,
                                                        OBSERVER_MODE.INTPTR);
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

        #region terra IVideoFrameObserver

        [Test]
        public void Test_OnCaptureVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONCAPTUREVIDEOFRAME;

            jsonObj.Clear();

            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("sourceType", sourceType);

            VideoFrame videoFrame = ParamsHelper.CreateParam<VideoFrame>();
            jsonObj.Add("videoFrame", videoFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCaptureVideoFramePassed(sourceType, videoFrame));
        }

        [Test]
        public void Test_OnPreEncodeVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONPREENCODEVIDEOFRAME;

            jsonObj.Clear();

            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("sourceType", sourceType);

            VideoFrame videoFrame = ParamsHelper.CreateParam<VideoFrame>();
            jsonObj.Add("videoFrame", videoFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPreEncodeVideoFramePassed(sourceType, videoFrame));
        }

        [Test]
        public void Test_OnMediaPlayerVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONMEDIAPLAYERVIDEOFRAME;

            jsonObj.Clear();

            VideoFrame videoFrame = ParamsHelper.CreateParam<VideoFrame>();
            jsonObj.Add("videoFrame", videoFrame);

            int mediaPlayerId = ParamsHelper.CreateParam<int>();
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

            jsonObj.Clear();

            string channelId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channelId", channelId);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            VideoFrame videoFrame = ParamsHelper.CreateParam<VideoFrame>();
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

            jsonObj.Clear();

            VideoFrame videoFrame = ParamsHelper.CreateParam<VideoFrame>();
            jsonObj.Add("videoFrame", videoFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTranscodedVideoFramePassed(videoFrame));
        }

        #endregion terra IVideoFrameObserver
    }
}
