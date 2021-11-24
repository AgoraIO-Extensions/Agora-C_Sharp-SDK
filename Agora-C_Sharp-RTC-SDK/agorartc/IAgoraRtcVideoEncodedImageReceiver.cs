//  IAgoraRtcVideoEncodedImageReceiver.cs
//
//  Created by YuGuo Chen on October 6, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    public class IAgoraRtcVideoEncodedImageReceiver
    {
        public virtual bool OnEncodedVideoImageReceived(byte[] imageBuffer, UInt64 length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
    }
}