using NUnit.Framework;
using Agora.Rtc;
namespace ut
{
    public class UnitTest_IMediaPlayer
    {
        public IRtcEngine Engine;
        public IMediaPlayer MediaPlayer;


        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine();
            MediaPlayer = Engine.CreateMediaPlayer();
            Assert.AreEqual(MediaPlayer.GetId() > 0, true);
        }

        [TearDown]
        public void TearDown()
        {
            Engine.DestroyMediaPlayer(MediaPlayer);
            Engine.Dispose();
        }

        #region custom

        [Test]
        public void Test_GetDuration()
        {
            long duration;
            ParamsHelper.InitParam(out duration);
            var nRet = MediaPlayer.GetDuration(ref duration);

            Assert.AreEqual(nRet, 0);
        }


        [Test]
        public void Test_GetPlayPosition()
        {
            long pos;
            ParamsHelper.InitParam(out pos);
            var nRet = MediaPlayer.GetPlayPosition(ref pos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetStreamCount()
        {
            long count;
            ParamsHelper.InitParam(out count);
            var nRet = MediaPlayer.GetStreamCount(ref count);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetStreamInfo()
        {
            long index;
            ParamsHelper.InitParam(out index);
            PlayerStreamInfo info;
            ParamsHelper.InitParam(out info);
            var nRet = MediaPlayer.GetStreamInfo(index, ref info);

            Assert.AreEqual(nRet, 0);
        }


        [Test]
        public void Test_GetMute()
        {
            bool muted;
            ParamsHelper.InitParam(out muted);
            var nRet = MediaPlayer.GetMute(ref muted);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPlayoutVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = MediaPlayer.GetPlayoutVolume(ref volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPublishSignalVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = MediaPlayer.GetPublishSignalVolume(ref volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetView()
        {

            var nRet = MediaPlayer.SetView();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RegisterPlayerSourceObserver()
        {
            IMediaPlayerSourceObserver observer;
            ParamsHelper.InitParam(out observer);
            MediaPlayer.InitEventHandler(observer);
        }

        [Test]
        public void Test_UnregisterPlayerSourceObserver()
        {
            MediaPlayer.InitEventHandler(null);
        }

        [Test]
        public void Test_UnregisterAudioFrameObserver()
        {
            IMediaPlayerAudioFrameObserver observer;
            ParamsHelper.InitParam(out observer);
            var nRet = MediaPlayer.UnregisterAudioFrameObserver();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UnregisterMediaPlayerAudioSpectrumObserver()
        {
            IAudioSpectrumObserver observer;
            ParamsHelper.InitParam(out observer);
            var nRet = MediaPlayer.UnregisterMediaPlayerAudioSpectrumObserver();

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
            var nRet = MediaPlayer.Open(url, startPos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_OpenWithCustomSource()
        {
            long startPos;
            ParamsHelper.InitParam(out startPos);
            IMediaPlayerCustomDataProvider provider;
            ParamsHelper.InitParam(out provider);
            var nRet = MediaPlayer.OpenWithCustomSource(startPos, provider);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_OpenWithMediaSource()
        {
            MediaSource source;
            ParamsHelper.InitParam(out source);
            var nRet = MediaPlayer.OpenWithMediaSource(source);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Play()
        {

            var nRet = MediaPlayer.Play();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Pause()
        {

            var nRet = MediaPlayer.Pause();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Stop()
        {

            var nRet = MediaPlayer.Stop();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Resume()
        {

            var nRet = MediaPlayer.Resume();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Seek()
        {
            long newPos;
            ParamsHelper.InitParam(out newPos);
            var nRet = MediaPlayer.Seek(newPos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioPitch()
        {
            int pitch;
            ParamsHelper.InitParam(out pitch);
            var nRet = MediaPlayer.SetAudioPitch(pitch);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLoopCount()
        {
            int loopCount;
            ParamsHelper.InitParam(out loopCount);
            var nRet = MediaPlayer.SetLoopCount(loopCount);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetPlaybackSpeed()
        {
            int speed;
            ParamsHelper.InitParam(out speed);
            var nRet = MediaPlayer.SetPlaybackSpeed(speed);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SelectAudioTrack()
        {
            int index;
            ParamsHelper.InitParam(out index);
            var nRet = MediaPlayer.SelectAudioTrack(index);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetPlayerOption()
        {
            string key;
            ParamsHelper.InitParam(out key);
            int value;
            ParamsHelper.InitParam(out value);
            var nRet = MediaPlayer.SetPlayerOption(key, value);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetPlayerOption2()
        {
            string key;
            ParamsHelper.InitParam(out key);
            string value;
            ParamsHelper.InitParam(out value);
            var nRet = MediaPlayer.SetPlayerOption(key, value);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_TakeScreenshot()
        {
            string filename;
            ParamsHelper.InitParam(out filename);
            var nRet = MediaPlayer.TakeScreenshot(filename);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SelectInternalSubtitle()
        {
            int index;
            ParamsHelper.InitParam(out index);
            var nRet = MediaPlayer.SelectInternalSubtitle(index);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetExternalSubtitle()
        {
            string url;
            ParamsHelper.InitParam(out url);
            var nRet = MediaPlayer.SetExternalSubtitle(url);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetState()
        {

            var nRet = MediaPlayer.GetState();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Mute()
        {
            bool muted;
            ParamsHelper.InitParam(out muted);
            var nRet = MediaPlayer.Mute(muted);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AdjustPlayoutVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = MediaPlayer.AdjustPlayoutVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AdjustPublishSignalVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = MediaPlayer.AdjustPublishSignalVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetRenderMode()
        {
            RENDER_MODE_TYPE renderMode;
            ParamsHelper.InitParam(out renderMode);
            var nRet = MediaPlayer.SetRenderMode(renderMode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RegisterAudioFrameObserver()
        {
            IMediaPlayerAudioFrameObserver observer;
            ParamsHelper.InitParam(out observer);
            var nRet = MediaPlayer.RegisterAudioFrameObserver(observer);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RegisterAudioFrameObserver2()
        {
            IMediaPlayerAudioFrameObserver observer;
            ParamsHelper.InitParam(out observer);
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode;
            ParamsHelper.InitParam(out mode);
            var nRet = MediaPlayer.RegisterAudioFrameObserver(observer, mode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RegisterMediaPlayerAudioSpectrumObserver()
        {
            IAudioSpectrumObserver observer;
            ParamsHelper.InitParam(out observer);
            int intervalInMS;
            ParamsHelper.InitParam(out intervalInMS);
            var nRet = MediaPlayer.RegisterMediaPlayerAudioSpectrumObserver(observer, intervalInMS);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioDualMonoMode()
        {
            AUDIO_DUAL_MONO_MODE mode;
            ParamsHelper.InitParam(out mode);
            var nRet = MediaPlayer.SetAudioDualMonoMode(mode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPlayerSdkVersion()
        {

            var nRet = MediaPlayer.GetPlayerSdkVersion();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPlaySrc()
        {

            var nRet = MediaPlayer.GetPlaySrc();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_OpenWithAgoraCDNSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            long startPos;
            ParamsHelper.InitParam(out startPos);
            var nRet = MediaPlayer.OpenWithAgoraCDNSrc(src, startPos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetAgoraCDNLineCount()
        {

            var nRet = MediaPlayer.GetAgoraCDNLineCount();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SwitchAgoraCDNLineByIndex()
        {
            int index;
            ParamsHelper.InitParam(out index);
            var nRet = MediaPlayer.SwitchAgoraCDNLineByIndex(index);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetCurrentAgoraCDNIndex()
        {

            var nRet = MediaPlayer.GetCurrentAgoraCDNIndex();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableAutoSwitchAgoraCDN()
        {
            bool enable;
            ParamsHelper.InitParam(out enable);
            var nRet = MediaPlayer.EnableAutoSwitchAgoraCDN(enable);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RenewAgoraCDNSrcToken()
        {
            string token;
            ParamsHelper.InitParam(out token);
            long ts;
            ParamsHelper.InitParam(out ts);
            var nRet = MediaPlayer.RenewAgoraCDNSrcToken(token, ts);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SwitchAgoraCDNSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            bool syncPts;
            ParamsHelper.InitParam(out syncPts);
            var nRet = MediaPlayer.SwitchAgoraCDNSrc(src, syncPts);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SwitchSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            bool syncPts;
            ParamsHelper.InitParam(out syncPts);
            var nRet = MediaPlayer.SwitchSrc(src, syncPts);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_PreloadSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            long startPos;
            ParamsHelper.InitParam(out startPos);
            var nRet = MediaPlayer.PreloadSrc(src, startPos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_PlayPreloadedSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            var nRet = MediaPlayer.PlayPreloadedSrc(src);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UnloadSrc()
        {
            string src;
            ParamsHelper.InitParam(out src);
            var nRet = MediaPlayer.UnloadSrc(src);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetSpatialAudioParams()
        {
            SpatialAudioParams @params;
            ParamsHelper.InitParam(out @params);
            var nRet = MediaPlayer.SetSpatialAudioParams(@params);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetSoundPositionParams()
        {
            float pan;
            ParamsHelper.InitParam(out pan);
            float gain;
            ParamsHelper.InitParam(out gain);
            var nRet = MediaPlayer.SetSoundPositionParams(pan, gain);

            Assert.AreEqual(nRet, 0);
        }

        #endregion


    }
}
