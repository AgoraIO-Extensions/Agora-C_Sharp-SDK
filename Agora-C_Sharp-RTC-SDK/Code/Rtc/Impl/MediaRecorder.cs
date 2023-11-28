namespace Agora.Rtc
{
    public sealed class MediaRecorder : IMediaRecorder
    {
        private MediaRecorderImpl _mediaRecorderImpl = null;
        private string _nativeHandle = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        internal MediaRecorder(MediaRecorderImpl impl, string nativeHandle)
        {
            _mediaRecorderImpl = impl;
            _nativeHandle = nativeHandle;
        }

        ~MediaRecorder()
        {
            _mediaRecorderImpl = null;
        }

        internal string GetNativeHandle()
        {
            return this._nativeHandle;
        }

        internal void SetNativeHandle(string nativeHandle)
        {
            this._nativeHandle = nativeHandle;
        }

        #region terra IMediaRecorder
        public override int SetMediaRecorderObserver(IMediaRecorderObserver callback)
        {
            if (_mediaRecorderImpl == null || this._nativeHandle == null)
            {
                return ErrorCode;
            }
            return _mediaRecorderImpl.SetMediaRecorderObserver(_nativeHandle, callback);
        }

        public override int StartRecording(MediaRecorderConfiguration config)
        {
            if (_mediaRecorderImpl == null || this._nativeHandle == null)
            {
                return ErrorCode;
            }
            return _mediaRecorderImpl.StartRecording(_nativeHandle, config);
        }

        public override int StopRecording()
        {
            if (_mediaRecorderImpl == null || this._nativeHandle == null)
            {
                return ErrorCode;
            }
            return _mediaRecorderImpl.StopRecording(_nativeHandle);
        }
        #endregion terra IMediaRecorder
    }
}
