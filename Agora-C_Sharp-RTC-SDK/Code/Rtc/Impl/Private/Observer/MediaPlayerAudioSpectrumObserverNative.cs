using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS 
using AOT;
using UnityEngine;
#endif

namespace Agora.Rtc
{
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

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));
                var data = eventParam.data;

                LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                int playerId = (int)AgoraJson.GetData<int>(jsonData, "playerId");
                if (mediaPlayerAudioSpectrumObserverDic.ContainsKey(playerId) == false)
                {
                    CreateDefaultReturn(ref eventParam, param);
                    return;
                }

                var @event = eventParam.@event;

                var audioSpectrumObserver = mediaPlayerAudioSpectrumObserverDic[playerId];

                switch (@event)
                {
                    case AgoraEventType.EVENT_AUDIOSPECTRUMOBSERVER_ONLOCALAUDIOSPECTRUM:
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
                    case AgoraEventType.EVENT_AUDIOSPECTRUMOBSERVER_ONREMOTEAUDIOSPECTRUM:
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
                            var result = ((IAudioSpectrumObserver)audioSpectrumObserver).OnRemoteAudioSpectrum(list, spectrumNumber);
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

        private static void CreateDefaultReturn(ref IrisRtcCEventParam eventParam, IntPtr param)
        {
            var @event = eventParam.@event;
            switch (@event)
            {
                case AgoraEventType.EVENT_AUDIOSPECTRUMOBSERVER_ONLOCALAUDIOSPECTRUM:
                case AgoraEventType.EVENT_AUDIOSPECTRUMOBSERVER_ONREMOTEAUDIOSPECTRUM:
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
    }
}