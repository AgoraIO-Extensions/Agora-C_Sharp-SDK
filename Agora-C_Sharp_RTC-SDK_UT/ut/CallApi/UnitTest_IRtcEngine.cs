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
        public void Test_SetAudioProfile()
        {
            AUDIO_PROFILE_TYPE profile = ParamsHelper.CreateParam<AUDIO_PROFILE_TYPE>();
            AUDIO_SCENARIO_TYPE scenario = ParamsHelper.CreateParam<AUDIO_SCENARIO_TYPE>();

            var nRet = RtcEngine.SetAudioProfile(profile, scenario);
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
        public void Test_SetRemoteVoicePosition()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            double pan = ParamsHelper.CreateParam<double>();
            double gain = ParamsHelper.CreateParam<double>();

            var nRet = RtcEngine.SetRemoteVoicePosition(uid, pan, gain);
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
        public void Test_SetRemoteRenderMode()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();

            var nRet = RtcEngine.SetRemoteRenderMode(uid, renderMode, mirrorMode);
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
        public void Test_AdjustUserPlaybackSignalVolume()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = RtcEngine.AdjustUserPlaybackSignalVolume(uid, volume);
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
        public void Test_EnableExtension()
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
            ExtensionInfo extensionInfo = ParamsHelper.CreateParam<ExtensionInfo>();
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.SetExtensionProperty(provider, extension, extensionInfo, key, value);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetExtensionProperty()
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
        public void Test_AddVideoWatermark()
        {
            RtcImage watermark = ParamsHelper.CreateParam<RtcImage>();

            var nRet = RtcEngine.AddVideoWatermark(watermark);
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
        public void Test_StopAudioFrameDump()
        {
            string channel_id = ParamsHelper.CreateParam<string>();
            uint uid = ParamsHelper.CreateParam<uint>();
            string location = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.StopAudioFrameDump(channel_id, uid, location);
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
        public void Test_TakeSnapshot()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngine.TakeSnapshot(uid, filePath);
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
        public void Test_StartScreenCaptureByScreenRect()
        {
            Rectangle screenRect = ParamsHelper.CreateParam<Rectangle>();
            Rectangle regionRect = ParamsHelper.CreateParam<Rectangle>();
            ScreenCaptureParameters captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters>();

            var nRet = RtcEngine.StartScreenCaptureByScreenRect(screenRect, regionRect, captureParams);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IRtcEngine

        #region terra IMediaEngine

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