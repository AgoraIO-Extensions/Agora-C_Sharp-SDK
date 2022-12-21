using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
using UnityEngine;
#endif

namespace Agora.Rtc
{
    internal class IrisAudioSpectrumData
    {
        public IrisAudioSpectrumData()
        {
        }

        public ulong audioSpectrumData;
        public int dataLength;

        public void GenerateAudioSpectrumData(ref AudioSpectrumData audioSpectrum)
        {
            audioSpectrum.audioSpectrumData = new float[this.dataLength];
            Marshal.Copy((IntPtr)this.audioSpectrumData, audioSpectrum.audioSpectrumData, 0, dataLength);
            audioSpectrum.dataLength = this.dataLength;
        }
    }


    internal class IrisUserAudioSpectrumInfo
    {
        public IrisUserAudioSpectrumInfo()
        {
        }


        public uint uid;
        public IrisAudioSpectrumData spectrumData;

        public void GenerateUserAudioSpectrumInfo(ref UserAudioSpectrumInfo info)
        {
            info.uid = this.uid;
            info.spectrumData = new AudioSpectrumData();
            this.spectrumData.GenerateAudioSpectrumData(ref info.spectrumData);
        }

    }




    internal static class MediaPlayerAudioSpectrumObserverNative
    {
        private static System.Object observerLock = new System.Object();
        private static Dictionary<int, IAudioSpectrumObserver> mediaPlayerAudioSpectrumObserverDic = new Dictionary<int, IAudioSpectrumObserver>();

        internal static void AddAudioSpectrumObserver(int playerId, IAudioSpectrumObserver observer)
        {
            lock (observerLock)
            {
                if (mediaPlayerAudioSpectrumObserverDic.ContainsKey(playerId) == false)
                    mediaPlayerAudioSpectrumObserverDic.Add(playerId, observer);
            }
        }

        internal static void RemoveAudioSpectrumObserver(int playerId)
        {
            lock (observerLock)
            {
                if (mediaPlayerAudioSpectrumObserverDic.ContainsKey(playerId))
                    mediaPlayerAudioSpectrumObserverDic.Remove(playerId);
            }
        }



        //private static AudioSpectrumData ProcessAudioSpectrumData(IntPtr bufferPtr, int length)
        //{
        //    AudioSpectrumData spectrumData = new AudioSpectrumData();
        //    spectrumData.dataLength = length;

        //    spectrumData.audioSpectrumData = new float[length];
        //    if (bufferPtr != IntPtr.Zero)
        //    {
        //        Marshal.Copy(bufferPtr, spectrumData.audioSpectrumData, 0, length);
        //    }
        //    return spectrumData;
        //}

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
                if (mediaPlayerAudioSpectrumObserverDic.ContainsKey(playerId) == false)
                {
                    CreateDefaultReturn(ref eventParam, param);
                    return;
                }

                var @event = eventParam.@event;
                var buffer = eventParam.buffer;
                var length = eventParam.length;
                var buffer_count = eventParam.buffer_count;

                var audioSpectrumObserver = mediaPlayerAudioSpectrumObserverDic[playerId];

                switch (@event)
                {
                    case "AudioSpectrumObserver_onLocalAudioSpectrum":
                        {
                            var irisAudioSpectrumData = AgoraJson.JsonToStruct<IrisAudioSpectrumData>(jsonData, "data");
                            var spectrumData = new AudioSpectrumData();
                            irisAudioSpectrumData.GenerateAudioSpectrumData(ref spectrumData);
                            var result = audioSpectrumObserver.OnLocalAudioSpectrum(spectrumData);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "AudioSpectrumObserver_onRemoteAudioSpectrum":
                        {
                            var irisUserAudioSpectrumInfo = AgoraJson.JsonToStructArray<IrisUserAudioSpectrumInfo>(jsonData, "spectrums");
                            var spectrumNumber = (uint)AgoraJson.GetData<uint>(jsonData, "spectrumNumber");

                            UserAudioSpectrumInfo[] list = new UserAudioSpectrumInfo[spectrumNumber];
                            for (var i = 0; i < spectrumNumber; i++)
                            {
                                UserAudioSpectrumInfo e = new UserAudioSpectrumInfo();
                                irisUserAudioSpectrumInfo[i].GenerateUserAudioSpectrumInfo(ref e);
                                list[i] = e;
                            }
                            var result = audioSpectrumObserver.OnRemoteAudioSpectrum(list, spectrumNumber);
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
                case "AudioSpectrumObserver_onLocalAudioSpectrum":
                case "AudioSpectrumObserver_onRemoteAudioSpectrum":
                    {
                        var result = true;
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
        //        [MonoPInvokeCallback(typeof(Func_EventEx_Native))]
        //#endif
        //        internal static void OnEventEx(string @event, string data, IntPtr result, IntPtr buffer, IntPtr length, uint buffer_count)
        //        {
        //        }


        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        //        [MonoPInvokeCallback(typeof(Func_LocalAudioSpectrum_Native))]
        //#endif
        //        internal static bool OnLocalAudioSpectrum(int playerId, IntPtr data)
        //        {
        //            if (!AudioSpectrumObserverDic.ContainsKey(playerId)) return false;
        //            var irisMediaPlayerAudioSpectrumData = (IrisAudioSpectrumData)Marshal.PtrToStructure(data, typeof(IrisAudioSpectrumData));

        //            try
        //            {
        //                return AudioSpectrumObserverDic[playerId].OnLocalAudioSpectrum(ProcessAudioSpectrumData(irisMediaPlayerAudioSpectrumData.audioSpectrumData, irisMediaPlayerAudioSpectrumData.dataLength));
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioSpectrumObserver.OnLocalAudioSpectrum: " + e);
        //                return true;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        //        [MonoPInvokeCallback(typeof(Func_RemoteAudioSpectrum_Native))]
        //#endif
        //        internal static bool OnRemoteAudioSpectrum(int playerId, IntPtr dataspectrums, uint spectrumNumber)
        //        {
        //            if (!AudioSpectrumObserverDic.ContainsKey(playerId)) return false;
        //            UserAudioSpectrumInfo[] MediaPlayerSpectrumInfos = new UserAudioSpectrumInfo[spectrumNumber];
        //            for (int i = 0; i < spectrumNumber; i++)
        //            {
        //                IntPtr p = new IntPtr(dataspectrums.ToInt64() + Marshal.SizeOf(typeof(IrisUserAudioSpectrumInfo)) * i);
        //                var dataspectrum = (IrisUserAudioSpectrumInfo)Marshal.PtrToStructure(p, typeof(IrisUserAudioSpectrumInfo));
        //                MediaPlayerSpectrumInfos[i].uid = dataspectrum.uid;
        //                MediaPlayerSpectrumInfos[i].spectrumData = ProcessAudioSpectrumData(dataspectrum.spectrumData.audioSpectrumData, dataspectrum.spectrumData.dataLength);
        //            }

        //            try
        //            {
        //                return AudioSpectrumObserverDic[playerId].OnRemoteAudioSpectrum(MediaPlayerSpectrumInfos, spectrumNumber);
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioSpectrumObserver.OnRemoteAudioSpectrum: " + e);
        //                return true;
        //            }
        //        }
    }
}