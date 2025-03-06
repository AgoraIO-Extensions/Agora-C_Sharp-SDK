#define AGORA_RTC
#define AGORA_RTM

#if UNITY_OPENHARMONY
using System.Collections;
using System.Collections.Generic;
using Agora.Rtc.LitJson;
using UnityEngine;

#if AGORA_RTC
namespace Agora.Rtc
#elif AGORA_RTM
namespace Agora.Rtm
#endif
{
    internal class AgoraOhosCallback : MonoBehaviour
    {
        internal RtcEngineImpl impl;

        public void OnAgoraMessageCall(string data)
        {
            Debug.Log("OnAgoraMessageCall :" + data);
            JsonData jsonData = AgoraJson.ToObject(data);
            string type = (string)jsonData["type"];
            switch (type)
            {
                case "createOhosRtcEngine":
                    {
                        string nativeHandler = (string)jsonData["data"];
                        impl.OnInitializeFinishFromOhos(nativeHandler);
                        break;
                    }
                default:
                    {
                        int result = (int)jsonData["data"];
                        impl.OnCommonApiFinishFromOhos(type, result);
                        break;
                    }
            }

            if(type == "destroyOhosRtcEngine")
            {
                impl.OnDisposeFinish();
            }

        }
    }
}
#endif
