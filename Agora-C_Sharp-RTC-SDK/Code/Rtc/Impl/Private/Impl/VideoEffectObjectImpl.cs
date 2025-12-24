using System;
using System.Collections.Generic;

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;

    public partial class VideoEffectObjectImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private IrisRtcCApiParam _apiParam;
        private readonly Dictionary<string, object> _param = new Dictionary<string, object>();

        internal VideoEffectObjectImpl(IrisApiEnginePtr irisApiEngine)
        {
            _irisApiEngine = irisApiEngine;
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();
        }

        ~VideoEffectObjectImpl()
        {
            Dispose(false);
        }

        internal void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                // No managed resources to dispose in this class.
            }

            _irisApiEngine = IntPtr.Zero;
            _apiParam.FreeResult();
            _disposed = true;
        }
    }
}
