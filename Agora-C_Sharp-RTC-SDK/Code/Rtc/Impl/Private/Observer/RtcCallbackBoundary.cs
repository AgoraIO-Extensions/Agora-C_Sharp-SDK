using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Agora.Rtc
{
    // Iris event JSON is UTF-8; keep all standalone reverse-P/Invoke failures inside managed code.
    internal static class RtcCallbackBoundary
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct NativeEvent
        {
            internal IntPtr name, data;
            internal uint dataSize;
            internal IntPtr result, buffer, length;
            internal uint bufferCount;
        }
        private static NativeEvent Header(IntPtr pointer)
        {
            if (pointer == IntPtr.Zero) throw new ArgumentNullException("pointer");
            return (NativeEvent)Marshal.PtrToStructure(pointer, typeof(NativeEvent));
        }
        internal static IrisRtcCEventParam ReadEvent(IntPtr pointer)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            return (IrisRtcCEventParam)Marshal.PtrToStructure(pointer, typeof(IrisRtcCEventParam));
#else
            var raw = Header(pointer);
            int count = checked((int)raw.dataSize);
            string data = null;
            if (raw.data != IntPtr.Zero)
            {
                var bytes = new byte[count];
                Marshal.Copy(raw.data, bytes, 0, count);
                if (count > 0 && bytes[count - 1] == 0) count--;
                data = new UTF8Encoding(false, true).GetString(bytes, 0, count);
            }
            else if (count != 0) throw new ArgumentException("Missing callback data.");
            return new IrisRtcCEventParam
            {
                @event = Marshal.PtrToStringAnsi(raw.name), data = data, data_size = raw.dataSize,
                result = raw.result, buffer = raw.buffer, length = raw.length, buffer_count = raw.bufferCount
            };
#endif
        }
        internal static LitJson.JsonData Parse(string data)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            return AgoraJson.ToObject(data);
#else
            return LitJson.JsonMapper.ToObject(data);
#endif
        }
        internal static void HandleException(IntPtr pointer, Exception error, string scope)
        {
            Report(error, scope);
            try { WriteFailure(pointer); }
            catch (Exception writeError) { Report(writeError, scope); }
        }
        private static void Report(Exception error, string scope)
        {
            // Never include payloads, signed URLs, or arbitrary exception messages.
            try { Console.Error.WriteLine("RTC callback rejected ({0}): {1}", scope, error.GetType().Name); }
            catch (Exception) { /* Error reporting cannot escape into Native. */ }
        }
        internal static void WriteFailure(IntPtr pointer)
        {
#if !(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS)
            var raw = Header(pointer);
            if (raw.result == IntPtr.Zero) return;
            string name = Marshal.PtrToStringAnsi(raw.name);
            object result;
            switch (name)
            {
                case AgoraApiType.IAUDIOFRAMEOBSERVER_ONRECORDAUDIOFRAME_4c8de15:
                case AgoraApiType.IAUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAME_4c8de15:
                case AgoraApiType.IAUDIOFRAMEOBSERVER_ONMIXEDAUDIOFRAME_4c8de15:
                case AgoraApiType.IAUDIOFRAMEOBSERVER_ONEARMONITORINGAUDIOFRAME_5405a47:
                case AgoraApiType.IAUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING_9215cc7:
                case AgoraApiType.IAUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING_85ec0fc:
                case AgoraApiType.IVIDEOFRAMEOBSERVER_ONCAPTUREVIDEOFRAME_1673590:
                case AgoraApiType.IVIDEOFRAMEOBSERVER_ONPREENCODEVIDEOFRAME_1673590:
                case AgoraApiType.IVIDEOFRAMEOBSERVER_ONMEDIAPLAYERVIDEOFRAME_e648e2c:
                case AgoraApiType.IVIDEOFRAMEOBSERVER_ONTRANSCODEDVIDEOFRAME_27754d8:
                case AgoraApiType.IVIDEOFRAMEOBSERVER_ONRENDERVIDEOFRAME_43dcf82:
                case AgoraApiType.IVIDEOENCODEDFRAMEOBSERVER_ONENCODEDVIDEOFRAMERECEIVED_6922697:
                case AgoraApiType.IAUDIOSPECTRUMOBSERVER_ONLOCALAUDIOSPECTRUM_5822fed:
                case AgoraApiType.IAUDIOSPECTRUMOBSERVER_ONREMOTEAUDIOSPECTRUM_8ea2cde:
                case AgoraApiType.IFACEINFOOBSERVER_ONFACEINFO_3a2037f:
                    // Reject possibly partially modified frame/analysis output.
                    result = new Dictionary<string, object> { { "result", false } };
                    break;
                case AgoraApiType.IMEDIAPLAYERCUSTOMDATAPROVIDER_ONREADDATA_6e75338:
                case AgoraApiType.IMETADATAOBSERVER_GETMAXMETADATASIZE:
                    result = new Dictionary<string, object> { { "result", 0 } };
                    break;
                case AgoraApiType.IMEDIAPLAYERCUSTOMDATAPROVIDER_ONSEEK_624d569:
                    result = new Dictionary<string, object> { { "result", -1L } };
                    break;
                case AgoraApiType.IMETADATAOBSERVER_ONREADYTOSENDMETADATA_cbf4b59:
                    result = new Dictionary<string, object> { { "result", false }, { "metadata", new Metadata() } };
                    break;
                default:
                    return; // Void notifications have no result contract.
            }
            byte[] bytes = Encoding.UTF8.GetBytes(AgoraJson.ToJson(result));
            Marshal.Copy(bytes, 0, raw.result, bytes.Length);
            Marshal.WriteByte(raw.result, bytes.Length, 0);
#endif
        }
    }
}
