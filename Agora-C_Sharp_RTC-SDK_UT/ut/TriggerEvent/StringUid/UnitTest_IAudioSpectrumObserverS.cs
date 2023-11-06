using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IAudioSpectrumObserverS
    {
        public IRtcEngineExS Engine;
        public UTAudioSpectrumObserverS EventHandler;
        public IMediaPlayer MediaPlayer;
        public UTAudioSpectrumObserverS EventHandlerForMediaPlayer;
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

            EventHandler = new UTAudioSpectrumObserverS();
            EventHandler.TAG = "FOR_RTCENGINE";
            int ret = Engine.RegisterAudioSpectrumObserver(EventHandler);
            Assert.AreEqual(0, ret);

            EventHandlerForMediaPlayer = new UTAudioSpectrumObserverS();
            EventHandlerForMediaPlayer.TAG = "FOR_MEDIAPLAYER";
            MediaPlayer = Engine.CreateMediaPlayer();

            //todo need delete this.
            ret = MediaPlayer.RegisterMediaPlayerAudioSpectrumObserver((UTAudioSpectrumObserver)(System.Object)EventHandlerForMediaPlayer, 10);

            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.UnregisterAudioSpectrumObserver();
            Assert.AreEqual(0, ret);

            ret = MediaPlayer.UnregisterMediaPlayerAudioSpectrumObserver();
            Assert.AreEqual(0, ret);

            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IAudioSpectrumObserverS

        [Test]
        public void Test_OnLocalAudioSpectrum()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOSPECTRUMOBSERVERS_ONLOCALAUDIOSPECTRUM;

            jsonObj.Clear();

            AudioSpectrumData data = ParamsHelper.CreateParam<AudioSpectrumData>();
            jsonObj.Add("data", data);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalAudioSpectrumPassed(data));
            Assert.AreEqual(true, EventHandlerForMediaPlayer.OnLocalAudioSpectrumPassed(data));
        }
        [Test]
        public void Test_OnRemoteAudioSpectrum()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOSPECTRUMOBSERVERS_ONREMOTEAUDIOSPECTRUM;

            jsonObj.Clear();

            UserAudioSpectrumInfoS[] spectrumsS = ParamsHelper.CreateParam<UserAudioSpectrumInfoS[]>();
            jsonObj.Add("spectrumsS", spectrumsS);

            uint spectrumNumber = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("spectrumNumber", spectrumNumber);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteAudioSpectrumPassed(spectrumsS, spectrumNumber));
            Assert.AreEqual(true, EventHandlerForMediaPlayer.OnRemoteAudioSpectrumPassed(spectrumsS, spectrumNumber));
        }
        #endregion terra IAudioSpectrumObserverS
    }
}