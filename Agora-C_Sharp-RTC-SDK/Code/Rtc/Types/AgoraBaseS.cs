using System;
using Agora.Rtc.LitJson;
namespace Agora.Rtc
{
    using view_t = Int64;

    #region terra AgoraBaseS.h
    public class EncodedVideoFrameInfoS : EncodedVideoFrameInfoBase
    {
        public string userAccount;

        public EncodedVideoFrameInfoS()
        {
            this.userAccount = "";
        }

        public EncodedVideoFrameInfoS(VIDEO_CODEC_TYPE codecType, int width, int height, int framesPerSecond, VIDEO_FRAME_TYPE frameType, VIDEO_ORIENTATION rotation, int trackId, long captureTimeMs, long decodeTimeMs, VIDEO_STREAM_TYPE streamType, string userAccount)
        : base(codecType, width, height, framesPerSecond, frameType, rotation, trackId, captureTimeMs, decodeTimeMs, streamType)
        {
            this.userAccount = userAccount;
        }
    }



    public class AudioVolumeInfoS : AudioVolumeInfoBase
    {
        public string userAccount;

        public AudioVolumeInfoS()
        {
            this.userAccount = "";
        }

        public AudioVolumeInfoS(uint volume, uint vad, double voicePitch, string userAccount)
        : base(volume, vad, voicePitch)
        {
            this.userAccount = userAccount;
        }
    }



    public class TranscodingUserS : TranscodingUserBase
    {
        public string userAccount;

        public TranscodingUserS()
        {
            this.userAccount = "";
        }

        public TranscodingUserS(int x, int y, int width, int height, int zOrder, double alpha, int audioChannel, string userAccount)
        : base(x, y, width, height, zOrder, alpha, audioChannel)
        {
            this.userAccount = userAccount;
        }
    }



    public class LiveTranscodingS : LiveTranscodingBase
    {
        public uint userCount;

        public TranscodingUserS[] transcodingUsersS;

        public LiveTranscodingS()
        {
            this.userCount = 0;
            this.transcodingUsersS = new TranscodingUserS[0];
        }

        public LiveTranscodingS(int width, int height, int videoBitrate, int videoFramerate, bool lowLatency, int videoGop, VIDEO_CODEC_PROFILE_TYPE videoCodecProfile, uint backgroundColor, VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType, string transcodingExtraInfo, string metadata, RtcImage[] watermark, uint watermarkCount, RtcImage[] backgroundImage, uint backgroundImageCount, AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels, AUDIO_CODEC_PROFILE_TYPE audioCodecProfile, LiveStreamAdvancedFeature[] advancedFeatures, uint advancedFeatureCount, uint userCount, TranscodingUserS[] transcodingUsersS)
        : base(width, height, videoBitrate, videoFramerate, lowLatency, videoGop, videoCodecProfile, backgroundColor, videoCodecType, transcodingExtraInfo, metadata, watermark, watermarkCount, backgroundImage, backgroundImageCount, audioSampleRate, audioBitrate, audioChannels, audioCodecProfile, advancedFeatures, advancedFeatureCount)
        {
            this.userCount = userCount;
            this.transcodingUsersS = transcodingUsersS;
        }
    }



    public class TranscodingVideoStreamS : TranscodingVideoStreamBase
    {
        public string remoteUserAccount;

        public TranscodingVideoStreamS()
        {
            this.remoteUserAccount = "";
        }

        public TranscodingVideoStreamS(VIDEO_SOURCE_TYPE sourceType, string imageUrl, int mediaPlayerId, int x, int y, int width, int height, int zOrder, double alpha, bool mirror, string remoteUserAccount)
        : base(sourceType, imageUrl, mediaPlayerId, x, y, width, height, zOrder, alpha, mirror)
        {
            this.remoteUserAccount = remoteUserAccount;
        }
    }



    public class LocalTranscoderConfigurationS : LocalTranscoderConfigurationBase
    {
        public uint streamCount;

        public TranscodingVideoStreamS[] videoInputStreamsS;

        public LocalTranscoderConfigurationS()
        {
            this.streamCount = 0;
            this.videoInputStreamsS = new TranscodingVideoStreamS[0];
        }

        public LocalTranscoderConfigurationS(VideoEncoderConfiguration videoOutputConfiguration, bool syncWithPrimaryCamera, uint streamCount, TranscodingVideoStreamS[] videoInputStreamsS)
        : base(videoOutputConfiguration, syncWithPrimaryCamera)
        {
            this.streamCount = streamCount;
            this.videoInputStreamsS = videoInputStreamsS;
        }
    }



    public class VideoCanvasS : VideoCanvasBase
    {
        public string userAccount;

        public VideoCanvasS()
        {
            this.userAccount = "";
        }

        public VideoCanvasS(view_t v, RENDER_MODE_TYPE m, VIDEO_MIRROR_MODE_TYPE mt, string u)
        : base(v, m, mt)
        {
            this.userAccount = u;
        }

        public VideoCanvasS(view_t v, RENDER_MODE_TYPE m, VIDEO_MIRROR_MODE_TYPE mt)
        : base(v, m, mt)
        {
            this.userAccount = "";
        }

        public VideoCanvasS(view_t view, uint backgroundColor, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, VIDEO_VIEW_SETUP_MODE setupMode, VIDEO_SOURCE_TYPE sourceType, int mediaPlayerId, Rectangle cropArea, bool enableAlphaMask, VIDEO_MODULE_POSITION position, uint subviewUid, string userAccount)
        : base(view, backgroundColor, renderMode, mirrorMode, setupMode, sourceType, mediaPlayerId, cropArea, enableAlphaMask, position, subviewUid)
        {
            this.userAccount = userAccount;
        }
    }



    public class ChannelMediaInfoS : ChannelMediaInfoBase
    {
        public string userAccount;

        public ChannelMediaInfoS()
        {
        }

        public ChannelMediaInfoS(string c, string t, string u)
        : base(c, t)
        {
            this.userAccount = u;
        }

    }



    public class ChannelMediaRelayConfigurationS : ChannelMediaRelayConfigurationBase
    {
        public ChannelMediaInfoS srcInfoS;

        public ChannelMediaInfoS[] destInfosS;

        public ChannelMediaRelayConfigurationS()
        {
            this.srcInfoS = new ChannelMediaInfoS();
            this.destInfosS = new ChannelMediaInfoS[0];
        }

        public ChannelMediaRelayConfigurationS(int destCount, ChannelMediaInfoS srcInfoS, ChannelMediaInfoS[] destInfosS)
        : base(destCount)
        {
            this.srcInfoS = srcInfoS;
            this.destInfosS = destInfosS;
        }
    }



    public class RecorderStreamInfoS : RecorderStreamInfoBase
    {
        public string userAccount;

        public RecorderStreamInfoS()
        {
            this.userAccount = "";
        }

        public RecorderStreamInfoS(string channelId, string userAccount)
        : base(channelId)
        {
            this.userAccount = userAccount;
        }

    }




    #endregion terra AgoraBaseS.h
}