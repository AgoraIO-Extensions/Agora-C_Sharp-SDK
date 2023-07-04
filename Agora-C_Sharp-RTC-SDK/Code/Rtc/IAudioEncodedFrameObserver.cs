using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The encoded audio observer.
    /// </summary>
    ///
    public abstract class IAudioEncodedFrameObserver
    {
        ///
        /// <summary>
        /// Gets the encoded audio data of the local user.
        /// After calling RegisterAudioEncodedFrameObserver and setting the encoded audio as AUDIO_ENCODED_FRAME_OBSERVER_POSITION_RECORD, you can get the encoded audio data of the local user from this callback.
        /// </summary>
        ///
        /// <param name="frameBufferPtr"> The audio buffer.</param>
        ///
        /// <param name="length"> The data length (byte).</param>
        ///
        /// <param name="audioEncodedFrameInfo"> Audio information after encoding. See EncodedAudioFrameInfo .</param>
        ///
        public virtual void OnRecordAudioEncodedFrame(IntPtr frameBufferPtr, int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }

        ///
        /// <summary>
        /// Gets the encoded audio data of all remote users.
        /// After calling RegisterAudioEncodedFrameObserver and setting the encoded audio as AUDIO_ENCODED_FRAME_OBSERVER_POSITION_PLAYBACK, you can get encoded audio data of all remote users through this callback.
        /// </summary>
        ///
        /// <param name="frameBufferPtr"> The audio buffer.</param>
        ///
        /// <param name="length"> The data length (byte).</param>
        ///
        /// <param name="audioEncodedFrameInfo"> Audio information after encoding. See EncodedAudioFrameInfo .</param>
        ///
        public virtual void OnPlaybackAudioEncodedFrame(IntPtr frameBufferPtr, int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }

        ///
        /// <summary>
        /// Gets the mixed and encoded audio data of the local and all remote users.
        /// After calling RegisterAudioEncodedFrameObserver and setting the audio profile as AUDIO_ENCODED_FRAME_OBSERVER_POSITION_MIXED, you can get the mixed and encoded audio data of the local and all remote users through this callback.
        /// </summary>
        ///
        /// <param name="frameBufferPtr"> The audio buffer.</param>
        ///
        /// <param name="length"> The data length (byte).</param>
        ///
        /// <param name="audioEncodedFrameInfo"> Audio information after encoding. See EncodedAudioFrameInfo .</param>
        ///
        public virtual void OnMixedAudioEncodedFrame(IntPtr frameBufferPtr, int length, 
                                                    EncodedAudioFrameInfo audioEncodedFrameInfo)
        {

        }
    };
}