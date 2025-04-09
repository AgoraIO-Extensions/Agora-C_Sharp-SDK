using System;
using view_t = System.UInt64;
namespace Agora.Rtc
{
    public partial class MediaPlayer
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MediaPlayerImpl _impl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
        private int playerId;

        internal MediaPlayer(IRtcEngine rtcEngine, MediaPlayerImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _impl = impl;

            playerId = _impl.CreateMediaPlayer();
        }

        ~MediaPlayer()
        {
            _impl = null;
            _rtcEngineInstance = null;
        }

        public override void Dispose()
        {
            if (_impl == null)
            {
                return;
            }
            _impl.DestroyMediaPlayer(playerId);
            playerId = 0;
        }

        public int Destroy()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            var ret = _impl.DestroyMediaPlayer(playerId);
            playerId = 0;
            return ret;
        }

        public override int GetId()
        {
            return playerId;
        }

        public override int InitEventHandler(IMediaPlayerSourceObserver engineEventHandler)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.InitEventHandler(playerId, engineEventHandler);
        }
    }
}