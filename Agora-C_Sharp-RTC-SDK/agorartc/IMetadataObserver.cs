using System;

namespace agora.rtc
{
    public class IMetadataObserver
    {
        public virtual int GetMaxMetadataSize()
        {
            return (int)MAX_METADATA_SIZE_TYPE.DEFAULT_METADATA_SIZE_IN_BYTE;
        }

        public virtual bool OnReadyToSendMetadata(IntPtr metadata, VIDEO_SOURCE_TYPE source_type)
        {
            return true;
        }

        public virtual void OnMetadataReceived(IntPtr metadataPtr, Metadata metadata)
        {

        }
    }
}
