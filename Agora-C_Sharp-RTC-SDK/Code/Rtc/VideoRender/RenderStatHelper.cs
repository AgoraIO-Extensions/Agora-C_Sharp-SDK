using System.Collections.Generic;
using UnityEngine;

namespace Agora.Rtc
{
    public static class RenderStatHelper
    {
        // IDs defined by user
        public const int ID_LOCAL_IN_FPS = 579;
        public const int ID_LOCAL_OUT_FPS = 526;
        public const int ID_REMOTE_IN_FPS = 578;
        public const int ID_REMOTE_OUT_FPS = 537;
        public const int ID_LOCAL_DRAW_COST = 577;
        public const int ID_REMOTE_DRAW_COST = 576;

        private const int VIDEO_SOURCE_REMOTE_INT = 9;

        // Counters
        private static int _localInCount = 0;
        private static int _localOutCount = 0;
        private static int _remoteInCount = 0;
        private static int _remoteOutCount = 0;

        // Draw Cost Accumulators (in milliseconds)
        private static float _localDrawCostSum = 0;
        private static int _localDrawCostCount = 0;
        private static float _remoteDrawCostSum = 0;
        private static int _remoteDrawCostCount = 0;

        private static float _lastTime = 0;
        private static float _interval = 6.0f; // 6 seconds interval

        public static void LogInFrame(VIDEO_SOURCE_TYPE sourceType)
        {
            if (IsRemote(sourceType))
            {
                _remoteInCount++;
            }
            else
            {
                _localInCount++;
            }
            CheckAndPrint();
        }

        public static void LogOutFrame(VIDEO_SOURCE_TYPE sourceType)
        {
            if (IsRemote(sourceType))
            {
                _remoteOutCount++;
            }
            else
            {
                _localOutCount++;
            }
        }

        public static void LogDrawCost(VIDEO_SOURCE_TYPE sourceType, float costMs)
        {
            if (IsRemote(sourceType))
            {
                _remoteDrawCostSum += costMs;
                _remoteDrawCostCount++;
            }
            else
            {
                _localDrawCostSum += costMs;
                _localDrawCostCount++;
            }
        }

        private static bool IsRemote(VIDEO_SOURCE_TYPE sourceType)
        {
            return (int)sourceType == VIDEO_SOURCE_REMOTE_INT;
        }

        private static void CheckAndPrint()
        {
            float currentTime = Time.realtimeSinceStartup;
            float actualInterval = currentTime - _lastTime;
            
            if (_lastTime == 0)
            {
                _lastTime = currentTime;
                return;
            }

            if (actualInterval >= _interval)
            {
                // Calculate FPS (Average over the interval)
                // Use actualInterval to ensure accuracy if the check is delayed
                int localInFps = (int)(_localInCount / actualInterval);
                int localOutFps = (int)(_localOutCount / actualInterval);
                int remoteInFps = (int)(_remoteInCount / actualInterval);
                int remoteOutFps = (int)(_remoteOutCount / actualInterval);

                // Calculate Mean Draw Cost
                float localDrawCostMean = _localDrawCostCount > 0 ? _localDrawCostSum / _localDrawCostCount : 0;
                float remoteDrawCostMean = _remoteDrawCostCount > 0 ? _remoteDrawCostSum / _remoteDrawCostCount : 0;

                // Output stats (Formatted as requested or just logged)
                // Using Debug.Log for now.
                // Format: "Key (ID): Value"
                
                // Only log if there is activity to avoid spamming empty logs
                if (_localInCount + _remoteInCount + _localOutCount + _remoteOutCount > 0)
                {
                   /*
                    * Local In FPS:
                    VIDEO LOCAL FRAME TO RENDER FPS (579)

                    * Local Out FPS
                    Video Render Mean FPS (526)

                    * Remote In FPS
                    VIDEO REMOTE FRAME TO RENDER FPS (578)

                    * Remote Out FPS
                    Video Remote Render Mean FPS (537)


                    2. 渲染耗时
                    LOCAL
                    VIDEO LOCAL RENDER DRAW COST (577)

                    Remote
                    VIDEO REMOTE RENDER DRAW COST (576)
                    */
                    
                    var sb = new System.Text.StringBuilder();
                    sb.AppendLine("=== Agora Video Render Stats ===");
                    
                    // Local
                    sb.AppendLine($"VIDEO LOCAL FRAME TO RENDER FPS ({ID_LOCAL_IN_FPS}): {localInFps}");
                    sb.AppendLine($"Video Render Mean FPS ({ID_LOCAL_OUT_FPS}): {localOutFps}");
                    sb.AppendLine($"VIDEO LOCAL RENDER DRAW COST ({ID_LOCAL_DRAW_COST}): {localDrawCostMean:F2} ms");

                    // Remote
                    sb.AppendLine($"VIDEO REMOTE FRAME TO RENDER FPS ({ID_REMOTE_IN_FPS}): {remoteInFps}");
                    sb.AppendLine($"Video Remote Render Mean FPS ({ID_REMOTE_OUT_FPS}): {remoteOutFps}");
                    sb.AppendLine($"VIDEO REMOTE RENDER DRAW COST ({ID_REMOTE_DRAW_COST}): {remoteDrawCostMean:F2} ms");

                    AgoraLog.Log(sb.ToString());
                }

                // Reset
                _localInCount = 0;
                _localOutCount = 0;
                _remoteInCount = 0;
                _remoteOutCount = 0;
                _localDrawCostSum = 0;
                _localDrawCostCount = 0;
                _remoteDrawCostSum = 0;
                _remoteDrawCostCount = 0;

                _lastTime = currentTime;
            }
        }
    }
}

