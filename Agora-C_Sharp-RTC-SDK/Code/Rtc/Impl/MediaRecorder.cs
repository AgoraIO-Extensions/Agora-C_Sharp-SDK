namespace Agora.Rtc
{
    public sealed class MediaRecorder : IMediaRecorder
    {
        private MediaRecorderImpl _mediaRecorderImpl = null;
        private string _nativeHandler = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        internal MediaRecorder(MediaRecorderImpl impl, string nativeHandler)
        {
            _mediaRecorderImpl = impl;
            _nativeHandler = nativeHandler;
        }

        ~MediaRecorder()
        {
            _mediaRecorderImpl = null;
        }

        internal string GetNativeHandler()
        {
            return this._nativeHandler;
        }

        internal void SetNativeHandler(string nativeHandler)
        {
            this._nativeHandler = nativeHandler;
        }

        public override int SetMediaRecorderObserver(IMediaRecorderObserver callback)
        {
            if (_mediaRecorderImpl == null || this._nativeHandler == null)
            {
                return ErrorCode;
            }
            return _mediaRecorderImpl.SetMediaRecorderObserver(this._nativeHandler, callback);
        }

        public override int StartRecording(MediaRecorderConfiguration config)
        {
            if (_mediaRecorderImpl == null || this._nativeHandler == null)
            {
                return ErrorCode;
            }
            return _mediaRecorderImpl.StartRecording(this._nativeHandler, config);
        }

        public override int StopRecording()
        {
            if (_mediaRecorderImpl == null || this._nativeHandler == null)
            {
                return ErrorCode;
            }
            return _mediaRecorderImpl.StopRecording(this._nativeHandler);
        }
    }
}
