using System;
using view_t = System.Int64;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
{
    #region terra IAgoraRtcEngine.h
    public class LocalVideoStats : LocalVideoStatsBase
    {
        public uint uid;

        public LocalVideoStats(int sentBitrate, int sentFrameRate, int captureFrameRate, int captureFrameWidth, int captureFrameHeight, int regulatedCaptureFrameRate, int regulatedCaptureFrameWidth, int regulatedCaptureFrameHeight, int encoderOutputFrameRate, int encodedFrameWidth, int encodedFrameHeight, int rendererOutputFrameRate, int targetBitrate, int targetFrameRate, QUALITY_ADAPT_INDICATION qualityAdaptIndication, int encodedBitrate, int encodedFrameCount, VIDEO_CODEC_TYPE codecType, ushort txPacketLossRate, CAPTURE_BRIGHTNESS_LEVEL_TYPE captureBrightnessLevel, bool dualStreamEnabled, int hwEncoderAccelerating, uint uid)
        : base(sentBitrate, sentFrameRate, captureFrameRate, captureFrameWidth, captureFrameHeight, regulatedCaptureFrameRate, regulatedCaptureFrameWidth, regulatedCaptureFrameHeight, encoderOutputFrameRate, encodedFrameWidth, encodedFrameHeight, rendererOutputFrameRate, targetBitrate, targetFrameRate, qualityAdaptIndication, encodedBitrate, encodedFrameCount, codecType, txPacketLossRate, captureBrightnessLevel, dualStreamEnabled, hwEncoderAccelerating)
        {
            this.uid = uid;
        }
        public LocalVideoStats()
        {
        }

    }



    public class RemoteAudioStats : RemoteAudioStatsBase
    {
        public uint uid;

        public RemoteAudioStats()
        {
            this.uid = 0;
        }

        public RemoteAudioStats(int quality, int networkTransportDelay, int jitterBufferDelay, int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate, int totalFrozenTime, int frozenRate, int mosValue, uint frozenRateByCustomPlcCount, uint plcCount, int totalActiveTime, int publishDuration, int qoeQuality, int qualityChangedReason, uint rxAudioBytes, uint uid)
        : base(quality, networkTransportDelay, jitterBufferDelay, audioLossRate, numChannels, receivedSampleRate, receivedBitrate, totalFrozenTime, frozenRate, mosValue, frozenRateByCustomPlcCount, plcCount, totalActiveTime, publishDuration, qoeQuality, qualityChangedReason, rxAudioBytes)
        {
            this.uid = uid;
        }
    }



    public class RemoteVideoStats : RemoteVideoStatsBase
    {
        public uint uid;

        public int delay;

        public RemoteVideoStats(int e2eDelay, int width, int height, int receivedBitrate, int decoderOutputFrameRate, int rendererOutputFrameRate, int frameLossRate, int packetLossRate, VIDEO_STREAM_TYPE rxStreamType, int totalFrozenTime, int frozenRate, int avSyncTimeMs, int totalActiveTime, int publishDuration, int mosValue, uint rxVideoBytes, uint uid, int delay)
        : base(e2eDelay, width, height, receivedBitrate, decoderOutputFrameRate, rendererOutputFrameRate, frameLossRate, packetLossRate, rxStreamType, totalFrozenTime, frozenRate, avSyncTimeMs, totalActiveTime, publishDuration, mosValue, rxVideoBytes)
        {
            this.uid = uid;
            this.delay = delay;
        }
        public RemoteVideoStats()
        {
        }

    }



    public class VideoCompositingLayout : VideoCompositingLayoutBase
    {
        public Region[] regions;

        public int regionCount;

        public VideoCompositingLayout()
        {
            this.regions = new Region[0];
            this.regionCount = 0;
        }

        public VideoCompositingLayout(int canvasWidth, int canvasHeight, string backgroundColor, string appData, int appDataLength, Region[] regions, int regionCount)
        : base(canvasWidth, canvasHeight, backgroundColor, appData, appDataLength)
        {
            this.regions = regions;
            this.regionCount = regionCount;
        }
    }



    public class Region : RegionBase
    {
        public uint uid;

        public Region()
        {
            this.uid = 0;
        }

        public Region(double x, double y, double width, double height, int zOrder, double alpha, RENDER_MODE_TYPE renderMode, uint uid)
        : base(x, y, width, height, zOrder, alpha, renderMode)
        {
            this.uid = uid;
        }
    }



    public class RtcEngineContext : RtcEngineContextBase, IOptionalJsonParse
    {
        public RtcEngineContext()
        {
        }

        public RtcEngineContext(string appId, ulong context, CHANNEL_PROFILE_TYPE channelProfile, string license, AUDIO_SCENARIO_TYPE audioScenario, AREA_CODE areaCode, LogConfig logConfig, Optional<THREAD_PRIORITY_TYPE> threadPriority, bool useExternalEglContext, bool domainLimit, bool autoRegisterAgoraExtensions)
        : base(appId, context, channelProfile, license, audioScenario, areaCode, logConfig, threadPriority, useExternalEglContext, domainLimit, autoRegisterAgoraExtensions)
        {
        }

        public override void ToJson(JsonWriter writer)
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



    public class Metadata : MetadataBase
    {
        public uint uid;

        public Metadata()
        {
            this.uid = 0;
        }

        public Metadata(uint size, IntPtr buffer, long timeStampMs, uint uid)
        : base(size, buffer, timeStampMs)
        {
            this.uid = uid;
        }
    }



    public class ExtensionInfo : ExtensionInfoBase
    {
        public uint remoteUid;

        public uint localUid;

        public ExtensionInfo()
        {
            this.remoteUid = 0;
            this.localUid = 0;
        }

        public ExtensionInfo(MEDIA_SOURCE_TYPE mediaSourceType, string channelId, uint remoteUid, uint localUid)
        : base(mediaSourceType, channelId)
        {
            this.remoteUid = remoteUid;
            this.localUid = localUid;
        }
    }




    #endregion terra IAgoraRtcEngine.h
}