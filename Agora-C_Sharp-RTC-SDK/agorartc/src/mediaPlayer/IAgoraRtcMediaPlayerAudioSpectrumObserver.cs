//  IAgoraRtcMediaPlayerAudioSpectrumObserver.cs
//
//  Created by YuGuo Chen on May 12, 2022.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    public class IAgoraRtcMediaPlayerAudioSpectrumObserver
    {
        public virtual bool OnLocalAudioSpectrum(AudioSpectrumData data)
        {
            return true;
        }

        public virtual bool OnRemoteAudioSpectrum(UserAudioSpectrumInfo[] spectrums, uint spectrumNumber)
        {
            return true;
        }
    }
}