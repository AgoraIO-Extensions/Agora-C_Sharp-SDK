#region Generated by `terra/node/src/rtc/ut/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

using System;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    public partial class UTAudioPcmFrameSink : IAudioPcmFrameSink
    {
        public bool OnFrame_95f515a_be_trigger = false;
        public AudioPcmFrame OnFrame_95f515a_frame;

        public override void OnFrame(AudioPcmFrame frame)
        {
            OnFrame_95f515a_be_trigger = true;
            OnFrame_95f515a_frame = frame;
        }

        public bool OnFramePassed(AudioPcmFrame frame)
        {
            if (OnFrame_95f515a_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<AudioPcmFrame>(OnFrame_95f515a_frame, frame) == false)
                return false;

            return true;
        }

        /////////////////////////////////

    }
}