using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMetadataObserver : IMetadataObserver
    {


        public bool GetMaxMetadataSize_be_trigger = false;

        public override int GetMaxMetadataSize()
        {
            GetMaxMetadataSize_be_trigger = true;
            return 1024;
        }

        public bool GetMaxMetadataSizePassed()
        {
            if (GetMaxMetadataSize_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnReadyToSendMetadata_be_trigger = false;
        public Metadata OnReadyToSendMetadata_metadata = null;
        public VIDEO_SOURCE_TYPE OnReadyToSendMetadata_source_type;

        public override bool OnReadyToSendMetadata(ref Metadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            OnReadyToSendMetadata_be_trigger = true;
            OnReadyToSendMetadata_metadata = metadata;
            OnReadyToSendMetadata_source_type = source_type;
            return true;
        }

        public bool OnReadyToSendMetadataPassed(Metadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            if (OnReadyToSendMetadata_be_trigger == false)
                return false;

            if (ParamsHelper.compareMetadata(OnReadyToSendMetadata_metadata, metadata) == false)
                return false;
            if (ParamsHelper.compareVIDEO_SOURCE_TYPE(OnReadyToSendMetadata_source_type, source_type) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnMetadataReceived_be_trigger = false;
        public Metadata OnMetadataReceived_metadata = null;

        public override void OnMetadataReceived(Metadata metadata)
        {
            OnMetadataReceived_be_trigger = true;
            OnMetadataReceived_metadata = metadata;
        }

        public bool OnMetadataReceivedPassed(Metadata metadata)
        {
            if (OnMetadataReceived_be_trigger == false)
                return false;

            if (ParamsHelper.compareMetadata(OnMetadataReceived_metadata, metadata) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
