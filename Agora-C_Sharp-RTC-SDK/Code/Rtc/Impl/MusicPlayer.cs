using System;

namespace Agora.Rtc
{
    public partial class MusicPlayer
    {
        private MusicPlayerImpl _impl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
        private int playerId;

        internal MusicPlayer(MusicPlayerImpl impl, int id)
        {

            this._impl = impl;
            this.playerId = id;
        }

        public override void Dispose()
        {
            AgoraLog.LogError("Please use IMusicContentCenter.DestroyMusicPlayer to instead of");
        }

        ~MusicPlayer()
        {
            _impl = null;
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