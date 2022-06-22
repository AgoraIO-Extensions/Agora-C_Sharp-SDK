﻿using System;

namespace Agora.Rtc
{
    public abstract class IAudioEncodedFrameObserver
    {
        public virtual void OnRecordAudioEncodedFrame(IntPtr frameBufferPtr, int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }

        public virtual void OnPlaybackAudioEncodedFrame(IntPtr frameBufferPtr, int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }

        public virtual void OnMixedAudioEncodedFrame(IntPtr frameBufferPtr, int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }
    };
}