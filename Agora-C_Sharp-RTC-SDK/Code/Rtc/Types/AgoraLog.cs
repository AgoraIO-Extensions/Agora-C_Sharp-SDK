using System;

namespace Agora.Rtc
{
    #region terra IAgoraLog.h
    ///
    /// <summary>
    /// The output log level of the SDK.
    /// </summary>
    ///
    public enum LOG_LEVEL
    {
        ///
        /// <summary>
        /// 0: Do not output any log information.
        /// </summary>
        ///
        LOG_LEVEL_NONE = 0x0000,

        ///
        /// <summary>
        /// 0x0001: (Default) Output FATAL, ERROR, WARN, and INFO level log information. We recommend setting your log filter to this level.
        /// </summary>
        ///
        LOG_LEVEL_INFO = 0x0001,

        ///
        /// <summary>
        /// 0x0002: Output FATAL, ERROR, and WARN level log information.
        /// </summary>
        ///
        LOG_LEVEL_WARN = 0x0002,

        ///
        /// <summary>
        /// 0x0004: Output FATAL and ERROR level log information.
        /// </summary>
        ///
        LOG_LEVEL_ERROR = 0x0004,

        ///
        /// <summary>
        /// 0x0008: Output FATAL level log information.
        /// </summary>
        ///
        LOG_LEVEL_FATAL = 0x0008,

        ///
        /// @ignore
        ///
        LOG_LEVEL_API_CALL = 0x0010,
    }

    ///
    /// @ignore
    ///
    public enum LOG_FILTER_TYPE
    {
        ///
        /// @ignore
        ///
        LOG_FILTER_OFF = 0,

        ///
        /// @ignore
        ///
        LOG_FILTER_DEBUG = 0x080f,

        ///
        /// @ignore
        ///
        LOG_FILTER_INFO = 0x000f,

        ///
        /// @ignore
        ///
        LOG_FILTER_WARN = 0x000e,

        ///
        /// @ignore
        ///
        LOG_FILTER_ERROR = 0x000c,

        ///
        /// @ignore
        ///
        LOG_FILTER_CRITICAL = 0x0008,

        ///
        /// @ignore
        ///
        LOG_FILTER_MASK = 0x80f,
    }

    ///
    /// <summary>
    /// Configuration of Agora SDK log files.
    /// </summary>
    ///
    public class LogConfig
    {
        ///
        /// <summary>
        /// The complete path of the log files. Agora recommends using the default log directory. If you need to modify the default directory, ensure that the directory you specify exists and is writable. The default log directory is:
        ///  Android： /storage/emulated/0/Android/data/<packagename>/files/agorasdk.log.
        ///  iOS： App Sandbox/Library/caches/agorasdk.log.
        ///  macOS:
        ///  If Sandbox is enabled: App Sandbox/Library/Logs/agorasdk.log. For example, /Users/<username>/Library/Containers/<AppBundleIdentifier>/Data/Library/Logs/agorasdk.log.
        ///  If Sandbox is disabled: ~/Library/Logs/agorasdk.log
        ///  Windows: C:\Users\<user_name>\AppData\Local\Agora\<process_name>\agorasdk.log.
        /// </summary>
        ///
        public string filePath;

        ///
        /// <summary>
        /// The size (KB) of an agorasdk.log file. The value range is [128,20480]. The default value is 2,048 KB. If you set fileSizeInKByte smaller than 128 KB, the SDK automatically adjusts it to 128 KB; if you set fileSizeInKByte greater than 20,480 KB, the SDK automatically adjusts it to 20,480 KB.
        /// </summary>
        ///
        public uint fileSizeInKB;

        ///
        /// <summary>
        /// The output level of the SDK log file. See LOG_LEVEL. For example, if you set the log level to WARN, the SDK outputs the logs within levels FATAL, ERROR, and WARN.
        /// </summary>
        ///
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