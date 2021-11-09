//  IAgoraRtcAudioFrameObserver.cs
//
//  Created by YuGuo Chen on October 6, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    public class IAgoraRtcAudioFrameObserver
    {
        public virtual bool OnRecordAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrame(AudioFrame audio_frame)
        {
            return true;
        }

        public virtual bool OnMixedAudioFrame(AudioFrame audio_frame)
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixing(uint uid, AudioFrame audio_frame)
        {
            return true;
        }

        public virtual bool IsMultipleChannelFrameWanted()
        { 
            return true; 
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixingEx(string channel_id,
                                                        uint uid,
                                                        AudioFrame audio_frame)
        {
            return false;
        }
    }

    public class IAgoraRtcAudioEncodedFrameObserver
    {
        public virtual void OnRecordAudioEncodedFrame(uint frameBuffer,  int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }

        public virtual void OnPlaybackAudioEncodedFrame(uint frameBuffer,  int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }

        public virtual void OnMixedAudioEncodedFrame(uint frameBuffer,  int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }
    };
}