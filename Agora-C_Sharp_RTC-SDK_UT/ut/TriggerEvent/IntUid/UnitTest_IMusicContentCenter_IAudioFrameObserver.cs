using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Ut.Event
{
    [TestFixture]
    public partial class UnitTest_IMusicContentCenter_IAudioFrameObserver
    {

        public IRtcEngineEx Engine;
        public IMusicContentCenter MusicContentCenter;
        public UTAudioFrameObserver callback;
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

            callback = new UTAudioFrameObserver();
            MusicContentCenter = Engine.GetMusicContentCenter();
            int ret = MusicContentCenter.Initialize(new MusicContentCenterConfiguration(10));
            Assert.AreEqual(0, ret);
            MusicContentCenter.RegisterAudioFrameObserver(callback,
                                              AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_PLAYBACK |
                                                  AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_RECORD |
                                                  AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_MIXED |
                                                  AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_BEFORE_MIXING |
                                                  AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_EAR_MONITORING);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = MusicContentCenter.UnregisterAudioFrameObserver();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }
    }
}