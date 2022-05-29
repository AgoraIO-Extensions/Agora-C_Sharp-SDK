using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    internal static class MetadataObserverNative
    {
        internal static IMetadataObserver Observer;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_MaxMetadataSize_Native))]
#endif
        internal static int GetMaxMetadataSize()
        {
            return 0;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_ReadyToSendMetadata_Native))]
#endif
        internal static bool OnReadyToSendMetadata(IntPtr metadata, VIDEO_SOURCE_TYPE source_type)
        {
            return false;
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

            localMetaData.bufferPtr = metaData.buffer;
            localMetaData.uid = metaData.uid;
            localMetaData.size = metaData.size;
            localMetaData.timeStampMs = metaData.timeStampMs;

            Observer.OnMetadataReceived(localMetaData);
        }
    }
}