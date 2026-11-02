using System;
using System.IO;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    internal static class BusinessLogSettings
    {
        internal static LOG_LEVEL[] Levels => new[] { LOG_LEVEL.LOG_LEVEL_INFO, LOG_LEVEL.LOG_LEVEL_WARN,
            LOG_LEVEL.LOG_LEVEL_ERROR, LOG_LEVEL.LOG_LEVEL_FATAL, LOG_LEVEL.LOG_LEVEL_NONE };
        internal static LogConfig Create(string path, uint size, LOG_LEVEL level)
        {
            if (Array.IndexOf(Levels, level) < 0) throw new ArgumentException("请选择公开日志等级；内部DEBUG/API_CALL不能用于常规日志采集。");
            if (size < 128 || size > 20480) throw new ArgumentException("日志大小范围为128–20480 KiB。");
            path = path?.Trim() ?? "";
            if (path.Length > 0)
            {
                if (!Path.IsPathFullyQualified(path) || string.IsNullOrWhiteSpace(Path.GetFileName(path)))
                    throw new ArgumentException("请填写包含文件名的绝对日志路径。");
                if (!Directory.Exists(Path.GetDirectoryName(path)) || Directory.Exists(path))
                    throw new ArgumentException("日志父目录必须存在，且路径不能是文件夹；还需确保目录可写。");
            }
            return new LogConfig(path, size, level);
        }
    }
}
