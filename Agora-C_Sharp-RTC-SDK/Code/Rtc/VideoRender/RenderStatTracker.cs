using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using UnityEngine;
#endif

namespace Agora.Rtc
{
    [System.Serializable]
    public class MetricCounter
    {
        public int counterId;
        public int value;
    }

    [System.Serializable]
    public class RtcConnectionInfo
    {
        public string channelId;
        public uint localUid;
    }

    [System.Serializable]
    public class MetricReportDataItem
    {
        public MetricCounter[] counters;
        public uint uid;
        public RtcConnectionInfo connection;
    }

    [System.Serializable]
    public class MetricReportWrapper
    {
        public MetricReportDataItem[] data;

        public static string ToJson(MetricReportDataItem dataItem)
        {
            // New format: {"data":[{"counters":[...],"uid":1,"connection":{...}}]}
            var sb = new System.Text.StringBuilder();
            sb.Append("{\"data\":[{");

            // Add counters array first
            sb.Append("\"counters\":[");
            for (int i = 0; i < dataItem.counters.Length; i++)
            {
                if (i > 0) sb.Append(",");
                sb.Append("{");
                sb.AppendFormat("\"counterId\":{0},", dataItem.counters[i].counterId);
                sb.AppendFormat("\"value\":{0}", dataItem.counters[i].value);
                sb.Append("}");
            }
            sb.Append("],");

            // Add uid
            sb.AppendFormat("\"uid\":{0},", dataItem.uid);

            // Add connection (note: moved to the end, without trailing comma)
            sb.Append("\"connection\":{");
            sb.AppendFormat("\"channelId\":\"{0}\",", EscapeJsonString(dataItem.connection.channelId));
            sb.AppendFormat("\"localUid\":{0}", dataItem.connection.localUid);
            sb.Append("}");

            sb.Append("}]}");
            return sb.ToString();
        }

        /// <summary>
        /// Test method using simple parameter format like C++
        /// Usage: MetricReportWrapper.TestSimpleParameter()
        /// </summary>
        public static string TestSimpleParameter()
        {
            // Test with simple format like C++: {"che.audio.ps.mode":1}
            return "{\"che.audio.ps.mode\":1}";
        }

        private static string EscapeJsonString(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            return str.Replace("\\", "\\\\")
                    .Replace("\"", "\\\"")
                    .Replace("\n", "\\n")
                    .Replace("\r", "\\r")
                    .Replace("\t", "\\t");
        }
    }

    /// <summary>
    /// Metric type enumeration
    /// </summary>
    public enum MetricType
    {
        //IN_FPS,      // Frame rate of incoming frames
        OUT_FPS,     // Frame rate of rendered frames
        DRAW_COST    // Average rendering time cost (ms)
    }

    /// <summary>
    /// Counter ID mapping helper
    /// </summary>
    public static class CounterIdMapper
    {
        // Counter ID constants
        //public const int ID_LOCAL_IN_FPS = 579;
        public const int ID_LOCAL_OUT_FPS = 526;
        public const int ID_LOCAL_DRAW_COST = 577;
        //public const int ID_REMOTE_IN_FPS = 578;
        public const int ID_REMOTE_OUT_FPS = 537;
        public const int ID_REMOTE_DRAW_COST = 576;

