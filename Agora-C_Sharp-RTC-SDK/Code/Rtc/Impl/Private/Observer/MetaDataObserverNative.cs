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
        private static IMetadataObserver metadataObserver;

        internal static void SetMetadataObserver(IMetadataObserver observer)
        {
            lock (observerLock)
            {
                metadataObserver = observer;
            }
        }


        //internal class IrisMetadata
        //{
        //    public uint uid;
        //    public uint size;
        //    public UInt64 buffer;
        //    public long timeStampMs;

        //    public void GenerateMetadata(ref Metadata data)
        //    {
        //        data.uid = uid;
        //        data.size = size;
        //        data.buffer = (IntPtr)buffer;
        //        data.timeStampMs = timeStampMs;
        //    }

        //    public void CopyFromMetadata(ref Metadata data)
        //    {
        //        uid = data.uid;
        //        size = data.size;
        //        buffer = (UInt64)data.buffer;
        //        timeStampMs = data.timeStampMs;
        //    }

        //}

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        //        [MonoPInvokeCallback(typeof(Func_MaxMetadataSize_Native))]
        //#endif
        //        internal static int GetMaxMetadataSize()
        //        {
        //            if (MetadataObserver == null) return 0;
        //            return MetadataObserver.GetMaxMetadataSize();
        //        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));

                if (metadataObserver == null)
                {
                    CreateDefaultReturn(ref eventParam, param);
                    return;
                }

                var @event = eventParam.@event;
                var data = eventParam.data;
                var buffer = eventParam.buffer;
                var length = eventParam.length;
                var buffer_count = eventParam.buffer_count;

                switch (@event)
                {
                    case "MetadataObserver_getMaxMetadataSize":
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
                    case "MetadataObserver_onReadyToSendMetadata":
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
                    case "MetadataObserver_onMetadataReceived":
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

        private static void CreateDefaultReturn(ref IrisCEventParam eventParam, IntPtr param)
        {
            var @event = eventParam.@event;
            switch (@event)
            {
                case "MetadataObserver_getMaxMetadataSize":
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
                case "MetadataObserver_onMetadataReceived":
                    break;
                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }





        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_ReadyToSendMetadata_Native))]
        //#endif
        //            internal static bool OnReadyToSendMetadata(ref IrisMetadata metadata, VIDEO_SOURCE_TYPE source_type)
        //            {
        //                if (MetadataObserver == null) return false;

        //                var localMetaData = new Metadata();
        //                localMetaData.buffer = metadata.buffer;
        //                localMetaData.size = metadata.size;
        //                localMetaData.uid = metadata.uid;
        //                localMetaData.timeStampMs = metadata.timeStampMs;

        //                var ret = MetadataObserver.OnReadyToSendMetadata(ref localMetaData, source_type);

        //                metadata.buffer = localMetaData.buffer;
        //                metadata.uid = localMetaData.uid;
        //                metadata.size = localMetaData.size;
        //                metadata.timeStampMs = localMetaData.timeStampMs;

        //                return ret;
        //            }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //            [MonoPInvokeCallback(typeof(Func_MetadataReceived_Native))]
        //#endif
        //            internal static void OnMetadataReceived(IntPtr metadata)
        //            {
        //                if (MetadataObserver == null) return;

        //                var metaData = (IrisMetadata)(Marshal.PtrToStructure(metadata, typeof(IrisMetadata)) ??
        //                                                        new IrisMetadata());
        //                var localMetaData = new Metadata();

        //                localMetaData.buffer = metaData.buffer;
        //                localMetaData.uid = metaData.uid;
        //                localMetaData.size = metaData.size;
        //                localMetaData.timeStampMs = metaData.timeStampMs;

        //                MetadataObserver.OnMetadataReceived(localMetaData);
        //            }
    }
}