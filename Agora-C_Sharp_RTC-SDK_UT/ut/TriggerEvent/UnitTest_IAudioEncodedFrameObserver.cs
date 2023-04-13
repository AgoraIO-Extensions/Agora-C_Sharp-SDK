using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IAudioEncodedFrameObserver
    {

        public IRtcEngineEx Engine;
        public UTAudioEncodedFrameObserver EventHandler;
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
            EventHandler = new UTAudioEncodedFrameObserver();
            Engine.RegisterAudioEncodedFrameObserver(config, EventHandler);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.UnRegisterAudioEncodedFrameObserver();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }


        #region


        [Test]
        public void Test_OnRecordAudioEncodedFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOENCODEDFRAMEOBSERVER_ONRECORDAUDIOENCODEDFRAME;

            IntPtr frameBuffer;
            ParamsHelper.InitParam(out frameBuffer);

            int length;
            ParamsHelper.InitParam(out length);

            EncodedAudioFrameInfo audioEncodedFrameInfo;
            ParamsHelper.InitParam(out audioEncodedFrameInfo);

            jsonObj.Clear();
            jsonObj.Add("frameBuffer", frameBuffer);
            jsonObj.Add("length", length);
            jsonObj.Add("audioEncodedFrameInfo", audioEncodedFrameInfo);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRecordAudioEncodedFramePassed(frameBuffer, length, audioEncodedFrameInfo));
        }

        [Test]
        public void Test_OnPlaybackAudioEncodedFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOENCODEDFRAMEOBSERVER_ONPLAYBACKAUDIOENCODEDFRAME;

            IntPtr frameBuffer;
            ParamsHelper.InitParam(out frameBuffer);

            int length;
            ParamsHelper.InitParam(out length);

            EncodedAudioFrameInfo audioEncodedFrameInfo;
            ParamsHelper.InitParam(out audioEncodedFrameInfo);

            jsonObj.Clear();
            jsonObj.Add("frameBuffer", frameBuffer);
            jsonObj.Add("length", length);
            jsonObj.Add("audioEncodedFrameInfo", audioEncodedFrameInfo);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlaybackAudioEncodedFramePassed(frameBuffer, length, audioEncodedFrameInfo));
        }

        [Test]
        public void Test_OnMixedAudioEncodedFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOENCODEDFRAMEOBSERVER_ONMIXEDAUDIOENCODEDFRAME;

            IntPtr frameBuffer;
            ParamsHelper.InitParam(out frameBuffer);

            int length;
            ParamsHelper.InitParam(out length);

            EncodedAudioFrameInfo audioEncodedFrameInfo;
            ParamsHelper.InitParam(out audioEncodedFrameInfo);

            jsonObj.Clear();
            jsonObj.Add("frameBuffer", frameBuffer);
            jsonObj.Add("length", length);
            jsonObj.Add("audioEncodedFrameInfo", audioEncodedFrameInfo);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMixedAudioEncodedFramePassed(frameBuffer, length, audioEncodedFrameInfo));
        }

        #endregion
    }
}