        /// <summary>
        /// Get counter ID based on VIDEO_SOURCE_TYPE and metric type
        /// Only VIDEO_SOURCE_REMOTE is considered remote, all others are local
        /// </summary>
        /// <param name="sourceType">Video source type</param>
        /// <param name="metricType">Metric type (IN_FPS, OUT_FPS, DRAW_COST)</param>
        /// <returns>Corresponding counter ID</returns>
        public static int GetCounterId(VIDEO_SOURCE_TYPE sourceType, MetricType metricType)
        {
            bool isRemote = (sourceType == VIDEO_SOURCE_TYPE.VIDEO_SOURCE_REMOTE);

            if (isRemote)
            {
                switch (metricType)
                {
                    //case MetricType.IN_FPS:
                    //    return ID_REMOTE_IN_FPS;
                    case MetricType.OUT_FPS:
                        return ID_REMOTE_OUT_FPS;
                    case MetricType.DRAW_COST:
                        return ID_REMOTE_DRAW_COST;
                    default:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                        Debug.LogWarning($"Unknown metric type: {metricType}");
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
                        System.Diagnostics.Debug.WriteLine($"[Agora Warning] Unknown metric type: {metricType}");
#endif
                        return 0;
                }
            }
            else // LOCAL
            {
                switch (metricType)
                {
                    //case MetricType.IN_FPS:
                    //    return ID_LOCAL_IN_FPS;
                    case MetricType.OUT_FPS:
                        return ID_LOCAL_OUT_FPS;
                    case MetricType.DRAW_COST:
                        return ID_LOCAL_DRAW_COST;
                    default:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                        Debug.LogWarning($"Unknown metric type: {metricType}");
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
                        System.Diagnostics.Debug.WriteLine($"[Agora Warning] Unknown metric type: {metricType}");
#endif
                        return 0;
                }
            }
        }
    }

    /// <summary>
    /// Individual render stat tracker for each VideoSurface
    /// Tracks and reports rendering metrics independently for each video surface instance
    /// </summary>
    public class RenderStatTracker
    {
        // Identity
        private uint _uid;              // The uid used for identifying the video surface (0 for local, remote uid for remote)
        private uint _localUid;         // The actual local uid from OnLocalVideoStats (for reporting)
        private string _channelId;
        private VIDEO_SOURCE_TYPE _sourceType;

        // Counters
        private int _inCount = 0;
        private int _outCount = 0;

        // Draw Cost Accumulators (in milliseconds)
        private float _drawCostSum = 0;
        private int _drawCostCount = 0;

        private float _lastTime = 0;
        private float _interval = 6.0f; // 6 seconds interval

        // Reporting switch
        private bool _enableReporting = false;

        public RenderStatTracker(uint uid, string channelId, VIDEO_SOURCE_TYPE sourceType)
        {
            _uid = uid;
            _localUid = uid;  // Initially same as uid, will be updated for local video via OnLocalVideoStats
            _channelId = channelId;
            _sourceType = sourceType;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            _lastTime = Time.realtimeSinceStartup;
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            _lastTime = System.Environment.TickCount / 1000.0f;
#endif
        }

