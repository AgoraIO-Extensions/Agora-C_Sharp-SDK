using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    internal static class MediaPlayerCustomDataProviderNative
    {
        internal static OBSERVER_MODE mode = OBSERVER_MODE.INTPTR;
        internal static IMediaPlayerCustomDataProvider CustomDataProvider;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_OnSeek_Native))]
#endif
        internal static Int64 OnSeek(Int64 offset, int whence, int playerId)
        {
            return CustomDataProvider == null ? -1 : 
                CustomDataProvider.OnSeek(offset, whence, playerId);
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_onReadData_Native))]
#endif
        internal static int OnReadData(IntPtr buffer, int bufferSize, int playerId)
        {
            byte[] Buffer = new byte[0];
            if (mode == OBSERVER_MODE.RAW_DATA)
            {
                Buffer = new byte[bufferSize];
                if (buffer != IntPtr.Zero)
                {
                    Marshal.Copy(buffer, Buffer, 0, (int)bufferSize);
                }
            }
            
            return CustomDataProvider == null ? -1 :
                CustomDataProvider.OnReadData(buffer, Buffer, bufferSize, playerId);
        }
    }
}