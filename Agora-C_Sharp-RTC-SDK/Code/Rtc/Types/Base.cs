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
    }

    ///
    /// <summary>
    /// Video frame settings.
    /// </summary>
    ///
    public struct VideoFrameBufferConfig
    {
        ///
        /// <summary>
        /// The video source type. See VIDEO_SOURCE_TYPE .
        /// </summary>
        ///
        public VIDEO_SOURCE_TYPE type;

        ///
        /// <summary>
        /// The user ID.
        /// </summary>
        ///
        public uint id;

        ///
        /// <summary>
        /// The channel name.
        /// </summary>
        ///
        public string key;
    }

    ///
    /// <summary>
    /// Video frame formats.
    /// </summary>
    ///
    public enum VIDEO_OBSERVER_FRAME_TYPE
    {
        ///
        /// @ignore
        ///
        FRAME_TYPE_YUV420 = 0,
        
        ///
        /// @ignore
        ///
        FRAME_TYPE_YUV422 = 1, 
        
        ///
        /// <summary>
        /// 2: The format of the video frame is RGBA.
        /// </summary>
        ///
        FRAME_TYPE_RGBA = 2,
        
        ///
        /// @ignore
        ///
        FRAME_TYPE_BGRA = 3,
    };
}