using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace Agora.Rtm
{
    using IrisApiRtmEnginePtr = IntPtr;

    internal class RtmStorageImpl
    {
        private bool _disposed = false;
        private IrisApiRtmEnginePtr _irisApiRtmEngine;
        private IrisCApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, System.Object>();


        internal RtmStorageImpl(IrisApiRtmEnginePtr irisApiRtmEngine)
        {
            _apiParam = new IrisCApiParam();
            this._irisApiRtmEngine = irisApiRtmEngine;
        }


        ~RtmStorageImpl()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
            }

            _irisApiRtmEngine = IntPtr.Zero;
            _apiParam = new IrisCApiParam();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public RtmMetadata CreateMetadata()
        //{
        //    _param.Clear();

        //    var json = Agora.Rtc.AgoraJson.ToJson(_param);

        //    var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMSTORAGE_CREATEMETADATA, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
        //    if (nRet == 0)
        //    {
        //        IntPtr metadataPtr = (IntPtr)(UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "result");
        //        if (metadataPtr != IntPtr.Zero)
        //        {
        //            Metadata metadata = new Metadata(this._metadataImpl, metadataPtr);
        //            return metadata;
        //        }
        //    }

        //    return null;
        //}

        public int SetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("data", data);
            _param.Add("options", options);
            _param.Add("lockName", lockName);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet =
                AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMSTORAGE_SETCHANNELMETADATA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("data", data);
            _param.Add("options", options);
            _param.Add("lockName", lockName);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet =
                AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMSTORAGE_UPDATECHANNELMETADATA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RemoveChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("data", data);
            _param.Add("options", options);
            _param.Add("lockName", lockName);

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet =
                AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMSTORAGE_REMOVECHANNELMETADATA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet =
                AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMSTORAGE_GETCHANNELMETADATA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("userId", userId);
            _param.Add("data", data);
            _param.Add("options", options);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet =
                AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMSTORAGE_SETUSERMETADATA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("userId", userId);
            _param.Add("data", data);
            _param.Add("options", options);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet =
                AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMSTORAGE_UPDATEUSERMETADATA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RemoveUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("userId", userId);
            _param.Add("data", data);
            _param.Add("options", options);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet =
                AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMSTORAGE_REMOVEUSERMETADATA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetUserMetadata(string userId, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("userId", userId);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet =
                AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMSTORAGE_GETUSERMETADATA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SubscribeUserMetadata(string userId)
        {
            _param.Clear();
            _param.Add("userId", userId);

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet =
                AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMSTORAGE_SUBSCRIBEUSERMETADATA, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UnsubscribeUserMetadata(string userId)
        {
            _param.Clear();
            _param.Add("userId", userId);

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMSTORAGE_UNSUBSCRIBEUSERMETADATA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


    }
}
