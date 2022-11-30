using System;

namespace Agora.Rtc
{
    #region IAgoraLog.h

    public class LogConfig
    {
        public LogConfig()
        {
            filePath = "";
            fileSizeInKB = 0;
            level = LOG_LEVEL.LOG_LEVEL_INFO;
        }

        public LogConfig(string filePath, uint fileSizeInKB = 1024, LOG_LEVEL level = LOG_LEVEL.LOG_LEVEL_INFO)
        {
            this.filePath = filePath;
            this.fileSizeInKB = fileSizeInKB;
            this.level = level;
        }

        public string filePath { set; get; }

        public uint fileSizeInKB { set; get; }

        public LOG_LEVEL level { set; get; }
    };

    [Flags]
    public enum LOG_LEVEL
    {
        LOG_LEVEL_NONE = 0x0000,

        LOG_LEVEL_INFO = 0x0001,

        LOG_LEVEL_WARN = 0x0002,

        LOG_LEVEL_ERROR = 0x0004,
        
        LOG_LEVEL_FATAL = 0x0008,
    };

    #endregion
}