        /// <summary>
        /// Update connection information (uid, channelId, sourceType)
        /// This is useful when initial values were incomplete or placeholders
        /// For local video: uid remains 0, but localUid will be updated to actual local uid
        /// For remote video: both uid and localUid are the same
        /// </summary>
        /// <param name="uid">User ID from OnLocalVideoStats (this becomes localUid)</param>
        /// <param name="channelId">Channel ID</param>
        /// <param name="sourceType">Video source type</param>
        public void UpdateConnectionInfo(uint uid, string channelId, VIDEO_SOURCE_TYPE sourceType)
        {
            bool changed = false;

            // For local video: keep _uid as 0, update _localUid
            // For remote video: both _uid and _localUid should be the same
            bool isLocal = (_sourceType != VIDEO_SOURCE_TYPE.VIDEO_SOURCE_REMOTE);

            if (isLocal)
            {
                // Local video: uid stays 0, localUid gets updated
                if (_localUid != uid)
                {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    Debug.Log($"RenderStatTracker: Updating LocalUID from {_localUid} to {uid} (UID remains {_uid})");
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
                    System.Diagnostics.Debug.WriteLine($"[Agora Log] RenderStatTracker: Updating LocalUID from {_localUid} to {uid} (UID remains {_uid})");
#endif
                    _localUid = uid;
                    changed = true;
                }
            }
            else
            {
                // Remote video: both uid and localUid should be the same
                if (_uid != uid)
                {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    Debug.Log($"RenderStatTracker: Updating UID from {_uid} to {uid}");
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
                    System.Diagnostics.Debug.WriteLine($"[Agora Log] RenderStatTracker: Updating UID from {_uid} to {uid}");
#endif
                    _uid = uid;
                    _localUid = uid;
                    changed = true;
                }
            }

            if (_channelId != channelId && !string.IsNullOrEmpty(channelId))
            {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                Debug.Log($"RenderStatTracker: Updating ChannelId from '{_channelId}' to '{channelId}'");
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
                System.Diagnostics.Debug.WriteLine($"[Agora Log] RenderStatTracker: Updating ChannelId from '{_channelId}' to '{channelId}'");
#endif
                _channelId = channelId;
                changed = true;
            }

            if (_sourceType != sourceType)
            {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                Debug.Log($"RenderStatTracker: Updating SourceType from {_sourceType} to {sourceType}");
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
                System.Diagnostics.Debug.WriteLine($"[Agora Log] RenderStatTracker: Updating SourceType from {_sourceType} to {sourceType}");
#endif
                _sourceType = sourceType;
                changed = true;
            }

            if (changed)
            {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                Debug.Log($"RenderStatTracker: Connection info updated - UID: {_uid}, LocalUID: {_localUid}, Channel: {_channelId}, Source: {_sourceType}");
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
                System.Diagnostics.Debug.WriteLine($"[Agora Log] RenderStatTracker: Connection info updated - UID: {_uid}, LocalUID: {_localUid}, Channel: {_channelId}, Source: {_sourceType}");
#endif
            }
        }

        public void SetEnableReporting(bool enable)
        {
            _enableReporting = enable;
        }

        public bool IsReportingEnabled()
        {
            return _enableReporting;
        }

        //public void LogInFrame()
        //{
        //    _inCount++;
        //}

        public void LogOutFrame()
        {
            _outCount++;
        }

        public void LogDrawCost(float costMs)
        {
            _drawCostSum += costMs;
            _drawCostCount++;
        }

        /// <summary>
        /// Call this method periodically (e.g., in Update loop) to check and report metrics
        /// </summary>
        public void Tick()
        {
            CheckAndReport();
        }

        private void CheckAndReport()
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            float currentTime = Time.realtimeSinceStartup;
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            float currentTime = System.Environment.TickCount / 1000.0f;
#endif
            float actualInterval = currentTime - _lastTime;

