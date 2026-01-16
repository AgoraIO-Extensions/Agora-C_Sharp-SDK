#define AGORA_RTC
#define AGORA_RTM
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

    public class MetricCounter
    {
        public int counterId;
        public int value;
    }

    public class MetricCounters
    {
        public List<MetricCounter> counter = new List<MetricCounter>();
        public int uid;
    }

    public class TrackData
    {
        public List<MetricCounters> data = new List<MetricCounters>();
        public RtcConnection connection;
    }


    class RtcConnectionComparer : IEqualityComparer<RtcConnection>
    {
        public static readonly RtcConnectionComparer Instance = new RtcConnectionComparer();

        public bool Equals(RtcConnection x, RtcConnection y)
        {

            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.localUid == y.localUid &&
                   string.Equals(x.channelId, y.channelId);
        }

        public int GetHashCode(RtcConnection obj)
        {
            return (obj.localUid, obj.channelId).GetHashCode();
        }
    }


    // Marks which local video stream is the pushed stream for the current connection
    class LocalVideoMark
    {
        public VIDEO_SOURCE_TYPE sourceType;
        public int id;

        public LocalVideoMark(VIDEO_SOURCE_TYPE sourceType, int id)
        {
            this.sourceType = sourceType;
            this.id = id;
        }
    }

    internal sealed class AgoraRenderTrackerMgr : MonoBehaviour
    {
        public const int ID_LOCAL_IN_FPS = 579;
        // public const int ID_LOCAL_OUT_FPS = 526;
        public const int ID_LOCAL_DRAW_COST = 577;
        //public const int ID_REMOTE_IN_FPS = 578;
        public const int ID_REMOTE_OUT_FPS = 537;
        public const int ID_REMOTE_DRAW_COST = 576;

        public static AgoraRenderTrackerMgr Instance = null;

        // All RtcConnections to be tracked
        HashSet<RtcConnection> rtcConnections = new HashSet<RtcConnection>(RtcConnectionComparer.Instance);

        // Which tracked connection corresponds to the local video stream
        Dictionary<RtcConnection, LocalVideoMark> localVideoMarks = new Dictionary<RtcConnection, LocalVideoMark>(RtcConnectionComparer.Instance);

        private long _lastTrackTimestampMs = 0;

        private const long TRACK_INTERVAL_MS = 6000;

        public void AddRtcConnection(RtcConnection connection)
        {
            if (!rtcConnections.Contains(connection))
            {
                rtcConnections.Add(connection);
            }
        }

        public void RemoveRtcConnection(RtcConnection connection)
        {
            if (rtcConnections.Contains(connection))
            {
                rtcConnections.Remove(connection);
            }
        }

        // Mark local video stream info for the given connection
        public void MarkLocalVideoInfo(RtcConnection connection, LocalVideoMark mark)
        {
            if (localVideoMarks.ContainsKey(connection))
            {
                localVideoMarks[connection] = mark;
            }
            else
            {
                localVideoMarks.Add(connection, mark);
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
            gameObject.hideFlags = HideFlags.HideInHierarchy;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        private void Update()
        {
            long currentTimestampMs = RenderTrackClock.curTimestampMs;
            if (currentTimestampMs - _lastTrackTimestampMs >= TRACK_INTERVAL_MS)
            {
                _lastTrackTimestampMs = currentTimestampMs;
                var textureManagers = GameObject.FindObjectsOfType<TextureManager>();
                foreach (var connection in rtcConnections)
                {
                    var trackData = new TrackData();
                    trackData.connection = connection;
                    foreach (var tm in textureManagers)
                    {
                        if (tm.ChannelId == connection.channelId)
                        {
                            if (tm.RenderTrackClock.Average != 0)
                            {
                                int drawCost = (int)tm.RenderTrackClock.Average;
                                int fps = (int)(1000 / drawCost);
                                var mcs = new MetricCounters();
                                mcs.uid = (int)tm.Uid;
                                if (tm.SourceType == VIDEO_SOURCE_TYPE.VIDEO_SOURCE_REMOTE)
                                {
                                    //remote video
                                    mcs.counter.Add(new MetricCounter() { counterId = ID_REMOTE_OUT_FPS, value = fps });
                                    mcs.counter.Add(new MetricCounter() { counterId = ID_REMOTE_DRAW_COST, value = drawCost });
                                }
                                else
                                {
                                    //if have three mpk playing, this will report three times.
                                    //local video
                                    if (localVideoMarks.ContainsKey(connection) &&
                                       localVideoMarks[connection].sourceType == tm.SourceType)
                                    {

                                        mcs.counter.Add(new MetricCounter() { counterId = ID_LOCAL_IN_FPS, value = fps });
                                        mcs.counter.Add(new MetricCounter() { counterId = ID_LOCAL_DRAW_COST, value = drawCost });
                                        //local video use uid 0
                                        mcs.uid = 0;
                                    }
                                }
                                if (mcs.counter.Count > 0)
                                {
                                    trackData.data.Add(mcs);
                                }
                            }
                        }
                    }

                    if (trackData.data.Count > 0)
                    {
                        var engine = RtcEngine.Get();
                        if (engine != null)
                        {
                            var json = AgoraJson.ToJson<TrackData>(trackData);
                            int ret = engine.SetParameters("rtc.report.argus_counters", json);
                            if (ret != 0)
                            {
                                AgoraLog.LogWarning("AgoraRenderTrackerMgr SetParameters rtc.report.argus_counters failed, ret:" + ret);
                            }
                        }
                    }

                }
            }
        }
    }
}

#endif