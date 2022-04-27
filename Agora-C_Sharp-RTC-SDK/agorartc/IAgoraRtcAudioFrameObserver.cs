//  IAgoraRtcAudioFrameObserver.cs
//
//  Created by Yiqing Huang on June 9, 2021.
//  Modified by Yiqing Huang on June 9, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

namespace agora.rtc
{
    /**
     * The audio frame observer.
     */
    public abstract class IAgoraRtcAudioFrameObserver
    {
        /**
         * Gets the captured audio frame.
         * @param
         *  audioFrame: The playback audio frame. 
         * @return
         * true: The mixed audio data is valid and is encoded and sent.
         *  false: The mixed audio data is invalid and is not encoded or sent.
         */
        public virtual bool OnRecordAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }

        /**
         * Gtes the audio frame for playback.
         * @param
         *  audioFrame: The playback audio frame. 
         * @return
         * true: The mixed audio data is valid and is encoded and sent.
         *  false: The mixed audio data is invalid and is not encoded or sent.
         */
        public virtual bool OnPlaybackAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }

        /**
         * Retrieves the mixed captured and playback audio frame.
         * This callback only returns the single-channel data.
         * @param
         *  audioFrame: The playback audio frame. 
         * @return
         * true: The mixed audio data is valid and is encoded and sent.
         *  false: The mixed audio data is invalid and is not encoded or sent.
         */
        public virtual bool OnMixedAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }

        /**
         * Retrieves the audio frame of a specified user before mixing.
         * @param
         *  uid: The user ID of the specified user.
         *  audioFrame: The audio frame. 
         * @return
         * true: The mixed audio data is valid and is encoded and sent.
         *  false: The mixed audio data is invalid and is not encoded or sent.
         */
        public virtual bool OnPlaybackAudioFrameBeforeMixing(uint uid, AudioFrame audioFrame)
        {
            return true;
        }

        /**
         * Determines whether to receive audio data from multiple channels.
         * Since
         *  v3.0.1 After you register the audio frame observer, the SDK triggers this callback every time it captures an audio frame.
         *  In the multi-channel scenario, if you want to get audio data from multiple channels, set the return value of this callback as true. After that, the SDK triggers the OnPlaybackAudioFrameBeforeMixingEx callback to send you the before-mixing audio frame from various channels. You can also get the channel ID of each audio frame. Once you set the return value of the callback as true, the SDK triggers only the OnPlaybackAudioFrameBeforeMixingEx callback to send the audio data. OnPlaybackAudioFrameBeforeMixing will not be triggered. In the multi-channel scenario, Agora recommends setting the return value as true.
         *  If you set the return value of this callback as false, the SDK triggers only the OnPlaybackAudioFrameBeforeMixing callback to send the audio data.
         * @return
         * true: Receive audio data from multiple channels.
         *  false: Do not receive audio data from multiple channels.
         */
        public virtual bool IsMultipleChannelFrameWanted()
        {
            return true;
        }

        /**
         * Gets the before-mixing playback audio frame from multiple channels.
         * After you successfully register the audio frame observer, if you set the return value of IsMultipleChannelFrameWanted as true, the SDK triggers this callback each time it receives an audio frame from any of the channels.
         * @param
         *  channelId: The channel name of this audio frame.
         *  uid: The ID of the user sending the audio frame.
         *  audioFrame: playback audio frame. 
         * @return
         * true: Valid buffer in AudioFrame, and the captured audio frame is sent out.
         *  false: Invalid buffer in AudioFrame, and the captured audio frame is discarded.
         */
        public virtual bool OnPlaybackAudioFrameBeforeMixingEx(string channelId, uint uid, AudioFrame audioFrame)
        {
            return true;
        }
    }
}
