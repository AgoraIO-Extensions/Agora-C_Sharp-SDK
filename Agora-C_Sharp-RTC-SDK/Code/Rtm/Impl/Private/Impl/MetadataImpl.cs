//using System;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
//using AOT;
//#endif


//namespace Agora.Rtm
//{
//    using IrisApiRtmEnginePtr = IntPtr;

//    internal class MetadataImpl
//    {
//        private bool _disposed = false;
//        private IrisApiRtmEnginePtr _irisApiRtmEngine;
//        private IrisCApiParam _apiParam;
//        private Dictionary<string, System.Object> _param = new Dictionary<string, System.Object>();

//        internal MetadataImpl(IrisApiRtmEnginePtr irisApiRtmEngine)
//        {
//            _apiParam = new IrisCApiParam();
//            _irisApiRtmEngine = irisApiRtmEngine;
//        }

//        ~MetadataImpl()
//        {
//            Dispose(false);
//        }

//        private void Dispose(bool disposing)
//        {
//            if (_disposed) return;

//            if (disposing)
//            {
//            }

//            _irisApiRtmEngine = IntPtr.Zero;
//            _apiParam = new IrisCApiParam();

//            _disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        public void SetMajorRevision(IntPtr metadata, Int64 revision)
//        {
//            _param.Clear();
//            _param.Add("metadata", (UInt64)metadata);
//            _param.Add("revision", revision);

//            var json = Agora.Rtc.AgoraJson.ToJson(_param);
//            IntPtr[] arrayPtr = new IntPtr[] { metadata };

//            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_METADATA_SETMAJORREVISION,
//                json, (UInt32)json.Length,
//                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
//                ref _apiParam);
//            if (nRet != 0)
//            {
//                Agora.Rtc.AgoraLog.LogError("MetadataImpl SetMajorRevision failed: " + nRet);
//            }
//        }

//        public void SetMetadataItem(IntPtr metadata, MetadataItem item)
//        {
//            _param.Clear();
//            _param.Add("metadata", (UInt64)metadata);
//            _param.Add("item", item);

//            var json = Agora.Rtc.AgoraJson.ToJson(_param);
//            IntPtr[] arrayPtr = new IntPtr[] { metadata };

//            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_METADATA_SETMETADATAITEM,
//                json, (UInt32)json.Length,
//                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
//                ref _apiParam);
//            if (nRet != 0)
//            {
//                Agora.Rtc.AgoraLog.LogError("MetadataImpl SetMetadataItem failed: " + nRet);
//            }
//        }

//        public void GetMetadataItems(IntPtr metadata, ref MetadataItem[] items, ref UInt64 size)
//        {
//            _param.Clear();
//            _param.Add("metadata", (UInt64)metadata);
//            _param.Add("items", items);
//            _param.Add("size", size);

//            var json = Agora.Rtc.AgoraJson.ToJson(_param);
//            IntPtr[] arrayPtr = new IntPtr[] { metadata };

//            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_METADATA_GETMETADATAITEMS,
//                json, (UInt32)json.Length,
//                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
//                ref _apiParam);

//            if (nRet != 0)
//            {
//                Agora.Rtc.AgoraLog.LogError("MetadataImpl GetMetadataItems failed: " + nRet);
//                items = new MetadataItem[0];
//                size = 0;
//            }
//            else
//            {
//                items = Agora.Rtc.AgoraJson.JsonToStructArray<MetadataItem>(_apiParam.Result, "items");
//                size = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "size");
//            }
//        }

//        public void ClearMetadata(IntPtr metadata)
//        {
//            _param.Clear();
//            _param.Add("metadata", (UInt64)metadata);

//            var json = Agora.Rtc.AgoraJson.ToJson(_param);
//            IntPtr[] arrayPtr = new IntPtr[] { metadata };

//            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_METADATA_CLEARMETADATA,
//                json, (UInt32)json.Length,
//                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
//                ref _apiParam);
//            if (nRet != 0)
//            {
//                Agora.Rtc.AgoraLog.LogError("MetadataImpl ClearMetadata failed: " + nRet);
//            }
//        }

//        public void Release(IntPtr metadata)
//        {
//            _param.Clear();
//            _param.Add("metadata", (UInt64)metadata);

//            var json = Agora.Rtc.AgoraJson.ToJson(_param);
//            IntPtr[] arrayPtr = new IntPtr[] { metadata };

//            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_METADATA_RELEASE,
//                json, (UInt32)json.Length,
//                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
//                ref _apiParam);
//            if (nRet != 0)
//            {
//                Agora.Rtc.AgoraLog.LogError("MetadataImpl Release failed: " + nRet);
//            }
//        }
//    }
//}
