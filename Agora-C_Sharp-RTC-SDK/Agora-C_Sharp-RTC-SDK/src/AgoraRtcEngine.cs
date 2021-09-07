//  AgoraRtcEngine.cs
//
//  Created by Yiqing Huang on June 2, 2021.
//  Modified by Yiqing Huang on July 21, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//
#define __C_SHARP__

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LitJson;
#if __UNITY__
using AOT;
#endif

namespace agora.rtc
{
    using LitJson;
    using view_t = UInt64;
    using IrisRtcEnginePtr = IntPtr;
    using IrisEventHandlerHandleNative = IntPtr;
    using IrisCEventHandlerNativeMarshal = IntPtr;
    using IrisRtcDeviceManagerPtr = IntPtr;
    using IrisRtcVideoFrameObserverHandleNative = IntPtr;
    using IrisRtcCVideoFrameObserverNativeMarshal = IntPtr;
    using IrisRtcAudioFrameObserverHandleNative = IntPtr;
    using IrisRtcRendererPtr = IntPtr;
    using IrisRtcCAudioFrameObserverNativeMarshal = IntPtr;

    public sealed class AgoraRtcEngine : IAgoraRtcEngine
    {
        private bool _disposed;

        private static readonly AgoraRtcEngine[] engineInstance = {null, null};

        private static readonly string[] identifier = {"UnityRtcMainProcess", "UnityRtcSubProcess"};

        private IrisRtcEnginePtr _irisRtcEngine;

        private IrisEventHandlerHandleNative _irisEngineEventHandlerHandleNative;
        private IrisCEventHandler _irisCEventHandler;
        private IrisEventHandlerHandleNative _irisCEngineEventHandlerNative;
        
#if __UNITY__
        private AgoraCallbackObject _callbackObject;
#endif

        private readonly Dictionary<string, AgoraRtcChannel> _channelInstance;

        private IrisRtcDeviceManagerPtr _irisRtcDeviceManager;
        private AgoraRtcVideoDeviceManager _videoDeviceManagerInstance;
        private VideoDeviceManager _deprecatedVideoDeviceManagerInstance;
        private AgoraRtcAudioPlaybackDeviceManager _audioPlaybackDeviceManagerInstance;
        private AudioPlaybackDeviceManager _deprecatedAudioPlaybackDeviceManagerInstance;
        private AgoraRtcAudioRecordingDeviceManager _audioRecordingDeviceManagerInstance;
        private AudioRecordingDeviceManager _deprecatedAudioRecordingDeviceManagerInstance;
        private AudioEffectManager _deprecatedAudioEffectManagerInstance;

        private IrisRtcCAudioFrameObserverNativeMarshal _irisRtcCAudioFrameObserverNative;
        private IrisRtcCAudioFrameObserver _irisRtcCAudioFrameObserver;
        private IrisRtcAudioFrameObserverHandleNative _irisRtcAudioFrameObserverHandleNative;

        private IrisRtcCVideoFrameObserverNativeMarshal _irisRtcCVideoFrameObserverNative;
        private IrisRtcCVideoFrameObserver _irisRtcCVideoFrameObserver;
        private IrisRtcVideoFrameObserverHandleNative _irisRtcVideoFrameObserverHandleNative;

        private CharAssistant _result;

        private AgoraRtcEngine(EngineType type = EngineType.kEngineTypeNormal)
        {
            _result = new CharAssistant();
            _channelInstance = new Dictionary<string, AgoraRtcChannel>();
            _irisRtcEngine = type == EngineType.kEngineTypeNormal
                ? AgoraRtcNative.CreateIrisRtcEngine()
                : AgoraRtcNative.CreateIrisRtcEngine(EngineType.kEngineTypeSubProcess);

            _irisRtcDeviceManager = AgoraRtcNative.GetIrisRtcDeviceManager(_irisRtcEngine);

            _videoDeviceManagerInstance = new AgoraRtcVideoDeviceManager(_irisRtcDeviceManager);
            _deprecatedVideoDeviceManagerInstance = new VideoDeviceManager(_videoDeviceManagerInstance);

            _audioPlaybackDeviceManagerInstance = new AgoraRtcAudioPlaybackDeviceManager(_irisRtcDeviceManager);
            _deprecatedAudioPlaybackDeviceManagerInstance =
                new AudioPlaybackDeviceManager(_audioPlaybackDeviceManagerInstance);

            _audioRecordingDeviceManagerInstance = new AgoraRtcAudioRecordingDeviceManager(_irisRtcDeviceManager);
            _deprecatedAudioRecordingDeviceManagerInstance =
                new AudioRecordingDeviceManager(_audioRecordingDeviceManagerInstance);

            _deprecatedAudioEffectManagerInstance =
                new AudioEffectManager(type == EngineType.kEngineTypeNormal ? engineInstance[0] : engineInstance[1]);
        }

        private void Dispose(bool disposing, bool sync)
        {
            if (_disposed) return;

            if (disposing)
            {
                ReleaseEventHandler();
                // TODO: Unmanaged resources.
                UnSetIrisAudioFrameObserver();
                UnSetIrisVideoFrameObserver();

                foreach (var channelInstance in _channelInstance.Values)
                {
                    channelInstance.Dispose();
                }

                if (AgoraRtcChannel.IrisChannelEventHandlerHandleNative != IntPtr.Zero)
                    AgoraRtcChannel.UnsetChannelEventHandler(_irisRtcEngine);

                _deprecatedVideoDeviceManagerInstance.Dispose();
                _deprecatedVideoDeviceManagerInstance = null;
                _videoDeviceManagerInstance.Dispose();
                _videoDeviceManagerInstance = null;

                _deprecatedAudioPlaybackDeviceManagerInstance.Dispose();
                _deprecatedAudioPlaybackDeviceManagerInstance = null;
                _audioPlaybackDeviceManagerInstance.Dispose();
                _audioPlaybackDeviceManagerInstance = null;

                _deprecatedAudioRecordingDeviceManagerInstance.Dispose();
                _deprecatedAudioRecordingDeviceManagerInstance = null;
                _audioRecordingDeviceManagerInstance.Dispose();
                _audioRecordingDeviceManagerInstance = null;

                _deprecatedAudioEffectManagerInstance.Dispose();
                _deprecatedAudioEffectManagerInstance = null;

                _irisRtcDeviceManager = IntPtr.Zero;
            }

            Release(sync);

            _disposed = true;
        }

        private void Release(bool sync = false)
        {
            var param = new
            {
                sync
            };

            AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineRelease,
                JsonMapper.ToJson(param), out _result);
            AgoraRtcNative.DestroyIrisRtcEngine(_irisRtcEngine);
            _irisRtcEngine = IntPtr.Zero;
            _result = new CharAssistant();
            for (var i = 0; i < engineInstance.Length; i++)
            {
                if (engineInstance[i] == this) engineInstance[i] = null;
            }
        }

        internal IrisRtcEnginePtr GetNativeHandler()
        {
            return _irisRtcEngine;
        }

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || __C_SHARP__
        public static IAgoraRtcEngine CreateAgoraRtcEngine(AgoraEngineType engineType = AgoraEngineType.MainProcess)
        {
            switch (engineType)
            {
                case AgoraEngineType.MainProcess:
                    return engineInstance[0] ?? (engineInstance[0] = new AgoraRtcEngine());
                case AgoraEngineType.SubProcess:
                    return engineInstance[1] ??
                           (engineInstance[1] = new AgoraRtcEngine(EngineType.kEngineTypeSubProcess));
                default:
                    throw new ArgumentOutOfRangeException("", engineType, null);
            }
        }
#elif UNITY_ANDROID || UNITY_IPHONE
        public static IAgoraRtcEngine CreateAgoraRtcEngine()
        {
            return engineInstance[0] ?? (engineInstance[0] = new AgoraRtcEngine());
        }
#endif

        [Obsolete(
            "This method is deprecated. Please call CreateAgoraRtcEngine and Initialize instead",
            false)]
        public static IRtcEngine GetEngine(string appId)
        {
            var agoraRtcEngine = CreateAgoraRtcEngine();
            agoraRtcEngine.Initialize(new RtcEngineContext(appId));
            return agoraRtcEngine;
        }

        [Obsolete(
            "This method is deprecated. Please call CreateAgoraRtcEngine and Initialize instead",
            false)]
        public static IRtcEngine GetEngine(RtcEngineConfig engineConfig)
        {
            var agoraRtcEngine = CreateAgoraRtcEngine();
            agoraRtcEngine.Initialize(new RtcEngineContext(engineConfig.appId, engineConfig.areaCode,
                engineConfig.logConfig));
            return agoraRtcEngine;
        }

        [Obsolete("This method is deprecated. Please call Get instead.", false)]
        public static IRtcEngine QueryEngine()
        {
            return engineInstance[0];
        }

        public static IAgoraRtcEngine Get(AgoraEngineType engineType = AgoraEngineType.MainProcess)
        {
            switch (engineType)
            {
                case AgoraEngineType.MainProcess:
                    return engineInstance[0];
                case AgoraEngineType.SubProcess:
                    return engineInstance[1];
                default:
                    throw new ArgumentOutOfRangeException("", engineType, null);
            }
        }

        private int SetAppType(AppType appType)
        {
            var param = new
            {
                appType
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetAppType,
                JsonMapper.ToJson(param), out _result);
        }

