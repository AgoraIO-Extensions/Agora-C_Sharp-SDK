using System;

namespace Agora.Rtc
{
    public partial class MusicContentCenter
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MusicContentCenterImpl _impl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        public MusicContentCenter(IRtcEngine rtcEngine, MusicContentCenterImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _impl = impl;
        }

        ~MusicContentCenter()
        {
            _rtcEngineInstance = null;
            _impl = null;
        }

        private static IMusicContentCenter instance = null;
        internal static IMusicContentCenter GetInstance(IRtcEngine rtcEngine, MusicContentCenterImpl impl)
        {
            return instance ?? (instance = new MusicContentCenter(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.RegisterAudioFrameObserver(audioFrameObserver, position, mode);
        }

        public override int UnregisterAudioFrameObserver()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.UnregisterAudioFrameObserver();
        }
    }
}