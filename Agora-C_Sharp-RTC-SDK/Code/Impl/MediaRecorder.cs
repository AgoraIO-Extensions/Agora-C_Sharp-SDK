namespace Agora.Rtc
{
    public sealed class MediaRecorder : IMediaRecorder
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MediaRecorderImpl _mediaRecorderImpl = null;
        private const string ErrorMsgLog = "[MediaRecorder]:IRtcEngine has not been created yet!";
        private const int ErrorCode = -1;

        internal MediaRecorder(IRtcEngine rtcEngine, MediaRecorderImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _mediaRecorderImpl = impl;
        }

        ~MediaRecorder()
        {
            _mediaRecorderImpl = null;
            _rtcEngineInstance = null;
        }

        private static MediaRecorder instance = null;
        public static MediaRecorder Instance
        {
            get
            {
                return instance;
            }
        }

        internal static IMediaRecorder GetInstance(IRtcEngine rtcEngine, MediaRecorderImpl impl)
        {
            return instance ?? (instance = new MediaRecorder(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override int SetMediaRecorderObserver(RtcConnection connection, IMediaRecorderObserver callback)
        {
            if (_rtcEngineInstance == null || _mediaRecorderImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return -1;
            }
            return _mediaRecorderImpl.SetMediaRecorderObserver(connection, callback);
        }

        public override int StartRecording(RtcConnection connection, MediaRecorderConfiguration config)
        {
            if (_rtcEngineInstance == null || _mediaRecorderImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return -1;
            }
            return _mediaRecorderImpl.StartRecording(connection, config);
        }

        public override int StopRecording(RtcConnection connection)
        {
            if (_rtcEngineInstance == null || _mediaRecorderImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return -1;
            }
            return _mediaRecorderImpl.StopRecording(connection);
        }
    }
}
