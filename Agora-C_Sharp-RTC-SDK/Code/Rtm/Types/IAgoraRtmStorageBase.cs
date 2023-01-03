using System;
namespace Agora.Rtm
{
    public class MetadataOptions
    {

        public bool recordTs;

        public bool recordUserId;

        MetadataOptions()
        {
            recordTs = false;
            recordUserId = false;
           
        }
    };

    public class MetadataItem
    {

        public string key;
    
        public string value;
     
        public string authorUserId;
      
        public Int64 revision;
      
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
