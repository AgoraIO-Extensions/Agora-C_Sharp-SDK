using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMediaPlayerAudioFrameObserver: IMediaPlayerAudioFrameObserver
    {


        public bool OnFrame_be_trigger = false;
        public AudioPcmFrame OnFrame_frame = null;

        public override bool OnFrame(AudioPcmFrame frame)
        {
            OnFrame_be_trigger = true;
            OnFrame_frame = frame;
            return true;
        }

        public bool OnFramePassed(AudioPcmFrame frame)
        {
            if (OnFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareAudioPcmFrame(OnFrame_frame, frame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
