using UnityEngine;
using System.Collections;

namespace Agora.Rtc
{
    public class AgoraGameObject : MonoBehaviour
    {
        void OnApplicationQuit()
        {
            IRtcEngine rtcEngine = RtcEngine.Get();
            if (rtcEngine != null)
            {
                rtcEngine.Dispose();
            }
        }
    }
}