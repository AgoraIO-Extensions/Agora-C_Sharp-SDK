#define AGORA_RTC
#define AGORA_RTM
using System;
using view_t = System.Int64;
using track_id_t = System.UInt32;
namespace Agora.Rtc
{

    public abstract class IRtcEngineS : IRtcEngineBase
    {
        public abstract int InitEventHandler(IRtcEngineEventHandlerS engineEventHandler);

        public abstract ILocalSpatialAudioEngineS GetLocalSpatialAudioEngine();

        public abstract IH265TranscoderS GetH265Transcoder();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        public abstract int SendMetadata(MetadataS metadata, VIDEO_SOURCE_TYPE source_type);
#endif

        #region terra IRtcEngineS
        public abstract int PrepareUserAccount(string userAccount, uint uid);

        public abstract int Initialize(RtcEngineContextS contextS);

        public abstract int JoinChannel(string token, string channelId, string info, string userAccount);

        public abstract int JoinChannel(string token, string channelId, string userAccount, ChannelMediaOptions options);

        public abstract int SetupRemoteVideo(VideoCanvasS canvas);

        public abstract int SetupLocalVideo(VideoCanvasBase canvas);

        public abstract int MuteRemoteAudioStream(string userAccount, bool mute);

        public abstract int MuteRemoteVideoStream(string userAccount, bool mute);

        public abstract int SetRemoteVideoStreamType(string userAccount, VIDEO_STREAM_TYPE streamType);

        public abstract int SetRemoteVideoSubscriptionOptions(string userAccount, VideoSubscriptionOptions options);

        public abstract int SetSubscribeAudioBlocklist(string[] userAccountList, int userAccountNumber);

        public abstract int SetSubscribeAudioAllowlist(string[] userAccountList, int userAccountNumber);

        public abstract int SetSubscribeVideoBlocklist(string[] userAccountList, int userAccountNumber);

        public abstract int SetSubscribeVideoAllowlist(string[] userAccountList, int userAccountNumber);

        public abstract IMediaRecorderS CreateMediaRecorder(RecorderStreamInfoS info);

        public abstract int DestroyMediaRecorder(IMediaRecorderS mediaRecorderS);

        public abstract int SetRemoteVoicePosition(string userAccount, double pan, double gain);

        public abstract int SetRemoteUserSpatialAudioParams(string userAccount, SpatialAudioParams @params);

        public abstract int SetRemoteRenderMode(string userAccount, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        public abstract int RegisterAudioSpectrumObserver(IAudioSpectrumObserverS observerS);

        public abstract int UnregisterAudioSpectrumObserver();

        public abstract int AdjustUserPlaybackSignalVolume(string userAccount, int volume);

        public abstract int SetHighPriorityUserList(string[] userAccountList, int userAccountNum, STREAM_FALLBACK_OPTIONS option);

        public abstract int EnableExtension(string provider, string extension, ExtensionInfoS extensionInfoS, bool enable = true);

        public abstract int SetExtensionProperty(string provider, string extension, ExtensionInfoS extensionInfoS, string key, string value);

        public abstract int GetExtensionProperty(string provider, string extension, ExtensionInfoS extensionInfoS, string key, ref string value, int buf_len);

        public abstract int StartRtmpStreamWithTranscoding(string url, LiveTranscodingS transcodingS);

        public abstract int UpdateRtmpTranscoding(LiveTranscodingS transcodingS);

        public abstract int StartLocalVideoTranscoder(LocalTranscoderConfigurationS configS);

        public abstract int UpdateLocalTranscoderConfiguration(LocalTranscoderConfigurationS configS);

        public abstract int SetRemoteUserPriority(string userAccount, PRIORITY_TYPE userPriority);

        public abstract int RegisterMediaMetadataObserver(IMetadataObserverS observerS, METADATA_TYPE type);

        public abstract int UnregisterMediaMetadataObserver();

        public abstract int StartAudioFrameDump(string channel_id, string userAccount, string location, string uuid, string passwd, long duration_ms, bool auto_upload);

        public abstract int StopAudioFrameDump(string channel_id, string userAccount, string location);

        public abstract int StartOrUpdateChannelMediaRelay(ChannelMediaRelayConfigurationS configuration);

        public abstract int TakeSnapshot(string userAccount, string filePath);

        public abstract int SetAVSyncSource(string channelId, string userAccount);
        #endregion terra IRtcEngineS

        public abstract int RegisterVideoFrameObserver(IVideoFrameObserverS observer, VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract int UnRegisterVideoFrameObserver();

        public abstract int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserverS observer, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract int UnRegisterVideoEncodedFrameObserver();

        public abstract int RegisterAudioFrameObserver(IAudioFrameObserverBase audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract int UnRegisterAudioFrameObserver();

        #region terra IMediaEngineS
        public abstract int PushEncodedVideoImage(byte[] imageBuffer, ulong length, EncodedVideoFrameInfoS videoEncodedFrameInfo, uint videoTrackId = 0);


        #endregion terra IMediaEngineS
    };

}