#define __UNITY__

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if __UNITY__
using AOT;
#endif

namespace agora.rtc
{
    internal static class MetadataObserver
    {
        internal static IMetadataObserver Observer;

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_MaxMetadataSize_Native))]
#endif
        internal static int GetMaxMetadataSize()
        {
            if (Observer.GetMaxMetadataSize == null) return;
            return Observer.GetMaxMetadataSize();
        }

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_ReadyToSendMetadata_Native))]
#endif
        internal static bool OnReadyToSendMetadata(IntPtr metadata, VIDEO_SOURCE_TYPE source_type)
        {
            if (Observer.OnReadyToSendMetadata == null) return;
            return Observer.OnReadyToSendMetadata(metadata, source_type);
        }

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_MetadataReceived_Native))]
#endif
        internal static void OnMetadataReceived(IntPtr metadata)
        {
            if (Observer.OnMetadataReceived == null) return;

            var metaData = (IrisMetadata) (Marshal.PtrToStructure(audioFramePtr, typeof(IrisMetadata)) ??
                                                    new IrisMetadata());
            var localMetaData = new Metadata();

            localMetaData.buffer = new byte[metaData.size];

            if (metaData.buffer != IntPtr.Zero)
                Marshal.Copy(metaData.buffer, localMetaData.buffer, 0, (int) metaData.size);
            localMetaData.uid = metaData.uid;
            localMetaData.size = metaData.size;
            localMetaData.timeStampMs = metaData.timeStampMs;

            return Observer.OnMetadataReceived(localMetaData);
        }
    }
}