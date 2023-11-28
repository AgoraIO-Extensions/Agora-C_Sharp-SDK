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
        public IRtcEngine MediaEngineBase;
        [SetUp]
        public void Setup()
        {
            RtcEngine = Rtc.RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
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

        #region terra IRtcEngine
        [Test]
        public void Test_IRtcEngineGetVersion()
        {
            int build = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetVersion(ref build);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetErrorDescription()
        {
            int code = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetErrorDescription(code);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineQueryCodecCapability()
        {
            CodecCapInfo[] codecInfo = ParamsHelper.CreateParam<CodecCapInfo[]>();
            int size = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.QueryCodecCapability(ref codecInfo, ref size);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineQueryDeviceScore()
        {


            var nRet = RtcEngine.QueryDeviceScore();
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
        public void Test_IRtcEnginePreloadChannelWithUserAccount()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.PreloadChannelWithUserAccount(token, channelId, userAccount);
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
        public void Test_IRtcEngineUpdateChannelMediaOptions()
        {
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngine.UpdateChannelMediaOptions(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineLeaveChannel()
        {


            var nRet = RtcEngine.LeaveChannel();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineLeaveChannel2()
        {
            LeaveChannelOptions options = ParamsHelper.CreateParam<LeaveChannelOptions>();

            var nRet = RtcEngine.LeaveChannel(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineRenewToken()
        {
            string token = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.RenewToken(token);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetChannelProfile()
        {
            CHANNEL_PROFILE_TYPE profile = ParamsHelper.CreateParam<CHANNEL_PROFILE_TYPE>();

            var nRet = RtcEngine.SetChannelProfile(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetClientRole()
        {
            CLIENT_ROLE_TYPE role = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();

            var nRet = RtcEngine.SetClientRole(role);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetClientRole2()
        {
            CLIENT_ROLE_TYPE role = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();
            ClientRoleOptions options = ParamsHelper.CreateParam<ClientRoleOptions>();

            var nRet = RtcEngine.SetClientRole(role, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartEchoTest()
        {


            var nRet = RtcEngine.StartEchoTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartEchoTest2()
        {
            int intervalInSeconds = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.StartEchoTest(intervalInSeconds);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartEchoTest3()
        {
            EchoTestConfiguration config = ParamsHelper.CreateParam<EchoTestConfiguration>();

            var nRet = RtcEngine.StartEchoTest(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopEchoTest()
        {


            var nRet = RtcEngine.StopEchoTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableMultiCamera()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngine.EnableMultiCamera(enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableVideo()
        {


            var nRet = RtcEngine.EnableVideo();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineDisableVideo()
        {


            var nRet = RtcEngine.DisableVideo();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartPreview()
        {


            var nRet = RtcEngine.StartPreview();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StartPreview(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopPreview()
        {


            var nRet = RtcEngine.StopPreview();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StopPreview(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartLastmileProbeTest()
        {
            LastmileProbeConfig config = ParamsHelper.CreateParam<LastmileProbeConfig>();

            var nRet = RtcEngine.StartLastmileProbeTest(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopLastmileProbeTest()
        {


            var nRet = RtcEngine.StopLastmileProbeTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetVideoEncoderConfiguration()
        {
            VideoEncoderConfiguration config = ParamsHelper.CreateParam<VideoEncoderConfiguration>();

            var nRet = RtcEngine.SetVideoEncoderConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetBeautyEffectOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            BeautyOptions options = ParamsHelper.CreateParam<BeautyOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetBeautyEffectOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLowlightEnhanceOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            LowlightEnhanceOptions options = ParamsHelper.CreateParam<LowlightEnhanceOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetLowlightEnhanceOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetVideoDenoiserOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            VideoDenoiserOptions options = ParamsHelper.CreateParam<VideoDenoiserOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetVideoDenoiserOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetColorEnhanceOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            ColorEnhanceOptions options = ParamsHelper.CreateParam<ColorEnhanceOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetColorEnhanceOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableVirtualBackground()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            VirtualBackgroundSource backgroundSource = ParamsHelper.CreateParam<VirtualBackgroundSource>();
            SegmentationProperty segproperty = ParamsHelper.CreateParam<SegmentationProperty>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.EnableVirtualBackground(enabled, backgroundSource, segproperty, type);
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
        public void Test_IRtcEngineSetVideoScenario()
        {
            VIDEO_APPLICATION_SCENARIO_TYPE scenarioType = ParamsHelper.CreateParam<VIDEO_APPLICATION_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetVideoScenario(scenarioType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetVideoQoEPreference()
        {
            VIDEO_QOE_PREFERENCE_TYPE qoePreference = ParamsHelper.CreateParam<VIDEO_QOE_PREFERENCE_TYPE>();

            var nRet = RtcEngine.SetVideoQoEPreference(qoePreference);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableAudio()
        {


            var nRet = RtcEngine.EnableAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineDisableAudio()
        {


            var nRet = RtcEngine.DisableAudio();
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
        public void Test_IRtcEngineSetAudioProfile2()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();

            var nRet = RtcEngine.SetAudioProfile(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetAudioScenario()
        {
            AUDIO_SCENARIO_TYPE scenario = ParamsHelper.CreateParam<AUDIO_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetAudioScenario(scenario);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableLocalAudio()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableLocalAudio(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineMuteLocalAudioStream()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteLocalAudioStream(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineMuteAllRemoteAudioStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteAllRemoteAudioStreams(mute);
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
        public void Test_IRtcEngineMuteLocalVideoStream()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteLocalVideoStream(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableLocalVideo()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableLocalVideo(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineMuteAllRemoteVideoStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteAllRemoteVideoStreams(mute);
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
        public void Test_IRtcEngineSetRemoteDefaultVideoStreamType()
        {
            VIDEO_STREAM_TYPE streamType = ParamsHelper.CreateParam<VIDEO_STREAM_TYPE>();

            var nRet = RtcEngine.SetRemoteDefaultVideoStreamType(streamType);
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
        public void Test_IRtcEngineEnableAudioVolumeIndication()
        {
            int interval = ParamsHelper.CreateParam<int>();
            int smooth = ParamsHelper.CreateParam<int>();
            bool reportVad = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableAudioVolumeIndication(interval, smooth, reportVad);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartAudioRecording()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            AUDIO_RECORDING_QUALITY_TYPE quality = ParamsHelper.CreateParam<AUDIO_RECORDING_QUALITY_TYPE>();

            var nRet = RtcEngine.StartAudioRecording(filePath, quality);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartAudioRecording2()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            int sampleRate = ParamsHelper.CreateParam<int>();
            AUDIO_RECORDING_QUALITY_TYPE quality = ParamsHelper.CreateParam<AUDIO_RECORDING_QUALITY_TYPE>();

            var nRet = RtcEngine.StartAudioRecording(filePath, sampleRate, quality);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartAudioRecording3()
        {
            AudioRecordingConfiguration config = ParamsHelper.CreateParam<AudioRecordingConfiguration>();

            var nRet = RtcEngine.StartAudioRecording(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineRegisterAudioEncodedFrameObserver()
        {
            AudioEncodedFrameObserverConfig config = ParamsHelper.CreateParam<AudioEncodedFrameObserverConfig>();
            IAudioEncodedFrameObserver observer = ParamsHelper.CreateParam<IAudioEncodedFrameObserver>();

            var nRet = RtcEngine.RegisterAudioEncodedFrameObserver(config, observer);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopAudioRecording()
        {


            var nRet = RtcEngine.StopAudioRecording();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineCreateMediaPlayer()
        {


            var nRet = RtcEngine.CreateMediaPlayer();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineDestroyMediaPlayer()
        {
            IMediaPlayer media_player = ParamsHelper.CreateParam<IMediaPlayer>();

            var nRet = RtcEngine.DestroyMediaPlayer(media_player);
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
        public void Test_IRtcEngineStartAudioMixing()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            bool loopback = ParamsHelper.CreateParam<bool>();
            int cycle = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.StartAudioMixing(filePath, loopback, cycle);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartAudioMixing2()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            bool loopback = ParamsHelper.CreateParam<bool>();
            int cycle = ParamsHelper.CreateParam<int>();
            int startPos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.StartAudioMixing(filePath, loopback, cycle, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopAudioMixing()
        {


            var nRet = RtcEngine.StopAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEnginePauseAudioMixing()
        {


            var nRet = RtcEngine.PauseAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineResumeAudioMixing()
        {


            var nRet = RtcEngine.ResumeAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSelectAudioTrack()
        {
            int index = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SelectAudioTrack(index);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetAudioTrackCount()
        {


            var nRet = RtcEngine.GetAudioTrackCount();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineAdjustAudioMixingVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustAudioMixingVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineAdjustAudioMixingPublishVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustAudioMixingPublishVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetAudioMixingPublishVolume()
        {


            var nRet = RtcEngine.GetAudioMixingPublishVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineAdjustAudioMixingPlayoutVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustAudioMixingPlayoutVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetAudioMixingPlayoutVolume()
        {


            var nRet = RtcEngine.GetAudioMixingPlayoutVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetAudioMixingDuration()
        {


            var nRet = RtcEngine.GetAudioMixingDuration();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetAudioMixingCurrentPosition()
        {


            var nRet = RtcEngine.GetAudioMixingCurrentPosition();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetAudioMixingPosition()
        {
            int pos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAudioMixingPosition(pos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetAudioMixingDualMonoMode()
        {
            AUDIO_MIXING_DUAL_MONO_MODE mode = ParamsHelper.CreateParam<AUDIO_MIXING_DUAL_MONO_MODE>();

            var nRet = RtcEngine.SetAudioMixingDualMonoMode(mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetAudioMixingPitch()
        {
            int pitch = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAudioMixingPitch(pitch);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetEffectsVolume()
        {


            var nRet = RtcEngine.GetEffectsVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetEffectsVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetEffectsVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEnginePreloadEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            string filePath = ParamsHelper.CreateParam<string>();
            int startPos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.PreloadEffect(soundId, filePath, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEnginePlayEffect()
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
        public void Test_IRtcEnginePlayAllEffects()
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
        public void Test_IRtcEngineGetVolumeOfEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetVolumeOfEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetVolumeOfEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetVolumeOfEffect(soundId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEnginePauseEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.PauseEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEnginePauseAllEffects()
        {


            var nRet = RtcEngine.PauseAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineResumeEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.ResumeEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineResumeAllEffects()
        {


            var nRet = RtcEngine.ResumeAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.StopEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopAllEffects()
        {


            var nRet = RtcEngine.StopAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUnloadEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.UnloadEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUnloadAllEffects()
        {


            var nRet = RtcEngine.UnloadAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetEffectDuration()
        {
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.GetEffectDuration(filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetEffectPosition()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            int pos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetEffectPosition(soundId, pos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetEffectCurrentPosition()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetEffectCurrentPosition(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableSoundPositionIndication()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableSoundPositionIndication(enabled);
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
        public void Test_IRtcEngineEnableSpatialAudio()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableSpatialAudio(enabled);
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
        public void Test_IRtcEngineSetVoiceBeautifierPreset()
        {
            VOICE_BEAUTIFIER_PRESET preset = ParamsHelper.CreateParam<VOICE_BEAUTIFIER_PRESET>();

            var nRet = RtcEngine.SetVoiceBeautifierPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetAudioEffectPreset()
        {
            AUDIO_EFFECT_PRESET preset = ParamsHelper.CreateParam<AUDIO_EFFECT_PRESET>();

            var nRet = RtcEngine.SetAudioEffectPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetVoiceConversionPreset()
        {
            VOICE_CONVERSION_PRESET preset = ParamsHelper.CreateParam<VOICE_CONVERSION_PRESET>();

            var nRet = RtcEngine.SetVoiceConversionPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetAudioEffectParameters()
        {
            AUDIO_EFFECT_PRESET preset = ParamsHelper.CreateParam<AUDIO_EFFECT_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAudioEffectParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetVoiceBeautifierParameters()
        {
            VOICE_BEAUTIFIER_PRESET preset = ParamsHelper.CreateParam<VOICE_BEAUTIFIER_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetVoiceBeautifierParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetVoiceConversionParameters()
        {
            VOICE_CONVERSION_PRESET preset = ParamsHelper.CreateParam<VOICE_CONVERSION_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetVoiceConversionParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLocalVoicePitch()
        {
            double pitch = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngine.SetLocalVoicePitch(pitch);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLocalVoiceFormant()
        {
            double formantRatio = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngine.SetLocalVoiceFormant(formantRatio);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLocalVoiceEqualization()
        {
            AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency = ParamsHelper.CreateParam<AUDIO_EQUALIZATION_BAND_FREQUENCY>();
            int bandGain = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetLocalVoiceEqualization(bandFrequency, bandGain);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLocalVoiceReverb()
        {
            AUDIO_REVERB_TYPE reverbKey = ParamsHelper.CreateParam<AUDIO_REVERB_TYPE>();
            int value = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetLocalVoiceReverb(reverbKey, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetHeadphoneEQPreset()
        {
            HEADPHONE_EQUALIZER_PRESET preset = ParamsHelper.CreateParam<HEADPHONE_EQUALIZER_PRESET>();

            var nRet = RtcEngine.SetHeadphoneEQPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetHeadphoneEQParameters()
        {
            int lowGain = ParamsHelper.CreateParam<int>();
            int highGain = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetHeadphoneEQParameters(lowGain, highGain);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLogFile()
        {
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetLogFile(filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLogFilter()
        {
            uint filter = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SetLogFilter(filter);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLogLevel()
        {
            LOG_LEVEL level = ParamsHelper.CreateParam<LOG_LEVEL>();

            var nRet = RtcEngine.SetLogLevel(level);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLogFileSize()
        {
            uint fileSizeInKBytes = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SetLogFileSize(fileSizeInKBytes);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUploadLogFile()
        {
            string requestId = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.UploadLogFile(ref requestId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLocalRenderMode()
        {
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngine.SetLocalRenderMode(renderMode, mirrorMode);
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
        public void Test_IRtcEngineSetLocalRenderMode2()
        {
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();

            var nRet = RtcEngine.SetLocalRenderMode(renderMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLocalVideoMirrorMode()
        {
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngine.SetLocalVideoMirrorMode(mirrorMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableDualStreamMode()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableDualStreamMode(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableDualStreamMode2()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();

            var nRet = RtcEngine.EnableDualStreamMode(enabled, streamConfig);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetDualStreamMode()
        {
            SIMULCAST_STREAM_MODE mode = ParamsHelper.CreateParam<SIMULCAST_STREAM_MODE>();

            var nRet = RtcEngine.SetDualStreamMode(mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetDualStreamMode2()
        {
            SIMULCAST_STREAM_MODE mode = ParamsHelper.CreateParam<SIMULCAST_STREAM_MODE>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();

            var nRet = RtcEngine.SetDualStreamMode(mode, streamConfig);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableCustomAudioLocalPlayback()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableCustomAudioLocalPlayback(trackId, enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetRecordingAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetRecordingAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetPlaybackAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetPlaybackAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetMixedAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetMixedAudioFrameParameters(sampleRate, channel, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetEarMonitoringAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetEarMonitoringAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetPlaybackAudioFrameBeforeMixingParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetPlaybackAudioFrameBeforeMixingParameters(sampleRate, channel);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableAudioSpectrumMonitor()
        {
            int intervalInMS = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.EnableAudioSpectrumMonitor(intervalInMS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineDisableAudioSpectrumMonitor()
        {


            var nRet = RtcEngine.DisableAudioSpectrumMonitor();
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
        public void Test_IRtcEngineAdjustRecordingSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustRecordingSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineMuteRecordingSignal()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteRecordingSignal(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineAdjustPlaybackSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustPlaybackSignalVolume(volume);
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
        public void Test_IRtcEngineSetLocalPublishFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();

            var nRet = RtcEngine.SetLocalPublishFallbackOption(option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetRemoteSubscribeFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();

            var nRet = RtcEngine.SetRemoteSubscribeFallbackOption(option);
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
        public void Test_IRtcEngineEnableLoopbackRecording()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            string deviceName = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.EnableLoopbackRecording(enabled, deviceName);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineAdjustLoopbackSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustLoopbackSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetLoopbackRecordingVolume()
        {


            var nRet = RtcEngine.GetLoopbackRecordingVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableInEarMonitoring()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            int includeAudioFilters = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.EnableInEarMonitoring(enabled, includeAudioFilters);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetInEarMonitoringVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetInEarMonitoringVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineLoadExtensionProvider()
        {
            string path = ParamsHelper.CreateParam<string>();
            bool unload_after_use = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.LoadExtensionProvider(path, unload_after_use);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetExtensionProviderProperty()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetExtensionProviderProperty(provider, key, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineRegisterExtension()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.RegisterExtension(provider, extension, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableExtension2()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            bool enable = ParamsHelper.CreateParam<bool>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.EnableExtension(provider, extension, enable, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetExtensionProperty2()
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
        public void Test_IRtcEngineGetExtensionProperty2()
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
        public void Test_IRtcEngineSetCameraCapturerConfiguration()
        {
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngine.SetCameraCapturerConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineCreateCustomVideoTrack()
        {


            var nRet = RtcEngine.CreateCustomVideoTrack();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineCreateCustomEncodedVideoTrack()
        {
            SenderOptions sender_option = ParamsHelper.CreateParam<SenderOptions>();

            var nRet = RtcEngine.CreateCustomEncodedVideoTrack(sender_option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineDestroyCustomVideoTrack()
        {
            uint video_track_id = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.DestroyCustomVideoTrack(video_track_id);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineDestroyCustomEncodedVideoTrack()
        {
            uint video_track_id = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.DestroyCustomEncodedVideoTrack(video_track_id);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSwitchCamera()
        {


            var nRet = RtcEngine.SwitchCamera();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineIsCameraZoomSupported()
        {


            var nRet = RtcEngine.IsCameraZoomSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineIsCameraFaceDetectSupported()
        {


            var nRet = RtcEngine.IsCameraFaceDetectSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineIsCameraTorchSupported()
        {


            var nRet = RtcEngine.IsCameraTorchSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineIsCameraFocusSupported()
        {


            var nRet = RtcEngine.IsCameraFocusSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineIsCameraAutoFocusFaceModeSupported()
        {


            var nRet = RtcEngine.IsCameraAutoFocusFaceModeSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetCameraZoomFactor()
        {
            float factor = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraZoomFactor(factor);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableFaceDetection()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableFaceDetection(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetCameraMaxZoomFactor()
        {


            var nRet = RtcEngine.GetCameraMaxZoomFactor();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetCameraFocusPositionInPreview()
        {
            float positionX = ParamsHelper.CreateParam<float>();
            float positionY = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraFocusPositionInPreview(positionX, positionY);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetCameraTorchOn()
        {
            bool isOn = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetCameraTorchOn(isOn);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetCameraAutoFocusFaceModeEnabled()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetCameraAutoFocusFaceModeEnabled(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineIsCameraExposurePositionSupported()
        {


            var nRet = RtcEngine.IsCameraExposurePositionSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetCameraExposurePosition()
        {
            float positionXinView = ParamsHelper.CreateParam<float>();
            float positionYinView = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraExposurePosition(positionXinView, positionYinView);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineIsCameraExposureSupported()
        {


            var nRet = RtcEngine.IsCameraExposureSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetCameraExposureFactor()
        {
            float factor = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraExposureFactor(factor);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineIsCameraAutoExposureFaceModeSupported()
        {


            var nRet = RtcEngine.IsCameraAutoExposureFaceModeSupported();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetCameraAutoExposureFaceModeEnabled()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetCameraAutoExposureFaceModeEnabled(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetDefaultAudioRouteToSpeakerphone()
        {
            bool defaultToSpeaker = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetDefaultAudioRouteToSpeakerphone(defaultToSpeaker);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetEnableSpeakerphone()
        {
            bool speakerOn = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetEnableSpeakerphone(speakerOn);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineIsSpeakerphoneEnabled()
        {


            var nRet = RtcEngine.IsSpeakerphoneEnabled();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetRouteInCommunicationMode()
        {
            int route = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetRouteInCommunicationMode(route);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetScreenCaptureSources()
        {
            SIZE thumbSize = ParamsHelper.CreateParam<SIZE>();
            SIZE iconSize = ParamsHelper.CreateParam<SIZE>();
            bool includeScreen = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.GetScreenCaptureSources(thumbSize, iconSize, includeScreen);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetAudioSessionOperationRestriction()
        {
            AUDIO_SESSION_OPERATION_RESTRICTION restriction = ParamsHelper.CreateParam<AUDIO_SESSION_OPERATION_RESTRICTION>();

            var nRet = RtcEngine.SetAudioSessionOperationRestriction(restriction);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartScreenCaptureByDisplayId()
        {
            uint displayId = ParamsHelper.CreateParam<uint>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);
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

        [Test]
        public void Test_IRtcEngineGetAudioDeviceInfo()
        {
            DeviceInfoMobile deviceInfo = ParamsHelper.CreateParam<DeviceInfoMobile>();

            var nRet = RtcEngine.GetAudioDeviceInfo(ref deviceInfo);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartScreenCaptureByWindowId()
        {
            view_t windowId = ParamsHelper.CreateParam<view_t>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.StartScreenCaptureByWindowId(windowId, regionRect, captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetScreenCaptureContentHint()
        {
            VIDEO_CONTENT_HINT contentHint = ParamsHelper.CreateParam<VIDEO_CONTENT_HINT>();

            var nRet = RtcEngine.SetScreenCaptureContentHint(contentHint);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUpdateScreenCaptureRegion()
        {
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();

            var nRet = RtcEngine.UpdateScreenCaptureRegion(regionRect);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUpdateScreenCaptureParameters()
        {
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.UpdateScreenCaptureParameters(captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartScreenCapture()
        {
            ScreenCaptureParameters2 captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters2>();

            var nRet = RtcEngine.StartScreenCapture(captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUpdateScreenCapture()
        {
            ScreenCaptureParameters2 captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters2>();

            var nRet = RtcEngine.UpdateScreenCapture(captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineQueryScreenCaptureCapability()
        {


            var nRet = RtcEngine.QueryScreenCaptureCapability();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetScreenCaptureScenario()
        {
            SCREEN_SCENARIO_TYPE screenScenario = ParamsHelper.CreateParam<SCREEN_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetScreenCaptureScenario(screenScenario);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopScreenCapture()
        {


            var nRet = RtcEngine.StopScreenCapture();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetCallId()
        {
            string callId = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.GetCallId(ref callId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineRate()
        {
            string callId = ParamsHelper.CreateParam<string>();
            int rating = ParamsHelper.CreateParam<int>();
            string description = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.Rate(callId, rating, description);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineComplain()
        {
            string callId = ParamsHelper.CreateParam<string>();
            string description = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.Complain(callId, description);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartRtmpStreamWithoutTranscoding()
        {
            string url = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.StartRtmpStreamWithoutTranscoding(url);
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
        public void Test_IRtcEngineStopRtmpStream()
        {
            string url = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.StopRtmpStream(url);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopLocalVideoTranscoder()
        {


            var nRet = RtcEngine.StopLocalVideoTranscoder();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartCameraCapture()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngine.StartCameraCapture(sourceType, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopCameraCapture()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StopCameraCapture(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetCameraDeviceOrientation()
        {
            VIDEO_SOURCE_TYPE type = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            VIDEO_ORIENTATION orientation = ParamsHelper.CreateParam<VIDEO_ORIENTATION>();

            var nRet = RtcEngine.SetCameraDeviceOrientation(type, orientation);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetScreenCaptureOrientation()
        {
            VIDEO_SOURCE_TYPE type = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            VIDEO_ORIENTATION orientation = ParamsHelper.CreateParam<VIDEO_ORIENTATION>();

            var nRet = RtcEngine.SetScreenCaptureOrientation(type, orientation);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartScreenCapture2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            ScreenCaptureConfiguration config = ParamsHelper.CreateParam<ScreenCaptureConfiguration>();

            var nRet = RtcEngine.StartScreenCapture(sourceType, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopScreenCapture2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StopScreenCapture(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetConnectionState()
        {


            var nRet = RtcEngine.GetConnectionState();
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
        public void Test_IRtcEngineEnableEncryption()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            EncryptionConfig config = ParamsHelper.CreateParam<EncryptionConfig>();

            var nRet = RtcEngine.EnableEncryption(enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineCreateDataStream()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            bool reliable = ParamsHelper.CreateParam<bool>();
            bool ordered = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.CreateDataStream(ref streamId, reliable, ordered);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineCreateDataStream2()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            DataStreamConfig config = ParamsHelper.CreateParam<DataStreamConfig>();

            var nRet = RtcEngine.CreateDataStream(ref streamId, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSendStreamMessage()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            byte[] data = ParamsHelper.CreateParam<byte[]>();
            uint length = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SendStreamMessage(streamId, data, length);
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
        public void Test_IRtcEngineAddVideoWatermark2()
        {
            string watermarkUrl = ParamsHelper.CreateParam<string>();
            WatermarkOptions options = ParamsHelper.CreateParam<WatermarkOptions>();

            var nRet = RtcEngine.AddVideoWatermark(watermarkUrl, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineClearVideoWatermarks()
        {


            var nRet = RtcEngine.ClearVideoWatermarks();
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
        public void Test_IRtcEngineSendCustomReportMessage()
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
        public void Test_IRtcEngineSetAINSMode()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            AUDIO_AINS_MODE mode = ParamsHelper.CreateParam<AUDIO_AINS_MODE>();

            var nRet = RtcEngine.SetAINSMode(enabled, mode);
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
        public void Test_IRtcEngineStopChannelMediaRelay()
        {


            var nRet = RtcEngine.StopChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEnginePauseAllChannelMediaRelay()
        {


            var nRet = RtcEngine.PauseAllChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineResumeAllChannelMediaRelay()
        {


            var nRet = RtcEngine.ResumeAllChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetDirectCdnStreamingAudioConfiguration()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();

            var nRet = RtcEngine.SetDirectCdnStreamingAudioConfiguration(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetDirectCdnStreamingVideoConfiguration()
        {
            VideoEncoderConfiguration config = ParamsHelper.CreateParam<VideoEncoderConfiguration>();

            var nRet = RtcEngine.SetDirectCdnStreamingVideoConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartDirectCdnStreaming()
        {
            string publishUrl = ParamsHelper.CreateParam<string>();
            DirectCdnStreamingMediaOptions options = ParamsHelper.CreateParam<DirectCdnStreamingMediaOptions>();

            var nRet = RtcEngine.StartDirectCdnStreaming(publishUrl, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopDirectCdnStreaming()
        {


            var nRet = RtcEngine.StopDirectCdnStreaming();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineUpdateDirectCdnStreamingMediaOptions()
        {
            DirectCdnStreamingMediaOptions options = ParamsHelper.CreateParam<DirectCdnStreamingMediaOptions>();

            var nRet = RtcEngine.UpdateDirectCdnStreamingMediaOptions(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartRhythmPlayer()
        {
            string sound1 = ParamsHelper.CreateParam<string>();
            string sound2 = ParamsHelper.CreateParam<string>();
            AgoraRhythmPlayerConfig config = ParamsHelper.CreateParam<AgoraRhythmPlayerConfig>();

            var nRet = RtcEngine.StartRhythmPlayer(sound1, sound2, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStopRhythmPlayer()
        {


            var nRet = RtcEngine.StopRhythmPlayer();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineConfigRhythmPlayer()
        {
            AgoraRhythmPlayerConfig config = ParamsHelper.CreateParam<AgoraRhythmPlayerConfig>();

            var nRet = RtcEngine.ConfigRhythmPlayer(config);
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
        public void Test_IRtcEngineEnableContentInspect()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            ContentInspectConfig config = ParamsHelper.CreateParam<ContentInspectConfig>();

            var nRet = RtcEngine.EnableContentInspect(enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineAdjustCustomAudioPublishVolume()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustCustomAudioPublishVolume(trackId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineAdjustCustomAudioPlayoutVolume()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustCustomAudioPlayoutVolume(trackId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetCloudProxy()
        {
            CLOUD_PROXY_TYPE proxyType = ParamsHelper.CreateParam<CLOUD_PROXY_TYPE>();

            var nRet = RtcEngine.SetCloudProxy(proxyType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetLocalAccessPoint()
        {
            LocalAccessPointConfiguration config = ParamsHelper.CreateParam<LocalAccessPointConfiguration>();

            var nRet = RtcEngine.SetLocalAccessPoint(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetAdvancedAudioOptions()
        {
            AdvancedAudioOptions options = ParamsHelper.CreateParam<AdvancedAudioOptions>();
            int sourceType = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAdvancedAudioOptions(options, sourceType);
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
        public void Test_IRtcEngineEnableVideoImageSource()
        {
            bool enable = ParamsHelper.CreateParam<bool>();
            ImageTrackOptions options = ParamsHelper.CreateParam<ImageTrackOptions>();

            var nRet = RtcEngine.EnableVideoImageSource(enable, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetCurrentMonotonicTimeInMs()
        {


            var nRet = RtcEngine.GetCurrentMonotonicTimeInMs();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableWirelessAccelerate()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableWirelessAccelerate(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetNetworkType()
        {


            var nRet = RtcEngine.GetNetworkType();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineSetParameters()
        {
            string parameters = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetParameters(parameters);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineStartMediaRenderingTracing()
        {


            var nRet = RtcEngine.StartMediaRenderingTracing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEnableInstantMediaRendering()
        {


            var nRet = RtcEngine.EnableInstantMediaRendering();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineGetNtpWallTimeInMs()
        {


            var nRet = RtcEngine.GetNtpWallTimeInMs();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineIsFeatureAvailableOnDevice()
        {
            FeatureType type = ParamsHelper.CreateParam<FeatureType>();

            var nRet = RtcEngine.IsFeatureAvailableOnDevice(type);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IRtcEngine

        #region terra IMediaEngine
        [Test]
        public void Test_IMediaEnginePushAudioFrame()
        {
            AudioFrame frame = ParamsHelper.CreateParam<AudioFrame>();
            uint trackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngine.PushAudioFrame(frame, trackId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEnginePullAudioFrame()
        {
            AudioFrame frame = ParamsHelper.CreateParam<AudioFrame>();

            var nRet = MediaEngine.PullAudioFrame(frame);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngineSetExternalVideoSource()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            bool useTexture = ParamsHelper.CreateParam<bool>();
            EXTERNAL_VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<EXTERNAL_VIDEO_SOURCE_TYPE>();
            SenderOptions encodedVideoOption = ParamsHelper.CreateParam<SenderOptions>();

            var nRet = MediaEngine.SetExternalVideoSource(enabled, useTexture, sourceType, encodedVideoOption);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngineSetExternalAudioSource()
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
        public void Test_IMediaEngineCreateCustomAudioTrack()
        {
            AUDIO_TRACK_TYPE trackType = ParamsHelper.CreateParam<AUDIO_TRACK_TYPE>();
            AudioTrackConfig config = ParamsHelper.CreateParam<AudioTrackConfig>();

            var nRet = MediaEngine.CreateCustomAudioTrack(trackType, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngineDestroyCustomAudioTrack()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngine.DestroyCustomAudioTrack(trackId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngineSetExternalAudioSink()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channels = ParamsHelper.CreateParam<int>();

            var nRet = MediaEngine.SetExternalAudioSink(enabled, sampleRate, channels);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEnginePushVideoFrame()
        {
            ExternalVideoFrame frame = ParamsHelper.CreateParam<ExternalVideoFrame>();
            uint videoTrackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngine.PushVideoFrame(frame, videoTrackId);
            Assert.AreEqual(0, nRet);
        }

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