            if (actualInterval >= _interval)
            {
                // Calculate FPS
                int inFps = (int)(_inCount / actualInterval);
                int outFps = (int)(_outCount / actualInterval);

                // ✅ Calculate AVERAGE Draw Cost (total cost / frame count)
                float drawCostMean = _drawCostCount > 0 ? _drawCostSum / _drawCostCount : 0;

                // ✅ Calculate AVERAGE Render Interval (time between frames)
                // actualInterval is in seconds, convert to ms and divide by frame count
                float renderIntervalMean = _outCount > 0 ? (actualInterval * 1000.0f) / _outCount : 0;

                // Only log if there is activity
                if (_outCount > 0)  // ✅ Changed from _inCount + _outCount to just _outCount
                {
                    bool isRemote = (_sourceType == VIDEO_SOURCE_TYPE.VIDEO_SOURCE_REMOTE);

                    var sb = new System.Text.StringBuilder();
                    sb.AppendLine($"=== Agora Video Render Stats (UID: {_uid}, LocalUID: {_localUid}, Channel: {_channelId}, Source: {_sourceType}) ===");

                    //int inFpsId = CounterIdMapper.GetCounterId(_sourceType, MetricType.IN_FPS);
                    int outFpsId = CounterIdMapper.GetCounterId(_sourceType, MetricType.OUT_FPS);
                    int drawCostId = CounterIdMapper.GetCounterId(_sourceType, MetricType.DRAW_COST);

                    if (isRemote)
                    {
                        //sb.AppendLine($"VIDEO REMOTE FRAME TO RENDER FPS ({inFpsId}): {inFps}");
                        sb.AppendLine($"Video Remote Render Mean FPS ({outFpsId}): {outFps}");
                        sb.AppendLine($"VIDEO REMOTE RENDER DRAW COST ({drawCostId}): {drawCostMean:F2} ms (avg of {_drawCostCount} frames)");
                        sb.AppendLine($"VIDEO REMOTE RENDER INTERVAL: {renderIntervalMean:F2} ms (avg interval between frames, {_outCount} frames in {actualInterval:F2}s)");
                    }
                    else
                    {
                        //sb.AppendLine($"VIDEO LOCAL FRAME TO RENDER FPS ({inFpsId}): {inFps}");
                        sb.AppendLine($"Video Render Mean FPS ({outFpsId}): {outFps}");
                        sb.AppendLine($"VIDEO LOCAL RENDER DRAW COST ({drawCostId}): {drawCostMean:F2} ms (avg of {_drawCostCount} frames)");
                        sb.AppendLine($"VIDEO LOCAL RENDER INTERVAL: {renderIntervalMean:F2} ms (avg interval between frames, {_outCount} frames in {actualInterval:F2}s)");
                    }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    Debug.Log(sb.ToString());
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
                    System.Diagnostics.Debug.WriteLine($"[Agora Log] {sb.ToString()}");
#endif

                    // Report metrics via SetParameters if enabled
                    if (_enableReporting)
                    {
                        ReportMetrics(inFps, outFps, drawCostMean);
                    }
                }

                // Reset counters
                //_inCount = 0;
                _outCount = 0;
                _drawCostSum = 0;
                _drawCostCount = 0;
                _lastTime = currentTime;
            }
        }

        private void ReportMetrics(int inFps, int outFps, float drawCostMean)
        {
            try
            {
                var engine = RtcEngineImpl.Get();
                if (engine == null) return;

                // Create metric report data item
                MetricReportDataItem reportDataItem = new MetricReportDataItem();
                reportDataItem.uid = _uid;  // Use _uid for identification (0 for local, remote uid for remote)
                reportDataItem.connection = new RtcConnectionInfo
                {
                    channelId = _channelId,
                    localUid = _localUid  // Use _localUid for connection info (actual local uid from OnLocalVideoStats)
                };

                // Create counters array
                List<MetricCounter> countersList = new List<MetricCounter>();

                // ❌ IN_FPS - Commented out, not reporting
                // countersList.Add(new MetricCounter
                // {
                //     counterId = CounterIdMapper.GetCounterId(_sourceType, MetricType.IN_FPS),
                //     value = inFps
                // });

                // ✅ OUT_FPS - Still reporting
                countersList.Add(new MetricCounter
                {
                    counterId = CounterIdMapper.GetCounterId(_sourceType, MetricType.OUT_FPS),
                    value = outFps
                });

                // ✅ DRAW_COST - Still reporting
                countersList.Add(new MetricCounter
                {
                    counterId = CounterIdMapper.GetCounterId(_sourceType, MetricType.DRAW_COST),
                    value = (int)drawCostMean
                });

                reportDataItem.counters = countersList.ToArray();

                // Build JSON parameters with new format
                string parameters = MetricReportWrapper.ToJson(reportDataItem);

                int ret = engine.SetParameters(parameters);

                // Log the JSON for debugging
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                Debug.Log($"[RenderStatTracker]: ret {ret} JSON: {parameters}");
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
                System.Diagnostics.Debug.WriteLine($"[Agora Log] [RenderStatTracker]: ret {ret} JSON: {parameters}");
#endif
               
            }
            catch (System.Exception ex)
            {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                Debug.LogError($"RenderStatTracker: Failed to report metrics - {ex.Message}");
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
                System.Diagnostics.Debug.WriteLine($"[Agora Error] RenderStatTracker: Failed to report metrics - {ex.Message}");
#endif
            }
        }
    }
}
