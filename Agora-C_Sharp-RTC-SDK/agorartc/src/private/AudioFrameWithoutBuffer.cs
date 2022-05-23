using System;
namespace agora.rtc
{
    internal class AudioFrameWithoutBuffer
    {
        public AudioFrameWithoutBuffer()
        {
        }

        public AudioFrameWithoutBuffer(AUDIO_FRAME_TYPE type, int samples, BYTES_PER_SAMPLE bytesPerSample, int channels,
            int samplesPerSec, long renderTimeMs, int avsync_type)
        {
            this.type = type;
            this.samples = samples;
            this.bytesPerSample = bytesPerSample;
            this.channels = channels;
            this.samplesPerSec = samplesPerSec;
            this.renderTimeMs = renderTimeMs;
            this.avsync_type = avsync_type;
        }

        /** The type of the audio frame. See #AUDIO_FRAME_TYPE
		 */
        public AUDIO_FRAME_TYPE type { set; get; }

        /** The number of samples per channel in the audio frame.
		 */
        public int samples { set; get; } //number of samples for each channel in this frame

        /**The number of bytes per audio sample, which is usually 16-bit (2-byte).
		 */
        public BYTES_PER_SAMPLE bytesPerSample { set; get; } //number of bytes per sample: 2 for PCM16

        /** The number of audio channels.
		 - 1: Mono
		 - 2: Stereo (the data is interleaved)
		 */
        public int channels { set; get; } //number of channels (data are interleaved if stereo)

        /** The sample rate.
		 */
        public int samplesPerSec { set; get; } //sampling rate

        /** The timestamp of the external audio frame. You can use this parameter for the following purposes:
		 - Restore the order of the captured audio frame.
		 - Synchronize audio and video frames in video-related scenarios, including where external video sources are used.
		 */
        public long renderTimeMs { set; get; }

        /** Reserved parameter.
		 */
        public int avsync_type { set; get; }
    }

}
