using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
using UnityEngine;
#endif

namespace Agora.Rtc
{
    internal static partial class RtcEngineEventHandlerNative
    {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
        private static System.Object observerLock = new System.Object();
#endif
        private static IRtcEngineEventHandler rtcEngineEventHandler = null;

        internal static void SetEventHandler(IRtcEngineEventHandler handler)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            lock (observerLock)
            {
#endif
                rtcEngineEventHandler = handler;
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            }
#endif
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject = null;

        /// <summary>
        /// Update connection info for all TextureManager instances matching the sourceType
        /// This is called from OnLocalVideoStats callback to ensure correct uid/channelId
        /// </summary>

#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            lock (observerLock)
            {
#endif
                if (rtcEngineEventHandler == null)
                    return;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                if (CallbackObject == null || CallbackObject._CallbackQueue == null)
                    return;
#endif

                IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));

                string @event = eventParam.@event;
                string data = eventParam.data;

                LitJson.JsonData jsonData = null;
                if (data != null)
                {
                    jsonData = AgoraJson.ToObject(data);
                }

                switch (@event)
                {
                    case AgoraApiType.IRTCENGINEEVENTHANDLER_ONSTREAMMESSAGE_99898cb:
                        {
                            var byteLength = (uint)AgoraJson.GetData<uint>(jsonData, "length");
                            var bufferPtr = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "data");
                            var byteData = new byte[byteLength];
                            if (byteLength != 0)
                            {
                                Marshal.Copy(bufferPtr, byteData, 0, (int)byteLength);
                            }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            CallbackObject._CallbackQueue.EnQueue(() =>
                            {
#endif
                            if (rtcEngineEventHandler == null)
                                return;
                            ((IRtcEngineEventHandler)rtcEngineEventHandler).OnStreamMessage(
                                AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                                (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                                (int)AgoraJson.GetData<int>(jsonData, "streamId"),
                                byteData,
                                byteLength,
                                (UInt64)AgoraJson.GetData<UInt64>(jsonData, "sentTs"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            });
#endif
                            break;
                        }

                    case AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOMETADATARECEIVED_0d4eb96:
                        {
                            var metadataLength = (uint)AgoraJson.GetData<uint>(jsonData, "length");
                            var metadataPtr = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "metadata");
                            var metadata = new byte[metadataLength];
                            if (metadataLength != 0)
                            {
                                Marshal.Copy(metadataPtr, metadata, 0, (int)metadataLength);
                            }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            CallbackObject._CallbackQueue.EnQueue(() =>
                            {
#endif
                            if (rtcEngineEventHandler == null) return;
                            rtcEngineEventHandler.OnAudioMetadataReceived(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                            metadata,
                            metadataLength
                            );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            });
#endif
                            break;
                        }

                    case AgoraApiType.IRTCENGINEEVENTHANDLER_ONLOCALVIDEOSTATS_0cebfd7:
                        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            CallbackObject._CallbackQueue.EnQueue(() =>
                            {
#endif
                            // Extract connection info
                            var connection = (RtcConnection)AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection");
                            var sourceType = (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "sourceType");

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            if(AgoraRenderTrackerMgr.Instance != null)
                            {
                                AgoraRenderTrackerMgr.Instance.MarkLocalVideoInfo(connection, new LocalVideoMark(sourceType, 0));
                            }   
#endif
                            if (rtcEngineEventHandler == null) return;
                            rtcEngineEventHandler.OnLocalVideoStats(
                            connection,
                            sourceType,
                            (LocalVideoStats)AgoraJson.JsonToStruct<LocalVideoStats>(jsonData, "stats")
                            );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            });
#endif
                            break;
                        }
                    case AgoraApiType.IRTCENGINEEVENTHANDLER_ONJOINCHANNELSUCCESS_263e4cd:
                        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            CallbackObject._CallbackQueue.EnQueue(() => 
                            {
#endif
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            if(AgoraRenderTrackerMgr.Instance != null)
                            {
                            AgoraRenderTrackerMgr.Instance.AddRtcConnection(
                            (RtcConnection)AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"));
                            }
#endif
                            if (rtcEngineEventHandler == null) return;
                            rtcEngineEventHandler.OnJoinChannelSuccess(
                            (RtcConnection)AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                            );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            });
#endif
                            break;
                        }
                    case AgoraApiType.IRTCENGINEEVENTHANDLER_ONLEAVECHANNEL_c8e730d:
                        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            CallbackObject._CallbackQueue.EnQueue(() => 
                            {
#endif
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            if(AgoraRenderTrackerMgr.Instance != null)
                            {
                                AgoraRenderTrackerMgr.Instance.RemoveRtcConnection(
                                (RtcConnection)AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"));
                            }
#endif
                            if (rtcEngineEventHandler == null) return;
                            rtcEngineEventHandler.OnLeaveChannel(
                            (RtcConnection)AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (RtcStats)AgoraJson.JsonToStruct<RtcStats>(jsonData, "stats")
                            );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            });
#endif
                            break;
                        }
                    default:
                        {
                            OnEventGen(ref eventParam, jsonData, @event);
                            break;
                        }
                }
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            }
#endif
        }
    }
}
