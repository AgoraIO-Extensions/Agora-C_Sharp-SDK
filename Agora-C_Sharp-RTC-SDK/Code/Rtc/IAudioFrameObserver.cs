namespace Agora.Rtc
{
    /* class_iaudioframeobserver */
    public abstract class IAudioFrameObserver
    {

#region terra IAudioFrameObserver

        /* callback_iaudioframeobserver_onrecordaudioframe */
        public virtual bool OnRecordAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        /* callback_iaudioframeobserver_onplaybackaudioframe */
        public virtual bool OnPlaybackAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        /* callback_iaudioframeobserver_onmixedaudioframe */
        public virtual bool OnMixedAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        /* callback_iaudioframeobserver_onearmonitoringaudioframe */
        public virtual bool OnEarMonitoringAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }

        /* callback_iaudioframeobserver_onplaybackaudioframebeforemixing */
        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId, string userId, AudioFrame audioFrame)
        {
            return true;
        }

        /* callback_iaudioframeobserver_onplaybackaudioframebeforemixing2 */
        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame audioFrame)
        {
            return true;
        }
#endregion terra IAudioFrameObserver
    }

}