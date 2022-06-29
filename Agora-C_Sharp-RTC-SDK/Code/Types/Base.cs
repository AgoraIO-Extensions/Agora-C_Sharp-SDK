namespace Agora.Rtc
{
    public enum OBSERVER_MODE
    {
        RAW_DATA,
        INTPTR
    }

    public struct VideoFrameBufferConfig
    {
        public VIDEO_SOURCE_TYPE type;
        public uint id;
        public string key;
    }


    public enum VIDEO_OBSERVER_FRAME_TYPE
    {
        /**
        * 0: (Default) YUV 420
        */
        FRAME_TYPE_YUV420 = 0,  // YUV 420 format
        /**
        * 1: YUV 422
        */
        FRAME_TYPE_YUV422 = 1,  // YUV 422 format
        /**
        * 2: RGBA
        */
        FRAME_TYPE_RGBA = 2,  // RGBA format
        FRAME_TYPE_BGRA = 3,
    };
}