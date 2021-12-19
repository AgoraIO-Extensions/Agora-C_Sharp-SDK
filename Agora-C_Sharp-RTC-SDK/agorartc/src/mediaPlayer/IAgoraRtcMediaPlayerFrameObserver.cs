//  IAgoraRtcMediaPlayerFrameObserver.cs
//
//  Created by YuGuo Chen on December 14, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    public class IAgoraRtcMediaPlayerAudioFrameObserver
    {
        public virtual bool OnFrame(AudioPcmFrame videoFrame, int mediaPlayerId)
        {
            return true;
        }
    }

    public class IAgoraRtcMediaPlayerVideoFrameObserver
    {
        public virtual bool OnFrame(VideoFrame audioFrame, VideoFrameBufferConfig config)
        {
            return true;
        }
    }

    public class IAgoraRtcMediaPlayerCustomDataProvider
    {
        public virtual Int64 OnSeek(Int64 offset, int whence, int playerId)
        {
            return 0;
        }

        public virtual int OnReadData(byte[] buffer, int bufferSize, int playerId)
        {
            return 0;
        }
    }
}