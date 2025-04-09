using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    using view_t = UInt64;
    public partial class MusicPlayerImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private IrisRtcCApiParam _apiParam;
        private MediaPlayerImpl _mediaPlayerImpl;
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

        internal MusicPlayerImpl(IrisApiEnginePtr irisApiEngine, MediaPlayerImpl impl)
        {
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();
            _irisApiEngine = irisApiEngine;
            _mediaPlayerImpl = impl;
        }

        ~MusicPlayerImpl()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
            }

            _irisApiEngine = IntPtr.Zero;
            _apiParam.FreeResult();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public int InitEventHandler(int playerId, IMediaPlayerSourceObserver engineEventHandler)
        {
            return _mediaPlayerImpl.InitEventHandler(playerId, engineEventHandler);
        }

    }
}