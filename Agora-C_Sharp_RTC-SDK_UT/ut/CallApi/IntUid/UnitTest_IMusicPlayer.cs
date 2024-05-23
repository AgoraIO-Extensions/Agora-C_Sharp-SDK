using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc.Ut
{
    using view_t = System.UInt64;
    public class UnitTest_IMusicPlayer
    {
        public IRtcEngine Engine;
        public IMusicPlayer MusicPlayer;
        public IMusicContentCenter MusicContentCenter;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            MusicContentCenter = Engine.GetMusicContentCenter();
            MusicPlayer = MusicContentCenter.CreateMusicPlayer();

            Assert.AreEqual(MusicPlayer.GetId() > 0, true);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = MusicContentCenter.DestroyMusicPlayer(MusicPlayer);
            Assert.AreEqual(0, ret);
            Engine.Dispose();
        }

        #region terra IMusicPlayer
        [Test]
        public void Test_Open()
        {
            string url = ParamsHelper.CreateParam<string>();
            long startPos = ParamsHelper.CreateParam<long>();

            var nRet = MusicPlayer.Open(url, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Play()
        {


            var nRet = MusicPlayer.Play();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Pause()
        {


            var nRet = MusicPlayer.Pause();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Stop()
        {


            var nRet = MusicPlayer.Stop();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Resume()
        {


            var nRet = MusicPlayer.Resume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Seek()
        {
            long newPos = ParamsHelper.CreateParam<long>();

            var nRet = MusicPlayer.Seek(newPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioPitch()
        {
            int pitch = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.SetAudioPitch(pitch);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetDuration()
        {
            long duration = ParamsHelper.CreateParam<long>();

            var nRet = MusicPlayer.GetDuration(ref duration);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlayPosition()
        {
            long pos = ParamsHelper.CreateParam<long>();

            var nRet = MusicPlayer.GetPlayPosition(ref pos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetStreamCount()
        {
            long count = ParamsHelper.CreateParam<long>();

            var nRet = MusicPlayer.GetStreamCount(ref count);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetStreamInfo()
        {
            long index = ParamsHelper.CreateParam<long>();
            PlayerStreamInfo info = ParamsHelper.CreateParam<PlayerStreamInfo>();

            var nRet = MusicPlayer.GetStreamInfo(index, ref info);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLoopCount()
        {
            int loopCount = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.SetLoopCount(loopCount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlaybackSpeed()
        {
            int speed = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.SetPlaybackSpeed(speed);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SelectAudioTrack()
        {
            int index = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.SelectAudioTrack(index);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SelectMultiAudioTrack()
        {
            int playoutTrackIndex = ParamsHelper.CreateParam<int>();
            int publishTrackIndex = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.SelectMultiAudioTrack(playoutTrackIndex, publishTrackIndex);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlayerOption()
        {
            string key = ParamsHelper.CreateParam<string>();
            int value = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.SetPlayerOption(key, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlayerOption2()
        {
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();

            var nRet = MusicPlayer.SetPlayerOption(key, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_TakeScreenshot()
        {
            string filename = ParamsHelper.CreateParam<string>();

            var nRet = MusicPlayer.TakeScreenshot(filename);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SelectInternalSubtitle()
        {
            int index = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.SelectInternalSubtitle(index);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExternalSubtitle()
        {
            string url = ParamsHelper.CreateParam<string>();

            var nRet = MusicPlayer.SetExternalSubtitle(url);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetState()
        {


            var nRet = MusicPlayer.GetState();
            Assert.AreEqual(MEDIA_PLAYER_STATE.PLAYER_STATE_IDLE, nRet);
        }

        [Test]
        public void Test_Mute()
        {
            bool muted = ParamsHelper.CreateParam<bool>();

            var nRet = MusicPlayer.Mute(muted);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetMute()
        {
            bool muted = ParamsHelper.CreateParam<bool>();

            var nRet = MusicPlayer.GetMute(ref muted);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustPlayoutVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.AdjustPlayoutVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlayoutVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.GetPlayoutVolume(ref volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustPublishSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.AdjustPublishSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPublishSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.GetPublishSignalVolume(ref volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetView()
        {
            view_t view = ParamsHelper.CreateParam<view_t>();

            var nRet = MusicPlayer.SetView(view);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRenderMode()
        {
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();

            var nRet = MusicPlayer.SetRenderMode(renderMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnregisterAudioFrameObserver()
        {


            var nRet = MusicPlayer.UnregisterAudioFrameObserver();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnregisterMediaPlayerAudioSpectrumObserver()
        {


            var nRet = MusicPlayer.UnregisterMediaPlayerAudioSpectrumObserver();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioDualMonoMode()
        {
            AUDIO_DUAL_MONO_MODE mode = ParamsHelper.CreateParam<AUDIO_DUAL_MONO_MODE>();

            var nRet = MusicPlayer.SetAudioDualMonoMode(mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlayerSdkVersion()
        {


            var nRet = MusicPlayer.GetPlayerSdkVersion();
            Assert.AreEqual("", nRet);
        }

        [Test]
        public void Test_GetPlaySrc()
        {


            var nRet = MusicPlayer.GetPlaySrc();
            Assert.AreEqual("", nRet);
        }

        [Test]
        public void Test_OpenWithAgoraCDNSrc()
        {
            string src = ParamsHelper.CreateParam<string>();
            long startPos = ParamsHelper.CreateParam<long>();

            var nRet = MusicPlayer.OpenWithAgoraCDNSrc(src, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAgoraCDNLineCount()
        {


            var nRet = MusicPlayer.GetAgoraCDNLineCount();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SwitchAgoraCDNLineByIndex()
        {
            int index = ParamsHelper.CreateParam<int>();

            var nRet = MusicPlayer.SwitchAgoraCDNLineByIndex(index);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCurrentAgoraCDNIndex()
        {


            var nRet = MusicPlayer.GetCurrentAgoraCDNIndex();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAutoSwitchAgoraCDN()
        {
            bool enable = ParamsHelper.CreateParam<bool>();

            var nRet = MusicPlayer.EnableAutoSwitchAgoraCDN(enable);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RenewAgoraCDNSrcToken()
        {
            string token = ParamsHelper.CreateParam<string>();
            long ts = ParamsHelper.CreateParam<long>();

            var nRet = MusicPlayer.RenewAgoraCDNSrcToken(token, ts);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SwitchAgoraCDNSrc()
        {
            string src = ParamsHelper.CreateParam<string>();
            bool syncPts = ParamsHelper.CreateParam<bool>();

            var nRet = MusicPlayer.SwitchAgoraCDNSrc(src, syncPts);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SwitchSrc()
        {
            string src = ParamsHelper.CreateParam<string>();
            bool syncPts = ParamsHelper.CreateParam<bool>();

            var nRet = MusicPlayer.SwitchSrc(src, syncPts);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PreloadSrc()
        {
            string src = ParamsHelper.CreateParam<string>();
            long startPos = ParamsHelper.CreateParam<long>();

            var nRet = MusicPlayer.PreloadSrc(src, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PlayPreloadedSrc()
        {
            string src = ParamsHelper.CreateParam<string>();

            var nRet = MusicPlayer.PlayPreloadedSrc(src);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnloadSrc()
        {
            string src = ParamsHelper.CreateParam<string>();

            var nRet = MusicPlayer.UnloadSrc(src);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSpatialAudioParams()
        {
            SpatialAudioParams @params = ParamsHelper.CreateParam<SpatialAudioParams>();

            var nRet = MusicPlayer.SetSpatialAudioParams(@params);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSoundPositionParams()
        {
            float pan = ParamsHelper.CreateParam<float>();
            float gain = ParamsHelper.CreateParam<float>();

            var nRet = MusicPlayer.SetSoundPositionParams(pan, gain);
            Assert.AreEqual(0, nRet);
        }
        [Test]
        public void Test_Open2()
        {
            long songCode = ParamsHelper.CreateParam<long>();
            long startPos = ParamsHelper.CreateParam<long>();

            var nRet = MusicPlayer.Open(songCode, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlayMode()
        {
            MusicPlayMode mode = ParamsHelper.CreateParam<MusicPlayMode>();

            var nRet = MusicPlayer.SetPlayMode(mode);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IMusicPlayer
    }
}
