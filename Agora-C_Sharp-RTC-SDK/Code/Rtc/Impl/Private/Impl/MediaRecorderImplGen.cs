#region Generated by `terra/node/src/rtc/impl/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

#define AGORA_RTC
#define AGORA_RTM
using System;
using view_t = System.UInt64;

namespace Agora.Rtc
{
    public partial class MediaRecorderImpl
    {

        public int StartRecording(string nativeHandle, MediaRecorderConfiguration config)
        {
            _param.Clear();
            _param.Add("nativeHandle", nativeHandle);
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIARECORDER_STARTRECORDING_94480b3,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");


            return result;
        }

        public int StopRecording(string nativeHandle)
        {
            _param.Clear();
            _param.Add("nativeHandle", nativeHandle);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIARECORDER_STOPRECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");


            return result;
        }

    }
}