using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc.Ut
{
    using uid_t = System.UInt32;
    using view_t = System.UInt64;
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

        [Test]
        public void Test_IRtcEngine_StartScreenCapture()
        {
            ScreenCaptureParameters2 captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters2>();

            var nRet = RtcEngine.StartScreenCapture(captureParams);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartScreenCapture2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            ScreenCaptureConfiguration config = ParamsHelper.CreateParam<ScreenCaptureConfiguration>();

            var nRet = RtcEngine.StartScreenCapture(sourceType, config);
            Assert.AreEqual(0, nRet);
        }

        #region terra IRtcEngine
        [Test]
        public void Test_IRtcEngine_GetVersion()
        {
            int build = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetVersion(ref build);
            Assert.AreEqual("v1", nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetErrorDescription()
        {
            int code = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetErrorDescription(code);
            Assert.AreEqual("fatal", nRet);
        }

        [Test]
        public void Test_IRtcEngine_QueryCodecCapability()
        {
            CodecCapInfo[] codecInfo = ParamsHelper.CreateParam<CodecCapInfo[]>();
            int size = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.QueryCodecCapability(ref codecInfo, ref size);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_QueryDeviceScore()
        {


            var nRet = RtcEngine.QueryDeviceScore();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_PreloadChannel()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.PreloadChannel(token, channelId, uid);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_PreloadChannelWithUserAccount()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.PreloadChannelWithUserAccount(token, channelId, userAccount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UpdatePreloadChannelToken()
        {
            string token = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.UpdatePreloadChannelToken(token);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_JoinChannel()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string info = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.JoinChannel(token, channelId, info, uid);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_JoinChannel2()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngine.JoinChannel(token, channelId, uid, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UpdateChannelMediaOptions()
        {
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngine.UpdateChannelMediaOptions(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_LeaveChannel()
        {


            var nRet = RtcEngine.LeaveChannel();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_LeaveChannel2()
        {
            LeaveChannelOptions options = ParamsHelper.CreateParam<LeaveChannelOptions>();

            var nRet = RtcEngine.LeaveChannel(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_RenewToken()
        {
            string token = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.RenewToken(token);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetChannelProfile()
        {
            CHANNEL_PROFILE_TYPE profile = ParamsHelper.CreateParam<CHANNEL_PROFILE_TYPE>();

            var nRet = RtcEngine.SetChannelProfile(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetClientRole()
        {
            CLIENT_ROLE_TYPE role = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();

            var nRet = RtcEngine.SetClientRole(role);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetClientRole2()
        {
            CLIENT_ROLE_TYPE role = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();
            ClientRoleOptions options = ParamsHelper.CreateParam<ClientRoleOptions>();

            var nRet = RtcEngine.SetClientRole(role, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartEchoTest()
        {
            EchoTestConfiguration config = ParamsHelper.CreateParam<EchoTestConfiguration>();

            var nRet = RtcEngine.StartEchoTest(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopEchoTest()
        {


            var nRet = RtcEngine.StopEchoTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableMultiCamera()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngine.EnableMultiCamera(enabled, config);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableVideo()
        {


            var nRet = RtcEngine.EnableVideo();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_DisableVideo()
        {


            var nRet = RtcEngine.DisableVideo();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartPreview()
        {


            var nRet = RtcEngine.StartPreview();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StartPreview(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopPreview()
        {


            var nRet = RtcEngine.StopPreview();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StopPreview(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartLastmileProbeTest()
        {
            LastmileProbeConfig config = ParamsHelper.CreateParam<LastmileProbeConfig>();

            var nRet = RtcEngine.StartLastmileProbeTest(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopLastmileProbeTest()
        {


            var nRet = RtcEngine.StopLastmileProbeTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetVideoEncoderConfiguration()
        {
            VideoEncoderConfiguration config = ParamsHelper.CreateParam<VideoEncoderConfiguration>();

            var nRet = RtcEngine.SetVideoEncoderConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetBeautyEffectOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            BeautyOptions options = ParamsHelper.CreateParam<BeautyOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetBeautyEffectOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetFaceShapeBeautyOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            FaceShapeBeautyOptions options = ParamsHelper.CreateParam<FaceShapeBeautyOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetFaceShapeBeautyOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetFaceShapeAreaOptions()
        {
            FaceShapeAreaOptions options = ParamsHelper.CreateParam<FaceShapeAreaOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetFaceShapeAreaOptions(options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetFaceShapeBeautyOptions()
        {
            FaceShapeBeautyOptions options = ParamsHelper.CreateParam<FaceShapeBeautyOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.GetFaceShapeBeautyOptions(ref options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetFaceShapeAreaOptions()
        {
            FACE_SHAPE_AREA shapeArea = ParamsHelper.CreateParam<FACE_SHAPE_AREA>();
            FaceShapeAreaOptions options = ParamsHelper.CreateParam<FaceShapeAreaOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.GetFaceShapeAreaOptions(shapeArea, ref options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLowlightEnhanceOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            LowlightEnhanceOptions options = ParamsHelper.CreateParam<LowlightEnhanceOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetLowlightEnhanceOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetVideoDenoiserOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            VideoDenoiserOptions options = ParamsHelper.CreateParam<VideoDenoiserOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetVideoDenoiserOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetColorEnhanceOptions()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            ColorEnhanceOptions options = ParamsHelper.CreateParam<ColorEnhanceOptions>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.SetColorEnhanceOptions(enabled, options, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableVirtualBackground()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            VirtualBackgroundSource backgroundSource = ParamsHelper.CreateParam<VirtualBackgroundSource>();
            SegmentationProperty segproperty = ParamsHelper.CreateParam<SegmentationProperty>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.EnableVirtualBackground(enabled, backgroundSource, segproperty, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetupRemoteVideo()
        {
            VideoCanvas canvas = ParamsHelper.CreateParam<VideoCanvas>();

            var nRet = RtcEngine.SetupRemoteVideo(canvas);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetupLocalVideo()
        {
            VideoCanvas canvas = ParamsHelper.CreateParam<VideoCanvas>();

            var nRet = RtcEngine.SetupLocalVideo(canvas);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetVideoScenario()
        {
            VIDEO_APPLICATION_SCENARIO_TYPE scenarioType = ParamsHelper.CreateParam<VIDEO_APPLICATION_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetVideoScenario(scenarioType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetVideoQoEPreference()
        {
            VIDEO_QOE_PREFERENCE_TYPE qoePreference = ParamsHelper.CreateParam<VIDEO_QOE_PREFERENCE_TYPE>();

            var nRet = RtcEngine.SetVideoQoEPreference(qoePreference);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableAudio()
        {


            var nRet = RtcEngine.EnableAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_DisableAudio()
        {


            var nRet = RtcEngine.DisableAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAudioProfile()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();
            AUDIO_SCENARIO_TYPE scenario = ParamsHelper.CreateParam<AUDIO_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetAudioProfile(profile, scenario);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAudioProfile2()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();

            var nRet = RtcEngine.SetAudioProfile(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAudioScenario()
        {
            AUDIO_SCENARIO_TYPE scenario = ParamsHelper.CreateParam<AUDIO_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetAudioScenario(scenario);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableLocalAudio()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableLocalAudio(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_MuteLocalAudioStream()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteLocalAudioStream(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_MuteAllRemoteAudioStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteAllRemoteAudioStreams(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_MuteRemoteAudioStream()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteRemoteAudioStream(uid, mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_MuteLocalVideoStream()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteLocalVideoStream(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableLocalVideo()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableLocalVideo(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_MuteAllRemoteVideoStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteAllRemoteVideoStreams(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetRemoteDefaultVideoStreamType()
        {
            VIDEO_STREAM_TYPE streamType = ParamsHelper.CreateParam<VIDEO_STREAM_TYPE>();

            var nRet = RtcEngine.SetRemoteDefaultVideoStreamType(streamType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_MuteRemoteVideoStream()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteRemoteVideoStream(uid, mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetRemoteVideoStreamType()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            VIDEO_STREAM_TYPE streamType = ParamsHelper.CreateParam<VIDEO_STREAM_TYPE>();

            var nRet = RtcEngine.SetRemoteVideoStreamType(uid, streamType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetRemoteVideoSubscriptionOptions()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            VideoSubscriptionOptions options = ParamsHelper.CreateParam<VideoSubscriptionOptions>();

            var nRet = RtcEngine.SetRemoteVideoSubscriptionOptions(uid, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetSubscribeAudioBlocklist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeAudioBlocklist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetSubscribeAudioAllowlist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeAudioAllowlist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetSubscribeVideoBlocklist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeVideoBlocklist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetSubscribeVideoAllowlist()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetSubscribeVideoAllowlist(uidList, uidNumber);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableAudioVolumeIndication()
        {
            int interval = ParamsHelper.CreateParam<int>();
            int smooth = ParamsHelper.CreateParam<int>();
            bool reportVad = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableAudioVolumeIndication(interval, smooth, reportVad);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartAudioRecording()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            AUDIO_RECORDING_QUALITY_TYPE quality = ParamsHelper.CreateParam<AUDIO_RECORDING_QUALITY_TYPE>();

            var nRet = RtcEngine.StartAudioRecording(filePath, quality);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartAudioRecording2()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            int sampleRate = ParamsHelper.CreateParam<int>();
            AUDIO_RECORDING_QUALITY_TYPE quality = ParamsHelper.CreateParam<AUDIO_RECORDING_QUALITY_TYPE>();

            var nRet = RtcEngine.StartAudioRecording(filePath, sampleRate, quality);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartAudioRecording3()
        {
            AudioRecordingConfiguration config = ParamsHelper.CreateParam<AudioRecordingConfiguration>();

            var nRet = RtcEngine.StartAudioRecording(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopAudioRecording()
        {


            var nRet = RtcEngine.StopAudioRecording();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartAudioMixing()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            bool loopback = ParamsHelper.CreateParam<bool>();
            int cycle = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.StartAudioMixing(filePath, loopback, cycle);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartAudioMixing2()
        {
            string filePath = ParamsHelper.CreateParam<string>();
            bool loopback = ParamsHelper.CreateParam<bool>();
            int cycle = ParamsHelper.CreateParam<int>();
            int startPos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.StartAudioMixing(filePath, loopback, cycle, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopAudioMixing()
        {


            var nRet = RtcEngine.StopAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_PauseAudioMixing()
        {


            var nRet = RtcEngine.PauseAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_ResumeAudioMixing()
        {


            var nRet = RtcEngine.ResumeAudioMixing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SelectAudioTrack()
        {
            int index = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SelectAudioTrack(index);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetAudioTrackCount()
        {


            var nRet = RtcEngine.GetAudioTrackCount();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_AdjustAudioMixingVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustAudioMixingVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_AdjustAudioMixingPublishVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustAudioMixingPublishVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetAudioMixingPublishVolume()
        {


            var nRet = RtcEngine.GetAudioMixingPublishVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_AdjustAudioMixingPlayoutVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustAudioMixingPlayoutVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetAudioMixingPlayoutVolume()
        {


            var nRet = RtcEngine.GetAudioMixingPlayoutVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetAudioMixingDuration()
        {


            var nRet = RtcEngine.GetAudioMixingDuration();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetAudioMixingCurrentPosition()
        {


            var nRet = RtcEngine.GetAudioMixingCurrentPosition();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAudioMixingPosition()
        {
            int pos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAudioMixingPosition(pos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAudioMixingDualMonoMode()
        {
            AUDIO_MIXING_DUAL_MONO_MODE mode = ParamsHelper.CreateParam<AUDIO_MIXING_DUAL_MONO_MODE>();

            var nRet = RtcEngine.SetAudioMixingDualMonoMode(mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAudioMixingPitch()
        {
            int pitch = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAudioMixingPitch(pitch);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAudioMixingPlaybackSpeed()
        {
            int speed = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAudioMixingPlaybackSpeed(speed);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetEffectsVolume()
        {


            var nRet = RtcEngine.GetEffectsVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetEffectsVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetEffectsVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_PreloadEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            string filePath = ParamsHelper.CreateParam<string>();
            int startPos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.PreloadEffect(soundId, filePath, startPos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_PlayEffect()
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
        public void Test_IRtcEngine_PlayAllEffects()
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
        public void Test_IRtcEngine_GetVolumeOfEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetVolumeOfEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetVolumeOfEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetVolumeOfEffect(soundId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_PauseEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.PauseEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_PauseAllEffects()
        {


            var nRet = RtcEngine.PauseAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_ResumeEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.ResumeEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_ResumeAllEffects()
        {


            var nRet = RtcEngine.ResumeAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.StopEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopAllEffects()
        {


            var nRet = RtcEngine.StopAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UnloadEffect()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.UnloadEffect(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UnloadAllEffects()
        {


            var nRet = RtcEngine.UnloadAllEffects();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetEffectDuration()
        {
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.GetEffectDuration(filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetEffectPosition()
        {
            int soundId = ParamsHelper.CreateParam<int>();
            int pos = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetEffectPosition(soundId, pos);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetEffectCurrentPosition()
        {
            int soundId = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.GetEffectCurrentPosition(soundId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableSoundPositionIndication()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableSoundPositionIndication(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetRemoteVoicePosition()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            double pan = ParamsHelper.CreateParam<double>();
            double gain = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngine.SetRemoteVoicePosition(uid, pan, gain);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableSpatialAudio()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableSpatialAudio(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetRemoteUserSpatialAudioParams()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            SpatialAudioParams @params = ParamsHelper.CreateParam<SpatialAudioParams>();

            var nRet = RtcEngine.SetRemoteUserSpatialAudioParams(uid, @params);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetVoiceBeautifierPreset()
        {
            VOICE_BEAUTIFIER_PRESET preset = ParamsHelper.CreateParam<VOICE_BEAUTIFIER_PRESET>();

            var nRet = RtcEngine.SetVoiceBeautifierPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAudioEffectPreset()
        {
            AUDIO_EFFECT_PRESET preset = ParamsHelper.CreateParam<AUDIO_EFFECT_PRESET>();

            var nRet = RtcEngine.SetAudioEffectPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetVoiceConversionPreset()
        {
            VOICE_CONVERSION_PRESET preset = ParamsHelper.CreateParam<VOICE_CONVERSION_PRESET>();

            var nRet = RtcEngine.SetVoiceConversionPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAudioEffectParameters()
        {
            AUDIO_EFFECT_PRESET preset = ParamsHelper.CreateParam<AUDIO_EFFECT_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAudioEffectParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetVoiceBeautifierParameters()
        {
            VOICE_BEAUTIFIER_PRESET preset = ParamsHelper.CreateParam<VOICE_BEAUTIFIER_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetVoiceBeautifierParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetVoiceConversionParameters()
        {
            VOICE_CONVERSION_PRESET preset = ParamsHelper.CreateParam<VOICE_CONVERSION_PRESET>();
            int param1 = ParamsHelper.CreateParam<int>();
            int param2 = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetVoiceConversionParameters(preset, param1, param2);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLocalVoicePitch()
        {
            double pitch = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngine.SetLocalVoicePitch(pitch);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLocalVoiceFormant()
        {
            double formantRatio = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngine.SetLocalVoiceFormant(formantRatio);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLocalVoiceEqualization()
        {
            AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency = ParamsHelper.CreateParam<AUDIO_EQUALIZATION_BAND_FREQUENCY>();
            int bandGain = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetLocalVoiceEqualization(bandFrequency, bandGain);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLocalVoiceReverb()
        {
            AUDIO_REVERB_TYPE reverbKey = ParamsHelper.CreateParam<AUDIO_REVERB_TYPE>();
            int value = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetLocalVoiceReverb(reverbKey, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetHeadphoneEQPreset()
        {
            HEADPHONE_EQUALIZER_PRESET preset = ParamsHelper.CreateParam<HEADPHONE_EQUALIZER_PRESET>();

            var nRet = RtcEngine.SetHeadphoneEQPreset(preset);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetHeadphoneEQParameters()
        {
            int lowGain = ParamsHelper.CreateParam<int>();
            int highGain = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetHeadphoneEQParameters(lowGain, highGain);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableVoiceAITuner()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            VOICE_AI_TUNER_TYPE type = ParamsHelper.CreateParam<VOICE_AI_TUNER_TYPE>();

            var nRet = RtcEngine.EnableVoiceAITuner(enabled, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLogFile()
        {
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetLogFile(filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLogFilter()
        {
            uint filter = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SetLogFilter(filter);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLogLevel()
        {
            LOG_LEVEL level = ParamsHelper.CreateParam<LOG_LEVEL>();

            var nRet = RtcEngine.SetLogLevel(level);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLogFileSize()
        {
            uint fileSizeInKBytes = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SetLogFileSize(fileSizeInKBytes);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UploadLogFile()
        {
            string requestId = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.UploadLogFile(ref requestId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_WriteLog()
        {
            LOG_LEVEL level = ParamsHelper.CreateParam<LOG_LEVEL>();
            string fmt = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.WriteLog(level, fmt);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLocalRenderMode()
        {
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngine.SetLocalRenderMode(renderMode, mirrorMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetRemoteRenderMode()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngine.SetRemoteRenderMode(uid, renderMode, mirrorMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLocalRenderMode2()
        {
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();

            var nRet = RtcEngine.SetLocalRenderMode(renderMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLocalVideoMirrorMode()
        {
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngine.SetLocalVideoMirrorMode(mirrorMode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableDualStreamMode()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableDualStreamMode(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableDualStreamMode2()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();

            var nRet = RtcEngine.EnableDualStreamMode(enabled, streamConfig);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetDualStreamMode()
        {
            SIMULCAST_STREAM_MODE mode = ParamsHelper.CreateParam<SIMULCAST_STREAM_MODE>();

            var nRet = RtcEngine.SetDualStreamMode(mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetSimulcastConfig()
        {
            SimulcastConfig simulcastConfig = ParamsHelper.CreateParam<SimulcastConfig>();

            var nRet = RtcEngine.SetSimulcastConfig(simulcastConfig);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetDualStreamMode2()
        {
            SIMULCAST_STREAM_MODE mode = ParamsHelper.CreateParam<SIMULCAST_STREAM_MODE>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();

            var nRet = RtcEngine.SetDualStreamMode(mode, streamConfig);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableCustomAudioLocalPlayback()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableCustomAudioLocalPlayback(trackId, enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetRecordingAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetRecordingAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetPlaybackAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetPlaybackAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetMixedAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetMixedAudioFrameParameters(sampleRate, channel, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetEarMonitoringAudioFrameParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode = ParamsHelper.CreateParam<RAW_AUDIO_FRAME_OP_MODE_TYPE>();
            int samplesPerCall = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetEarMonitoringAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetPlaybackAudioFrameBeforeMixingParameters()
        {
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channel = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetPlaybackAudioFrameBeforeMixingParameters(sampleRate, channel);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableAudioSpectrumMonitor()
        {
            int intervalInMS = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.EnableAudioSpectrumMonitor(intervalInMS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_DisableAudioSpectrumMonitor()
        {


            var nRet = RtcEngine.DisableAudioSpectrumMonitor();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UnregisterAudioSpectrumObserver()
        {


            var nRet = RtcEngine.UnregisterAudioSpectrumObserver();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_AdjustRecordingSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustRecordingSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_MuteRecordingSignal()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.MuteRecordingSignal(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_AdjustPlaybackSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustPlaybackSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_AdjustUserPlaybackSignalVolume()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustUserPlaybackSignalVolume(uid, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLocalPublishFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();

            var nRet = RtcEngine.SetLocalPublishFallbackOption(option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetRemoteSubscribeFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();

            var nRet = RtcEngine.SetRemoteSubscribeFallbackOption(option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetHighPriorityUserList()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNum = ParamsHelper.CreateParam<int>();
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();

            var nRet = RtcEngine.SetHighPriorityUserList(uidList, uidNum, option);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableExtension()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            ExtensionInfo extensionInfo = ParamsHelper.CreateParam<ExtensionInfo>();
            bool enable = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableExtension(provider, extension, extensionInfo, enable);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetExtensionProperty()
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
        public void Test_IRtcEngine_GetExtensionProperty()
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
        public void Test_IRtcEngine_EnableLoopbackRecording()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            string deviceName = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.EnableLoopbackRecording(enabled, deviceName);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_AdjustLoopbackSignalVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustLoopbackSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetLoopbackRecordingVolume()
        {


            var nRet = RtcEngine.GetLoopbackRecordingVolume();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableInEarMonitoring()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            int includeAudioFilters = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.EnableInEarMonitoring(enabled, includeAudioFilters);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetInEarMonitoringVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetInEarMonitoringVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_LoadExtensionProvider()
        {
            string path = ParamsHelper.CreateParam<string>();
            bool unload_after_use = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.LoadExtensionProvider(path, unload_after_use);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetExtensionProviderProperty()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetExtensionProviderProperty(provider, key, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_RegisterExtension()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.RegisterExtension(provider, extension, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableExtension2()
        {
            string provider = ParamsHelper.CreateParam<string>();
            string extension = ParamsHelper.CreateParam<string>();
            bool enable = ParamsHelper.CreateParam<bool>();
            MEDIA_SOURCE_TYPE type = ParamsHelper.CreateParam<MEDIA_SOURCE_TYPE>();

            var nRet = RtcEngine.EnableExtension(provider, extension, enable, type);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetExtensionProperty2()
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
        public void Test_IRtcEngine_GetExtensionProperty2()
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
        public void Test_IRtcEngine_SetCameraCapturerConfiguration()
        {
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngine.SetCameraCapturerConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_CreateCustomVideoTrack()
        {


            var nRet = RtcEngine.CreateCustomVideoTrack();
            Assert.AreEqual(true, nRet > 0);
        }

        [Test]
        public void Test_IRtcEngine_CreateCustomEncodedVideoTrack()
        {
            SenderOptions sender_option = ParamsHelper.CreateParam<SenderOptions>();

            var nRet = RtcEngine.CreateCustomEncodedVideoTrack(sender_option);
            Assert.AreEqual(true, nRet > 0);
        }

        [Test]
        public void Test_IRtcEngine_DestroyCustomVideoTrack()
        {
            uint video_track_id = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.DestroyCustomVideoTrack(video_track_id);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_DestroyCustomEncodedVideoTrack()
        {
            uint video_track_id = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.DestroyCustomEncodedVideoTrack(video_track_id);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SwitchCamera()
        {


            var nRet = RtcEngine.SwitchCamera();
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_IsCameraZoomSupported()
        {


            var nRet = RtcEngine.IsCameraZoomSupported();
            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IRtcEngine_IsCameraFaceDetectSupported()
        {


            var nRet = RtcEngine.IsCameraFaceDetectSupported();
            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IRtcEngine_IsCameraTorchSupported()
        {


            var nRet = RtcEngine.IsCameraTorchSupported();
            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IRtcEngine_IsCameraFocusSupported()
        {


            var nRet = RtcEngine.IsCameraFocusSupported();
            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IRtcEngine_IsCameraAutoFocusFaceModeSupported()
        {


            var nRet = RtcEngine.IsCameraAutoFocusFaceModeSupported();
            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetCameraZoomFactor()
        {
            float factor = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraZoomFactor(factor);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableFaceDetection()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableFaceDetection(enabled);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetCameraMaxZoomFactor()
        {


            var nRet = RtcEngine.GetCameraMaxZoomFactor();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetCameraFocusPositionInPreview()
        {
            float positionX = ParamsHelper.CreateParam<float>();
            float positionY = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraFocusPositionInPreview(positionX, positionY);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetCameraTorchOn()
        {
            bool isOn = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetCameraTorchOn(isOn);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetCameraAutoFocusFaceModeEnabled()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetCameraAutoFocusFaceModeEnabled(enabled);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_IsCameraExposurePositionSupported()
        {


            var nRet = RtcEngine.IsCameraExposurePositionSupported();
            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetCameraExposurePosition()
        {
            float positionXinView = ParamsHelper.CreateParam<float>();
            float positionYinView = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraExposurePosition(positionXinView, positionYinView);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_IsCameraExposureSupported()
        {


            var nRet = RtcEngine.IsCameraExposureSupported();
            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetCameraExposureFactor()
        {
            float factor = ParamsHelper.CreateParam<float>();

            var nRet = RtcEngine.SetCameraExposureFactor(factor);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_IsCameraAutoExposureFaceModeSupported()
        {


            var nRet = RtcEngine.IsCameraAutoExposureFaceModeSupported();
            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetCameraAutoExposureFaceModeEnabled()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetCameraAutoExposureFaceModeEnabled(enabled);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetCameraStabilizationMode()
        {
            CAMERA_STABILIZATION_MODE mode = ParamsHelper.CreateParam<CAMERA_STABILIZATION_MODE>();

            var nRet = RtcEngine.SetCameraStabilizationMode(mode);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetDefaultAudioRouteToSpeakerphone()
        {
            bool defaultToSpeaker = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetDefaultAudioRouteToSpeakerphone(defaultToSpeaker);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetEnableSpeakerphone()
        {
            bool speakerOn = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.SetEnableSpeakerphone(speakerOn);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_IsSpeakerphoneEnabled()
        {


            var nRet = RtcEngine.IsSpeakerphoneEnabled();
            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetRouteInCommunicationMode()
        {
            int route = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetRouteInCommunicationMode(route);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_IsCameraCenterStageSupported()
        {


            var nRet = RtcEngine.IsCameraCenterStageSupported();
            Assert.AreEqual(true, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableCameraCenterStage()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableCameraCenterStage(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAudioSessionOperationRestriction()
        {
            AUDIO_SESSION_OPERATION_RESTRICTION restriction = ParamsHelper.CreateParam<AUDIO_SESSION_OPERATION_RESTRICTION>();

            var nRet = RtcEngine.SetAudioSessionOperationRestriction(restriction);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartScreenCaptureByDisplayId()
        {
            uint displayId = ParamsHelper.CreateParam<uint>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartScreenCaptureByScreenRect()
        {
            Rectangle screenRect = ParamsHelper.CreateParam<Rectangle>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.StartScreenCaptureByScreenRect(screenRect, regionRect, captureParams);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetAudioDeviceInfo()
        {
            DeviceInfoMobile deviceInfo = ParamsHelper.CreateParam<DeviceInfoMobile>();

            var nRet = RtcEngine.GetAudioDeviceInfo(ref deviceInfo);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartScreenCaptureByWindowId()
        {
            view_t windowId = ParamsHelper.CreateParam<view_t>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.StartScreenCaptureByWindowId(windowId, regionRect, captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetScreenCaptureContentHint()
        {
            VIDEO_CONTENT_HINT contentHint = ParamsHelper.CreateParam<VIDEO_CONTENT_HINT>();

            var nRet = RtcEngine.SetScreenCaptureContentHint(contentHint);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UpdateScreenCaptureRegion()
        {
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();

            var nRet = RtcEngine.UpdateScreenCaptureRegion(regionRect);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UpdateScreenCaptureParameters()
        {
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.UpdateScreenCaptureParameters(captureParams);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UpdateScreenCapture()
        {
            ScreenCaptureParameters2 captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters2>();

            var nRet = RtcEngine.UpdateScreenCapture(captureParams);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_QueryScreenCaptureCapability()
        {


            var nRet = RtcEngine.QueryScreenCaptureCapability();
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_QueryCameraFocalLengthCapability()
        {
            FocalLengthInfo[] focalLengthInfos = ParamsHelper.CreateParam<FocalLengthInfo[]>();
            int size = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.QueryCameraFocalLengthCapability(ref focalLengthInfos, ref size);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetScreenCaptureScenario()
        {
            SCREEN_SCENARIO_TYPE screenScenario = ParamsHelper.CreateParam<SCREEN_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetScreenCaptureScenario(screenScenario);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopScreenCapture()
        {


            var nRet = RtcEngine.StopScreenCapture();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetCallId()
        {
            string callId = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.GetCallId(ref callId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_Rate()
        {
            string callId = ParamsHelper.CreateParam<string>();
            int rating = ParamsHelper.CreateParam<int>();
            string description = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.Rate(callId, rating, description);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_Complain()
        {
            string callId = ParamsHelper.CreateParam<string>();
            string description = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.Complain(callId, description);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartRtmpStreamWithoutTranscoding()
        {
            string url = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.StartRtmpStreamWithoutTranscoding(url);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartRtmpStreamWithTranscoding()
        {
            string url = ParamsHelper.CreateParam<string>();
            LiveTranscoding transcoding = ParamsHelper.CreateParam<LiveTranscoding>();

            var nRet = RtcEngine.StartRtmpStreamWithTranscoding(url, transcoding);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UpdateRtmpTranscoding()
        {
            LiveTranscoding transcoding = ParamsHelper.CreateParam<LiveTranscoding>();

            var nRet = RtcEngine.UpdateRtmpTranscoding(transcoding);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartLocalVideoTranscoder()
        {
            LocalTranscoderConfiguration config = ParamsHelper.CreateParam<LocalTranscoderConfiguration>();

            var nRet = RtcEngine.StartLocalVideoTranscoder(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UpdateLocalTranscoderConfiguration()
        {
            LocalTranscoderConfiguration config = ParamsHelper.CreateParam<LocalTranscoderConfiguration>();

            var nRet = RtcEngine.UpdateLocalTranscoderConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopRtmpStream()
        {
            string url = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.StopRtmpStream(url);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopLocalVideoTranscoder()
        {


            var nRet = RtcEngine.StopLocalVideoTranscoder();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartCameraCapture()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            CameraCapturerConfiguration config = ParamsHelper.CreateParam<CameraCapturerConfiguration>();

            var nRet = RtcEngine.StartCameraCapture(sourceType, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopCameraCapture()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StopCameraCapture(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetCameraDeviceOrientation()
        {
            VIDEO_SOURCE_TYPE type = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            VIDEO_ORIENTATION orientation = ParamsHelper.CreateParam<VIDEO_ORIENTATION>();

            var nRet = RtcEngine.SetCameraDeviceOrientation(type, orientation);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetScreenCaptureOrientation()
        {
            VIDEO_SOURCE_TYPE type = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            VIDEO_ORIENTATION orientation = ParamsHelper.CreateParam<VIDEO_ORIENTATION>();

            var nRet = RtcEngine.SetScreenCaptureOrientation(type, orientation);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopScreenCapture2()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();

            var nRet = RtcEngine.StopScreenCapture(sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetConnectionState()
        {


            var nRet = RtcEngine.GetConnectionState();
            Assert.AreEqual(CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetRemoteUserPriority()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            PRIORITY_TYPE userPriority = ParamsHelper.CreateParam<PRIORITY_TYPE>();

            var nRet = RtcEngine.SetRemoteUserPriority(uid, userPriority);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableEncryption()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            EncryptionConfig config = ParamsHelper.CreateParam<EncryptionConfig>();

            config.encryptionKdfSalt = new byte[32];
            var nRet = RtcEngine.EnableEncryption(enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_CreateDataStream()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            bool reliable = ParamsHelper.CreateParam<bool>();
            bool ordered = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.CreateDataStream(ref streamId, reliable, ordered);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_CreateDataStream2()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            DataStreamConfig config = ParamsHelper.CreateParam<DataStreamConfig>();

            var nRet = RtcEngine.CreateDataStream(ref streamId, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SendStreamMessage()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            byte[] data = ParamsHelper.CreateParam<byte[]>();
            uint length = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SendStreamMessage(streamId, data, length);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_AddVideoWatermark()
        {
            RtcImage watermark = ParamsHelper.CreateParam<RtcImage>();

            var nRet = RtcEngine.AddVideoWatermark(watermark);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_AddVideoWatermark2()
        {
            string watermarkUrl = ParamsHelper.CreateParam<string>();
            WatermarkOptions options = ParamsHelper.CreateParam<WatermarkOptions>();

            var nRet = RtcEngine.AddVideoWatermark(watermarkUrl, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_ClearVideoWatermarks()
        {


            var nRet = RtcEngine.ClearVideoWatermarks();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_PauseAudio()
        {


            var nRet = RtcEngine.PauseAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_ResumeAudio()
        {


            var nRet = RtcEngine.ResumeAudio();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableWebSdkInteroperability()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableWebSdkInteroperability(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SendCustomReportMessage()
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
        public void Test_IRtcEngine_UnregisterMediaMetadataObserver()
        {


            var nRet = RtcEngine.UnregisterMediaMetadataObserver();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartAudioFrameDump()
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
        public void Test_IRtcEngine_StopAudioFrameDump()
        {
            string channel_id = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();
            string location = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.StopAudioFrameDump(channel_id, uid, location);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAINSMode()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            AUDIO_AINS_MODE mode = ParamsHelper.CreateParam<AUDIO_AINS_MODE>();

            var nRet = RtcEngine.SetAINSMode(enabled, mode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_RegisterLocalUserAccount()
        {
            string appId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.RegisterLocalUserAccount(appId, userAccount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_JoinChannelWithUserAccount()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.JoinChannelWithUserAccount(token, channelId, userAccount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_JoinChannelWithUserAccount2()
        {
            string token = ParamsHelper.CreateParam<string>();
            string channelId = ParamsHelper.CreateParam<string>();
            string userAccount = ParamsHelper.CreateParam<string>();
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngine.JoinChannelWithUserAccount(token, channelId, userAccount, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetUserInfoByUserAccount()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            UserInfo userInfo = ParamsHelper.CreateParam<UserInfo>();

            var nRet = RtcEngine.GetUserInfoByUserAccount(userAccount, ref userInfo);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetUserInfoByUid()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            UserInfo userInfo = ParamsHelper.CreateParam<UserInfo>();

            var nRet = RtcEngine.GetUserInfoByUid(uid, ref userInfo);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartOrUpdateChannelMediaRelay()
        {
            ChannelMediaRelayConfiguration configuration = ParamsHelper.CreateParam<ChannelMediaRelayConfiguration>();

            var nRet = RtcEngine.StartOrUpdateChannelMediaRelay(configuration);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopChannelMediaRelay()
        {


            var nRet = RtcEngine.StopChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_PauseAllChannelMediaRelay()
        {


            var nRet = RtcEngine.PauseAllChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_ResumeAllChannelMediaRelay()
        {


            var nRet = RtcEngine.ResumeAllChannelMediaRelay();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetDirectCdnStreamingAudioConfiguration()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();

            var nRet = RtcEngine.SetDirectCdnStreamingAudioConfiguration(profile);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetDirectCdnStreamingVideoConfiguration()
        {
            VideoEncoderConfiguration config = ParamsHelper.CreateParam<VideoEncoderConfiguration>();

            var nRet = RtcEngine.SetDirectCdnStreamingVideoConfiguration(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartDirectCdnStreaming()
        {
            string publishUrl = ParamsHelper.CreateParam<string>();
            DirectCdnStreamingMediaOptions options = ParamsHelper.CreateParam<DirectCdnStreamingMediaOptions>();

            var nRet = RtcEngine.StartDirectCdnStreaming(publishUrl, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopDirectCdnStreaming()
        {


            var nRet = RtcEngine.StopDirectCdnStreaming();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_UpdateDirectCdnStreamingMediaOptions()
        {
            DirectCdnStreamingMediaOptions options = ParamsHelper.CreateParam<DirectCdnStreamingMediaOptions>();

            var nRet = RtcEngine.UpdateDirectCdnStreamingMediaOptions(options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartRhythmPlayer()
        {
            string sound1 = ParamsHelper.CreateParam<string>();
            string sound2 = ParamsHelper.CreateParam<string>();
            AgoraRhythmPlayerConfig config = ParamsHelper.CreateParam<AgoraRhythmPlayerConfig>();

            var nRet = RtcEngine.StartRhythmPlayer(sound1, sound2, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StopRhythmPlayer()
        {


            var nRet = RtcEngine.StopRhythmPlayer();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_ConfigRhythmPlayer()
        {
            AgoraRhythmPlayerConfig config = ParamsHelper.CreateParam<AgoraRhythmPlayerConfig>();

            var nRet = RtcEngine.ConfigRhythmPlayer(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_TakeSnapshot()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.TakeSnapshot(uid, filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableContentInspect()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            ContentInspectConfig config = ParamsHelper.CreateParam<ContentInspectConfig>();

            var nRet = RtcEngine.EnableContentInspect(enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_AdjustCustomAudioPublishVolume()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustCustomAudioPublishVolume(trackId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_AdjustCustomAudioPlayoutVolume()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustCustomAudioPlayoutVolume(trackId, volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetCloudProxy()
        {
            CLOUD_PROXY_TYPE proxyType = ParamsHelper.CreateParam<CLOUD_PROXY_TYPE>();

            var nRet = RtcEngine.SetCloudProxy(proxyType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetLocalAccessPoint()
        {
            LocalAccessPointConfiguration config = ParamsHelper.CreateParam<LocalAccessPointConfiguration>();

            var nRet = RtcEngine.SetLocalAccessPoint(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAdvancedAudioOptions()
        {
            AdvancedAudioOptions options = ParamsHelper.CreateParam<AdvancedAudioOptions>();
            int sourceType = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.SetAdvancedAudioOptions(options, sourceType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetAVSyncSource()
        {
            string channelId = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();

            var nRet = RtcEngine.SetAVSyncSource(channelId, uid);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableVideoImageSource()
        {
            bool enable = ParamsHelper.CreateParam<bool>();
            ImageTrackOptions options = ParamsHelper.CreateParam<ImageTrackOptions>();

            var nRet = RtcEngine.EnableVideoImageSource(enable, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetCurrentMonotonicTimeInMs()
        {


            var nRet = RtcEngine.GetCurrentMonotonicTimeInMs();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableWirelessAccelerate()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();

            var nRet = RtcEngine.EnableWirelessAccelerate(enabled);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetNetworkType()
        {


            var nRet = RtcEngine.GetNetworkType();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SetParameters()
        {
            string parameters = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetParameters(parameters);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_StartMediaRenderingTracing()
        {


            var nRet = RtcEngine.StartMediaRenderingTracing();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_EnableInstantMediaRendering()
        {


            var nRet = RtcEngine.EnableInstantMediaRendering();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngine_GetNtpWallTimeInMs()
        {


            var nRet = RtcEngine.GetNtpWallTimeInMs();
            Assert.AreEqual(true, nRet > 0);
        }

        [Test]
        public void Test_IRtcEngine_IsFeatureAvailableOnDevice()
        {
            FeatureType type = ParamsHelper.CreateParam<FeatureType>();

            var nRet = RtcEngine.IsFeatureAvailableOnDevice(type);
            Assert.AreEqual(true, nRet);
        }

        [Test]
        public void Test_IRtcEngine_SendAudioMetadata()
        {
            byte[] metadata = ParamsHelper.CreateParam<byte[]>();
            ulong length = ParamsHelper.CreateParam<ulong>();

            var nRet = RtcEngine.SendAudioMetadata(metadata, length);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IRtcEngine

        #region terra IMediaEngine
        [Test]
        public void Test_IMediaEngine_PushAudioFrame()
        {
            AudioFrame frame = ParamsHelper.CreateParam<AudioFrame>();
            uint trackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngine.PushAudioFrame(frame, trackId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngine_PullAudioFrame()
        {
            AudioFrame frame = ParamsHelper.CreateParam<AudioFrame>();

            var nRet = MediaEngine.PullAudioFrame(frame);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngine_SetExternalVideoSource()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            bool useTexture = ParamsHelper.CreateParam<bool>();
            EXTERNAL_VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<EXTERNAL_VIDEO_SOURCE_TYPE>();
            SenderOptions encodedVideoOption = ParamsHelper.CreateParam<SenderOptions>();

            var nRet = MediaEngine.SetExternalVideoSource(enabled, useTexture, sourceType, encodedVideoOption);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngine_SetExternalAudioSource()
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
        public void Test_IMediaEngine_CreateCustomAudioTrack()
        {
            AUDIO_TRACK_TYPE trackType = ParamsHelper.CreateParam<AUDIO_TRACK_TYPE>();
            AudioTrackConfig config = ParamsHelper.CreateParam<AudioTrackConfig>();

            var nRet = MediaEngine.CreateCustomAudioTrack(trackType, config);
            Assert.AreEqual(true, nRet > 0);
        }

        [Test]
        public void Test_IMediaEngine_DestroyCustomAudioTrack()
        {
            uint trackId = ParamsHelper.CreateParam<uint>();

            var nRet = MediaEngine.DestroyCustomAudioTrack(trackId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngine_SetExternalAudioSink()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            int sampleRate = ParamsHelper.CreateParam<int>();
            int channels = ParamsHelper.CreateParam<int>();

            var nRet = MediaEngine.SetExternalAudioSink(enabled, sampleRate, channels);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngine_PushVideoFrame()
        {
            ExternalVideoFrame frame = ParamsHelper.CreateParam<ExternalVideoFrame>();
            uint videoTrackId = ParamsHelper.CreateParam<uint>();

            frame.matrix = new float[16];
            var nRet = MediaEngine.PushVideoFrame(frame, videoTrackId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IMediaEngine_PushEncodedVideoImage()
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