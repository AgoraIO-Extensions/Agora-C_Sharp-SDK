namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The mode for receiving data.
    /// </summary>
    ///
    public enum OBSERVER_MODE
    {
        ///
        /// <summary>
        /// Raw data mode, which means the SDK sends you raw data.
        /// </summary>
        ///
        RAW_DATA,

        ///
        /// <summary>
        /// Pointer mode, which means the SDK sends you the pointer to the raw data.
        /// </summary>
        ///
        INTPTR
    };

    public struct VideoFrameBufferConfig
    {
        public VIDEO_SOURCE_TYPE type;

        public uint id;

        public string key;
    };

    public enum VIDEO_OBSERVER_FRAME_TYPE
    {
        FRAME_TYPE_YUV420 = 0,

        FRAME_TYPE_YUV422 = 1,

        FRAME_TYPE_RGBA = 2,

        FRAME_TYPE_BGRA = 3,
    };
}