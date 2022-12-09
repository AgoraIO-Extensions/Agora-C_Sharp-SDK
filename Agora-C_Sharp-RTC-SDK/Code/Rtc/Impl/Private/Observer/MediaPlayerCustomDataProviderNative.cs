using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class MediaPlayerCustomDataProviderNative
    {
        private static Object observerLock = new Object();
        private static Dictionary<int, IMediaPlayerCustomDataProvider> mediaPlayerCustomDataProviderDic = new Dictionary<int, IMediaPlayerCustomDataProvider>();

        internal static void AddCustomDataProvider(int playerId, IMediaPlayerCustomDataProvider observer)
        {
            lock (observerLock)
            {
                if (mediaPlayerCustomDataProviderDic.ContainsKey(playerId) == false)
                    mediaPlayerCustomDataProviderDic.Add(playerId, observer);
            }
        }

        internal static void RemoveCustomDataProvider(int playerId)
        {
            lock (observerLock)
            {
                if (mediaPlayerCustomDataProviderDic.ContainsKey(playerId))
                    mediaPlayerCustomDataProviderDic.Remove(playerId);
            }
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));

                var data = eventParam.data;

                LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                int playerId = (int)AgoraJson.GetData<int>(jsonData, "playerId");
                if (mediaPlayerCustomDataProviderDic.ContainsKey(playerId) == false)
                {
                    CreateDefaultReturn(ref eventParam, param);
                    return;
                }

                var customDataProvider = mediaPlayerCustomDataProviderDic[playerId];
                var @event = eventParam.@event;
                var buffer = eventParam.buffer;
                var length = eventParam.length;
                var buffer_count = eventParam.buffer_count;

                switch (@event)
                {
                    case "MediaPlayerCustomDataProvider_onReadData":
                        {
                            IntPtr buffer0 = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "buffer");
                            int bufferSize = (int)AgoraJson.GetData<int>(jsonData, "bufferSize");
                            int result = customDataProvider.OnReadData(buffer0, bufferSize);

                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "MediaPlayerCustomDataProvider_onSeek":
                        {
                            Int64 offset = (Int64)AgoraJson.GetData<Int64>(jsonData, "offset");
                            int whence = (int)AgoraJson.GetData<int>(jsonData, "whence");
                            Int64 result = customDataProvider.OnSeek(offset, whence);

                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    default:
                        AgoraLog.LogError("unexpected event: " + @event);
                        break;
                }
            }
        }

        private static void CreateDefaultReturn(ref IrisCEventParam eventParam, IntPtr param)
        {
            var @event = eventParam.@event;
            switch (@event)
            {
                case "MediaPlayerCustomDataProvider_onReadData":
                    {
                        int result = 0;
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
                case "MediaPlayerCustomDataProvider_onSeek":
                    {
                        Int64 result = 0;
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }




        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_OnSeek_Native))]
        //#endif
        //        internal static Int64 OnSeek(Int64 offset, int whence, int playerId)
        //        {
        //            if (CustomDataProviderDic.ContainsKey(playerId))
        //            {
        //                try
        //                {
        //                    return CustomDataProviderDic[playerId].OnSeek(offset, whence);
        //                }
        //                catch (Exception e)
        //                {
        //                    AgoraLog.LogError("[Exception] IMediaPlayerCustomDataProvider.OnSeek: " + e);
        //                    return 0;
        //                }
        //            }

        //            return 0;
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_onReadData_Native))]
        //#endif
        //        internal static int OnReadData(IntPtr buffer, int bufferSize, int playerId)
        //        {
        //            if (CustomDataProviderDic.ContainsKey(playerId))
        //            {
        //                try
        //                {
        //                    return CustomDataProviderDic[playerId].OnReadData(buffer, bufferSize);
        //                }
        //                catch (Exception e)
        //                {
        //                    AgoraLog.LogError("[Exception] IMediaPlayerCustomDataProvider.OnReadData: " + e);
        //                    return 0;
        //                }
        //            }

        //            return 0;
        //        }
    }
}