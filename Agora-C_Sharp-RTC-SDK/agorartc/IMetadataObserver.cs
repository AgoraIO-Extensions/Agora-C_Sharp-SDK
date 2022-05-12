using System;


namespace agora.rtc
{
    /** Definition of IMetadataObserver
    */
    public class IMetadataObserver
    {
        /** The metadata type.
        *
        * @note We only support video metadata for now.
        */
        public enum METADATA_TYPE
        {
            /** -1: (Not supported) Unknown.
             */
            UNKNOWN_METADATA = -1,
            /** 0: (Supported) Video metadata.
             */
            VIDEO_METADATA = 0,
        };

        /**
          * The maximum metadata size.
          */
        public enum MAX_METADATA_SIZE_TYPE
        {
            INVALID_METADATA_SIZE_IN_BYTE = -1,
            DEFAULT_METADATA_SIZE_IN_BYTE = 512,
            MAX_METADATA_SIZE_IN_BYTE = 1024
        };

        /** Metadata.
         */
        public struct Metadata
        {
            /** The User ID that sent the metadata.
             * For the receiver: the remote track User ID.
             * For the sender: ignore it.
             */
            uint uid;
            /** The metadata size.
             */
            uint size;
            /** The metadata buffer.
             */
            IntPtr buffer;
            /** The NTP timestamp (ms) that the metadata sends.
             *
             * @note If the metadata receiver is audience, this parameter does not work.
             */
            long timeStampMs;
        };

    
        /** Gets the maximum size of the metadata.
         *
         *
         * After calling the \ref agora::rtc::IRtcEngine::registerMediaMetadataObserver "registerMediaMetadataObserver" method,
         * the SDK triggers this callback to query the maximum size of your metadata.
         * You must specify the maximum size in the return value and then pass it to the SDK.
         *
         * @return The maximum size of your metadata. See #MAX_METADATA_SIZE_TYPE.
         */
        public virtual int getMaxMetadataSize()
        {
            return (int)MAX_METADATA_SIZE_TYPE.DEFAULT_METADATA_SIZE_IN_BYTE;
        }

        /** Occurs when the SDK is ready to receive and send metadata.

         @note Ensure that the size of the metadata does not exceed the value set in the \ref agora::rtc::IMetadataObserver::getMaxMetadataSize "getMaxMetadataSize" callback.

         @param metadata The Metadata to be sent.
         @return
         - true:  Send.
         - false: Do not send.
         */
        public virtual bool onReadyToSendMetadata(ref Metadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            return true;
        }

        /** Occurs when received the metadata.
        *
        * @param metadata The metadata received. See metadata.
        *
        * @note If the receiver is audience, the receiver cannot get the NTP timestamp (ms)
        * that the metadata sends.
        */
        public virtual void onMetadataReceived(ref Metadata metadata)
        {

        }
    }
}
