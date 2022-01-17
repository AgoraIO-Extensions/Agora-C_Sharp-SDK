//  AgoraFpaProxyService.cs
//
//  Created by YuGuo Chen on September 26, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.fpa
{
    using LitJson;

    using IrisFpaProxyServicePtr = IntPtr;
    using IrisEventHandlerHandleNative = IntPtr;

    public sealed class AgoraFpaProxyService : IAgoraFpaProxyService
    {
        private bool _disposed = false;
        private static AgoraFpaProxyService serviceInstance = null;
        private static readonly string identifier = "AgoraFpaProxyService";


        private IrisFpaProxyServicePtr _irisFpaProxyService;
        private CharAssistant _result;

        private IrisEventHandlerHandleNative _irisServiceEventHandlerHandleNative;
        private IrisCEventHandler _irisCEventHandler;
        private IrisEventHandlerHandleNative _irisCServiceEventHandlerNative;
        
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        private AgoraCallbackObject _callbackObject;
#endif

        private AgoraFpaProxyService()
        {
            _result = new CharAssistant();
            _irisFpaProxyService = AgoraFpaNative.CreateIrisFpaProxyService();
            SetParameters("{\"fpa:app_type\":2}");
        }

        private void Dispose(bool disposing, bool sync)
        {
            if (_disposed) return;

            if (disposing)
            {
                ReleaseEventHandler();
            }
            
            Release(sync);
            
            _disposed = true;
        }

        private void Release(bool sync = false)
        {
            AgoraFpaNative.DestroyIrisFpaProxyService(_irisFpaProxyService);
            _irisFpaProxyService = IntPtr.Zero;
            _result = new CharAssistant();
            
            serviceInstance = null;
        }

        internal IrisFpaProxyServicePtr GetNativeHandler()
        {
            return _irisFpaProxyService;
        }

        public static IAgoraFpaProxyService CreateAgoraFpaProxyService()
        {
            return serviceInstance ?? (serviceInstance = new AgoraFpaProxyService());
        }

        public static IAgoraFpaProxyService Get()
        {
            return serviceInstance;
        }

        public override void Dispose(bool sync = false)
        {
            Dispose(true, sync);
            GC.SuppressFinalize(this);
        }

        public override void InitEventHandler(IAgoraFpaProxyServiceEventHandler serviceEventHandler)
        {
            if (_irisServiceEventHandlerHandleNative == IntPtr.Zero)
            {
                _irisCEventHandler = new IrisCEventHandler
                {
                    OnEvent = FpaProxyServiceEventHandlerNative.OnEvent,
                    OnEventWithBuffer = FpaProxyServiceEventHandlerNative.OnEventWithBuffer
                };

                var cEventHandlerNativeLocal = new IrisCEventHandlerNative
                {
                    onEvent = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEvent),
                    onEventWithBuffer =
                        Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEventWithBuffer)
                };

                _irisCServiceEventHandlerNative = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
                Marshal.StructureToPtr(cEventHandlerNativeLocal, _irisCServiceEventHandlerNative, true);
                _irisServiceEventHandlerHandleNative =
                    AgoraFpaNative.SetIrisFpaProxyServiceEventHandler(_irisFpaProxyService, _irisCServiceEventHandlerNative);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
                FpaProxyServiceEventHandlerNative.CallbackObject = _callbackObject;
#endif
            }

            FpaProxyServiceEventHandlerNative.ServiceEventHandler = serviceEventHandler;
        }

        private void ReleaseEventHandler()
        {
            FpaProxyServiceEventHandlerNative.ServiceEventHandler = null;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            FpaProxyServiceEventHandlerNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif
            AgoraFpaNative.UnsetIrisFpaProxyServiceEventHandler(_irisFpaProxyService, _irisServiceEventHandlerHandleNative);
            Marshal.FreeHGlobal(_irisCServiceEventHandlerNative);
            _irisServiceEventHandlerHandleNative = IntPtr.Zero;
        }

        public override int Start(FpaProxyServiceConfig config)
        {
            var param = new 
            {
                config
            };
            return AgoraFpaNative.CallIrisFpaProxyServiceApi(_irisFpaProxyService, ApiTypeProxyService.KServiceStart, 
                JsonMapper.ToJson(param), out _result);
        }

        public override int Stop()
        {
            var param = new { };
            return AgoraFpaNative.CallIrisFpaProxyServiceApi(_irisFpaProxyService, ApiTypeProxyService.KServiceStop, 
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetHttpProxyPort(ref ushort port)
        {
            var param = new { };
            var ret = AgoraFpaNative.CallIrisFpaProxyServiceApi(_irisFpaProxyService, ApiTypeProxyService.KServiceGetHttpProxyPort, 
                JsonMapper.ToJson(param), out _result);
            if (_result.Result == null) return -99;
            port = Convert.ToUInt16(_result.Result);
            return ret;
        }

        public override int GetTransparentProxyPort(ref ushort proxy_port, FpaChainInfo info)
        {
            var param = new 
            {
                info
            };
            var ret = AgoraFpaNative.CallIrisFpaProxyServiceApi(_irisFpaProxyService, ApiTypeProxyService.KServiceGetTransparentProxyPort, 
                JsonMapper.ToJson(param), out _result);
            if (_result.Result == null) return -99;
            proxy_port = Convert.ToUInt16(_result.Result);
            return ret;
        }

        public override int SetParameters(string parameters)
        {
            var param = new 
            {
                parameters
            };
            return AgoraFpaNative.CallIrisFpaProxyServiceApi(_irisFpaProxyService, ApiTypeProxyService.KServiceSetParameters, 
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetOrUpdateHttpProxyChainConfig(FpaHttpProxyChainConfig config)
        {
            var param = new 
            {
                config
            };
            return AgoraFpaNative.CallIrisFpaProxyServiceApi(_irisFpaProxyService, ApiTypeProxyService.KServiceSetOrUpdateHttpProxyChainConfig, 
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetDiagnosisInfo(out FpaProxyServiceDiagnosisInfo info)
        {
            var param = new { };
            var ret = AgoraFpaNative.CallIrisFpaProxyServiceApi(_irisFpaProxyService, ApiTypeProxyService.KServiceGetDiagnosisInfo, 
                JsonMapper.ToJson(param), out _result);
            info = _result.Result.Length == 0 ? new FpaProxyServiceDiagnosisInfo() : AgoraJson.JsonToStruct<FpaProxyServiceDiagnosisInfo>(_result.Result);
            return ret; 
        }

        public override string GetAgoraFpaProxyServiceSdkVersion()
        {
            var param = new { };
            return AgoraFpaNative.CallIrisFpaProxyServiceApi(_irisFpaProxyService, ApiTypeProxyService.KServiceGetAgoraFpaProxyServiceSdkVersion, 
                JsonMapper.ToJson(param), out _result) != 0
            ? null
            : ((_result.Result.Length == 0) ? null : _result.Result);
        }

        public override string GetAgoraFpaProxyServiceSdkBuildInfo()
        {
            var param = new { };
            return AgoraFpaNative.CallIrisFpaProxyServiceApi(_irisFpaProxyService, ApiTypeProxyService.KServiceGetAgoraFpaProxyServiceSdkBuildInfo, 
                JsonMapper.ToJson(param), out _result) != 0
            ? null
            : ((_result.Result.Length == 0) ? null : _result.Result);
        }
      
        ~AgoraFpaProxyService()
        {
            Dispose(false, false);
        }
    }

    internal static class FpaProxyServiceEventHandlerNative
    {
        internal static IAgoraFpaProxyServiceEventHandler ServiceEventHandler = null;
        internal static AgoraCallbackObject CallbackObject = null;

        [MonoPInvokeCallback(typeof(Func_Event_Native))]
        internal static void OnEvent(string @event, string data)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
            switch(@event)
            {
                case "onAccelerationSuccess":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ServiceEventHandler != null)
                        {
                            ServiceEventHandler.OnAccelerationSuccess(
                                AgoraJson.JsonToStruct<FpaProxyConnectionInfo>(data, "info")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onConnected":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ServiceEventHandler != null)
                        {
                            ServiceEventHandler.OnConnected(
                                AgoraJson.JsonToStruct<FpaProxyConnectionInfo>(data, "info")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onDisconnectedAndFallback":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ServiceEventHandler != null)
                        {
                            ServiceEventHandler.OnDisconnectedAndFallback(
                                AgoraJson.JsonToStruct<FpaProxyConnectionInfo>(data, "info"),
                                (FPA_FAILED_REASON_CODE) AgoraJson.GetData<int>(data, "reason")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onConnectionFailed":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (ServiceEventHandler != null)
                        {
                            ServiceEventHandler.OnConnectionFailed(
                                AgoraJson.JsonToStruct<FpaProxyConnectionInfo>(data, "info"),
                                (FPA_FAILED_REASON_CODE) AgoraJson.GetData<int>(data, "reason")
                            );
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
        }
        
    }
}