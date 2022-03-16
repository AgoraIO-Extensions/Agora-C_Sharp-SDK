//  AgoraRtcSpatialAudioEngine.cs
//
//  Created by YuGuo Chen on December 12, 2021.
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

   using IrisCloudSpatialAudioEnginePtr = IntPtr;
   using IrisLocalSpatialAudioEnginePtr = IntPtr;
   using IrisSpatialAudioEnginePtr = IntPtr;
   using IrisEventHandlerHandleNative = IntPtr;

   public sealed class AgoraRtcCloudSpatialAudioEngine : IAgoraRtcCloudSpatialAudioEngine
   {
       private bool _disposed = false;
       private static readonly string identifier = "AgoraRtcSpatialAudioEngine";


       private IrisCloudSpatialAudioEnginePtr _irisRtcCloudSpatialAudioEngine;

       private CharAssistant _result;

       private IrisEventHandlerHandleNative _irisEngineEventHandlerHandleNative;
       private IrisCEventHandler _irisCEventHandler;
       private IrisEventHandlerHandleNative _irisCEngineEventHandlerNative;
        
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
       private AgoraCallbackObject _callbackObject;
#endif

       internal AgoraRtcCloudSpatialAudioEngine(IrisCloudSpatialAudioEnginePtr irisCloudSpatialAudioEngine)
       {
           _result = new CharAssistant();
           _irisRtcCloudSpatialAudioEngine = irisCloudSpatialAudioEngine;
       }

       ~AgoraRtcCloudSpatialAudioEngine()
       {
           Dispose(false);
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
           var param = new { };

           AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine,
           ApiTypeCloudSpatialAudio.kCloudSpatialAudioRelease,
           JsonMapper.ToJson(param), out _result);

           // AgoraRtcNative.DestroyIrisRtcEngine(_irisRtcSpatialAudioEngine);
           _irisRtcCloudSpatialAudioEngine = IntPtr.Zero;
           _result = new CharAssistant();
       }

       public override void Dispose()
       {
           Dispose(true);
           GC.SuppressFinalize(this);
       }

       public override void InitEventHandler(IAgoraRtcCloudSpatialAudioEngineEventHandler engineEventHandler)
       {
           if (_irisEngineEventHandlerHandleNative == IntPtr.Zero)
           {
               _irisCEventHandler = new IrisCEventHandler
               {
                   OnEvent = RtcCloudSpatialAudioEngineEventHandlerNative.OnEvent,
                   OnEventWithBuffer = RtcCloudSpatialAudioEngineEventHandlerNative.OnEventWithBuffer
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
                   AgoraRtcNative.SetIrisCloudAudioEngineEventHandler(_irisRtcCloudSpatialAudioEngine, _irisCEngineEventHandlerNative);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
               _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
               RtcCloudSpatialAudioEngineEventHandlerNative.CallbackObject = _callbackObject;
#endif
           }

           RtcCloudSpatialAudioEngineEventHandlerNative.CloudSpatialAudioEngineEventHandler = engineEventHandler;
       }

       private void ReleaseEventHandler()
       {
           RtcCloudSpatialAudioEngineEventHandlerNative.CloudSpatialAudioEngineEventHandler = null;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
           RtcCloudSpatialAudioEngineEventHandlerNative.CallbackObject = null;
           if (_callbackObject != null) _callbackObject.Release();
           _callbackObject = null;
#endif
           AgoraRtcNative.UnsetIrisCloudAudioEngineEventHandler(_irisRtcCloudSpatialAudioEngine, _irisEngineEventHandlerHandleNative);
           Marshal.FreeHGlobal(_irisCEngineEventHandlerNative);
           _irisEngineEventHandlerHandleNative = IntPtr.Zero;
       }

       public override int SetMaxAudioRecvCount(int maxCount)
       {
           var param = new
           {
               maxCount
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioSetMaxAudioRecvCount,
               JsonMapper.ToJson(param), out _result);
       }

       public override int SetAudioRecvRange(float range)
       {
           var param = new
           {
               range
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioSetAudioRecvRange,
               JsonMapper.ToJson(param), out _result);
       }

       public override int SetDistanceUnit(float unit)
       {
           var param = new
           {
               unit
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioSetDistanceUnit,
               JsonMapper.ToJson(param), out _result);
       }

       public override int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
       {
           var param = new
           {
               position,
               axisForward,
               axisRight,
               axisUp
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioUpdateSelfPosition,
               JsonMapper.ToJson(param), out _result);
       }

       public override int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
       {
           var param = new
           {
               position,
               axisForward,
               axisRight,
               axisUp,
               connection
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioUpdateSelfPositionEx,
               JsonMapper.ToJson(param), out _result);
       }

       public override int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
       {
           RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);
           var param = new
           {
               playerId,
               positionInfo
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioUpdatePlayerPositionInfo,
               JsonMapper.ToJson(param), out _result);
       }

       public override int SetParameters(string @params)
       {
           var param = new
           {
               @params
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioSetParameters,
               JsonMapper.ToJson(param), out _result);
       }

       public override int MuteLocalAudioStream(bool mute)
       {
           var param = new
           {
               mute
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioMuteLocalAudioStream,
               JsonMapper.ToJson(param), out _result);
       }

       public override int MuteAllRemoteAudioStreams(bool mute)
       {
           var param = new
           {
               mute
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioMuteAllRemoteAudioStreams,
               JsonMapper.ToJson(param), out _result);
       }

       public override int Initialize(CloudSpatialAudioConfig config)
       {
           var param = new
           {
               config
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioInitialze,
               JsonMapper.ToJson(param), out _result);
       }

       public override int EnableSpatializer(bool enable, bool applyToTeam)
       {
           var param = new
           {
               enable,
               applyToTeam
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioEnableSpatializer,
               JsonMapper.ToJson(param), out _result);
       }

       public override int SetTeamId(int teamId)
       {
           var param = new
           {
               teamId
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioSetTeamId,
               JsonMapper.ToJson(param), out _result);
       }

       public override int SetAudioRangeMode(RANGE_AUDIO_MODE_TYPE rangeMode)
       {
           var param = new
           {
               rangeMode
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioSetAudioRangeMode,
               JsonMapper.ToJson(param), out _result);
       }

       public override int EnterRoom(string token, string roomName, uint uid)
       {
           var param = new
           {
               token,
               roomName,
               uid
           };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioEnterRoom,
               JsonMapper.ToJson(param), out _result);
       }

       public override int ExitRoom()
       {
           var param = new { };
           return AgoraRtcNative.CallIrisCloudSpatialAudioApi(_irisRtcCloudSpatialAudioEngine, 
               ApiTypeCloudSpatialAudio.kCloudSpatialAudioExitRoom,
               JsonMapper.ToJson(param), out _result);
       }

       public override int GetTeammates(ref uint[] uids, int[] userCount)
       {
           return 0;
       }
   }

   public sealed class AgoraRtcSpatialAudioEngine : IAgoraRtcSpatialAudioEngine
   {
       private IrisSpatialAudioEnginePtr _irisRtcSpatialAudioEngine;
       private CharAssistant _result;
       private bool _disposed = false;
        
       internal AgoraRtcSpatialAudioEngine(IrisSpatialAudioEnginePtr irisSpatialAudioEngine)
       {
           _result = new CharAssistant();
           _irisRtcSpatialAudioEngine = irisSpatialAudioEngine;
           Initialize();
       }
        
       ~AgoraRtcSpatialAudioEngine()
       {
           _irisRtcSpatialAudioEngine = IntPtr.Zero;
           _result = new CharAssistant();
       }
        
       public override void Dispose()
       {
           if (!_disposed)
           {
               Release();
               _disposed = true;
           }
           
           _irisRtcSpatialAudioEngine = IntPtr.Zero;
           _result = new CharAssistant();
           GC.SuppressFinalize(this);
       }

       public override int SetMaxAudioRecvCount(int maxCount)
       {
           var param = new
           {
               maxCount
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioSetMaxAudioRecvCount,
               JsonMapper.ToJson(param), out _result);
       }

       public override int SetAudioRecvRange(float range)
       {
           var param = new
           {
               range
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioSetAudioRecvRange,
               JsonMapper.ToJson(param), out _result);
       }

       public override int SetDistanceUnit(float unit)
       {
           var param = new
           {
               unit
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioSetDistanceUnit,
               JsonMapper.ToJson(param), out _result);
       }

       public override int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
       {
           var param = new
           {
               position,
               axisForward,
               axisRight,
               axisUp
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioUpdateSelfPosition,
               JsonMapper.ToJson(param), out _result);
       }

       public override int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
       {
           var param = new
           {
               position,
               axisForward,
               axisRight,
               axisUp,
               connection
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioUpdateSelfPositionEx,
               JsonMapper.ToJson(param), out _result);
       }

       public override int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
       {
           RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);
           var param = new
           {
               playerId,
               positionInfo
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioUpdatePlayerPositionInfo,
               JsonMapper.ToJson(param), out _result);
       }

       public override int SetParameters(string @params)
       {
           var param = new
           {
               @params
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioSetParameters,
               JsonMapper.ToJson(param), out _result);
       }

       public override int MuteLocalAudioStream(bool mute)
       {
           var param = new
           {
               mute
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioMuteLocalAudioStream,
               JsonMapper.ToJson(param), out _result);
       }

       public override int MuteAllRemoteAudioStreams(bool mute)
       {
           var param = new
           {
               mute
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioMuteAllRemoteAudioStreams,
               JsonMapper.ToJson(param), out _result);
       }

       public override int UpdateRemotePosition(uint uid, float[] position, float[] forward)
       {
           RemoteVoicePositionInfo posInfo = new RemoteVoicePositionInfo(position, forward);
           var param = new
           {
               uid,
               posInfo
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioUpdateRemotePosition,
               JsonMapper.ToJson(param), out _result);
       }

       public override int UpdateRemotePositionEx(uint uid, float[] position, float[] forward, RtcConnection connection)
       {
           RemoteVoicePositionInfo posInfo = new RemoteVoicePositionInfo(position, forward);
           var param = new
           {
               uid,
               posInfo,
               connection
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioUpdateRemotePositionEx,
               JsonMapper.ToJson(param), out _result);
       }

       public override int RemoveRemotePosition(uint uid)
       {
           var param = new
           {
               uid
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioRemoveRemotePosition,
               JsonMapper.ToJson(param), out _result);
       }

       public override int RemoveRemotePositionEx(uint uid, RtcConnection connection)
       {
           var param = new
           {
               uid,
               connection
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioRemoveRemotePositionEx,
               JsonMapper.ToJson(param), out _result);
       }

       public override int ClearRemotePositions()
       {
           var param = new { };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioClearRemotePositions,
               JsonMapper.ToJson(param), out _result);
       }

       public override int ClearRemotePositionsEx(RtcConnection connection)
       {
           var param = new
           {
               connection
           };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioClearRemotePositionsEx,
               JsonMapper.ToJson(param), out _result);
       }

       private int Initialize()
       {
           var param = new { };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioInitialize,
               JsonMapper.ToJson(param), out _result);
       }

       private int Release()
       {
           var param = new { };
           return AgoraRtcNative.CallIrisLocalSpatialAudioApi(_irisRtcSpatialAudioEngine, 
               ApiTypeLocalSpatialAudio.kLocalSpatialAudioRelease,
               JsonMapper.ToJson(param), out _result);
       }
   }

   internal static class RtcCloudSpatialAudioEngineEventHandlerNative
   {
       internal static IAgoraRtcCloudSpatialAudioEngineEventHandler CloudSpatialAudioEngineEventHandler = null;
       internal static AgoraCallbackObject CallbackObject = null;

       [MonoPInvokeCallback(typeof(Func_Event_Native))]
       internal static void OnEvent(string @event, string data)
       {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
           if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
           switch(@event)
           {
               case "onTokenWillExpire":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                   CallbackObject._CallbackQueue.EnQueue(() =>
                   {
#endif
                       if (CloudSpatialAudioEngineEventHandler != null)
                       {
                           CloudSpatialAudioEngineEventHandler.OnTokenWillExpire();
                       }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                   });
#endif
                   break;
               case "onConnectionStateChange":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                   CallbackObject._CallbackQueue.EnQueue(() =>
                   {
#endif
                       if (CloudSpatialAudioEngineEventHandler != null)
                       {
                           CloudSpatialAudioEngineEventHandler.OnConnectionStateChange(
                               (SAE_CONNECTION_STATE_TYPE) AgoraJson.GetData<int>(data, "state"),
                               (SAE_CONNECTION_CHANGED_REASON_TYPE) AgoraJson.GetData<int>(data, "reason")
                           );
                       }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                   });
#endif
                   break;
               case "onTeammateLeft":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                   CallbackObject._CallbackQueue.EnQueue(() =>
                   {
#endif
                       if (CloudSpatialAudioEngineEventHandler != null)
                       {
                           CloudSpatialAudioEngineEventHandler.OnTeammateLeft(
                               (uint) AgoraJson.GetData<uint>(data, "uid")
                           );
                       }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                   });
#endif
                   break;
               case "onTeammateJoined":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                   CallbackObject._CallbackQueue.EnQueue(() =>
                   {
#endif
                       if (CloudSpatialAudioEngineEventHandler != null)
                       {
                           CloudSpatialAudioEngineEventHandler.OnTeammateJoined(
                               (uint) AgoraJson.GetData<uint>(data, "uid")
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
