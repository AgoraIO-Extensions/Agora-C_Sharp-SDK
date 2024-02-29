using System;
namespace Agora.Rtm
{
    ///
    /// <summary>
    /// Metadata options.
    /// </summary>
    ///
    public class MetadataOptions
    {

        ///
        /// <summary>
        /// Indicates whether to notify server update the modify timestamp of metadata
        /// </summary>
        ///
        public bool recordTs;

        ///
        /// <summary>
        /// Indicates whether to notify server update the modify user id of metadata
        /// </summary>
        ///
        public bool recordUserId;

        public MetadataOptions()
        {
            recordTs = false;
            recordUserId = false;
        }
    };

    public class MetadataItem
    {
        ///
        /// <summary>
        /// The key of the metadata item.
        /// </summary>
        ///
        public string key;

        ///
        /// <summary>
        /// The value of the metadata item.
        /// </summary>
        ///
        public string value;

        ///
        /// <summary>
        /// The User ID of the user who makes the latest update to the metadata item.
        /// </summary>
        ///
        public string authorUserId;

        ///
        /// <summary>
        /// The revision of the metadata item.
        /// </summary>
        ///
        public Int64 revision;

        ///
        /// <summary>
        /// The Timestamp when the metadata item was last updated.
        /// </summary>
        ///
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
