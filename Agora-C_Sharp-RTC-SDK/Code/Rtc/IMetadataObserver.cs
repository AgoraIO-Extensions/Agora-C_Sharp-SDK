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
        /// <summary>
        /// Occurs when the SDK is ready to send metadata.
        /// 
        /// This callback is triggered when the SDK is ready to send metadata.
        /// </summary>
        ///
        /// <param name="source_type"> Video data type. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <param name="metadata"> The metadata that the user wants to send. See Metadata. </param>
        ///
        /// <returns>
        /// true : Send the video frame. false : Do not send the video frame.
        /// </returns>
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