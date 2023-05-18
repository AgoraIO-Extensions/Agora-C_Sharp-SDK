namespace Agora.Rtc
{
    ///
    /// <summary>
    /// This class provides APIs for local and remote recording.
    /// </summary>
    ///
    public abstract class IMediaRecorder
    {
        ///
        /// <summary>
        /// Registers one IMediaRecorderObserver oberver.
        /// This method is used to set the callbacks of audio and video recording, so as to notify the app of the recording status and information of the audio and video stream during recording.Before calling this method, ensure the following:The IRtcEngine object is created and initialized.The recording object is created through CreateMediaRecorder .
        /// </summary>
        ///
        /// <param name="callback"> The callbacks for recording audio and video streams. See IMediaRecorderObserver .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetMediaRecorderObserver(IMediaRecorderObserver callback);

        ///
        /// <summary>
        /// Starts recording audio and video streams.
        /// You can call this method to enable the recording function. Agora supports recording the media streams of local and remote users at the same time.Before you call this method, ensure the following:The recording object is created through CreateMediaRecorder .The recording observer is registered through SetMediaRecorderObserver .You have joined the channel which the remote user that you want to record is in.Supported formats of recording are listed as below:AAC-encoded audio captured by the microphone.Video captured by a camera and encoded in H.264 or H.265.Once the recording is started, if the video resolution is changed, the SDK stops the recording; if the sampling rate and audio channel changes, the SDK continues recording and generates audio files respectively.The SDK can generate a recording file only when it detects audio and video streams; when there are no audio and video streams to be recorded or the audio and video streams are interrupted for more than five seconds, the SDK stops the recording and triggers the OnRecorderStateChanged(RECORDER_STATE_ERROR, RECORDER_ERROR_NO_STREAM) callback.If you want to record the media streams of the local user, ensure the role of the local user is set as broadcaster.If you want to record the media streams of a remote user, ensure you have subscribed to the user's media streams before starting the recording.
        /// </summary>
        ///
        /// <param name="config"> The recording configuration. See MediaRecorderConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid. Ensure the following:The specified path of the recording file exists and is writable.The specified format of the recording file is supported.The maximum recording duration is correctly set.-4: IRtcEngine does not support the request. The recording is ongoing or the recording stops because an error occurs.-7: The method is called before IRtcEngine is initialized. Ensure the IMediaRecorder object is created before calling this method.
        /// </returns>
        ///
        public abstract int StartRecording(MediaRecorderConfiguration config);

        ///
        /// <summary>
        /// Stops recording audio and video streams.
        /// After calling StartRecording , if you want to stop the recording, you must call this method; otherwise, the generated recording files may not be playable.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-7: The method is called before IRtcEngine is initialized. Ensure the IMediaRecorder object is created before calling this method.
        /// </returns>
        ///
        public abstract int StopRecording();
    };
}