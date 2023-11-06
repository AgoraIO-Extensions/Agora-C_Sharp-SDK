using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc
{
    using uid_t = System.UInt32;
    using view_t = System.Int64;
    [TestFixture]
    class UnitTest_IRtcEngine
    {
        public IRtcEngine RtcEngine;
        public IRtcEngineBase RtcEngineBase;
        public IRtcEngine MediaEngine;
        public IRtcEngine MediaEngineBase;
        [SetUp]
        public void Setup()
        {
            RtcEngine = Rtc.RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineBase = RtcEngine;
            MediaEngine = RtcEngine;
            MediaEngineBase = MediaEngine;
            RtcEngineContext rtcEngineContext = ParamsHelper.CreateParam<RtcEngineContext>();
            int nRet = RtcEngine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { RtcEngine.Dispose(); }

        [Test]
        public void Test_SetParameters1()
        {
            string parameters = ParamsHelper.CreateParam<string>();
            var nRet = RtcEngine.SetParameters(parameters);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetParameters2()
        {
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();
            var nRet = RtcEngine.SetParameters(key, value);
            Assert.AreEqual(0, nRet);

            float value2 = ParamsHelper.CreateParam<float>();
            nRet = RtcEngine.SetParameters(key, value2);
            Assert.AreEqual(0, nRet);

            bool value3 = ParamsHelper.CreateParam<bool>();
            nRet = RtcEngine.SetParameters(key, value3);
            Assert.AreEqual(0, nRet);

            int value4 = ParamsHelper.CreateParam<int>();
            nRet = RtcEngine.SetParameters(key, value4);
            Assert.AreEqual(0, nRet);
        }

        #region terra IRtcEngineBase
        [Test]
        public void Test_IRtcEngineBaseGetVersion()
        {
            int build = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.GetVersion(ref build);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetErrorDescription()
        {
            int code = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.GetErrorDescription(code);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseQueryCodecCapability()
        {
            CodecCapInfo[] codecInfo = ParamsHelper.CreateParam<CodecCapInfo[]>();
            int size = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.QueryCodecCapability(ref codecInfo, ref size);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseQueryDeviceScore()
        {


            var nRet = RtcEngineBase.QueryDeviceScore();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseUpdateChannelMediaOptions()
        {
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngineBase.UpdateChannelMediaOptions(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseLeaveChannel()
        {


            var nRet = RtcEngineBase.LeaveChannel();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseLeaveChannel2()
        {
            LeaveChannelOptions options = ParamsHelper.CreateParam<LeaveChannelOptions>();

            var nRet = RtcEngineBase.LeaveChannel(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseRenewToken()
        {
            string token = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.RenewToken(token);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetChannelProfile()
        {
            CHANNEL_PROFILE_TYPE profile = ParamsHelper.CreateParam<CHANNEL_PROFILE_TYPE>();

            var nRet = RtcEngineBase.SetChannelProfile(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetClientRole()
        {
            CLIENT_ROLE_TYPE role = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();

            var nRet = RtcEngineBase.SetClientRole(role);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetClientRole2()
        {
            CLIENT_ROLE_TYPE role = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();
            ClientRoleOptions options = ParamsHelper.CreateParam<ClientRoleOptions>();

            var nRet = RtcEngineBase.SetClientRole(role, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartEchoTest()
        {


            var nRet = RtcEngineBase.StartEchoTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartEchoTest2()
        {
            int intervalInSeconds = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.StartEchoTest(intervalInSeconds);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartEchoTest3()
        {
            EchoTestConfiguration config = ParamsHelper.CreateParam<EchoTestConfiguration>();

            var nRet = RtcEngineBase.StartEchoTest(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopEchoTest()
        {


            var nRet = RtcEngineBase.StopEchoTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableMultiCamera()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngineBase.EnableMultiCamera(enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableVideo()
        {


            var nRet = RtcEngineBase.EnableVideo();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseDisableVideo()
        {


            var nRet = RtcEngineBase.DisableVideo();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartPreview()
        {


            var nRet = RtcEngineBase.StartPreview();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngineBase.StartPreview(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopPreview()
        {


            var nRet = RtcEngineBase.StopPreview();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngineBase.StopPreview(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartLastmileProbeTest()
        {
            LastmileProbeConfig config = ParamsHelper.CreateParam<LastmileProbeConfig>();

            var nRet = RtcEngineBase.StartLastmileProbeTest(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopLastmileProbeTest()
        {


            var nRet = RtcEngineBase.StopLastmileProbeTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetVideoEncoderConfiguration()
        {
            VideoEncoderConfiguration config = ParamsHelper.CreateParam<VideoEncoderConfiguration>();

            var nRet = RtcEngineBase.SetVideoEncoderConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetBeautyEffectOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            BeautyOptions options = ParamsHelper.CreateParam<BeautyOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngineBase.SetBeautyEffectOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLowlightEnhanceOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            LowlightEnhanceOptions options = ParamsHelper.CreateParam<LowlightEnhanceOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngineBase.SetLowlightEnhanceOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetVideoDenoiserOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            VideoDenoiserOptions options = ParamsHelper.CreateParam<VideoDenoiserOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngineBase.SetVideoDenoiserOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetColorEnhanceOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            ColorEnhanceOptions options = ParamsHelper.CreateParam<ColorEnhanceOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngineBase.SetColorEnhanceOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableVirtualBackground()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            VirtualBackgroundSource backgroundSource = ParamsHelper.CreateParam<VirtualBackgroundSource>();
            SegmentationProperty segproperty = ParamsHelper.CreateParam<SegmentationProperty>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngineBase.EnableVirtualBackground(enabled, backgroundSource, segproperty, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetVideoScenario()
        {
            VIDEO_APPLICATION_SCENARIO_TYPE scenarioType = ParamsHelper.CreateParam<VIDEO_APPLICATION_SCENARIO_TYPE>();

            var nRet = RtcEngineBase.SetVideoScenario(scenarioType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetVideoQoEPreference()
        {
            VIDEO_QOE_PREFERENCE_TYPE qoePreference = ParamsHelper.CreateParam<VIDEO_QOE_PREFERENCE_TYPE>();

            var nRet = RtcEngineBase.SetVideoQoEPreference(qoePreference);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableAudio()
        {


            var nRet = RtcEngineBase.EnableAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseDisableAudio()
        {


            var nRet = RtcEngineBase.DisableAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetAudioProfile()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();

            var nRet = RtcEngineBase.SetAudioProfile(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetAudioScenario()
        {
            AUDIO_SCENARIO_TYPE scenario = ParamsHelper.CreateParam<AUDIO_SCENARIO_TYPE>();

            var nRet = RtcEngineBase.SetAudioScenario(scenario);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableLocalAudio()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.EnableLocalAudio(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseMuteLocalAudioStream()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.MuteLocalAudioStream(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseMuteAllRemoteAudioStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.MuteAllRemoteAudioStreams(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseMuteLocalVideoStream()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.MuteLocalVideoStream(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableLocalVideo()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.EnableLocalVideo(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseMuteAllRemoteVideoStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.MuteAllRemoteVideoStreams(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetRemoteDefaultVideoStreamType()
        {
            VIDEO_STREAM_TYPE streamType = ParamsHelper.CreateParam<VIDEO_STREAM_TYPE>();

            var nRet = RtcEngineBase.SetRemoteDefaultVideoStreamType(streamType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableAudioVolumeIndication()
        {
            int interval = ParamsHelper.CreateParam<int>();
            int smooth = ParamsHelper.CreateParam<int>();
            bool reportVad = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.EnableAudioVolumeIndication(interval, smooth, reportVad);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartAudioRecording()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            AUDIO_RECORDING_QUALITY_TYPE quality = ParamsHelper.CreateParam<AUDIO_RECORDING_QUALITY_TYPE>();

            var nRet = RtcEngineBase.StartAudioRecording(filePath, quality);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartAudioRecording2()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            int sampleRate = ParamsHelper.CreateParam<int>();
            AUDIO_RECORDING_QUALITY_TYPE quality = ParamsHelper.CreateParam<AUDIO_RECORDING_QUALITY_TYPE>();

            var nRet = RtcEngineBase.StartAudioRecording(filePath, sampleRate, quality);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartAudioRecording3()
        {
            AudioRecordingConfiguration config = ParamsHelper.CreateParam<AudioRecordingConfiguration>();

            var nRet = RtcEngineBase.StartAudioRecording(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseRegisterAudioEncodedFrameObserver()
        {
            AudioEncodedFrameObserverConfig config = ParamsHelper.CreateParam<AudioEncodedFrameObserverConfig>();
            IAudioEncodedFrameObserver observer = ParamsHelper.CreateParam<IAudioEncodedFrameObserver>();

            var nRet = RtcEngineBase.RegisterAudioEncodedFrameObserver(config, observer);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopAudioRecording()
        {


            var nRet = RtcEngineBase.StopAudioRecording();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseCreateMediaPlayer()
        {


            var nRet = RtcEngineBase.CreateMediaPlayer();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseDestroyMediaPlayer()
        {
            IMediaPlayer media_player = ParamsHelper.CreateParam<IMediaPlayer>();

            var nRet = RtcEngineBase.DestroyMediaPlayer(media_player);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartAudioMixing()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            bool loopback = ParamsHelper.CreateParam<bool>();
            int cycle = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.StartAudioMixing(filePath, loopback, cycle);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartAudioMixing2()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            bool loopback = ParamsHelper.CreateParam<bool>();
            int cycle = ParamsHelper.CreateParam<int>();
            int startPos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.StartAudioMixing(filePath, loopback, cycle, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopAudioMixing()
        {


            var nRet = RtcEngineBase.StopAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBasePauseAudioMixing()
        {


            var nRet = RtcEngineBase.PauseAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseResumeAudioMixing()
        {


            var nRet = RtcEngineBase.ResumeAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSelectAudioTrack()
        {
            int index = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SelectAudioTrack(index);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetAudioTrackCount()
        {


            var nRet = RtcEngineBase.GetAudioTrackCount();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseAdjustAudioMixingVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.AdjustAudioMixingVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseAdjustAudioMixingPublishVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.AdjustAudioMixingPublishVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetAudioMixingPublishVolume()
        {


            var nRet = RtcEngineBase.GetAudioMixingPublishVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseAdjustAudioMixingPlayoutVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.AdjustAudioMixingPlayoutVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetAudioMixingPlayoutVolume()
        {


            var nRet = RtcEngineBase.GetAudioMixingPlayoutVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetAudioMixingDuration()
        {


            var nRet = RtcEngineBase.GetAudioMixingDuration();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetAudioMixingCurrentPosition()
        {


            var nRet = RtcEngineBase.GetAudioMixingCurrentPosition();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetAudioMixingPosition()
        {
            int pos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetAudioMixingPosition(pos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetAudioMixingDualMonoMode()
        {
            AUDIO_MIXING_DUAL_MONO_MODE mode = ParamsHelper.CreateParam<AUDIO_MIXING_DUAL_MONO_MODE>();

            var nRet = RtcEngineBase.SetAudioMixingDualMonoMode(mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetAudioMixingPitch()
        {
            int pitch = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetAudioMixingPitch(pitch);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetEffectsVolume()
        {


            var nRet = RtcEngineBase.GetEffectsVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetEffectsVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetEffectsVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBasePreloadEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            string filePath = ParamsHelper.CreateParam<string>();
            int startPos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.PreloadEffect(soundId, filePath, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBasePlayEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            string filePath = ParamsHelper.CreateParam<string>();
            int loopCount = ParamsHelper.CreateParam<int>();
            double pitch = ParamsHelper.CreateParam<double>();
            double pan = ParamsHelper.CreateParam<double>();
            int gain = ParamsHelper.CreateParam<int>();
            bool publish = ParamsHelper.CreateParam<bool>();
            int startPos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.PlayEffect(soundId, filePath, loopCount, pitch, pan, gain, publish, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBasePlayAllEffects()
        {
            int loopCount = ParamsHelper.CreateParam<int>();
            double pitch = ParamsHelper.CreateParam<double>();
            double pan = ParamsHelper.CreateParam<double>();
            int gain = ParamsHelper.CreateParam<int>();
            bool publish = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.PlayAllEffects(loopCount, pitch, pan, gain, publish);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetVolumeOfEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.GetVolumeOfEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetVolumeOfEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetVolumeOfEffect(soundId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBasePauseEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.PauseEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBasePauseAllEffects()
        {


            var nRet = RtcEngineBase.PauseAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseResumeEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.ResumeEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseResumeAllEffects()
        {


            var nRet = RtcEngineBase.ResumeAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.StopEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopAllEffects()
        {


            var nRet = RtcEngineBase.StopAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseUnloadEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.UnloadEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseUnloadAllEffects()
        {


            var nRet = RtcEngineBase.UnloadAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetEffectDuration()
        {
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.GetEffectDuration(filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetEffectPosition()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            int pos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetEffectPosition(soundId, pos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetEffectCurrentPosition()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.GetEffectCurrentPosition(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableSoundPositionIndication()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.EnableSoundPositionIndication(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableSpatialAudio()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.EnableSpatialAudio(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetVoiceBeautifierPreset()
        {
            VOICE_BEAUTIFIER_PRESET preset = ParamsHelper.CreateParam<VOICE_BEAUTIFIER_PRESET>();

            var nRet = RtcEngineBase.SetVoiceBeautifierPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetAudioEffectPreset()
        {
            AUDIO_EFFECT_PRESET preset = ParamsHelper.CreateParam<AUDIO_EFFECT_PRESET>();

            var nRet = RtcEngineBase.SetAudioEffectPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetVoiceConversionPreset()
        {
            VOICE_CONVERSION_PRESET preset = ParamsHelper.CreateParam<VOICE_CONVERSION_PRESET>();

            var nRet = RtcEngineBase.SetVoiceConversionPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetAudioEffectParameters()
        {
            AUDIO_EFFECT_PRESET preset = ParamsHelper.CreateParam<AUDIO_EFFECT_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetAudioEffectParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetVoiceBeautifierParameters()
        {
            VOICE_BEAUTIFIER_PRESET preset = ParamsHelper.CreateParam<VOICE_BEAUTIFIER_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetVoiceBeautifierParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetVoiceConversionParameters()
        {
            VOICE_CONVERSION_PRESET preset = ParamsHelper.CreateParam<VOICE_CONVERSION_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetVoiceConversionParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLocalVoicePitch()
        {
            double pitch = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngineBase.SetLocalVoicePitch(pitch);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLocalVoiceFormant()
        {
            double formantRatio = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngineBase.SetLocalVoiceFormant(formantRatio);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLocalVoiceEqualization()
        {
            AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency = ParamsHelper.CreateParam<AUDIO_EQUALIZATION_BAND_FREQUENCY>();
            int bandGain = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetLocalVoiceEqualization(bandFrequency, bandGain);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLocalVoiceReverb()
        {
            AUDIO_REVERB_TYPE reverbKey = ParamsHelper.CreateParam<AUDIO_REVERB_TYPE>();
            int value = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetLocalVoiceReverb(reverbKey, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetHeadphoneEQPreset()
        {
            HEADPHONE_EQUALIZER_PRESET preset = ParamsHelper.CreateParam<HEADPHONE_EQUALIZER_PRESET>();

            var nRet = RtcEngineBase.SetHeadphoneEQPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetHeadphoneEQParameters()
        {
            int lowGain = ParamsHelper.CreateParam<int>();
            int highGain = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetHeadphoneEQParameters(lowGain, highGain);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLogFile()
        {
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.SetLogFile(filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLogFilter()
        {
            uint filter = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngineBase.SetLogFilter(filter);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLogLevel()
        {
            LOG_LEVEL level = ParamsHelper.CreateParam<LOG_LEVEL>();

            var nRet = RtcEngineBase.SetLogLevel(level);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLogFileSize()
        {
            uint fileSizeInKBytes = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngineBase.SetLogFileSize(fileSizeInKBytes);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseUploadLogFile()
        {
            string requestId = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.UploadLogFile(ref requestId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLocalRenderMode()
        {
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngineBase.SetLocalRenderMode(renderMode, mirrorMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLocalRenderMode2()
        {
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();

            var nRet = RtcEngineBase.SetLocalRenderMode(renderMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLocalVideoMirrorMode()
        {
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngineBase.SetLocalVideoMirrorMode(mirrorMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableDualStreamMode()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.EnableDualStreamMode(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableDualStreamMode2()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();

            var nRet = RtcEngineBase.EnableDualStreamMode(enabled, streamConfig);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetDualStreamMode()
        {
            SIMULCAST_STREAM_MODE mode = ParamsHelper.CreateParam<SIMULCAST_STREAM_MODE>();

            var nRet = RtcEngineBase.SetDualStreamMode(mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetDualStreamMode2()
        {
            SIMULCAST_STREAM_MODE mode = ParamsHelper.CreateParam<SIMULCAST_STREAM_MODE>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();

            var nRet = RtcEngineBase.SetDualStreamMode(mode, streamConfig);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableCustomAudioLocalPlayback()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.EnableCustomAudioLocalPlayback(trackId, enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetRecordingAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetRecordingAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetPlaybackAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetPlaybackAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetMixedAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetMixedAudioFrameParameters(sampleRate, channel, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetEarMonitoringAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetEarMonitoringAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetPlaybackAudioFrameBeforeMixingParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetPlaybackAudioFrameBeforeMixingParameters(sampleRate, channel);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableAudioSpectrumMonitor()
        {
            int intervalInMS = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.EnableAudioSpectrumMonitor(intervalInMS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseDisableAudioSpectrumMonitor()
        {


            var nRet = RtcEngineBase.DisableAudioSpectrumMonitor();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseAdjustRecordingSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.AdjustRecordingSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseMuteRecordingSignal()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.MuteRecordingSignal(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseAdjustPlaybackSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.AdjustPlaybackSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLocalPublishFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();

            var nRet = RtcEngineBase.SetLocalPublishFallbackOption(option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetRemoteSubscribeFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();

            var nRet = RtcEngineBase.SetRemoteSubscribeFallbackOption(option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableLoopbackRecording()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            string deviceName = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.EnableLoopbackRecording(enabled, deviceName);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseAdjustLoopbackSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.AdjustLoopbackSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetLoopbackRecordingVolume()
        {


            var nRet = RtcEngineBase.GetLoopbackRecordingVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableInEarMonitoring()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            int includeAudioFilters = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.EnableInEarMonitoring(enabled, includeAudioFilters);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetInEarMonitoringVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetInEarMonitoringVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseLoadExtensionProvider()
        {
            string path = ParamsHelper.CreateParam<string>();
            bool unload_after_use = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.LoadExtensionProvider(path, unload_after_use);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetExtensionProviderProperty()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.SetExtensionProviderProperty(provider, key, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseRegisterExtension()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngineBase.RegisterExtension(provider, extension, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableExtension()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            bool enable = ParamsHelper.CreateParam<bool>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngineBase.EnableExtension(provider, extension, enable, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetExtensionProperty()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngineBase.SetExtensionProperty(provider, extension, key, value, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetExtensionProperty()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();
            int buf_len = ParamsHelper.CreateParam<int>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngineBase.GetExtensionProperty(provider, extension, key, ref value, buf_len, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetCameraCapturerConfiguration()
        {
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngineBase.SetCameraCapturerConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseCreateCustomVideoTrack()
        {


            var nRet = RtcEngineBase.CreateCustomVideoTrack();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseCreateCustomEncodedVideoTrack()
        {
            SenderOptions sender_option = ParamsHelper.CreateParam<SenderOptions>();

            var nRet = RtcEngineBase.CreateCustomEncodedVideoTrack(sender_option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseDestroyCustomVideoTrack()
        {
            uint video_track_id = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngineBase.DestroyCustomVideoTrack(video_track_id);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseDestroyCustomEncodedVideoTrack()
        {
            uint video_track_id = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngineBase.DestroyCustomEncodedVideoTrack(video_track_id);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSwitchCamera()
        {


            var nRet = RtcEngineBase.SwitchCamera();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseIsCameraZoomSupported()
        {


            var nRet = RtcEngineBase.IsCameraZoomSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseIsCameraFaceDetectSupported()
        {


            var nRet = RtcEngineBase.IsCameraFaceDetectSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseIsCameraTorchSupported()
        {


            var nRet = RtcEngineBase.IsCameraTorchSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseIsCameraFocusSupported()
        {


            var nRet = RtcEngineBase.IsCameraFocusSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseIsCameraAutoFocusFaceModeSupported()
        {


            var nRet = RtcEngineBase.IsCameraAutoFocusFaceModeSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetCameraZoomFactor()
        {
            float factor = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngineBase.SetCameraZoomFactor(factor);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableFaceDetection()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.EnableFaceDetection(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetCameraMaxZoomFactor()
        {


            var nRet = RtcEngineBase.GetCameraMaxZoomFactor();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetCameraFocusPositionInPreview()
        {
            float positionX = ParamsHelper.CreateParam<float>();
            float positionY = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngineBase.SetCameraFocusPositionInPreview(positionX, positionY);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetCameraTorchOn()
        {
            bool isOn = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.SetCameraTorchOn(isOn);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetCameraAutoFocusFaceModeEnabled()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.SetCameraAutoFocusFaceModeEnabled(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseIsCameraExposurePositionSupported()
        {


            var nRet = RtcEngineBase.IsCameraExposurePositionSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetCameraExposurePosition()
        {
            float positionXinView = ParamsHelper.CreateParam<float>();
            float positionYinView = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngineBase.SetCameraExposurePosition(positionXinView, positionYinView);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseIsCameraExposureSupported()
        {


            var nRet = RtcEngineBase.IsCameraExposureSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetCameraExposureFactor()
        {
            float factor = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngineBase.SetCameraExposureFactor(factor);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseIsCameraAutoExposureFaceModeSupported()
        {


            var nRet = RtcEngineBase.IsCameraAutoExposureFaceModeSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetCameraAutoExposureFaceModeEnabled()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.SetCameraAutoExposureFaceModeEnabled(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetDefaultAudioRouteToSpeakerphone()
        {
            bool defaultToSpeaker = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.SetDefaultAudioRouteToSpeakerphone(defaultToSpeaker);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetEnableSpeakerphone()
        {
            bool speakerOn = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.SetEnableSpeakerphone(speakerOn);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseIsSpeakerphoneEnabled()
        {


            var nRet = RtcEngineBase.IsSpeakerphoneEnabled();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetRouteInCommunicationMode()
        {
            int route = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetRouteInCommunicationMode(route);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetScreenCaptureSources()
        {
            SIZE thumbSize = ParamsHelper.CreateParam<SIZE>();
            SIZE iconSize = ParamsHelper.CreateParam<SIZE>();
            bool includeScreen = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.GetScreenCaptureSources(thumbSize, iconSize, includeScreen);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetAudioSessionOperationRestriction()
        {
            AUDIO_SESSION_OPERATION_RESTRICTION restriction = ParamsHelper.CreateParam<AUDIO_SESSION_OPERATION_RESTRICTION>();

            var nRet = RtcEngineBase.SetAudioSessionOperationRestriction(restriction);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartScreenCaptureByDisplayId()
        {
            uint displayId = ParamsHelper.CreateParam<uint>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngineBase.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetAudioDeviceInfo()
        {
            DeviceInfoMobile deviceInfo = ParamsHelper.CreateParam<DeviceInfoMobile>();

            var nRet = RtcEngineBase.GetAudioDeviceInfo(ref deviceInfo);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartScreenCaptureByWindowId()
        {
            view_t windowId = ParamsHelper.CreateParam<view_t>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngineBase.StartScreenCaptureByWindowId(windowId, regionRect, captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetScreenCaptureContentHint()
        {
            VIDEO_CONTENT_HINT contentHint = ParamsHelper.CreateParam<VIDEO_CONTENT_HINT>();

            var nRet = RtcEngineBase.SetScreenCaptureContentHint(contentHint);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseUpdateScreenCaptureRegion()
        {
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();

            var nRet = RtcEngineBase.UpdateScreenCaptureRegion(regionRect);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseUpdateScreenCaptureParameters()
        {
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngineBase.UpdateScreenCaptureParameters(captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartScreenCapture()
        {
            ScreenCaptureParameters2 captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters2>();

            var nRet = RtcEngineBase.StartScreenCapture(captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseUpdateScreenCapture()
        {
            ScreenCaptureParameters2 captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters2>();

            var nRet = RtcEngineBase.UpdateScreenCapture(captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseQueryScreenCaptureCapability()
        {


            var nRet = RtcEngineBase.QueryScreenCaptureCapability();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetScreenCaptureScenario()
        {
            SCREEN_SCENARIO_TYPE screenScenario = ParamsHelper.CreateParam<SCREEN_SCENARIO_TYPE>();

            var nRet = RtcEngineBase.SetScreenCaptureScenario(screenScenario);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopScreenCapture()
        {


            var nRet = RtcEngineBase.StopScreenCapture();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetCallId()
        {
            string callId = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.GetCallId(ref callId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseRate()
        {
            string callId = ParamsHelper.CreateParam<string>();
            int rating = ParamsHelper.CreateParam<int>();
            string description = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.Rate(callId, rating, description);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseComplain()
        {
            string callId = ParamsHelper.CreateParam<string>();
            string description = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.Complain(callId, description);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartRtmpStreamWithoutTranscoding()
        {
            string url = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.StartRtmpStreamWithoutTranscoding(url);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopRtmpStream()
        {
            string url = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.StopRtmpStream(url);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopLocalVideoTranscoder()
        {


            var nRet = RtcEngineBase.StopLocalVideoTranscoder();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartCameraCapture()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngineBase.StartCameraCapture(sourceType, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopCameraCapture()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngineBase.StopCameraCapture(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetCameraDeviceOrientation()
        {
            VIDEO_SOURCE_TYPE type = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            VIDEO_ORIENTATION orientation = ParamsHelper.CreateParam<VIDEO_ORIENTATION>();

            var nRet = RtcEngineBase.SetCameraDeviceOrientation(type, orientation);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetScreenCaptureOrientation()
        {
            VIDEO_SOURCE_TYPE type = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            VIDEO_ORIENTATION orientation = ParamsHelper.CreateParam<VIDEO_ORIENTATION>();

            var nRet = RtcEngineBase.SetScreenCaptureOrientation(type, orientation);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartScreenCapture2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            ScreenCaptureConfiguration config = ParamsHelper.CreateParam<ScreenCaptureConfiguration>();

            var nRet = RtcEngineBase.StartScreenCapture(sourceType, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopScreenCapture2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngineBase.StopScreenCapture(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetConnectionState()
        {


            var nRet = RtcEngineBase.GetConnectionState();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableEncryption()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            EncryptionConfig config = ParamsHelper.CreateParam<EncryptionConfig>();

            var nRet = RtcEngineBase.EnableEncryption(enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseCreateDataStream()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            bool reliable = ParamsHelper.CreateParam<bool>();
            bool ordered = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.CreateDataStream(ref streamId, reliable, ordered);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseCreateDataStream2()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            DataStreamConfig config = ParamsHelper.CreateParam<DataStreamConfig>();

            var nRet = RtcEngineBase.CreateDataStream(ref streamId, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSendStreamMessage()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            byte[] data = ParamsHelper.CreateParam<byte[]>();
            uint length = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngineBase.SendStreamMessage(streamId, data, length);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseAddVideoWatermark()
        {
            string watermarkUrl = ParamsHelper.CreateParam<string>();
            WatermarkOptions options = ParamsHelper.CreateParam<WatermarkOptions>();

            var nRet = RtcEngineBase.AddVideoWatermark(watermarkUrl, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseClearVideoWatermarks()
        {


            var nRet = RtcEngineBase.ClearVideoWatermarks();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSendCustomReportMessage()
        {
            string id = ParamsHelper.CreateParam<string>();
            string category = ParamsHelper.CreateParam<string>();
            string @event = ParamsHelper.CreateParam<string>();
            string label = ParamsHelper.CreateParam<string>();
            int value = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SendCustomReportMessage(id, category, @event, label, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetAINSMode()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            AUDIO_AINS_MODE mode = ParamsHelper.CreateParam<AUDIO_AINS_MODE>();

            var nRet = RtcEngineBase.SetAINSMode(enabled, mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopChannelMediaRelay()
        {


            var nRet = RtcEngineBase.StopChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBasePauseAllChannelMediaRelay()
        {


            var nRet = RtcEngineBase.PauseAllChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseResumeAllChannelMediaRelay()
        {


            var nRet = RtcEngineBase.ResumeAllChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetDirectCdnStreamingAudioConfiguration()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();

            var nRet = RtcEngineBase.SetDirectCdnStreamingAudioConfiguration(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetDirectCdnStreamingVideoConfiguration()
        {
            VideoEncoderConfiguration config = ParamsHelper.CreateParam<VideoEncoderConfiguration>();

            var nRet = RtcEngineBase.SetDirectCdnStreamingVideoConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartDirectCdnStreaming()
        {
            string publishUrl = ParamsHelper.CreateParam<string>();
            DirectCdnStreamingMediaOptions options = ParamsHelper.CreateParam<DirectCdnStreamingMediaOptions>();

            var nRet = RtcEngineBase.StartDirectCdnStreaming(publishUrl, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopDirectCdnStreaming()
        {


            var nRet = RtcEngineBase.StopDirectCdnStreaming();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseUpdateDirectCdnStreamingMediaOptions()
        {
            DirectCdnStreamingMediaOptions options = ParamsHelper.CreateParam<DirectCdnStreamingMediaOptions>();

            var nRet = RtcEngineBase.UpdateDirectCdnStreamingMediaOptions(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartRhythmPlayer()
        {
            string sound1 = ParamsHelper.CreateParam<string>();
            string sound2 = ParamsHelper.CreateParam<string>();
            AgoraRhythmPlayerConfig config = ParamsHelper.CreateParam<AgoraRhythmPlayerConfig>();

            var nRet = RtcEngineBase.StartRhythmPlayer(sound1, sound2, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStopRhythmPlayer()
        {


            var nRet = RtcEngineBase.StopRhythmPlayer();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseConfigRhythmPlayer()
        {
            AgoraRhythmPlayerConfig config = ParamsHelper.CreateParam<AgoraRhythmPlayerConfig>();

            var nRet = RtcEngineBase.ConfigRhythmPlayer(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableContentInspect()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            ContentInspectConfig config = ParamsHelper.CreateParam<ContentInspectConfig>();

            var nRet = RtcEngineBase.EnableContentInspect(enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseAdjustCustomAudioPublishVolume()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.AdjustCustomAudioPublishVolume(trackId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseAdjustCustomAudioPlayoutVolume()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.AdjustCustomAudioPlayoutVolume(trackId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetCloudProxy()
        {
            CLOUD_PROXY_TYPE proxyType = ParamsHelper.CreateParam<CLOUD_PROXY_TYPE>();

            var nRet = RtcEngineBase.SetCloudProxy(proxyType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetLocalAccessPoint()
        {
            LocalAccessPointConfiguration config = ParamsHelper.CreateParam<LocalAccessPointConfiguration>();

            var nRet = RtcEngineBase.SetLocalAccessPoint(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetAdvancedAudioOptions()
        {
            AdvancedAudioOptions options = ParamsHelper.CreateParam<AdvancedAudioOptions>();
            int sourceType = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngineBase.SetAdvancedAudioOptions(options, sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableVideoImageSource()
        {
            bool enable = ParamsHelper.CreateParam<bool>();
            ImageTrackOptions options = ParamsHelper.CreateParam<ImageTrackOptions>();

            var nRet = RtcEngineBase.EnableVideoImageSource(enable, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetCurrentMonotonicTimeInMs()
        {


            var nRet = RtcEngineBase.GetCurrentMonotonicTimeInMs();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableWirelessAccelerate()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngineBase.EnableWirelessAccelerate(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetNetworkType()
        {


            var nRet = RtcEngineBase.GetNetworkType();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseSetParameters()
        {
            string parameters = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineBase.SetParameters(parameters);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseStartMediaRenderingTracing()
        {


            var nRet = RtcEngineBase.StartMediaRenderingTracing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseEnableInstantMediaRendering()
        {


            var nRet = RtcEngineBase.EnableInstantMediaRendering();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseGetNtpWallTimeInMs()
        {


            var nRet = RtcEngineBase.GetNtpWallTimeInMs();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineBaseIsFeatureAvailableOnDevice()
        {
            FeatureType type = ParamsHelper.CreateParam<FeatureType>();

            var nRet = RtcEngineBase.IsFeatureAvailableOnDevice(type);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IRtcEngineBase

        #region terra IRtcEngine
        [Test]
        public void Test_IRtcEngineInitialize()
        {
            RtcEngineContext context = ParamsHelper.CreateParam<RtcEngineContext>();

            var nRet = RtcEngine.Initialize(context);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEnginePreloadChannel()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.PreloadChannel(token, channelId, uid);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEnginePreloadChannel2()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.PreloadChannel(token, channelId, userAccount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUpdatePreloadChannelToken()
        {
            string token = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.UpdatePreloadChannelToken(token);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineJoinChannel()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string info = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.JoinChannel(token, channelId, info, uid);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineJoinChannel2()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngine.JoinChannel(token, channelId, uid, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetupRemoteVideo()
        {
            VideoCanvas canvas = ParamsHelper.CreateParam<VideoCanvas>();

            var nRet = RtcEngine.SetupRemoteVideo(canvas);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetupLocalVideo()
        {
            VideoCanvas canvas = ParamsHelper.CreateParam<VideoCanvas>();

            var nRet = RtcEngine.SetupLocalVideo(canvas);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetAudioProfile()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();
            AUDIO_SCENARIO_TYPE scenario = ParamsHelper.CreateParam<AUDIO_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetAudioProfile(profile, scenario);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetDefaultMuteAllRemoteAudioStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetDefaultMuteAllRemoteAudioStreams(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineMuteRemoteAudioStream()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteRemoteAudioStream(uid, mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetDefaultMuteAllRemoteVideoStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetDefaultMuteAllRemoteVideoStreams(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineMuteRemoteVideoStream()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteRemoteVideoStream(uid, mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetRemoteVideoStreamType()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            VIDEO_STREAM_TYPE streamType = ParamsHelper.CreateParam<VIDEO_STREAM_TYPE>();

            var nRet = RtcEngine.SetRemoteVideoStreamType(uid, streamType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetRemoteVideoSubscriptionOptions()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            VideoSubscriptionOptions options = ParamsHelper.CreateParam<VideoSubscriptionOptions>();

            var nRet = RtcEngine.SetRemoteVideoSubscriptionOptions(uid, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetSubscribeAudioBlocklist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeAudioBlocklist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetSubscribeAudioAllowlist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeAudioAllowlist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetSubscribeVideoBlocklist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeVideoBlocklist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetSubscribeVideoAllowlist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeVideoAllowlist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineCreateMediaRecorder()
        {
            RecorderStreamInfo info = ParamsHelper.CreateParam<RecorderStreamInfo>();

            var nRet = RtcEngine.CreateMediaRecorder(info);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineDestroyMediaRecorder()
        {
            IMediaRecorder mediaRecorder = ParamsHelper.CreateParam<IMediaRecorder>();

            var nRet = RtcEngine.DestroyMediaRecorder(mediaRecorder);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetRemoteVoicePosition()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            double pan = ParamsHelper.CreateParam<double>();
            double gain = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngine.SetRemoteVoicePosition(uid, pan, gain);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetRemoteUserSpatialAudioParams()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            SpatialAudioParams @params = ParamsHelper.CreateParam<SpatialAudioParams>();

            var nRet = RtcEngine.SetRemoteUserSpatialAudioParams(uid, @params);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetRemoteRenderMode()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngine.SetRemoteRenderMode(uid, renderMode, mirrorMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineRegisterAudioSpectrumObserver()
        {
            IAudioSpectrumObserver observer = ParamsHelper.CreateParam<IAudioSpectrumObserver>();

            var nRet = RtcEngine.RegisterAudioSpectrumObserver(observer);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUnregisterAudioSpectrumObserver()
        {


            var nRet = RtcEngine.UnregisterAudioSpectrumObserver();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineAdjustUserPlaybackSignalVolume()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustUserPlaybackSignalVolume(uid, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetHighPriorityUserList()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNum = ParamsHelper.CreateParam<int>();
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();

            var nRet = RtcEngine.SetHighPriorityUserList(uidList, uidNum, option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableExtension()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            ExtensionInfo extensionInfo = ParamsHelper.CreateParam<ExtensionInfo>();
            bool enable = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableExtension(provider, extension, extensionInfo, enable);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetExtensionProperty()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            ExtensionInfo extensionInfo = ParamsHelper.CreateParam<ExtensionInfo>();
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetExtensionProperty(provider, extension, extensionInfo, key, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetExtensionProperty()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            ExtensionInfo extensionInfo = ParamsHelper.CreateParam<ExtensionInfo>();
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();
            int buf_len = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetExtensionProperty(provider, extension, extensionInfo, key, ref value, buf_len);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartRtmpStreamWithTranscoding()
        {
            string url = ParamsHelper.CreateParam<string>();
            LiveTranscoding transcoding = ParamsHelper.CreateParam<LiveTranscoding>();

            var nRet = RtcEngine.StartRtmpStreamWithTranscoding(url, transcoding);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUpdateRtmpTranscoding()
        {
            LiveTranscoding transcoding = ParamsHelper.CreateParam<LiveTranscoding>();

            var nRet = RtcEngine.UpdateRtmpTranscoding(transcoding);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartLocalVideoTranscoder()
        {
            LocalTranscoderConfiguration config = ParamsHelper.CreateParam<LocalTranscoderConfiguration>();

            var nRet = RtcEngine.StartLocalVideoTranscoder(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUpdateLocalTranscoderConfiguration()
        {
            LocalTranscoderConfiguration config = ParamsHelper.CreateParam<LocalTranscoderConfiguration>();

            var nRet = RtcEngine.UpdateLocalTranscoderConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetRemoteUserPriority()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            PRIORITY_TYPE userPriority = ParamsHelper.CreateParam<PRIORITY_TYPE>();

            var nRet = RtcEngine.SetRemoteUserPriority(uid, userPriority);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetEncryptionMode()
        {
            string encryptionMode = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetEncryptionMode(encryptionMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetEncryptionSecret()
        {
            string secret = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetEncryptionSecret(secret);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineAddVideoWatermark()
        {
            RtcImage watermark = ParamsHelper.CreateParam<RtcImage>();

            var nRet = RtcEngine.AddVideoWatermark(watermark);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEnginePauseAudio()
        {


            var nRet = RtcEngine.PauseAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineResumeAudio()
        {


            var nRet = RtcEngine.ResumeAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableWebSdkInteroperability()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableWebSdkInteroperability(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineRegisterMediaMetadataObserver()
        {
            IMetadataObserver observer = ParamsHelper.CreateParam<IMetadataObserver>();
            METADATA_TYPE type = ParamsHelper.CreateParam<METADATA_TYPE>();

            var nRet = RtcEngine.RegisterMediaMetadataObserver(observer, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUnregisterMediaMetadataObserver()
        {


            var nRet = RtcEngine.UnregisterMediaMetadataObserver();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartAudioFrameDump()
        {
            string channel_id = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();
            string location = ParamsHelper.CreateParam<string>();
            string uuid = ParamsHelper.CreateParam<string>();
            string passwd = ParamsHelper.CreateParam<string>();
            long duration_ms = ParamsHelper.CreateParam<long>();
            bool auto_upload = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.StartAudioFrameDump(channel_id, uid, location, uuid, passwd, duration_ms, auto_upload);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopAudioFrameDump()
        {
            string channel_id = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();
            string location = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.StopAudioFrameDump(channel_id, uid, location);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineRegisterLocalUserAccount()
        {
            string appId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.RegisterLocalUserAccount(appId, userAccount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineJoinChannelWithUserAccount()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.JoinChannelWithUserAccount(token, channelId, userAccount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineJoinChannelWithUserAccount2()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngine.JoinChannelWithUserAccount(token, channelId, userAccount, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetUserInfoByUserAccount()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            UserInfo userInfo = ParamsHelper.CreateParam<UserInfo>();

            var nRet = RtcEngine.GetUserInfoByUserAccount(userAccount, ref userInfo);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetUserInfoByUid()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            UserInfo userInfo = ParamsHelper.CreateParam<UserInfo>();

            var nRet = RtcEngine.GetUserInfoByUid(uid, ref userInfo);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartOrUpdateChannelMediaRelay()
        {
            ChannelMediaRelayConfiguration configuration = ParamsHelper.CreateParam<ChannelMediaRelayConfiguration>();

            var nRet = RtcEngine.StartOrUpdateChannelMediaRelay(configuration);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartChannelMediaRelay()
        {
            ChannelMediaRelayConfiguration configuration = ParamsHelper.CreateParam<ChannelMediaRelayConfiguration>();

            var nRet = RtcEngine.StartChannelMediaRelay(configuration);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUpdateChannelMediaRelay()
        {
            ChannelMediaRelayConfiguration configuration = ParamsHelper.CreateParam<ChannelMediaRelayConfiguration>();

            var nRet = RtcEngine.UpdateChannelMediaRelay(configuration);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineTakeSnapshot()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.TakeSnapshot(uid, filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetAVSyncSource()
        {
            string channelId = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SetAVSyncSource(channelId, uid);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartScreenCaptureByScreenRect()
        {
            Rectangle screenRect = ParamsHelper.CreateParam<Rectangle>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.StartScreenCaptureByScreenRect(screenRect, regionRect, captureParams);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IRtcEngine

        #region terra IMediaEngineBase
        [Test]
        public void Test_IMediaEngineBasePushAudioFrame()
        {
            AudioFrame frame = ParamsHelper.CreateParam<AudioFrame>();
            uint trackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngineBase.PushAudioFrame(frame, trackId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngineBasePullAudioFrame()
        {
            AudioFrame frame = ParamsHelper.CreateParam<AudioFrame>();

            var nRet = MediaEngineBase.PullAudioFrame(frame);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngineBaseSetExternalVideoSource()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            bool useTexture = ParamsHelper.CreateParam<bool>();
            EXTERNAL_VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<EXTERNAL_VIDEO_SOURCE_TYPE>();
            SenderOptions encodedVideoOption = ParamsHelper.CreateParam<SenderOptions>();

            var nRet = MediaEngineBase.SetExternalVideoSource(enabled, useTexture, sourceType, encodedVideoOption);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngineBaseSetExternalAudioSource()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channels = ParamsHelper.CreateParam<int>();
            bool localPlayback = ParamsHelper.CreateParam<bool>();
            bool publish = ParamsHelper.CreateParam<bool>();

            var nRet = MediaEngineBase.SetExternalAudioSource(enabled, sampleRate, channels, localPlayback, publish);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngineBaseCreateCustomAudioTrack()
        {
            AUDIO_TRACK_TYPE trackType = ParamsHelper.CreateParam<AUDIO_TRACK_TYPE>();
            AudioTrackConfig config = ParamsHelper.CreateParam<AudioTrackConfig>();

            var nRet = MediaEngineBase.CreateCustomAudioTrack(trackType, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngineBaseDestroyCustomAudioTrack()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngineBase.DestroyCustomAudioTrack(trackId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngineBaseSetExternalAudioSink()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channels = ParamsHelper.CreateParam<int>();

            var nRet = MediaEngineBase.SetExternalAudioSink(enabled, sampleRate, channels);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngineBasePushVideoFrame()
        {
            ExternalVideoFrame frame = ParamsHelper.CreateParam<ExternalVideoFrame>();
            uint videoTrackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngineBase.PushVideoFrame(frame, videoTrackId);
            Assert.AreEqual(0, nRet);
        }


        #endregion terra IMediaEngineBase

        #region terra IMediaEngine
        [Test]
        public void Test_IMediaEnginePushEncodedVideoImage()
        {
            byte[] imageBuffer = ParamsHelper.CreateParam<byte[]>();
            ulong length = ParamsHelper.CreateParam<ulong>();
            EncodedVideoFrameInfo videoEncodedFrameInfo = ParamsHelper.CreateParam<EncodedVideoFrameInfo>();
            uint videoTrackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngine.PushEncodedVideoImage(imageBuffer, length, videoEncodedFrameInfo, videoTrackId);
            Assert.AreEqual(0, nRet);
        }


        #endregion terra IMediaEngine
    }

}