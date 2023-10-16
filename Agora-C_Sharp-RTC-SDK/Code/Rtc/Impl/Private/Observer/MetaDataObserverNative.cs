#define AGORA_STRING_UID
#define AGORA_NUMBER_UID
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class MetadataObserverNative
    {

        private static Object observerLock = new Object();
        private static IMetadataObserverBase metadataObserver;

        internal static void SetMetadataObserver(IMetadataObserverBase observer)
        {
            lock (observerLock)
            {
                metadataObserver = observer;
            }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));

                if (metadataObserver == null)
                {
                    CreateDefaultReturn(ref eventParam, param);
                    return;
                }

                var @event = eventParam.@event;
                var data = eventParam.data;

                switch (@event)
                {
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
                    case "MetadataObserverBase_getMaxMetadataSize":
                        {
                            int result = metadataObserver.GetMaxMetadataSize();
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
#endif
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
#if AGORA_NUMBER_UID
                    case "MetadataObserver_onReadyToSendMetadata":
                        {
                            var jsonData = AgoraJson.ToObject(data);
                            Metadata metadata = AgoraJson.JsonToStruct<Metadata>(jsonData, "metadata");
                            VIDEO_SOURCE_TYPE source_type = (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "source_type");
                            bool result = ((IMetadataObserver)metadataObserver).OnReadyToSendMetadata(ref metadata, source_type);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            p.Add("metadata", metadata);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
#endif
#endif
#if AGORA_NUMBER_UID
                    case "MetadataObserver_onMetadataReceived":
                        {
                            var jsonData = AgoraJson.ToObject(data);
                            Metadata metadata = AgoraJson.JsonToStruct<Metadata>(jsonData, "metadata");
                            ((IMetadataObserver)metadataObserver).OnMetadataReceived(metadata);
                        }
                        break;
#endif
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
#if AGORA_STRING_UID
                    case "MetadataObserverS_onReadyToSendMetadata":
                        {
                            var jsonData = AgoraJson.ToObject(data);
                            MetadataS metadataS = AgoraJson.JsonToStruct<MetadataS>(jsonData, "metadataS");
                            VIDEO_SOURCE_TYPE source_type = (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "source_type");
                            bool result = ((IMetadataObserverS)metadataObserver).OnReadyToSendMetadata(ref metadataS, source_type);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            p.Add("metadataS", metadataS);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
#endif
#endif
#if AGORA_STRING_UID
                    case "MetadataObserverS_onMetadataReceived":
                        {
                            var jsonData = AgoraJson.ToObject(data);
                            MetadataS metadataS = AgoraJson.JsonToStruct<MetadataS>(jsonData, "metadataS");
                            ((IMetadataObserverS)metadataObserver).OnMetadataReceived(metadataS);
                        }
                        break;
#endif
                    default:
                        AgoraLog.LogError("unexpected event: " + @event);
                        break;

                }
            }
        }

        private static void CreateDefaultReturn(ref IrisRtcCEventParam eventParam, IntPtr param)
        {
            var @event = eventParam.@event;
            switch (@event)
            {
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
                case "MetadataObserverBase_getMaxMetadataSize":
                    {
                        int result = 0;
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
#endif
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
#if AGORA_NUMBER_UID
                case "MetadataObserver_onReadyToSendMetadata":
                    {
                        Metadata metadata = new Metadata();
                        bool result = false;
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        p.Add("metadata", metadata);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
#endif
#endif
#if AGORA_NUMBER_UID
                case "MetadataObserver_onMetadataReceived":
                    break;
#endif
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
#if AGORA_STRING_UID
                case "MetadataObserverS_onReadyToSendMetadata":
                    {
                        MetadataS metadataS = new MetadataS();
                        bool result = false;
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        p.Add("metadataS", metadataS);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
#endif
#endif
#if AGORA_STRING_UID
                case "MetadataObserverS_onMetadataReceived":
                    break;
#endif
                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }
    }
}