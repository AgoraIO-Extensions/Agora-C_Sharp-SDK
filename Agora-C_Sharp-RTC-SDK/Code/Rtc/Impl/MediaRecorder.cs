namespace Agora.Rtc
{
    public partial class MediaRecorder
    {
        private MediaRecorderImpl _impl = null;
        private string _nativeHandle = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        internal MediaRecorder(MediaRecorderImpl impl, string nativeHandle)
        {
            _impl = impl;
            _nativeHandle = nativeHandle;
        }

        ~MediaRecorder()
        {
            _impl = null;
        }

        internal string GetNativeHandle()
        {
            return this._nativeHandle;
        }

        internal void SetNativeHandle(string nativeHandle)
        {
            this._nativeHandle = nativeHandle;
        }
    }
}
