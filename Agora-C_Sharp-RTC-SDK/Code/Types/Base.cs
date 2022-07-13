namespace Agora.Rtc
{
    public enum OBSERVER_MODE
    {
        RAW_DATA = 0,

        INTPTR = 1
    }

    public struct VideoFrameBufferConfig
    {
        public VIDEO_SOURCE_TYPE type;

        public uint id;

        public string key;
    }

    public enum VIDEO_OBSERVER_FRAME_TYPE
    {
        FRAME_TYPE_YUV420 = 0,  // YUV 420 format

        FRAME_TYPE_YUV422 = 1,  // YUV 422 format

        FRAME_TYPE_RGBA = 2,  // RGBA format

        FRAME_TYPE_BGRA = 3,
    };
}