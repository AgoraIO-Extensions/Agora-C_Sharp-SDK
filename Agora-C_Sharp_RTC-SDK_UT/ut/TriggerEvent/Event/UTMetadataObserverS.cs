using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMetadataObserverS : IMetadataObserverS
    {

        #region terra IMetadataObserverS

        public bool GetMaxMetadataSize_be_trigger = false;


        public override int GetMaxMetadataSize()
        {
            GetMaxMetadataSize_be_trigger = true;

            return 0;

        }

        public bool GetMaxMetadataSizePassed()
        {

            if (GetMaxMetadataSize_be_trigger == false)
                return false;



            return true;
        }

        /////////////////////////////////
        public bool OnReadyToSendMetadata_be_trigger = false;
        public MetadataS OnReadyToSendMetadata_metadataS;
        public VIDEO_SOURCE_TYPE OnReadyToSendMetadata_source_type;

        public override bool OnReadyToSendMetadata(ref MetadataS metadataS, VIDEO_SOURCE_TYPE source_type)
        {
            OnReadyToSendMetadata_be_trigger = true;
            OnReadyToSendMetadata_metadataS = metadataS;
            OnReadyToSendMetadata_source_type = source_type;
            return true;

        }

        public bool OnReadyToSendMetadataPassed(ref MetadataS metadataS, VIDEO_SOURCE_TYPE source_type)
        {

            if (OnReadyToSendMetadata_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<MetadataS>(OnReadyToSendMetadata_metadataS, metadataS) == false)
                return false;
            if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnReadyToSendMetadata_source_type, source_type) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnMetadataReceived_be_trigger = false;
        public Metadata OnMetadataReceived_metadataS;

        public override void OnMetadataReceived(Metadata metadataS)
        {
            OnMetadataReceived_be_trigger = true;
            OnMetadataReceived_metadataS = metadataS;

        }

        public bool OnMetadataReceivedPassed(Metadata metadataS)
        {

            if (OnMetadataReceived_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<Metadata>(OnMetadataReceived_metadataS, metadataS) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IMetadataObserverS
    }
}
