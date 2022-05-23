namespace agora.rtc
{
    public class IAudioEncodedFrameObserver
    {
        public virtual void OnRecordAudioEncodedFrame(byte[] frameBuffer,  int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }

        public virtual void OnPlaybackAudioEncodedFrame(byte[] frameBuffer,  int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }

        public virtual void OnMixedAudioEncodedFrame(byte[] frameBuffer,  int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }
    };
}