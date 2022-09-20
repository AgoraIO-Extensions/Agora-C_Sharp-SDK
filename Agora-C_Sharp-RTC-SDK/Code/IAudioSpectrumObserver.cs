namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The audio spectrum observer.
    /// </summary>
    ///
    public abstract class IAudioSpectrumObserver
    {
        ///
        /// <summary>
        /// Gets the statistics of a local audio spectrum.
        /// After successfully calling RegisterAudioSpectrumObserver to implement the OnLocalAudioSpectrum callback in IAudioSpectrumObserver and calling EnableAudioSpectrumMonitor to enable audio spectrum monitoring, the SDK will trigger the callback as the time interval you set to report the received remote audio data spectrum.
        /// </summary>
        ///
        /// <param name="data"> The audio spectrum data of the local user. See AudioSpectrumData .</param>
        ///
        /// <returns>
        /// Whether you have received the spectrum data:true: Spectrum data is received.false: No spectrum data is received.
        /// </returns>
        ///
        public virtual bool OnLocalAudioSpectrum(AudioSpectrumData data)
        {
            return true;
        }

        ///
        /// <summary>
        /// Gets the remote audio spectrum.
        /// After successfully calling RegisterAudioSpectrumObserver to implement the OnRemoteAudioSpectrum callback in the IAudioSpectrumObserver and calling EnableAudioSpectrumMonitor to enable audio spectrum monitoring, the SDK will trigger the callback as the time interval you set to report the received remote audio data spectrum.
        /// </summary>
        ///
        /// <param name="spectrums"> The audio spectrum information of the remote user, see UserAudioSpectrumInfo . The number of arrays is the number of remote users monitored by the SDK. If the array is null, it means that no audio spectrum of remote users is detected.</param>
        ///
        /// <param name="spectrumNumber"> The number of remote users.</param>
        ///
        /// <returns>
        /// Whether you have received the spectrum data:true: Spectrum data is received.false: No spectrum data is received.
        /// </returns>
        ///
        public virtual bool OnRemoteAudioSpectrum(UserAudioSpectrumInfo[] spectrums, uint spectrumNumber)
        {
            return true;
        }
    }
}