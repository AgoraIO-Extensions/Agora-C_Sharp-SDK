using System;

namespace Agora.Rtc
{
    #region IAgoraLog.h

    ///
    /// <summary>
    /// Configuration of Agora SDK log files.
    /// </summary>
    ///
    public class LogConfig
    {
        public LogConfig()
        {
            filePath = "";
            fileSizeInKB = 0;
            level = LOG_LEVEL.LOG_LEVEL_INFO;
        }

        public LogConfig(string filePath, uint fileSize = 1024, LOG_LEVEL level = LOG_LEVEL.LOG_LEVEL_INFO)
        {
            this.filePath = filePath;
            this.fileSizeInKB = 0;
            this.level = level;
        }

        ///
        /// <summary>
        /// The complete path of the log files. Ensure that the path for the log file exists and is writable. You can use this parameter to rename the log files.The default file path is:Android：/storage/emulated/0/Android/data/<packagename>/files/agorasdk.log.iOS：App Sandbox/Library/caches/agorasdk.log.macOSIf Sandbox is enabled: App~/Library/Logs/agorasdk.log. For example, /Users/<username>/Library/Containers/<AppBundleIdentifier>/Data/Library/Logs/agorasdk.log.If Sandbox is disabled: ~/Library/Logs/agorasdk.log.Windows：C:\Users\<user_name>\AppData\Local\Agora\<process_name>\agorasdk.log。
        /// </summary>
        ///
        public string filePath { set; get; }

        ///
        /// <summary>
        /// The size (KB) of an agorasdk.log file. The value range is [128,1024]. The default value is 1,024 KB. If you set fileSizeInKByte to a value lower than 128 KB, the SDK adjusts it to 128 KB. If you set fileSizeInKBytes to a value higher than 1,024 KB, the SDK adjusts it to 1,024 KB.
        /// </summary>
        ///
        public uint fileSizeInKB { set; get; }

        ///
        /// <summary>
        /// The output level of the SDK log file. See LOG_LEVEL .For example, if you set the log level to WARN, the SDK outputs the logs within levels FATAL, ERROR, and WARN.
        /// </summary>
        ///
        public LOG_LEVEL level { set; get; }
    };

    [Flags]
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
    };

    #endregion
}