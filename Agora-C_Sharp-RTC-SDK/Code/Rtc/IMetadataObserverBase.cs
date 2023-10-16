namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The metadata observer.
    /// </summary>
    ///
    public abstract class IMetadataObserverBase
    {
        ///
        /// <summary>
        /// Occurs when the SDK requests the maximum size of the metadata.
        /// 
        /// After successfully complete the registration by calling RegisterMediaMetadataObserver, the SDK triggers this callback once every video frame is sent. You need to specify the maximum size of the metadata in the return value of this callback.
        /// </summary>
        ///
        /// <returns>
        /// The maximum size of the buffer of the metadata that you want to use. The highest value is 1024 bytes. Ensure that you set the return value.
        /// </returns>
        ///
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)
        public virtual int GetMaxMetadataSize()
        {
            return 0;
        }
#endif

    }
}