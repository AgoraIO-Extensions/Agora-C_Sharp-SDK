using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IAudioFrameObserverBase
    {

        public IRtcEngineExS Engine;
        public UTAudioFrameObserverBase EventHandler;
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
            EventHandler = new UTAudioFrameObserverBase();
            Engine.RegisterAudioFrameObserver(EventHandler,
                                              AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_PLAYBACK |
                                                  AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_RECORD |
                                                  AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_MIXED |
                                                  AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_BEFORE_MIXING |
                                                  AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_EAR_MONITORING);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.UnRegisterAudioFrameObserver();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IAudioFrameObserverBase
        [Test]
        public void Test_OnRecordAudioFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVERBASE_ONRECORDAUDIOFRAME;

            jsonObj.Clear();

            string channelId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channelId", channelId);

            AudioFrame audioFrame = ParamsHelper.CreateParam<AudioFrame>();
            jsonObj.Add("audioFrame", audioFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRecordAudioFramePassed(channelId, audioFrame));
        }

        [Test]
        public void Test_OnPlaybackAudioFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVERBASE_ONPLAYBACKAUDIOFRAME;

            jsonObj.Clear();

            string channelId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channelId", channelId);

            AudioFrame audioFrame = ParamsHelper.CreateParam<AudioFrame>();
            jsonObj.Add("audioFrame", audioFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlaybackAudioFramePassed(channelId, audioFrame));
        }

        [Test]
        public void Test_OnMixedAudioFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVERBASE_ONMIXEDAUDIOFRAME;

            jsonObj.Clear();

            string channelId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channelId", channelId);

            AudioFrame audioFrame = ParamsHelper.CreateParam<AudioFrame>();
            jsonObj.Add("audioFrame", audioFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMixedAudioFramePassed(channelId, audioFrame));
        }

        [Test]
        public void Test_OnEarMonitoringAudioFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVERBASE_ONEARMONITORINGAUDIOFRAME;

            jsonObj.Clear();

            AudioFrame audioFrame = ParamsHelper.CreateParam<AudioFrame>();
            jsonObj.Add("audioFrame", audioFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnEarMonitoringAudioFramePassed(audioFrame));
        }

        [Test]
        public void Test_OnPlaybackAudioFrameBeforeMixing()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOFRAMEOBSERVERBASE_ONPLAYBACKAUDIOFRAMEBEFOREMIXING;

            jsonObj.Clear();

            string channelId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channelId", channelId);

            string userId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userId", userId);

            AudioFrame audioFrame = ParamsHelper.CreateParam<AudioFrame>();
            jsonObj.Add("audioFrame", audioFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlaybackAudioFrameBeforeMixingPassed(channelId, userId, audioFrame));
        }


        #endregion terra IAudioFrameObserverBase
    }
}
