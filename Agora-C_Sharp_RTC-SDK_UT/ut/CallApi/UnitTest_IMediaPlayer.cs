using NUnit.Framework;
using Agora.Rtc;
namespace Agora.Rtc
{
    using view_t = System.Int64;
    public class UnitTest_IMediaPlayer
    {
        public IRtcEngine Engine;
        public IMediaPlayer MediaPlayer;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            MediaPlayer = Engine.CreateMediaPlayer();
            Assert.AreEqual(MediaPlayer.GetId() > 0, true);
        }

        [TearDown]
        public void TearDown()
        {
            Engine.DestroyMediaPlayer(MediaPlayer);
            Engine.Dispose();
        }

        [Test]
        public void Test_OpenWithCustomSource()
        {
            long startPos = ParamsHelper.CreateParam<long>();
            IMediaPlayerCustomDataProvider provider = new UTMediaPlayerCustomDataProvider(); // ParamsHelper.CreateParam<IMediaPlayerCustomDataProvider>();

            var nRet = MediaPlayer.OpenWithCustomSource(startPos, provider);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_OpenWithMediaSource()
        {
            MediaSource source;
            ParamsHelper.InitParam(out source);

            var nRet = MediaPlayer.OpenWithMediaSource(source);
            Assert.AreEqual(0, nRet);
        }

        #region terra IMediaPlayer

        [Test]
        public void Test_Open()
        {
            string url = ParamsHelper.CreateParam<string>();
            long startPos = ParamsHelper.CreateParam<long>();

            var nRet = MediaPlayer.Open(url, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Play()
        {


            var nRet = MediaPlayer.Play();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Pause()
        {


            var nRet = MediaPlayer.Pause();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Stop()
        {


            var nRet = MediaPlayer.Stop();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Resume()
        {


            var nRet = MediaPlayer.Resume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Seek()
        {
            long newPos = ParamsHelper.CreateParam<long>();

            var nRet = MediaPlayer.Seek(newPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioPitch()
        {
            int pitch = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.SetAudioPitch(pitch);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetDuration()
        {
            long duration = ParamsHelper.CreateParam<long>();

            var nRet = MediaPlayer.GetDuration(ref duration);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlayPosition()
        {
            long pos = ParamsHelper.CreateParam<long>();

            var nRet = MediaPlayer.GetPlayPosition(ref pos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetStreamCount()
        {
            long count = ParamsHelper.CreateParam<long>();

            var nRet = MediaPlayer.GetStreamCount(ref count);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetStreamInfo()
        {
            long index = ParamsHelper.CreateParam<long>();
            PlayerStreamInfo info = ParamsHelper.CreateParam<PlayerStreamInfo>();

            var nRet = MediaPlayer.GetStreamInfo(index, ref info);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLoopCount()
        {
            int loopCount = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.SetLoopCount(loopCount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlaybackSpeed()
        {
            int speed = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.SetPlaybackSpeed(speed);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SelectAudioTrack()
        {
            int index = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.SelectAudioTrack(index);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlayerOption()
        {
            string key = ParamsHelper.CreateParam<string>();
            int value = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.SetPlayerOption(key, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlayerOption2()
        {
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();

            var nRet = MediaPlayer.SetPlayerOption(key, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_TakeScreenshot()
        {
            string filename = ParamsHelper.CreateParam<string>();

            var nRet = MediaPlayer.TakeScreenshot(filename);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SelectInternalSubtitle()
        {
            int index = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.SelectInternalSubtitle(index);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExternalSubtitle()
        {
            string url = ParamsHelper.CreateParam<string>();

            var nRet = MediaPlayer.SetExternalSubtitle(url);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetState()
        {


            var nRet = MediaPlayer.GetState();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Mute()
        {
            bool muted = ParamsHelper.CreateParam<bool>();

            var nRet = MediaPlayer.Mute(muted);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetMute()
        {
            bool muted = ParamsHelper.CreateParam<bool>();

            var nRet = MediaPlayer.GetMute(ref muted);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustPlayoutVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.AdjustPlayoutVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlayoutVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.GetPlayoutVolume(ref volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustPublishSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.AdjustPublishSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPublishSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.GetPublishSignalVolume(ref volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetView()
        {
            view_t view = ParamsHelper.CreateParam<view_t>();

            var nRet = MediaPlayer.SetView(view);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRenderMode()
        {
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();

            var nRet = MediaPlayer.SetRenderMode(renderMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RegisterAudioFrameObserver()
        {
            IAudioPcmFrameSink observer = ParamsHelper.CreateParam<IAudioPcmFrameSink>();

            var nRet = MediaPlayer.RegisterAudioFrameObserver(observer);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RegisterAudioFrameObserver2()
        {
            IAudioPcmFrameSink observer = ParamsHelper.CreateParam<IAudioPcmFrameSink>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();

            var nRet = MediaPlayer.RegisterAudioFrameObserver(observer, mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnregisterAudioFrameObserver()
        {


            var nRet = MediaPlayer.UnregisterAudioFrameObserver();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RegisterMediaPlayerAudioSpectrumObserver()
        {
            IAudioSpectrumObserver observer = ParamsHelper.CreateParam<IAudioSpectrumObserver>();
            int intervalInMS = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.RegisterMediaPlayerAudioSpectrumObserver(observer, intervalInMS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnregisterMediaPlayerAudioSpectrumObserver()
        {


            var nRet = MediaPlayer.UnregisterMediaPlayerAudioSpectrumObserver();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioDualMonoMode()
        {
            AUDIO_DUAL_MONO_MODE mode = ParamsHelper.CreateParam<AUDIO_DUAL_MONO_MODE>();

            var nRet = MediaPlayer.SetAudioDualMonoMode(mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlayerSdkVersion()
        {


            var nRet = MediaPlayer.GetPlayerSdkVersion();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlaySrc()
        {


            var nRet = MediaPlayer.GetPlaySrc();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_OpenWithAgoraCDNSrc()
        {
            string src = ParamsHelper.CreateParam<string>();
            long startPos = ParamsHelper.CreateParam<long>();

            var nRet = MediaPlayer.OpenWithAgoraCDNSrc(src, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAgoraCDNLineCount()
        {


            var nRet = MediaPlayer.GetAgoraCDNLineCount();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SwitchAgoraCDNLineByIndex()
        {
            int index = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayer.SwitchAgoraCDNLineByIndex(index);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCurrentAgoraCDNIndex()
        {


            var nRet = MediaPlayer.GetCurrentAgoraCDNIndex();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAutoSwitchAgoraCDN()
        {
            bool enable = ParamsHelper.CreateParam<bool>();

            var nRet = MediaPlayer.EnableAutoSwitchAgoraCDN(enable);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RenewAgoraCDNSrcToken()
        {
            string token = ParamsHelper.CreateParam<string>();
            long ts = ParamsHelper.CreateParam<long>();

            var nRet = MediaPlayer.RenewAgoraCDNSrcToken(token, ts);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SwitchAgoraCDNSrc()
        {
            string src = ParamsHelper.CreateParam<string>();
            bool syncPts = ParamsHelper.CreateParam<bool>();

            var nRet = MediaPlayer.SwitchAgoraCDNSrc(src, syncPts);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SwitchSrc()
        {
            string src = ParamsHelper.CreateParam<string>();
            bool syncPts = ParamsHelper.CreateParam<bool>();

            var nRet = MediaPlayer.SwitchSrc(src, syncPts);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PreloadSrc()
        {
            string src = ParamsHelper.CreateParam<string>();
            long startPos = ParamsHelper.CreateParam<long>();

            var nRet = MediaPlayer.PreloadSrc(src, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PlayPreloadedSrc()
        {
            string src = ParamsHelper.CreateParam<string>();

            var nRet = MediaPlayer.PlayPreloadedSrc(src);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnloadSrc()
        {
            string src = ParamsHelper.CreateParam<string>();

            var nRet = MediaPlayer.UnloadSrc(src);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSpatialAudioParams()
        {
            SpatialAudioParams @params = ParamsHelper.CreateParam<SpatialAudioParams>();

            var nRet = MediaPlayer.SetSpatialAudioParams(@params);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSoundPositionParams()
        {
            float pan = ParamsHelper.CreateParam<float>();
            float gain = ParamsHelper.CreateParam<float>();

            var nRet = MediaPlayer.SetSoundPositionParams(pan, gain);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IMediaPlayer
    }
}
