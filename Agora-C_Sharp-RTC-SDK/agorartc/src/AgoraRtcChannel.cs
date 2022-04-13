//  AgoraRtcChannel.cs
//
//  Created by Yiqing Huang on June 6, 2021.
//  Modified by Yiqing Huang on July 12, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    using LitJson;
    using IrisRtcChannelPtr = IntPtr;
    using IrisEventHandlerHandleNative = IntPtr;

    public sealed class AgoraRtcChannel : IAgoraRtcChannel, IDisposable
    {
        private bool _disposed;

        private readonly string _channelId;
        private IrisRtcChannelPtr _irisRtcChannel;

        private AgoraRtcEngine _rtcEngine;

        internal static IrisEventHandlerHandleNative IrisChannelEventHandlerHandleNative = IntPtr.Zero;
        private static IrisCEventHandler _irisCEventHandler;
        private static IrisEventHandlerHandleNative _irisCChannelEventHandlerNative;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        private static AgoraCallbackObject _callbackObject;
#endif

        private CharAssistant _result;

        internal AgoraRtcChannel(AgoraRtcEngine rtcEngine, string channelId)
        {
            _result = new CharAssistant();
            _rtcEngine = rtcEngine;
            _channelId = channelId;
            _irisRtcChannel = AgoraRtcNative.GetIrisRtcChannel(rtcEngine.GetNativeHandler());
            var param = new
            {
                channelId = _channelId
            };
            AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelCreateChannel,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.CreateChannelWarning, true)]
        public static AgoraChannel CreateChannel(IRtcEngine rtcEngine, string channelId)
        {
            return rtcEngine.CreateChannel(channelId);
        }

        public override void InitEventHandler(IAgoraRtcChannelEventHandler channelEventHandler)
        {
            RtcChannelEventHandlerNative.ChannelEventHandlerDict[_channelId] = channelEventHandler;
        }

        private void ReleaseEventHandler()
        {
            RtcChannelEventHandlerNative.ChannelEventHandlerDict.Remove(_channelId);
        }

        internal static void SetChannelEventHandler(IrisRtcChannelPtr irisRtcChannelPtr)
        {
            _irisCEventHandler = new IrisCEventHandler
            {
                OnEvent = RtcChannelEventHandlerNative.OnEvent,
                OnEventWithBuffer = RtcChannelEventHandlerNative.OnEventWithBuffer
            };

            var cChannelEventHandlerNativeLocal = new IrisCEventHandlerNative
            {
                onEvent = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEvent),
                onEventWithBuffer = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEventWithBuffer)
            };

            _irisCChannelEventHandlerNative = Marshal.AllocHGlobal(Marshal.SizeOf(cChannelEventHandlerNativeLocal));
            Marshal.StructureToPtr(cChannelEventHandlerNativeLocal, _irisCChannelEventHandlerNative, true);
            IrisChannelEventHandlerHandleNative =
                AgoraRtcNative.SetIrisRtcChannelEventHandler(irisRtcChannelPtr, _irisCChannelEventHandlerNative);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            _callbackObject = new AgoraCallbackObject("Agora Channel");
            RtcChannelEventHandlerNative.CallbackObject = _callbackObject;
