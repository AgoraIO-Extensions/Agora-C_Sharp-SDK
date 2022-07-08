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
        /// After successfully calling RegisterAudioSpectrumObserver to implement the OnLocalAudioSpectrum in IAudioSpectrumObserver and calling EnableAudioSpectrumMonitor to enable audio spectrum monitoring, the SDK will trigger the callback as the time interval you set to report the received remote audio data spectrum.
        /// </summary>
        ///
        /// <param name="data"> The audio spectrum data of the local user. See AudioSpectrumData .</param>
        ///
        /// <returns>
        /// Whether you have received the spectrum data:
        /// true: Spectrum data is received.
        /// false: No spectrum data is received.
        /// </returns>
        ///
        public virtual bool OnLocalAudioSpectrum(AudioSpectrumData data)
        {
            return true;
        }

        ///
        /// <summary>
        /// Gets the remote audio spectrum.
        /// 成功调用 RegisterAudioSpectrumObserver 实现 IAudioSpectrumObserver 中的 OnRemoteAudioSpectrum 回调并调用 EnableAudioSpectrumMonitor 开启音频频谱监测后，SDK 会按照你设置的时间间隔触发该回调，报告接收到的远端音频数据的频谱。
        /// </summary>
        ///
        /// <param name="spectrums"> For the audio spectrum information of the remote user, see UserAudioSpectrumInfo . The number of arrays is equal to the number of remote users monitored by the SDK. If the array is empty, it means that the audio spectrum of the remote users is not detected.</param>
        ///
        /// <param name="spectrumNumber"> The number of remote users.</param>
        ///
        /// <returns>
        /// Whether you have received the spectrum data:
        /// true: Spectrum data is received.
        /// false: No spectrum data is received.
        /// </returns>
        ///
        public virtual bool OnRemoteAudioSpectrum(UserAudioSpectrumInfo[] spectrums, uint spectrumNumber)
        {
            return true;
        }
    }
}