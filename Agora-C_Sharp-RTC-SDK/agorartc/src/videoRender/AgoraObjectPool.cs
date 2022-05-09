using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace agora.rtc
{
    internal class AgoraObjectPool<T, C> where T : new()
    {
        private readonly Dictionary<C, T> _objects;

        private AgoraObjectPool()
        {
            _objects = new Dictionary<C, T>();
        }

        private static AgoraObjectPool<T, C> instance;
        internal static AgoraObjectPool<T, C> Instacne
        {
            get
            {
                if (instance == null)
                {
                    instance = new AgoraObjectPool<T, C>();
                }
                return instance;
            }
        }

        internal T GetObj(C identity)
        {
            if (_objects.ContainsKey(identity))
            {
                T result = _objects[identity];
                return result;
            }
            return default(T);
        }

        internal void AddObj(C identity, T obj)
        {
            lock(_objects)
            {
                _objects.Add(identity, obj);
            }
        }

        internal void DelObj(C identity)
        {
            lock(_objects)
            {
                _objects.Remove(identity);
            }
        }

        private void Clear()
        {
            lock(_objects)
            {
                _objects.Clear();
            }
        }

        internal void Destroy()
        {
            _objects.Clear();
        }
    }

}