#endif
        }

        internal static void UnsetChannelEventHandler(IrisRtcChannelPtr irisRtcChannelPtr)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            RtcChannelEventHandlerNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif
            AgoraRtcNative.UnsetIrisRtcChannelEventHandler(irisRtcChannelPtr, IrisChannelEventHandlerHandleNative);
            Marshal.FreeHGlobal(_irisCChannelEventHandlerNative);
            _irisCChannelEventHandlerNative = IntPtr.Zero;
            IrisChannelEventHandlerHandleNative = IntPtr.Zero;
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                ReleaseEventHandler();
            }

            Release();
            _disposed = true;
        }

        private void Release()
        {
            var param = new
            {
                channelId = _channelId
            };
            AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelRelease,
                JsonMapper.ToJson(param), out _result);
            _rtcEngine.ReleaseChannel(_channelId);
            _rtcEngine = null;
            _irisRtcChannel = IntPtr.Zero;
            _result = new CharAssistant();
        }

        [Obsolete(ObsoleteMethodWarning.ReleaseChannelWarning, false)]
        public override int ReleaseChannel()
        {
            Dispose();
            return 0;
        }

        public override int JoinChannel(string token, string info, uint uid, ChannelMediaOptions options)
        {
            var param = new
            {
                channelId = _channelId,
                token,
                info,
                uid,
                options
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelJoinChannel,
                JsonMapper.ToJson(param), out _result);
        }

        public override int JoinChannelWithUserAccount(string token, string userAccount, ChannelMediaOptions options)
        {
            var param = new
            {
                channelId = _channelId,
                token,
                userAccount,
                options
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelJoinChannelWithUserAccount, JsonMapper.ToJson(param),
                out _result);
        }

        public override int LeaveChannel()
        {
            var param = new
            {
                channelId = _channelId
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelLeaveChannel,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.PublishWarning, false)]
        public override int Publish()
        {
            var param = new
            {
                channelId = _channelId
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelPublish,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.UnpublishWarning, false)]
        public override int Unpublish()
        {
            var param = new
            {
                channelId = _channelId
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelUnPublish,
                JsonMapper.ToJson(param), out _result);
        }

        public override string ChannelId()
        {
            return _channelId;
        }

        public override string GetCallId()
        {
            var param = new
            {
                channelId = _channelId
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelGetCallId,
                JsonMapper.ToJson(param), out _result) != 0
                ? null
                : _result.Result;
        }

        public override int RenewToken(string token)
        {
            var param = new
            {
                channelId = _channelId,
                token
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelRenewToken,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.SetEncryptionSecretWarning, false)]
        public override int SetEncryptionSecret(string secret)
        {
            var param = new
            {
                channelId = _channelId,
                secret
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelSetEncryptionSecret,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.SetEncryptionModeWarning, false)]
        public override int SetEncryptionMode(string encryptionMode)
        {
            var param = new
            {
                channelId = _channelId,
                encryptionMode
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelSetEncryptionMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableEncryption(bool enabled, EncryptionConfig config)
        {
            var param = new
            {
                channelId = _channelId,
                enabled,
                config = new
                {
                    config.encryptionMode,
                    config.encryptionKey,
                    config.encryptionKdfSalt
                }
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelEnableEncryption,
                JsonMapper.ToJson(param), out _result);
        }

        public override int RegisterPacketObserver(IPacketObserver observer)
        {
            var param = new
            {
                channelId = _channelId,
                observer
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelRegisterPacketObserver,
                JsonMapper.ToJson(param), out _result);
        }

        public override int RegisterMediaMetadataObserver(METADATA_TYPE type)
        {
            var param = new
            {
                channelId = _channelId,
                type
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelRegisterMediaMetadataObserver, JsonMapper.ToJson(param),
                out _result);
        }

        public override int UnRegisterMediaMetadataObserver(METADATA_TYPE type)
        {
            var param = new
            {
                channelId = _channelId,
                type
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelUnRegisterMediaMetadataObserver,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetMaxMetadataSize(int size)
        {
            var param = new
            {
                channelId = _channelId,
                size
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelSetMaxMetadataSize,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SendMetadata(Metadata metadata)
        {
            var param = new
            {
                channelId = _channelId,
                metadata
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelSendMetadata,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role)
        {
            var param = new
            {
                channelId = _channelId,
                role
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelSetClientRole,
                JsonMapper.ToJson(param), out _result);
            ;
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options)
        {
            var param = new
            {
                channelId = _channelId,
                role,
                options
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelSetClientRole,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            var param = new
            {
                channelId = _channelId,
                uid,
                userPriority
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelSetRemoteUserPriority,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            var param = new
            {
                channelId = _channelId,
                uid,
                pan,
                gain
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelSetRemoteVoicePosition,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteRenderMode(uint userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var param = new
            {
                channelId = _channelId,
                userId,
                renderMode,
                mirrorMode
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelSetRemoteRenderMode,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            var param = new
            {
                channelId = _channelId,
                mute
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelSetDefaultMuteAllRemoteAudioStreams,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            var param = new
            {
                channelId = _channelId,
                mute
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelSetDefaultMuteAllRemoteVideoStreams,
                JsonMapper.ToJson(param), out _result);
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            var param = new
            {
                channelId = _channelId,
                mute
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelMuteLocalAudioStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int MuteLocalVideoStream(bool mute)
        {
            var param = new
            {
                channelId = _channelId,
                mute
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelMuteLocalVideoStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            var param = new
            {
                channelId = _channelId,
                mute
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelMuteAllRemoteAudioStreams, JsonMapper.ToJson(param),
                out _result);
        }

        public override int AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            var param = new
            {
                channelId = _channelId,
                uid,
                volume
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelAdjustUserPlaybackSignalVolume, JsonMapper.ToJson(param),
                out _result);
        }

        public override int MuteRemoteAudioStream(uint userId, bool mute)
        {
            var param = new
            {
                channelId = _channelId,
                userId,
                mute
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelMuteRemoteAudioStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int MuteAllRemoteVideoStreams(bool mute)
        {
            var param = new
            {
                channelId = _channelId,
                mute
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelMuteAllRemoteVideoStreams, JsonMapper.ToJson(param),
                out _result);
        }

        public override int MuteRemoteVideoStream(uint userId, bool mute)
        {
            var param = new
            {
                channelId = _channelId,
                userId,
                mute
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelMuteRemoteVideoStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteVideoStreamType(uint userId, REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            var param = new
            {
                channelId = _channelId,
                userId,
                streamType
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelSetRemoteVideoStreamType, JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            var param = new
            {
                channelId = _channelId,
                streamType
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelSetRemoteDefaultVideoStreamType,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int CreateDataStream(bool reliable, bool ordered)
        {
            var param = new
            {
                channelId = _channelId,
                reliable,
                ordered
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelCreateDataStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int CreateDataStream(DataStreamConfig config)
        {
            var param = new
            {
                channelId = _channelId,
                config
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelCreateDataStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SendStreamMessage(int streamId, byte[] data)
        {
            var param = new
            {
                channelId = _channelId,
                streamId,
                length = data.Length
            };
            return AgoraRtcNative.CallIrisRtcChannelApiWithBuffer(_irisRtcChannel,
                ApiTypeChannel.kChannelSendStreamMessage,
                JsonMapper.ToJson(param), data, out _result);
        }

        public override int AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            var param = new
            {
                channelId = _channelId,
                url,
                transcodingEnabled
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelAddPublishStreamUrl,
                JsonMapper.ToJson(param), out _result);
        }

        public override int RemovePublishStreamUrl(string url)
        {
            var param = new
            {
                channelId = _channelId,
                url
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelRemovePublishStreamUrl,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLiveTranscoding(LiveTranscoding transcoding)
        {
            var param = new
            {
                channelId = _channelId,
                transcoding
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelSetLiveTranscoding,
                JsonMapper.ToJson(param), out _result);
        }

        public override int AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            var param = new
            {
                channelId = _channelId,
                url,
                config
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelAddInjectStreamUrl,
                JsonMapper.ToJson(param), out _result);
        }

        public override int RemoveInjectStreamUrl(string url)
        {
            var param = new
            {
                channelId = _channelId,
                url
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelRemoveInjectStreamUrl,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var param = new
            {
                channelId = _channelId,
                configuration
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelStartChannelMediaRelay,
                JsonMapper.ToJson(param), out _result);
        }

        public override int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var param = new
            {
                channelId = _channelId,
                configuration
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelUpdateChannelMediaRelay,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopChannelMediaRelay()
        {
            var param = new
            {
                channelId = _channelId
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel, ApiTypeChannel.kChannelStopChannelMediaRelay,
                JsonMapper.ToJson(param), out _result);
        }

        public override CONNECTION_STATE_TYPE GetConnectionState()
        {
            var param = new
            {
                channelId = _channelId
            };
            return (CONNECTION_STATE_TYPE) AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelGetConnectionState, JsonMapper.ToJson(param),
                out _result);
        }

        public override int EnableRemoteSuperResolution(uint userId, bool enable)
        {
            var param = new
            {
                channelId = _channelId,
                userId,
                enable
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelEnableRemoteSuperResolution, JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetAVSyncSource(string channelId, uint uid)
        {
            var param = new
            {
                channelId,
                uid
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelSetAVSyncSource, JsonMapper.ToJson(param),
                out _result);
        }

        public override int StartRtmpStreamWithoutTranscoding(string url)
        {
            var param = new
            {
                channelId = _channelId,
                url
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelStartRtmpStreamWithoutTranscoding, JsonMapper.ToJson(param),
                out _result);
        }

        public override int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding)
        {
            var param = new
            {
                channelId = _channelId,
                url,
                transcoding
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelStartRtmpStreamWithTranscoding, JsonMapper.ToJson(param),
                out _result);
        }

        public override int UpdateRtmpTranscoding(LiveTranscoding transcoding)
        {
            var param = new
            {
                channelId = _channelId,
                transcoding
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelUpdateRtmpTranscoding, JsonMapper.ToJson(param),
                out _result);
        }

        public override int StopRtmpStream(string url)
        {
            var param = new
            {
                channelId = _channelId,
                url
            };
            return AgoraRtcNative.CallIrisRtcChannelApi(_irisRtcChannel,
                ApiTypeChannel.kChannelStopRtmpStream, JsonMapper.ToJson(param),
                out _result);
        }

        ~AgoraRtcChannel()
        {
            Dispose(false);
        }
    }

    internal static class RtcChannelEventHandlerNative
    {
        internal static Dictionary<string, IAgoraRtcChannelEventHandler> ChannelEventHandlerDict =
            new Dictionary<string, IAgoraRtcChannelEventHandler>();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        internal static AgoraCallbackObject CallbackObject;

        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(string @event, string data)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
            var channelId = (string) AgoraJson.GetData<string>(data, "channelId");
            switch (@event)
            {
                case "onChannelWarning":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnChannelWarning(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (int) AgoraJson.GetData<int>(data, "warn"),
                                (string) AgoraJson.GetData<string>(data, "msg"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onChannelError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnChannelError(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (int) AgoraJson.GetData<int>(data, "err"),
                                (string) AgoraJson.GetData<string>(data, "msg"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onJoinChannelSuccess":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnJoinChannelSuccess(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRejoinChannelSuccess":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnRejoinChannelSuccess(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onLeaveChannel":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnLeaveChannel(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                AgoraJson.JsonToStruct<RtcStats>(data, "stats"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onClientRoleChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnClientRoleChanged(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (CLIENT_ROLE_TYPE) AgoraJson.GetData<int>(data, "oldRole"),
                                (CLIENT_ROLE_TYPE) AgoraJson.GetData<int>(data, "newRole"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onUserJoined":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnUserJoined(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onUserOffline":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnUserOffline(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (USER_OFFLINE_REASON_TYPE) AgoraJson.GetData<int>(data, "reason"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onConnectionLost":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnConnectionLost(
                                (string) AgoraJson.GetData<string>(data, "channelId"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRequestToken":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId]
                                .OnRequestToken((string) AgoraJson.GetData<string>(data, "channelId"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onTokenPrivilegeWillExpire":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnTokenPrivilegeWillExpire(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (string) AgoraJson.GetData<string>(data, "token"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRtcStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnRtcStats(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                AgoraJson.JsonToStruct<RtcStats>(data, "stats"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onNetworkQuality":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnNetworkQuality(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "txQuality"),
                                (int) AgoraJson.GetData<int>(data, "rxQuality"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteVideoStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnRemoteVideoStats(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                AgoraJson.JsonToStruct<RemoteVideoStats>(data, "stats"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteAudioStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnRemoteAudioStats(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                AgoraJson.JsonToStruct<RemoteAudioStats>(data, "stats"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteAudioStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnRemoteAudioStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (REMOTE_AUDIO_STATE) AgoraJson.GetData<int>(data, "state"),
                                (REMOTE_AUDIO_STATE_REASON) AgoraJson.GetData<int>(data, "reason"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioPublishStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnAudioPublishStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onVideoPublishStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnVideoPublishStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioSubscribeStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnAudioSubscribeStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onVideoSubscribeStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnVideoSubscribeStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onUserSuperResolutionEnabled":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnUserSuperResolutionEnabled(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "enabled"),
                                (SUPER_RESOLUTION_STATE_REASON) AgoraJson.GetData<int>(data, "reason"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onActiveSpeaker":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnActiveSpeaker(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onVideoSizeChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnVideoSizeChanged(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"),
                                (int) AgoraJson.GetData<int>(data, "rotation"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteVideoStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnRemoteVideoStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (REMOTE_VIDEO_STATE) AgoraJson.GetData<int>(data, "state"),
                                (REMOTE_VIDEO_STATE_REASON) AgoraJson.GetData<int>(data, "reason"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onStreamMessageError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnStreamMessageError(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "streamId"),
                                (int) AgoraJson.GetData<int>(data, "code"),
                                (int) AgoraJson.GetData<int>(data, "missed"),
                                (int) AgoraJson.GetData<int>(data, "cached"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onChannelMediaRelayStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnChannelMediaRelayStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (CHANNEL_MEDIA_RELAY_STATE) AgoraJson.GetData<int>(data, "state"),
                                (CHANNEL_MEDIA_RELAY_ERROR) AgoraJson.GetData<int>(data, "code"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onChannelMediaRelayEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnChannelMediaRelayEvent(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (CHANNEL_MEDIA_RELAY_EVENT) AgoraJson.GetData<int>(data, "code"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRtmpStreamingStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnRtmpStreamingStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (RTMP_STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "state"),
                                (RTMP_STREAM_PUBLISH_ERROR_TYPE) AgoraJson.GetData<int>(data, "errCode"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRtmpStreamingEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnRtmpStreamingEvent(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (RTMP_STREAMING_EVENT) AgoraJson.GetData<int>(data, "eventCode"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onTranscodingUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnTranscodingUpdated(
                                (string) AgoraJson.GetData<string>(data, "channelId"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onStreamInjectedStatus":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnStreamInjectedStatus(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "status"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onLocalPublishFallbackToAudioOnly":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnLocalPublishFallbackToAudioOnly(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (bool) AgoraJson.GetData<bool>(data, "isFallbackOrRecover"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteSubscribeFallbackToAudioOnly":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnRemoteSubscribeFallbackToAudioOnly(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "isFallbackOrRecover"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onConnectionStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnConnectionStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (CONNECTION_STATE_TYPE) AgoraJson.GetData<int>(data, "state"),
                                (CONNECTION_CHANGED_REASON_TYPE) AgoraJson.GetData<int>(data, "reason"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onClientRoleChangeFailed":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnClientRoleChangeFailed(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (CLIENT_ROLE_CHANGE_FAILED_REASON) AgoraJson.GetData<int>(data, "reason"),
                                (CLIENT_ROLE_TYPE) AgoraJson.GetData<int>(data, "currentRole"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onProxyConnected":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnProxyConnected(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (PROXY_TYPE) AgoraJson.GetData<int>(data, "proxyType"),
                                (string) AgoraJson.GetData<string>(data, "localProxyIp"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
            }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_EventWithBuffer_Native))]
#endif
        internal static void OnEventWithBuffer(string @event, string data, IntPtr buffer, uint length)
        {
            var byteData = new byte[length];
            if (buffer != IntPtr.Zero) Marshal.Copy(buffer, byteData, 0, (int) length);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
            var channelId = (string) AgoraJson.GetData<string>(data, "channelId");
            switch (@event)
            {
                case "onStreamMessage":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnStreamMessage(
                                (string) AgoraJson.GetData<string>(data, "channelId"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "streamId"), byteData, length);
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onReadyToSendMetadata":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        var metadata1 = new Metadata((uint) AgoraJson.GetData<uint>(data, "uid"),
                            (uint) AgoraJson.GetData<uint>(data, "size"), byteData,
                            (long) AgoraJson.GetData<long>(data, "timeStampMs"));
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnReadyToSendMetadata(metadata1);
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onMetadataReceived":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        var metadata2 = new Metadata((uint) AgoraJson.GetData<uint>(data, "uid"),
                            (uint) AgoraJson.GetData<uint>(data, "size"), byteData,
                            (long) AgoraJson.GetData<long>(data, "timeStampMs"));
                        if (ChannelEventHandlerDict != null && ChannelEventHandlerDict.ContainsKey(channelId))
                        {
                            ChannelEventHandlerDict[channelId].OnMetadataReceived(metadata2);
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
            }
        }
    }
}