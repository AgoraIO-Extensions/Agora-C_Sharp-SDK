//  AgoraCallbackQueue.cs
//
//  Created by Tao Zhang.
//  Modified by Yiqing Huang on June 5, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//
#if __UNITY__

using UnityEngine;
using System;
using System.Collections.Generic;

namespace agora.rtc {
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
                    if (_queue.Count >= 250)
                    {
                        _queue.Dequeue();
                    }
                    _queue.Enqueue(action);
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
                }
                return action;
            }

            // Update is called once per frame
            private void Update()
            {
                var action = DeQueue();

                if (action != null) action.Invoke();
            }

            private void OnDestroy()
            {
                ClearQueue();
            }
        }
}
#endif