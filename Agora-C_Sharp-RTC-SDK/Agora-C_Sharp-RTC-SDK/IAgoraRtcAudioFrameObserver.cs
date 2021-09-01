//  IAgoraRtcAudioFrameObserver.cs
//
//  Created by Yiqing Huang on June 9, 2021.
//  Modified by Yiqing Huang on June 9, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

namespace agora.rtc
{
    public abstract class IAgoraRtcAudioFrameObserver
    {
        public virtual bool OnRecordAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool OnMixedAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixing(uint uid, AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool IsMultipleChannelFrameWanted()
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixingEx(string channelId, uint uid, AudioFrame audioFrame)
        {
            return true;
        }
    }
}