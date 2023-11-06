using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IAudioEncodedFrameObserverS
    {

        public IRtcEngineExS Engine;
        public UTAudioEncodedFrameObserver EventHandler;
        public IntPtr FakeRtcEnginePtr;
        public IrisCApiParam2 ApiParam;
        public Dictionary<string, System.Object> jsonObj = new Dictionary<string, object>();

        [SetUp]
        public void Setup()
        {
            FakeRtcEnginePtr = DLLHelper.CreateFakeRtcEngineS();
            Engine = RtcEngineS.CreateAgoraRtcEngineEx(FakeRtcEnginePtr);
            RtcEngineContextS rtcEngineContext;
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

        #region terra IAudioEncodedFrameObserver
        [Test]
        public void Test_OnRecordAudioEncodedFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOENCODEDFRAMEOBSERVER_ONRECORDAUDIOENCODEDFRAME;

            jsonObj.Clear();

            IntPtr frameBuffer = ParamsHelper.CreateParam<IntPtr>();
            jsonObj.Add("frameBuffer", frameBuffer);

            int length = ParamsHelper.CreateParam<int>();
            jsonObj.Add("length", length);

            EncodedAudioFrameInfo audioEncodedFrameInfo = ParamsHelper.CreateParam<EncodedAudioFrameInfo>();
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

            jsonObj.Clear();

            IntPtr frameBuffer = ParamsHelper.CreateParam<IntPtr>();
            jsonObj.Add("frameBuffer", frameBuffer);

            int length = ParamsHelper.CreateParam<int>();
            jsonObj.Add("length", length);

            EncodedAudioFrameInfo audioEncodedFrameInfo = ParamsHelper.CreateParam<EncodedAudioFrameInfo>();
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

            jsonObj.Clear();

            IntPtr frameBuffer = ParamsHelper.CreateParam<IntPtr>();
            jsonObj.Add("frameBuffer", frameBuffer);

            int length = ParamsHelper.CreateParam<int>();
            jsonObj.Add("length", length);

            EncodedAudioFrameInfo audioEncodedFrameInfo = ParamsHelper.CreateParam<EncodedAudioFrameInfo>();
            jsonObj.Add("audioEncodedFrameInfo", audioEncodedFrameInfo);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMixedAudioEncodedFramePassed(frameBuffer, length, audioEncodedFrameInfo));
        }
        #endregion terra IAudioEncodedFrameObserver
    }
}