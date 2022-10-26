using NUnit.Framework;
using Agora.Rtc;

namespace ut
{
    public class UnitTest_IMusicPlayer
    {
        public IRtcEngine Engine;
        public IMusicPlayer MusicPlayer;
        public IMusicContentCenter MusicContentCenter;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateDebugApiEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(nRet, 0);
            MusicContentCenter = Engine.GetMusicContentCenter();
            MusicPlayer = MusicContentCenter.CreateMusicPlayer();

            Assert.AreEqual(MusicPlayer.GetId() > 0, true);
        }

        [TearDown]
        public void TearDown()
        {
            MusicContentCenter.DestroyMusicPlayer(MusicPlayer);
            Engine.Dispose();
        }

        #region custom

        [Test]
        public void Test_GetDuration()
        {
            long duration;
            ParamsHelper.InitParam(out duration);
            var nRet = MusicPlayer.GetDuration(ref duration);

            Assert.AreEqual(nRet, 0);
        }


        [Test]
        public void Test_GetPlayPosition()
        {
            long pos;
            ParamsHelper.InitParam(out pos);
            var nRet = MusicPlayer.GetPlayPosition(ref pos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetStreamCount()
        {
            long count;
            ParamsHelper.InitParam(out count);
            var nRet = MusicPlayer.GetStreamCount(ref count);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetStreamInfo()
        {
            long index;
            ParamsHelper.InitParam(out index);
            PlayerStreamInfo info;
            ParamsHelper.InitParam(out info);
            var nRet = MusicPlayer.GetStreamInfo(index, ref info);

            Assert.AreEqual(nRet, 0);
        }


        [Test]
        public void Test_GetMute()
        {
            bool muted;
            ParamsHelper.InitParam(out muted);
            var nRet = MusicPlayer.GetMute(ref muted);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPlayoutVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = MusicPlayer.GetPlayoutVolume(ref volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPublishSignalVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = MusicPlayer.GetPublishSignalVolume(ref volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetView()
        {

            var nRet = MusicPlayer.SetView();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RegisterPlayerSourceObserver()
        {
            IMediaPlayerSourceObserver observer;
            ParamsHelper.InitParam(out observer);
            MusicPlayer.InitEventHandler(observer);
        }

        [Test]
        public void Test_UnregisterPlayerSourceObserver()
        {
            MusicPlayer.InitEventHandler(null);
        }

        [Test]
        public void Test_UnregisterAudioFrameObserver()
        {
            IMediaPlayerAudioFrameObserver observer;
            ParamsHelper.InitParam(out observer);
            var nRet = MusicPlayer.UnregisterAudioFrameObserver();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UnregisterMediaPlayerAudioSpectrumObserver()
        {
            IAudioSpectrumObserver observer;
            ParamsHelper.InitParam(out observer);
            var nRet = MusicPlayer.UnregisterMediaPlayerAudioSpectrumObserver();

            Assert.AreEqual(nRet, 0);
        }

        #endregion



        #region terr
        [Test]
        public void Test_Open()
        {
            string url;
            ParamsHelper.InitParam(out url);
            long startPos;
            ParamsHelper.InitParam(out startPos);
            var nRet = MusicPlayer.Open(url, startPos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_OpenWithCustomSource()
        {
            long startPos;
            ParamsHelper.InitParam(out startPos);
            IMediaPlayerCustomDataProvider provider;
            ParamsHelper.InitParam(out provider);
            var nRet = MusicPlayer.OpenWithCustomSource(startPos, provider);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_OpenWithMediaSource()
        {
            MediaSource source;
            ParamsHelper.InitParam(out source);
            var nRet = MusicPlayer.OpenWithMediaSource(source);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Play()
        {

            var nRet = MusicPlayer.Play();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Pause()
        {

            var nRet = MusicPlayer.Pause();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Stop()
        {

            var nRet = MusicPlayer.Stop();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Resume()
        {

            var nRet = MusicPlayer.Resume();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Seek()
        {
            long newPos;
            ParamsHelper.InitParam(out newPos);
            var nRet = MusicPlayer.Seek(newPos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioPitch()
        {
            int pitch;
            ParamsHelper.InitParam(out pitch);
            var nRet = MusicPlayer.SetAudioPitch(pitch);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLoopCount()
        {
            int loopCount;
            ParamsHelper.InitParam(out loopCount);
            var nRet = MusicPlayer.SetLoopCount(loopCount);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetPlaybackSpeed()
        {
            int speed;
            ParamsHelper.InitParam(out speed);
            var nRet = MusicPlayer.SetPlaybackSpeed(speed);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SelectAudioTrack()
        {
            int index;
            ParamsHelper.InitParam(out index);
            var nRet = MusicPlayer.SelectAudioTrack(index);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetPlayerOption()
        {
            string key;
            ParamsHelper.InitParam(out key);
            int value;
            ParamsHelper.InitParam(out value);
            var nRet = MusicPlayer.SetPlayerOption(key, value);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetPlayerOption2()
        {
            string key;
            ParamsHelper.InitParam(out key);
            string value;
            ParamsHelper.InitParam(out value);
            var nRet = MusicPlayer.SetPlayerOption(key, value);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_TakeScreenshot()
        {
            string filename;
            ParamsHelper.InitParam(out filename);
            var nRet = MusicPlayer.TakeScreenshot(filename);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SelectInternalSubtitle()
        {
            int index;
            ParamsHelper.InitParam(out index);
            var nRet = MusicPlayer.SelectInternalSubtitle(index);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetExternalSubtitle()
        {
            string url;
            ParamsHelper.InitParam(out url);
            var nRet = MusicPlayer.SetExternalSubtitle(url);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetState()
        {

            var nRet = MusicPlayer.GetState();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Mute()
        {
            bool muted;
            ParamsHelper.InitParam(out muted);
            var nRet = MusicPlayer.Mute(muted);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AdjustPlayoutVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = MusicPlayer.AdjustPlayoutVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AdjustPublishSignalVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = MusicPlayer.AdjustPublishSignalVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetRenderMode()
        {
            RENDER_MODE_TYPE renderMode;
            ParamsHelper.InitParam(out renderMode);
            var nRet = MusicPlayer.SetRenderMode(renderMode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RegisterAudioFrameObserver()
        {
            IMediaPlayerAudioFrameObserver observer;
            ParamsHelper.InitParam(out observer);
            var nRet = MusicPlayer.RegisterAudioFrameObserver(observer);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RegisterAudioFrameObserver2()
        {
            IMediaPlayerAudioFrameObserver observer;
            ParamsHelper.InitParam(out observer);
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode;
            ParamsHelper.InitParam(out mode);
            var nRet = MusicPlayer.RegisterAudioFrameObserver(observer, mode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RegisterMediaPlayerAudioSpectrumObserver()
        {
            IAudioSpectrumObserver observer;
            ParamsHelper.InitParam(out observer);
            int intervalInMS;
            ParamsHelper.InitParam(out intervalInMS);
            var nRet = MusicPlayer.RegisterMediaPlayerAudioSpectrumObserver(observer, intervalInMS);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioDualMonoMode()
        {
            AUDIO_DUAL_MONO_MODE mode;
            ParamsHelper.InitParam(out mode);
            var nRet = MusicPlayer.SetAudioDualMonoMode(mode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPlayerSdkVersion()
        {

            var nRet = MusicPlayer.GetPlayerSdkVersion();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPlaySrc()
        {

            var nRet = MusicPlayer.GetPlaySrc();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_OpenWithAgoraCDNSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            long startPos;
            ParamsHelper.InitParam(out startPos);
            var nRet = MusicPlayer.OpenWithAgoraCDNSrc(src, startPos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetAgoraCDNLineCount()
        {

            var nRet = MusicPlayer.GetAgoraCDNLineCount();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SwitchAgoraCDNLineByIndex()
        {
            int index;
            ParamsHelper.InitParam(out index);
            var nRet = MusicPlayer.SwitchAgoraCDNLineByIndex(index);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetCurrentAgoraCDNIndex()
        {

            var nRet = MusicPlayer.GetCurrentAgoraCDNIndex();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableAutoSwitchAgoraCDN()
        {
            bool enable;
            ParamsHelper.InitParam(out enable);
            var nRet = MusicPlayer.EnableAutoSwitchAgoraCDN(enable);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RenewAgoraCDNSrcToken()
        {
            string token;
            ParamsHelper.InitParam(out token);
            long ts;
            ParamsHelper.InitParam(out ts);
            var nRet = MusicPlayer.RenewAgoraCDNSrcToken(token, ts);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SwitchAgoraCDNSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            bool syncPts;
            ParamsHelper.InitParam(out syncPts);
            var nRet = MusicPlayer.SwitchAgoraCDNSrc(src, syncPts);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SwitchSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            bool syncPts;
            ParamsHelper.InitParam(out syncPts);
            var nRet = MusicPlayer.SwitchSrc(src, syncPts);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_PreloadSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            long startPos;
            ParamsHelper.InitParam(out startPos);
            var nRet = MusicPlayer.PreloadSrc(src, startPos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_PlayPreloadedSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            var nRet = MusicPlayer.PlayPreloadedSrc(src);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UnloadSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            var nRet = MusicPlayer.UnloadSrc(src);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetSpatialAudioParams()
        {
            SpatialAudioParams @params;
            ParamsHelper.InitParam(out @params);
            var nRet = MusicPlayer.SetSpatialAudioParams(@params);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetSoundPositionParams()
        {
            float pan;
            ParamsHelper.InitParam(out pan);
            float gain;
            ParamsHelper.InitParam(out gain);
            var nRet = MusicPlayer.SetSoundPositionParams(pan, gain);

            Assert.AreEqual(nRet, 0);
        }
        [Test]
        public void Test_Open2()
        {
            long songCode;
            ParamsHelper.InitParam(out songCode);
            long startPos;
            ParamsHelper.InitParam(out startPos);
            var nRet = MusicPlayer.Open(songCode, startPos);

            Assert.AreEqual(nRet, 0);
        }

        #endregion





    }
}
