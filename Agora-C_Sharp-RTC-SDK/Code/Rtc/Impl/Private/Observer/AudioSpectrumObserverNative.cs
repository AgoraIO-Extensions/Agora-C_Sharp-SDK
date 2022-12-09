using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class AudioSpectrumObserverNative
    {
        private static Object observerLock = new Object();
        private static IAudioSpectrumObserver audioSpectrumObserver = null;

        internal static void SetAudioSpectrumObserver(IAudioSpectrumObserver observer)
        {
            lock (observerLock)
            {
                audioSpectrumObserver = observer;
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
                if (playerId != 0)
                {
                    AgoraLog.LogError("playerId not zero in AudioSpectrumObserverNative");
                    return;
                }

                if (audioSpectrumObserver == null)
                {
                    CreateDefaultReturn(ref eventParam, param);
                    return;
                }

                var @event = eventParam.@event;
                var buffer = eventParam.buffer;
                var length = eventParam.length;
                var buffer_count = eventParam.buffer_count;


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


        //        private static AudioSpectrumData ProcessAudioSpectrumData(IntPtr bufferPtr, int length)
        //        {
        //            AudioSpectrumData spectrumData = new AudioSpectrumData();
        //            spectrumData.dataLength = length;

        //            spectrumData.audioSpectrumData = new float[length];
        //            if (bufferPtr != IntPtr.Zero)
        //            {
        //                Marshal.Copy(bufferPtr, spectrumData.audioSpectrumData, 0, length);
        //            }
        //            return spectrumData;
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        //        [MonoPInvokeCallback(typeof(Func_LocalAudioSpectrum_Native))]
        //#endif
        //        internal static bool OnLocalAudioSpectrum(int playerId, IntPtr data)
        //        {
        //            if (AgoraRtcAudioSpectrumObserver == null || playerId != 0) return true;
        //            var irisAudioSpectrumData = (IrisAudioSpectrumData)Marshal.PtrToStructure(data, typeof(IrisAudioSpectrumData));

        //            try
        //            {
        //                return AgoraRtcAudioSpectrumObserver.OnLocalAudioSpectrum(ProcessAudioSpectrumData(irisAudioSpectrumData.audioSpectrumData, irisAudioSpectrumData.dataLength));
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
        //            if (AgoraRtcAudioSpectrumObserver == null || playerId != 0) return true;
        //            UserAudioSpectrumInfo[] SpectrumInfos = new UserAudioSpectrumInfo[spectrumNumber];
        //            for (int i = 0; i < spectrumNumber; i++)
        //            {
        //                IntPtr p = new IntPtr(dataspectrums.ToInt64() + Marshal.SizeOf(typeof(IrisUserAudioSpectrumInfo)) * i);
        //                var dataspectrum = (IrisUserAudioSpectrumInfo)Marshal.PtrToStructure(p, typeof(IrisUserAudioSpectrumInfo));
        //                SpectrumInfos[i].uid = dataspectrum.uid;
        //                SpectrumInfos[i].spectrumData = ProcessAudioSpectrumData(dataspectrum.spectrumData.audioSpectrumData, dataspectrum.spectrumData.dataLength);
        //            }

        //            try
        //            {
        //                return AgoraRtcAudioSpectrumObserver.OnRemoteAudioSpectrum(SpectrumInfos, spectrumNumber);
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioSpectrumObserver.OnRemoteAudioSpectrum: " + e);
        //                return true;
        //            }
        //        }
    }
}
