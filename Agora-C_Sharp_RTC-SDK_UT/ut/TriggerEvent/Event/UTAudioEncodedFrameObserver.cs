using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTAudioEncodedFrameObserver : IAudioEncodedFrameObserver
    {
        #region terra IAudioEncodedFrameObserver

        public bool OnRecordAudioEncodedFrame_be_trigger = false;
        public IntPtr OnRecordAudioEncodedFrame_frameBuffer;
        public int OnRecordAudioEncodedFrame_length;
        public EncodedAudioFrameInfo OnRecordAudioEncodedFrame_audioEncodedFrameInfo;

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

            if (ParamsHelper.Compare<IntPtr>(OnRecordAudioEncodedFrame_frameBuffer, frameBuffer) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnRecordAudioEncodedFrame_length, length) == false)
                return false;
            if (ParamsHelper.Compare<EncodedAudioFrameInfo>(OnRecordAudioEncodedFrame_audioEncodedFrameInfo, audioEncodedFrameInfo) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnPlaybackAudioEncodedFrame_be_trigger = false;
        public IntPtr OnPlaybackAudioEncodedFrame_frameBuffer;
        public int OnPlaybackAudioEncodedFrame_length;
        public EncodedAudioFrameInfo OnPlaybackAudioEncodedFrame_audioEncodedFrameInfo;

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

            if (ParamsHelper.Compare<IntPtr>(OnPlaybackAudioEncodedFrame_frameBuffer, frameBuffer) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnPlaybackAudioEncodedFrame_length, length) == false)
                return false;
            if (ParamsHelper.Compare<EncodedAudioFrameInfo>(OnPlaybackAudioEncodedFrame_audioEncodedFrameInfo, audioEncodedFrameInfo) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnMixedAudioEncodedFrame_be_trigger = false;
        public IntPtr OnMixedAudioEncodedFrame_frameBuffer;
        public int OnMixedAudioEncodedFrame_length;
        public EncodedAudioFrameInfo OnMixedAudioEncodedFrame_audioEncodedFrameInfo;

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

            if (ParamsHelper.Compare<IntPtr>(OnMixedAudioEncodedFrame_frameBuffer, frameBuffer) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnMixedAudioEncodedFrame_length, length) == false)
                return false;
            if (ParamsHelper.Compare<EncodedAudioFrameInfo>(OnMixedAudioEncodedFrame_audioEncodedFrameInfo, audioEncodedFrameInfo) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IAudioEncodedFrameObserver
    }
}
