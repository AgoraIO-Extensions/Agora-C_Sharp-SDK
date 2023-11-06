using System;
using view_t = System.Int64;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
{
    #region terra IAgoraRtcEngineS.h
    public class LocalVideoStatsS : LocalVideoStatsBase
    {
        public string userAccount;

        public LocalVideoStatsS()
        {
            this.userAccount = "";
        }

        public LocalVideoStatsS(int sentBitrate, int sentFrameRate, int captureFrameRate, int captureFrameWidth, int captureFrameHeight, int regulatedCaptureFrameRate, int regulatedCaptureFrameWidth, int regulatedCaptureFrameHeight, int encoderOutputFrameRate, int encodedFrameWidth, int encodedFrameHeight, int rendererOutputFrameRate, int targetBitrate, int targetFrameRate, QUALITY_ADAPT_INDICATION qualityAdaptIndication, int encodedBitrate, int encodedFrameCount, VIDEO_CODEC_TYPE codecType, ushort txPacketLossRate, CAPTURE_BRIGHTNESS_LEVEL_TYPE captureBrightnessLevel, bool dualStreamEnabled, int hwEncoderAccelerating, string userAccount)
        : base(sentBitrate, sentFrameRate, captureFrameRate, captureFrameWidth, captureFrameHeight, regulatedCaptureFrameRate, regulatedCaptureFrameWidth, regulatedCaptureFrameHeight, encoderOutputFrameRate, encodedFrameWidth, encodedFrameHeight, rendererOutputFrameRate, targetBitrate, targetFrameRate, qualityAdaptIndication, encodedBitrate, encodedFrameCount, codecType, txPacketLossRate, captureBrightnessLevel, dualStreamEnabled, hwEncoderAccelerating)
        {
            this.userAccount = userAccount;
        }
    }



    public class RemoteAudioStatsS : RemoteAudioStatsBase
    {
        public string userAccount;

        public RemoteAudioStatsS()
        {
            this.userAccount = "";
        }

        public RemoteAudioStatsS(int quality, int networkTransportDelay, int jitterBufferDelay, int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate, int totalFrozenTime, int frozenRate, int mosValue, uint frozenRateByCustomPlcCount, uint plcCount, int totalActiveTime, int publishDuration, int qoeQuality, int qualityChangedReason, uint rxAudioBytes, string userAccount)
        : base(quality, networkTransportDelay, jitterBufferDelay, audioLossRate, numChannels, receivedSampleRate, receivedBitrate, totalFrozenTime, frozenRate, mosValue, frozenRateByCustomPlcCount, plcCount, totalActiveTime, publishDuration, qoeQuality, qualityChangedReason, rxAudioBytes)
        {
            this.userAccount = userAccount;
        }
    }



    public class RemoteVideoStatsS : RemoteVideoStatsBase
    {
        public string userAccount;

        public RemoteVideoStatsS()
        {
            this.userAccount = "";
        }

        public RemoteVideoStatsS(int e2eDelay, int width, int height, int receivedBitrate, int decoderOutputFrameRate, int rendererOutputFrameRate, int frameLossRate, int packetLossRate, VIDEO_STREAM_TYPE rxStreamType, int totalFrozenTime, int frozenRate, int avSyncTimeMs, int totalActiveTime, int publishDuration, int mosValue, uint rxVideoBytes, string userAccount)
        : base(e2eDelay, width, height, receivedBitrate, decoderOutputFrameRate, rendererOutputFrameRate, frameLossRate, packetLossRate, rxStreamType, totalFrozenTime, frozenRate, avSyncTimeMs, totalActiveTime, publishDuration, mosValue, rxVideoBytes)
        {
            this.userAccount = userAccount;
        }
    }



    public class VideoCompositingLayoutS : VideoCompositingLayoutBase
    {
        public RegionS[] regionSs;

        public int regionCount;

        public VideoCompositingLayoutS()
        {
            this.regionSs = new RegionS[0];
            this.regionCount = 0;
        }

        public VideoCompositingLayoutS(int canvasWidth, int canvasHeight, string backgroundColor, string appData, int appDataLength, RegionS[] regionSs, int regionCount)
        : base(canvasWidth, canvasHeight, backgroundColor, appData, appDataLength)
        {
            this.regionSs = regionSs;
            this.regionCount = regionCount;
        }
    }



    public class RegionS : RegionBase
    {
        public string userAccount;

        public RegionS()
        {
            this.userAccount = "";
        }

        public RegionS(double x, double y, double width, double height, int zOrder, double alpha, RENDER_MODE_TYPE renderMode, string userAccount)
        : base(x, y, width, height, zOrder, alpha, renderMode)
        {
            this.userAccount = userAccount;
        }
    }



    public class RtcEngineContextS : RtcEngineContextBase, IOptionalJsonParse
    {
        public RtcEngineContextS()
        {
        }

        public RtcEngineContextS(string appId, ulong context, CHANNEL_PROFILE_TYPE channelProfile, string license, AUDIO_SCENARIO_TYPE audioScenario, AREA_CODE areaCode, LogConfig logConfig, Optional<THREAD_PRIORITY_TYPE> threadPriority, bool useExternalEglContext, bool domainLimit, bool autoRegisterAgoraExtensions)
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



    public class MetadataS : MetadataBase
    {
        public string userAccount;

        public MetadataS()
        {
            this.userAccount = "";
        }

        public MetadataS(uint size, IntPtr buffer, long timeStampMs, string userAccount)
        : base(size, buffer, timeStampMs)
        {
            this.userAccount = userAccount;
        }
    }



    public class ExtensionInfoS : ExtensionInfoBase
    {
        public string remoteUserAccount;

        public string localUserAccount;

        public ExtensionInfoS()
        {
            this.remoteUserAccount = "";
            this.localUserAccount = "";
        }

        public ExtensionInfoS(MEDIA_SOURCE_TYPE mediaSourceType, string channelId, string remoteUserAccount, string localUserAccount)
        : base(mediaSourceType, channelId)
        {
            this.remoteUserAccount = remoteUserAccount;
            this.localUserAccount = localUserAccount;
        }
    }




    #endregion terra IAgoraRtcEngineS.h
}