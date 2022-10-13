using System;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class MediaPlayerCustomDataProviderNative
    {
        internal static Dictionary<int, IMediaPlayerCustomDataProvider> CustomDataProviders = new Dictionary<int, IMediaPlayerCustomDataProvider>();


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_OnSeek_Native))]
#endif
        internal static Int64 OnSeek(Int64 offset, int whence, int playerId)
        {
            if (CustomDataProviders.ContainsKey(playerId))
            {
                try
                {
                    return CustomDataProviders[playerId].OnSeek(offset, whence);
                }
                catch (Exception e)
                {
                    AgoraLog.LogError("[Exception] IMediaPlayerCustomDataProvider.OnSeek: " + e);
                    return 0;
                }
            }

            return 0;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_onReadData_Native))]
#endif
        internal static int OnReadData(IntPtr buffer, int bufferSize, int playerId)
        {
            if (CustomDataProviders.ContainsKey(playerId))
            {
                try
                {
                    return CustomDataProviders[playerId].OnReadData(buffer, bufferSize);
                }
                catch (Exception e)
                {
                    AgoraLog.LogError("[Exception] IMediaPlayerCustomDataProvider.OnReadData: " + e);
                    return 0;
                }
            }

            return 0;
        }
    }
}