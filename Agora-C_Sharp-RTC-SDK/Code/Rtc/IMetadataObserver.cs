namespace Agora.Rtc
{
    /* class_imetadataobserver */
    public abstract class IMetadataObserver
    {
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
        /* callback_imetadataobserver_getmaxmetadatasize */
        public virtual int GetMaxMetadataSize()
        {
            return 0;
        }
#endif
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
        /* callback_imetadataobserver_onreadytosendmetadata */
        public virtual bool OnReadyToSendMetadata(ref Metadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            return false;
        }
#endif

        /* callback_imetadataobserver_onmetadatareceived */
        public virtual void OnMetadataReceived(Metadata metadata)
        {
        }
    }
}