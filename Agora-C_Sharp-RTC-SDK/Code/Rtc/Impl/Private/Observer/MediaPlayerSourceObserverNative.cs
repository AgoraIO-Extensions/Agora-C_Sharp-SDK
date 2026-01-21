using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    internal static partial class MediaPlayerSourceObserverNative
    {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
        private static Object observerLock = new Object();
#endif
        private static Dictionary<int, IMediaPlayerSourceObserver> mediaPlayerSourceObserverDic = new Dictionary<int, IMediaPlayerSourceObserver>();

        internal static void AddSourceObserver(int playerId, IMediaPlayerSourceObserver observer)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            lock (observerLock)
            {
#endif
                if (mediaPlayerSourceObserverDic.ContainsKey(playerId) == false)
                    mediaPlayerSourceObserverDic.Add(playerId, observer);
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            }
#endif
        }

        internal static void RemoveSourceObserver(int playerId)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            lock (observerLock)
            {
#endif
                if (mediaPlayerSourceObserverDic.ContainsKey(playerId))
                    mediaPlayerSourceObserverDic.Remove(playerId);
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            }
#endif
        }

        internal static void ClearSourceObserver()
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            lock (observerLock)
            {
#endif
                mediaPlayerSourceObserverDic.Clear();
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            }
#endif
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            lock (observerLock)
            {
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                if (CallbackObject == null || CallbackObject._CallbackQueue == null)
                    return;
#endif

                IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));
                var @event = eventParam.@event;
                var data = eventParam.data;

                var jsonData = AgoraJson.ToObject(data);
                int playerId = (int)AgoraJson.GetData<int>(jsonData, "playerId");
                switch (@event)
                {
                    case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONMETADATA_469a01b:
                        {
                            var byteLength = (int)AgoraJson.GetData<int>(jsonData, "length");
                            var bufferPtr = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "data");
                            var byteData = new byte[byteLength];
                            if (byteLength != 0)
                            {
                                Marshal.Copy(bufferPtr, byteData, 0, (int)byteLength);
                            }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                            CallbackObject._CallbackQueue.EnQueue(() =>
                                                                  {
#endif
                            if (!mediaPlayerSourceObserverDic.ContainsKey(playerId))
                                return;
                            mediaPlayerSourceObserverDic[playerId].OnMetaData(byteData, byteLength);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                                  });
#endif
                            break;
                        }

                    default:
                        {
                            OnEventGen(ref eventParam, jsonData, @event);
                            break;
                        }
                }
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            }
#endif
        }
    }

}