        public override int Initialize(RtcEngineContext context)
        {
            var param = new
            {
                context
            };
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineInitialize,
                JsonMapper.ToJson(param), out _result);
#if __UNITY__
            if (ret == 0) SetAppType(AppType.APP_TYPE_UNITY);
#elif __C_SHARP__
            if (ret == 0) SetAppType(AppType.APP_TYPE_C_SHARP);
#endif
            return ret;
        }

        public override void InitEventHandler(IAgoraRtcEngineEventHandler engineEventHandler)
        {
            var idx = this == engineInstance[0] ? 0 : 1;

            if (_irisEngineEventHandlerHandleNative == IntPtr.Zero)
            {
                _irisCEventHandler = idx == 0
                    ? new IrisCEventHandler
                    {
                        OnEvent = RtcEngineEventHandlerNative.OnEvent,
                        OnEventWithBuffer = RtcEngineEventHandlerNative.OnEventWithBuffer
                    }
                    : new IrisCEventHandler
                    {
                        OnEvent = RtcEngineEventHandlerNative.OnEventSubProcess,
                        OnEventWithBuffer = RtcEngineEventHandlerNative.OnEventWithBufferSubProcess
                    };

                var cEventHandlerNativeLocal = new IrisCEventHandlerNative
                {
                    onEvent = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEvent),
                    onEventWithBuffer =
                        Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEventWithBuffer)
                };

                _irisCEngineEventHandlerNative = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
                Marshal.StructureToPtr(cEventHandlerNativeLocal, _irisCEngineEventHandlerNative, true);
                _irisEngineEventHandlerHandleNative =
                    AgoraRtcNative.SetIrisRtcEngineEventHandler(_irisRtcEngine, _irisCEngineEventHandlerNative);

#if __UNITY__
                _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
                RtcEngineEventHandlerNative.CallbackObjectArr[idx] = _callbackObject;
