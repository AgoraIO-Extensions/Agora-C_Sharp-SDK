namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Used for recording audio and video on the client.
    /// IMediaRecorder can record the following:
    /// The audio captured by the local microphone and encoded in AAC format.The video captured by the local camera and encoded by the SDK.
    /// </summary>
    ///
    public abstract class IMediaRecorder
    {
        ///
        /// <summary>
        /// Registers one IMediaRecorderObserver object.
        /// Make sure the IRtcEngine is initialized before you call this method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="callback"> The callbacks for recording local audio and video streams. See IMediaRecorderObserver .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetMediaRecorderObserver(RtcConnection connection, IMediaRecorderObserver callback);

        ///
        /// <summary>
        /// Starts recording the local audio and video.
        /// After successfully getting the IMediaRecorder object by calling GetMediaRecorder , you can call this method to enable the recoridng of the local audio and video.This method can record the audio captured by the local microphone and encoded in AAC format, and the video captured by the local camera and encoded in H.264 format. The SDK can generate a recording file only when it detects audio and video streams; when there are no audio and video streams to be recorded or the audio and video streams are interrupted for more than five seconds, the SDK stops the recording and triggers the OnRecorderStateChanged(RECORDER_STATE_ERROR, RECORDER_ERROR_NO_STREAM) callback.Once the recording is started, if the video resolution is changed, the SDK stops the recording; if the sampling rate and audio channel changes, the SDK continues recording and generates audio files respectively.Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="config"> The recording configuration. See MediaRecorderConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.2: The parameter is invalid. Ensure the following:The specified path of the recording file exists and is writable.The specified format of the recording file is supported.The maximum recording duration is correctly set.4: IRtcEngine does not support the request. The recording is ongoing or the recording stops because an error occurs.7: A method is called before IRtcEngine is initialized.
        /// </returns>
        ///
        public abstract int StartRecording(RtcConnection connection, MediaRecorderConfiguration config);

        ///
        /// <summary>
        /// Stops recording the local audio and video.
        /// After calling StartRecording , if you want to stop the recording, you must call this method; otherwise, the generated recording files may not be playable.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-7: A method is called before IRtcEngine is initialized.
        /// </returns>
        ///
        public abstract int StopRecording(RtcConnection connection);
    };
}