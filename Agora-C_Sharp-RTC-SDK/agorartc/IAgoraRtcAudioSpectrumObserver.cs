using System;

namespace agora.rtc
{
    public class IAgoraRtcAudioSpectrumObserver
    {

        /**
         * Reports the audio spectrum of local audio.
         *
         * This callback reports the audio spectrum data of the local audio at the moment
         * in the channel.
         *
         * You can set the time interval of this callback using \ref ILocalUser::enableAudioSpectrumMonitor "enableAudioSpectrumMonitor".
         *
         * @param data The audio spectrum data of local audio.
         * - true: Processed.
         * - false: Not processed.
         */
        public virtual bool onLocalAudioSpectrum(AudioSpectrumData data)
        {
            return true;
        }

        /**
        * Reports the audio spectrum of remote user.
        *
        * This callback reports the IDs and audio spectrum data of the loudest speakers at the moment
        * in the channel.
        *
        * You can set the time interval of this callback using \ref ILocalUser::enableAudioSpectrumMonitor "enableAudioSpectrumMonitor".
        *
        * @param spectrums The pointer to \ref agora::media::UserAudioSpectrumInfo "UserAudioSpectrumInfo", which is an array containing
        * the user ID and audio spectrum data for each speaker.
        * - This array contains the following members:
        *   - `uid`, which is the UID of each remote speaker
        *   - `spectrumData`, which reports the audio spectrum of each remote speaker.
        * @param spectrumNumber The array length of the spectrums.
        * - true: Processed.
        * - false: Not processed.
        */
        public virtual bool onRemoteAudioSpectrum(UserAudioSpectrumInfo spectrums, uint spectrumNumber)
        {
            return true;
        }
    }
}
