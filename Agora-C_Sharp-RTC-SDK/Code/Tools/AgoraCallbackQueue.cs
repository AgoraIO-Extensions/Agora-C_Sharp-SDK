#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Agora.Rtc
{
    internal sealed class AgoraCallbackQueue : MonoBehaviour
    {
        private readonly Queue<Action> _queue = new Queue<Action>();

        internal void ClearQueue()
        {
            lock (_queue)
            {
                _queue.Clear();
            }
        }

        internal void EnQueue(Action action)
        {
            lock (_queue)
            {
                if (action != null)
                {
                    _queue.Enqueue(action);
                }
            }
        }

        internal Action DeQueue()
        {
            Action action = null;
            lock (_queue)
            {
                if (_queue.Count > 0)
                {
                    action = _queue.Dequeue();
                }
                return action;
            }
        }

        private void Update()
        {
            lock (_queue)
            {
                while (_queue.Count > 0)
                {
                    try
                    {
                        _queue.Dequeue().Invoke();
                    }
                    catch(Exception e)
                    {
                        AgoraLog.LogError("[Exception] AgoraCallbackQueue: " + e);
                    }
                }
            }
        }

        private void OnDestroy()
        {
            ClearQueue();
        }
    }
}

#endif