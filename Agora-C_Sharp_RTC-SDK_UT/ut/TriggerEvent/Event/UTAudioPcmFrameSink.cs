using System;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    public class UTIAudioPcmFrameSink : IAudioPcmFrameSink
    {
        #region terra IAudioPcmFrameSink
        public bool OnFrame_be_trigger = false;
        public AudioPcmFrame OnFrame_frame;

        public override void OnFrame(AudioPcmFrame frame)
        {
            OnFrame_be_trigger = true;
            OnFrame_frame = frame;

        }

        public bool OnFramePassed(AudioPcmFrame frame)
        {

            if (OnFrame_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<AudioPcmFrame>(OnFrame_frame, frame) == false)
            //return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IAudioPcmFrameSink
    }
}
