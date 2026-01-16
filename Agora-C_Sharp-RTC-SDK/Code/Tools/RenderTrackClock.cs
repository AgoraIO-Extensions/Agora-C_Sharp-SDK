
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using System;
using System.Collections.Generic;
using UnityEngine;

#if AGORA_RTC
namespace Agora.Rtc
#elif AGORA_RTM
namespace Agora.Rtm
#endif
{
    public class RenderTrackClock
    {
        private long[] _array;
        private int _capacity;
        private int _count;
        private int _head;
        private int _tail;
        private long _lastTickTimestampMs;

        public RenderTrackClock(int capacity)
        {
            _capacity = capacity;
            _array = new long[capacity];
            _count = 0;
            _head = 0;
            _tail = 0;
            _lastTickTimestampMs = 0;
        }

        public void Add(long item)
        {
            _array[_tail] = item;
            if (_count == _capacity)
            {
                _head = (_head + 1) % _capacity; // Overwrite the oldest item
            }
            else
            {
                _count++;
            }
            _tail = (_tail + 1) % _capacity;
        }

        public int Count
        {
            get { return _count; }
        }

        public long Average
        {
            get
            {
                long sum = 0;
                for (int i = 0; i < _count; i++)
                {
                    sum += _array[(_head + i) % _capacity];
                }
                return sum / _count;
            }
        }

        public static long curTimestampMs
        {
            get
            {
                return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }
        }

        public void Tick()
        {
            //first tick will not calculate delta
            if(_lastTickTimestampMs == 0)
            {
                _lastTickTimestampMs = curTimestampMs;
                return;
            }
            long currentTimestampMs = curTimestampMs;
            long delta =  currentTimestampMs - _lastTickTimestampMs;
             Add(delta);
            _lastTickTimestampMs = currentTimestampMs;
        }
    }
}
#endif