using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTAudioEncodedFrameObserver : IAudioEncodedFrameObserver
    {

        public bool OnRecordAudioEncodedFrame_be_trigger = false;
        public IntPtr OnRecordAudioEncodedFrame_frameBuffer = IntPtr.Zero;
        public int OnRecordAudioEncodedFrame_length = 0;
        public EncodedAudioFrameInfo OnRecordAudioEncodedFrame_audioEncodedFrameInfo = null;

        public override void OnRecordAudioEncodedFrame(IntPtr frameBuffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)
        {
            OnRecordAudioEncodedFrame_be_trigger = true;
            OnRecordAudioEncodedFrame_frameBuffer = frameBuffer;
            OnRecordAudioEncodedFrame_length = length;
            OnRecordAudioEncodedFrame_audioEncodedFrameInfo = audioEncodedFrameInfo;
        }

        public bool OnRecordAudioEncodedFramePassed(IntPtr frameBuffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)
        {
            if (OnRecordAudioEncodedFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareIntPtr(OnRecordAudioEncodedFrame_frameBuffer, frameBuffer) == false)
                return false;
            if (ParamsHelper.compareInt(OnRecordAudioEncodedFrame_length, length) == false)
                return false;
            if (ParamsHelper.compareEncodedAudioFrameInfo(OnRecordAudioEncodedFrame_audioEncodedFrameInfo, audioEncodedFrameInfo) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPlaybackAudioEncodedFrame_be_trigger = false;
        public IntPtr OnPlaybackAudioEncodedFrame_frameBuffer = IntPtr.Zero;
        public int OnPlaybackAudioEncodedFrame_length = 0;
        public EncodedAudioFrameInfo OnPlaybackAudioEncodedFrame_audioEncodedFrameInfo = null;

        public override void OnPlaybackAudioEncodedFrame(IntPtr frameBuffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)
        {
            OnPlaybackAudioEncodedFrame_be_trigger = true;
            OnPlaybackAudioEncodedFrame_frameBuffer = frameBuffer;
            OnPlaybackAudioEncodedFrame_length = length;
            OnPlaybackAudioEncodedFrame_audioEncodedFrameInfo = audioEncodedFrameInfo;
        }

        public bool OnPlaybackAudioEncodedFramePassed(IntPtr frameBuffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)
        {
            if (OnPlaybackAudioEncodedFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareIntPtr(OnPlaybackAudioEncodedFrame_frameBuffer, frameBuffer) == false)
                return false;
            if (ParamsHelper.compareInt(OnPlaybackAudioEncodedFrame_length, length) == false)
                return false;
            if (ParamsHelper.compareEncodedAudioFrameInfo(OnPlaybackAudioEncodedFrame_audioEncodedFrameInfo, audioEncodedFrameInfo) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnMixedAudioEncodedFrame_be_trigger = false;
        public IntPtr OnMixedAudioEncodedFrame_frameBuffer = IntPtr.Zero;
        public int OnMixedAudioEncodedFrame_length = 0;
        public EncodedAudioFrameInfo OnMixedAudioEncodedFrame_audioEncodedFrameInfo = null;

        public override void OnMixedAudioEncodedFrame(IntPtr frameBuffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)
        {
            OnMixedAudioEncodedFrame_be_trigger = true;
            OnMixedAudioEncodedFrame_frameBuffer = frameBuffer;
            OnMixedAudioEncodedFrame_length = length;
            OnMixedAudioEncodedFrame_audioEncodedFrameInfo = audioEncodedFrameInfo;
        }

        public bool OnMixedAudioEncodedFramePassed(IntPtr frameBuffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)
        {
            if (OnMixedAudioEncodedFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareIntPtr(OnMixedAudioEncodedFrame_frameBuffer, frameBuffer) == false)
                return false;
            if (ParamsHelper.compareInt(OnMixedAudioEncodedFrame_length, length) == false)
                return false;
            if (ParamsHelper.compareEncodedAudioFrameInfo(OnMixedAudioEncodedFrame_audioEncodedFrameInfo, audioEncodedFrameInfo) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
