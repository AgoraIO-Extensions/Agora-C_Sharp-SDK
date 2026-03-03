#define AGORA_RTC
#define AGORA_RTM
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS

using System;
using System.Collections.Generic;
using System.IO;
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
        public List<MetricCounter> counters = new List<MetricCounter>();
        public uint uid;
    }

    public class TrackData : IOptionalJsonParse
    {
        public List<MetricCounters> data = new List<MetricCounters>();
        public Optional<RtcConnection> connection = new Optional<RtcConnection>();
        public Optional<VIDEO_SOURCE_TYPE> videoSourceType = new Optional<VIDEO_SOURCE_TYPE>();

        public void ToJson(Agora.Rtc.LitJson.JsonWriter writer)
        {
            writer.WriteObjectStart();
            
            writer.WritePropertyName("data");
            Agora.Rtc.LitJson.JsonMapper.WriteValue(this.data, writer, false, 0);

            if (connection.HasValue())
            {
                writer.WritePropertyName("connection");
                Agora.Rtc.LitJson.JsonMapper.WriteValue(this.connection.GetValue(), writer, false, 0);
            }

            if (videoSourceType.HasValue())
            {
                writer.WritePropertyName("videoSourceType");
                AgoraJson.WriteEnum(writer, videoSourceType.GetValue());
            }
            
            writer.WriteObjectEnd();
        }
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


    internal sealed class AgoraRenderTrackerMgr : MonoBehaviour
    {
        public const int ID_LOCAL_IN_FPS = 526;
        public const int ID_LOCAL_DRAW_COST = 577;

        public const int ID_REMOTE_OUT_FPS = 537;
        public const int ID_REMOTE_DRAW_COST = 576;

        public static AgoraRenderTrackerMgr Instance = null;

        private long _lastTrackTimestampMs = 0;

        private const long TRACK_INTERVAL_MS = 6000;
        
        private Dictionary<RtcConnection, List<uint>> connection2RemoteUid = new Dictionary<RtcConnection, List<uint>>(RtcConnectionComparer.Instance);

        
        public void AddRemoteUid(RtcConnection connection, uint remoteUid)
        {
            if (connection2RemoteUid.ContainsKey(connection))
            {
                var remoteUids = connection2RemoteUid[connection];
                if (!remoteUids.Contains(remoteUid))
                {
                    remoteUids.Add(remoteUid);
                }
            }
            else
            {
                AgoraLog.LogWarning("" + connection.channelId + " not exist in connection2RemoteUid");
            }
        }

        public void RemoveRemoteUid(RtcConnection connection, uint remoteUid)
        {
            if (connection2RemoteUid.ContainsKey(connection))
            {
                var remoteUids = connection2RemoteUid[connection];
                if (remoteUids.Contains(remoteUid))
                {
                    remoteUids.Remove(remoteUid);
                }
            }
        }

       
        //when onUserJoinedSucess, will call this
        public void AddRtcConnection(RtcConnection connection)
        {
            if (!connection2RemoteUid.ContainsKey(connection))
            {
                connection2RemoteUid.Add(connection, new List<uint>());
            }
        }

        //when onUserOffline, will call this
        public void RemoveRtcConnection(RtcConnection connection)
        {
            if (connection2RemoteUid.ContainsKey(connection))
            {
                connection2RemoteUid.Remove(connection);
            }
        }

    
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            gameObject.hideFlags = HideFlags.HideInHierarchy;
        }

        private void Report(TrackData trackData)
        {
            var engine = RtcEngine.Get();
            if (engine != null)
            {
                // AgoraLog.Log(AgoraJson.ToJson(trackData));
                int ret = engine.SetParameters("rtc.report.argus_counters", trackData);
                if (ret != 0)
                {
                    AgoraLog.LogWarning(
                        "AgoraRenderTrackerMgr SetParameters rtc.report.argus_counters failed, ret:" + ret);
                }
            }
        }


        private void Update()
        {
            long currentTimestampMs = RenderTrackClock.curTimestampMs;
            if (currentTimestampMs - _lastTrackTimestampMs >= TRACK_INTERVAL_MS)
            {
                _lastTrackTimestampMs = currentTimestampMs;
                var textureManagers = GameObject.FindObjectsOfType<TextureManager>();

                foreach (var tm in textureManagers)
                {
                    if (tm.renderTrackClock == null || tm.renderTrackClock.Average == 0)
                        continue;

                    //ChannelId == "" mean local video view
                    if (tm.ChannelId == "")
                    {
                        var trackData = new TrackData();
                        int drawCost = (int)tm.renderTrackClock.Average;
                        int fps = (int)(1000 / drawCost);
                        var mcs = new MetricCounters();
                        mcs.counters.Add(new MetricCounter()
                            { counterId = ID_LOCAL_IN_FPS, value = fps });
                        mcs.counters.Add(new MetricCounter()
                            { counterId = ID_LOCAL_DRAW_COST, value = drawCost });
                        //local video view uid must be set to 0
                        mcs.uid = 0;
                        trackData.data.Add(mcs);
                        trackData.videoSourceType.SetValue(tm.SourceType);
                        Report(trackData);
                    }
                    else
                    {
                        //ChannelId != "" mean remote video view, report with connection info
                        foreach (var kvp in connection2RemoteUid)
                        {
                            if(kvp.Value.Contains(tm.Uid) && kvp.Key.channelId == tm.ChannelId)
                            {
                                var trackData = new TrackData();
                                int drawCost = (int)tm.renderTrackClock.Average;
                                int fps = (int)(1000 / drawCost);
                                var mcs = new MetricCounters();
                                mcs.counters.Add(new MetricCounter()
                                    { counterId = ID_REMOTE_OUT_FPS, value = fps });
                                mcs.counters.Add(new MetricCounter()
                                    { counterId = ID_REMOTE_DRAW_COST, value = drawCost });
                                mcs.uid = tm.Uid;
                                trackData.data.Add(mcs);
                                trackData.connection.SetValue(kvp.Key);
                                Report(trackData);
                            }
                        }
                    }
                }
            }
        }
    }
}

#endif