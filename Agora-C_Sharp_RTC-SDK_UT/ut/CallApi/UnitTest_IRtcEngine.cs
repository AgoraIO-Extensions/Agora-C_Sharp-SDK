using NUnit.Framework;
using Agora.Rtc;
using track_id_t = System.UInt32;
namespace Agora.Rtc
{
    using uid_t = System.UInt32;
    [TestFixture]
    class UnitTest_IRtcEngine
    {

        public IRtcEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

        #region custom

        [Test]
        public void Test_SetParameters1()
        {
            string parameters;
            ParamsHelper.InitParam(out parameters);

            var nRet = Engine.SetParameters(parameters);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetParameters2()
        {
            string key;
            ParamsHelper.InitParam(out key);

            string value;
            ParamsHelper.InitParam(out value);
            var nRet = Engine.SetParameters(key, value);
            Assert.AreEqual(0, nRet);

            float value2;
            ParamsHelper.InitParam(out value2);
            nRet = Engine.SetParameters(key, value2);
            Assert.AreEqual(0, nRet);

            bool value3;
            ParamsHelper.InitParam(out value3);
            nRet = Engine.SetParameters(key, value3);
            Assert.AreEqual(0, nRet);

            int value4;
            ParamsHelper.InitParam(out value4);
            nRet = Engine.SetParameters(key, value4);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetErrorDescription()
        {
            int code;
            ParamsHelper.InitParam(out code);

            string nRet = Engine.GetErrorDescription(code);

            Assert.AreEqual("", nRet);
        }

        [Test]
        public void Test_QueryCodecCapability()
        {
            CodecCapInfo[] codecInfo;
            ParamsHelper.InitParam(out codecInfo);
            int size;
            ParamsHelper.InitParam(out size);
            var nRet = Engine.QueryCodecCapability(ref codecInfo, ref size);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetVersion()
        {
            int build;
            ParamsHelper.InitParam(out build);

            string nRet = Engine.GetVersion(ref build);

            Assert.AreEqual("", nRet);
        }

        [Test]
        public void Test_CreateMediaPlayer()
        {
            IMediaPlayer mediaPlayer = Engine.CreateMediaPlayer();
            Assert.AreNotEqual(mediaPlayer, null);
        }

        [Test]
        public void Test_DestroyMediaPlayer()
        {
            IMediaPlayer mediaPlayer = Engine.CreateMediaPlayer();
            Assert.AreNotEqual(mediaPlayer, null);

            Engine.DestroyMediaPlayer(mediaPlayer);
        }

        [Test]
        public void Test_UploadLogFile()
        {
            string requestId;
            ParamsHelper.InitParam(out requestId);
            int nRet = Engine.UploadLogFile(ref requestId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCallId()
        {
            string callId;
            ParamsHelper.InitParam(out callId);

            int nRet = Engine.GetCallId(ref callId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetConnectionState()
        {
            var nRet = Engine.GetConnectionState();

            Assert.AreEqual(nRet, CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED);
        }

        [Test]
        public void Test_RegisterEventHandler()
        {
            IRtcEngineEventHandler eventHandler;
            ParamsHelper.InitParam(out eventHandler);

            Engine.InitEventHandler(eventHandler);

            Assert.Pass();
        }

        [Test]
        public void Test_UnregisterEventHandler()
        {
            IRtcEngineEventHandler eventHandler;
            ParamsHelper.InitParam(out eventHandler);

            Engine.InitEventHandler(null);

            Assert.Pass();
        }

        [Test]
        public void Test_CreateDataStream()
        {
            int streamId;
            ParamsHelper.InitParam(out streamId);
            bool reliable;
            ParamsHelper.InitParam(out reliable);
            bool ordered;
            ParamsHelper.InitParam(out ordered);

            int nRet = Engine.CreateDataStream(ref streamId, reliable, ordered);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateDataStream2()
        {
            int streamId;
            ParamsHelper.InitParam(out streamId);
            DataStreamConfig config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.CreateDataStream(ref streamId, config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioDeviceInfo()
        {
            DeviceInfo deviceInfo;
            ParamsHelper.InitParam(out deviceInfo);
            var nRet = Engine.GetAudioDeviceInfo(ref deviceInfo);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_GetUserInfoByUserAccount()
        {
            string userAccount;
            ParamsHelper.InitParam(out userAccount);
            UserInfo userInfo;
            ParamsHelper.InitParam(out userInfo);
            var nRet = Engine.GetUserInfoByUserAccount(userAccount, ref userInfo);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetUserInfoByUid()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            UserInfo userInfo;
            ParamsHelper.InitParam(out userInfo);
            var nRet = Engine.GetUserInfoByUid(uid, ref userInfo);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartDirectCdnStreaming()
        {

            string publishUrl;
            ParamsHelper.InitParam(out publishUrl);
            DirectCdnStreamingMediaOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = Engine.StartDirectCdnStreaming(publishUrl, options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetExtensionProperty()
        {
            string provider;
            ParamsHelper.InitParam(out provider);
            string extension;
            ParamsHelper.InitParam(out extension);
            string key;
            ParamsHelper.InitParam(out key);
            string value;
            ParamsHelper.InitParam(out value);
            int buf_len;
            ParamsHelper.InitParam(out buf_len);
            MEDIA_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.GetExtensionProperty(provider, extension, key, ref value, buf_len, type);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetExtensionProperty2()
        {
            string provider;
            ParamsHelper.InitParam(out provider);
            string extension;
            ParamsHelper.InitParam(out extension);
            ExtensionInfo extensionInfo;
            ParamsHelper.InitParam(out extensionInfo);
            string key;
            ParamsHelper.InitParam(out key);
            string value;
            ParamsHelper.InitParam(out value);
            int buf_len;
            ParamsHelper.InitParam(out buf_len);
            var nRet = Engine.GetExtensionProperty(provider, extension, extensionInfo, key, ref value, buf_len);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetScreenCaptureSources()
        {
            SIZE thumbSize;
            ParamsHelper.InitParam(out thumbSize);
            SIZE iconSize;
            ParamsHelper.InitParam(out iconSize);
            bool includeScreen;
            ParamsHelper.InitParam(out includeScreen);
            var nRet = Engine.GetScreenCaptureSources(thumbSize, iconSize, includeScreen);

            Assert.AreEqual(0, nRet.Length);
        }

        [Test]
        public void Test_CreateCustomVideoTrack()
        {

            var nRet = Engine.CreateCustomVideoTrack();

            Assert.AreEqual(1, nRet);
        }

        [Test]
        public void Test_CreateCustomEncodedVideoTrack()
        {
            SenderOptions sender_option;
            ParamsHelper.InitParam(out sender_option);
            var nRet = Engine.CreateCustomEncodedVideoTrack(sender_option);

            Assert.AreEqual(1, nRet);
        }

        #endregion

        #region terr

        [Test]
        public void Test_Initialize()
        {
            RtcEngineContext context;
            ParamsHelper.InitParam(out context);
            var nRet = Engine.Initialize(context);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_JoinChannel()
        {
            string token;
            ParamsHelper.InitParam(out token);
            string channelId;
            ParamsHelper.InitParam(out channelId);
            string info;
            ParamsHelper.InitParam(out info);
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            var nRet = Engine.JoinChannel(token, channelId, info, uid);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_JoinChannel2()
        {
            string token;
            ParamsHelper.InitParam(out token);
            string channelId;
            ParamsHelper.InitParam(out channelId);
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            ChannelMediaOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = Engine.JoinChannel(token, channelId, uid, options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateChannelMediaOptions()
        {
            ChannelMediaOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = Engine.UpdateChannelMediaOptions(options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LeaveChannel()
        {

            var nRet = Engine.LeaveChannel();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LeaveChannel2()
        {
            LeaveChannelOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = Engine.LeaveChannel(options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RenewToken()
        {
            string token;
            ParamsHelper.InitParam(out token);
            var nRet = Engine.RenewToken(token);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetChannelProfile()
        {
            CHANNEL_PROFILE_TYPE profile;
            ParamsHelper.InitParam(out profile);
            var nRet = Engine.SetChannelProfile(profile);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetClientRole()
        {
            CLIENT_ROLE_TYPE role;
            ParamsHelper.InitParam(out role);
            var nRet = Engine.SetClientRole(role);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetClientRole2()
        {
            CLIENT_ROLE_TYPE role;
            ParamsHelper.InitParam(out role);
            ClientRoleOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = Engine.SetClientRole(role, options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartEchoTest()
        {

            var nRet = Engine.StartEchoTest();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartEchoTest2()
        {
            int intervalInSeconds;
            ParamsHelper.InitParam(out intervalInSeconds);
            var nRet = Engine.StartEchoTest(intervalInSeconds);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartEchoTest3()
        {
            EchoTestConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.StartEchoTest(config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopEchoTest()
        {

            var nRet = Engine.StopEchoTest();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableMultiCamera()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            CameraCapturerConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.EnableMultiCamera(enabled, config);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_EnableVideo()
        {

            var nRet = Engine.EnableVideo();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DisableVideo()
        {

            var nRet = Engine.DisableVideo();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartPreview()
        {

            var nRet = Engine.StartPreview();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType;
            ParamsHelper.InitParam(out sourceType);
            var nRet = Engine.StartPreview(sourceType);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopPreview()
        {

            var nRet = Engine.StopPreview();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType;
            ParamsHelper.InitParam(out sourceType);
            var nRet = Engine.StopPreview(sourceType);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartLastmileProbeTest()
        {
            LastmileProbeConfig config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.StartLastmileProbeTest(config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopLastmileProbeTest()
        {

            var nRet = Engine.StopLastmileProbeTest();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVideoEncoderConfiguration()
        {
            VideoEncoderConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.SetVideoEncoderConfiguration(config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetBeautyEffectOptions()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            BeautyOptions options;
            ParamsHelper.InitParam(out options);
            MEDIA_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.SetBeautyEffectOptions(enabled, options, type);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLowlightEnhanceOptions()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            LowlightEnhanceOptions options;
            ParamsHelper.InitParam(out options);
            MEDIA_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.SetLowlightEnhanceOptions(enabled, options, type);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVideoDenoiserOptions()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            VideoDenoiserOptions options;
            ParamsHelper.InitParam(out options);
            MEDIA_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.SetVideoDenoiserOptions(enabled, options, type);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetColorEnhanceOptions()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            ColorEnhanceOptions options;
            ParamsHelper.InitParam(out options);
            MEDIA_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.SetColorEnhanceOptions(enabled, options, type);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableVirtualBackground()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            VirtualBackgroundSource backgroundSource;
            ParamsHelper.InitParam(out backgroundSource);
            SegmentationProperty segproperty;
            ParamsHelper.InitParam(out segproperty);
            MEDIA_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.EnableVirtualBackground(enabled, backgroundSource, segproperty, type);

            Assert.AreEqual(0, nRet);
        }

  
        [Test]
        public void Test_SetupRemoteVideo()
        {
            VideoCanvas canvas;
            ParamsHelper.InitParam(out canvas);
            var nRet = Engine.SetupRemoteVideo(canvas);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetupLocalVideo()
        {
            VideoCanvas canvas;
            ParamsHelper.InitParam(out canvas);
            var nRet = Engine.SetupLocalVideo(canvas);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAudio()
        {

            var nRet = Engine.EnableAudio();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DisableAudio()
        {

            var nRet = Engine.DisableAudio();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioProfile()
        {
            AUDIO_PROFILE_TYPE profile;
            ParamsHelper.InitParam(out profile);
            AUDIO_SCENARIO_TYPE scenario;
            ParamsHelper.InitParam(out scenario);
            var nRet = Engine.SetAudioProfile(profile, scenario);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioProfile2()
        {
            AUDIO_PROFILE_TYPE profile;
            ParamsHelper.InitParam(out profile);
            var nRet = Engine.SetAudioProfile(profile);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioScenario()
        {
            AUDIO_SCENARIO_TYPE scenario;
            ParamsHelper.InitParam(out scenario);
            var nRet = Engine.SetAudioScenario(scenario);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableLocalAudio()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = Engine.EnableLocalAudio(enabled);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalAudioStream()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = Engine.MuteLocalAudioStream(mute);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteAudioStreams()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = Engine.MuteAllRemoteAudioStreams(mute);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDefaultMuteAllRemoteAudioStreams()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = Engine.SetDefaultMuteAllRemoteAudioStreams(mute);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteAudioStream()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = Engine.MuteRemoteAudioStream(uid, mute);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalVideoStream()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = Engine.MuteLocalVideoStream(mute);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableLocalVideo()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = Engine.EnableLocalVideo(enabled);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteVideoStreams()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = Engine.MuteAllRemoteVideoStreams(mute);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDefaultMuteAllRemoteVideoStreams()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = Engine.SetDefaultMuteAllRemoteVideoStreams(mute);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteVideoStream()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = Engine.MuteRemoteVideoStream(uid, mute);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVideoStreamType()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            VIDEO_STREAM_TYPE streamType;
            ParamsHelper.InitParam(out streamType);
            var nRet = Engine.SetRemoteVideoStreamType(uid, streamType);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVideoSubscriptionOptions()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            VideoSubscriptionOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = Engine.SetRemoteVideoSubscriptionOptions(uid, options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteDefaultVideoStreamType()
        {
            VIDEO_STREAM_TYPE streamType;
            ParamsHelper.InitParam(out streamType);
            var nRet = Engine.SetRemoteDefaultVideoStreamType(streamType);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeAudioBlocklist()
        {
            uint[] uidList;
            ParamsHelper.InitParam(out uidList);
            int uidNumber = uidList.Length;
            var nRet = Engine.SetSubscribeAudioBlocklist(uidList, uidNumber);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeAudioAllowlist()
        {
            uint[] uidList;
            ParamsHelper.InitParam(out uidList);
            int uidNumber = uidList.Length;
            var nRet = Engine.SetSubscribeAudioAllowlist(uidList, uidNumber);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeVideoBlocklist()
        {
            uint[] uidList;
            ParamsHelper.InitParam(out uidList);
            int uidNumber = uidList.Length;
            var nRet = Engine.SetSubscribeVideoBlocklist(uidList, uidNumber);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeVideoAllowlist()
        {
            uint[] uidList;
            ParamsHelper.InitParam(out uidList);
            int uidNumber = uidList.Length;
            var nRet = Engine.SetSubscribeVideoAllowlist(uidList, uidNumber);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAudioVolumeIndication()
        {
            int interval;
            ParamsHelper.InitParam(out interval);
            int smooth;
            ParamsHelper.InitParam(out smooth);
            bool reportVad;
            ParamsHelper.InitParam(out reportVad);
            var nRet = Engine.EnableAudioVolumeIndication(interval, smooth, reportVad);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioRecording()
        {
            string filePath;
            ParamsHelper.InitParam(out filePath);
            AUDIO_RECORDING_QUALITY_TYPE quality;
            ParamsHelper.InitParam(out quality);
            var nRet = Engine.StartAudioRecording(filePath, quality);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioRecording2()
        {
            string filePath;
            ParamsHelper.InitParam(out filePath);
            int sampleRate;
            ParamsHelper.InitParam(out sampleRate);
            AUDIO_RECORDING_QUALITY_TYPE quality;
            ParamsHelper.InitParam(out quality);
            var nRet = Engine.StartAudioRecording(filePath, sampleRate, quality);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioRecording3()
        {
            AudioRecordingConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.StartAudioRecording(config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopAudioRecording()
        {

            var nRet = Engine.StopAudioRecording();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioMixing()
        {
            string filePath;
            ParamsHelper.InitParam(out filePath);
            bool loopback;
            ParamsHelper.InitParam(out loopback);
            int cycle;
            ParamsHelper.InitParam(out cycle);
            var nRet = Engine.StartAudioMixing(filePath, loopback, cycle);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioMixing2()
        {
            string filePath;
            ParamsHelper.InitParam(out filePath);
            bool loopback;
            ParamsHelper.InitParam(out loopback);
            int cycle;
            ParamsHelper.InitParam(out cycle);
            int startPos;
            ParamsHelper.InitParam(out startPos);
            var nRet = Engine.StartAudioMixing(filePath, loopback, cycle, startPos);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopAudioMixing()
        {

            var nRet = Engine.StopAudioMixing();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseAudioMixing()
        {

            var nRet = Engine.PauseAudioMixing();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeAudioMixing()
        {

            var nRet = Engine.ResumeAudioMixing();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SelectAudioTrack()
        {
            int index;
            ParamsHelper.InitParam(out index);
            var nRet = Engine.SelectAudioTrack(index);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioTrackCount()
        {

            var nRet = Engine.GetAudioTrackCount();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustAudioMixingVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.AdjustAudioMixingVolume(volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustAudioMixingPublishVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.AdjustAudioMixingPublishVolume(volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioMixingPublishVolume()
        {

            var nRet = Engine.GetAudioMixingPublishVolume();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustAudioMixingPlayoutVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.AdjustAudioMixingPlayoutVolume(volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioMixingPlayoutVolume()
        {

            var nRet = Engine.GetAudioMixingPlayoutVolume();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioMixingDuration()
        {

            var nRet = Engine.GetAudioMixingDuration();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetAudioMixingCurrentPosition()
        {

            var nRet = Engine.GetAudioMixingCurrentPosition();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioMixingPosition()
        {
            int pos;
            ParamsHelper.InitParam(out pos);
            var nRet = Engine.SetAudioMixingPosition(pos);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioMixingDualMonoMode()
        {
            AUDIO_MIXING_DUAL_MONO_MODE mode;
            ParamsHelper.InitParam(out mode);
            var nRet = Engine.SetAudioMixingDualMonoMode(mode);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioMixingPitch()
        {
            int pitch;
            ParamsHelper.InitParam(out pitch);
            var nRet = Engine.SetAudioMixingPitch(pitch);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetEffectsVolume()
        {

            var nRet = Engine.GetEffectsVolume();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetEffectsVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.SetEffectsVolume(volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PreloadEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            string filePath;
            ParamsHelper.InitParam(out filePath);
            int startPos;
            ParamsHelper.InitParam(out startPos);
            var nRet = Engine.PreloadEffect(soundId, filePath, startPos);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PlayEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            string filePath;
            ParamsHelper.InitParam(out filePath);
            int loopCount;
            ParamsHelper.InitParam(out loopCount);
            double pitch;
            ParamsHelper.InitParam(out pitch);
            double pan;
            ParamsHelper.InitParam(out pan);
            int gain;
            ParamsHelper.InitParam(out gain);
            bool publish;
            ParamsHelper.InitParam(out publish);
            int startPos;
            ParamsHelper.InitParam(out startPos);
            var nRet = Engine.PlayEffect(soundId, filePath, loopCount, pitch, pan, gain, publish, startPos);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PlayAllEffects()
        {
            int loopCount;
            ParamsHelper.InitParam(out loopCount);
            double pitch;
            ParamsHelper.InitParam(out pitch);
            double pan;
            ParamsHelper.InitParam(out pan);
            int gain;
            ParamsHelper.InitParam(out gain);
            bool publish;
            ParamsHelper.InitParam(out publish);
            var nRet = Engine.PlayAllEffects(loopCount, pitch, pan, gain, publish);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetVolumeOfEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            var nRet = Engine.GetVolumeOfEffect(soundId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVolumeOfEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.SetVolumeOfEffect(soundId, volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            var nRet = Engine.PauseEffect(soundId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseAllEffects()
        {

            var nRet = Engine.PauseAllEffects();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            var nRet = Engine.ResumeEffect(soundId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeAllEffects()
        {

            var nRet = Engine.ResumeAllEffects();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            var nRet = Engine.StopEffect(soundId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopAllEffects()
        {

            var nRet = Engine.StopAllEffects();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnloadEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            var nRet = Engine.UnloadEffect(soundId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnloadAllEffects()
        {

            var nRet = Engine.UnloadAllEffects();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetEffectDuration()
        {
            string filePath;
            ParamsHelper.InitParam(out filePath);
            var nRet = Engine.GetEffectDuration(filePath);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetEffectPosition()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            int pos;
            ParamsHelper.InitParam(out pos);
            var nRet = Engine.SetEffectPosition(soundId, pos);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetEffectCurrentPosition()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            var nRet = Engine.GetEffectCurrentPosition(soundId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableSoundPositionIndication()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = Engine.EnableSoundPositionIndication(enabled);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVoicePosition()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            double pan;
            ParamsHelper.InitParam(out pan);
            double gain;
            ParamsHelper.InitParam(out gain);
            var nRet = Engine.SetRemoteVoicePosition(uid, pan, gain);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableSpatialAudio()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = Engine.EnableSpatialAudio(enabled);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteUserSpatialAudioParams()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            SpatialAudioParams @params;
            ParamsHelper.InitParam(out @params);
            var nRet = Engine.SetRemoteUserSpatialAudioParams(uid, @params);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVoiceBeautifierPreset()
        {
            VOICE_BEAUTIFIER_PRESET preset;
            ParamsHelper.InitParam(out preset);
            var nRet = Engine.SetVoiceBeautifierPreset(preset);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioEffectPreset()
        {
            AUDIO_EFFECT_PRESET preset;
            ParamsHelper.InitParam(out preset);
            var nRet = Engine.SetAudioEffectPreset(preset);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVoiceConversionPreset()
        {
            VOICE_CONVERSION_PRESET preset;
            ParamsHelper.InitParam(out preset);
            var nRet = Engine.SetVoiceConversionPreset(preset);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioEffectParameters()
        {
            AUDIO_EFFECT_PRESET preset;
            ParamsHelper.InitParam(out preset);
            int param1;
            ParamsHelper.InitParam(out param1);
            int param2;
            ParamsHelper.InitParam(out param2);
            var nRet = Engine.SetAudioEffectParameters(preset, param1, param2);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVoiceBeautifierParameters()
        {
            VOICE_BEAUTIFIER_PRESET preset;
            ParamsHelper.InitParam(out preset);
            int param1;
            ParamsHelper.InitParam(out param1);
            int param2;
            ParamsHelper.InitParam(out param2);
            var nRet = Engine.SetVoiceBeautifierParameters(preset, param1, param2);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVoiceConversionParameters()
        {
            VOICE_CONVERSION_PRESET preset;
            ParamsHelper.InitParam(out preset);
            int param1;
            ParamsHelper.InitParam(out param1);
            int param2;
            ParamsHelper.InitParam(out param2);
            var nRet = Engine.SetVoiceConversionParameters(preset, param1, param2);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalVoicePitch()
        {
            double pitch;
            ParamsHelper.InitParam(out pitch);
            var nRet = Engine.SetLocalVoicePitch(pitch);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalVoiceEqualization()
        {
            AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency;
            ParamsHelper.InitParam(out bandFrequency);
            int bandGain;
            ParamsHelper.InitParam(out bandGain);
            var nRet = Engine.SetLocalVoiceEqualization(bandFrequency, bandGain);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalVoiceReverb()
        {
            AUDIO_REVERB_TYPE reverbKey;
            ParamsHelper.InitParam(out reverbKey);
            int value;
            ParamsHelper.InitParam(out value);
            var nRet = Engine.SetLocalVoiceReverb(reverbKey, value);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetHeadphoneEQPreset()
        {
            HEADPHONE_EQUALIZER_PRESET preset;
            ParamsHelper.InitParam(out preset);
            var nRet = Engine.SetHeadphoneEQPreset(preset);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetHeadphoneEQParameters()
        {
            int lowGain;
            ParamsHelper.InitParam(out lowGain);
            int highGain;
            ParamsHelper.InitParam(out highGain);
            var nRet = Engine.SetHeadphoneEQParameters(lowGain, highGain);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLogFile()
        {
            string filePath;
            ParamsHelper.InitParam(out filePath);
            var nRet = Engine.SetLogFile(filePath);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLogFilter()
        {
            uint filter;
            ParamsHelper.InitParam(out filter);
            var nRet = Engine.SetLogFilter(filter);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLogLevel()
        {
            LOG_LEVEL level;
            ParamsHelper.InitParam(out level);
            var nRet = Engine.SetLogLevel(level);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLogFileSize()
        {
            uint fileSizeInKBytes;
            ParamsHelper.InitParam(out fileSizeInKBytes);
            var nRet = Engine.SetLogFileSize(fileSizeInKBytes);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalRenderMode()
        {
            RENDER_MODE_TYPE renderMode;
            ParamsHelper.InitParam(out renderMode);
            VIDEO_MIRROR_MODE_TYPE mirrorMode;
            ParamsHelper.InitParam(out mirrorMode);
            var nRet = Engine.SetLocalRenderMode(renderMode, mirrorMode);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteRenderMode()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            RENDER_MODE_TYPE renderMode;
            ParamsHelper.InitParam(out renderMode);
            VIDEO_MIRROR_MODE_TYPE mirrorMode;
            ParamsHelper.InitParam(out mirrorMode);
            var nRet = Engine.SetRemoteRenderMode(uid, renderMode, mirrorMode);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalRenderMode2()
        {
            RENDER_MODE_TYPE renderMode;
            ParamsHelper.InitParam(out renderMode);
            var nRet = Engine.SetLocalRenderMode(renderMode);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalVideoMirrorMode()
        {
            VIDEO_MIRROR_MODE_TYPE mirrorMode;
            ParamsHelper.InitParam(out mirrorMode);
            var nRet = Engine.SetLocalVideoMirrorMode(mirrorMode);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableDualStreamMode()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = Engine.EnableDualStreamMode(enabled);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableDualStreamMode2()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            SimulcastStreamConfig streamConfig;
            ParamsHelper.InitParam(out streamConfig);
            var nRet = Engine.EnableDualStreamMode(enabled, streamConfig);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDualStreamMode()
        {
            SIMULCAST_STREAM_MODE mode;
            ParamsHelper.InitParam(out mode);
            var nRet = Engine.SetDualStreamMode(mode);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDualStreamMode2()
        {
            SIMULCAST_STREAM_MODE mode;
            ParamsHelper.InitParam(out mode);
            SimulcastStreamConfig streamConfig;
            ParamsHelper.InitParam(out streamConfig);
            var nRet = Engine.SetDualStreamMode(mode, streamConfig);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableCustomAudioLocalPlayback()
        {
            track_id_t trackId;
            ParamsHelper.InitParam(out trackId);
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = Engine.EnableCustomAudioLocalPlayback(trackId, enabled);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRecordingAudioFrameParameters()
        {
            int sampleRate;
            ParamsHelper.InitParam(out sampleRate);
            int channel;
            ParamsHelper.InitParam(out channel);
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode;
            ParamsHelper.InitParam(out mode);
            int samplesPerCall;
            ParamsHelper.InitParam(out samplesPerCall);
            var nRet = Engine.SetRecordingAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlaybackAudioFrameParameters()
        {
            int sampleRate;
            ParamsHelper.InitParam(out sampleRate);
            int channel;
            ParamsHelper.InitParam(out channel);
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode;
            ParamsHelper.InitParam(out mode);
            int samplesPerCall;
            ParamsHelper.InitParam(out samplesPerCall);
            var nRet = Engine.SetPlaybackAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetMixedAudioFrameParameters()
        {
            int sampleRate;
            ParamsHelper.InitParam(out sampleRate);
            int channel;
            ParamsHelper.InitParam(out channel);
            int samplesPerCall;
            ParamsHelper.InitParam(out samplesPerCall);
            var nRet = Engine.SetMixedAudioFrameParameters(sampleRate, channel, samplesPerCall);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetEarMonitoringAudioFrameParameters()
        {
            int sampleRate;
            ParamsHelper.InitParam(out sampleRate);
            int channel;
            ParamsHelper.InitParam(out channel);
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode;
            ParamsHelper.InitParam(out mode);
            int samplesPerCall;
            ParamsHelper.InitParam(out samplesPerCall);
            var nRet = Engine.SetEarMonitoringAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlaybackAudioFrameBeforeMixingParameters()
        {
            int sampleRate;
            ParamsHelper.InitParam(out sampleRate);
            int channel;
            ParamsHelper.InitParam(out channel);
            var nRet = Engine.SetPlaybackAudioFrameBeforeMixingParameters(sampleRate, channel);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAudioSpectrumMonitor()
        {
            int intervalInMS;
            ParamsHelper.InitParam(out intervalInMS);
            var nRet = Engine.EnableAudioSpectrumMonitor(intervalInMS);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DisableAudioSpectrumMonitor()
        {

            var nRet = Engine.DisableAudioSpectrumMonitor();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustRecordingSignalVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.AdjustRecordingSignalVolume(volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRecordingSignal()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = Engine.MuteRecordingSignal(mute);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustPlaybackSignalVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.AdjustPlaybackSignalVolume(volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustUserPlaybackSignalVolume()
        {
            uint uid;
            ParamsHelper.InitParam(out uid);
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.AdjustUserPlaybackSignalVolume(uid, volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalPublishFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option;
            ParamsHelper.InitParam(out option);
            var nRet = Engine.SetLocalPublishFallbackOption(option);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteSubscribeFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option;
            ParamsHelper.InitParam(out option);
            var nRet = Engine.SetRemoteSubscribeFallbackOption(option);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableLoopbackRecording()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            string deviceName;
            ParamsHelper.InitParam(out deviceName);
            var nRet = Engine.EnableLoopbackRecording(enabled, deviceName);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustLoopbackSignalVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.AdjustLoopbackSignalVolume(volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetLoopbackRecordingVolume()
        {

            var nRet = Engine.GetLoopbackRecordingVolume();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableInEarMonitoring()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            int includeAudioFilters;
            ParamsHelper.InitParam(out includeAudioFilters);
            var nRet = Engine.EnableInEarMonitoring(enabled, includeAudioFilters);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetInEarMonitoringVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.SetInEarMonitoringVolume(volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LoadExtensionProvider()
        {
            string path;
            ParamsHelper.InitParam(out path);
            bool unload_after_use;
            ParamsHelper.InitParam(out unload_after_use);
            var nRet = Engine.LoadExtensionProvider(path, unload_after_use);

            Assert.AreEqual(true, nRet == 0 || nRet == -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED);
        }

        [Test]
        public void Test_SetExtensionProviderProperty()
        {
            string provider;
            ParamsHelper.InitParam(out provider);
            string key;
            ParamsHelper.InitParam(out key);
            string value;
            ParamsHelper.InitParam(out value);
            var nRet = Engine.SetExtensionProviderProperty(provider, key, value);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RegisterExtension()
        {
            string provider;
            ParamsHelper.InitParam(out provider);
            string extension;
            ParamsHelper.InitParam(out extension);
            MEDIA_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.RegisterExtension(provider, extension, type);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableExtension()
        {
            string provider;
            ParamsHelper.InitParam(out provider);
            string extension;
            ParamsHelper.InitParam(out extension);
            bool enable;
            ParamsHelper.InitParam(out enable);
            MEDIA_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.EnableExtension(provider, extension, enable, type);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExtensionProperty()
        {
            string provider;
            ParamsHelper.InitParam(out provider);
            string extension;
            ParamsHelper.InitParam(out extension);
            string key;
            ParamsHelper.InitParam(out key);
            string value;
            ParamsHelper.InitParam(out value);
            MEDIA_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.SetExtensionProperty(provider, extension, key, value, type);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableExtension2()
        {
            string provider;
            ParamsHelper.InitParam(out provider);
            string extension;
            ParamsHelper.InitParam(out extension);
            ExtensionInfo extensionInfo;
            ParamsHelper.InitParam(out extensionInfo);
            bool enable;
            ParamsHelper.InitParam(out enable);
            var nRet = Engine.EnableExtension(provider, extension, extensionInfo, enable);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExtensionProperty2()
        {
            string provider;
            ParamsHelper.InitParam(out provider);
            string extension;
            ParamsHelper.InitParam(out extension);
            ExtensionInfo extensionInfo;
            ParamsHelper.InitParam(out extensionInfo);
            string key;
            ParamsHelper.InitParam(out key);
            string value;
            ParamsHelper.InitParam(out value);
            var nRet = Engine.SetExtensionProperty(provider, extension, extensionInfo, key, value);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCameraCapturerConfiguration()
        {
            CameraCapturerConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.SetCameraCapturerConfiguration(config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DestroyCustomVideoTrack()
        {
            uint video_track_id;
            ParamsHelper.InitParam(out video_track_id);
            var nRet = Engine.DestroyCustomVideoTrack(video_track_id);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DestroyCustomEncodedVideoTrack()
        {
            uint video_track_id;
            ParamsHelper.InitParam(out video_track_id);
            var nRet = Engine.DestroyCustomEncodedVideoTrack(video_track_id);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SwitchCamera()
        {

            var nRet = Engine.SwitchCamera();

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_IsCameraZoomSupported()
        {

            var nRet = Engine.IsCameraZoomSupported();

            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IsCameraFaceDetectSupported()
        {

            var nRet = Engine.IsCameraFaceDetectSupported();

            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IsCameraTorchSupported()
        {

            var nRet = Engine.IsCameraTorchSupported();

            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IsCameraFocusSupported()
        {

            var nRet = Engine.IsCameraFocusSupported();

            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_IsCameraAutoFocusFaceModeSupported()
        {

            var nRet = Engine.IsCameraAutoFocusFaceModeSupported();

            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_SetCameraZoomFactor()
        {
            float factor;
            ParamsHelper.InitParam(out factor);
            var nRet = Engine.SetCameraZoomFactor(factor);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_EnableFaceDetection()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = Engine.EnableFaceDetection(enabled);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_GetCameraMaxZoomFactor()
        {

            var nRet = Engine.GetCameraMaxZoomFactor();

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_SetCameraFocusPositionInPreview()
        {
            float positionX;
            ParamsHelper.InitParam(out positionX);
            float positionY;
            ParamsHelper.InitParam(out positionY);
            var nRet = Engine.SetCameraFocusPositionInPreview(positionX, positionY);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_SetCameraTorchOn()
        {
            bool isOn;
            ParamsHelper.InitParam(out isOn);
            var nRet = Engine.SetCameraTorchOn(isOn);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_SetCameraAutoFocusFaceModeEnabled()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = Engine.SetCameraAutoFocusFaceModeEnabled(enabled);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_IsCameraExposurePositionSupported()
        {

            var nRet = Engine.IsCameraExposurePositionSupported();

            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_SetCameraExposurePosition()
        {
            float positionXinView;
            ParamsHelper.InitParam(out positionXinView);
            float positionYinView;
            ParamsHelper.InitParam(out positionYinView);
            var nRet = Engine.SetCameraExposurePosition(positionXinView, positionYinView);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_IsCameraAutoExposureFaceModeSupported()
        {

            var nRet = Engine.IsCameraAutoExposureFaceModeSupported();

            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_SetCameraAutoExposureFaceModeEnabled()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = Engine.SetCameraAutoExposureFaceModeEnabled(enabled);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_SetDefaultAudioRouteToSpeakerphone()
        {
            bool defaultToSpeaker;
            ParamsHelper.InitParam(out defaultToSpeaker);
            var nRet = Engine.SetDefaultAudioRouteToSpeakerphone(defaultToSpeaker);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_SetEnableSpeakerphone()
        {
            bool speakerOn;
            ParamsHelper.InitParam(out speakerOn);
            var nRet = Engine.SetEnableSpeakerphone(speakerOn);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_IsSpeakerphoneEnabled()
        {

            var nRet = Engine.IsSpeakerphoneEnabled();

            Assert.AreEqual(false, nRet);
        }

        [Test]
        public void Test_SetAudioSessionOperationRestriction()
        {
            AUDIO_SESSION_OPERATION_RESTRICTION restriction;
            ParamsHelper.InitParam(out restriction);
            var nRet = Engine.SetAudioSessionOperationRestriction(restriction);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_StartScreenCaptureByDisplayId()
        {
            uint displayId;
            ParamsHelper.InitParam(out displayId);
            Rectangle regionRect;
            ParamsHelper.InitParam(out regionRect);
            ScreenCaptureParameters captureParams;
            ParamsHelper.InitParam(out captureParams);
            var nRet = Engine.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartScreenCaptureByScreenRect()
        {
            Rectangle screenRect;
            ParamsHelper.InitParam(out screenRect);
            Rectangle regionRect;
            ParamsHelper.InitParam(out regionRect);
            ScreenCaptureParameters captureParams;
            ParamsHelper.InitParam(out captureParams);
            var nRet = Engine.StartScreenCaptureByScreenRect(screenRect, regionRect, captureParams);

            Assert.AreEqual(true, nRet == 0 || nRet == -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED);
        }

        [Test]
        public void Test_StartScreenCaptureByWindowId()
        {
            ulong windowId;
            ParamsHelper.InitParam(out windowId);
            Rectangle regionRect;
            ParamsHelper.InitParam(out regionRect);
            ScreenCaptureParameters captureParams;
            ParamsHelper.InitParam(out captureParams);
            var nRet = Engine.StartScreenCaptureByWindowId(windowId, regionRect, captureParams);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetScreenCaptureContentHint()
        {
            VIDEO_CONTENT_HINT contentHint;
            ParamsHelper.InitParam(out contentHint);
            var nRet = Engine.SetScreenCaptureContentHint(contentHint);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetScreenCaptureScenario()
        {
            SCREEN_SCENARIO_TYPE screenScenario;
            ParamsHelper.InitParam(out screenScenario);
            var nRet = Engine.SetScreenCaptureScenario(screenScenario);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateScreenCaptureRegion()
        {
            Rectangle regionRect;
            ParamsHelper.InitParam(out regionRect);
            var nRet = Engine.UpdateScreenCaptureRegion(regionRect);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateScreenCaptureParameters()
        {
            ScreenCaptureParameters captureParams;
            ParamsHelper.InitParam(out captureParams);
            var nRet = Engine.UpdateScreenCaptureParameters(captureParams);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartScreenCapture()
        {
            ScreenCaptureParameters2 captureParams;
            ParamsHelper.InitParam(out captureParams);
            var nRet = Engine.StartScreenCapture(captureParams);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_StartScreenCapture2()
        {
            VIDEO_SOURCE_TYPE sourceType;
            ParamsHelper.InitParam(out sourceType);
            CameraCapturerConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.StartCameraCapture(sourceType, config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateScreenCapture()
        {
            ScreenCaptureParameters2 captureParams;
            ParamsHelper.InitParam(out captureParams);
            var nRet = Engine.UpdateScreenCapture(captureParams);

            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED, nRet);
        }

        [Test]
        public void Test_StopScreenCapture()
        {

            var nRet = Engine.StopScreenCapture();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopScreenCapture2()
        {
            VIDEO_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.StopScreenCapture(type);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_QueryScreenCaptureCapability()
        {
            var nRet = Engine.QueryScreenCaptureCapability();
            Assert.AreEqual(true, nRet == 0 || nRet == -4);
        }

        [Test]
        public void Test_Rate()
        {
            string callId;
            ParamsHelper.InitParam(out callId);
            int rating;
            ParamsHelper.InitParam(out rating);
            string description;
            ParamsHelper.InitParam(out description);
            var nRet = Engine.Rate(callId, rating, description);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Complain()
        {
            string callId;
            ParamsHelper.InitParam(out callId);
            string description;
            ParamsHelper.InitParam(out description);
            var nRet = Engine.Complain(callId, description);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRtmpStreamWithoutTranscoding()
        {
            string url;
            ParamsHelper.InitParam(out url);
            var nRet = Engine.StartRtmpStreamWithoutTranscoding(url);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRtmpStreamWithTranscoding()
        {
            string url;
            ParamsHelper.InitParam(out url);
            LiveTranscoding transcoding;
            ParamsHelper.InitParam(out transcoding);
            var nRet = Engine.StartRtmpStreamWithTranscoding(url, transcoding);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateRtmpTranscoding()
        {
            LiveTranscoding transcoding;
            ParamsHelper.InitParam(out transcoding);
            var nRet = Engine.UpdateRtmpTranscoding(transcoding);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRtmpStream()
        {
            string url;
            ParamsHelper.InitParam(out url);
            var nRet = Engine.StopRtmpStream(url);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartLocalVideoTranscoder()
        {
            LocalTranscoderConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.StartLocalVideoTranscoder(config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateLocalTranscoderConfiguration()
        {
            LocalTranscoderConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.UpdateLocalTranscoderConfiguration(config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopLocalVideoTranscoder()
        {

            var nRet = Engine.StopLocalVideoTranscoder();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartCameraCapture()
        {
            VIDEO_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            CameraCapturerConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.StartCameraCapture(type, config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopCameraCapture()
        {
            VIDEO_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.StopCameraCapture(type);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCameraDeviceOrientation()
        {
            VIDEO_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            VIDEO_ORIENTATION orientation;
            ParamsHelper.InitParam(out orientation);
            var nRet = Engine.SetCameraDeviceOrientation(type, orientation);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetScreenCaptureOrientation()
        {
            VIDEO_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            VIDEO_ORIENTATION orientation;
            ParamsHelper.InitParam(out orientation);
            var nRet = Engine.SetScreenCaptureOrientation(type, orientation);

            Assert.AreEqual(0, nRet);
        }

       

        [Test]
        public void Test_SetRemoteUserPriority()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            PRIORITY_TYPE userPriority;
            ParamsHelper.InitParam(out userPriority);
            var nRet = Engine.SetRemoteUserPriority(uid, userPriority);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetEncryptionMode()
        {
            string encryptionMode;
            ParamsHelper.InitParam(out encryptionMode);
            var nRet = Engine.SetEncryptionMode(encryptionMode);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetEncryptionSecret()
        {
            string secret;
            ParamsHelper.InitParam(out secret);
            var nRet = Engine.SetEncryptionSecret(secret);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableEncryption()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            EncryptionConfig config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.EnableEncryption(enabled, config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SendStreamMessage()
        {
            int streamId;
            ParamsHelper.InitParam(out streamId);
            byte[] data;
            ParamsHelper.InitParam(out data);
            uint length;
            ParamsHelper.InitParam(out length);
            var nRet = Engine.SendStreamMessage(streamId, data, length);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AddVideoWatermark()
        {
            RtcImage watermark;
            ParamsHelper.InitParam(out watermark);
            var nRet = Engine.AddVideoWatermark(watermark);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AddVideoWatermark2()
        {
            string watermarkUrl;
            ParamsHelper.InitParam(out watermarkUrl);
            WatermarkOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = Engine.AddVideoWatermark(watermarkUrl, options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ClearVideoWatermarks()
        {

            var nRet = Engine.ClearVideoWatermarks();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseAudio()
        {

            var nRet = Engine.PauseAudio();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeAudio()
        {

            var nRet = Engine.ResumeAudio();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableWebSdkInteroperability()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = Engine.EnableWebSdkInteroperability(enabled);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SendCustomReportMessage()
        {
            string id;
            ParamsHelper.InitParam(out id);
            string category;
            ParamsHelper.InitParam(out category);
            string @event;
            ParamsHelper.InitParam(out @event);
            string label;
            ParamsHelper.InitParam(out label);
            int value;
            ParamsHelper.InitParam(out value);
            var nRet = Engine.SendCustomReportMessage(id, category, @event, label, value);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioFrameDump()
        {
            string channel_id;
            ParamsHelper.InitParam(out channel_id);
            uid_t user_id;
            ParamsHelper.InitParam(out user_id);
            string location;
            ParamsHelper.InitParam(out location);
            string uuid;
            ParamsHelper.InitParam(out uuid);
            string passwd;
            ParamsHelper.InitParam(out passwd);
            long duration_ms;
            ParamsHelper.InitParam(out duration_ms);
            bool auto_upload;
            ParamsHelper.InitParam(out auto_upload);
            var nRet = Engine.StartAudioFrameDump(channel_id, user_id, location, uuid, passwd, duration_ms, auto_upload);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopAudioFrameDump()
        {
            string channel_id;
            ParamsHelper.InitParam(out channel_id);
            uid_t user_id;
            ParamsHelper.InitParam(out user_id);
            string location;
            ParamsHelper.InitParam(out location);
            var nRet = Engine.StopAudioFrameDump(channel_id, user_id, location);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RegisterLocalUserAccount()
        {
            string appId;
            ParamsHelper.InitParam(out appId);
            string userAccount;
            ParamsHelper.InitParam(out userAccount);
            var nRet = Engine.RegisterLocalUserAccount(appId, userAccount);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_JoinChannelWithUserAccount()
        {
            string token;
            ParamsHelper.InitParam(out token);
            string channelId;
            ParamsHelper.InitParam(out channelId);
            string userAccount;
            ParamsHelper.InitParam(out userAccount);
            var nRet = Engine.JoinChannelWithUserAccount(token, channelId, userAccount);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_JoinChannelWithUserAccount2()
        {
            string token;
            ParamsHelper.InitParam(out token);
            string channelId;
            ParamsHelper.InitParam(out channelId);
            string userAccount;
            ParamsHelper.InitParam(out userAccount);
            ChannelMediaOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = Engine.JoinChannelWithUserAccount(token, channelId, userAccount, options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartChannelMediaRelay()
        {
            ChannelMediaRelayConfiguration configuration;
            ParamsHelper.InitParam(out configuration);
            var nRet = Engine.StartChannelMediaRelay(configuration);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateChannelMediaRelay()
        {
            ChannelMediaRelayConfiguration configuration;
            ParamsHelper.InitParam(out configuration);
            var nRet = Engine.UpdateChannelMediaRelay(configuration);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopChannelMediaRelay()
        {

            var nRet = Engine.StopChannelMediaRelay();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseAllChannelMediaRelay()
        {

            var nRet = Engine.PauseAllChannelMediaRelay();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeAllChannelMediaRelay()
        {

            var nRet = Engine.ResumeAllChannelMediaRelay();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDirectCdnStreamingAudioConfiguration()
        {
            AUDIO_PROFILE_TYPE profile;
            ParamsHelper.InitParam(out profile);
            var nRet = Engine.SetDirectCdnStreamingAudioConfiguration(profile);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDirectCdnStreamingVideoConfiguration()
        {
            VideoEncoderConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.SetDirectCdnStreamingVideoConfiguration(config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopDirectCdnStreaming()
        {

            var nRet = Engine.StopDirectCdnStreaming();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateDirectCdnStreamingMediaOptions()
        {
            DirectCdnStreamingMediaOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = Engine.UpdateDirectCdnStreamingMediaOptions(options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRhythmPlayer()
        {
            string sound1;
            ParamsHelper.InitParam(out sound1);
            string sound2;
            ParamsHelper.InitParam(out sound2);
            AgoraRhythmPlayerConfig config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.StartRhythmPlayer(sound1, sound2, config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRhythmPlayer()
        {

            var nRet = Engine.StopRhythmPlayer();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ConfigRhythmPlayer()
        {
            AgoraRhythmPlayerConfig config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.ConfigRhythmPlayer(config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_TakeSnapshot()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            string filePath;
            ParamsHelper.InitParam(out filePath);
            var nRet = Engine.TakeSnapshot(uid, filePath);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableContentInspect()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            ContentInspectConfig config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.EnableContentInspect(enabled, config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustCustomAudioPublishVolume()
        {
            track_id_t trackId;
            ParamsHelper.InitParam(out trackId);
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.AdjustCustomAudioPublishVolume(trackId, volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustCustomAudioPlayoutVolume()
        {
            track_id_t trackId;
            ParamsHelper.InitParam(out trackId);
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = Engine.AdjustCustomAudioPlayoutVolume(trackId, volume);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCloudProxy()
        {
            CLOUD_PROXY_TYPE proxyType;
            ParamsHelper.InitParam(out proxyType);
            var nRet = Engine.SetCloudProxy(proxyType);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLocalAccessPoint()
        {
            LocalAccessPointConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.SetLocalAccessPoint(config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAdvancedAudioOptions()
        {
            AdvancedAudioOptions options;
            ParamsHelper.InitParam(out options);
            int sourceType;
            ParamsHelper.InitParam(out sourceType);
            var nRet = Engine.SetAdvancedAudioOptions(options, sourceType);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAVSyncSource()
        {
            string channelId;
            ParamsHelper.InitParam(out channelId);
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            var nRet = Engine.SetAVSyncSource(channelId, uid);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableVideoImageSource()
        {
            bool enable;
            ParamsHelper.InitParam(out enable);
            ImageTrackOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = Engine.EnableVideoImageSource(enable, options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCurrentMonotonicTimeInMs()
        {

            var nRet = Engine.GetCurrentMonotonicTimeInMs();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableWirelessAccelerate()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = Engine.EnableWirelessAccelerate(enabled);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetNetworkType()
        {

            var nRet = Engine.GetNetworkType();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartMediaRenderingTracing()
        {

            var nRet = Engine.StartMediaRenderingTracing();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableInstantMediaRendering()
        {

            var nRet = Engine.EnableInstantMediaRendering();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetNtpWallTimeInMs()
        {

            var nRet = Engine.GetNtpWallTimeInMs();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsFeatureAvailableOnDevice()
        {
            FeatureType type;
            ParamsHelper.InitParam(out type);
            var nRet = Engine.IsFeatureAvailableOnDevice(type);

            Assert.AreEqual(true, nRet);
        }



        #region mediaEngine

        [Test]
        public void Test_PushAudioFrame()
        {
            AudioFrame frame;
            ParamsHelper.InitParam(out frame);
            uint trackId;
            ParamsHelper.InitParam(out trackId);
            var nRet = Engine.PushAudioFrame(frame, trackId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PullAudioFrame()
        {
            AudioFrame frame;
            ParamsHelper.InitParam(out frame);
            var nRet = Engine.PullAudioFrame(frame);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExternalVideoSource()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            bool useTexture;
            ParamsHelper.InitParam(out useTexture);
            EXTERNAL_VIDEO_SOURCE_TYPE sourceType;
            ParamsHelper.InitParam(out sourceType);
            SenderOptions encodedVideoOption;
            ParamsHelper.InitParam(out encodedVideoOption);
            var nRet = Engine.SetExternalVideoSource(enabled, useTexture, sourceType, encodedVideoOption);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExternalAudioSource()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            int sampleRate;
            ParamsHelper.InitParam(out sampleRate);
            int channels;
            ParamsHelper.InitParam(out channels);
            bool localPlayback;
            ParamsHelper.InitParam(out localPlayback);
            bool publish;
            ParamsHelper.InitParam(out publish);
            var nRet = Engine.SetExternalAudioSource(enabled, sampleRate, channels, localPlayback, publish);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateCustomAudioTrack()
        {
            AUDIO_TRACK_TYPE trackType;
            ParamsHelper.InitParam(out trackType);
            AudioTrackConfig config;
            ParamsHelper.InitParam(out config);
            var nRet = Engine.CreateCustomAudioTrack(trackType, config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_DestroyCustomAudioTrack()
        {
            uint trackId;
            ParamsHelper.InitParam(out trackId);
            var nRet = Engine.DestroyCustomAudioTrack(trackId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetExternalAudioSink()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            int sampleRate;
            ParamsHelper.InitParam(out sampleRate);
            int channels;
            ParamsHelper.InitParam(out channels);
            var nRet = Engine.SetExternalAudioSink(enabled, sampleRate, channels);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PushVideoFrame()
        {
            ExternalVideoFrame frame;
            ParamsHelper.InitParam(out frame);
            uint videoTrackId;
            ParamsHelper.InitParam(out videoTrackId);
            var nRet = Engine.PushVideoFrame(frame, videoTrackId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PushEncodedVideoImage()
        {
            byte[] imageBuffer;
            ParamsHelper.InitParam(out imageBuffer);
            uint length;
            ParamsHelper.InitParam(out length);
            EncodedVideoFrameInfo videoEncodedFrameInfo;
            ParamsHelper.InitParam(out videoEncodedFrameInfo);
            uint videoTrackId;
            ParamsHelper.InitParam(out videoTrackId);
            var nRet = Engine.PushEncodedVideoImage(imageBuffer, length, videoEncodedFrameInfo, videoTrackId);

            Assert.AreEqual(0, nRet);
        }



        #endregion



        #endregion
    }

}