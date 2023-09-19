namespace Agora.Rtc
{
    public abstract class IMetadataObserver
    {
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
        public virtual int GetMaxMetadataSize()
        {
            return 0;
        }
#endif
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
        public virtual bool OnReadyToSendMetadata(ref Metadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            return false;
        }
#endif

        public virtual void OnMetadataReceived(Metadata metadata)
        {
        }
    }
}