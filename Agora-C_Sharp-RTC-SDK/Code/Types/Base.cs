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
        FRAME_TYPE_YUV420 = 0,
        
        FRAME_TYPE_YUV422 = 1, 
        
        FRAME_TYPE_RGBA = 2,
        
        FRAME_TYPE_BGRA = 3,
    };
}