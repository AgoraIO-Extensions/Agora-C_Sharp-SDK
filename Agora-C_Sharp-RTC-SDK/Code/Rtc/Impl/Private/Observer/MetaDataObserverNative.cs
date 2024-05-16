using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class MetadataObserverNative
    {

        private static Object observerLock = new Object();
        private static IMetadataObserver metadataObserver;

        internal static void SetMetadataObserver(IMetadataObserver observer)
        {
            lock (observerLock)
            {
                metadataObserver = observer;
            }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
                    case AgoraEventType.EVENT_METADATAOBSERVER_GETMAXMETADATASIZE:
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
                    case AgoraEventType.EVENT_METADATAOBSERVER_ONREADYTOSENDMETADATA:
                        {
                            var jsonData = AgoraJson.ToObject(data);
                            Metadata metadata = AgoraJson.JsonToStruct<Metadata>(jsonData, "metadata");
                            VIDEO_SOURCE_TYPE source_type = (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "source_type");
                            bool result = metadataObserver.OnReadyToSendMetadata(ref metadata, source_type);
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
                    case AgoraEventType.EVENT_METADATAOBSERVER_ONMETADATARECEIVED:
                        {
                            var jsonData = AgoraJson.ToObject(data);
                            Metadata metadata = AgoraJson.JsonToStruct<Metadata>(jsonData, "metadata");
                            metadataObserver.OnMetadataReceived(metadata);
                        }
                        break;
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
                case AgoraEventType.EVENT_METADATAOBSERVER_GETMAXMETADATASIZE:
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
                case AgoraEventType.EVENT_METADATAOBSERVER_ONREADYTOSENDMETADATA:
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
                case AgoraEventType.EVENT_METADATAOBSERVER_ONMETADATARECEIVED:
                    break;
                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }
    }
}