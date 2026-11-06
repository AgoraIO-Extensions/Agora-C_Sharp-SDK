using System;

namespace Agora.Rtc
{
    public partial class RtcEngineImpl
    {
        // Iris copies each source to JSON and releases the native list before returning.
        public LoopbackRecordingSourceInfo[] GetLoopbackRecordingSources(LoopbackRecordingSourceOptions options)
        {
            if (options == null) throw new ArgumentNullException("options");
            _param.Clear();
            _param.Add("options", options);
            string json = AgoraJson.ToJson(_param);
            int ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.IRTCENGINE_GETLOOPBACKRECORDINGSOURCES_89105d0,
                json, (uint)System.Text.Encoding.UTF8.GetByteCount(json), IntPtr.Zero, 0, ref _apiParam);
            return ret == 0
                ? AgoraJson.JsonToStructArray<LoopbackRecordingSourceInfo>(_apiParam.Result, "result")
                : new LoopbackRecordingSourceInfo[0];
        }
    }
}
