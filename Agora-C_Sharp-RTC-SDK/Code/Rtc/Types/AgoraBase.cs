using System;
using Agora.Rtc.LitJson;
namespace Agora.Rtc
{
    using view_t = Int64;

    #region terra AgoraBase.h

    public class EncodedVideoFrameInfo : EncodedVideoFrameInfoBase
    {
        public uint uid;

        public EncodedVideoFrameInfo()
        {
            this.uid = 0;
        }

        public EncodedVideoFrameInfo(VIDEO_CODEC_TYPE codecType, int width, int height, int framesPerSecond, VIDEO_FRAME_TYPE frameType, VIDEO_ORIENTATION rotation, int trackId, long captureTimeMs, long decodeTimeMs, VIDEO_STREAM_TYPE streamType, uint uid)
        : base(codecType, width, height, framesPerSecond, frameType, rotation, trackId, captureTimeMs, decodeTimeMs, streamType)
        {
            this.uid = uid;
        }
    }



    public class AudioVolumeInfo : AudioVolumeInfoBase
    {
        public uint uid;

        public AudioVolumeInfo()
        {
            this.uid = 0;
        }

        public AudioVolumeInfo(uint volume, uint vad, double voicePitch, uint uid)
        : base(volume, vad, voicePitch)
        {
            this.uid = uid;
        }
    }



    public class TranscodingUser : TranscodingUserBase
    {
        public uint uid;

        public TranscodingUser()
        {
            this.uid = 0;
        }

        public TranscodingUser(int x, int y, int width, int height, int zOrder, double alpha, int audioChannel, uint uid)
        : base(x, y, width, height, zOrder, alpha, audioChannel)
        {
            this.uid = uid;
        }
    }



    public class LiveTranscoding : LiveTranscodingBase
    {
        public uint userCount;

        public TranscodingUser[] transcodingUsers;

        public LiveTranscoding()
        {
            this.userCount = 0;
            this.transcodingUsers = new TranscodingUser[0];
        }

        public LiveTranscoding(int width, int height, int videoBitrate, int videoFramerate, bool lowLatency, int videoGop, VIDEO_CODEC_PROFILE_TYPE videoCodecProfile, uint backgroundColor, VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType, string transcodingExtraInfo, string metadata, RtcImage[] watermark, uint watermarkCount, RtcImage[] backgroundImage, uint backgroundImageCount, AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels, AUDIO_CODEC_PROFILE_TYPE audioCodecProfile, LiveStreamAdvancedFeature[] advancedFeatures, uint advancedFeatureCount, uint userCount, TranscodingUser[] transcodingUsers)
        : base(width, height, videoBitrate, videoFramerate, lowLatency, videoGop, videoCodecProfile, backgroundColor, videoCodecType, transcodingExtraInfo, metadata, watermark, watermarkCount, backgroundImage, backgroundImageCount, audioSampleRate, audioBitrate, audioChannels, audioCodecProfile, advancedFeatures, advancedFeatureCount)
        {
            this.userCount = userCount;
            this.transcodingUsers = transcodingUsers;
        }
    }



    public class TranscodingVideoStream : TranscodingVideoStreamBase
    {
        public uint remoteUserUid;

        public TranscodingVideoStream()
        {
            this.remoteUserUid = 0;
        }

        public TranscodingVideoStream(VIDEO_SOURCE_TYPE sourceType, string imageUrl, int mediaPlayerId, int x, int y, int width, int height, int zOrder, double alpha, bool mirror, uint remoteUserUid)
        : base(sourceType, imageUrl, mediaPlayerId, x, y, width, height, zOrder, alpha, mirror)
        {
            this.remoteUserUid = remoteUserUid;
        }
    }



    public class LocalTranscoderConfiguration : LocalTranscoderConfigurationBase
    {
        public uint streamCount;

        public TranscodingVideoStream[] videoInputStreams;

        public LocalTranscoderConfiguration()
        {
            this.streamCount = 0;
            this.videoInputStreams = new TranscodingVideoStream[0];
        }

        public LocalTranscoderConfiguration(VideoEncoderConfiguration videoOutputConfiguration, bool syncWithPrimaryCamera, uint streamCount, TranscodingVideoStream[] videoInputStreams)
        : base(videoOutputConfiguration, syncWithPrimaryCamera)
        {
            this.streamCount = streamCount;
            this.videoInputStreams = videoInputStreams;
        }
    }



    public class VideoCanvas : VideoCanvasBase
    {
        public uint uid;

        public VideoCanvas()
        {
            this.uid = 0;
        }

        public VideoCanvas(view_t v, RENDER_MODE_TYPE m, VIDEO_MIRROR_MODE_TYPE mt, uint u)
        : base(v, m, mt)
        {
            this.uid = u;
        }

        public VideoCanvas(view_t v, RENDER_MODE_TYPE m, VIDEO_MIRROR_MODE_TYPE mt)
        : base(v, m, mt)
        {
            this.uid = 0;
        }

        public VideoCanvas(view_t v, RENDER_MODE_TYPE m, VIDEO_MIRROR_MODE_TYPE mt, uint u, uint subu)
        : base(v, m, mt, subu)
        {
            this.uid = u;
        }

        public VideoCanvas(view_t view, uint backgroundColor, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, VIDEO_VIEW_SETUP_MODE setupMode, VIDEO_SOURCE_TYPE sourceType, int mediaPlayerId, Rectangle cropArea, bool enableAlphaMask, VIDEO_MODULE_POSITION position, uint subviewUid, uint uid)
        : base(view, backgroundColor, renderMode, mirrorMode, setupMode, sourceType, mediaPlayerId, cropArea, enableAlphaMask, position, subviewUid)
        {
            this.uid = uid;
        }
    }



    public class ChannelMediaInfo : ChannelMediaInfoBase
    {
        public uint uid;

        public ChannelMediaInfo()
        {
        }

        public ChannelMediaInfo(string c, string t, uint u)
        : base(c, t)
        {
            this.uid = u;
        }

    }



    public class ChannelMediaRelayConfiguration : ChannelMediaRelayConfigurationBase
    {
        public ChannelMediaInfo[] srcInfo;

        public ChannelMediaInfo[] destInfos;

        public ChannelMediaRelayConfiguration()
        {
            this.srcInfo = new ChannelMediaInfo[0];
            this.destInfos = new ChannelMediaInfo[0];
        }

        public ChannelMediaRelayConfiguration(int destCount, ChannelMediaInfo[] srcInfo, ChannelMediaInfo[] destInfos)
        : base(destCount)
        {
            this.srcInfo = srcInfo;
            this.destInfos = destInfos;
        }
    }



    public class RecorderStreamInfo : RecorderStreamInfoBase
    {
        public uint uid;

        public RecorderStreamInfo()
        {
            this.uid = 0;
        }

        public RecorderStreamInfo(string channelId, uint uid)
        : base(channelId)
        {
            this.uid = uid;
        }

    }




    #endregion terra AgoraBase.h
}