//  AgoraCallbackQueue.cs
//
//  Created by YuGuo Chen on October 3, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 

using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading;

namespace agora.rtc
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
                    _queue.Dequeue().Invoke();
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