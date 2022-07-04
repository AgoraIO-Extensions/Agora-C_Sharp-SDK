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

        public LogConfig(string filePath, uint fileSize = 1024, LOG_LEVEL level = LOG_LEVEL.LOG_LEVEL_INFO)
        {
            this.filePath = filePath;
            this.fileSizeInKB = 0;
            this.level = level;
        }

        /** The absolute path of log files.
         *
         * The default file path is:
         * - Android: `/storage/emulated/0/Android/data/<package name>/files/agorasdk.log`
         * - iOS: `App Sandbox/Library/caches/agorasdk.log`
         * - macOS:
         *  - Sandbox enabled: `App Sandbox/Library/Logs/agorasdk.log`, such as `/Users/<username>/Library/Containers/<App Bundle Identifier>/Data/Library/Logs/agorasdk.log`.
         *  - Sandbox disabled: `～/Library/Logs/agorasdk.log`.
         * - Windows: `C:\Users\<user_name>\AppData\Local\Agora\<process_name>\agorasdk.log`
         *
         * Ensure that the directory for the log files exists and is writable. You can use this parameter to rename the log files.
         */
        public string filePath { set; get; }

        /** The size (KB) of a log file. The default value is 1024 KB. If you set `fileSize` to 1024 KB, the SDK outputs at most 5 MB log files;
         * if you set it to less than 1024 KB, the setting is invalid, and the maximum size of a log file is still 1024 KB.
         */
        public uint fileSizeInKB { set; get; }

        /** The output log level of the SDK. See #LOG_LEVEL.
         *
         * For example, if you set the log level to WARN, the SDK outputs the logs within levels FATAL, ERROR, and WARN.
         */
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
