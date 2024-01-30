namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The metadata observer.
    /// </summary>
    ///
    public abstract class IMetadataObserver
    {

        ///
        /// @ignore
        ///
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
        public virtual int GetMaxMetadataSize()
        {
            return 0;
        }
#endif

        ///
        /// @ignore
        ///
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
        public virtual bool OnReadyToSendMetadata(ref Metadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            return false;
        }
#endif

        ///
        /// <summary>
        /// Occurs when the local user receives the metadata.
        /// </summary>
        ///
        /// <param name="metadata"> The metadata received. See Metadata. </param>
        ///
        public virtual void OnMetadataReceived(Metadata metadata)
        {
        }
    }
}