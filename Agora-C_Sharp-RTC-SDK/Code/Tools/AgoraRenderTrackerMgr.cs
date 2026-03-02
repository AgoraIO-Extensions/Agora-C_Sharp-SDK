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


    internal sealed class AgoraRenderTrackerMgr : MonoBehaviour
    {
        public const int ID_LOCAL_IN_FPS = 526;
        public const int ID_LOCAL_DRAW_COST = 577;

        public const int ID_REMOTE_OUT_FPS = 537;
        public const int ID_REMOTE_DRAW_COST = 576;

        public static AgoraRenderTrackerMgr Instance = null;

        private long _lastTrackTimestampMs = 0;

        private const long TRACK_INTERVAL_MS = 6000;
        
        List<RtcConnection> rtcConnections = new List<RtcConnection>();
    
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
                AgoraLog.Log(AgoraJson.ToJson(trackData));
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
                        foreach (var connection in rtcConnections)
                        {
                            if (connection.channelId == tm.ChannelId)
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
                                trackData.connection.SetValue(connection);
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