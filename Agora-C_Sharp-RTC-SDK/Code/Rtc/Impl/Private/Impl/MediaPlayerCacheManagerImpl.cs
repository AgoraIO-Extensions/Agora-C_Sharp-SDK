using System;
using System.Collections.Generic;
namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    public partial class MediaPlayerCacheManagerImpl
    {

        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private IrisRtcCApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

        internal MediaPlayerCacheManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();
            _irisApiEngine = irisApiEngine;
        }

        ~MediaPlayerCacheManagerImpl()
        {
            Dispose(false);
        }

        internal void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Dispose(bool disposing)
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
    }
}