#endif
            }

            RtcEngineEventHandlerNative.EngineEventHandlerArr[idx] = engineEventHandler;
        }

        private void ReleaseEventHandler()
        {
            var idx = this == engineInstance[0] ? 0 : 1;

            RtcEngineEventHandlerNative.EngineEventHandlerArr[idx] = null;
#if __UNITY__
            RtcEngineEventHandlerNative.CallbackObjectArr[idx] = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif
            AgoraRtcNative.UnsetIrisRtcEngineEventHandler(_irisRtcEngine, _irisEngineEventHandlerHandleNative);
            Marshal.FreeHGlobal(_irisCEngineEventHandlerNative);
            _irisEngineEventHandlerHandleNative = IntPtr.Zero;
        }

        public override void RegisterAudioFrameObserver(IAgoraRtcAudioFrameObserver audioFrameObserver)
        {
            if (this == engineInstance[1])
                throw new NotSupportedException(
                    "The `RegisterAudioFrameObserver` method is not supported by the sub-process engine.");

            SetIrisAudioFrameObserver();
            RtcAudioFrameObserverNative.AudioFrameObserver = audioFrameObserver;
        }

        public override void UnRegisterAudioFrameObserver()
        {
            if (this == engineInstance[1])
                throw new NotSupportedException(
                    "The `UnRegisterAudioFrameObserver` method is not supported by the sub-process engine.");

            UnSetIrisAudioFrameObserver();
        }

        private void SetIrisAudioFrameObserver()
        {
            if (_irisRtcAudioFrameObserverHandleNative != IntPtr.Zero) return;

            _irisRtcCAudioFrameObserver = new IrisRtcCAudioFrameObserver
            {
                OnRecordAudioFrame = RtcAudioFrameObserverNative.OnRecordAudioFrame,
                OnPlaybackAudioFrame = RtcAudioFrameObserverNative.OnPlaybackAudioFrame,
                OnMixedAudioFrame = RtcAudioFrameObserverNative.OnMixedAudioFrame,
                OnPlaybackAudioFrameBeforeMixing = RtcAudioFrameObserverNative.OnPlaybackAudioFrameBeforeMixing,
                IsMultipleChannelFrameWanted = RtcAudioFrameObserverNative.IsMultipleChannelFrameWanted,
                OnPlaybackAudioFrameBeforeMixingEx = RtcAudioFrameObserverNative.OnPlaybackAudioFrameBeforeMixingEx
            };

            var irisRtcCAudioFrameObserverNativeLocal = new IrisRtcCAudioFrameObserverNative
            {
                OnRecordAudioFrame =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioFrameObserver.OnRecordAudioFrame),
                OnPlaybackAudioFrame =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioFrameObserver.OnPlaybackAudioFrame),
                OnMixedAudioFrame =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioFrameObserver.OnMixedAudioFrame),
                OnPlaybackAudioFrameBeforeMixing =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioFrameObserver.OnPlaybackAudioFrameBeforeMixing),
                IsMultipleChannelFrameWanted =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioFrameObserver.IsMultipleChannelFrameWanted),
                OnPlaybackAudioFrameBeforeMixingEx =
                    Marshal.GetFunctionPointerForDelegate(
                        _irisRtcCAudioFrameObserver.OnPlaybackAudioFrameBeforeMixingEx)
            };

            _irisRtcCAudioFrameObserverNative =
                Marshal.AllocHGlobal(Marshal.SizeOf(irisRtcCAudioFrameObserverNativeLocal));
            Marshal.StructureToPtr(irisRtcCAudioFrameObserverNativeLocal, _irisRtcCAudioFrameObserverNative, true);

            _irisRtcAudioFrameObserverHandleNative = AgoraRtcNative.RegisterAudioFrameObserver(
                AgoraRtcNative.GetIrisRtcRawData(_irisRtcEngine), _irisRtcCAudioFrameObserverNative, 0,
                this == engineInstance[0] ? identifier[0] : identifier[1]);
        }

        private void UnSetIrisAudioFrameObserver()
        {
            if (_irisRtcAudioFrameObserverHandleNative == IntPtr.Zero) return;

            AgoraRtcNative.UnRegisterAudioFrameObserver(AgoraRtcNative.GetIrisRtcRawData(_irisRtcEngine),
                _irisRtcAudioFrameObserverHandleNative, this == engineInstance[0] ? identifier[0] : identifier[1]);
            _irisRtcAudioFrameObserverHandleNative = IntPtr.Zero;
            RtcAudioFrameObserverNative.AudioFrameObserver = null;
            _irisRtcCAudioFrameObserver = new IrisRtcCAudioFrameObserver();
            Marshal.FreeHGlobal(_irisRtcCAudioFrameObserverNative);
        }

        public override void RegisterVideoFrameObserver(IAgoraRtcVideoFrameObserver videoFrameObserver)
        {
            if (this == engineInstance[1])
                throw new NotSupportedException(
                    "The `RegisterVideoFrameObserver` method is not supported by the sub-process engine.");

            SetIrisVideoFrameObserver();
            RtcVideoFrameObserverNative.VideoFrameObserver = videoFrameObserver;
        }

        public override void UnRegisterVideoFrameObserver()
        {
            if (this == engineInstance[1])
                throw new NotSupportedException(
                    "The `UnRegisterVideoFrameObserver` method is not supported by the sub-process engine.");

            UnSetIrisVideoFrameObserver();
        }

        private void SetIrisVideoFrameObserver()
        {
            if (_irisRtcVideoFrameObserverHandleNative != IntPtr.Zero) return;

            _irisRtcCVideoFrameObserver = new IrisRtcCVideoFrameObserver
            {
                OnCaptureVideoFrame = RtcVideoFrameObserverNative.OnCaptureVideoFrame,
                OnPreEncodeVideoFrame = RtcVideoFrameObserverNative.OnPreEncodeVideoFrame,
                OnRenderVideoFrame = RtcVideoFrameObserverNative.OnRenderVideoFrame,
                GetObservedFramePosition = RtcVideoFrameObserverNative.GetObservedFramePosition,
                IsMultipleChannelFrameWanted = RtcVideoFrameObserverNative.IsMultipleChannelFrameWanted,
                OnRenderVideoFrameEx = RtcVideoFrameObserverNative.OnRenderVideoFrameEx
            };

            var irisRtcCVideoFrameObserverNativeLocal = new IrisRtcCVideoFrameObserverNative
            {
                OnCaptureVideoFrame =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoFrameObserver.OnCaptureVideoFrame),
                OnPreEncodeVideoFrame =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoFrameObserver.OnPreEncodeVideoFrame),
                OnRenderVideoFrame =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoFrameObserver.OnRenderVideoFrame),
                GetObservedFramePosition =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoFrameObserver.GetObservedFramePosition),
                IsMultipleChannelFrameWanted =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoFrameObserver.IsMultipleChannelFrameWanted),
                OnRenderVideoFrameEx =
                    Marshal.GetFunctionPointerForDelegate(
                        _irisRtcCVideoFrameObserver.OnRenderVideoFrameEx)
            };

            _irisRtcCVideoFrameObserverNative =
                Marshal.AllocHGlobal(Marshal.SizeOf(irisRtcCVideoFrameObserverNativeLocal));
            Marshal.StructureToPtr(irisRtcCVideoFrameObserverNativeLocal, _irisRtcCVideoFrameObserverNative, true);

            _irisRtcVideoFrameObserverHandleNative = AgoraRtcNative.RegisterVideoFrameObserver(
                AgoraRtcNative.GetIrisRtcRawData(_irisRtcEngine), _irisRtcCVideoFrameObserverNative, 0,
                this == engineInstance[0] ? identifier[0] : identifier[1]);
        }

        private void UnSetIrisVideoFrameObserver()
        {
            if (_irisRtcVideoFrameObserverHandleNative == IntPtr.Zero) return;

            AgoraRtcNative.UnRegisterVideoFrameObserver(AgoraRtcNative.GetIrisRtcRawData(_irisRtcEngine),
                _irisRtcVideoFrameObserverHandleNative, this == engineInstance[0] ? identifier[0] : identifier[1]);
            _irisRtcVideoFrameObserverHandleNative = IntPtr.Zero;
            RtcVideoFrameObserverNative.VideoFrameObserver = null;
            _irisRtcCVideoFrameObserver = new IrisRtcCVideoFrameObserver();
            Marshal.FreeHGlobal(_irisRtcCVideoFrameObserverNative);
        }

        public override void Dispose(bool sync = false)
        {
            Dispose(true, sync);
            GC.SuppressFinalize(this);
        }

        [Obsolete(ObsoleteMethodWarning.DestroyWarning, true)]
        public static void Destroy(AgoraRtcEngine rtcEngine = null)
        {
            if (rtcEngine == null)
            {
                if (engineInstance[0] != null) engineInstance[0].Dispose();
            }
            else
            {
                rtcEngine.Dispose();
            }
        }

        [Obsolete(
            "This method is deprecated. IAudioEffectManagerWarning is deprecated. All the methods can be called directly in AgoraRtcEngine.",
            false)]
        public override IAudioEffectManager GetAudioEffectManager()
        {
            return _deprecatedAudioEffectManagerInstance;
        }

        [Obsolete("This method is deprecated. Please call GetAgoraRtcAudioRecordingDeviceManager instead.", false)]
        public override IAudioRecordingDeviceManager GetAudioRecordingDeviceManager()
        {
            return _deprecatedAudioRecordingDeviceManagerInstance;
        }

        public override IAgoraRtcAudioRecordingDeviceManager GetAgoraRtcAudioRecordingDeviceManager()
        {
            return _audioRecordingDeviceManagerInstance;
        }

        [Obsolete("This method is deprecated. Please call GetAgoraRtcAudioPlaybackDeviceManager instead.", false)]
        public override IAudioPlaybackDeviceManager GetAudioPlaybackDeviceManager()
        {
            return _deprecatedAudioPlaybackDeviceManagerInstance;
        }

        public override IAgoraRtcAudioPlaybackDeviceManager GetAgoraRtcAudioPlaybackDeviceManager()
        {
            return _audioPlaybackDeviceManagerInstance;
        }

        [Obsolete("This method is deprecated. Please call GetAgoraRtcVideoDeviceManager instead.", false)]
        public override IVideoDeviceManager GetVideoDeviceManager()
        {
            return _deprecatedVideoDeviceManagerInstance;
        }

        public override IAgoraRtcVideoDeviceManager GetAgoraRtcVideoDeviceManager()
        {
            return _videoDeviceManagerInstance;
        }

        public override IAgoraRtcChannel CreateChannel(string channelId)
        {
            if (this == engineInstance[1])
                throw new NotSupportedException(
                    "The `CreateChannel` method is not supported by the sub-process engine.");

            AgoraRtcChannel.SetChannelEventHandler(AgoraRtcNative.GetIrisRtcChannel(_irisRtcEngine));
            if (_channelInstance.ContainsKey(channelId))
            {
                return _channelInstance[channelId];
            }

            var ret = new AgoraRtcChannel(this, channelId);
            _channelInstance.Add(channelId, ret);
            return ret;
        }

        internal IVideoStreamManager GetVideoStreamManager()
        {
            return new VideoStreamManager(this);
        }

        internal void ReleaseChannel(string channelId)
        {
            _channelInstance.Remove(channelId);
        }

        public override int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)
        {
            var param = new
            {
                profile
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetChannelProfile,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role)
        {
            var param = new
            {
                role
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetClientRole,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options)
        {
            var param = new
            {
                role,
                options
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetClientRole,
                JsonMapper.ToJson(param), out _result);
        }

        public override int JoinChannel(string token, string channelId, string info = "", uint uid = 0)
        {
            var param = new
            {
                token,
                channelId,
                info,
                uid
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineJoinChannel,
                JsonMapper.ToJson(param), out _result);
        }

        public override int JoinChannel(string token, string channelId, string info, uint uid,
            ChannelMediaOptions options)
        {
            var param = new
            {
                token,
                channelId,
                info,
                uid,
                options
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineJoinChannel,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int JoinChannel(string channelId, string info = "", uint uid = 0)
        {
            return JoinChannel(null, channelId, info, uid);
        }

        [Obsolete(ObsoleteMethodWarning.JoinChannelByKeyWarning, false)]
        public override int JoinChannelByKey(string token, string channelId, string info = "", uint uid = 0)
        {
            return JoinChannel(token, channelId, info, uid);
        }

        public override int SwitchChannel(string token, string channelId)
        {
            var param = new
            {
                token,
                channelId
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSwitchChannel,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SwitchChannel(string token, string channelId, ChannelMediaOptions options)
        {
            var param = new
            {
                token,
                channelId,
                options
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSwitchChannel,
                JsonMapper.ToJson(param), out _result);
        }

        public override int LeaveChannel()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineLeaveChannel,
                JsonMapper.ToJson(param), out _result);
        }

        public override int RenewToken(string token)
        {
            var param = new
            {
                token
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineRenewToken,
                JsonMapper.ToJson(param), out _result);
        }

        public override int RegisterLocalUserAccount(string appId, string userAccount)
        {
            var param = new
            {
                appId,
                userAccount
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineRegisterLocalUserAccount,
                JsonMapper.ToJson(param), out _result);
        }

        public override int JoinChannelWithUserAccount(string token, string channelId, string userAccount)
        {
            var param = new
            {
                token,
                channelId,
                userAccount
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineJoinChannelWithUserAccount,
                JsonMapper.ToJson(param), out _result);
        }

        public override int JoinChannelWithUserAccount(string token, string channelId, string userAccount,
            ChannelMediaOptions options)
        {
            var param = new
            {
                token,
                channelId,
                userAccount,
                options
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineJoinChannelWithUserAccount,
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetUserInfoByUserAccount(string userAccount, out UserInfo userInfo)
        {
            var param = new
            {
                userAccount
            };
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetUserInfoByUserAccount,
                JsonMapper.ToJson(param), out _result);
            userInfo = _result.Result.Length == 0 ? new UserInfo() : AgoraJson.JsonToStruct<UserInfo>(_result.Result);
            return ret;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override UserInfo GetUserInfoByUserAccount(string userAccount)
        {
            var param = new
            {
                userAccount
            };
            AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetUserInfoByUserAccount,
                JsonMapper.ToJson(param), out _result);
            return _result.Result.Length == 0 ? new UserInfo() : AgoraJson.JsonToStruct<UserInfo>(_result.Result);
        }

        public override int GetUserInfoByUid(uint uid, out UserInfo userInfo)
        {
            var param = new
            {
                uid
            };
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetUserInfoByUid,
                JsonMapper.ToJson(param), out _result);
            userInfo = _result.Result.Length == 0 ? new UserInfo() : AgoraJson.JsonToStruct<UserInfo>(_result.Result);
            return ret;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override UserInfo GetUserInfoByUid(uint uid)
        {
            var param = new
            {
                uid
            };
            AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineGetUserInfoByUid,
                JsonMapper.ToJson(param), out _result);
            return _result.Result.Length == 0 ? new UserInfo() : AgoraJson.JsonToStruct<UserInfo>(_result.Result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int StartEchoTest()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineStartEchoTest,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StartEchoTest(int intervalInSeconds)
        {
            var param = new
            {
                intervalInSeconds
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineStartEchoTest,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopEchoTest()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineStopEchoTest,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetCloudProxy(CLOUD_PROXY_TYPE proxyType)
        {
            var param = new
            {
                proxyType
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetCloudProxy,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableVideo()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineEnableVideo,
                JsonMapper.ToJson(param), out _result);
        }

        public override int DisableVideo()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineDisableVideo,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableVideoObserver()
        {
            throw new NotImplementedException();
        }

        public override int DisableVideoObserver()
        {
            throw new NotImplementedException();
        }

        [Obsolete("This method is deprecated. Please call SetVideoEncoderConfiguration instead.", false)]
        public override int SetVideoProfile(VIDEO_PROFILE_TYPE profile, bool swapWidthAndHeight = false)
        {
            var param = new
            {
                profile,
                swapWidthAndHeight
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetVideoProfile,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetVideoEncoderConfiguration, JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetCameraCapturerConfiguration, JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetupLocalVideo(VideoCanvas canvas)
        {
            var param = new
            {
                canvas = new
                {
                    view = (ulong) canvas.view,
                    canvas.renderMode,
                    canvas.channelId,
                    canvas.uid,
                    canvas.mirrorMode
                }
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetupLocalVideo,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetupRemoteVideo(VideoCanvas canvas)
        {
            var param = new
            {
                canvas = new
                {
                    view = (ulong) canvas.view,
                    canvas.renderMode,
                    canvas.channelId,
                    canvas.uid,
                    canvas.mirrorMode
                }
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetupRemoteVideo,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StartPreview()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineStartPreview,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            var param = new
            {
                uid,
                userPriority
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetRemoteUserPriority,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopPreview()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineStopPreview,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableAudio()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineEnableAudio,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableLocalAudio(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineEnableLocalAudio,
                JsonMapper.ToJson(param), out _result);
        }

        public override int DisableAudio()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineDisableAudio,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)
        {
            var param = new
            {
                profile,
                scenario
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetAudioProfile,
                JsonMapper.ToJson(param), out _result);
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineMuteLocalAudioStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineMuteAllRemoteAudioStreams,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetDefaultMuteAllRemoteAudioStreams,
                JsonMapper.ToJson(param), out _result);
        }

        public override int AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            var param = new
            {
                uid,
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAdjustUserPlaybackSignalVolume, JsonMapper.ToJson(param),
                out _result);
        }

        public override int MuteRemoteAudioStream(uint userId, bool mute)
        {
            var param = new
            {
                userId,
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineMuteRemoteAudioStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int MuteLocalVideoStream(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineMuteLocalVideoStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableLocalVideo(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineEnableLocalVideo,
                JsonMapper.ToJson(param), out _result);
        }

        public override int MuteAllRemoteVideoStreams(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineMuteAllRemoteVideoStreams,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetDefaultMuteAllRemoteVideoStreams,
                JsonMapper.ToJson(param), out _result);
        }

        public override int MuteRemoteVideoStream(uint userId, bool mute)
        {
            var param = new
            {
                userId,
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineMuteRemoteVideoStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteVideoStreamType(uint userId, REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            var param = new
            {
                userId,
                streamType
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetRemoteVideoStreamType,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            var param = new
            {
                streamType
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetRemoteDefaultVideoStreamType, JsonMapper.ToJson(param),
                out _result);
        }

        public override int EnableAudioVolumeIndication(int interval, int smooth, bool report_vad)
        {
            var param = new
            {
                interval,
                smooth,
                report_vad
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableAudioVolumeIndication,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            var param = new
            {
                filePath,
                quality
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartAudioRecording,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            var param = new
            {
                filePath,
                sampleRate,
                quality
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartAudioRecording,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StartAudioRecording(AudioRecordingConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartAudioRecording,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopAudioRecording()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopAudioRecording,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle)
        {
            var param = new
            {
                filePath,
                loopback,
                replace,
                cycle
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineStartAudioMixing,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle, int startPos)
        {
            var param = new
            {
                filePath,
                loopback,
                replace,
                cycle,
                startPos
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineStartAudioMixing,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopAudioMixing()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineStopAudioMixing,
                JsonMapper.ToJson(param), out _result);
        }

        public override int PauseAudioMixing()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEnginePauseAudioMixing,
                JsonMapper.ToJson(param), out _result);
        }

        public override int ResumeAudioMixing()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineResumeAudioMixing,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int SetHighQualityAudioParameters(bool fullband, bool stereo, bool fullBitrate)
        {
            var param = new
            {
                fullband,
                stereo,
                fullBitrate
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetHighQualityAudioParameters, JsonMapper.ToJson(param),
                out _result);
        }

        public override int AdjustAudioMixingVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAdjustAudioMixingVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int AdjustAudioMixingPlayoutVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAdjustAudioMixingPlayoutVolume, JsonMapper.ToJson(param),
                out _result);
        }

        public override int GetAudioMixingPlayoutVolume()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetAudioMixingPlayoutVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int AdjustAudioMixingPublishVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAdjustAudioMixingPublishVolume, JsonMapper.ToJson(param),
                out _result);
        }

        public override int GetAudioMixingPublishVolume()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetAudioMixingPublishVolume,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int GetAudioMixingDuration()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetAudioMixingDuration,
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetAudioMixingDuration(string filePath)
        {
            var param = new
            {
                filePath
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetAudioMixingDuration,
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetAudioMixingCurrentPosition()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetAudioMixingCurrentPosition, JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetAudioMixingPosition(int pos)
        {
            var param = new
            {
                pos
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetAudioMixingPosition,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetAudioMixingPitch(int pitch)
        {
            var param = new
            {
                pitch
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetAudioMixingPitch,
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetEffectsVolume()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineGetEffectsVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetEffectsVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetEffectsVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetVolumeOfEffect(int soundId, int volume)
        {
            var param = new
            {
                soundId,
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetVolumeOfEffect,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableFaceDetection(bool enable)
        {
            var param = new
            {
                enable
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableFaceDetection,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int PlayEffect(int soundId, string filePath, int loopCount, double pitch = 1.0,
            double pan = 0.0, int gain = 100, bool publish = false)
        {
            var param = new
            {
                soundId,
                filePath,
                loopCount,
                pitch,
                pan,
                gain,
                publish
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEnginePlayEffect,
                JsonMapper.ToJson(param), out _result);
        }

        public override int PlayEffect(int soundId, string filePath, int loopCount, int startPos, double pitch = 1.0,
            double pan = 0.0, int gain = 100, bool publish = false)
        {
            var param = new
            {
                soundId,
                filePath,
                loopCount,
                pitch,
                pan,
                gain,
                publish,
                startPos
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEnginePlayEffect,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopEffect(int soundId)
        {
            var param = new
            {
                soundId
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineStopEffect,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopAllEffects()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineStopAllEffects,
                JsonMapper.ToJson(param), out _result);
        }

        public override int PreloadEffect(int soundId, string filePath)
        {
            var param = new
            {
                soundId,
                filePath
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEnginePreloadEffect,
                JsonMapper.ToJson(param), out _result);
        }

        public override int UnloadEffect(int soundId)
        {
            var param = new
            {
                soundId
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineUnloadEffect,
                JsonMapper.ToJson(param), out _result);
        }

        public override int PauseEffect(int soundId)
        {
            var param = new
            {
                soundId
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEnginePauseEffect,
                JsonMapper.ToJson(param), out _result);
        }

        public override int PauseAllEffects()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEnginePauseAllEffects,
                JsonMapper.ToJson(param), out _result);
        }

        public override int ResumeEffect(int soundId)
        {
            var param = new
            {
                soundId
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineResumeEffect,
                JsonMapper.ToJson(param), out _result);
        }

        public override int ResumeAllEffects()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineResumeAllEffects,
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetEffectDuration()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineGetEffectDuration,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetEffectPosition(int soundId, int pos)
        {
            var param = new
            {
                soundId,
                pos
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetEffectPosition,
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetEffectCurrentPosition(int soundId)
        {
            var param = new
            {
                soundId
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineGetEffectCurrentPosition,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableDeepLearningDenoise(bool enable)
        {
            var param = new
            {
                enable
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableDeepLearningDenoise,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableSoundPositionIndication(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableSoundPositionIndication, JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            var param = new
            {
                uid,
                pan,
                gain
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetRemoteVoicePosition,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalVoicePitch(double pitch)
        {
            var param = new
            {
                pitch
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalVoicePitch,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain)
        {
            var param = new
            {
                bandFrequency,
                bandGain
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalVoiceEqualization,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            var param = new
            {
                reverbKey,
                value
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalVoiceReverb,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int SetLocalVoiceChanger(VOICE_CHANGER_PRESET voiceChanger)
        {
            var param = new
            {
                voiceChanger
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalVoiceChanger,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.SetLocalVoiceReverbPresetWarning, false)]
        public override int SetLocalVoiceReverbPreset(AUDIO_REVERB_PRESET reverbPreset)
        {
            var param = new
            {
                reverbPreset
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalVoiceReverbPreset,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)
        {
            var param = new
            {
                preset
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetVoiceBeautifierPreset,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)
        {
            var param = new
            {
                preset
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetAudioEffectPreset,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset)
        {
            var param = new
            {
                preset
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetVoiceConversionPreset,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)
        {
            var param = new
            {
                preset,
                param1,
                param2
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetAudioEffectParameters,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2)
        {
            var param = new
            {
                preset,
                param1,
                param2
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetVoiceBeautifierParameters, JsonMapper.ToJson(param),
                out _result);
        }

        [Obsolete(ObsoleteMethodWarning.SetLogFileWarning, false)]
        public override int SetLogFile(string filePath)
        {
            var param = new
            {
                filePath
            };

            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetLogFile,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.SetLogFilterWarning, false)]
        public override int SetLogFilter(uint filter)
        {
            var param = new
            {
                filter
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetLogFilter,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.SetLogFileSizeWarning, false)]
        public override int SetLogFileSize(uint fileSizeInKBytes)
        {
            var param = new
            {
                fileSizeInKBytes
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetLogFileSize,
                JsonMapper.ToJson(param), out _result);
        }

        public override string UploadLogFile()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineUploadLogFile,
                JsonMapper.ToJson(param), out _result) != 0
                ? null
                : _result.Result;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            var param = new
            {
                renderMode
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalRenderMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var param = new
            {
                renderMode,
                mirrorMode
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalRenderMode,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int SetRemoteRenderMode(uint userId, RENDER_MODE_TYPE renderMode)
        {
            var param = new
            {
                userId,
                renderMode
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetRemoteRenderMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteRenderMode(uint userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var param = new
            {
                userId,
                renderMode,
                mirrorMode
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetRemoteRenderMode,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.SetLocalVideoMirrorModeWarning, false)]
        public override int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var param = new
            {
                mirrorMode
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalVideoMirrorMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableDualStreamMode(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableDualStreamMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetExternalAudioSource(bool enabled, int sampleRate, int channels)
        {
            var param = new
            {
                enabled,
                sampleRate,
                channels
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetExternalAudioSource,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetExternalAudioSink(bool enabled, int sampleRate, int channels)
        {
            var param = new
            {
                enabled,
                sampleRate,
                channels
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetExternalAudioSink,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRecordingAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode,
            int samplesPerCall)
        {
            var param = new
            {
                sampleRate,
                channel,
                mode,
                samplesPerCall
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetRecordingAudioFrameParameters, JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetPlaybackAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            var param = new
            {
                sampleRate,
                channel,
                mode,
                samplesPerCall
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetPlaybackAudioFrameParameters, JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetMixedAudioFrameParameters(int sampleRate, int samplesPerCall)
        {
            var param = new
            {
                sampleRate,
                samplesPerCall
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetMixedAudioFrameParameters, JsonMapper.ToJson(param),
                out _result);
        }

        public override int AdjustRecordingSignalVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAdjustRecordingSignalVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int AdjustPlaybackSignalVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAdjustPlaybackSignalVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int AdjustLoopbackRecordingSignalVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAdjustLoopBackRecordingSignalVolume,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int EnableWebSdkInteroperability(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableWebSdkInteroperability, JsonMapper.ToJson(param),
                out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int SetVideoQualityParameters(bool preferFrameRateOverImageQuality)
        {
            var param = new
            {
                preferFrameRateOverImageQuality
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetVideoQualityParameters,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            var param = new
            {
                option
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalPublishFallbackOption, JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            var param = new
            {
                option
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetRemoteSubscribeFallbackOption, JsonMapper.ToJson(param),
                out _result);
        }

        public override int SwitchCamera()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSwitchCamera,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker)
        {
            var param = new
            {
                defaultToSpeaker
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetDefaultAudioRouteToSpeakerPhone,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetEnableSpeakerphone(bool speakerOn)
        {
            var param = new
            {
                speakerOn
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetEnableSpeakerPhone,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableInEarMonitoring(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableInEarMonitoring,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetInEarMonitoringVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetInEarMonitoringVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override bool IsSpeakerphoneEnabled()
        {
            var param = new { };
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineIsSpeakerPhoneEnabled,
                JsonMapper.ToJson(param), out _result);
            if (ret < 0) return false;
            return ret == 1;
        }

        public override int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)
        {
            var param = new
            {
                restriction
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetAudioSessionOperationRestriction,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableLoopbackRecording(bool enabled, string deviceName)
        {
            var param = new
            {
                enabled,
                deviceName
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableLoopBackRecording,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect,
            ScreenCaptureParameters captureParams)
        {
            var param = new
            {
                displayId,
                regionRect,
                captureParams
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartScreenCaptureByDisplayId, JsonMapper.ToJson(param),
                out _result);
        }

        public override int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect,
            ScreenCaptureParameters captureParams)
        {
            var param = new
            {
                screenRect,
                regionRect,
                captureParams
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartScreenCaptureByScreenRect, JsonMapper.ToJson(param),
                out _result);
        }

        public override int StartScreenCaptureByWindowId(view_t windowId, Rectangle regionRect,
            ScreenCaptureParameters captureParams)
        {
            var param = new
            {
                windowId,
                regionRect,
                captureParams
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartScreenCaptureByWindowId, JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetScreenCaptureContentHint(VideoContentHint contentHint)
        {
            var param = new
            {
                contentHint
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetScreenCaptureContentHint,
                JsonMapper.ToJson(param), out _result);
        }

        public override int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
        {
            var param = new
            {
                captureParams
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineUpdateScreenCaptureParameters, JsonMapper.ToJson(param),
                out _result);
        }

        public override int UpdateScreenCaptureRegion(Rectangle regionRect)
        {
            var param = new
            {
                regionRect
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineUpdateScreenCaptureRegion,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopScreenCapture()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopScreenCapture,
                JsonMapper.ToJson(param), out _result);
        }

        public override string GetCallId()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineGetCallId,
                JsonMapper.ToJson(param), out _result) != 0
                ? null
                : _result.Result;
        }

        public override int Rate(string callId, int rating, string description = "")
        {
            var param = new
            {
                callId,
                rating,
                description
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineRate,
                JsonMapper.ToJson(param), out _result);
        }

        public override int Complain(string callId, string description = "")
        {
            var param = new
            {
                callId,
                description
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineComplain,
                JsonMapper.ToJson(param), out _result);
        }

        public override string GetVersion()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineGetVersion,
                JsonMapper.ToJson(param), out _result) != 0
                ? null
                : _result.Result;
        }

        [Obsolete(
            "GetSdkVersion is deprecated, please call GetVersion instead after IAgoraRtcEngine instance has been initialized.",
            true)]
        public static string GetSdkVersion()
        {
            return "";
        }

        public override int EnableLastmileTest()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableLastMileTest,
                JsonMapper.ToJson(param), out _result);
        }

        public override int DisableLastmileTest()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineDisableLastMileTest,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StartLastmileProbeTest(LastmileProbeConfig config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartLastMileProbeTest,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopLastmileProbeTest()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopLastMileProbeTest,
                JsonMapper.ToJson(param), out _result);
        }

        public override string GetErrorDescription(int code)
        {
            var param = new
            {
                code
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetErrorDescription,
                JsonMapper.ToJson(param), out _result) != 0
                ? null
                : _result.Result;
        }

        [Obsolete(ObsoleteMethodWarning.SetEncryptionSecretWarning, false)]
        public override int SetEncryptionSecret(string secret)
        {
            var param = new
            {
                secret
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetEncryptionSecret,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.SetEncryptionModeWarning, false)]
        public override int SetEncryptionMode(string encryptionMode)
        {
            var param = new
            {
                encryptionMode
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetEncryptionMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableEncryption(bool enabled, EncryptionConfig config)
        {
            var param = new
            {
                enabled,
                config = new
                {
                    config.encryptionMode,
                    config.encryptionKey,
                    config.encryptionKdfSalt
                }
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineEnableEncryption,
                JsonMapper.ToJson(param), out _result);
        }

        public override int RegisterPacketObserver(IPacketObserver observer)
        {
            var param = new
            {
                observer
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineRegisterPacketObserver,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int CreateDataStream(bool reliable, bool ordered)
        {
            var param = new
            {
                reliable,
                ordered
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineCreateDataStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int CreateDataStream(DataStreamConfig config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineCreateDataStream,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SendStreamMessage(int streamId, byte[] data)
        {
            var param = new
            {
                streamId,
                length = data.Length
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine,
                ApiTypeEngine.kEngineSendStreamMessage,
                JsonMapper.ToJson(param), data, out _result);
        }

        public override int AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            var param = new
            {
                url,
                transcodingEnabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAddPublishStreamUrl,
                JsonMapper.ToJson(param), out _result);
        }

        public override int RemovePublishStreamUrl(string url)
        {
            var param = new
            {
                url
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineRemovePublishStreamUrl,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLiveTranscoding(LiveTranscoding transcoding)
        {
            var param = new
            {
                transcoding
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLiveTranscoding,
                JsonMapper.ToJson(param), out _result);
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int AddVideoWatermark(RtcImage watermark)
        {
            var param = new
            {
                watermark
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAddVideoWaterMark,
                JsonMapper.ToJson(param), out _result);
        }

        public override int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            var param = new
            {
                watermarkUrl,
                options
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAddVideoWaterMark,
                JsonMapper.ToJson(param), out _result);
        }

        public override int ClearVideoWatermarks()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineClearVideoWaterMarks,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetBeautyEffectOptions(bool enabled, BeautyOptions options)
        {
            var param = new
            {
                enabled,
                options
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetBeautyEffectOptions,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource)
        {
            var param = new
            {
                enabled,
                backgroundSource
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableVirtualBackground,
                JsonMapper.ToJson(param), out _result);
        }

        public override int AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            var param = new
            {
                url,
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAddInjectStreamUrl,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var param = new
            {
                configuration
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartChannelMediaRelay,
                JsonMapper.ToJson(param), out _result);
        }

        public override int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var param = new
            {
                configuration
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineUpdateChannelMediaRelay,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopChannelMediaRelay()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopChannelMediaRelay,
                JsonMapper.ToJson(param), out _result);
        }

        public override int RemoveInjectStreamUrl(string url)
        {
            var param = new
            {
                url
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineRemoveInjectStreamUrl,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SendCustomReportMessage(string id, string category, string events, string label, int value)
        {
            var param = new
            {
                id,
                category,
                events,
                label,
                value
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSendCustomReportMessage,
                JsonMapper.ToJson(param), out _result);
        }

        public override CONNECTION_STATE_TYPE GetConnectionState()
        {
            var param = new { };
            return (CONNECTION_STATE_TYPE) AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetConnectionState, JsonMapper.ToJson(param), out _result);
        }

        public override int RegisterMediaMetadataObserver(METADATA_TYPE type)
        {
            var param = new
            {
                type
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineRegisterMediaMetadataObserver, JsonMapper.ToJson(param),
                out _result);
        }

        public override int UnRegisterMediaMetadataObserver(METADATA_TYPE type)
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineUnRegisterMediaMetadataObserver, JsonMapper.ToJson(param),
                out _result);
        }

        public override int EnableRemoteSuperResolution(uint userId, bool enable)
        {
            var param = new
            {
                userId,
                enable
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableRemoteSuperResolution,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetParameters(string parameters)
        {
            var param = new
            {
                parameters
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetParameters,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetMaxMetadataSize(int size)
        {
            var param = new
            {
                size
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetMaxMetadataSize,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SendMetadata(Metadata metadata)
        {
            var param = new
            {
                metadata = new
                {
                    metadata.uid,
                    metadata.size,
                    metadata.timeStampMs
                }
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine,
                ApiTypeEngine.kEngineSendMetadata,
                JsonMapper.ToJson(param), metadata.buffer, out _result);
        }

        public override int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame, bool wrap)
        {
            var param = new
            {
                type,
                frame = new
                {
                    frame.type,
                    frame.samples,
                    frame.bytesPerSample,
                    frame.channels,
                    frame.samplesPerSec,
                    frame.renderTimeMs,
                    frame.avsync_type
                },
                wrap
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine,
                ApiTypeEngine.kMediaPushAudioFrame,
                JsonMapper.ToJson(param), frame.buffer, out _result);
        }

        public override int PushAudioFrame(AudioFrame frame)
        {
            var param = new
            {
                frame = new
                {
                    frame.type,
                    frame.samples,
                    frame.bytesPerSample,
                    frame.channels,
                    frame.samplesPerSec,
                    frame.renderTimeMs,
                    frame.avsync_type
                }
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine,
                ApiTypeEngine.kMediaPushAudioFrame,
                JsonMapper.ToJson(param), frame.buffer, out _result);
        }

        public override int PullAudioFrame(AudioFrame frame)
        {
            var param = new { };
            var ret = AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine,
                ApiTypeEngine.kMediaPullAudioFrame,
                JsonMapper.ToJson(param), frame.buffer, out _result);
            var f = _result.Result.Length == 0
                ? new AudioFrameWithoutBuffer()
                : AgoraJson.JsonToStruct<AudioFrameWithoutBuffer>(_result.Result);
            frame.avsync_type = f.avsync_type;
            frame.channels = f.channels;
            frame.samples = f.samples;
            frame.type = f.type;
            frame.bytesPerSample = f.bytesPerSample;
            frame.renderTimeMs = f.renderTimeMs;
            frame.samplesPerSec = f.samplesPerSec;
            return ret;
        }

        public override int SetExternalVideoSource(bool enable, bool useTexture = false)
        {
            var param = new
            {
                enable,
                useTexture
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kMediaSetExternalVideoSource, JsonMapper.ToJson(param),
                out _result);
        }

        public override int PushVideoFrame(ExternalVideoFrame frame)
        {
            var param = new
            {
                frame = new
                {
                    frame.type,
                    frame.format,
                    frame.stride,
                    frame.height,
                    frame.cropLeft,
                    frame.cropTop,
                    frame.cropRight,
                    frame.cropBottom,
                    frame.rotation,
                    frame.timestamp
                }
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine,
                ApiTypeEngine.kMediaPushVideoFrame,
                JsonMapper.ToJson(param), frame.buffer, out _result);
        }

        ~AgoraRtcEngine()
        {
            Dispose(false, false);
        }
    }

    internal static class RtcEngineEventHandlerNative
    {
        internal static IAgoraRtcEngineEventHandler[] EngineEventHandlerArr = {null, null};
#if __UNITY__
        internal static AgoraCallbackObject[] CallbackObjectArr = {null, null};


        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(string @event, string data)
        {
#if __UNITY__
            if (CallbackObjectArr[0] == null || CallbackObjectArr[0]._CallbackQueue == null) return;
#endif
            switch (@event)
            {
                case "onWarning":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnWarning((int) AgoraJson.GetData<int>(data, "warn"),
                                (string) AgoraJson.GetData<string>(data, "msg"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onError":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnError((int) AgoraJson.GetData<int>(data, "err"),
                                (string) AgoraJson.GetData<string>(data, "msg"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onJoinChannelSuccess":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnJoinChannelSuccess(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRejoinChannelSuccess":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRejoinChannelSuccess(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLeaveChannel":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnLeaveChannel(
                                AgoraJson.JsonToStruct<RtcStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onClientRoleChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnClientRoleChanged(
                                (CLIENT_ROLE_TYPE) AgoraJson.GetData<int>(data, "oldRole"),
                                (CLIENT_ROLE_TYPE) AgoraJson.GetData<int>(data, "newRole"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserJoined":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnUserJoined((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserOffline":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnUserOffline((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (USER_OFFLINE_REASON_TYPE) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLastmileQuality":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnLastmileQuality(
                                (int) AgoraJson.GetData<int>(data, "quality"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLastmileProbeResult":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnLastmileProbeResult(
                                AgoraJson.JsonToStruct<LastmileProbeResult>(data, "result"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onConnectionInterrupted":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(
                        () =>
                        {
#endif
                    if (EngineEventHandlerArr[0] != null)
                            {
                                EngineEventHandlerArr[0].OnConnectionInterrupted();
                            }
#if __UNITY__
                    });
#endif
                    break;
                case "onConnectionLost":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnConnectionLost();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onConnectionBanned":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnConnectionBanned();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onApiCallExecuted":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnApiCallExecuted(
                                (int) AgoraJson.GetData<int>(data, "err"),
                                (string) AgoraJson.GetData<string>(data, "api"),
                                (string) AgoraJson.GetData<string>(data, "result"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRequestToken":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRequestToken();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onTokenPrivilegeWillExpire":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnTokenPrivilegeWillExpire(
                                (string) AgoraJson.GetData<string>(data, "token"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioQuality":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnAudioQuality((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "quality"),
                                (ushort) AgoraJson.GetData<ushort>(data, "delay"),
                                (ushort) AgoraJson.GetData<ushort>(data, "lost"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRtcStats":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRtcStats(
                                AgoraJson.JsonToStruct<RtcStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onNetworkQuality":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnNetworkQuality((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "txQuality"),
                                (int) AgoraJson.GetData<int>(data, "rxQuality"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalVideoStats":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnLocalVideoStats(
                                AgoraJson.JsonToStruct<LocalVideoStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteVideoStats":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRemoteVideoStats(
                                AgoraJson.JsonToStruct<RemoteVideoStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalAudioStats":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnLocalAudioStats(
                                AgoraJson.JsonToStruct<LocalAudioStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteAudioStats":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRemoteAudioStats(
                                AgoraJson.JsonToStruct<RemoteAudioStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalAudioStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnLocalAudioStateChanged(
                                (LOCAL_AUDIO_STREAM_STATE) AgoraJson.GetData<int>(data, "state"),
                                (LOCAL_AUDIO_STREAM_ERROR) AgoraJson.GetData<int>(data, "error"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteAudioStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRemoteAudioStateChanged(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (REMOTE_AUDIO_STATE) AgoraJson.GetData<int>(data, "state"),
                                (REMOTE_AUDIO_STATE_REASON) AgoraJson.GetData<int>(data, "reason"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioPublishStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnAudioPublishStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVideoPublishStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnVideoPublishStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioSubscribeStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnAudioSubscribeStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVideoSubscribeStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnVideoSubscribeStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioVolumeIndication":
                    var speakerNumber = (uint) AgoraJson.GetData<uint>(data, "speakerNumber");
                    var speakers = AgoraJson.JsonToStructArray<AudioVolumeInfo>(data, "speakers", speakerNumber);
                    var totalVolume = (int) AgoraJson.GetData<int>(data, "totalVolume");
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnAudioVolumeIndication(speakers, speakerNumber, totalVolume);
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onActiveSpeaker":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnActiveSpeaker((uint) AgoraJson.GetData<uint>(data, "uid"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVideoStopped":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnVideoStopped();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstLocalVideoFrame":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnFirstLocalVideoFrame(
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstLocalVideoFramePublished":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnFirstLocalVideoFramePublished(
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstRemoteVideoDecoded":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnFirstRemoteVideoDecoded(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstRemoteVideoFrame":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnFirstRemoteVideoFrame(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserMuteAudio":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnUserMuteAudio((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "muted"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserMuteVideo":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnUserMuteVideo((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "muted"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserEnableVideo":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnUserEnableVideo((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "enabled"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioDeviceStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnAudioDeviceStateChanged(
                                (string) AgoraJson.GetData<string>(data, "deviceId"),
                                (int) AgoraJson.GetData<int>(data, "deviceType"),
                                (int) AgoraJson.GetData<int>(data, "deviceState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioDeviceVolumeChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnAudioDeviceVolumeChanged(
                                (MEDIA_DEVICE_TYPE) AgoraJson.GetData<int>(data, "deviceType"),
                                (int) AgoraJson.GetData<int>(data, "volume"),
                                (bool) AgoraJson.GetData<bool>(data, "muted"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onCameraReady":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnCameraReady();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onCameraFocusAreaChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnCameraFocusAreaChanged(
                                (int) AgoraJson.GetData<int>(data, "x"),
                                (int) AgoraJson.GetData<int>(data, "y"), (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFacePositionChanged":
                    var numFaces = (int) AgoraJson.GetData<int>(data, "numFaces");
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnFacePositionChanged(
                                (int) AgoraJson.GetData<int>(data, "imageWidth"),
                                (int) AgoraJson.GetData<int>(data, "imageHeight"),
                                AgoraJson.JsonToStruct<Rectangle>(
                                    (string) AgoraJson.GetData<string>(data, "vecRectangle")),
                                AgoraJson.JsonToStructArray<int>(data, "vecDistance", (uint) numFaces), numFaces);
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onCameraExposureAreaChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnCameraExposureAreaChanged(
                                (int) AgoraJson.GetData<int>(data, "x"),
                                (int) AgoraJson.GetData<int>(data, "y"), (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioMixingFinished":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnAudioMixingFinished();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioMixingStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnAudioMixingStateChanged(
                                (AUDIO_MIXING_STATE_TYPE) AgoraJson.GetData<int>(data, "state"),
                                (AUDIO_MIXING_REASON_TYPE) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteAudioMixingBegin":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRemoteAudioMixingBegin();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteAudioMixingEnd":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRemoteAudioMixingEnd();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioEffectFinished":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnAudioEffectFinished(
                                (int) AgoraJson.GetData<int>(data, "soundId"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstRemoteAudioDecoded":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnFirstRemoteAudioDecoded(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVideoDeviceStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnVideoDeviceStateChanged(
                                (string) AgoraJson.GetData<string>(data, "deviceId"),
                                (int) AgoraJson.GetData<int>(data, "deviceType"),
                                (int) AgoraJson.GetData<int>(data, "deviceState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalVideoStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnLocalVideoStateChanged(
                                (LOCAL_VIDEO_STREAM_STATE) AgoraJson.GetData<int>(data, "localVideoState"),
                                (LOCAL_VIDEO_STREAM_ERROR) AgoraJson.GetData<int>(data, "error"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVideoSizeChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnVideoSizeChanged((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"),
                                (int) AgoraJson.GetData<int>(data, "rotation"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteVideoStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRemoteVideoStateChanged(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (REMOTE_VIDEO_STATE) AgoraJson.GetData<int>(data, "state"),
                                (REMOTE_VIDEO_STATE_REASON) AgoraJson.GetData<int>(data, "reason"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserEnableLocalVideo":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnUserEnableLocalVideo(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "enabled"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onStreamMessageError":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnStreamMessageError(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "streamId"),
                                (int) AgoraJson.GetData<int>(data, "code"),
                                (int) AgoraJson.GetData<int>(data, "missed"),
                                (int) AgoraJson.GetData<int>(data, "cached"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onMediaEngineLoadSuccess":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnMediaEngineLoadSuccess();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onMediaEngineStartCallSuccess":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnMediaEngineStartCallSuccess();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVirtualBackgroundSourceEnabled":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnVirtualBackgroundSourceEnabled(
                                (bool) AgoraJson.GetData<bool>(data, "enabled"),
                                (VIRTUAL_BACKGROUND_SOURCE_STATE_REASON) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserSuperResolutionEnabled":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnUserSuperResolutionEnabled(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "enabled"),
                                (SUPER_RESOLUTION_STATE_REASON) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onChannelMediaRelayStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnChannelMediaRelayStateChanged(
                                (CHANNEL_MEDIA_RELAY_STATE) AgoraJson.GetData<int>(data, "state"),
                                (CHANNEL_MEDIA_RELAY_ERROR) AgoraJson.GetData<int>(data, "code"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onChannelMediaRelayEvent":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnChannelMediaRelayEvent(
                                (CHANNEL_MEDIA_RELAY_EVENT) AgoraJson.GetData<int>(data, "code"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstLocalAudioFrame":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnFirstLocalAudioFrame(
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstLocalAudioFramePublished":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnFirstLocalAudioFramePublished(
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstRemoteAudioFrame":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnFirstRemoteAudioFrame(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRtmpStreamingStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRtmpStreamingStateChanged(
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (RTMP_STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "state"),
                                (RTMP_STREAM_PUBLISH_ERROR) AgoraJson.GetData<int>(data, "errCode"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRtmpStreamingEvent":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRtmpStreamingEvent(
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (RTMP_STREAMING_EVENT) AgoraJson.GetData<int>(data, "eventCode"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onStreamPublished":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnStreamPublished(
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (int) AgoraJson.GetData<int>(data, "error"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onStreamUnpublished":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnStreamUnpublished(
                                (string) AgoraJson.GetData<string>(data, "url"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onTranscodingUpdated":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnTranscodingUpdated();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onStreamInjectedStatus":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnStreamInjectedStatus(
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "status"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioRouteChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnAudioRouteChanged(
                                (AUDIO_ROUTE_TYPE) AgoraJson.GetData<int>(data, "routing"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalPublishFallbackToAudioOnly":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnLocalPublishFallbackToAudioOnly(
                                (bool) AgoraJson.GetData<bool>(data, "isFallbackOrRecover"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteSubscribeFallbackToAudioOnly":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRemoteSubscribeFallbackToAudioOnly(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "isFallbackOrRecover"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteAudioTransportStats":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRemoteAudioTransportStats(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (ushort) AgoraJson.GetData<ushort>(data, "delay"),
                                (ushort) AgoraJson.GetData<ushort>(data, "lost"),
                                (ushort) AgoraJson.GetData<ushort>(data, "rxKBitRate"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteVideoTransportStats":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnRemoteVideoTransportStats(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (ushort) AgoraJson.GetData<ushort>(data, "delay"),
                                (ushort) AgoraJson.GetData<ushort>(data, "lost"),
                                (ushort) AgoraJson.GetData<ushort>(data, "rxKBitRate"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onMicrophoneEnabled":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnMicrophoneEnabled(
                                (bool) AgoraJson.GetData<bool>(data, "enabled"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onConnectionStateChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnConnectionStateChanged(
                                (CONNECTION_STATE_TYPE) AgoraJson.GetData<int>(data, "state"),
                                (CONNECTION_CHANGED_REASON_TYPE) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onNetworkTypeChanged":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnNetworkTypeChanged(
                                (NETWORK_TYPE) AgoraJson.GetData<int>(data, "type"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalUserRegistered":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnLocalUserRegistered(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (string) AgoraJson.GetData<string>(data, "userAccount"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserInfoUpdated":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnUserInfoUpdated((uint) AgoraJson.GetData<uint>(data, "uid"),
                                AgoraJson.JsonToStruct<UserInfo>(data, "info"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUploadLogResult":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnUploadLogResult(
                                (string) AgoraJson.GetData<string>(data, "requestId"),
                                (bool) AgoraJson.GetData<bool>(data, "success"),
                                (UPLOAD_ERROR_REASON) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
            }
        }
#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_EventWithBuffer_Native))]
#endif
        internal static void OnEventWithBuffer(string @event, string data, IntPtr buffer, uint length)
        {
            var byteData = new byte[length];
            if (buffer != IntPtr.Zero) Marshal.Copy(buffer, byteData, 0, (int) length);
#if __UNITY__
            if (CallbackObjectArr[0] == null || CallbackObjectArr[0]._CallbackQueue == null) return;
#endif
            switch (@event)
            {
                case "onStreamMessage":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] != null)
                        {
                            EngineEventHandlerArr[0].OnStreamMessage((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "streamId"), byteData, length);
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onReadyToSendMetadata":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] == null) return;
                        var metadata1 = new Metadata((uint) AgoraJson.GetData<uint>(data, "uid"),
                            (uint) AgoraJson.GetData<uint>(data, "size"), byteData,
                            (long) AgoraJson.GetData<long>(data, "timeStampMs"));
                        EngineEventHandlerArr[0].OnReadyToSendMetadata(metadata1);
#if __UNITY__
                    });
#endif
                    break;
                case "onMetadataReceived":
#if __UNITY__
                    CallbackObjectArr[0]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[0] == null) return;
                        var metadata2 = new Metadata((uint) AgoraJson.GetData<uint>(data, "uid"),
                            (uint) AgoraJson.GetData<uint>(data, "size"), byteData,
                            (long) AgoraJson.GetData<long>(data, "timeStampMs"));
                        EngineEventHandlerArr[0].OnMetadataReceived(metadata2);
#if __UNITY__
                    });
#endif
                    break;
            }
        }

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEventSubProcess(string @event, string data)
        {
#if __UNITY__
            if (CallbackObjectArr[1] == null || CallbackObjectArr[1]._CallbackQueue == null) return;
#endif
            switch (@event)
            {
                case "onWarning":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnWarning((int) AgoraJson.GetData<int>(data, "warn"),
                                (string) AgoraJson.GetData<string>(data, "msg"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onError":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnError((int) AgoraJson.GetData<int>(data, "err"),
                                (string) AgoraJson.GetData<string>(data, "msg"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onJoinChannelSuccess":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnJoinChannelSuccess(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRejoinChannelSuccess":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRejoinChannelSuccess(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLeaveChannel":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnLeaveChannel(
                                AgoraJson.JsonToStruct<RtcStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onClientRoleChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnClientRoleChanged(
                                (CLIENT_ROLE_TYPE) AgoraJson.GetData<int>(data, "oldRole"),
                                (CLIENT_ROLE_TYPE) AgoraJson.GetData<int>(data, "newRole"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserJoined":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnUserJoined((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserOffline":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnUserOffline((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (USER_OFFLINE_REASON_TYPE) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLastmileQuality":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnLastmileQuality(
                                (int) AgoraJson.GetData<int>(data, "quality"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLastmileProbeResult":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnLastmileProbeResult(
                                AgoraJson.JsonToStruct<LastmileProbeResult>(data, "result"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onConnectionInterrupted":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(
                        () =>
                        {
#endif
                    if (EngineEventHandlerArr[1] != null)
                            {
                                EngineEventHandlerArr[1].OnConnectionInterrupted();
                            }
#if __UNITY__
                    });
#endif
                    break;
                case "onConnectionLost":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnConnectionLost();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onConnectionBanned":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnConnectionBanned();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onApiCallExecuted":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnApiCallExecuted(
                                (int) AgoraJson.GetData<int>(data, "err"),
                                (string) AgoraJson.GetData<string>(data, "api"),
                                (string) AgoraJson.GetData<string>(data, "result"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRequestToken":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRequestToken();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onTokenPrivilegeWillExpire":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnTokenPrivilegeWillExpire(
                                (string) AgoraJson.GetData<string>(data, "token"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioQuality":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnAudioQuality((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "quality"),
                                (ushort) AgoraJson.GetData<ushort>(data, "delay"),
                                (ushort) AgoraJson.GetData<ushort>(data, "lost"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRtcStats":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRtcStats(
                                AgoraJson.JsonToStruct<RtcStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onNetworkQuality":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnNetworkQuality((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "txQuality"),
                                (int) AgoraJson.GetData<int>(data, "rxQuality"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalVideoStats":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnLocalVideoStats(
                                AgoraJson.JsonToStruct<LocalVideoStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteVideoStats":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRemoteVideoStats(
                                AgoraJson.JsonToStruct<RemoteVideoStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalAudioStats":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnLocalAudioStats(
                                AgoraJson.JsonToStruct<LocalAudioStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteAudioStats":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRemoteAudioStats(
                                AgoraJson.JsonToStruct<RemoteAudioStats>(data, "stats"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalAudioStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnLocalAudioStateChanged(
                                (LOCAL_AUDIO_STREAM_STATE) AgoraJson.GetData<int>(data, "state"),
                                (LOCAL_AUDIO_STREAM_ERROR) AgoraJson.GetData<int>(data, "error"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteAudioStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRemoteAudioStateChanged(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (REMOTE_AUDIO_STATE) AgoraJson.GetData<int>(data, "state"),
                                (REMOTE_AUDIO_STATE_REASON) AgoraJson.GetData<int>(data, "reason"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioPublishStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnAudioPublishStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVideoPublishStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnVideoPublishStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioSubscribeStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnAudioSubscribeStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVideoSubscribeStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnVideoSubscribeStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioVolumeIndication":
                    var speakerNumber = (uint) AgoraJson.GetData<uint>(data, "speakerNumber");
                    var speakers = AgoraJson.JsonToStructArray<AudioVolumeInfo>(data, "speakers", speakerNumber);
                    var totalVolume = (int) AgoraJson.GetData<int>(data, "totalVolume");
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnAudioVolumeIndication(speakers, speakerNumber, totalVolume);
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onActiveSpeaker":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnActiveSpeaker((uint) AgoraJson.GetData<uint>(data, "uid"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVideoStopped":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnVideoStopped();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstLocalVideoFrame":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnFirstLocalVideoFrame(
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstLocalVideoFramePublished":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnFirstLocalVideoFramePublished(
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstRemoteVideoDecoded":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnFirstRemoteVideoDecoded(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstRemoteVideoFrame":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnFirstRemoteVideoFrame(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserMuteAudio":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnUserMuteAudio((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "muted"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserMuteVideo":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnUserMuteVideo((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "muted"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserEnableVideo":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnUserEnableVideo((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "enabled"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioDeviceStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnAudioDeviceStateChanged(
                                (string) AgoraJson.GetData<string>(data, "deviceId"),
                                (int) AgoraJson.GetData<int>(data, "deviceType"),
                                (int) AgoraJson.GetData<int>(data, "deviceState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioDeviceVolumeChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnAudioDeviceVolumeChanged(
                                (MEDIA_DEVICE_TYPE) AgoraJson.GetData<int>(data, "deviceType"),
                                (int) AgoraJson.GetData<int>(data, "volume"),
                                (bool) AgoraJson.GetData<bool>(data, "muted"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onCameraReady":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnCameraReady();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onCameraFocusAreaChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnCameraFocusAreaChanged(
                                (int) AgoraJson.GetData<int>(data, "x"),
                                (int) AgoraJson.GetData<int>(data, "y"), (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFacePositionChanged":
                    var numFaces = (int) AgoraJson.GetData<int>(data, "numFaces");
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnFacePositionChanged(
                                (int) AgoraJson.GetData<int>(data, "imageWidth"),
                                (int) AgoraJson.GetData<int>(data, "imageHeight"),
                                AgoraJson.JsonToStruct<Rectangle>(
                                    (string) AgoraJson.GetData<string>(data, "vecRectangle")),
                                AgoraJson.JsonToStructArray<int>(data, "vecDistance", (uint) numFaces), numFaces);
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onCameraExposureAreaChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnCameraExposureAreaChanged(
                                (int) AgoraJson.GetData<int>(data, "x"),
                                (int) AgoraJson.GetData<int>(data, "y"), (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioMixingFinished":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnAudioMixingFinished();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioMixingStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnAudioMixingStateChanged(
                                (AUDIO_MIXING_STATE_TYPE) AgoraJson.GetData<int>(data, "state"),
                                (AUDIO_MIXING_REASON_TYPE) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteAudioMixingBegin":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRemoteAudioMixingBegin();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteAudioMixingEnd":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRemoteAudioMixingEnd();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioEffectFinished":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnAudioEffectFinished(
                                (int) AgoraJson.GetData<int>(data, "soundId"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstRemoteAudioDecoded":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnFirstRemoteAudioDecoded(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVideoDeviceStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnVideoDeviceStateChanged(
                                (string) AgoraJson.GetData<string>(data, "deviceId"),
                                (int) AgoraJson.GetData<int>(data, "deviceType"),
                                (int) AgoraJson.GetData<int>(data, "deviceState"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalVideoStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnLocalVideoStateChanged(
                                (LOCAL_VIDEO_STREAM_STATE) AgoraJson.GetData<int>(data, "localVideoState"),
                                (LOCAL_VIDEO_STREAM_ERROR) AgoraJson.GetData<int>(data, "error"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVideoSizeChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnVideoSizeChanged((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"),
                                (int) AgoraJson.GetData<int>(data, "rotation"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteVideoStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRemoteVideoStateChanged(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (REMOTE_VIDEO_STATE) AgoraJson.GetData<int>(data, "state"),
                                (REMOTE_VIDEO_STATE_REASON) AgoraJson.GetData<int>(data, "reason"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserEnableLocalVideo":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnUserEnableLocalVideo(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "enabled"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onStreamMessageError":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnStreamMessageError(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "streamId"),
                                (int) AgoraJson.GetData<int>(data, "code"),
                                (int) AgoraJson.GetData<int>(data, "missed"),
                                (int) AgoraJson.GetData<int>(data, "cached"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onMediaEngineLoadSuccess":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnMediaEngineLoadSuccess();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onMediaEngineStartCallSuccess":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnMediaEngineStartCallSuccess();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onVirtualBackgroundSourceEnabled":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnVirtualBackgroundSourceEnabled(
                                (bool) AgoraJson.GetData<bool>(data, "enabled"),
                                (VIRTUAL_BACKGROUND_SOURCE_STATE_REASON) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserSuperResolutionEnabled":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnUserSuperResolutionEnabled(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "enabled"),
                                (SUPER_RESOLUTION_STATE_REASON) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onChannelMediaRelayStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnChannelMediaRelayStateChanged(
                                (CHANNEL_MEDIA_RELAY_STATE) AgoraJson.GetData<int>(data, "state"),
                                (CHANNEL_MEDIA_RELAY_ERROR) AgoraJson.GetData<int>(data, "code"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onChannelMediaRelayEvent":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnChannelMediaRelayEvent(
                                (CHANNEL_MEDIA_RELAY_EVENT) AgoraJson.GetData<int>(data, "code"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstLocalAudioFrame":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnFirstLocalAudioFrame(
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstLocalAudioFramePublished":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnFirstLocalAudioFramePublished(
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onFirstRemoteAudioFrame":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnFirstRemoteAudioFrame(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRtmpStreamingStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRtmpStreamingStateChanged(
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (RTMP_STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "state"),
                                (RTMP_STREAM_PUBLISH_ERROR) AgoraJson.GetData<int>(data, "errCode"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRtmpStreamingEvent":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRtmpStreamingEvent(
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (RTMP_STREAMING_EVENT) AgoraJson.GetData<int>(data, "eventCode"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onStreamPublished":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnStreamPublished(
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (int) AgoraJson.GetData<int>(data, "error"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onStreamUnpublished":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnStreamUnpublished(
                                (string) AgoraJson.GetData<string>(data, "url"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onTranscodingUpdated":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnTranscodingUpdated();
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onStreamInjectedStatus":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnStreamInjectedStatus(
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "status"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onAudioRouteChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnAudioRouteChanged(
                                (AUDIO_ROUTE_TYPE) AgoraJson.GetData<int>(data, "routing"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalPublishFallbackToAudioOnly":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnLocalPublishFallbackToAudioOnly(
                                (bool) AgoraJson.GetData<bool>(data, "isFallbackOrRecover"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteSubscribeFallbackToAudioOnly":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRemoteSubscribeFallbackToAudioOnly(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "isFallbackOrRecover"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteAudioTransportStats":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRemoteAudioTransportStats(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (ushort) AgoraJson.GetData<ushort>(data, "delay"),
                                (ushort) AgoraJson.GetData<ushort>(data, "lost"),
                                (ushort) AgoraJson.GetData<ushort>(data, "rxKBitRate"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onRemoteVideoTransportStats":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnRemoteVideoTransportStats(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (ushort) AgoraJson.GetData<ushort>(data, "delay"),
                                (ushort) AgoraJson.GetData<ushort>(data, "lost"),
                                (ushort) AgoraJson.GetData<ushort>(data, "rxKBitRate"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onMicrophoneEnabled":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnMicrophoneEnabled(
                                (bool) AgoraJson.GetData<bool>(data, "enabled"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onConnectionStateChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnConnectionStateChanged(
                                (CONNECTION_STATE_TYPE) AgoraJson.GetData<int>(data, "state"),
                                (CONNECTION_CHANGED_REASON_TYPE) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onNetworkTypeChanged":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnNetworkTypeChanged(
                                (NETWORK_TYPE) AgoraJson.GetData<int>(data, "type"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onLocalUserRegistered":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnLocalUserRegistered(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (string) AgoraJson.GetData<string>(data, "userAccount"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUserInfoUpdated":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnUserInfoUpdated((uint) AgoraJson.GetData<uint>(data, "uid"),
                                AgoraJson.JsonToStruct<UserInfo>(data, "info"));
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onUploadLogResult":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnUploadLogResult(
                                (string) AgoraJson.GetData<string>(data, "requestId"),
                                (bool) AgoraJson.GetData<bool>(data, "success"),
                                (UPLOAD_ERROR_REASON) AgoraJson.GetData<int>(data, "reason"));
                        }
#if __UNITY__
                    });
#endif
                    break;
            }
        }
#if __UNITY__
        [MonoPInvokeCallback((typeof(Func_EventWithBuffer_Native)))]
#endif
        internal static void OnEventWithBufferSubProcess(string @event, string data, IntPtr buffer, uint length)
        {
            var byteData = new byte[length];
            if (buffer != IntPtr.Zero) Marshal.Copy(buffer, byteData, 0, (int) length);
#if __UNITY__
            if (CallbackObjectArr[1] == null || CallbackObjectArr[1]._CallbackQueue == null) return;
#endif
            switch (@event)
            {
                case "onStreamMessage":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] != null)
                        {
                            EngineEventHandlerArr[1].OnStreamMessage((uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "streamId"), byteData, length);
                        }
#if __UNITY__
                    });
#endif
                    break;
                case "onReadyToSendMetadata":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] == null) return;
                        var metadata1 = new Metadata((uint) AgoraJson.GetData<uint>(data, "uid"),
                            (uint) AgoraJson.GetData<uint>(data, "size"), byteData,
                            (long) AgoraJson.GetData<long>(data, "timeStampMs"));
                        EngineEventHandlerArr[1].OnReadyToSendMetadata(metadata1);
#if __UNITY__
                    });
#endif
                    break;
                case "onMetadataReceived":
#if __UNITY__
                    CallbackObjectArr[1]._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandlerArr[1] == null) return;
                        var metadata2 = new Metadata((uint) AgoraJson.GetData<uint>(data, "uid"),
                            (uint) AgoraJson.GetData<uint>(data, "size"), byteData,
                            (long) AgoraJson.GetData<long>(data, "timeStampMs"));
                        EngineEventHandlerArr[1].OnMetadataReceived(metadata2);
#if __UNITY__
                    });
#endif
                    break;
            }
        }
    }
}