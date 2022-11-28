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
/// <summary>
/// Destroys the specified video track.
/// </summary>
///
/// <returns>
/// 0: Success.< 0: Failure.
/// </returns>
///
        public virtual int GetMaxMetadataSize()
        {
            return 0;
        }

///
/// <summary>
/// Occurs when the SDK is ready to send metadata.
/// This callback is triggered when the SDK is ready to send metadata.
/// </summary>
///
/// <param name ="metadata">The metadata the user wants to send. See Metadata .</param>
/// <param name ="source_type">Video data type. See VIDEO_SOURCE_TYPE .</param>
///
/// <returns>
/// true: Send it.false: Do not send it.
/// </returns>
///
        public virtual bool OnReadyToSendMetadata(ref Metadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            return false;
        }

///
/// <summary>
/// Occurs when the local user receives the metadata.
/// </summary>
///
/// <param name ="metadata">The metadata received, see Metadata .</param>
///
        public virtual void OnMetadataReceived(Metadata metadata)
        {

        }
    }
}