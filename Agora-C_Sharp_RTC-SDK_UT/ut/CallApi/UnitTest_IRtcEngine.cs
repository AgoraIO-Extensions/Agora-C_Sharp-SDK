using NUnit.Framework;
using Agora.Rtc;


namespace ut
{
    using uid_t = System.UInt32;

    [TestFixture]
    class UnitTest_IRtcEngine
    {

        public IRtcEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine();
        }

        [TearDown]
        public void TearDown()
        {
            Engine.Dispose();
        }


        [Test]
        public void Test_GetErrorDescription()
        {
            int code;
            ParamsHelper.InitParam(out code);

            string nRet = Engine.GetErrorDescription(code);

            Assert.AreEqual(nRet, "error");
        }

       

        #region terr


        [Test]
        public void Test_Initialize()
        {
            RtcEngineContext context;
            ParamsHelper.InitParam(out context);

            int nRet = Engine.Initialize(context);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.JoinChannel(token, channelId, info, uid);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.JoinChannel(token, channelId, uid, options);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UpdateChannelMediaOptions()
        {
            ChannelMediaOptions options;
            ParamsHelper.InitParam(out options);

            int nRet = Engine.UpdateChannelMediaOptions(options);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_LeaveChannel()
        {


            int nRet = Engine.LeaveChannel();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_LeaveChannel2()
        {
            LeaveChannelOptions options;
            ParamsHelper.InitParam(out options);

            int nRet = Engine.LeaveChannel(options);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RenewToken()
        {
            string token;
            ParamsHelper.InitParam(out token);

            int nRet = Engine.RenewToken(token);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetChannelProfile()
        {
            CHANNEL_PROFILE_TYPE profile;
            ParamsHelper.InitParam(out profile);

            int nRet = Engine.SetChannelProfile(profile);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetClientRole()
        {
            CLIENT_ROLE_TYPE role;
            ParamsHelper.InitParam(out role);

            int nRet = Engine.SetClientRole(role);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetClientRole2()
        {
            CLIENT_ROLE_TYPE role;
            ParamsHelper.InitParam(out role);
            ClientRoleOptions options;
            ParamsHelper.InitParam(out options);

            int nRet = Engine.SetClientRole(role, options);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartEchoTest()
        {


            int nRet = Engine.StartEchoTest();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartEchoTest2()
        {
            int intervalInSeconds;
            ParamsHelper.InitParam(out intervalInSeconds);

            int nRet = Engine.StartEchoTest(intervalInSeconds);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartEchoTest3()
        {
            EchoTestConfiguration config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.StartEchoTest(config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopEchoTest()
        {


            int nRet = Engine.StopEchoTest();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableMultiCamera()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            CameraCapturerConfiguration config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.EnableMultiCamera(enabled, config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableVideo()
        {


            int nRet = Engine.EnableVideo();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_DisableVideo()
        {


            int nRet = Engine.DisableVideo();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartPreview()
        {


            int nRet = Engine.StartPreview();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType;
            ParamsHelper.InitParam(out sourceType);

            int nRet = Engine.StartPreview(sourceType);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopPreview()
        {


            int nRet = Engine.StopPreview();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopPreview2()
        {
            VIDEO_SOURCE_TYPE sourceType;
            ParamsHelper.InitParam(out sourceType);

            int nRet = Engine.StopPreview(sourceType);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartLastmileProbeTest()
        {
            LastmileProbeConfig config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.StartLastmileProbeTest(config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopLastmileProbeTest()
        {


            int nRet = Engine.StopLastmileProbeTest();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetVideoEncoderConfiguration()
        {
            VideoEncoderConfiguration config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.SetVideoEncoderConfiguration(config);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetBeautyEffectOptions(enabled, options, type);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetLowlightEnhanceOptions(enabled, options, type);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetVideoDenoiserOptions(enabled, options, type);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetColorEnhanceOptions(enabled, options, type);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.EnableVirtualBackground(enabled, backgroundSource, segproperty, type);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableRemoteSuperResolution()
        {
            uid_t userId;
            ParamsHelper.InitParam(out userId);
            bool enable;
            ParamsHelper.InitParam(out enable);

            int nRet = Engine.EnableRemoteSuperResolution(userId, enable);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetupRemoteVideo()
        {
            VideoCanvas canvas;
            ParamsHelper.InitParam(out canvas);

            int nRet = Engine.SetupRemoteVideo(canvas);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetupLocalVideo()
        {
            VideoCanvas canvas;
            ParamsHelper.InitParam(out canvas);

            int nRet = Engine.SetupLocalVideo(canvas);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableAudio()
        {


            int nRet = Engine.EnableAudio();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_DisableAudio()
        {


            int nRet = Engine.DisableAudio();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioProfile()
        {
            AUDIO_PROFILE_TYPE profile;
            ParamsHelper.InitParam(out profile);
            AUDIO_SCENARIO_TYPE scenario;
            ParamsHelper.InitParam(out scenario);

            int nRet = Engine.SetAudioProfile(profile, scenario);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioProfile2()
        {
            AUDIO_PROFILE_TYPE profile;
            ParamsHelper.InitParam(out profile);

            int nRet = Engine.SetAudioProfile(profile);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioScenario()
        {
            AUDIO_SCENARIO_TYPE scenario;
            ParamsHelper.InitParam(out scenario);

            int nRet = Engine.SetAudioScenario(scenario);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableLocalAudio()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);

            int nRet = Engine.EnableLocalAudio(enabled);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_MuteLocalAudioStream()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);

            int nRet = Engine.MuteLocalAudioStream(mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_MuteAllRemoteAudioStreams()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);

            int nRet = Engine.MuteAllRemoteAudioStreams(mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetDefaultMuteAllRemoteAudioStreams()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);

            int nRet = Engine.SetDefaultMuteAllRemoteAudioStreams(mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_MuteRemoteAudioStream()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            bool mute;
            ParamsHelper.InitParam(out mute);

            int nRet = Engine.MuteRemoteAudioStream(uid, mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_MuteLocalVideoStream()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);

            int nRet = Engine.MuteLocalVideoStream(mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableLocalVideo()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);

            int nRet = Engine.EnableLocalVideo(enabled);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_MuteAllRemoteVideoStreams()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);

            int nRet = Engine.MuteAllRemoteVideoStreams(mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetDefaultMuteAllRemoteVideoStreams()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);

            int nRet = Engine.SetDefaultMuteAllRemoteVideoStreams(mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_MuteRemoteVideoStream()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            bool mute;
            ParamsHelper.InitParam(out mute);

            int nRet = Engine.MuteRemoteVideoStream(uid, mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetRemoteVideoStreamType()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            VIDEO_STREAM_TYPE streamType;
            ParamsHelper.InitParam(out streamType);

            int nRet = Engine.SetRemoteVideoStreamType(uid, streamType);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetRemoteVideoSubscriptionOptions()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            VideoSubscriptionOptions options;
            ParamsHelper.InitParam(out options);

            int nRet = Engine.SetRemoteVideoSubscriptionOptions(uid, options);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetRemoteDefaultVideoStreamType()
        {
            VIDEO_STREAM_TYPE streamType;
            ParamsHelper.InitParam(out streamType);

            int nRet = Engine.SetRemoteDefaultVideoStreamType(streamType);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.EnableAudioVolumeIndication(interval, smooth, reportVad);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartAudioRecording()
        {
            string filePath;
            ParamsHelper.InitParam(out filePath);
            AUDIO_RECORDING_QUALITY_TYPE quality;
            ParamsHelper.InitParam(out quality);

            int nRet = Engine.StartAudioRecording(filePath, quality);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.StartAudioRecording(filePath, sampleRate, quality);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartAudioRecording3()
        {
            AudioRecordingConfiguration config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.StartAudioRecording(config);

            Assert.AreEqual(nRet, 0);
        }

       

        [Test]
        public void Test_StopAudioRecording()
        {


            int nRet = Engine.StopAudioRecording();

            Assert.AreEqual(nRet, 0);
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
        public void Test_StartAudioMixing()
        {
            string filePath;
            ParamsHelper.InitParam(out filePath);
            bool loopback;
            ParamsHelper.InitParam(out loopback);
            int cycle;
            ParamsHelper.InitParam(out cycle);

            int nRet = Engine.StartAudioMixing(filePath, loopback, cycle);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.StartAudioMixing(filePath, loopback, cycle, startPos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopAudioMixing()
        {


            int nRet = Engine.StopAudioMixing();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_PauseAudioMixing()
        {


            int nRet = Engine.PauseAudioMixing();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_ResumeAudioMixing()
        {


            int nRet = Engine.ResumeAudioMixing();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SelectAudioTrack()
        {
            int index;
            ParamsHelper.InitParam(out index);

            int nRet = Engine.SelectAudioTrack(index);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetAudioTrackCount()
        {


            int nRet = Engine.GetAudioTrackCount();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AdjustAudioMixingVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);

            int nRet = Engine.AdjustAudioMixingVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AdjustAudioMixingPublishVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);

            int nRet = Engine.AdjustAudioMixingPublishVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetAudioMixingPublishVolume()
        {


            int nRet = Engine.GetAudioMixingPublishVolume();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AdjustAudioMixingPlayoutVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);

            int nRet = Engine.AdjustAudioMixingPlayoutVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetAudioMixingPlayoutVolume()
        {


            int nRet = Engine.GetAudioMixingPlayoutVolume();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetAudioMixingDuration()
        {


            int nRet = Engine.GetAudioMixingDuration();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetAudioMixingCurrentPosition()
        {


            int nRet = Engine.GetAudioMixingCurrentPosition();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioMixingPosition()
        {
            int pos;
            ParamsHelper.InitParam(out pos);

            int nRet = Engine.SetAudioMixingPosition(pos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioMixingDualMonoMode()
        {
            AUDIO_MIXING_DUAL_MONO_MODE mode;
            ParamsHelper.InitParam(out mode);

            int nRet = Engine.SetAudioMixingDualMonoMode(mode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioMixingPitch()
        {
            int pitch;
            ParamsHelper.InitParam(out pitch);

            int nRet = Engine.SetAudioMixingPitch(pitch);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetEffectsVolume()
        {


            int nRet = Engine.GetEffectsVolume();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetEffectsVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);

            int nRet = Engine.SetEffectsVolume(volume);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.PreloadEffect(soundId, filePath, startPos);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.PlayEffect(soundId, filePath, loopCount, pitch, pan, gain, publish, startPos);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.PlayAllEffects(loopCount, pitch, pan, gain, publish);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetVolumeOfEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);

            int nRet = Engine.GetVolumeOfEffect(soundId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetVolumeOfEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            int volume;
            ParamsHelper.InitParam(out volume);

            int nRet = Engine.SetVolumeOfEffect(soundId, volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_PauseEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);

            int nRet = Engine.PauseEffect(soundId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_PauseAllEffects()
        {


            int nRet = Engine.PauseAllEffects();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_ResumeEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);

            int nRet = Engine.ResumeEffect(soundId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_ResumeAllEffects()
        {


            int nRet = Engine.ResumeAllEffects();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);

            int nRet = Engine.StopEffect(soundId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopAllEffects()
        {


            int nRet = Engine.StopAllEffects();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UnloadEffect()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);

            int nRet = Engine.UnloadEffect(soundId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UnloadAllEffects()
        {


            int nRet = Engine.UnloadAllEffects();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetEffectDuration()
        {
            string filePath;
            ParamsHelper.InitParam(out filePath);

            int nRet = Engine.GetEffectDuration(filePath);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetEffectPosition()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);
            int pos;
            ParamsHelper.InitParam(out pos);

            int nRet = Engine.SetEffectPosition(soundId, pos);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetEffectCurrentPosition()
        {
            int soundId;
            ParamsHelper.InitParam(out soundId);

            int nRet = Engine.GetEffectCurrentPosition(soundId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableSoundPositionIndication()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);

            int nRet = Engine.EnableSoundPositionIndication(enabled);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetRemoteVoicePosition(uid, pan, gain);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableSpatialAudio()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);

            int nRet = Engine.EnableSpatialAudio(enabled);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetRemoteUserSpatialAudioParams()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            SpatialAudioParams param;
            ParamsHelper.InitParam(out param);

            int nRet = Engine.SetRemoteUserSpatialAudioParams(uid, param);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetVoiceBeautifierPreset()
        {
            VOICE_BEAUTIFIER_PRESET preset;
            ParamsHelper.InitParam(out preset);

            int nRet = Engine.SetVoiceBeautifierPreset(preset);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioEffectPreset()
        {
            AUDIO_EFFECT_PRESET preset;
            ParamsHelper.InitParam(out preset);

            int nRet = Engine.SetAudioEffectPreset(preset);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetVoiceConversionPreset()
        {
            VOICE_CONVERSION_PRESET preset;
            ParamsHelper.InitParam(out preset);

            int nRet = Engine.SetVoiceConversionPreset(preset);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetAudioEffectParameters(preset, param1, param2);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetVoiceBeautifierParameters(preset, param1, param2);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetVoiceConversionParameters(preset, param1, param2);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLocalVoicePitch()
        {
            double pitch;
            ParamsHelper.InitParam(out pitch);

            int nRet = Engine.SetLocalVoicePitch(pitch);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLocalVoiceEqualization()
        {
            AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency;
            ParamsHelper.InitParam(out bandFrequency);
            int bandGain;
            ParamsHelper.InitParam(out bandGain);

            int nRet = Engine.SetLocalVoiceEqualization(bandFrequency, bandGain);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLocalVoiceReverb()
        {
            AUDIO_REVERB_TYPE reverbKey;
            ParamsHelper.InitParam(out reverbKey);
            int value;
            ParamsHelper.InitParam(out value);

            int nRet = Engine.SetLocalVoiceReverb(reverbKey, value);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetHeadphoneEQPreset()
        {
            HEADPHONE_EQUALIZER_PRESET preset;
            ParamsHelper.InitParam(out preset);

            int nRet = Engine.SetHeadphoneEQPreset(preset);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetHeadphoneEQParameters()
        {
            int lowGain;
            ParamsHelper.InitParam(out lowGain);
            int highGain;
            ParamsHelper.InitParam(out highGain);

            int nRet = Engine.SetHeadphoneEQParameters(lowGain, highGain);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLogFile()
        {
            string filePath;
            ParamsHelper.InitParam(out filePath);

            int nRet = Engine.SetLogFile(filePath);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLogFilter()
        {
            uint filter;
            ParamsHelper.InitParam(out filter);

            int nRet = Engine.SetLogFilter(filter);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLogLevel()
        {
            commons::LOG_LEVEL level;
            ParamsHelper.InitParam(out level);

            int nRet = Engine.SetLogLevel(level);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLogFileSize()
        {
            uint fileSizeInKBytes;
            ParamsHelper.InitParam(out fileSizeInKBytes);

            int nRet = Engine.SetLogFileSize(fileSizeInKBytes);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UploadLogFile()
        {
             string requestId;
            ParamsHelper.InitParam(out requestId);

            int nRet = Engine.UploadLogFile(ref requestId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLocalRenderMode()
        {
            RENDER_MODE_TYPE renderMode;
            ParamsHelper.InitParam(out renderMode);
            VIDEO_MIRROR_MODE_TYPE mirrorMode;
            ParamsHelper.InitParam(out mirrorMode);

            int nRet = Engine.SetLocalRenderMode(renderMode, mirrorMode);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetRemoteRenderMode(uid, renderMode, mirrorMode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLocalRenderMode2()
        {
            RENDER_MODE_TYPE renderMode;
            ParamsHelper.InitParam(out renderMode);

            int nRet = Engine.SetLocalRenderMode(renderMode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLocalVideoMirrorMode()
        {
            VIDEO_MIRROR_MODE_TYPE mirrorMode;
            ParamsHelper.InitParam(out mirrorMode);

            int nRet = Engine.SetLocalVideoMirrorMode(mirrorMode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableDualStreamMode()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);

            int nRet = Engine.EnableDualStreamMode(enabled);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableDualStreamMode2()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            SimulcastStreamConfig streamConfig;
            ParamsHelper.InitParam(out streamConfig);

            int nRet = Engine.EnableDualStreamMode(enabled, streamConfig);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetDualStreamMode()
        {
            SIMULCAST_STREAM_MODE mode;
            ParamsHelper.InitParam(out mode);

            int nRet = Engine.SetDualStreamMode(mode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetDualStreamMode2()
        {
            SIMULCAST_STREAM_MODE mode;
            ParamsHelper.InitParam(out mode);
            SimulcastStreamConfig streamConfig;
            ParamsHelper.InitParam(out streamConfig);

            int nRet = Engine.SetDualStreamMode(mode, streamConfig);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableEchoCancellationExternal()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            int audioSourceDelay;
            ParamsHelper.InitParam(out audioSourceDelay);

            int nRet = Engine.EnableEchoCancellationExternal(enabled, audioSourceDelay);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableCustomAudioLocalPlayback()
        {
            int sourceId;
            ParamsHelper.InitParam(out sourceId);
            bool enabled;
            ParamsHelper.InitParam(out enabled);

            int nRet = Engine.EnableCustomAudioLocalPlayback(sourceId, enabled);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartPrimaryCustomAudioTrack()
        {
            AudioTrackConfig config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.StartPrimaryCustomAudioTrack(config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopPrimaryCustomAudioTrack()
        {


            int nRet = Engine.StopPrimaryCustomAudioTrack();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartSecondaryCustomAudioTrack()
        {
            AudioTrackConfig config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.StartSecondaryCustomAudioTrack(config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopSecondaryCustomAudioTrack()
        {


            int nRet = Engine.StopSecondaryCustomAudioTrack();

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetRecordingAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetPlaybackAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetMixedAudioFrameParameters(sampleRate, channel, samplesPerCall);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetEarMonitoringAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetPlaybackAudioFrameBeforeMixingParameters()
        {
            int sampleRate;
            ParamsHelper.InitParam(out sampleRate);
            int channel;
            ParamsHelper.InitParam(out channel);

            int nRet = Engine.SetPlaybackAudioFrameBeforeMixingParameters(sampleRate, channel);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableAudioSpectrumMonitor()
        {
            int intervalInMS;
            ParamsHelper.InitParam(out intervalInMS);

            int nRet = Engine.EnableAudioSpectrumMonitor(intervalInMS);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_DisableAudioSpectrumMonitor()
        {


            int nRet = Engine.DisableAudioSpectrumMonitor();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RegisterAudioSpectrumObserver()
        {
            IAudioSpectrumObserver* observer;
            ParamsHelper.InitParam(out observer);

            int nRet = Engine.RegisterAudioSpectrumObserver(observer);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UnregisterAudioSpectrumObserver()
        {
            IAudioSpectrumObserver* observer;
            ParamsHelper.InitParam(out observer);

            int nRet = Engine.UnregisterAudioSpectrumObserver(observer);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AdjustRecordingSignalVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);

            int nRet = Engine.AdjustRecordingSignalVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_MuteRecordingSignal()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);

            int nRet = Engine.MuteRecordingSignal(mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AdjustPlaybackSignalVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);

            int nRet = Engine.AdjustPlaybackSignalVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AdjustUserPlaybackSignalVolume()
        {
            uint uid;
            ParamsHelper.InitParam(out uid);
            int volume;
            ParamsHelper.InitParam(out volume);

            int nRet = Engine.AdjustUserPlaybackSignalVolume(uid, volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLocalPublishFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option;
            ParamsHelper.InitParam(out option);

            int nRet = Engine.SetLocalPublishFallbackOption(option);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetRemoteSubscribeFallbackOption()
        {
            STREAM_FALLBACK_OPTIONS option;
            ParamsHelper.InitParam(out option);

            int nRet = Engine.SetRemoteSubscribeFallbackOption(option);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableLoopbackRecording()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            string deviceName;
            ParamsHelper.InitParam(out deviceName);

            int nRet = Engine.EnableLoopbackRecording(enabled, deviceName);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AdjustLoopbackSignalVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);

            int nRet = Engine.AdjustLoopbackSignalVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetLoopbackRecordingVolume()
        {


            int nRet = Engine.GetLoopbackRecordingVolume();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableInEarMonitoring()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            int includeAudioFilters;
            ParamsHelper.InitParam(out includeAudioFilters);

            int nRet = Engine.EnableInEarMonitoring(enabled, includeAudioFilters);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetInEarMonitoringVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);

            int nRet = Engine.SetInEarMonitoringVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_LoadExtensionProvider()
        {
            string path;
            ParamsHelper.InitParam(out path);
            bool unload_after_use;
            ParamsHelper.InitParam(out unload_after_use);

            int nRet = Engine.LoadExtensionProvider(path, unload_after_use);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetExtensionProviderProperty(provider, key, value);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.EnableExtension(provider, extension, enable, type);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetExtensionProperty(provider, extension, key, value, type);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.GetExtensionProperty(provider, extension, key, value, buf_len, type);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.EnableExtension(provider, extension, extensionInfo, enable);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.SetExtensionProperty(provider, extension, extensionInfo, key, value);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.GetExtensionProperty(provider, extension, extensionInfo, key, value, buf_len);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetCameraCapturerConfiguration()
        {
            CameraCapturerConfiguration config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.SetCameraCapturerConfiguration(config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_CreateCustomVideoTrack()
        {


            int nRet = Engine.CreateCustomVideoTrack();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_CreateCustomEncodedVideoTrack()
        {
            SenderOptions sender_option;
            ParamsHelper.InitParam(out sender_option);

            int nRet = Engine.CreateCustomEncodedVideoTrack(sender_option);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_DestroyCustomVideoTrack()
        {
            video_track_id_t video_track_id;
            ParamsHelper.InitParam(out video_track_id);

            int nRet = Engine.DestroyCustomVideoTrack(video_track_id);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_DestroyCustomEncodedVideoTrack()
        {
            video_track_id_t video_track_id;
            ParamsHelper.InitParam(out video_track_id);

            int nRet = Engine.DestroyCustomEncodedVideoTrack(video_track_id);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SwitchCamera()
        {


            int nRet = Engine.SwitchCamera();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_IsCameraZoomSupported()
        {


            int nRet = Engine.IsCameraZoomSupported();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_IsCameraFaceDetectSupported()
        {


            int nRet = Engine.IsCameraFaceDetectSupported();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_IsCameraTorchSupported()
        {


            int nRet = Engine.IsCameraTorchSupported();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_IsCameraFocusSupported()
        {


            int nRet = Engine.IsCameraFocusSupported();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_IsCameraAutoFocusFaceModeSupported()
        {


            int nRet = Engine.IsCameraAutoFocusFaceModeSupported();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetCameraZoomFactor()
        {
            float factor;
            ParamsHelper.InitParam(out factor);

            int nRet = Engine.SetCameraZoomFactor(factor);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableFaceDetection()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);

            int nRet = Engine.EnableFaceDetection(enabled);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetCameraMaxZoomFactor()
        {


            int nRet = Engine.GetCameraMaxZoomFactor();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetCameraFocusPositionInPreview()
        {
            float positionX;
            ParamsHelper.InitParam(out positionX);
            float positionY;
            ParamsHelper.InitParam(out positionY);

            int nRet = Engine.SetCameraFocusPositionInPreview(positionX, positionY);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetCameraTorchOn()
        {
            bool isOn;
            ParamsHelper.InitParam(out isOn);

            int nRet = Engine.SetCameraTorchOn(isOn);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetCameraAutoFocusFaceModeEnabled()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);

            int nRet = Engine.SetCameraAutoFocusFaceModeEnabled(enabled);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_IsCameraExposurePositionSupported()
        {


            int nRet = Engine.IsCameraExposurePositionSupported();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetCameraExposurePosition()
        {
            float positionXinView;
            ParamsHelper.InitParam(out positionXinView);
            float positionYinView;
            ParamsHelper.InitParam(out positionYinView);

            int nRet = Engine.SetCameraExposurePosition(positionXinView, positionYinView);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_IsCameraAutoExposureFaceModeSupported()
        {


            int nRet = Engine.IsCameraAutoExposureFaceModeSupported();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetCameraAutoExposureFaceModeEnabled()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);

            int nRet = Engine.SetCameraAutoExposureFaceModeEnabled(enabled);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetDefaultAudioRouteToSpeakerphone()
        {
            bool defaultToSpeaker;
            ParamsHelper.InitParam(out defaultToSpeaker);

            int nRet = Engine.SetDefaultAudioRouteToSpeakerphone(defaultToSpeaker);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetEnableSpeakerphone()
        {
            bool speakerOn;
            ParamsHelper.InitParam(out speakerOn);

            int nRet = Engine.SetEnableSpeakerphone(speakerOn);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_IsSpeakerphoneEnabled()
        {


            int nRet = Engine.IsSpeakerphoneEnabled();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetScreenCaptureSources()
        {
            int const&thumbSize;
            ParamsHelper.InitParam(out thumbSize);
            int const&iconSize;
            ParamsHelper.InitParam(out iconSize);
            bool const includeScreen;
            ParamsHelper.InitParam(out includeScreen);

            int nRet = Engine.GetScreenCaptureSources(thumbSize, iconSize, includeScreen);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetAudioSessionOperationRestriction()
        {
            AUDIO_SESSION_OPERATION_RESTRICTION restriction;
            ParamsHelper.InitParam(out restriction);

            int nRet = Engine.SetAudioSessionOperationRestriction(restriction);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartScreenCaptureByDisplayId()
        {
            int displayId;
            ParamsHelper.InitParam(out displayId);
            Rectangle regionRect;
            ParamsHelper.InitParam(out regionRect);
            ScreenCaptureParameters captureParams;
            ParamsHelper.InitParam(out captureParams);

            int nRet = Engine.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.StartScreenCaptureByScreenRect(screenRect, regionRect, captureParams);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetAudioDeviceInfo()
        {
            DeviceInfo deviceInfo;
            ParamsHelper.InitParam(out deviceInfo);

            int nRet = Engine.GetAudioDeviceInfo(deviceInfo);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartScreenCaptureByWindowId()
        {
            view_t windowId;
            ParamsHelper.InitParam(out windowId);
            Rectangle regionRect;
            ParamsHelper.InitParam(out regionRect);
            ScreenCaptureParameters captureParams;
            ParamsHelper.InitParam(out captureParams);

            int nRet = Engine.StartScreenCaptureByWindowId(windowId, regionRect, captureParams);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetScreenCaptureContentHint()
        {
            VIDEO_CONTENT_HINT contentHint;
            ParamsHelper.InitParam(out contentHint);

            int nRet = Engine.SetScreenCaptureContentHint(contentHint);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetScreenCaptureScenario()
        {
            SCREEN_SCENARIO_TYPE screenScenario;
            ParamsHelper.InitParam(out screenScenario);

            int nRet = Engine.SetScreenCaptureScenario(screenScenario);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UpdateScreenCaptureRegion()
        {
            Rectangle regionRect;
            ParamsHelper.InitParam(out regionRect);

            int nRet = Engine.UpdateScreenCaptureRegion(regionRect);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UpdateScreenCaptureParameters()
        {
            ScreenCaptureParameters captureParams;
            ParamsHelper.InitParam(out captureParams);

            int nRet = Engine.UpdateScreenCaptureParameters(captureParams);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartScreenCapture()
        {
            ScreenCaptureParameters2 captureParams;
            ParamsHelper.InitParam(out captureParams);

            int nRet = Engine.StartScreenCapture(captureParams);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UpdateScreenCapture()
        {
            ScreenCaptureParameters2 captureParams;
            ParamsHelper.InitParam(out captureParams);

            int nRet = Engine.UpdateScreenCapture(captureParams);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopScreenCapture()
        {


            int nRet = Engine.StopScreenCapture();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetCallId()
        {
            ref string callId;
            ParamsHelper.InitParam(out callId);

            int nRet = Engine.GetCallId(callId);

            Assert.AreEqual(nRet, 0);
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

            int nRet = Engine.Rate(callId, rating, description);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_Complain()
        {
            string callId;
            ParamsHelper.InitParam(out callId);
            string description;
            ParamsHelper.InitParam(out description);

            int nRet = Engine.Complain(callId, description);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartRtmpStreamWithoutTranscoding()
        {
            string url;
            ParamsHelper.InitParam(out url);

            int nRet = Engine.StartRtmpStreamWithoutTranscoding(url);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartRtmpStreamWithTranscoding()
        {
            string url;
            ParamsHelper.InitParam(out url);
            LiveTranscoding transcoding;
            ParamsHelper.InitParam(out transcoding);

            int nRet = Engine.StartRtmpStreamWithTranscoding(url, transcoding);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UpdateRtmpTranscoding()
        {
            LiveTranscoding transcoding;
            ParamsHelper.InitParam(out transcoding);

            int nRet = Engine.UpdateRtmpTranscoding(transcoding);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopRtmpStream()
        {
            string url;
            ParamsHelper.InitParam(out url);

            int nRet = Engine.StopRtmpStream(url);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartLocalVideoTranscoder()
        {
            LocalTranscoderConfiguration config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.StartLocalVideoTranscoder(config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UpdateLocalTranscoderConfiguration()
        {
            LocalTranscoderConfiguration config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.UpdateLocalTranscoderConfiguration(config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopLocalVideoTranscoder()
        {


            int nRet = Engine.StopLocalVideoTranscoder();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartPrimaryCameraCapture()
        {
            CameraCapturerConfiguration config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.StartPrimaryCameraCapture(config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartSecondaryCameraCapture()
        {
            CameraCapturerConfiguration config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.StartSecondaryCameraCapture(config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopPrimaryCameraCapture()
        {


            int nRet = Engine.StopPrimaryCameraCapture();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopSecondaryCameraCapture()
        {


            int nRet = Engine.StopSecondaryCameraCapture();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetCameraDeviceOrientation()
        {
            VIDEO_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            VIDEO_ORIENTATION orientation;
            ParamsHelper.InitParam(out orientation);

            int nRet = Engine.SetCameraDeviceOrientation(type, orientation);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetScreenCaptureOrientation()
        {
            VIDEO_SOURCE_TYPE type;
            ParamsHelper.InitParam(out type);
            VIDEO_ORIENTATION orientation;
            ParamsHelper.InitParam(out orientation);

            int nRet = Engine.SetScreenCaptureOrientation(type, orientation);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartPrimaryScreenCapture()
        {
            ScreenCaptureConfiguration config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.StartPrimaryScreenCapture(config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartSecondaryScreenCapture()
        {
            ScreenCaptureConfiguration config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.StartSecondaryScreenCapture(config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopPrimaryScreenCapture()
        {


            int nRet = Engine.StopPrimaryScreenCapture();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopSecondaryScreenCapture()
        {


            int nRet = Engine.StopSecondaryScreenCapture();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetConnectionState()
        {


            int nRet = Engine.GetConnectionState();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RegisterEventHandler()
        {
            IRtcEngineEventHandler* eventHandler;
            ParamsHelper.InitParam(out eventHandler);

            int nRet = Engine.RegisterEventHandler(eventHandler);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_UnregisterEventHandler()
        {
            IRtcEngineEventHandler* eventHandler;
            ParamsHelper.InitParam(out eventHandler);

            int nRet = Engine.UnregisterEventHandler(eventHandler);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetRemoteUserPriority()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            PRIORITY_TYPE userPriority;
            ParamsHelper.InitParam(out userPriority);

            int nRet = Engine.SetRemoteUserPriority(uid, userPriority);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_RegisterPacketObserver()
        {
            IPacketObserver* observer;
            ParamsHelper.InitParam(out observer);

            int nRet = Engine.RegisterPacketObserver(observer);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetEncryptionMode()
        {
            string encryptionMode;
            ParamsHelper.InitParam(out encryptionMode);

            int nRet = Engine.SetEncryptionMode(encryptionMode);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetEncryptionSecret()
        {
            string secret;
            ParamsHelper.InitParam(out secret);

            int nRet = Engine.SetEncryptionSecret(secret);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableEncryption()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            EncryptionConfig config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.EnableEncryption(enabled, config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_CreateDataStream()
        {
            int* streamId;
            ParamsHelper.InitParam(out streamId);
            bool reliable;
            ParamsHelper.InitParam(out reliable);
            bool ordered;
            ParamsHelper.InitParam(out ordered);

            int nRet = Engine.CreateDataStream(streamId, reliable, ordered);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_CreateDataStream2()
        {
            int* streamId;
            ParamsHelper.InitParam(out streamId);
            DataStreamConfig config;
            ParamsHelper.InitParam(out config);

            int nRet = Engine.CreateDataStream(streamId, config);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SendStreamMessage()
        {
            int streamId;
            ParamsHelper.InitParam(out streamId);
            string data;
            ParamsHelper.InitParam(out data);
            ulong length;
            ParamsHelper.InitParam(out length);

            int nRet = Engine.SendStreamMessage(streamId, data, length);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AddVideoWatermark()
        {
            RtcImage watermark;
            ParamsHelper.InitParam(out watermark);

            int nRet = Engine.AddVideoWatermark(watermark);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_AddVideoWatermark2()
        {
            string watermarkUrl;
            ParamsHelper.InitParam(out watermarkUrl);
            WatermarkOptions options;
            ParamsHelper.InitParam(out options);

            int nRet = Engine.AddVideoWatermark(watermarkUrl, options);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_ClearVideoWatermarks()
        {


            int nRet = Engine.ClearVideoWatermarks();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_PauseAudio()
        {


            int nRet = Engine.PauseAudio();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_ResumeAudio()
        {


            int nRet = Engine.ResumeAudio();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnableWebSdkInteroperability()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);

            int nRet = Engine.EnableWebSdkInteroperability(enabled);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SendCustomReportMessage()
        {
            string id;
            ParamsHelper.InitParam(out id);
            string category;
            ParamsHelper.InitParam(out category);
            string event;
        ParamsHelper.InitParam(out event);
string label;
        ParamsHelper.InitParam(out label);
int value;
        ParamsHelper.InitParam(out value);

            int nRet = Engine.SendCustomReportMessage(id, category, event, label, value);

        Assert.AreEqual(nRet, 0);
        }

    [Test]
    public void Test_RegisterMediaMetadataObserver()
    {
        IMetadataObserver* observer;
        ParamsHelper.InitParam(out observer);
        IMetadataObserver::METADATA_TYPE type;
        ParamsHelper.InitParam(out type);

        int nRet = Engine.RegisterMediaMetadataObserver(observer, type);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_UnregisterMediaMetadataObserver()
    {
        IMetadataObserver* observer;
        ParamsHelper.InitParam(out observer);
        IMetadataObserver::METADATA_TYPE type;
        ParamsHelper.InitParam(out type);

        int nRet = Engine.UnregisterMediaMetadataObserver(observer, type);

        Assert.AreEqual(nRet, 0);
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

        int nRet = Engine.StartAudioFrameDump(channel_id, user_id, location, uuid, passwd, duration_ms, auto_upload);

        Assert.AreEqual(nRet, 0);
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

        int nRet = Engine.StopAudioFrameDump(channel_id, user_id, location);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_RegisterLocalUserAccount()
    {
        string appId;
        ParamsHelper.InitParam(out appId);
        string userAccount;
        ParamsHelper.InitParam(out userAccount);

        int nRet = Engine.RegisterLocalUserAccount(appId, userAccount);

        Assert.AreEqual(nRet, 0);
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

        int nRet = Engine.JoinChannelWithUserAccount(token, channelId, userAccount);

        Assert.AreEqual(nRet, 0);
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

        int nRet = Engine.JoinChannelWithUserAccount(token, channelId, userAccount, options);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_JoinChannelWithUserAccountEx()
    {
        string token;
        ParamsHelper.InitParam(out token);
        string channelId;
        ParamsHelper.InitParam(out channelId);
        string userAccount;
        ParamsHelper.InitParam(out userAccount);
        ChannelMediaOptions options;
        ParamsHelper.InitParam(out options);
        IRtcEngineEventHandler* eventHandler;
        ParamsHelper.InitParam(out eventHandler);

        int nRet = Engine.JoinChannelWithUserAccountEx(token, channelId, userAccount, options, eventHandler);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_GetUserInfoByUserAccount()
    {
        string userAccount;
        ParamsHelper.InitParam(out userAccount);
        rtc::UserInfo* userInfo;
        ParamsHelper.InitParam(out userInfo);

        int nRet = Engine.GetUserInfoByUserAccount(userAccount, userInfo);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_GetUserInfoByUid()
    {
        uid_t uid;
        ParamsHelper.InitParam(out uid);
        rtc::UserInfo* userInfo;
        ParamsHelper.InitParam(out userInfo);

        int nRet = Engine.GetUserInfoByUid(uid, userInfo);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_StartChannelMediaRelay()
    {
        ChannelMediaRelayConfiguration configuration;
        ParamsHelper.InitParam(out configuration);

        int nRet = Engine.StartChannelMediaRelay(configuration);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_UpdateChannelMediaRelay()
    {
        ChannelMediaRelayConfiguration configuration;
        ParamsHelper.InitParam(out configuration);

        int nRet = Engine.UpdateChannelMediaRelay(configuration);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_StopChannelMediaRelay()
    {


        int nRet = Engine.StopChannelMediaRelay();

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_PauseAllChannelMediaRelay()
    {


        int nRet = Engine.PauseAllChannelMediaRelay();

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_ResumeAllChannelMediaRelay()
    {


        int nRet = Engine.ResumeAllChannelMediaRelay();

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_SetDirectCdnStreamingAudioConfiguration()
    {
        AUDIO_PROFILE_TYPE profile;
        ParamsHelper.InitParam(out profile);

        int nRet = Engine.SetDirectCdnStreamingAudioConfiguration(profile);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_SetDirectCdnStreamingVideoConfiguration()
    {
        VideoEncoderConfiguration config;
        ParamsHelper.InitParam(out config);

        int nRet = Engine.SetDirectCdnStreamingVideoConfiguration(config);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_StartDirectCdnStreaming()
    {
        IDirectCdnStreamingEventHandler* eventHandler;
        ParamsHelper.InitParam(out eventHandler);
        string publishUrl;
        ParamsHelper.InitParam(out publishUrl);
        DirectCdnStreamingMediaOptions options;
        ParamsHelper.InitParam(out options);

        int nRet = Engine.StartDirectCdnStreaming(eventHandler, publishUrl, options);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_StopDirectCdnStreaming()
    {


        int nRet = Engine.StopDirectCdnStreaming();

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_UpdateDirectCdnStreamingMediaOptions()
    {
        DirectCdnStreamingMediaOptions options;
        ParamsHelper.InitParam(out options);

        int nRet = Engine.UpdateDirectCdnStreamingMediaOptions(options);

        Assert.AreEqual(nRet, 0);
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

        int nRet = Engine.StartRhythmPlayer(sound1, sound2, config);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_StopRhythmPlayer()
    {


        int nRet = Engine.StopRhythmPlayer();

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_ConfigRhythmPlayer()
    {
        AgoraRhythmPlayerConfig config;
        ParamsHelper.InitParam(out config);

        int nRet = Engine.ConfigRhythmPlayer(config);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_TakeSnapshot()
    {
        uid_t uid;
        ParamsHelper.InitParam(out uid);
        string filePath;
        ParamsHelper.InitParam(out filePath);

        int nRet = Engine.TakeSnapshot(uid, filePath);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_EnableContentInspect()
    {
        bool enabled;
        ParamsHelper.InitParam(out enabled);
        media::ContentInspectConfig const&config;
        ParamsHelper.InitParam(out config);

        int nRet = Engine.EnableContentInspect(enabled, config);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_AdjustCustomAudioPublishVolume()
    {
        int32_t sourceId;
        ParamsHelper.InitParam(out sourceId);
        int volume;
        ParamsHelper.InitParam(out volume);

        int nRet = Engine.AdjustCustomAudioPublishVolume(sourceId, volume);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_AdjustCustomAudioPlayoutVolume()
    {
        int32_t sourceId;
        ParamsHelper.InitParam(out sourceId);
        int volume;
        ParamsHelper.InitParam(out volume);

        int nRet = Engine.AdjustCustomAudioPlayoutVolume(sourceId, volume);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_SetCloudProxy()
    {
        CLOUD_PROXY_TYPE proxyType;
        ParamsHelper.InitParam(out proxyType);

        int nRet = Engine.SetCloudProxy(proxyType);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_SetLocalAccessPoint()
    {
        LocalAccessPointConfiguration config;
        ParamsHelper.InitParam(out config);

        int nRet = Engine.SetLocalAccessPoint(config);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_SetAdvancedAudioOptions()
    {
        AdvancedAudioOptions options;
        ParamsHelper.InitParam(out options);
        int sourceType;
        ParamsHelper.InitParam(out sourceType);

        int nRet = Engine.SetAdvancedAudioOptions(options, sourceType);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_SetAVSyncSource()
    {
        string channelId;
        ParamsHelper.InitParam(out channelId);
        uid_t uid;
        ParamsHelper.InitParam(out uid);

        int nRet = Engine.SetAVSyncSource(channelId, uid);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_EnableVideoImageSource()
    {
        bool enable;
        ParamsHelper.InitParam(out enable);
        ImageTrackOptions options;
        ParamsHelper.InitParam(out options);

        int nRet = Engine.EnableVideoImageSource(enable, options);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_GetCurrentMonotonicTimeInMs()
    {


        int nRet = Engine.GetCurrentMonotonicTimeInMs();

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_EnableWirelessAccelerate()
    {
        bool enabled;
        ParamsHelper.InitParam(out enabled);

        int nRet = Engine.EnableWirelessAccelerate(enabled);

        Assert.AreEqual(nRet, 0);
    }

    [Test]
    public void Test_GetNetworkType()
    {


        int nRet = Engine.GetNetworkType();

        Assert.AreEqual(nRet, 0);
    }

    #endregion





}

}