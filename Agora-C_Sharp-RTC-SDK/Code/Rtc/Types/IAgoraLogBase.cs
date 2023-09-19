using System;

namespace Agora.Rtc
{
#region terra IAgoraLog.h

    /* enum_loglevel */
    public enum LOG_LEVEL
    {
        /* enum_loglevel_LOG_LEVEL_NONE */
        LOG_LEVEL_NONE = 0x0000,

        /* enum_loglevel_LOG_LEVEL_INFO */
        LOG_LEVEL_INFO = 0x0001,

        /* enum_loglevel_LOG_LEVEL_WARN */
        LOG_LEVEL_WARN = 0x0002,

        /* enum_loglevel_LOG_LEVEL_ERROR */
        LOG_LEVEL_ERROR = 0x0004,

        /* enum_loglevel_LOG_LEVEL_FATAL */
        LOG_LEVEL_FATAL = 0x0008,

        /* enum_loglevel_LOG_LEVEL_API_CALL */
        LOG_LEVEL_API_CALL = 0x0010,
    }

    /* enum_logfiltertype */
    public enum LOG_FILTER_TYPE
    {
        /* enum_logfiltertype_LOG_FILTER_OFF */
        LOG_FILTER_OFF = 0,

        /* enum_logfiltertype_LOG_FILTER_DEBUG */
        LOG_FILTER_DEBUG = 0x080f,

        /* enum_logfiltertype_LOG_FILTER_INFO */
        LOG_FILTER_INFO = 0x000f,

        /* enum_logfiltertype_LOG_FILTER_WARN */
        LOG_FILTER_WARN = 0x000e,

        /* enum_logfiltertype_LOG_FILTER_ERROR */
        LOG_FILTER_ERROR = 0x000c,

        /* enum_logfiltertype_LOG_FILTER_CRITICAL */
        LOG_FILTER_CRITICAL = 0x0008,

        /* enum_logfiltertype_LOG_FILTER_MASK */
        LOG_FILTER_MASK = 0x80f,
    }

    /* class_logconfig */
    public class LogConfig
    {
        /* class_logconfig_filePath */
        public string filePath;

        /* class_logconfig_fileSizeInKB */
        public uint fileSizeInKB;

        /* class_logconfig_level */
        public LOG_LEVEL level;

        public LogConfig()
        {
            this.filePath = "";
            this.fileSizeInKB = 1024;
            this.level = LOG_LEVEL.LOG_LEVEL_INFO;
        }

        public LogConfig(string filePath, uint fileSizeInKB, LOG_LEVEL level)
        {
            this.filePath = filePath;
            this.fileSizeInKB = fileSizeInKB;
            this.level = level;
        }
    }

#endregion terra IAgoraLog.h
}