using System;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
//    internal static class CloudSpatialAudioEngineEventHandlerNative
//    {
//        internal static ICloudSpatialAudioEventHandler CloudSpatialAudioEngineEventHandler = null;
//#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
//        internal static AgoraCallbackObject CallbackObject = null;
//#endif

//#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
//        [MonoPInvokeCallback(typeof(Func_Event_Native))]
//#endif
//        internal static void OnEvent(string @event, string data, IntPtr buffer, IntPtr length, uint buffer_count)
//        {
//            if (CloudSpatialAudioEngineEventHandler == null) return;

//#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
//            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
//            CallbackObject._CallbackQueue.EnQueue(() =>
//            {
//#endif
//                switch (@event)
//                {
//                    case "CloudSpatialAudioEventHandler_onTokenWillExpire":
//                        CloudSpatialAudioEngineEventHandler.OnTokenWillExpire();
//                        break;
//                    case "CloudSpatialAudioEventHandler_onConnectionStateChange":
//                        CloudSpatialAudioEngineEventHandler.OnConnectionStateChange(
//                            (SAE_CONNECTION_STATE_TYPE)AgoraJson.GetData<int>(data, "state"),
//                            (SAE_CONNECTION_CHANGED_REASON_TYPE)AgoraJson.GetData<int>(data, "reason")
//                        );
//                        break;
//                    case "CloudSpatialAudioEventHandler_onTeammateLeft":
//                        CloudSpatialAudioEngineEventHandler.OnTeammateLeft(
//                            (uint)AgoraJson.GetData<uint>(data, "uid")
//                        );
//                        break;
//                    case "CloudSpatialAudioEventHandler_onTeammateJoined":
//                        CloudSpatialAudioEngineEventHandler.OnTeammateJoined(
//                            (uint)AgoraJson.GetData<uint>(data, "uid")
//                        );
//                        break;
//                }
//#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
//            });
//#endif
//        }
//    }
}