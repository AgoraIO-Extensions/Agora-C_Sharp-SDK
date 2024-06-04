using System;
using view_t = System.UInt64;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
{
    #region terra IAgoraRtcEngine.h
    ///
    /// <summary>
    /// Media device types.
    /// </summary>
    ///
    public enum MEDIA_DEVICE_TYPE
    {
        ///
        /// <summary>
        /// -1: Unknown device type.
        /// </summary>
        ///
        UNKNOWN_AUDIO_DEVICE = -1,

        ///
        /// <summary>
        /// 0: Audio playback device.
        /// </summary>
        ///
        AUDIO_PLAYOUT_DEVICE = 0,

        ///
        /// <summary>
        /// 1: Audio capturing device.
        /// </summary>
        ///
        AUDIO_RECORDING_DEVICE = 1,

        ///
        /// <summary>
        /// 2: Video rendering device (graphics card).
        /// </summary>
        ///
        VIDEO_RENDER_DEVICE = 2,

        ///
        /// <summary>
        /// 3: Video capturing device.
        /// </summary>
        ///
        VIDEO_CAPTURE_DEVICE = 3,

        ///
        /// <summary>
        /// 4: Audio playback device for an app.
        /// </summary>
        ///
        AUDIO_APPLICATION_PLAYOUT_DEVICE = 4,

        ///
        /// <summary>
        /// (For macOS only) 5: Virtual audio playback device (virtual sound card).
        /// </summary>
        ///
        AUDIO_VIRTUAL_PLAYOUT_DEVICE = 5,

        ///
        /// <summary>
        /// (For macOS only) 6: Virtual audio capturing device (virtual sound card).
        /// </summary>
        ///
        AUDIO_VIRTUAL_RECORDING_DEVICE = 6,
    }

    ///
    /// <summary>
    /// The playback state of the music file.
    /// </summary>
    ///
    public enum AUDIO_MIXING_STATE_TYPE
    {
        ///
        /// <summary>
        /// 710: The music file is playing.
        /// </summary>
        ///
        AUDIO_MIXING_STATE_PLAYING = 710,

        ///
        /// <summary>
        /// 711: The music file pauses playing.
        /// </summary>
        ///
        AUDIO_MIXING_STATE_PAUSED = 711,

        ///
        /// <summary>
        /// 713: The music file stops playing. The possible reasons include: AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED (723) AUDIO_MIXING_REASON_STOPPED_BY_USER (724)
        /// </summary>
        ///
        AUDIO_MIXING_STATE_STOPPED = 713,

        ///
        /// <summary>
        /// 714: An error occurs during the playback of the audio mixing file. The possible reasons include: AUDIO_MIXING_REASON_CAN_NOT_OPEN (701) AUDIO_MIXING_REASON_TOO_FREQUENT_CALL (702) AUDIO_MIXING_REASON_INTERRUPTED_EOF (703)
        /// </summary>
        ///
        AUDIO_MIXING_STATE_FAILED = 714,
    }

    ///
    /// <summary>
    /// The reason why the playback state of the music file changes. Reported in the OnAudioMixingStateChanged callback.
    /// </summary>
    ///
    public enum AUDIO_MIXING_REASON_TYPE
    {
        ///
        /// <summary>
        /// 701: The SDK cannot open the music file. For example, the local music file does not exist, the SDK does not support the file format, or the the SDK cannot access the music file URL.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_CAN_NOT_OPEN = 701,

        ///
        /// <summary>
        /// 702: The SDK opens the music file too frequently. If you need to call startAudioMixing multiple times, ensure that the call interval is more than 500 ms.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_TOO_FREQUENT_CALL = 702,

        ///
        /// <summary>
        /// 703: The music file playback is interrupted.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_INTERRUPTED_EOF = 703,

        ///
        /// <summary>
        /// 721: The music file completes a loop playback.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_ONE_LOOP_COMPLETED = 721,

        ///
        /// <summary>
        /// 723: The music file completes all loop playback.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED = 723,

        ///
        /// <summary>
        /// 724: Successfully call StopAudioMixing to stop playing the music file.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_STOPPED_BY_USER = 724,

        ///
        /// <summary>
        /// 0: The SDK opens music file successfully.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_OK = 0,
    }

    ///
    /// @ignore
    ///
    public enum INJECT_STREAM_STATUS
    {
        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_START_SUCCESS = 0,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_START_ALREADY_EXISTS = 1,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_START_UNAUTHORIZED = 2,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_START_TIMEDOUT = 3,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_START_FAILED = 4,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_STOP_SUCCESS = 5,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_STOP_NOT_FOUND = 6,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_STOP_UNAUTHORIZED = 7,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_STOP_TIMEDOUT = 8,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_STOP_FAILED = 9,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_BROKEN = 10,
    }

    ///
    /// <summary>
    /// The midrange frequency for audio equalization.
    /// </summary>
    ///
    public enum AUDIO_EQUALIZATION_BAND_FREQUENCY
    {
        ///
        /// <summary>
        /// 0: 31 Hz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_31 = 0,

        ///
        /// <summary>
        /// 1: 62 Hz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_62 = 1,

        ///
        /// <summary>
        /// 2: 125 Hz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_125 = 2,

        ///
        /// <summary>
        /// 3: 250 Hz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_250 = 3,

        ///
        /// <summary>
        /// 4: 500 Hz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_500 = 4,

        ///
        /// <summary>
        /// 5: 1 kHz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_1K = 5,

        ///
        /// <summary>
        /// 6: 2 kHz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_2K = 6,

        ///
        /// <summary>
        /// 7: 4 kHz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_4K = 7,

        ///
        /// <summary>
        /// 8: 8 kHz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_8K = 8,

        ///
        /// <summary>
        /// 9: 16 kHz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_16K = 9,
    }

    ///
    /// <summary>
    /// Audio reverberation types.
    /// </summary>
    ///
    public enum AUDIO_REVERB_TYPE
    {
        ///
        /// <summary>
        /// 0: The level of the dry signal (dB). The value is between -20 and 10.
        /// </summary>
        ///
        AUDIO_REVERB_DRY_LEVEL = 0,

        ///
        /// <summary>
        /// 1: The level of the early reflection signal (wet signal) (dB). The value is between -20 and 10.
        /// </summary>
        ///
        AUDIO_REVERB_WET_LEVEL = 1,

        ///
        /// <summary>
        /// 2: The room size of the reflection. The value is between 0 and 100.
        /// </summary>
        ///
        AUDIO_REVERB_ROOM_SIZE = 2,

        ///
        /// <summary>
        /// 3: The length of the initial delay of the wet signal (ms). The value is between 0 and 200.
        /// </summary>
        ///
        AUDIO_REVERB_WET_DELAY = 3,

        ///
        /// <summary>
        /// 4: The reverberation strength. The value is between 0 and 100.
        /// </summary>
        ///
        AUDIO_REVERB_STRENGTH = 4,
    }

    ///
    /// <summary>
    /// Options for handling audio and video stream fallback when network conditions are weak.
    /// </summary>
    ///
    public enum STREAM_FALLBACK_OPTIONS
    {
        ///
        /// <summary>
        /// 0: No fallback processing is performed on audio and video streams, the quality of the audio and video streams cannot be guaranteed.
        /// </summary>
        ///
        STREAM_FALLBACK_OPTION_DISABLED = 0,

        ///
        /// <summary>
        /// 1: Only receive low-quality (low resolution, low bitrate) video stream.
        /// </summary>
        ///
        STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW = 1,

        ///
        /// <summary>
        /// 2: When the network conditions are weak, try to receive the low-quality video stream first. If the video cannot be displayed due to extremely weak network environment, then fall back to receiving audio-only stream.
        /// </summary>
        ///
        STREAM_FALLBACK_OPTION_AUDIO_ONLY = 2,
    }

    ///
    /// @ignore
    ///
    public enum PRIORITY_TYPE
    {
        ///
        /// @ignore
        ///
        PRIORITY_HIGH = 50,

        ///
        /// @ignore
        ///
        PRIORITY_NORMAL = 100,
    }

    ///
    /// <summary>
    /// The statistics of the local video stream.
    /// </summary>
    ///
    public class LocalVideoStats
    {
        ///
        /// <summary>
        /// The ID of the local user.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// The actual bitrate (Kbps) while sending the local video stream. This value does not include the bitrate for resending the video after packet loss.
        /// </summary>
        ///
        public int sentBitrate;

        ///
        /// <summary>
        /// The actual frame rate (fps) while sending the local video stream. This value does not include the frame rate for resending the video after packet loss.
        /// </summary>
        ///
        public int sentFrameRate;

        ///
        /// <summary>
        /// The frame rate (fps) for capturing the local video stream.
        /// </summary>
        ///
        public int captureFrameRate;

        ///
        /// <summary>
        /// The width (px) for capturing the local video stream.
        /// </summary>
        ///
        public int captureFrameWidth;

        ///
        /// <summary>
        /// The height (px) for capturing the local video stream.
        /// </summary>
        ///
        public int captureFrameHeight;

        ///
        /// <summary>
        /// The frame rate (fps) adjusted by the built-in video capture adapter (regulator) of the SDK for capturing the local video stream. The regulator adjusts the frame rate of the video captured by the camera according to the video encoding configuration.
        /// </summary>
        ///
        public int regulatedCaptureFrameRate;

        ///
        /// <summary>
        /// The width (px) adjusted by the built-in video capture adapter (regulator) of the SDK for capturing the local video stream. The regulator adjusts the height and width of the video captured by the camera according to the video encoding configuration.
        /// </summary>
        ///
        public int regulatedCaptureFrameWidth;

        ///
        /// <summary>
        /// The height (px) adjusted by the built-in video capture adapter (regulator) of the SDK for capturing the local video stream. The regulator adjusts the height and width of the video captured by the camera according to the video encoding configuration.
        /// </summary>
        ///
        public int regulatedCaptureFrameHeight;

        ///
        /// <summary>
        /// The output frame rate (fps) of the local video encoder.
        /// </summary>
        ///
        public int encoderOutputFrameRate;

        ///
        /// <summary>
        /// The width of the encoded video (px).
        /// </summary>
        ///
        public int encodedFrameWidth;

        ///
        /// <summary>
        /// The height of the encoded video (px).
        /// </summary>
        ///
        public int encodedFrameHeight;

        ///
        /// <summary>
        /// The output frame rate (fps) of the local video renderer.
        /// </summary>
        ///
        public int rendererOutputFrameRate;

        ///
        /// <summary>
        /// The target bitrate (Kbps) of the current encoder. This is an estimate made by the SDK based on the current network conditions.
        /// </summary>
        ///
        public int targetBitrate;

        ///
        /// <summary>
        /// The target frame rate (fps) of the current encoder.
        /// </summary>
        ///
        public int targetFrameRate;

        ///
        /// <summary>
        /// The quality adaptation of the local video stream in the reported interval (based on the target frame rate and target bitrate). See QUALITY_ADAPT_INDICATION.
        /// </summary>
        ///
        public QUALITY_ADAPT_INDICATION qualityAdaptIndication;

        ///
        /// <summary>
        /// The bitrate (Kbps) while encoding the local video stream. This value does not include the bitrate for resending the video after packet loss.
        /// </summary>
        ///
        public int encodedBitrate;

        ///
        /// <summary>
        /// The number of the sent video frames, represented by an aggregate value.
        /// </summary>
        ///
        public int encodedFrameCount;

        ///
        /// <summary>
        /// The codec type of the local video. See VIDEO_CODEC_TYPE.
        /// </summary>
        ///
        public VIDEO_CODEC_TYPE codecType;

        ///
        /// <summary>
        /// The video packet loss rate (%) from the local client to the Agora server before applying the anti-packet loss strategies.
        /// </summary>
        ///
        public ushort txPacketLossRate;

        ///
        /// <summary>
        /// The brightness level of the video image captured by the local camera. See CAPTURE_BRIGHTNESS_LEVEL_TYPE.
        /// </summary>
        ///
        public CAPTURE_BRIGHTNESS_LEVEL_TYPE captureBrightnessLevel;

        ///
        /// @ignore
        ///
        public bool dualStreamEnabled;

        ///
        /// <summary>
        /// The local video encoding acceleration type.
        ///  0: Software encoding is applied without acceleration.
        ///  1: Hardware encoding is applied for acceleration.
        /// </summary>
        ///
        public int hwEncoderAccelerating;

        public LocalVideoStats(uint uid, int sentBitrate, int sentFrameRate, int captureFrameRate, int captureFrameWidth, int captureFrameHeight, int regulatedCaptureFrameRate, int regulatedCaptureFrameWidth, int regulatedCaptureFrameHeight, int encoderOutputFrameRate, int encodedFrameWidth, int encodedFrameHeight, int rendererOutputFrameRate, int targetBitrate, int targetFrameRate, QUALITY_ADAPT_INDICATION qualityAdaptIndication, int encodedBitrate, int encodedFrameCount, VIDEO_CODEC_TYPE codecType, ushort txPacketLossRate, CAPTURE_BRIGHTNESS_LEVEL_TYPE captureBrightnessLevel, bool dualStreamEnabled, int hwEncoderAccelerating)
        {
            this.uid = uid;
            this.sentBitrate = sentBitrate;
            this.sentFrameRate = sentFrameRate;
            this.captureFrameRate = captureFrameRate;
            this.captureFrameWidth = captureFrameWidth;
            this.captureFrameHeight = captureFrameHeight;
            this.regulatedCaptureFrameRate = regulatedCaptureFrameRate;
            this.regulatedCaptureFrameWidth = regulatedCaptureFrameWidth;
            this.regulatedCaptureFrameHeight = regulatedCaptureFrameHeight;
            this.encoderOutputFrameRate = encoderOutputFrameRate;
            this.encodedFrameWidth = encodedFrameWidth;
            this.encodedFrameHeight = encodedFrameHeight;
            this.rendererOutputFrameRate = rendererOutputFrameRate;
            this.targetBitrate = targetBitrate;
            this.targetFrameRate = targetFrameRate;
            this.qualityAdaptIndication = qualityAdaptIndication;
            this.encodedBitrate = encodedBitrate;
            this.encodedFrameCount = encodedFrameCount;
            this.codecType = codecType;
            this.txPacketLossRate = txPacketLossRate;
            this.captureBrightnessLevel = captureBrightnessLevel;
            this.dualStreamEnabled = dualStreamEnabled;
            this.hwEncoderAccelerating = hwEncoderAccelerating;
        }
        public LocalVideoStats()
        {
        }

    }

    ///
    /// <summary>
    /// Audio statistics of the remote user.
    /// </summary>
    ///
    public class RemoteAudioStats
    {
        ///
        /// <summary>
        /// The user ID of the remote user.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// The quality of the audio stream sent by the user. See QUALITY_TYPE.
        /// </summary>
        ///
        public int quality;

        ///
        /// <summary>
        /// The network delay (ms) from the sender to the receiver.
        /// </summary>
        ///
        public int networkTransportDelay;

        ///
        /// <summary>
        /// The network delay (ms) from the audio receiver to the jitter buffer. When the receiving end is an audience member and audienceLatencyLevel of ClientRoleOptions is 1, this parameter does not take effect.
        /// </summary>
        ///
        public int jitterBufferDelay;

        ///
        /// <summary>
        /// The frame loss rate (%) of the remote audio stream in the reported interval.
        /// </summary>
        ///
        public int audioLossRate;

        ///
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        ///
        public int numChannels;

        ///
        /// <summary>
        /// The sampling rate of the received audio stream in the reported interval.
        /// </summary>
        ///
        public int receivedSampleRate;

        ///
        /// <summary>
        /// The average bitrate (Kbps) of the received audio stream in the reported interval.
        /// </summary>
        ///
        public int receivedBitrate;

        ///
        /// <summary>
        /// The total freeze time (ms) of the remote audio stream after the remote user joins the channel. In a session, audio freeze occurs when the audio frame loss rate reaches 4%.
        /// </summary>
        ///
        public int totalFrozenTime;

        ///
        /// <summary>
        /// The total audio freeze time as a percentage (%) of the total time when the audio is available. The audio is considered available when the remote user neither stops sending the audio stream nor disables the audio module after joining the channel.
        /// </summary>
        ///
        public int frozenRate;

        ///
        /// <summary>
        /// The quality of the remote audio stream in the reported interval. The quality is determined by the Agora real-time audio MOS (Mean Opinion Score) measurement method. The return value range is [0, 500]. Dividing the return value by 100 gets the MOS score, which ranges from 0 to 5. The higher the score, the better the audio quality. The subjective perception of audio quality corresponding to the Agora real-time audio MOS scores is as follows: MOS score Perception of audio quality Greater than 4 Excellent. The audio sounds clear and smooth. From 3.5 to 4 Good. The audio has some perceptible impairment but still sounds clear. From 3 to 3.5 Fair. The audio freezes occasionally and requires attentive listening. From 2.5 to 3 Poor. The audio sounds choppy and requires considerable effort to understand. From 2 to 2.5 Bad. The audio has occasional noise. Consecutive audio dropouts occur, resulting in some information loss. The users can communicate only with difficulty. Less than 2 Very bad. The audio has persistent noise. Consecutive audio dropouts are frequent, resulting in severe information loss. Communication is nearly impossible.
        /// </summary>
        ///
        public int mosValue;

        ///
        /// @ignore
        ///
        public uint frozenRateByCustomPlcCount;

        ///
        /// @ignore
        ///
        public uint plcCount;

        ///
        /// <summary>
        /// The total active time (ms) between the start of the audio call and the callback of the remote user. The active time refers to the total duration of the remote user without the mute state.
        /// </summary>
        ///
        public int totalActiveTime;

        ///
        /// <summary>
        /// The total duration (ms) of the remote audio stream.
        /// </summary>
        ///
        public int publishDuration;

        ///
        /// <summary>
        /// The Quality of Experience (QoE) of the local user when receiving a remote audio stream. See EXPERIENCE_QUALITY_TYPE.
        /// </summary>
        ///
        public int qoeQuality;

        ///
        /// <summary>
        /// Reasons why the QoE of the local user when receiving a remote audio stream is poor. See EXPERIENCE_POOR_REASON.
        /// </summary>
        ///
        public int qualityChangedReason;

        ///
        /// @ignore
        ///
        public uint rxAudioBytes;

        ///
        /// <summary>
        /// End-to-end audio delay (in milliseconds), which refers to the time from when the audio is captured by the remote user to when it is played by the local user.
        /// </summary>
        ///
        public int e2eDelay;

        public RemoteAudioStats()
        {
            this.uid = 0;
            this.quality = 0;
            this.networkTransportDelay = 0;
            this.jitterBufferDelay = 0;
            this.audioLossRate = 0;
            this.numChannels = 0;
            this.receivedSampleRate = 0;
            this.receivedBitrate = 0;
            this.totalFrozenTime = 0;
            this.frozenRate = 0;
            this.mosValue = 0;
            this.frozenRateByCustomPlcCount = 0;
            this.plcCount = 0;
            this.totalActiveTime = 0;
            this.publishDuration = 0;
            this.qoeQuality = 0;
            this.qualityChangedReason = 0;
            this.rxAudioBytes = 0;
            this.e2eDelay = 0;
        }

        public RemoteAudioStats(uint uid, int quality, int networkTransportDelay, int jitterBufferDelay, int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate, int totalFrozenTime, int frozenRate, int mosValue, uint frozenRateByCustomPlcCount, uint plcCount, int totalActiveTime, int publishDuration, int qoeQuality, int qualityChangedReason, uint rxAudioBytes, int e2eDelay)
        {
            this.uid = uid;
            this.quality = quality;
            this.networkTransportDelay = networkTransportDelay;
            this.jitterBufferDelay = jitterBufferDelay;
            this.audioLossRate = audioLossRate;
            this.numChannels = numChannels;
            this.receivedSampleRate = receivedSampleRate;
            this.receivedBitrate = receivedBitrate;
            this.totalFrozenTime = totalFrozenTime;
            this.frozenRate = frozenRate;
            this.mosValue = mosValue;
            this.frozenRateByCustomPlcCount = frozenRateByCustomPlcCount;
            this.plcCount = plcCount;
            this.totalActiveTime = totalActiveTime;
            this.publishDuration = publishDuration;
            this.qoeQuality = qoeQuality;
            this.qualityChangedReason = qualityChangedReason;
            this.rxAudioBytes = rxAudioBytes;
            this.e2eDelay = e2eDelay;
        }
    }

    ///
    /// <summary>
    /// Statistics of the remote video stream.
    /// </summary>
    ///
    public class RemoteVideoStats
    {
        ///
        /// <summary>
        /// The user ID of the remote user sending the video stream.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// Deprecated: In scenarios where audio and video are synchronized, you can get the video delay data from networkTransportDelay and jitterBufferDelay in RemoteAudioStats. The video delay (ms).
        /// </summary>
        ///
        public int delay;

        ///
        /// <summary>
        /// End-to-end video latency (ms). That is, the time elapsed from the video capturing on the remote user's end to the receiving and rendering of the video on the local user's end.
        /// </summary>
        ///
        public int e2eDelay;

        ///
        /// <summary>
        /// The width (pixels) of the video.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// The height (pixels) of the video.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// The bitrate (Kbps) of the remote video received since the last count.
        /// </summary>
        ///
        public int receivedBitrate;

        ///
        /// <summary>
        /// The frame rate (fps) of decoding the remote video.
        /// </summary>
        ///
        public int decoderOutputFrameRate;

        ///
        /// <summary>
        /// The frame rate (fps) of rendering the remote video.
        /// </summary>
        ///
        public int rendererOutputFrameRate;

        ///
        /// <summary>
        /// The packet loss rate (%) of the remote video.
        /// </summary>
        ///
        public int frameLossRate;

        ///
        /// <summary>
        /// The packet loss rate (%) of the remote video after using the anti-packet-loss technology.
        /// </summary>
        ///
        public int packetLossRate;

        ///
        /// <summary>
        /// The type of the video stream. See VIDEO_STREAM_TYPE.
        /// </summary>
        ///
        public VIDEO_STREAM_TYPE rxStreamType;

        ///
        /// <summary>
        /// The total freeze time (ms) of the remote video stream after the remote user joins the channel. In a video session where the frame rate is set to no less than 5 fps, video freeze occurs when the time interval between two adjacent renderable video frames is more than 500 ms.
        /// </summary>
        ///
        public int totalFrozenTime;

        ///
        /// <summary>
        /// The total video freeze time as a percentage (%) of the total time the video is available. The video is considered available as long as that the remote user neither stops sending the video stream nor disables the video module after joining the channel.
        /// </summary>
        ///
        public int frozenRate;

        ///
        /// <summary>
        /// The amount of time (ms) that the audio is ahead of the video. If this value is negative, the audio is lagging behind the video.
        /// </summary>
        ///
        public int avSyncTimeMs;

        ///
        /// <summary>
        /// The total active time (ms) of the video. As long as the remote user or host neither stops sending the video stream nor disables the video module after joining the channel, the video is available.
        /// </summary>
        ///
        public int totalActiveTime;

        ///
        /// <summary>
        /// The total duration (ms) of the remote video stream.
        /// </summary>
        ///
        public int publishDuration;

        ///
        /// @ignore
        ///
        public int mosValue;

        ///
        /// @ignore
        ///
        public uint rxVideoBytes;

        public RemoteVideoStats(uint uid, int delay, int e2eDelay, int width, int height, int receivedBitrate, int decoderOutputFrameRate, int rendererOutputFrameRate, int frameLossRate, int packetLossRate, VIDEO_STREAM_TYPE rxStreamType, int totalFrozenTime, int frozenRate, int avSyncTimeMs, int totalActiveTime, int publishDuration, int mosValue, uint rxVideoBytes)
        {
            this.uid = uid;
            this.delay = delay;
            this.e2eDelay = e2eDelay;
            this.width = width;
            this.height = height;
            this.receivedBitrate = receivedBitrate;
            this.decoderOutputFrameRate = decoderOutputFrameRate;
            this.rendererOutputFrameRate = rendererOutputFrameRate;
            this.frameLossRate = frameLossRate;
            this.packetLossRate = packetLossRate;
            this.rxStreamType = rxStreamType;
            this.totalFrozenTime = totalFrozenTime;
            this.frozenRate = frozenRate;
            this.avSyncTimeMs = avSyncTimeMs;
            this.totalActiveTime = totalActiveTime;
            this.publishDuration = publishDuration;
            this.mosValue = mosValue;
            this.rxVideoBytes = rxVideoBytes;
        }
        public RemoteVideoStats()
        {
        }

    }

    ///
    /// @ignore
    ///
    public class VideoCompositingLayout
    {
        ///
        /// @ignore
        ///
        public int canvasWidth;

        ///
        /// @ignore
        ///
        public int canvasHeight;

        ///
        /// @ignore
        ///
        public string backgroundColor;

        ///
        /// @ignore
        ///
        public Region[] regions;

        ///
        /// @ignore
        ///
        public int regionCount;

        ///
        /// @ignore
        ///
        public string appData;

        ///
        /// @ignore
        ///
        public int appDataLength;

        public VideoCompositingLayout()
        {
            this.canvasWidth = 0;
            this.canvasHeight = 0;
            this.backgroundColor = "";
            this.regions = new Region[0];
            this.regionCount = 0;
            this.appData = "";
            this.appDataLength = 0;
        }

        public VideoCompositingLayout(int canvasWidth, int canvasHeight, string backgroundColor, Region[] regions, int regionCount, string appData, int appDataLength)
        {
            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
            this.backgroundColor = backgroundColor;
            this.regions = regions;
            this.regionCount = regionCount;
            this.appData = appData;
            this.appDataLength = appDataLength;
        }
    }

    ///
    /// @ignore
    ///
    public class Region
    {
        ///
        /// @ignore
        ///
        public uint uid;

        ///
        /// @ignore
        ///
        public double x;

        ///
        /// @ignore
        ///
        public double y;

        ///
        /// @ignore
        ///
        public double width;

        ///
        /// @ignore
        ///
        public double height;

        ///
        /// @ignore
        ///
        public int zOrder;

        ///
        /// @ignore
        ///
        public double alpha;

        ///
        /// @ignore
        ///
        public RENDER_MODE_TYPE renderMode;

        public Region()
        {
            this.uid = 0;
            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
            this.zOrder = 0;
            this.alpha = 1.0;
            this.renderMode = RENDER_MODE_TYPE.RENDER_MODE_HIDDEN;
        }

        public Region(uint uid, double x, double y, double width, double height, int zOrder, double alpha, RENDER_MODE_TYPE renderMode)
        {
            this.uid = uid;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.zOrder = zOrder;
            this.alpha = alpha;
            this.renderMode = renderMode;
        }
    }

    ///
    /// @ignore
    ///
    public class InjectStreamConfig
    {
        ///
        /// @ignore
        ///
        public int width;

        ///
        /// @ignore
        ///
        public int height;

        ///
        /// @ignore
        ///
        public int videoGop;

        ///
        /// @ignore
        ///
        public int videoFramerate;

        ///
        /// @ignore
        ///
        public int videoBitrate;

        ///
        /// @ignore
        ///
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate;

        ///
        /// @ignore
        ///
        public int audioBitrate;

        ///
        /// @ignore
        ///
        public int audioChannels;

        public InjectStreamConfig()
        {
            this.width = 0;
            this.height = 0;
            this.videoGop = 30;
            this.videoFramerate = 15;
            this.videoBitrate = 400;
            this.audioSampleRate = AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_48000;
            this.audioBitrate = 48;
            this.audioChannels = 1;
        }

        public InjectStreamConfig(int width, int height, int videoGop, int videoFramerate, int videoBitrate, AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels)
        {
            this.width = width;
            this.height = height;
            this.videoGop = videoGop;
            this.videoFramerate = videoFramerate;
            this.videoBitrate = videoBitrate;
            this.audioSampleRate = audioSampleRate;
            this.audioBitrate = audioBitrate;
            this.audioChannels = audioChannels;
        }
    }

    ///
    /// <summary>
    /// Lifecycle of the CDN live video stream.
    /// 
    /// Deprecated
    /// </summary>
    ///
    public enum RTMP_STREAM_LIFE_CYCLE_TYPE
    {
        ///
        /// <summary>
        /// Bind to the channel lifecycle. If all hosts leave the channel, the CDN live streaming stops after 30 seconds.
        /// </summary>
        ///
        RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL = 1,

        ///
        /// <summary>
        /// Bind to the owner of the RTMP stream. If the owner leaves the channel, the CDN live streaming stops immediately.
        /// </summary>
        ///
        RTMP_STREAM_LIFE_CYCLE_BIND2OWNER = 2,
    }

    ///
    /// @ignore
    ///
    public class PublisherConfiguration
    {
        ///
        /// @ignore
        ///
        public int width;

        ///
        /// @ignore
        ///
        public int height;

        ///
        /// @ignore
        ///
        public int framerate;

        ///
        /// @ignore
        ///
        public int bitrate;

        ///
        /// @ignore
        ///
        public int defaultLayout;

        ///
        /// @ignore
        ///
        public int lifecycle;

        ///
        /// @ignore
        ///
        public bool owner;

        ///
        /// @ignore
        ///
        public int injectStreamWidth;

        ///
        /// @ignore
        ///
        public int injectStreamHeight;

        ///
        /// @ignore
        ///
        public string injectStreamUrl;

        ///
        /// @ignore
        ///
        public string publishUrl;

        ///
        /// @ignore
        ///
        public string rawStreamUrl;

        ///
        /// @ignore
        ///
        public string extraInfo;

        public PublisherConfiguration()
        {
            this.width = 640;
            this.height = 360;
            this.framerate = 15;
            this.bitrate = 500;
            this.defaultLayout = 1;
            this.lifecycle = (int)RTMP_STREAM_LIFE_CYCLE_TYPE.RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL;
            this.owner = true;
            this.injectStreamWidth = 0;
            this.injectStreamHeight = 0;
            this.injectStreamUrl = "";
            this.publishUrl = "";
            this.rawStreamUrl = "";
            this.extraInfo = "";
        }

        public PublisherConfiguration(int width, int height, int framerate, int bitrate, int defaultLayout, int lifecycle, bool owner, int injectStreamWidth, int injectStreamHeight, string injectStreamUrl, string publishUrl, string rawStreamUrl, string extraInfo)
        {
            this.width = width;
            this.height = height;
            this.framerate = framerate;
            this.bitrate = bitrate;
            this.defaultLayout = defaultLayout;
            this.lifecycle = lifecycle;
            this.owner = owner;
            this.injectStreamWidth = injectStreamWidth;
            this.injectStreamHeight = injectStreamHeight;
            this.injectStreamUrl = injectStreamUrl;
            this.publishUrl = publishUrl;
            this.rawStreamUrl = rawStreamUrl;
            this.extraInfo = extraInfo;
        }
    }

    ///
    /// <summary>
    /// The camera direction.
    /// </summary>
    ///
    public enum CAMERA_DIRECTION
    {
        ///
        /// <summary>
        /// 0: The rear camera.
        /// </summary>
        ///
        CAMERA_REAR = 0,

        ///
        /// <summary>
        /// 1: (Default) The front camera.
        /// </summary>
        ///
        CAMERA_FRONT = 1,
    }

    ///
    /// <summary>
    /// The cloud proxy type.
    /// </summary>
    ///
    public enum CLOUD_PROXY_TYPE
    {
        ///
        /// <summary>
        /// 0: The automatic mode. The SDK has this mode enabled by default. In this mode, the SDK attempts a direct connection to SD-RTN™ and automatically switches to TCP/TLS 443 if the attempt fails.
        /// </summary>
        ///
        NONE_PROXY = 0,

        ///
        /// <summary>
        /// 1: The cloud proxy for the UDP protocol, that is, the Force UDP cloud proxy mode. In this mode, the SDK always transmits data over UDP.
        /// </summary>
        ///
        UDP_PROXY = 1,

        ///
        /// <summary>
        /// 2: The cloud proxy for the TCP (encryption) protocol, that is, the Force TCP cloud proxy mode. In this mode, the SDK always transmits data over TCP/TLS 443.
        /// </summary>
        ///
        TCP_PROXY = 2,
    }

    ///
    /// <summary>
    /// The camera capturer preference.
    /// </summary>
    ///
    public class CameraCapturerConfiguration : IOptionalJsonParse
    {
        ///
        /// <summary>
        /// (Optional) The camera direction. See CAMERA_DIRECTION. This parameter is for Android and iOS only.
        /// </summary>
        ///
        public Optional<CAMERA_DIRECTION> cameraDirection = new Optional<CAMERA_DIRECTION>();

        ///
        /// <summary>
        /// (Optional) The camera focal length type. See CAMERA_FOCAL_LENGTH_TYPE.
        ///  This parameter is for Android and iOS only.
        ///  To set the focal length type of the camera, it is only supported to specify the camera through cameraDirection, and not supported to specify it through cameraId.
        ///  For iOS devices equipped with multi-lens rear cameras, such as those featuring dual-camera (wide-angle and ultra-wide-angle) or triple-camera (wide-angle, ultra-wide-angle, and telephoto), you can use one of the following methods to capture video with an ultra-wide-angle perspective:
        ///  Method one: Set this parameter to CAMERA_FOCAL_LENGTH_ULTRA_WIDE (2) (ultra-wide lens).
        ///  Method two: Set this parameter to CAMERA_FOCAL_LENGTH_DEFAULT (0) (standard lens), then call SetCameraZoomFactor to set the camera's zoom factor to a value less than 1.0, with the minimum setting being 0.5. The difference is that the size of the ultra-wide angle in method one is not adjustable, whereas method two supports adjusting the camera's zoom factor freely.
        /// </summary>
        ///
        public Optional<CAMERA_FOCAL_LENGTH_TYPE> cameraFocalLengthType = new Optional<CAMERA_FOCAL_LENGTH_TYPE>();

        ///
        /// <summary>
        /// The camera ID. This parameter is for Windows and macOS only.
        /// </summary>
        ///
        public Optional<string> deviceId = new Optional<string>();

        ///
        /// <summary>
        /// (Optional) The camera ID. The default value is the camera ID of the front camera. You can get the camera ID through the Android native system API, see and for details.
        ///  This parameter is for Android only.
        ///  This parameter and cameraDirection are mutually exclusive in specifying the camera; you can choose one based on your needs. The differences are as follows:
        ///  Specifying the camera via cameraDirection is more straightforward. You only need to indicate the camera direction (front or rear), without specifying a specific camera ID; the SDK will retrieve and confirm the actual camera ID through Android native system APIs.
        ///  Specifying via cameraId allows for more precise identification of a particular camera. For devices with multiple cameras, where cameraDirection cannot recognize or access all available cameras, it is recommended to use cameraId to specify the desired camera ID directly.
        /// </summary>
        ///
        public Optional<string> cameraId = new Optional<string>();

        ///
        /// <summary>
        /// (Optional) Whether to follow the video aspect ratio set in SetVideoEncoderConfiguration : true : (Default) Follow the set video aspect ratio. The SDK crops the captured video according to the set video aspect ratio and synchronously changes the local preview screen and the video frame in OnCaptureVideoFrame and OnPreEncodeVideoFrame. false : Do not follow the system default audio playback device. The SDK does not change the aspect ratio of the captured video frame.
        /// </summary>
        ///
        public Optional<bool> followEncodeDimensionRatio = new Optional<bool>();

        ///
        /// <summary>
        /// (Optional) The format of the video frame. See VideoFormat.
        /// </summary>
        ///
        public VideoFormat format;

        public CameraCapturerConfiguration()
        {
            this.format = new VideoFormat(0, 0, 0);
        }

        public CameraCapturerConfiguration(Optional<CAMERA_DIRECTION> cameraDirection, Optional<CAMERA_FOCAL_LENGTH_TYPE> cameraFocalLengthType, Optional<string> deviceId, Optional<string> cameraId, Optional<bool> followEncodeDimensionRatio, VideoFormat format)
        {
            this.cameraDirection = cameraDirection;
            this.cameraFocalLengthType = cameraFocalLengthType;
            this.deviceId = deviceId;
            this.cameraId = cameraId;
            this.followEncodeDimensionRatio = followEncodeDimensionRatio;
            this.format = format;
        }

        ///
        /// @ignore
        ///
        public virtual void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            if (this.cameraDirection.HasValue())
            {
                writer.WritePropertyName("cameraDirection");
                AgoraJson.WriteEnum(writer, this.cameraDirection.GetValue());
            }

            if (this.cameraFocalLengthType.HasValue())
            {
                writer.WritePropertyName("cameraFocalLengthType");
                AgoraJson.WriteEnum(writer, this.cameraFocalLengthType.GetValue());
            }

            if (this.deviceId.HasValue())
            {
                writer.WritePropertyName("deviceId");
                writer.Write(this.deviceId.GetValue());
            }

            if (this.cameraId.HasValue())
            {
                writer.WritePropertyName("cameraId");
                writer.Write(this.cameraId.GetValue());
            }

            if (this.followEncodeDimensionRatio.HasValue())
            {
                writer.WritePropertyName("followEncodeDimensionRatio");
                writer.Write(this.followEncodeDimensionRatio.GetValue());
            }

            writer.WritePropertyName("format");
            JsonMapper.WriteValue(this.format, writer, false, 0);

            writer.WriteObjectEnd();
        }
    }

    ///
    /// <summary>
    /// The configuration of the captured screen.
    /// </summary>
    ///
    public class ScreenCaptureConfiguration
    {
        ///
        /// <summary>
        /// Whether to capture the window on the screen: true : Capture the window. false : (Default) Capture the screen, not the window.
        /// </summary>
        ///
        public bool isCaptureWindow;

        ///
        /// <summary>
        /// (macOS only) The display ID of the screen. This parameter takes effect only when you want to capture the screen on macOS.
        /// </summary>
        ///
        public uint displayId;

        ///
        /// <summary>
        /// (Windows only) The relative position of the shared screen to the virtual screen. This parameter takes effect only when you want to capture the screen on Windows.
        /// </summary>
        ///
        public Rectangle screenRect;

        ///
        /// <summary>
        /// (For Windows and macOS only) Window ID. This parameter takes effect only when you want to capture the window.
        /// </summary>
        ///
        public view_t windowId;

        public ScreenCaptureParameters @params;

        ///
        /// <summary>
        /// (For Windows and macOS only) The relative position of the shared region to the whole screen. See Rectangle. If you do not set this parameter, the SDK shares the whole screen. If the region you set exceeds the boundary of the screen, only the region within in the screen is shared. If you set width or height in Rectangle as 0, the whole screen is shared.
        /// </summary>
        ///
        public Rectangle regionRect;

        public ScreenCaptureConfiguration()
        {
            this.isCaptureWindow = false;
            this.displayId = 0;
            this.windowId = 0;
        }

        public ScreenCaptureConfiguration(bool isCaptureWindow, uint displayId, Rectangle screenRect, view_t windowId, ScreenCaptureParameters @params, Rectangle regionRect)
        {
            this.isCaptureWindow = isCaptureWindow;
            this.displayId = displayId;
            this.screenRect = screenRect;
            this.windowId = windowId;
            this.@params = @params;
            this.regionRect = regionRect;
        }
    }

    ///
    /// @ignore
    ///
    public class SIZE
    {
        ///
        /// @ignore
        ///
        public int width;

        ///
        /// @ignore
        ///
        public int height;

        public SIZE()
        {
            this.width = 0;
            this.height = 0;
        }

        public SIZE(int ww, int hh)
        {
            this.width = ww;
            this.height = hh;
        }

    }

    ///
    /// <summary>
    /// The image content of the thumbnail or icon. Set in ScreenCaptureSourceInfo.
    /// 
    /// The default image is in the ARGB format. If you need to use another format, you need to convert the image on your own.
    /// </summary>
    ///
    public class ThumbImageBuffer
    {
        ///
        /// <summary>
        /// The buffer of the thumbnail or icon.
        /// </summary>
        ///
        public byte[] buffer;

        ///
        /// <summary>
        /// The buffer length of the thumbnail or icon, in bytes.
        /// </summary>
        ///
        public uint length;

        ///
        /// <summary>
        /// The actual width (px) of the thumbnail or icon.
        /// </summary>
        ///
        public uint width;

        ///
        /// <summary>
        /// The actual height (px) of the thumbnail or icon.
        /// </summary>
        ///
        public uint height;

        public ThumbImageBuffer()
        {
            this.buffer = new byte[0];
            this.length = 0;
            this.width = 0;
            this.height = 0;
        }

        public ThumbImageBuffer(byte[] buffer, uint length, uint width, uint height)
        {
            this.buffer = buffer;
            this.length = length;
            this.width = width;
            this.height = height;
        }
    }

    ///
    /// <summary>
    /// The type of the shared target. Set in ScreenCaptureSourceInfo.
    /// </summary>
    ///
    public enum ScreenCaptureSourceType
    {
        ///
        /// <summary>
        /// -1: Unknown type.
        /// </summary>
        ///
        ScreenCaptureSourceType_Unknown = -1,

        ///
        /// <summary>
        /// 0: The shared target is a window.
        /// </summary>
        ///
        ScreenCaptureSourceType_Window = 0,

        ///
        /// <summary>
        /// 1: The shared target is a screen of a particular monitor.
        /// </summary>
        ///
        ScreenCaptureSourceType_Screen = 1,

        ///
        /// <summary>
        /// 2: Reserved parameter
        /// </summary>
        ///
        ScreenCaptureSourceType_Custom = 2,
    }

    ///
    /// <summary>
    /// The information about the specified shareable window or screen.
    /// </summary>
    ///
    public class ScreenCaptureSourceInfo
    {
        ///
        /// <summary>
        /// The type of the shared target. See ScreenCaptureSourceType.
        /// </summary>
        ///
        public ScreenCaptureSourceType type;

        ///
        /// <summary>
        /// The window ID for a window or the display ID for a screen.
        /// </summary>
        ///
        public view_t sourceId;

        ///
        /// <summary>
        /// The name of the window or screen. UTF-8 encoding.
        /// </summary>
        ///
        public string sourceName;

        ///
        /// <summary>
        /// The image content of the thumbnail. See ThumbImageBuffer.
        /// </summary>
        ///
        public ThumbImageBuffer thumbImage;

        ///
        /// <summary>
        /// The image content of the icon. See ThumbImageBuffer.
        /// </summary>
        ///
        public ThumbImageBuffer iconImage;

        ///
        /// <summary>
        /// The process to which the window belongs. UTF-8 encoding.
        /// </summary>
        ///
        public string processPath;

        ///
        /// <summary>
        /// The title of the window. UTF-8 encoding.
        /// </summary>
        ///
        public string sourceTitle;

        ///
        /// <summary>
        /// Determines whether the screen is the primary display: true : The screen is the primary display. false : The screen is not the primary display.
        /// </summary>
        ///
        public bool primaryMonitor;

        ///
        /// @ignore
        ///
        public bool isOccluded;

        ///
        /// <summary>
        /// The position of a window relative to the entire screen space (including all shareable screens). See Rectangle.
        /// </summary>
        ///
        public Rectangle position;

        ///
        /// @ignore
        ///
        public bool minimizeWindow;

        ///
        /// <summary>
        /// (For Windows only) Screen ID where the window is located. If the window is displayed across multiple screens, this parameter indicates the ID of the screen with which the window has the largest intersection area. If the window is located outside of the visible screens, the value of this member is -2.
        /// </summary>
        ///
        public view_t sourceDisplayId;

        public ScreenCaptureSourceInfo()
        {
            this.type = ScreenCaptureSourceType.ScreenCaptureSourceType_Unknown;
            this.sourceId = 0;
            this.sourceName = "";
            this.processPath = "";
            this.sourceTitle = "";
            this.primaryMonitor = false;
            this.isOccluded = false;
            this.minimizeWindow = false;
            this.sourceDisplayId = AgoraUtil.ConvertNegativeToUInt64(-2);
        }

        public ScreenCaptureSourceInfo(ScreenCaptureSourceType type, view_t sourceId, string sourceName, ThumbImageBuffer thumbImage, ThumbImageBuffer iconImage, string processPath, string sourceTitle, bool primaryMonitor, bool isOccluded, Rectangle position, bool minimizeWindow, view_t sourceDisplayId)
        {
            this.type = type;
            this.sourceId = sourceId;
            this.sourceName = sourceName;
            this.thumbImage = thumbImage;
            this.iconImage = iconImage;
            this.processPath = processPath;
            this.sourceTitle = sourceTitle;
            this.primaryMonitor = primaryMonitor;
            this.isOccluded = isOccluded;
            this.position = position;
            this.minimizeWindow = minimizeWindow;
            this.sourceDisplayId = sourceDisplayId;
        }
    }

    ///
    /// <summary>
    /// The advanced options for audio.
    /// </summary>
    ///
    public class AdvancedAudioOptions : IOptionalJsonParse
    {
        ///
        /// <summary>
        /// The number of channels for audio preprocessing. See AUDIO_PROCESSING_CHANNELS.
        /// </summary>
        ///
        public Optional<int> audioProcessingChannels = new Optional<int>();

        public AdvancedAudioOptions()
        {
        }

        public AdvancedAudioOptions(Optional<int> audioProcessingChannels)
        {
            this.audioProcessingChannels = audioProcessingChannels;
        }

        ///
        /// @ignore
        ///
        public virtual void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            if (this.audioProcessingChannels.HasValue())
            {
                writer.WritePropertyName("audioProcessingChannels");
                writer.Write(this.audioProcessingChannels.GetValue());
            }

            writer.WriteObjectEnd();
        }
    }

    ///
    /// <summary>
    /// Image configurations.
    /// </summary>
    ///
    public class ImageTrackOptions
    {
        ///
        /// <summary>
        /// The image URL. Supported formats of images include JPEG, JPG, PNG and GIF. This method supports adding an image from the local absolute or relative file path. On the Android platform, adding images from /assets/ is not supported.
        /// </summary>
        ///
        public string imageUrl;

        ///
        /// <summary>
        /// The frame rate of the video streams being published. The value range is [1,30]. The default value is 1.
        /// </summary>
        ///
        public int fps;

        ///
        /// @ignore
        ///
        public VIDEO_MIRROR_MODE_TYPE mirrorMode;

        public ImageTrackOptions()
        {
            this.imageUrl = "";
            this.fps = 1;
            this.mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED;
        }

        public ImageTrackOptions(string imageUrl, int fps, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            this.imageUrl = imageUrl;
            this.fps = fps;
            this.mirrorMode = mirrorMode;
        }
    }

    ///
    /// <summary>
    /// The channel media options.
    /// 
    /// Agora supports publishing multiple audio streams and one video stream at the same time and in the same RtcConnection. For example, publishMicrophoneTrack, publishCustomAudioTrack, and publishMediaPlayerAudioTrack can be set as true at the same time, but only one of publishCameraTrack, publishScreenCaptureVideo, publishScreenTrack, publishCustomVideoTrack, or publishEncodedVideoTrack can be set as true. Agora recommends that you set member parameter values yourself according to your business scenario, otherwise the SDK will automatically assign values to member parameters.
    /// </summary>
    ///
    public class ChannelMediaOptions : IOptionalJsonParse
    {
        ///
        /// <summary>
        /// Whether to publish the video captured by the camera: true : Publish the video captured by the camera. false : Do not publish the video captured by the camera.
        /// </summary>
        ///
        public Optional<bool> publishCameraTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured by the second camera: true : Publish the video captured by the second camera. false : Do not publish the video captured by the second camera.
        /// </summary>
        ///
        public Optional<bool> publishSecondaryCameraTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured by the third camera: true : Publish the video captured by the third camera. false : Do not publish the video captured by the third camera. This parameter is for Android, Windows and macOS only.
        /// </summary>
        ///
        public Optional<bool> publishThirdCameraTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured by the fourth camera: true : Publish the video captured by the fourth camera. false : Do not publish the video captured by the fourth camera. This parameter is for Android, Windows and macOS only.
        /// </summary>
        ///
        public Optional<bool> publishFourthCameraTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the audio captured by the microphone: true : Publish the audio captured by the microphone. false : Do not publish the audio captured by the microphone.
        /// </summary>
        ///
        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured from the screen: true : Publish the video captured from the screen. false : Do not publish the video captured from the screen. This parameter is for Android and iOS only.
        /// </summary>
        ///
        public Optional<bool> publishScreenCaptureVideo = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the audio captured from the screen: true : Publish the audio captured from the screen. false : Publish the audio captured from the screen. This parameter is for Android and iOS only.
        /// </summary>
        ///
        public Optional<bool> publishScreenCaptureAudio = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured from the screen: true : Publish the video captured from the screen. false : Do not publish the video captured from the screen. This is for Windows and macOS only.
        /// </summary>
        ///
        public Optional<bool> publishScreenTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured from the second screen: true : Publish the video captured from the second screen. false : Do not publish the video captured from the second screen.
        /// </summary>
        ///
        public Optional<bool> publishSecondaryScreenTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured from the third screen: true : Publish the captured video from the third screen. false : Do not publish the video captured from the third screen. This is for Windows and macOS only.
        /// </summary>
        ///
        public Optional<bool> publishThirdScreenTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured from the fourth screen: true : Publish the captured video from the fourth screen. false : Do not publish the video captured from the fourth screen. This is for Windows and macOS only.
        /// </summary>
        ///
        public Optional<bool> publishFourthScreenTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the audio captured from a custom source: true : Publish the audio captured from the custom source. false : Do not publish the captured audio from a custom source.
        /// </summary>
        ///
        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();

        ///
        /// <summary>
        /// The ID of the custom audio source to publish. The default value is 0. If you have set sourceNumber in SetExternalAudioSource to a value greater than 1, the SDK creates the corresponding number of custom audio tracks and assigns an ID to each audio track, starting from 0.
        /// </summary>
        ///
        public Optional<int> publishCustomAudioTrackId = new Optional<int>();

        ///
        /// <summary>
        /// Whether to publish the video captured from a custom source: true : Publish the video captured from the custom source. false : Do not publish the captured video from a custom source.
        /// </summary>
        ///
        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the encoded video: true : Publish the encoded video. false : Do not publish the encoded video.
        /// </summary>
        ///
        public Optional<bool> publishEncodedVideoTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the audio from the media player: true : Publish the audio from the media player. false : Do not publish the audio from the media player.
        /// </summary>
        ///
        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video from the media player: true : Publish the video from the media player. false : Do not publish the video from the media player.
        /// </summary>
        ///
        public Optional<bool> publishMediaPlayerVideoTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the local transcoded video: true : Publish the local transcoded video. false : Do not publish the local transcoded video.
        /// </summary>
        ///
        public Optional<bool> publishTranscodedVideoTrack = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<bool> publishMixedAudioTrack = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<bool> publishLipSyncTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to automatically subscribe to all remote audio streams when the user joins a channel: true : Subscribe to all remote audio streams. false : Do not automatically subscribe to any remote audio streams.
        /// </summary>
        ///
        public Optional<bool> autoSubscribeAudio = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to automatically subscribe to all remote video streams when the user joins the channel: true : Subscribe to all remote video streams. false : Do not automatically subscribe to any remote video streams.
        /// </summary>
        ///
        public Optional<bool> autoSubscribeVideo = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to enable audio capturing or playback: true : Enable audio capturing or playback. false : Do not enable audio capturing or playback. If you need to publish the audio streams captured by your microphone, ensure this parameter is set as true.
        /// </summary>
        ///
        public Optional<bool> enableAudioRecordingOrPlayout = new Optional<bool>();

        ///
        /// <summary>
        /// The ID of the media player to be published. The default value is 0.
        /// </summary>
        ///
        public Optional<int> publishMediaPlayerId = new Optional<int>();

        ///
        /// <summary>
        /// The user role. See CLIENT_ROLE_TYPE. If you set the user role as an audience member, you cannot publish audio and video streams in the channel. If you want to publish media streams in a channel during live streaming, ensure you set the user role as broadcaster.
        /// </summary>
        ///
        public Optional<CLIENT_ROLE_TYPE> clientRoleType = new Optional<CLIENT_ROLE_TYPE>();

        ///
        /// <summary>
        /// The latency level of an audience member in interactive live streaming. See AUDIENCE_LATENCY_LEVEL_TYPE.
        /// </summary>
        ///
        public Optional<AUDIENCE_LATENCY_LEVEL_TYPE> audienceLatencyLevel = new Optional<AUDIENCE_LATENCY_LEVEL_TYPE>();

        ///
        /// <summary>
        /// The default video-stream type. See VIDEO_STREAM_TYPE.
        /// </summary>
        ///
        public Optional<VIDEO_STREAM_TYPE> defaultVideoStreamType = new Optional<VIDEO_STREAM_TYPE>();

        ///
        /// <summary>
        /// The channel profile. See CHANNEL_PROFILE_TYPE.
        /// </summary>
        ///
        public Optional<CHANNEL_PROFILE_TYPE> channelProfile = new Optional<CHANNEL_PROFILE_TYPE>();

        ///
        /// <summary>
        /// Delay (in milliseconds) for sending audio frames. You can use this parameter to set the delay of the audio frames that need to be sent, to ensure audio and video synchronization. To switch off the delay, set the value to 0.
        /// </summary>
        ///
        public Optional<int> audioDelayMs = new Optional<int>();

        ///
        /// @ignore
        ///
        public Optional<int> mediaPlayerAudioDelayMs = new Optional<int>();

        ///
        /// <summary>
        /// (Optional) The token generated on your server for authentication.
        ///  This parameter takes effect only when calling UpdateChannelMediaOptions or UpdateChannelMediaOptionsEx.
        ///  Ensure that the App ID, channel name, and user name used for creating the token are the same as those used by the Initialize method for initializing the RTC engine, and those used by the JoinChannel [2/2] and JoinChannelEx methods for joining the channel.
        /// </summary>
        ///
        public Optional<string> token = new Optional<string>();

        ///
        /// @ignore
        ///
        public Optional<bool> enableBuiltInMediaEncryption = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the sound of a metronome to remote users: true : Publish processed audio frames. Both the local user and remote users can hear the metronome. false : Do not publish the sound of the metronome. Only the local user can hear the metronome.
        /// </summary>
        ///
        public Optional<bool> publishRhythmPlayerTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to enable interactive mode: true : Enable interactive mode. Once this mode is enabled and the user role is set as audience, the user can receive remote video streams with low latency. false :Do not enable interactive mode. If this mode is disabled, the user receives the remote video streams in default settings.
        ///  This parameter only applies to co-streaming scenarios. The cohosts need to call the JoinChannelEx method to join the other host's channel as an audience member, and set isInteractiveAudience to true.
        ///  This parameter takes effect only when the user role is CLIENT_ROLE_AUDIENCE.
        /// </summary>
        ///
        public Optional<bool> isInteractiveAudience = new Optional<bool>();

        ///
        /// <summary>
        /// The video track ID returned by calling the CreateCustomVideoTrack method. The default value is 0.
        /// </summary>
        ///
        public Optional<uint> customVideoTrackId = new Optional<uint>();

        ///
        /// <summary>
        /// Whether the audio stream being published is filtered according to the volume algorithm: true : The audio stream is filtered. If the audio stream filter is not enabled, this setting does not takes effect. false : The audio stream is not filtered. If you need to enable this function, contact.
        /// </summary>
        ///
        public Optional<bool> isAudioFilterable = new Optional<bool>();

        public ChannelMediaOptions()
        {
        }

        public ChannelMediaOptions(Optional<bool> publishCameraTrack, Optional<bool> publishSecondaryCameraTrack, Optional<bool> publishThirdCameraTrack, Optional<bool> publishFourthCameraTrack, Optional<bool> publishMicrophoneTrack, Optional<bool> publishScreenCaptureVideo, Optional<bool> publishScreenCaptureAudio, Optional<bool> publishScreenTrack, Optional<bool> publishSecondaryScreenTrack, Optional<bool> publishThirdScreenTrack, Optional<bool> publishFourthScreenTrack, Optional<bool> publishCustomAudioTrack, Optional<int> publishCustomAudioTrackId, Optional<bool> publishCustomVideoTrack, Optional<bool> publishEncodedVideoTrack, Optional<bool> publishMediaPlayerAudioTrack, Optional<bool> publishMediaPlayerVideoTrack, Optional<bool> publishTranscodedVideoTrack, Optional<bool> publishMixedAudioTrack, Optional<bool> publishLipSyncTrack, Optional<bool> autoSubscribeAudio, Optional<bool> autoSubscribeVideo, Optional<bool> enableAudioRecordingOrPlayout, Optional<int> publishMediaPlayerId, Optional<CLIENT_ROLE_TYPE> clientRoleType, Optional<AUDIENCE_LATENCY_LEVEL_TYPE> audienceLatencyLevel, Optional<VIDEO_STREAM_TYPE> defaultVideoStreamType, Optional<CHANNEL_PROFILE_TYPE> channelProfile, Optional<int> audioDelayMs, Optional<int> mediaPlayerAudioDelayMs, Optional<string> token, Optional<bool> enableBuiltInMediaEncryption, Optional<bool> publishRhythmPlayerTrack, Optional<bool> isInteractiveAudience, Optional<uint> customVideoTrackId, Optional<bool> isAudioFilterable)
        {
            this.publishCameraTrack = publishCameraTrack;
            this.publishSecondaryCameraTrack = publishSecondaryCameraTrack;
            this.publishThirdCameraTrack = publishThirdCameraTrack;
            this.publishFourthCameraTrack = publishFourthCameraTrack;
            this.publishMicrophoneTrack = publishMicrophoneTrack;
            this.publishScreenCaptureVideo = publishScreenCaptureVideo;
            this.publishScreenCaptureAudio = publishScreenCaptureAudio;
            this.publishScreenTrack = publishScreenTrack;
            this.publishSecondaryScreenTrack = publishSecondaryScreenTrack;
            this.publishThirdScreenTrack = publishThirdScreenTrack;
            this.publishFourthScreenTrack = publishFourthScreenTrack;
            this.publishCustomAudioTrack = publishCustomAudioTrack;
            this.publishCustomAudioTrackId = publishCustomAudioTrackId;
            this.publishCustomVideoTrack = publishCustomVideoTrack;
            this.publishEncodedVideoTrack = publishEncodedVideoTrack;
            this.publishMediaPlayerAudioTrack = publishMediaPlayerAudioTrack;
            this.publishMediaPlayerVideoTrack = publishMediaPlayerVideoTrack;
            this.publishTranscodedVideoTrack = publishTranscodedVideoTrack;
            this.publishMixedAudioTrack = publishMixedAudioTrack;
            this.publishLipSyncTrack = publishLipSyncTrack;
            this.autoSubscribeAudio = autoSubscribeAudio;
            this.autoSubscribeVideo = autoSubscribeVideo;
            this.enableAudioRecordingOrPlayout = enableAudioRecordingOrPlayout;
            this.publishMediaPlayerId = publishMediaPlayerId;
            this.clientRoleType = clientRoleType;
            this.audienceLatencyLevel = audienceLatencyLevel;
            this.defaultVideoStreamType = defaultVideoStreamType;
            this.channelProfile = channelProfile;
            this.audioDelayMs = audioDelayMs;
            this.mediaPlayerAudioDelayMs = mediaPlayerAudioDelayMs;
            this.token = token;
            this.enableBuiltInMediaEncryption = enableBuiltInMediaEncryption;
            this.publishRhythmPlayerTrack = publishRhythmPlayerTrack;
            this.isInteractiveAudience = isInteractiveAudience;
            this.customVideoTrackId = customVideoTrackId;
            this.isAudioFilterable = isAudioFilterable;
        }

        ///
        /// @ignore
        ///
        public virtual void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            if (this.publishCameraTrack.HasValue())
            {
                writer.WritePropertyName("publishCameraTrack");
                writer.Write(this.publishCameraTrack.GetValue());
            }

            if (this.publishSecondaryCameraTrack.HasValue())
            {
                writer.WritePropertyName("publishSecondaryCameraTrack");
                writer.Write(this.publishSecondaryCameraTrack.GetValue());
            }

            if (this.publishThirdCameraTrack.HasValue())
            {
                writer.WritePropertyName("publishThirdCameraTrack");
                writer.Write(this.publishThirdCameraTrack.GetValue());
            }

            if (this.publishFourthCameraTrack.HasValue())
            {
                writer.WritePropertyName("publishFourthCameraTrack");
                writer.Write(this.publishFourthCameraTrack.GetValue());
            }

            if (this.publishMicrophoneTrack.HasValue())
            {
                writer.WritePropertyName("publishMicrophoneTrack");
                writer.Write(this.publishMicrophoneTrack.GetValue());
            }

            if (this.publishScreenCaptureVideo.HasValue())
            {
                writer.WritePropertyName("publishScreenCaptureVideo");
                writer.Write(this.publishScreenCaptureVideo.GetValue());
            }

            if (this.publishScreenCaptureAudio.HasValue())
            {
                writer.WritePropertyName("publishScreenCaptureAudio");
                writer.Write(this.publishScreenCaptureAudio.GetValue());
            }

            if (this.publishScreenTrack.HasValue())
            {
                writer.WritePropertyName("publishScreenTrack");
                writer.Write(this.publishScreenTrack.GetValue());
            }

            if (this.publishSecondaryScreenTrack.HasValue())
            {
                writer.WritePropertyName("publishSecondaryScreenTrack");
                writer.Write(this.publishSecondaryScreenTrack.GetValue());
            }

            if (this.publishThirdScreenTrack.HasValue())
            {
                writer.WritePropertyName("publishThirdScreenTrack");
                writer.Write(this.publishThirdScreenTrack.GetValue());
            }

            if (this.publishFourthScreenTrack.HasValue())
            {
                writer.WritePropertyName("publishFourthScreenTrack");
                writer.Write(this.publishFourthScreenTrack.GetValue());
            }

            if (this.publishCustomAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishCustomAudioTrack");
                writer.Write(this.publishCustomAudioTrack.GetValue());
            }

            if (this.publishCustomAudioTrackId.HasValue())
            {
                writer.WritePropertyName("publishCustomAudioTrackId");
                writer.Write(this.publishCustomAudioTrackId.GetValue());
            }

            if (this.publishCustomVideoTrack.HasValue())
            {
                writer.WritePropertyName("publishCustomVideoTrack");
                writer.Write(this.publishCustomVideoTrack.GetValue());
            }

            if (this.publishEncodedVideoTrack.HasValue())
            {
                writer.WritePropertyName("publishEncodedVideoTrack");
                writer.Write(this.publishEncodedVideoTrack.GetValue());
            }

            if (this.publishMediaPlayerAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishMediaPlayerAudioTrack");
                writer.Write(this.publishMediaPlayerAudioTrack.GetValue());
            }

            if (this.publishMediaPlayerVideoTrack.HasValue())
            {
                writer.WritePropertyName("publishMediaPlayerVideoTrack");
                writer.Write(this.publishMediaPlayerVideoTrack.GetValue());
            }

            if (this.publishTranscodedVideoTrack.HasValue())
            {
                writer.WritePropertyName("publishTranscodedVideoTrack");
                writer.Write(this.publishTranscodedVideoTrack.GetValue());
            }

            if (this.publishMixedAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishMixedAudioTrack");
                writer.Write(this.publishMixedAudioTrack.GetValue());
            }

            if (this.publishLipSyncTrack.HasValue())
            {
                writer.WritePropertyName("publishLipSyncTrack");
                writer.Write(this.publishLipSyncTrack.GetValue());
            }

            if (this.autoSubscribeAudio.HasValue())
            {
                writer.WritePropertyName("autoSubscribeAudio");
                writer.Write(this.autoSubscribeAudio.GetValue());
            }

            if (this.autoSubscribeVideo.HasValue())
            {
                writer.WritePropertyName("autoSubscribeVideo");
                writer.Write(this.autoSubscribeVideo.GetValue());
            }

            if (this.enableAudioRecordingOrPlayout.HasValue())
            {
                writer.WritePropertyName("enableAudioRecordingOrPlayout");
                writer.Write(this.enableAudioRecordingOrPlayout.GetValue());
            }

            if (this.publishMediaPlayerId.HasValue())
            {
                writer.WritePropertyName("publishMediaPlayerId");
                writer.Write(this.publishMediaPlayerId.GetValue());
            }

            if (this.clientRoleType.HasValue())
            {
                writer.WritePropertyName("clientRoleType");
                AgoraJson.WriteEnum(writer, this.clientRoleType.GetValue());
            }

            if (this.audienceLatencyLevel.HasValue())
            {
                writer.WritePropertyName("audienceLatencyLevel");
                AgoraJson.WriteEnum(writer, this.audienceLatencyLevel.GetValue());
            }

            if (this.defaultVideoStreamType.HasValue())
            {
                writer.WritePropertyName("defaultVideoStreamType");
                AgoraJson.WriteEnum(writer, this.defaultVideoStreamType.GetValue());
            }

            if (this.channelProfile.HasValue())
            {
                writer.WritePropertyName("channelProfile");
                AgoraJson.WriteEnum(writer, this.channelProfile.GetValue());
            }

            if (this.audioDelayMs.HasValue())
            {
                writer.WritePropertyName("audioDelayMs");
                writer.Write(this.audioDelayMs.GetValue());
            }

            if (this.mediaPlayerAudioDelayMs.HasValue())
            {
                writer.WritePropertyName("mediaPlayerAudioDelayMs");
                writer.Write(this.mediaPlayerAudioDelayMs.GetValue());
            }

            if (this.token.HasValue())
            {
                writer.WritePropertyName("token");
                writer.Write(this.token.GetValue());
            }

            if (this.enableBuiltInMediaEncryption.HasValue())
            {
                writer.WritePropertyName("enableBuiltInMediaEncryption");
                writer.Write(this.enableBuiltInMediaEncryption.GetValue());
            }

            if (this.publishRhythmPlayerTrack.HasValue())
            {
                writer.WritePropertyName("publishRhythmPlayerTrack");
                writer.Write(this.publishRhythmPlayerTrack.GetValue());
            }

            if (this.isInteractiveAudience.HasValue())
            {
                writer.WritePropertyName("isInteractiveAudience");
                writer.Write(this.isInteractiveAudience.GetValue());
            }

            if (this.customVideoTrackId.HasValue())
            {
                writer.WritePropertyName("customVideoTrackId");
                writer.Write(this.customVideoTrackId.GetValue());
            }

            if (this.isAudioFilterable.HasValue())
            {
                writer.WritePropertyName("isAudioFilterable");
                writer.Write(this.isAudioFilterable.GetValue());
            }

            writer.WriteObjectEnd();
        }
    }

    ///
    /// <summary>
    /// The cloud proxy type.
    /// </summary>
    ///
    public enum PROXY_TYPE
    {
        ///
        /// <summary>
        /// 0: Reserved for future use.
        /// </summary>
        ///
        NONE_PROXY_TYPE = 0,

        ///
        /// <summary>
        /// 1: The cloud proxy for the UDP protocol, that is, the Force UDP cloud proxy mode. In this mode, the SDK always transmits data over UDP.
        /// </summary>
        ///
        UDP_PROXY_TYPE = 1,

        ///
        /// <summary>
        /// 2: The cloud proxy for the TCP (encryption) protocol, that is, the Force TCP cloud proxy mode. In this mode, the SDK always transmits data over TCP/TLS 443.
        /// </summary>
        ///
        TCP_PROXY_TYPE = 2,

        ///
        /// <summary>
        /// 3: Reserved for future use.
        /// </summary>
        ///
        LOCAL_PROXY_TYPE = 3,

        ///
        /// <summary>
        /// 4: Automatic mode. In this mode, the SDK attempts a direct connection to SD-RTN™ and automatically switches to TCP/TLS 443 if the attempt fails.
        /// </summary>
        ///
        TCP_PROXY_AUTO_FALLBACK_TYPE = 4,

        ///
        /// @ignore
        ///
        HTTP_PROXY_TYPE = 5,

        ///
        /// @ignore
        ///
        HTTPS_PROXY_TYPE = 6,
    }

    ///
    /// <summary>
    /// The type of the advanced feature.
    /// </summary>
    ///
    public enum FeatureType
    {
        ///
        /// <summary>
        /// 1: Virtual background.
        /// </summary>
        ///
        VIDEO_VIRTUAL_BACKGROUND = 1,

        ///
        /// <summary>
        /// 2: Image enhancement.
        /// </summary>
        ///
        VIDEO_BEAUTY_EFFECT = 2,
    }

    ///
    /// <summary>
    /// The options for leaving a channel.
    /// </summary>
    ///
    public class LeaveChannelOptions
    {
        ///
        /// <summary>
        /// Whether to stop playing and mixing the music file when a user leaves the channel. true : (Default) Stop playing and mixing the music file. false : Do not stop playing and mixing the music file.
        /// </summary>
        ///
        public bool stopAudioMixing;

        ///
        /// <summary>
        /// Whether to stop playing all audio effects when a user leaves the channel. true : (Default) Stop playing all audio effects. false : Do not stop playing any audio effect.
        /// </summary>
        ///
        public bool stopAllEffect;

        ///
        /// <summary>
        /// Whether to stop microphone recording when a user leaves the channel. true : (Default) Stop microphone recording. false : Do not stop microphone recording.
        /// </summary>
        ///
        public bool stopMicrophoneRecording;

        public LeaveChannelOptions()
        {
            this.stopAudioMixing = true;
            this.stopAllEffect = true;
            this.stopMicrophoneRecording = true;
        }

        public LeaveChannelOptions(bool stopAudioMixing, bool stopAllEffect, bool stopMicrophoneRecording)
        {
            this.stopAudioMixing = stopAudioMixing;
            this.stopAllEffect = stopAllEffect;
            this.stopMicrophoneRecording = stopMicrophoneRecording;
        }
    }

    ///
    /// @ignore
    ///
    public class RtcEngineContext : IOptionalJsonParse
    {
        ///
        /// @ignore
        ///
        public string appId;

        ///
        /// @ignore
        ///
        public ulong context;

        ///
        /// @ignore
        ///
        public CHANNEL_PROFILE_TYPE channelProfile;

        ///
        /// @ignore
        ///
        public string license;

        ///
        /// @ignore
        ///
        public AUDIO_SCENARIO_TYPE audioScenario;

        ///
        /// @ignore
        ///
        public AREA_CODE areaCode;

        ///
        /// @ignore
        ///
        public LogConfig logConfig;

        ///
        /// @ignore
        ///
        public Optional<THREAD_PRIORITY_TYPE> threadPriority = new Optional<THREAD_PRIORITY_TYPE>();

        ///
        /// @ignore
        ///
        public bool useExternalEglContext;

        ///
        /// @ignore
        ///
        public bool domainLimit;

        ///
        /// @ignore
        ///
        public bool autoRegisterAgoraExtensions;

        public RtcEngineContext()
        {
            this.appId = "";
            this.context = 0;
            this.channelProfile = CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING;
            this.license = "";
            this.audioScenario = AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT;
            this.areaCode = AREA_CODE.AREA_CODE_GLOB;
            this.logConfig = new LogConfig();
            this.useExternalEglContext = false;
            this.domainLimit = false;
            this.autoRegisterAgoraExtensions = true;
        }

        public RtcEngineContext(string appId, ulong context, CHANNEL_PROFILE_TYPE channelProfile, string license, AUDIO_SCENARIO_TYPE audioScenario, AREA_CODE areaCode, LogConfig logConfig, Optional<THREAD_PRIORITY_TYPE> threadPriority, bool useExternalEglContext, bool domainLimit, bool autoRegisterAgoraExtensions)
        {
            this.appId = appId;
            this.context = context;
            this.channelProfile = channelProfile;
            this.license = license;
            this.audioScenario = audioScenario;
            this.areaCode = areaCode;
            this.logConfig = logConfig;
            this.threadPriority = threadPriority;
            this.useExternalEglContext = useExternalEglContext;
            this.domainLimit = domainLimit;
            this.autoRegisterAgoraExtensions = autoRegisterAgoraExtensions;
        }

        ///
        /// @ignore
        ///
        public virtual void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            writer.WritePropertyName("appId");
            writer.Write(this.appId);

            writer.WritePropertyName("context");
            writer.Write(this.context);

            writer.WritePropertyName("channelProfile");
            AgoraJson.WriteEnum(writer, this.channelProfile);

            writer.WritePropertyName("license");
            writer.Write(this.license);

            writer.WritePropertyName("audioScenario");
            AgoraJson.WriteEnum(writer, this.audioScenario);

            writer.WritePropertyName("areaCode");
            AgoraJson.WriteEnum(writer, this.areaCode);

            writer.WritePropertyName("logConfig");
            JsonMapper.WriteValue(this.logConfig, writer, false, 0);

            if (this.threadPriority.HasValue())
            {
                writer.WritePropertyName("threadPriority");
                AgoraJson.WriteEnum(writer, this.threadPriority.GetValue());
            }

            writer.WritePropertyName("useExternalEglContext");
            writer.Write(this.useExternalEglContext);

            writer.WritePropertyName("domainLimit");
            writer.Write(this.domainLimit);

            writer.WritePropertyName("autoRegisterAgoraExtensions");
            writer.Write(this.autoRegisterAgoraExtensions);

            writer.WriteObjectEnd();
        }
    }

    ///
    /// <summary>
    /// Metadata type of the observer. We only support video metadata for now.
    /// </summary>
    ///
    public enum METADATA_TYPE
    {
        ///
        /// <summary>
        /// The type of metadata is unknown.
        /// </summary>
        ///
        UNKNOWN_METADATA = -1,

        ///
        /// <summary>
        /// The type of metadata is video.
        /// </summary>
        ///
        VIDEO_METADATA = 0,
    }

    ///
    /// @ignore
    ///
    public enum MAX_METADATA_SIZE_TYPE
    {
        ///
        /// @ignore
        ///
        INVALID_METADATA_SIZE_IN_BYTE = -1,

        ///
        /// @ignore
        ///
        DEFAULT_METADATA_SIZE_IN_BYTE = 512,

        ///
        /// @ignore
        ///
        MAX_METADATA_SIZE_IN_BYTE = 1024,
    }

    ///
    /// <summary>
    /// Media metadata.
    /// </summary>
    ///
    public class Metadata
    {
        ///
        /// <summary>
        /// The user ID.
        ///  For the recipient: The ID of the remote user who sent the Metadata.
        ///  For the sender: Ignore it.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// The buffer size of the sent or received Metadata.
        /// </summary>
        ///
        public uint size;

        ///
        /// <summary>
        /// The buffer address of the sent or received Metadata.
        /// </summary>
        ///
        public IntPtr buffer;

        ///
        /// <summary>
        /// The timestamp (ms) of Metadata.
        /// </summary>
        ///
        public long timeStampMs;

        public Metadata()
        {
            this.uid = 0;
            this.size = 0;
            this.buffer = IntPtr.Zero;
            this.timeStampMs = 0;
        }

        public Metadata(uint uid, uint size, IntPtr buffer, long timeStampMs)
        {
            this.uid = uid;
            this.size = size;
            this.buffer = buffer;
            this.timeStampMs = timeStampMs;
        }
    }

    ///
    /// <summary>
    /// Reasons for the changes in CDN streaming status.
    /// </summary>
    ///
    public enum DIRECT_CDN_STREAMING_REASON
    {
        ///
        /// <summary>
        /// 0: No error.
        /// </summary>
        ///
        DIRECT_CDN_STREAMING_REASON_OK = 0,

        ///
        /// <summary>
        /// 1: A general error; no specific reason. You can try to push the media stream again.
        /// </summary>
        ///
        DIRECT_CDN_STREAMING_REASON_FAILED = 1,

        ///
        /// <summary>
        /// 2: An error occurs when pushing audio streams. For example, the local audio capture device is not working properly, is occupied by another process, or does not get the permission required.
        /// </summary>
        ///
        DIRECT_CDN_STREAMING_REASON_AUDIO_PUBLICATION = 2,

        ///
        /// <summary>
        /// 3: An error occurs when pushing video streams. For example, the local video capture device is not working properly, is occupied by another process, or does not get the permission required.
        /// </summary>
        ///
        DIRECT_CDN_STREAMING_REASON_VIDEO_PUBLICATION = 3,

        ///
        /// <summary>
        /// 4: Fails to connect to the CDN.
        /// </summary>
        ///
        DIRECT_CDN_STREAMING_REASON_NET_CONNECT = 4,

        ///
        /// <summary>
        /// 5: The URL is already being used. Use a new URL for streaming.
        /// </summary>
        ///
        DIRECT_CDN_STREAMING_REASON_BAD_NAME = 5,
    }

    ///
    /// <summary>
    /// The current CDN streaming state.
    /// </summary>
    ///
    public enum DIRECT_CDN_STREAMING_STATE
    {
        ///
        /// <summary>
        /// 0: The initial state before the CDN streaming starts.
        /// </summary>
        ///
        DIRECT_CDN_STREAMING_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: Streams are being pushed to the CDN. The SDK returns this value when you call the StartDirectCdnStreaming method to push streams to the CDN.
        /// </summary>
        ///
        DIRECT_CDN_STREAMING_STATE_RUNNING = 1,

        ///
        /// <summary>
        /// 2: Stops pushing streams to the CDN. The SDK returns this value when you call the StopDirectCdnStreaming method to stop pushing streams to the CDN.
        /// </summary>
        ///
        DIRECT_CDN_STREAMING_STATE_STOPPED = 2,

        ///
        /// <summary>
        /// 3: Fails to push streams to the CDN. You can troubleshoot the issue with the information reported by the OnDirectCdnStreamingStateChanged callback, and then push streams to the CDN again.
        /// </summary>
        ///
        DIRECT_CDN_STREAMING_STATE_FAILED = 3,

        ///
        /// <summary>
        /// 4: Tries to reconnect the Agora server to the CDN. The SDK attempts to reconnect a maximum of 10 times; if the connection is not restored, the streaming state becomes DIRECT_CDN_STREAMING_STATE_FAILED.
        /// </summary>
        ///
        DIRECT_CDN_STREAMING_STATE_RECOVERING = 4,
    }

    ///
    /// <summary>
    /// The statistics of the current CDN streaming.
    /// </summary>
    ///
    public class DirectCdnStreamingStats
    {
        ///
        /// <summary>
        /// The width (px) of the video frame.
        /// </summary>
        ///
        public int videoWidth;

        ///
        /// <summary>
        /// The height (px) of the video frame.
        /// </summary>
        ///
        public int videoHeight;

        ///
        /// <summary>
        /// The frame rate (fps) of the current video frame.
        /// </summary>
        ///
        public int fps;

        ///
        /// <summary>
        /// The bitrate (bps) of the current video frame.
        /// </summary>
        ///
        public int videoBitrate;

        ///
        /// <summary>
        /// The bitrate (bps) of the current audio frame.
        /// </summary>
        ///
        public int audioBitrate;

        public DirectCdnStreamingStats(int videoWidth, int videoHeight, int fps, int videoBitrate, int audioBitrate)
        {
            this.videoWidth = videoWidth;
            this.videoHeight = videoHeight;
            this.fps = fps;
            this.videoBitrate = videoBitrate;
            this.audioBitrate = audioBitrate;
        }
        public DirectCdnStreamingStats()
        {
        }

    }

    ///
    /// <summary>
    /// The media setting options for the host.
    /// </summary>
    ///
    public class DirectCdnStreamingMediaOptions : IOptionalJsonParse
    {
        ///
        /// <summary>
        /// Sets whether to publish the video captured by the camera: true : Publish the video captured by the camera. false : (Default) Do not publish the video captured by the camera.
        /// </summary>
        ///
        public Optional<bool> publishCameraTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Sets whether to publish the audio captured by the microphone: true : Publish the audio captured by the microphone. false : (Default) Do not publish the audio captured by the microphone.
        /// </summary>
        ///
        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Sets whether to publish the captured audio from a custom source: true : Publish the captured audio from a custom source. false : (Default) Do not publish the captured audio from the custom source.
        /// </summary>
        ///
        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Sets whether to publish the captured video from a custom source: true : Publish the captured video from a custom source. false : (Default) Do not publish the captured video from the custom source.
        /// </summary>
        ///
        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<int> publishMediaPlayerId = new Optional<int>();

        ///
        /// <summary>
        /// The video track ID returned by calling the CreateCustomVideoTrack method. The default value is 0.
        /// </summary>
        ///
        public Optional<uint> customVideoTrackId = new Optional<uint>();

        public DirectCdnStreamingMediaOptions()
        {
        }

        public DirectCdnStreamingMediaOptions(Optional<bool> publishCameraTrack, Optional<bool> publishMicrophoneTrack, Optional<bool> publishCustomAudioTrack, Optional<bool> publishCustomVideoTrack, Optional<bool> publishMediaPlayerAudioTrack, Optional<int> publishMediaPlayerId, Optional<uint> customVideoTrackId)
        {
            this.publishCameraTrack = publishCameraTrack;
            this.publishMicrophoneTrack = publishMicrophoneTrack;
            this.publishCustomAudioTrack = publishCustomAudioTrack;
            this.publishCustomVideoTrack = publishCustomVideoTrack;
            this.publishMediaPlayerAudioTrack = publishMediaPlayerAudioTrack;
            this.publishMediaPlayerId = publishMediaPlayerId;
            this.customVideoTrackId = customVideoTrackId;
        }

        ///
        /// @ignore
        ///
        public virtual void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            if (this.publishCameraTrack.HasValue())
            {
                writer.WritePropertyName("publishCameraTrack");
                writer.Write(this.publishCameraTrack.GetValue());
            }

            if (this.publishMicrophoneTrack.HasValue())
            {
                writer.WritePropertyName("publishMicrophoneTrack");
                writer.Write(this.publishMicrophoneTrack.GetValue());
            }

            if (this.publishCustomAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishCustomAudioTrack");
                writer.Write(this.publishCustomAudioTrack.GetValue());
            }

            if (this.publishCustomVideoTrack.HasValue())
            {
                writer.WritePropertyName("publishCustomVideoTrack");
                writer.Write(this.publishCustomVideoTrack.GetValue());
            }

            if (this.publishMediaPlayerAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishMediaPlayerAudioTrack");
                writer.Write(this.publishMediaPlayerAudioTrack.GetValue());
            }

            if (this.publishMediaPlayerId.HasValue())
            {
                writer.WritePropertyName("publishMediaPlayerId");
                writer.Write(this.publishMediaPlayerId.GetValue());
            }

            if (this.customVideoTrackId.HasValue())
            {
                writer.WritePropertyName("customVideoTrackId");
                writer.Write(this.customVideoTrackId.GetValue());
            }

            writer.WriteObjectEnd();
        }
    }

    ///
    /// @ignore
    ///
    public class ExtensionInfo
    {
        ///
        /// @ignore
        ///
        public MEDIA_SOURCE_TYPE mediaSourceType;

        ///
        /// @ignore
        ///
        public uint remoteUid;

        ///
        /// @ignore
        ///
        public string channelId;

        ///
        /// @ignore
        ///
        public uint localUid;

        public ExtensionInfo()
        {
            this.mediaSourceType = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE;
            this.remoteUid = 0;
            this.channelId = "";
            this.localUid = 0;
        }

        public ExtensionInfo(MEDIA_SOURCE_TYPE mediaSourceType, uint remoteUid, string channelId, uint localUid)
        {
            this.mediaSourceType = mediaSourceType;
            this.remoteUid = remoteUid;
            this.channelId = channelId;
            this.localUid = localUid;
        }
    }

    ///
    /// @ignore
    ///
    public enum QUALITY_REPORT_FORMAT_TYPE
    {
        ///
        /// @ignore
        ///
        QUALITY_REPORT_JSON = 0,

        ///
        /// @ignore
        ///
        QUALITY_REPORT_HTML = 1,
    }

    ///
    /// <summary>
    /// Media device states.
    /// </summary>
    ///
    public enum MEDIA_DEVICE_STATE_TYPE
    {
        ///
        /// <summary>
        /// 0: The device is ready for use.
        /// </summary>
        ///
        MEDIA_DEVICE_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: The device is in use.
        /// </summary>
        ///
        MEDIA_DEVICE_STATE_ACTIVE = 1,

        ///
        /// <summary>
        /// 2: The device is disabled.
        /// </summary>
        ///
        MEDIA_DEVICE_STATE_DISABLED = 2,

        ///
        /// <summary>
        /// 4: The device is not found.
        /// </summary>
        ///
        MEDIA_DEVICE_STATE_NOT_PRESENT = 4,

        ///
        /// <summary>
        /// 8: The device is unplugged.
        /// </summary>
        ///
        MEDIA_DEVICE_STATE_UNPLUGGED = 8,
    }

    ///
    /// <summary>
    /// Video profile.
    /// </summary>
    ///
    public enum VIDEO_PROFILE_TYPE
    {
        ///
        /// <summary>
        /// 0: 160 × 120, frame rate 15 fps, bitrate 65 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_120P = 0,

        ///
        /// <summary>
        /// 2: 120 × 120, frame rate 15 fps, bitrate 50 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_120P_3 = 2,

        ///
        /// <summary>
        /// 10: 320 × 180, frame rate 15 fps, bitrate 140 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_180P = 10,

        ///
        /// <summary>
        /// 12: 180 × 180, frame rate 15 fps, bitrate 100 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_180P_3 = 12,

        ///
        /// <summary>
        /// 13: 240 × 180, frame rate 15 fps, bitrate 120 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_180P_4 = 13,

        ///
        /// <summary>
        /// 20: 320 × 240, frame rate 15 fps, bitrate 200 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_240P = 20,

        ///
        /// <summary>
        /// 22: 240 × 240, frame rate 15 fps, bitrate 140 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_240P_3 = 22,

        ///
        /// <summary>
        /// 23: 424 × 240, frame rate 15 fps, bitrate 220 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_240P_4 = 23,

        ///
        /// <summary>
        /// 30: 640 × 360, frame rate 15 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P = 30,

        ///
        /// <summary>
        /// 32: 360 × 360, frame rate 15 fps, bitrate 260 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_3 = 32,

        ///
        /// <summary>
        /// 33: 640 × 360, frame rate 30 fps, bitrate 600 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_4 = 33,

        ///
        /// <summary>
        /// 35: 360 × 360, frame rate 30 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_6 = 35,

        ///
        /// <summary>
        /// 36: 480 × 360, frame rate 15 fps, bitrate 320 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_7 = 36,

        ///
        /// <summary>
        /// 37: 480 × 360, frame rate 30 fps, bitrate 490 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_8 = 37,

        ///
        /// <summary>
        /// 38: 640 × 360, frame rate 15 fps, bitrate 800 Kbps. This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_9 = 38,

        ///
        /// <summary>
        /// 39: 640 × 360, frame rate 24 fps, bitrate 800 Kbps. This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_10 = 39,

        ///
        /// <summary>
        /// 100: 640 × 360, frame rate 24 fps, bitrate 1000 Kbps. This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_11 = 100,

        ///
        /// <summary>
        /// 40: 640 × 480, frame rate 15 fps, bitrate 500 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P = 40,

        ///
        /// <summary>
        /// 42: 480 × 480, frame rate 15 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_3 = 42,

        ///
        /// <summary>
        /// 43: 640 × 480, frame rate 30 fps, bitrate 750 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_4 = 43,

        ///
        /// <summary>
        /// 45: 480 × 480, frame rate 30 fps, bitrate 600 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_6 = 45,

        ///
        /// <summary>
        /// 47: 848 × 480, frame rate 15 fps, bitrate 610 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_8 = 47,

        ///
        /// <summary>
        /// 48: 848 × 480, frame rate 30 fps, bitrate 930 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_9 = 48,

        ///
        /// <summary>
        /// 49: 640 × 480, frame rate 10 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_10 = 49,

        ///
        /// <summary>
        /// 50: 1280 × 720, frame rate 15 fps, bitrate 1130 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_720P = 50,

        ///
        /// <summary>
        /// 52: 1280 × 720, frame rate 30 fps, bitrate 1710 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_720P_3 = 52,

        ///
        /// <summary>
        /// 54: 960 × 720, frame rate 15 fps, bitrate 910 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_720P_5 = 54,

        ///
        /// <summary>
        /// 55: 960 × 720, frame rate 30 fps, bitrate 1380 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_720P_6 = 55,

        ///
        /// <summary>
        /// 60: 1920 × 1080, frame rate 15 fps, bitrate 2080 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_1080P = 60,

        ///
        /// <summary>
        /// 60: 1920 × 1080, frame rate 30 fps, bitrate 3150 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_1080P_3 = 62,

        ///
        /// <summary>
        /// 64: 1920 × 1080, frame rate 60 fps, bitrate 4780 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_1080P_5 = 64,

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_LANDSCAPE_1440P = 66,

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_LANDSCAPE_1440P_2 = 67,

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_LANDSCAPE_4K = 70,

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_LANDSCAPE_4K_3 = 72,

        ///
        /// <summary>
        /// 1000: 120 × 160, frame rate 15 fps, bitrate 65 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_120P = 1000,

        ///
        /// <summary>
        /// 1002: 120 × 120, frame rate 15 fps, bitrate 50 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_120P_3 = 1002,

        ///
        /// <summary>
        /// 1010: 180 × 320, frame rate 15 fps, bitrate 140 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_180P = 1010,

        ///
        /// <summary>
        /// 1012: 180 × 180, frame rate 15 fps, bitrate 100 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_180P_3 = 1012,

        ///
        /// <summary>
        /// 1013: 180 × 240, frame rate 15 fps, bitrate 120 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_180P_4 = 1013,

        ///
        /// <summary>
        /// 1020: 240 × 320, frame rate 15 fps, bitrate 200 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_240P = 1020,

        ///
        /// <summary>
        /// 1022: 240 × 240, frame rate 15 fps, bitrate 140 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_240P_3 = 1022,

        ///
        /// <summary>
        /// 1023: 240 × 424, frame rate 15 fps, bitrate 220 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_240P_4 = 1023,

        ///
        /// <summary>
        /// 1030: 360 × 640, frame rate 15 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P = 1030,

        ///
        /// <summary>
        /// 1032: 360 × 360, frame rate 15 fps, bitrate 260 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_3 = 1032,

        ///
        /// <summary>
        /// 1033: 360 × 640, frame rate 15 fps, bitrate 600 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_4 = 1033,

        ///
        /// <summary>
        /// 1035: 360 × 360, frame rate 30 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_6 = 1035,

        ///
        /// <summary>
        /// 1036: 360 × 480, frame rate 15 fps, bitrate 320 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_7 = 1036,

        ///
        /// <summary>
        /// 1037: 360 × 480, frame rate 30 fps, bitrate 490 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_8 = 1037,

        ///
        /// <summary>
        /// 1038: 360 × 640, frame rate 15 fps, bitrate 800 Kbps. This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_9 = 1038,

        ///
        /// <summary>
        /// 1039: 360 × 640, frame rate 24 fps, bitrate 800 Kbps. This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_10 = 1039,

        ///
        /// <summary>
        /// 1100: 360 × 640, frame rate 24 fps, bitrate 1000 Kbps. This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_11 = 1100,

        ///
        /// <summary>
        /// 1040: 480 × 640, frame rate 15 fps, bitrate 500 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P = 1040,

        ///
        /// <summary>
        /// 1042: 480 × 480, frame rate 15 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_3 = 1042,

        ///
        /// <summary>
        /// 1043: 480 × 640, frame rate 30 fps, bitrate 750 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_4 = 1043,

        ///
        /// <summary>
        /// 1045: 480 × 480, frame rate 30 fps, bitrate 600 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_6 = 1045,

        ///
        /// <summary>
        /// 1047: 480 × 848, frame rate 15 fps, bitrate 610 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_8 = 1047,

        ///
        /// <summary>
        /// 1048: 480 × 848, frame rate 30 fps, bitrate 930 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_9 = 1048,

        ///
        /// <summary>
        /// 1049: 480 × 640, frame rate 10 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_10 = 1049,

        ///
        /// <summary>
        /// 1050: 720 × 1280, frame rate 15 fps, bitrate 1130 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_720P = 1050,

        ///
        /// <summary>
        /// 1052: 720 × 1280, frame rate 30 fps, bitrate 1710 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_720P_3 = 1052,

        ///
        /// <summary>
        /// 1054: 720 × 960, frame rate 15 fps, bitrate 910 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_720P_5 = 1054,

        ///
        /// <summary>
        /// 1055: 720 × 960, frame rate 30 fps, bitrate 1380 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_720P_6 = 1055,

        ///
        /// <summary>
        /// 1060: 1080 × 1920, frame rate 15 fps, bitrate 2080 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_1080P = 1060,

        ///
        /// <summary>
        /// 1062: 1080 × 1920, frame rate 30 fps, bitrate 3150 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_1080P_3 = 1062,

        ///
        /// <summary>
        /// 1064: 1080 × 1920, frame rate 60 fps, bitrate 4780 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_1080P_5 = 1064,

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_PORTRAIT_1440P = 1066,

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_PORTRAIT_1440P_2 = 1067,

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_PORTRAIT_4K = 1070,

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_PORTRAIT_4K_3 = 1072,

        ///
        /// <summary>
        /// (Default) 640 × 360, frame rate 15 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_DEFAULT = VIDEO_PROFILE_LANDSCAPE_360P,
    }

    #endregion terra IAgoraRtcEngine.h
}