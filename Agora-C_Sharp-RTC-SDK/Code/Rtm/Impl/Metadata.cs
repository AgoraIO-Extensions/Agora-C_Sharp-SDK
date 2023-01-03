//using System;
//namespace Agora.Rtm
//{
//    public class Metadata : RtmMetadata
//    {
//        private bool _disposed = false;
//        private MetadataImpl _metadataImpl = null;
//        private IntPtr _metadataPtr = IntPtr.Zero;
//        private const int ErrorCode = -7;


//        internal Metadata(MetadataImpl impl, IntPtr metatdataPtr)
//        {
//            this._metadataImpl = impl;
//            this._metadataPtr = metatdataPtr;
//        }

//        ~Metadata()
//        {
//            Dispose(false);
//        }

//        private void Dispose(bool disposing)
//        {
//            if (_disposed) return;

//            if (disposing)
//            {
//            }
//            _metadataImpl = null;
//            _metadataPtr = IntPtr.Zero;
//            _disposed = true;
//        }

//        public override void Dispose()
//        {
//            if (_metadataImpl == null || _metadataPtr == IntPtr.Zero)
//            {
//                Agora.Rtc.AgoraLog.LogError("Medata Dispose failed: " + ErrorCode);
//                return;
//            }
//            _metadataImpl.Release(this._metadataPtr);
//            this.Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        internal IntPtr GetMedataPtr()
//        {
//            return this._metadataPtr;
//        }

//        public override void SetMajorRevision(Int64 revision)
//        {
//            if (_metadataImpl == null || _metadataPtr == IntPtr.Zero)
//            {
//                Agora.Rtc.AgoraLog.LogError("Medata Dispose failed: " + ErrorCode);
//                return;
//            }
//            this._metadataImpl.SetMajorRevision(this._metadataPtr, revision);
//        }

//        public override void SetMetadataItem(MetadataItem item)
//        {
//            if (_metadataImpl == null || _metadataPtr == IntPtr.Zero)
//            {
//                Agora.Rtc.AgoraLog.LogError("Medata Dispose failed: " + ErrorCode);
//                return;
//            }
//            this._metadataImpl.SetMetadataItem(this._metadataPtr, item);
//        }

//        public override void GetMetadataItems(ref MetadataItem[] items, ref UInt64 size)
//        {
//            if (_metadataImpl == null || _metadataPtr == IntPtr.Zero)
//            {
//                Agora.Rtc.AgoraLog.LogError("Medata Dispose failed: " + ErrorCode);
//                return;
//            }
//            this._metadataImpl.GetMetadataItems(this._metadataPtr, ref items, ref size);
//        }

//        public override void ClearMetadata()
//        {

//            if (_metadataImpl == null || _metadataPtr == IntPtr.Zero)
//            {
//                Agora.Rtc.AgoraLog.LogError("Medata Dispose failed: " + ErrorCode);
//                return;
//            }
//            this._metadataImpl.ClearMetadata(this._metadataPtr);

//        }
//    }
//}
