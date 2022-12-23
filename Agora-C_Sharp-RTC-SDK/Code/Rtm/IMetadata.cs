using System;
namespace Agora.Rtm
{

    public abstract class IMetadata
    {
        public abstract void SetMajorRevision(Int64 revision);

        public abstract void SetMetadataItem(MetadataItem item);

        public abstract void GetMetadataItems(ref MetadataItem[] items, ref UInt64 size);

        public abstract void ClearMetadata();

        public abstract void Dispose();
    }
}
