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

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);

            VideoFrameBufferConfig config;
            config.type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA;
            config.id = 0;
            config.key = "";

            jsonObj.Clear();
            // 

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCaptureVideoFramePassed(videoFrame, config));
        }

        [Test]
        public void Test_OnPreEncodeVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONPREENCODEVIDEOFRAME;

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);

            jsonObj.Clear();
           

            VideoFrameBufferConfig config;
            config.type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            config.id = 0;
            config.key = "";

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPreEncodeVideoFramePassed(videoFrame, config));
        }

        [Test]
        public void Test_OnSecondaryCameraCaptureVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONSECONDARYCAMERACAPTUREVIDEOFRAME;

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);

          
            jsonObj.Clear();
             

            VideoFrameBufferConfig config;
            config.type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_SECONDARY;
            config.id = 0;
            config.key = "";

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCaptureVideoFramePassed(videoFrame, config));
        }

        [Test]
        public void Test_OnSecondaryPreEncodeCameraVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONSECONDARYPREENCODECAMERAVIDEOFRAME;

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);

            jsonObj.Clear();
             

            VideoFrameBufferConfig config;
            config.type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_SECONDARY;
            config.id = 0;
            config.key = "";

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPreEncodeVideoFramePassed(videoFrame, config));
        }

        [Test]
        public void Test_OnScreenCaptureVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONSCREENCAPTUREVIDEOFRAME;

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);

            jsonObj.Clear();
             

            VideoFrameBufferConfig config;
            config.type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_SCREEN_PRIMARY;
            config.id = 0;
            config.key = "";

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCaptureVideoFramePassed(videoFrame, config));
        }

        [Test]
        public void Test_OnPreEncodeScreenVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONPREENCODESCREENVIDEOFRAME;

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);

            jsonObj.Clear();
             

            VideoFrameBufferConfig config;
            config.type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_SCREEN;
            config.id = 0;
            config.key = "";

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPreEncodeVideoFramePassed(videoFrame,config));
        }

        [Test]
        public void Test_OnMediaPlayerVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONMEDIAPLAYERVIDEOFRAME;

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);

            int mediaPlayerId;
            ParamsHelper.InitParam(out mediaPlayerId);

            VideoFrameBufferConfig config;
            config.type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_MEDIA_PLAYER;
            config.id = 1;
            config.key = "";

            jsonObj.Clear();
             
            jsonObj.Add("mediaPlayerId", mediaPlayerId);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCaptureVideoFramePassed(videoFrame, config));
        }

        [Test]
        public void Test_OnSecondaryScreenCaptureVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONSECONDARYSCREENCAPTUREVIDEOFRAME;

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);

            VideoFrameBufferConfig config;
            config.type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_SCREEN_SECONDARY;
            config.id = 0;
            config.key = "";

            jsonObj.Clear();
             

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCaptureVideoFramePassed(videoFrame,config));
        }

        [Test]
        public void Test_OnSecondaryPreEncodeScreenVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOFRAMEOBSERVER_ONSECONDARYPREENCODESCREENVIDEOFRAME;

            VideoFrame videoFrame;
            ParamsHelper.InitParam(out videoFrame);

            jsonObj.Clear();
             

            VideoFrameBufferConfig config;
            config.type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_SCREEN_SECONDARY;
            config.id = 0;
            config.key = "";

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPreEncodeVideoFramePassed(videoFrame,config));
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
             

            VideoFrameBufferConfig config;
            config.type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_TRANSCODED;
            config.id = 0;
            config.key = "";

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCaptureVideoFramePassed(videoFrame,config));
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
            //iris will not trigger this call back
            //Assert.AreEqual(true, EventHandler.GetVideoFormatPreferencePassed());
        }

        #endregion
    }
}

