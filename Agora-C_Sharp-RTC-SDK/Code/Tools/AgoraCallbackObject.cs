#define AGORA_RTC
#define AGORA_RTM
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS || UNITY_OPENHARMONY

using UnityEngine;
using Object = UnityEngine.Object;

#if AGORA_RTC
namespace Agora.Rtc
#elif AGORA_RTM
namespace Agora.Rtm
#endif
{
    internal sealed class AgoraCallbackObject
    {
        private GameObject _CallbackGameObject;
        internal AgoraCallbackQueue _CallbackQueue;
        private string GameObjectName;

        internal AgoraCallbackObject(string gameObjectName)
        {
            GameObjectName = gameObjectName;
            InitGameObject(gameObjectName);
        }

        internal void Release()
        {
            DeInitGameObject(GameObjectName);
        }

        private void InitGameObject(string gameObjectName)
        {
            DeInitGameObject(gameObjectName);
            _CallbackGameObject = new GameObject(gameObjectName);
            _CallbackQueue = _CallbackGameObject.AddComponent<AgoraCallbackQueue>();
            Object.DontDestroyOnLoad(_CallbackGameObject);
            _CallbackGameObject.hideFlags = HideFlags.HideInHierarchy;
        }

        private void DeInitGameObject(string gameObjectName)
        {
            var gameObject = GameObject.Find(gameObjectName);
            if (!ReferenceEquals(gameObject, null))
            {
                AgoraCallbackQueue callbackQueue = gameObject.GetComponent<AgoraCallbackQueue>();
                if (!ReferenceEquals(callbackQueue, null))
                {
                    callbackQueue.ClearQueue();
                }

                Object.Destroy(gameObject);
            }
        }
    }
}

#endif