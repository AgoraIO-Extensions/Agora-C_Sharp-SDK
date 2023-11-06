#define AGORA_RTC
#define AGORA_RTM
using System;
using view_t = System.Int64;
using track_id_t = System.UInt32;
namespace Agora.Rtc
{

    public abstract class IRtcEngine : IRtcEngineBase
    {
        public abstract int InitEventHandler(IRtcEngineEventHandler engineEventHandler);

        public abstract ILocalSpatialAudioEngine GetLocalSpatialAudioEngine();

        public abstract IH265Transcoder GetH265Transcoder();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        public abstract int SendMetadata(Metadata metadata, VIDEO_SOURCE_TYPE source_type);
#endif

        #region terra IRtcEngine
        public abstract int Initialize(RtcEngineContext context);

        public abstract int PreloadChannel(string token, string channelId, uint uid);

        public abstract int PreloadChannel(string token, string channelId, string userAccount);

        public abstract int UpdatePreloadChannelToken(string token);

        public abstract int JoinChannel(string token, string channelId, string info, uint uid);

        public abstract int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options);

        public abstract int SetupRemoteVideo(VideoCanvas canvas);

        public abstract int SetupLocalVideo(VideoCanvas canvas);

        [Obsolete("This method is deprecated. You can use the \ref IRtcEngine::setAudioProfile(AUDIO_PROFILE_TYPE) \"setAudioProfile\" method instead. To set the audio scenario, call the \ref IRtcEngine::initialize \"initialize\" method and pass value in the `audioScenario` member in the RtcEngineContext struct.")]
        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario);

        [Obsolete("This method is deprecated. To set whether to receive remote audio streams by default, call \ref IRtcEngine::muteAllRemoteAudioStreams \"muteAllRemoteAudioStreams\" before calling `joinChannel`")]
        public abstract int SetDefaultMuteAllRemoteAudioStreams(bool mute);

        public abstract int MuteRemoteAudioStream(uint uid, bool mute);

        [Obsolete("This method is deprecated. To set whether to receive remote video streams by default, call \ref IRtcEngine::muteAllRemoteVideoStreams \"muteAllRemoteVideoStreams\" before calling `joinChannel`.")]
        public abstract int SetDefaultMuteAllRemoteVideoStreams(bool mute);

        public abstract int MuteRemoteVideoStream(uint uid, bool mute);

        public abstract int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType);

        public abstract int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options);

        public abstract int SetSubscribeAudioBlocklist(uint[] uidList, int uidNumber);

        public abstract int SetSubscribeAudioAllowlist(uint[] uidList, int uidNumber);

        public abstract int SetSubscribeVideoBlocklist(uint[] uidList, int uidNumber);

        public abstract int SetSubscribeVideoAllowlist(uint[] uidList, int uidNumber);

        public abstract IMediaRecorder CreateMediaRecorder(RecorderStreamInfo info);

        public abstract int DestroyMediaRecorder(IMediaRecorder mediaRecorder);

        public abstract int SetRemoteVoicePosition(uint uid, double pan, double gain);

        public abstract int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams @params);

        public abstract int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        public abstract int RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer);

        public abstract int UnregisterAudioSpectrumObserver();

        public abstract int AdjustUserPlaybackSignalVolume(uint uid, int volume);

        public abstract int SetHighPriorityUserList(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option);

        public abstract int EnableExtension(string provider, string extension, ExtensionInfo extensionInfo, bool enable = true);

        public abstract int SetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, string value);

        public abstract int GetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, ref string value, int buf_len);

        public abstract int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding);

        public abstract int UpdateRtmpTranscoding(LiveTranscoding transcoding);

        public abstract int StartLocalVideoTranscoder(LocalTranscoderConfiguration config);

        public abstract int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config);

        public abstract int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority);

        [Obsolete("This method is deprecated. Use enableEncryption(bool enabled, const EncryptionConfig&) instead.")]
        public abstract int SetEncryptionMode(string encryptionMode);

        [Obsolete("This method is deprecated. Use enableEncryption(bool enabled, const EncryptionConfig&) instead.")]
        public abstract int SetEncryptionSecret(string secret);

        public abstract int AddVideoWatermark(RtcImage watermark);

        [Obsolete("Use disableAudio() instead.")]
        public abstract int PauseAudio();

        [Obsolete("Use enableAudio() instead.")]
        public abstract int ResumeAudio();

        [Obsolete("The Agora NG SDK enables the interoperablity with the Web SDK.")]
        public abstract int EnableWebSdkInteroperability(bool enabled);

        public abstract int RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type);

        public abstract int UnregisterMediaMetadataObserver();

        public abstract int StartAudioFrameDump(string channel_id, uint uid, string location, string uuid, string passwd, long duration_ms, bool auto_upload);

        public abstract int StopAudioFrameDump(string channel_id, uint uid, string location);

        public abstract int RegisterLocalUserAccount(string appId, string userAccount);

        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount);

        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options);

        public abstract int GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo);

        public abstract int GetUserInfoByUid(uint uid, ref UserInfo userInfo);

        public abstract int StartOrUpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelay` instead.")]
        public abstract int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelay` instead.")]
        public abstract int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        public abstract int TakeSnapshot(uint uid, string filePath);

        public abstract int SetAVSyncSource(string channelId, uint uid);

        public abstract int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams);
        #endregion terra IRtcEngine

        public abstract int RegisterVideoFrameObserver(IVideoFrameObserver observer, VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract int UnRegisterVideoFrameObserver();

        public abstract int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver observer, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract int UnRegisterVideoEncodedFrameObserver();

        public abstract int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract int UnRegisterAudioFrameObserver();

        #region terra IMediaEngine
        public abstract int PushEncodedVideoImage(byte[] imageBuffer, ulong length, EncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId = 0);


        #endregion terra IMediaEngine
    };

}