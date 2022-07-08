namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The mode for receiving data.
    /// </summary>
    ///
    public enum OBSERVER_MODE
    {
        RAW_DATA,

        INTPTR
    };

    public struct VideoFrameBufferConfig
    {
        public VIDEO_SOURCE_TYPE type;

        public uint id;

        public string key;
    };

    ///
    /// TODO(doc)
    ///
    public enum VIDEO_OBSERVER_FRAME_TYPE
    {
        ///
        /// TODO(doc)
        ///
        FRAME_TYPE_YUV420 = 0,

        ///
        /// TODO(doc)
        ///
        FRAME_TYPE_YUV422 = 1,

        ///
        /// TODO(doc)
        ///
        FRAME_TYPE_RGBA = 2,

        ///
        /// TODO(doc)
        ///
        FRAME_TYPE_BGRA = 3,
    };
}