namespace Agora.Rtc
{
    public class IMetadataObserver
    {
        public virtual int GetMaxMetadataSize()
        {
            return 0;
        }

        public virtual bool OnReadyToSendMetadata(ref Metadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            return false;
        }

        public virtual void OnMetadataReceived(Metadata metadata)
        {

        }
    }
}
