using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class MetadataObserverNative
    {
        internal static IMetadataObserver Observer;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_MaxMetadataSize_Native))]
#endif
        internal static int GetMaxMetadataSize()
        {
            if (Observer == null) return 0;
            return Observer.GetMaxMetadataSize();
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_ReadyToSendMetadata_Native))]
#endif
        internal static bool OnReadyToSendMetadata(ref IrisMetadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            if (Observer == null) return false;

            var localMetaData = new Metadata();
            localMetaData.buffer = metadata.buffer;
            localMetaData.size = metadata.size;
            localMetaData.uid = metadata.uid;
            localMetaData.timeStampMs = metadata.timeStampMs;
               
            var ret = Observer.OnReadyToSendMetadata(ref localMetaData, source_type);

            metadata.buffer = localMetaData.buffer;
            metadata.uid = localMetaData.uid;
            metadata.size = localMetaData.size;
            metadata.timeStampMs = localMetaData.timeStampMs;

            return ret;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_MetadataReceived_Native))]
#endif
        internal static void OnMetadataReceived(IntPtr metadata)
        {
            if (Observer == null) return;

            var metaData = (IrisMetadata) (Marshal.PtrToStructure(metadata, typeof(IrisMetadata)) ??
                                                    new IrisMetadata());
            var localMetaData = new Metadata();

            localMetaData.buffer = metaData.buffer;
            localMetaData.uid = metaData.uid;
            localMetaData.size = metaData.size;
            localMetaData.timeStampMs = metaData.timeStampMs;

            Observer.OnMetadataReceived(localMetaData);
        }
    }
}