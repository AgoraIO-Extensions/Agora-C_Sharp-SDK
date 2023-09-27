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
        public IRtcEngine MediaEngine;

        [SetUp]
        public void Setup()
        {
            RtcEngine = Rtc.RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            MediaEngine = RtcEngine;
            RtcEngineContext rtcEngineContext = ParamsHelper.CreateParam<RtcEngineContext>();
            int nRet = RtcEngine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { RtcEngine.Dispose(); }

        [Test]
        public void Test_SetParameters1()
        {
            string parameters;
            ParamsHelper.InitParam(out parameters);

            var nRet = RtcEngine.SetParameters(parameters);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetParameters2()
        {
            string key;
            ParamsHelper.InitParam(out key);

            string value;
            ParamsHelper.InitParam(out value);
            var nRet = RtcEngine.SetParameters(key, value);
            Assert.AreEqual(0, nRet);

            float value2;
            ParamsHelper.InitParam(out value2);
            nRet = RtcEngine.SetParameters(key, value2);
            Assert.AreEqual(0, nRet);

            bool value3;
            ParamsHelper.InitParam(out value3);
            nRet = RtcEngine.SetParameters(key, value3);
            Assert.AreEqual(0, nRet);

            int value4;
            ParamsHelper.InitParam(out value4);
            nRet = RtcEngine.SetParameters(key, value4);
            Assert.AreEqual(0, nRet);
        }

        #region terra IRtcEngine

        [Test]
        public void Test_Initialize()
        {
            RtcEngineContext context = ParamsHelper.CreateParam<RtcEngineContext>();

            var nRet = RtcEngine.Initialize(context);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetVersion()
        {
            int build = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetVersion(ref build);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetErrorDescription()
        {
            int code = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetErrorDescription(code);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_QueryCodecCapability()
        {
            CodecCapInfo[] codecInfo = ParamsHelper.CreateParam<CodecCapInfo[]>();
            int size = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.QueryCodecCapability(ref codecInfo, ref size);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PreloadChannel()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.PreloadChannel(token, channelId, uid);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PreloadChannel2()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.PreloadChannel(token, channelId, userAccount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdatePreloadChannelToken()
        {
            string token = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.UpdatePreloadChannelToken(token);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_JoinChannel()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string info = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.JoinChannel(token, channelId, info, uid);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_JoinChannel2()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngine.JoinChannel(token, channelId, uid, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateChannelMediaOptions()
        {
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngine.UpdateChannelMediaOptions(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LeaveChannel()
        {


            var nRet = RtcEngine.LeaveChannel();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LeaveChannel2()
        {
            LeaveChannelOptions options = ParamsHelper.CreateParam<LeaveChannelOptions>();

            var nRet = RtcEngine.LeaveChannel(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RenewToken()
        {
            string token = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.RenewToken(token);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetChannelProfile()
        {
            CHANNEL_PROFILE_TYPE profile = ParamsHelper.CreateParam<CHANNEL_PROFILE_TYPE>();

            var nRet = RtcEngine.SetChannelProfile(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetClientRole()
        {
            CLIENT_ROLE_TYPE role = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();

            var nRet = RtcEngine.SetClientRole(role);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetClientRole2()
        {
            CLIENT_ROLE_TYPE role = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();
            ClientRoleOptions options = ParamsHelper.CreateParam<ClientRoleOptions>();

            var nRet = RtcEngine.SetClientRole(role, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartEchoTest()
        {


            var nRet = RtcEngine.StartEchoTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartEchoTest2()
        {
            int intervalInSeconds = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.StartEchoTest(intervalInSeconds);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartEchoTest3()
        {
            EchoTestConfiguration config = ParamsHelper.CreateParam<EchoTestConfiguration>();

            var nRet = RtcEngine.StartEchoTest(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopEchoTest()
        {


            var nRet = RtcEngine.StopEchoTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableMultiCamera()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngine.EnableMultiCamera(enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableVideo()
        {


            var nRet = RtcEngine.EnableVideo();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DisableVideo()
        {


            var nRet = RtcEngine.DisableVideo();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartPreview()
        {


            var nRet = RtcEngine.StartPreview();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StartPreview(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopPreview()
        {


            var nRet = RtcEngine.StopPreview();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StopPreview(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartLastmileProbeTest()
        {
            LastmileProbeConfig config = ParamsHelper.CreateParam<LastmileProbeConfig>();

            var nRet = RtcEngine.StartLastmileProbeTest(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopLastmileProbeTest()
        {


            var nRet = RtcEngine.StopLastmileProbeTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVideoEncoderConfiguration()
        {
            VideoEncoderConfiguration config = ParamsHelper.CreateParam<VideoEncoderConfiguration>();

            var nRet = RtcEngine.SetVideoEncoderConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetBeautyEffectOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            BeautyOptions options = ParamsHelper.CreateParam<BeautyOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetBeautyEffectOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLowlightEnhanceOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            LowlightEnhanceOptions options = ParamsHelper.CreateParam<LowlightEnhanceOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetLowlightEnhanceOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVideoDenoiserOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            VideoDenoiserOptions options = ParamsHelper.CreateParam<VideoDenoiserOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetVideoDenoiserOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetColorEnhanceOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            ColorEnhanceOptions options = ParamsHelper.CreateParam<ColorEnhanceOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetColorEnhanceOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableVirtualBackground()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            VirtualBackgroundSource backgroundSource = ParamsHelper.CreateParam<VirtualBackgroundSource>();
            SegmentationProperty segproperty = ParamsHelper.CreateParam<SegmentationProperty>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.EnableVirtualBackground(enabled, backgroundSource, segproperty, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetupRemoteVideo()
        {
            VideoCanvas canvas = ParamsHelper.CreateParam<VideoCanvas>();

            var nRet = RtcEngine.SetupRemoteVideo(canvas);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetupLocalVideo()
        {
            VideoCanvas canvas = ParamsHelper.CreateParam<VideoCanvas>();

            var nRet = RtcEngine.SetupLocalVideo(canvas);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVideoScenario()
        {
            VIDEO_APPLICATION_SCENARIO_TYPE scenarioType = ParamsHelper.CreateParam<VIDEO_APPLICATION_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetVideoScenario(scenarioType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAudio()
        {


            var nRet = RtcEngine.EnableAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DisableAudio()
        {


            var nRet = RtcEngine.DisableAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioProfile()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();
            AUDIO_SCENARIO_TYPE scenario = ParamsHelper.CreateParam<AUDIO_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetAudioProfile(profile, scenario);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioProfile2()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();

            var nRet = RtcEngine.SetAudioProfile(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioScenario()
        {
            AUDIO_SCENARIO_TYPE scenario = ParamsHelper.CreateParam<AUDIO_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetAudioScenario(scenario);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableLocalAudio()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableLocalAudio(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalAudioStream()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteLocalAudioStream(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteAudioStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteAllRemoteAudioStreams(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDefaultMuteAllRemoteAudioStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetDefaultMuteAllRemoteAudioStreams(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteAudioStream()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteRemoteAudioStream(uid, mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalVideoStream()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteLocalVideoStream(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableLocalVideo()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableLocalVideo(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteVideoStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteAllRemoteVideoStreams(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDefaultMuteAllRemoteVideoStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetDefaultMuteAllRemoteVideoStreams(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteVideoStream()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteRemoteVideoStream(uid, mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVideoStreamType()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            VIDEO_STREAM_TYPE streamType = ParamsHelper.CreateParam<VIDEO_STREAM_TYPE>();

            var nRet = RtcEngine.SetRemoteVideoStreamType(uid, streamType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVideoSubscriptionOptions()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            VideoSubscriptionOptions options = ParamsHelper.CreateParam<VideoSubscriptionOptions>();

            var nRet = RtcEngine.SetRemoteVideoSubscriptionOptions(uid, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteDefaultVideoStreamType()
        {
            VIDEO_STREAM_TYPE streamType = ParamsHelper.CreateParam<VIDEO_STREAM_TYPE>();

            var nRet = RtcEngine.SetRemoteDefaultVideoStreamType(streamType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeAudioBlocklist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeAudioBlocklist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeAudioAllowlist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeAudioAllowlist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeVideoBlocklist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeVideoBlocklist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeVideoAllowlist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeVideoAllowlist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAudioVolumeIndication()
        {
            int interval = ParamsHelper.CreateParam<int>();
            int smooth = ParamsHelper.CreateParam<int>();
            bool reportVad = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableAudioVolumeIndication(interval, smooth, reportVad);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioRecording()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            AUDIO_RECORDING_QUALITY_TYPE quality = ParamsHelper.CreateParam<AUDIO_RECORDING_QUALITY_TYPE>();

            var nRet = RtcEngine.StartAudioRecording(filePath, quality);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioRecording2()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            int sampleRate = ParamsHelper.CreateParam<int>();
            AUDIO_RECORDING_QUALITY_TYPE quality = ParamsHelper.CreateParam<AUDIO_RECORDING_QUALITY_TYPE>();

            var nRet = RtcEngine.StartAudioRecording(filePath, sampleRate, quality);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioRecording3()
        {
            AudioRecordingConfiguration config = ParamsHelper.CreateParam<AudioRecordingConfiguration>();

            var nRet = RtcEngine.StartAudioRecording(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RegisterAudioEncodedFrameObserver()
        {
            AudioEncodedFrameObserverConfig config = ParamsHelper.CreateParam<AudioEncodedFrameObserverConfig>();
            IAudioEncodedFrameObserver observer = ParamsHelper.CreateParam<IAudioEncodedFrameObserver>();

            var nRet = RtcEngine.RegisterAudioEncodedFrameObserver(config, observer);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopAudioRecording()
        {


            var nRet = RtcEngine.StopAudioRecording();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateMediaPlayer()
        {


            var nRet = RtcEngine.CreateMediaPlayer();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DestroyMediaPlayer()
        {
            IMediaPlayer media_player = ParamsHelper.CreateParam<IMediaPlayer>();

            var nRet = RtcEngine.DestroyMediaPlayer(media_player);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateMediaRecorder()
        {
            RecorderStreamInfo info = ParamsHelper.CreateParam<RecorderStreamInfo>();

            var nRet = RtcEngine.CreateMediaRecorder(info);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DestroyMediaRecorder()
        {
            IMediaRecorder mediaRecorder = ParamsHelper.CreateParam<IMediaRecorder>();

            var nRet = RtcEngine.DestroyMediaRecorder(mediaRecorder);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioMixing()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            bool loopback = ParamsHelper.CreateParam<bool>();
            int cycle = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.StartAudioMixing(filePath, loopback, cycle);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioMixing2()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            bool loopback = ParamsHelper.CreateParam<bool>();
            int cycle = ParamsHelper.CreateParam<int>();
            int startPos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.StartAudioMixing(filePath, loopback, cycle, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopAudioMixing()
        {


            var nRet = RtcEngine.StopAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseAudioMixing()
        {


            var nRet = RtcEngine.PauseAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeAudioMixing()
        {


            var nRet = RtcEngine.ResumeAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SelectAudioTrack()
        {
            int index = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SelectAudioTrack(index);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioTrackCount()
        {


            var nRet = RtcEngine.GetAudioTrackCount();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustAudioMixingVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustAudioMixingVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustAudioMixingPublishVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustAudioMixingPublishVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioMixingPublishVolume()
        {


            var nRet = RtcEngine.GetAudioMixingPublishVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustAudioMixingPlayoutVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustAudioMixingPlayoutVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioMixingPlayoutVolume()
        {


            var nRet = RtcEngine.GetAudioMixingPlayoutVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioMixingDuration()
        {


            var nRet = RtcEngine.GetAudioMixingDuration();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioMixingCurrentPosition()
        {


            var nRet = RtcEngine.GetAudioMixingCurrentPosition();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioMixingPosition()
        {
            int pos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAudioMixingPosition(pos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioMixingDualMonoMode()
        {
            AUDIO_MIXING_DUAL_MONO_MODE mode = ParamsHelper.CreateParam<AUDIO_MIXING_DUAL_MONO_MODE>();

            var nRet = RtcEngine.SetAudioMixingDualMonoMode(mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioMixingPitch()
        {
            int pitch = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAudioMixingPitch(pitch);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetEffectsVolume()
        {


            var nRet = RtcEngine.GetEffectsVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetEffectsVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetEffectsVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PreloadEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            string filePath = ParamsHelper.CreateParam<string>();
            int startPos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.PreloadEffect(soundId, filePath, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PlayEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            string filePath = ParamsHelper.CreateParam<string>();
            int loopCount = ParamsHelper.CreateParam<int>();
            double pitch = ParamsHelper.CreateParam<double>();
            double pan = ParamsHelper.CreateParam<double>();
            int gain = ParamsHelper.CreateParam<int>();
            bool publish = ParamsHelper.CreateParam<bool>();
            int startPos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.PlayEffect(soundId, filePath, loopCount, pitch, pan, gain, publish, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PlayAllEffects()
        {
            int loopCount = ParamsHelper.CreateParam<int>();
            double pitch = ParamsHelper.CreateParam<double>();
            double pan = ParamsHelper.CreateParam<double>();
            int gain = ParamsHelper.CreateParam<int>();
            bool publish = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.PlayAllEffects(loopCount, pitch, pan, gain, publish);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetVolumeOfEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetVolumeOfEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVolumeOfEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetVolumeOfEffect(soundId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.PauseEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseAllEffects()
        {


            var nRet = RtcEngine.PauseAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.ResumeEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeAllEffects()
        {


            var nRet = RtcEngine.ResumeAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.StopEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopAllEffects()
        {


            var nRet = RtcEngine.StopAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnloadEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.UnloadEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnloadAllEffects()
        {


            var nRet = RtcEngine.UnloadAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetEffectDuration()
        {
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.GetEffectDuration(filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetEffectPosition()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            int pos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetEffectPosition(soundId, pos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetEffectCurrentPosition()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetEffectCurrentPosition(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableSoundPositionIndication()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableSoundPositionIndication(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVoicePosition()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            double pan = ParamsHelper.CreateParam<double>();
            double gain = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngine.SetRemoteVoicePosition(uid, pan, gain);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableSpatialAudio()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableSpatialAudio(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteUserSpatialAudioParams()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            SpatialAudioParams @params = ParamsHelper.CreateParam<SpatialAudioParams>();

            var nRet = RtcEngine.SetRemoteUserSpatialAudioParams(uid, @params);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVoiceBeautifierPreset()
        {
            VOICE_BEAUTIFIER_PRESET preset = ParamsHelper.CreateParam<VOICE_BEAUTIFIER_PRESET>();

            var nRet = RtcEngine.SetVoiceBeautifierPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioEffectPreset()
        {
            AUDIO_EFFECT_PRESET preset = ParamsHelper.CreateParam<AUDIO_EFFECT_PRESET>();

            var nRet = RtcEngine.SetAudioEffectPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVoiceConversionPreset()
        {
            VOICE_CONVERSION_PRESET preset = ParamsHelper.CreateParam<VOICE_CONVERSION_PRESET>();

            var nRet = RtcEngine.SetVoiceConversionPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioEffectParameters()
        {
            AUDIO_EFFECT_PRESET preset = ParamsHelper.CreateParam<AUDIO_EFFECT_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAudioEffectParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVoiceBeautifierParameters()
        {
            VOICE_BEAUTIFIER_PRESET preset = ParamsHelper.CreateParam<VOICE_BEAUTIFIER_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetVoiceBeautifierParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVoiceConversionParameters()
        {
            VOICE_CONVERSION_PRESET preset = ParamsHelper.CreateParam<VOICE_CONVERSION_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetVoiceConversionParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalVoicePitch()
        {
            double pitch = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngine.SetLocalVoicePitch(pitch);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalVoiceFormant()
        {
            double formantRatio = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngine.SetLocalVoiceFormant(formantRatio);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalVoiceEqualization()
        {
            AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency = ParamsHelper.CreateParam<AUDIO_EQUALIZATION_BAND_FREQUENCY>();
            int bandGain = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetLocalVoiceEqualization(bandFrequency, bandGain);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalVoiceReverb()
        {
            AUDIO_REVERB_TYPE reverbKey = ParamsHelper.CreateParam<AUDIO_REVERB_TYPE>();
            int value = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetLocalVoiceReverb(reverbKey, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetHeadphoneEQPreset()
        {
            HEADPHONE_EQUALIZER_PRESET preset = ParamsHelper.CreateParam<HEADPHONE_EQUALIZER_PRESET>();

            var nRet = RtcEngine.SetHeadphoneEQPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetHeadphoneEQParameters()
        {
            int lowGain = ParamsHelper.CreateParam<int>();
            int highGain = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetHeadphoneEQParameters(lowGain, highGain);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLogFile()
        {
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetLogFile(filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLogFilter()
        {
            uint filter = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SetLogFilter(filter);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLogLevel()
        {
            LOG_LEVEL level = ParamsHelper.CreateParam<LOG_LEVEL>();

            var nRet = RtcEngine.SetLogLevel(level);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLogFileSize()
        {
            uint fileSizeInKBytes = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SetLogFileSize(fileSizeInKBytes);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UploadLogFile()
        {
            string requestId = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.UploadLogFile(ref requestId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalRenderMode()
        {
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngine.SetLocalRenderMode(renderMode, mirrorMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteRenderMode()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngine.SetRemoteRenderMode(uid, renderMode, mirrorMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalRenderMode2()
        {
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();

            var nRet = RtcEngine.SetLocalRenderMode(renderMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalVideoMirrorMode()
        {
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngine.SetLocalVideoMirrorMode(mirrorMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableDualStreamMode()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableDualStreamMode(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableDualStreamMode2()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();

            var nRet = RtcEngine.EnableDualStreamMode(enabled, streamConfig);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDualStreamMode()
        {
            SIMULCAST_STREAM_MODE mode = ParamsHelper.CreateParam<SIMULCAST_STREAM_MODE>();

            var nRet = RtcEngine.SetDualStreamMode(mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDualStreamMode2()
        {
            SIMULCAST_STREAM_MODE mode = ParamsHelper.CreateParam<SIMULCAST_STREAM_MODE>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();

            var nRet = RtcEngine.SetDualStreamMode(mode, streamConfig);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableCustomAudioLocalPlayback()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableCustomAudioLocalPlayback(trackId, enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRecordingAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetRecordingAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlaybackAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetPlaybackAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetMixedAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetMixedAudioFrameParameters(sampleRate, channel, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetEarMonitoringAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetEarMonitoringAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlaybackAudioFrameBeforeMixingParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetPlaybackAudioFrameBeforeMixingParameters(sampleRate, channel);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAudioSpectrumMonitor()
        {
            int intervalInMS = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.EnableAudioSpectrumMonitor(intervalInMS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DisableAudioSpectrumMonitor()
        {


            var nRet = RtcEngine.DisableAudioSpectrumMonitor();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RegisterAudioSpectrumObserver()
        {
            IAudioSpectrumObserver observer = ParamsHelper.CreateParam<IAudioSpectrumObserver>();

            var nRet = RtcEngine.RegisterAudioSpectrumObserver(observer);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnregisterAudioSpectrumObserver()
        {


            var nRet = RtcEngine.UnregisterAudioSpectrumObserver();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustRecordingSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustRecordingSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRecordingSignal()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteRecordingSignal(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustPlaybackSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustPlaybackSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustUserPlaybackSignalVolume()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustUserPlaybackSignalVolume(uid, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalPublishFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();

            var nRet = RtcEngine.SetLocalPublishFallbackOption(option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteSubscribeFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();

            var nRet = RtcEngine.SetRemoteSubscribeFallbackOption(option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetHighPriorityUserList()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNum = ParamsHelper.CreateParam<int>();
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();

            var nRet = RtcEngine.SetHighPriorityUserList(uidList, uidNum, option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableLoopbackRecording()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            string deviceName = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.EnableLoopbackRecording(enabled, deviceName);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustLoopbackSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustLoopbackSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetLoopbackRecordingVolume()
        {


            var nRet = RtcEngine.GetLoopbackRecordingVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableInEarMonitoring()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            int includeAudioFilters = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.EnableInEarMonitoring(enabled, includeAudioFilters);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetInEarMonitoringVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetInEarMonitoringVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LoadExtensionProvider()
        {
            string path = ParamsHelper.CreateParam<string>();
            bool unload_after_use = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.LoadExtensionProvider(path, unload_after_use);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExtensionProviderProperty()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetExtensionProviderProperty(provider, key, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RegisterExtension()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.RegisterExtension(provider, extension, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableExtension()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            bool enable = ParamsHelper.CreateParam<bool>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.EnableExtension(provider, extension, enable, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableExtension2()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            ExtensionInfo extensionInfo = ParamsHelper.CreateParam<ExtensionInfo>();
            bool enable = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableExtension(provider, extension, extensionInfo, enable);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExtensionProperty()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetExtensionProperty(provider, extension, key, value, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetExtensionProperty()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();
            int buf_len = ParamsHelper.CreateParam<int>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.GetExtensionProperty(provider, extension, key, ref value, buf_len, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExtensionProperty2()
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
        public void Test_GetExtensionProperty2()
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
        public void Test_SetCameraCapturerConfiguration()
        {
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngine.SetCameraCapturerConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateCustomVideoTrack()
        {


            var nRet = RtcEngine.CreateCustomVideoTrack();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateCustomEncodedVideoTrack()
        {
            SenderOptions sender_option = ParamsHelper.CreateParam<SenderOptions>();

            var nRet = RtcEngine.CreateCustomEncodedVideoTrack(sender_option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DestroyCustomVideoTrack()
        {
            uint video_track_id = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.DestroyCustomVideoTrack(video_track_id);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DestroyCustomEncodedVideoTrack()
        {
            uint video_track_id = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.DestroyCustomEncodedVideoTrack(video_track_id);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SwitchCamera()
        {


            var nRet = RtcEngine.SwitchCamera();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsCameraZoomSupported()
        {


            var nRet = RtcEngine.IsCameraZoomSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsCameraFaceDetectSupported()
        {


            var nRet = RtcEngine.IsCameraFaceDetectSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsCameraTorchSupported()
        {


            var nRet = RtcEngine.IsCameraTorchSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsCameraFocusSupported()
        {


            var nRet = RtcEngine.IsCameraFocusSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsCameraAutoFocusFaceModeSupported()
        {


            var nRet = RtcEngine.IsCameraAutoFocusFaceModeSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCameraZoomFactor()
        {
            float factor = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraZoomFactor(factor);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableFaceDetection()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableFaceDetection(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCameraMaxZoomFactor()
        {


            var nRet = RtcEngine.GetCameraMaxZoomFactor();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCameraFocusPositionInPreview()
        {
            float positionX = ParamsHelper.CreateParam<float>();
            float positionY = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraFocusPositionInPreview(positionX, positionY);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCameraTorchOn()
        {
            bool isOn = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetCameraTorchOn(isOn);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCameraAutoFocusFaceModeEnabled()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetCameraAutoFocusFaceModeEnabled(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsCameraExposurePositionSupported()
        {


            var nRet = RtcEngine.IsCameraExposurePositionSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCameraExposurePosition()
        {
            float positionXinView = ParamsHelper.CreateParam<float>();
            float positionYinView = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraExposurePosition(positionXinView, positionYinView);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsCameraExposureSupported()
        {


            var nRet = RtcEngine.IsCameraExposureSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCameraExposureFactor()
        {
            float value = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraExposureFactor(value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsCameraAutoExposureFaceModeSupported()
        {


            var nRet = RtcEngine.IsCameraAutoExposureFaceModeSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCameraAutoExposureFaceModeEnabled()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetCameraAutoExposureFaceModeEnabled(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDefaultAudioRouteToSpeakerphone()
        {
            bool defaultToSpeaker = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetDefaultAudioRouteToSpeakerphone(defaultToSpeaker);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetEnableSpeakerphone()
        {
            bool speakerOn = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetEnableSpeakerphone(speakerOn);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsSpeakerphoneEnabled()
        {


            var nRet = RtcEngine.IsSpeakerphoneEnabled();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRouteInCommunicationMode()
        {
            int route = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetRouteInCommunicationMode(route);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetScreenCaptureSources()
        {
            SIZE thumbSize = ParamsHelper.CreateParam<SIZE>();
            SIZE iconSize = ParamsHelper.CreateParam<SIZE>();
            bool includeScreen = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.GetScreenCaptureSources(thumbSize, iconSize, includeScreen);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioSessionOperationRestriction()
        {
            AUDIO_SESSION_OPERATION_RESTRICTION restriction = ParamsHelper.CreateParam<AUDIO_SESSION_OPERATION_RESTRICTION>();

            var nRet = RtcEngine.SetAudioSessionOperationRestriction(restriction);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartScreenCaptureByDisplayId()
        {
            uint displayId = ParamsHelper.CreateParam<uint>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartScreenCaptureByScreenRect()
        {
            Rectangle screenRect = ParamsHelper.CreateParam<Rectangle>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.StartScreenCaptureByScreenRect(screenRect, regionRect, captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioDeviceInfo()
        {
            DeviceInfoMobile deviceInfo = ParamsHelper.CreateParam<DeviceInfoMobile>();

            var nRet = RtcEngine.GetAudioDeviceInfo(ref deviceInfo);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartScreenCaptureByWindowId()
        {
            view_t windowId = ParamsHelper.CreateParam<view_t>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.StartScreenCaptureByWindowId(windowId, regionRect, captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetScreenCaptureContentHint()
        {
            VIDEO_CONTENT_HINT contentHint = ParamsHelper.CreateParam<VIDEO_CONTENT_HINT>();

            var nRet = RtcEngine.SetScreenCaptureContentHint(contentHint);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateScreenCaptureRegion()
        {
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();

            var nRet = RtcEngine.UpdateScreenCaptureRegion(regionRect);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateScreenCaptureParameters()
        {
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.UpdateScreenCaptureParameters(captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartScreenCapture()
        {
            ScreenCaptureParameters2 captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters2>();

            var nRet = RtcEngine.StartScreenCapture(captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateScreenCapture()
        {
            ScreenCaptureParameters2 captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters2>();

            var nRet = RtcEngine.UpdateScreenCapture(captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_QueryScreenCaptureCapability()
        {


            var nRet = RtcEngine.QueryScreenCaptureCapability();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetScreenCaptureScenario()
        {
            SCREEN_SCENARIO_TYPE screenScenario = ParamsHelper.CreateParam<SCREEN_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetScreenCaptureScenario(screenScenario);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopScreenCapture()
        {


            var nRet = RtcEngine.StopScreenCapture();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCallId()
        {
            string callId = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.GetCallId(ref callId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Rate()
        {
            string callId = ParamsHelper.CreateParam<string>();
            int rating = ParamsHelper.CreateParam<int>();
            string description = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.Rate(callId, rating, description);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Complain()
        {
            string callId = ParamsHelper.CreateParam<string>();
            string description = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.Complain(callId, description);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRtmpStreamWithoutTranscoding()
        {
            string url = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.StartRtmpStreamWithoutTranscoding(url);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRtmpStreamWithTranscoding()
        {
            string url = ParamsHelper.CreateParam<string>();
            LiveTranscoding transcoding = ParamsHelper.CreateParam<LiveTranscoding>();

            var nRet = RtcEngine.StartRtmpStreamWithTranscoding(url, transcoding);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateRtmpTranscoding()
        {
            LiveTranscoding transcoding = ParamsHelper.CreateParam<LiveTranscoding>();

            var nRet = RtcEngine.UpdateRtmpTranscoding(transcoding);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRtmpStream()
        {
            string url = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.StopRtmpStream(url);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartLocalVideoTranscoder()
        {
            LocalTranscoderConfiguration config = ParamsHelper.CreateParam<LocalTranscoderConfiguration>();

            var nRet = RtcEngine.StartLocalVideoTranscoder(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateLocalTranscoderConfiguration()
        {
            LocalTranscoderConfiguration config = ParamsHelper.CreateParam<LocalTranscoderConfiguration>();

            var nRet = RtcEngine.UpdateLocalTranscoderConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopLocalVideoTranscoder()
        {


            var nRet = RtcEngine.StopLocalVideoTranscoder();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartCameraCapture()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngine.StartCameraCapture(sourceType, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopCameraCapture()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StopCameraCapture(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCameraDeviceOrientation()
        {
            VIDEO_SOURCE_TYPE type = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            VIDEO_ORIENTATION orientation = ParamsHelper.CreateParam<VIDEO_ORIENTATION>();

            var nRet = RtcEngine.SetCameraDeviceOrientation(type, orientation);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetScreenCaptureOrientation()
        {
            VIDEO_SOURCE_TYPE type = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            VIDEO_ORIENTATION orientation = ParamsHelper.CreateParam<VIDEO_ORIENTATION>();

            var nRet = RtcEngine.SetScreenCaptureOrientation(type, orientation);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartScreenCapture2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            ScreenCaptureConfiguration config = ParamsHelper.CreateParam<ScreenCaptureConfiguration>();

            var nRet = RtcEngine.StartScreenCapture(sourceType, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopScreenCapture2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StopScreenCapture(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetConnectionState()
        {


            var nRet = RtcEngine.GetConnectionState();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteUserPriority()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            PRIORITY_TYPE userPriority = ParamsHelper.CreateParam<PRIORITY_TYPE>();

            var nRet = RtcEngine.SetRemoteUserPriority(uid, userPriority);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetEncryptionMode()
        {
            string encryptionMode = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetEncryptionMode(encryptionMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetEncryptionSecret()
        {
            string secret = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetEncryptionSecret(secret);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableEncryption()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            EncryptionConfig config = ParamsHelper.CreateParam<EncryptionConfig>();

            var nRet = RtcEngine.EnableEncryption(enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateDataStream()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            bool reliable = ParamsHelper.CreateParam<bool>();
            bool ordered = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.CreateDataStream(ref streamId, reliable, ordered);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateDataStream2()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            DataStreamConfig config = ParamsHelper.CreateParam<DataStreamConfig>();

            var nRet = RtcEngine.CreateDataStream(ref streamId, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SendStreamMessage()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            byte[] data = ParamsHelper.CreateParam<byte[]>();
            uint length = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SendStreamMessage(streamId, data, length);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AddVideoWatermark()
        {
            RtcImage watermark = ParamsHelper.CreateParam<RtcImage>();

            var nRet = RtcEngine.AddVideoWatermark(watermark);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AddVideoWatermark2()
        {
            string watermarkUrl = ParamsHelper.CreateParam<string>();
            WatermarkOptions options = ParamsHelper.CreateParam<WatermarkOptions>();

            var nRet = RtcEngine.AddVideoWatermark(watermarkUrl, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ClearVideoWatermarks()
        {


            var nRet = RtcEngine.ClearVideoWatermarks();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseAudio()
        {


            var nRet = RtcEngine.PauseAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeAudio()
        {


            var nRet = RtcEngine.ResumeAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableWebSdkInteroperability()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableWebSdkInteroperability(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SendCustomReportMessage()
        {
            string id = ParamsHelper.CreateParam<string>();
            string category = ParamsHelper.CreateParam<string>();
            string @event = ParamsHelper.CreateParam<string>();
            string label = ParamsHelper.CreateParam<string>();
            int value = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SendCustomReportMessage(id, category, @event, label, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RegisterMediaMetadataObserver()
        {
            IMetadataObserver observer = ParamsHelper.CreateParam<IMetadataObserver>();
            METADATA_TYPE type = ParamsHelper.CreateParam<METADATA_TYPE>();

            var nRet = RtcEngine.RegisterMediaMetadataObserver(observer, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnregisterMediaMetadataObserver()
        {


            var nRet = RtcEngine.UnregisterMediaMetadataObserver();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioFrameDump()
        {
            string channel_id = ParamsHelper.CreateParam<string>();
            uint user_id = ParamsHelper.CreateParam<uint>();
            string location = ParamsHelper.CreateParam<string>();
            string uuid = ParamsHelper.CreateParam<string>();
            string passwd = ParamsHelper.CreateParam<string>();
            long duration_ms = ParamsHelper.CreateParam<long>();
            bool auto_upload = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.StartAudioFrameDump(channel_id, user_id, location, uuid, passwd, duration_ms, auto_upload);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopAudioFrameDump()
        {
            string channel_id = ParamsHelper.CreateParam<string>();
            uint user_id = ParamsHelper.CreateParam<uint>();
            string location = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.StopAudioFrameDump(channel_id, user_id, location);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAINSMode()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            AUDIO_AINS_MODE mode = ParamsHelper.CreateParam<AUDIO_AINS_MODE>();

            var nRet = RtcEngine.SetAINSMode(enabled, mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RegisterLocalUserAccount()
        {
            string appId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.RegisterLocalUserAccount(appId, userAccount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_JoinChannelWithUserAccount()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.JoinChannelWithUserAccount(token, channelId, userAccount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_JoinChannelWithUserAccount2()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngine.JoinChannelWithUserAccount(token, channelId, userAccount, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetUserInfoByUserAccount()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            UserInfo userInfo = ParamsHelper.CreateParam<UserInfo>();

            var nRet = RtcEngine.GetUserInfoByUserAccount(userAccount, ref userInfo);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetUserInfoByUid()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            UserInfo userInfo = ParamsHelper.CreateParam<UserInfo>();

            var nRet = RtcEngine.GetUserInfoByUid(uid, ref userInfo);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartOrUpdateChannelMediaRelay()
        {
            ChannelMediaRelayConfiguration configuration = ParamsHelper.CreateParam<ChannelMediaRelayConfiguration>();

            var nRet = RtcEngine.StartOrUpdateChannelMediaRelay(configuration);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartChannelMediaRelay()
        {
            ChannelMediaRelayConfiguration configuration = ParamsHelper.CreateParam<ChannelMediaRelayConfiguration>();

            var nRet = RtcEngine.StartChannelMediaRelay(configuration);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateChannelMediaRelay()
        {
            ChannelMediaRelayConfiguration configuration = ParamsHelper.CreateParam<ChannelMediaRelayConfiguration>();

            var nRet = RtcEngine.UpdateChannelMediaRelay(configuration);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopChannelMediaRelay()
        {


            var nRet = RtcEngine.StopChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseAllChannelMediaRelay()
        {


            var nRet = RtcEngine.PauseAllChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeAllChannelMediaRelay()
        {


            var nRet = RtcEngine.ResumeAllChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDirectCdnStreamingAudioConfiguration()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();

            var nRet = RtcEngine.SetDirectCdnStreamingAudioConfiguration(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDirectCdnStreamingVideoConfiguration()
        {
            VideoEncoderConfiguration config = ParamsHelper.CreateParam<VideoEncoderConfiguration>();

            var nRet = RtcEngine.SetDirectCdnStreamingVideoConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartDirectCdnStreaming()
        {
            string publishUrl = ParamsHelper.CreateParam<string>();
            DirectCdnStreamingMediaOptions options = ParamsHelper.CreateParam<DirectCdnStreamingMediaOptions>();

            var nRet = RtcEngine.StartDirectCdnStreaming(publishUrl, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopDirectCdnStreaming()
        {


            var nRet = RtcEngine.StopDirectCdnStreaming();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateDirectCdnStreamingMediaOptions()
        {
            DirectCdnStreamingMediaOptions options = ParamsHelper.CreateParam<DirectCdnStreamingMediaOptions>();

            var nRet = RtcEngine.UpdateDirectCdnStreamingMediaOptions(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRhythmPlayer()
        {
            string sound1 = ParamsHelper.CreateParam<string>();
            string sound2 = ParamsHelper.CreateParam<string>();
            AgoraRhythmPlayerConfig config = ParamsHelper.CreateParam<AgoraRhythmPlayerConfig>();

            var nRet = RtcEngine.StartRhythmPlayer(sound1, sound2, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRhythmPlayer()
        {


            var nRet = RtcEngine.StopRhythmPlayer();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ConfigRhythmPlayer()
        {
            AgoraRhythmPlayerConfig config = ParamsHelper.CreateParam<AgoraRhythmPlayerConfig>();

            var nRet = RtcEngine.ConfigRhythmPlayer(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_TakeSnapshot()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.TakeSnapshot(uid, filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableContentInspect()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            ContentInspectConfig config = ParamsHelper.CreateParam<ContentInspectConfig>();

            var nRet = RtcEngine.EnableContentInspect(enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustCustomAudioPublishVolume()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustCustomAudioPublishVolume(trackId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustCustomAudioPlayoutVolume()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustCustomAudioPlayoutVolume(trackId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCloudProxy()
        {
            CLOUD_PROXY_TYPE proxyType = ParamsHelper.CreateParam<CLOUD_PROXY_TYPE>();

            var nRet = RtcEngine.SetCloudProxy(proxyType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalAccessPoint()
        {
            LocalAccessPointConfiguration config = ParamsHelper.CreateParam<LocalAccessPointConfiguration>();

            var nRet = RtcEngine.SetLocalAccessPoint(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAdvancedAudioOptions()
        {
            AdvancedAudioOptions options = ParamsHelper.CreateParam<AdvancedAudioOptions>();
            int sourceType = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAdvancedAudioOptions(options, sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAVSyncSource()
        {
            string channelId = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SetAVSyncSource(channelId, uid);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableVideoImageSource()
        {
            bool enable = ParamsHelper.CreateParam<bool>();
            ImageTrackOptions options = ParamsHelper.CreateParam<ImageTrackOptions>();

            var nRet = RtcEngine.EnableVideoImageSource(enable, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCurrentMonotonicTimeInMs()
        {


            var nRet = RtcEngine.GetCurrentMonotonicTimeInMs();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableWirelessAccelerate()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableWirelessAccelerate(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetNetworkType()
        {


            var nRet = RtcEngine.GetNetworkType();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetParameters()
        {
            string parameters = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetParameters(parameters);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartMediaRenderingTracing()
        {


            var nRet = RtcEngine.StartMediaRenderingTracing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableInstantMediaRendering()
        {


            var nRet = RtcEngine.EnableInstantMediaRendering();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetNtpWallTimeInMs()
        {


            var nRet = RtcEngine.GetNtpWallTimeInMs();
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IRtcEngine

        #region terra IMediaEngine

        [Test]
        public void Test_PushAudioFrame()
        {
            AudioFrame frame = ParamsHelper.CreateParam<AudioFrame>();
            uint trackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngine.PushAudioFrame(frame, trackId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PullAudioFrame()
        {
            AudioFrame frame = ParamsHelper.CreateParam<AudioFrame>();

            var nRet = MediaEngine.PullAudioFrame(frame);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExternalVideoSource()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            bool useTexture = ParamsHelper.CreateParam<bool>();
            EXTERNAL_VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<EXTERNAL_VIDEO_SOURCE_TYPE>();
            SenderOptions encodedVideoOption = ParamsHelper.CreateParam<SenderOptions>();

            var nRet = MediaEngine.SetExternalVideoSource(enabled, useTexture, sourceType, encodedVideoOption);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExternalAudioSource()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channels = ParamsHelper.CreateParam<int>();
            bool localPlayback = ParamsHelper.CreateParam<bool>();
            bool publish = ParamsHelper.CreateParam<bool>();

            var nRet = MediaEngine.SetExternalAudioSource(enabled, sampleRate, channels, localPlayback, publish);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateCustomAudioTrack()
        {
            AUDIO_TRACK_TYPE trackType = ParamsHelper.CreateParam<AUDIO_TRACK_TYPE>();
            AudioTrackConfig config = ParamsHelper.CreateParam<AudioTrackConfig>();

            var nRet = MediaEngine.CreateCustomAudioTrack(trackType, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DestroyCustomAudioTrack()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngine.DestroyCustomAudioTrack(trackId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExternalAudioSink()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channels = ParamsHelper.CreateParam<int>();

            var nRet = MediaEngine.SetExternalAudioSink(enabled, sampleRate, channels);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PushVideoFrame()
        {
            ExternalVideoFrame frame = ParamsHelper.CreateParam<ExternalVideoFrame>();
            uint videoTrackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngine.PushVideoFrame(frame, videoTrackId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PushEncodedVideoImage()
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