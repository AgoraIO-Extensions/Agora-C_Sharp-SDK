using System;
namespace Agora.Rtm
{
    /**
    * Metadata options.
    */
    public class MetadataOptions
    {

        /**
        * Indicates whether or not to notify server update the modify timestamp of metadata
        */
        public bool recordTs;

        /**
        * Indicates whether or not to notify server update the modify user id of metadata
        */
        public bool recordUserId;

        public MetadataOptions()
        {
            recordTs = false;
            recordUserId = false;
           
        }
    };

    public class MetadataItem
    {
        /**
        * The key of the metadata item.
        */
        public string key;

        /**
        * The value of the metadata item.
         */
        public string value;

        /**
        * The User ID of the user who makes the latest update to the metadata item.
        */
        public string authorUserId;

        /**
        * The revision of the metadata item.
        */
        public Int64 revision;

        /**
        * The Timestamp when the metadata item was last updated.
        */
        public Int64 updateTs;

        public MetadataItem()
        {
            key = "";
            value = "";
            authorUserId = "";
            revision = -1;
            updateTs = 0;
        }

        public MetadataItem(string key, string value, Int64 revision = -1)
        {
            this.key = key;
            this.value = value;     
            this.revision = revision;
            this.authorUserId = "";
            this.updateTs = 0;
        }
    };

}
