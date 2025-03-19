/**
 * 参数名称默认值转换配置
 */

import { ConversionTable } from "./types";

//函数的每个形数默认值的转换表
export const variableDefaultValueConversionTable: ConversionTable = {
    special_class_param: {},
    special_method_param: {
        "IRtcEngine.enableLoopbackRecording.deviceName:__null": "\"\"",
        "IRtcEngine.enableLoopbackRecording.deviceName:NULL": "\"\"",
        "IMediaEngine.setExternalVideoSource.sourceType:VIDEO_FRAME": "@remove",
        "IMediaEngine.setExternalVideoSource.encodedVideoOption:rtc::SenderOptions()": "@remove",
        "ContentInspectConfig.ContentInspectConfig.extraInfo:NULL": "\"\"",
        "ExternalVideoFrame.ExternalVideoFrame.buffer:NULL": "null",
        "ExternalVideoFrame.ExternalVideoFrame.metadataBuffer:NULL": "null",
        "ExternalVideoFrame.ExternalVideoFrame.alphaBuffer:NULL": "null",
        "ExternalVideoFrame.ExternalVideoFrame.eglContext:NULL": "IntPtr.Zero",
        "ExternalVideoFrame.ExternalVideoFrame.d3d11Texture2d:NULL": "IntPtr.Zero",
        "AudioSpectrumData.AudioSpectrumData.audioSpectrumData:NULL": "null",
        "MediaRecorderConfiguration.MediaRecorderConfiguration.storagePath:NULL": "\"\"",
        "RecorderInfo.RecorderInfo.fileName:NULL": "\"\"",
        "AudioFrame.AudioFrame.buffer:NULL": "IntPtr.Zero",
        "VideoFrame.VideoFrame.metadata_buffer:NULL": "IntPtr.Zero",
        "VideoFrame.VideoFrame.sharedContext:0": "IntPtr.Zero",
        "VideoFrame.VideoFrame.d3d11Texture2d:NULL": "IntPtr.Zero",
        "VideoFrame.VideoFrame.metaInfo:NULL": "null",
        "VideoFrame.VideoFrame.alphaStitchMode:NO_ALPHA_STITCH": "ALPHA_STITCH_MODE.NO_ALPHA_STITCH",
        "VideoCompositingLayout.VideoCompositingLayout.backgroundColor:NULL": "\"\"",
        "VideoCompositingLayout.VideoCompositingLayout.appData:NULL": "\"\"",
        "VideoCompositingLayout.VideoCompositingLayout.regions:NULL": "new Region[0]",
        "VideoCompositingLayout.VideoCompositingLayout.regions:OPTIONAL_NULLPTR": "new Region[0]",
        "PublisherConfiguration.PublisherConfiguration.lifecycle:RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL": "(int)RTMP_STREAM_LIFE_CYCLE_TYPE.RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL",
        "PublisherConfiguration.PublisherConfiguration.injectStreamUrl:NULL": "\"\"",
        "PublisherConfiguration.PublisherConfiguration.publishUrl:NULL": "\"\"",
        "PublisherConfiguration.PublisherConfiguration.rawStreamUrl:NULL": "\"\"",
        "PublisherConfiguration.PublisherConfiguration.extraInfo:NULL": "\"\"",
        "ThumbImageBuffer.ThumbImageBuffer.buffer:nullptr": "new byte[0]",
        "ScreenCaptureSourceInfo.ScreenCaptureSourceInfo.sourceId:nullptr": "0",
        "ScreenCaptureSourceInfo.ScreenCaptureSourceInfo.sourceName:nullptr": "\"\"",
        "ScreenCaptureSourceInfo.ScreenCaptureSourceInfo.processPath:nullptr": "\"\"",
        "ScreenCaptureSourceInfo.ScreenCaptureSourceInfo.sourceTitle:nullptr": "\"\"",
        "ScreenCaptureSourceInfo.ScreenCaptureSourceInfo.sourceDisplayId:(view_t)-2": "AgoraUtil.ConvertNegativeToUInt64(-2)",
        "ImageTrackOptions.ImageTrackOptions.imageUrl:OPTIONAL_NULLPTR": "\"\"",
        "RtcEngineContext.RtcEngineContext.appId:OPTIONAL_NULLPTR": "\"\"",
        "RtcEngineContext.RtcEngineContext.context:OPTIONAL_NULLPTR": "0",
        "RtcEngineContext.RtcEngineContext.context:NULL": "0",
        "RtcEngineContext.RtcEngineContext.license:OPTIONAL_NULLPTR": "\"\"",
        "RtcEngineContext.RtcEngineContext.logConfig:": "new LogConfig()",
        "ExtensionInfo.ExtensionInfo.channelId:OPTIONAL_NULLPTR": "\"\"",
        "VideoEncoderConfiguration.VideoEncoderConfiguration.minBitrate:DEFAULT_MIN_BITRATE": "(int)BITRATE.DEFAULT_MIN_BITRATE",
        "VideoEncoderConfiguration.VideoEncoderConfiguration.dimensions:FRAME_WIDTH_960,FRAME_HEIGHT_540": "new VideoDimensions((int)FRAME_WIDTH.FRAME_WIDTH_960, (int)FRAME_HEIGHT.FRAME_HEIGHT_540)",
        "VideoEncoderConfiguration.VideoEncoderConfiguration.frameRate:FRAME_RATE_FPS_15": "(int)FRAME_RATE.FRAME_RATE_FPS_15",
        "VideoEncoderConfiguration.VideoEncoderConfiguration.bitrate:STANDARD_BITRATE": "(int)BITRATE.STANDARD_BITRATE",
        "VideoFormat.VideoFormat.width:FRAME_WIDTH_960": "(int)FRAME_WIDTH.FRAME_WIDTH_960",
        "VideoFormat.VideoFormat.height:FRAME_HEIGHT_540": "(int)FRAME_HEIGHT.FRAME_HEIGHT_540",
        "VideoFormat.VideoFormat.fps:FRAME_RATE_FPS_15": "(int)FRAME_RATE.FRAME_RATE_FPS_15",
        "LiveTranscoding.LiveTranscoding.watermark:OPTIONAL_NULLPTR": "new RtcImage[0]",
        "LiveTranscoding.LiveTranscoding.backgroundImage:OPTIONAL_NULLPTR": "new RtcImage[0]",
        "LiveTranscoding.LiveTranscoding.advancedFeatures:OPTIONAL_NULLPTR": "new LiveStreamAdvancedFeature[0]",
        "LiveTranscoding.LiveTranscoding.transcodingUsers:OPTIONAL_NULLPTR": "new TranscodingUser[0]",
        "LocalTranscoderConfiguration.LocalTranscoderConfiguration.videoOutputConfiguration:": "new VideoEncoderConfiguration()",
        "LocalTranscoderConfiguration.LocalTranscoderConfiguration.videoInputStreams:OPTIONAL_NULLPTR": "new TranscodingVideoStream[0]",
        "LocalTranscoderConfigurationS.LocalTranscoderConfigurationS.videoInputStreamsS:OPTIONAL_NULLPTR": "new TranscodingVideoStreamS[0]",
        "VideoCanvas.VideoCanvas.view:NULL": "0",
        "VideoCanvas.VideoCanvas.mediaPlayerId:-ERR_NOT_READY": "-(int)ERROR_CODE_TYPE.ERR_NOT_READY",
        "ScreenCaptureParameters.ScreenCaptureParameters.bitrate:STANDARD_BITRATE": "(int)BITRATE.STANDARD_BITRATE",
        "ScreenCaptureParameters.ScreenCaptureParameters.excludeWindowList:OPTIONAL_NULLPTR": "new view_t[0]",
        "ChannelMediaRelayConfiguration.ChannelMediaRelayConfiguration.srcInfo:OPTIONAL_NULLPTR": "new ChannelMediaInfo()",
        "ChannelMediaRelayConfiguration.ChannelMediaRelayConfiguration.destInfos:OPTIONAL_NULLPTR": "new ChannelMediaInfo[0]",
        "DownlinkNetworkInfo.DownlinkNetworkInfo.peer_downlink_info:OPTIONAL_NULLPTR": "new PeerDownlinkInfo[0]",
        "PeerDownlinkInfo.PeerDownlinkInfo.uid:OPTIONAL_NULLPTR": "\"\"",
        "EchoTestConfiguration.EchoTestConfiguration.intervalInSeconds:is": "@is",
        "EchoTestConfiguration.EchoTestConfiguration.view:OPTIONAL_NULLPTR": "0",
        "LocalAccessPointConfiguration.LocalAccessPointConfiguration.ipList:NULL": "new string[0]",
        "LocalAccessPointConfiguration.LocalAccessPointConfiguration.domainList:NULL": "new string[0]",
        "VideoTrackInfo.VideoTrackInfo.observationPosition:agora::media::base::POSITION_POST_CAPTURER": "(uint)VIDEO_MODULE_POSITION.POSITION_POST_CAPTURER",
        "MediaSource.MediaSource.provider:NULL": "null",
        "MusicContentCenterConfiguration.MusicContentCenterConfiguration.appId:nullptr": "\"\"",
        "MusicContentCenterConfiguration.MusicContentCenterConfiguration.token:nullptr": "\"\"",
        "MusicContentCenterConfiguration.MusicContentCenterConfiguration.mccDomain:nullptr": "\"\"",
        "MusicContentCenterConfiguration.MusicContentCenterConfiguration.apiurl:nullptr": "\"\"",
        "LocalSpatialAudioConfig.LocalSpatialAudioConfig.rtcEngine:NULL": "null",
        "IMusicContentCenter.getMusicCollectionByMusicChartId.jsonOption:nullptr": "\"\"",
        "IMusicContentCenter.searchMusic.jsonOption:nullptr": "\"\"",
        "Metadata.Metadata.buffer:NULL": "IntPtr.Zero",
        "MixedAudioStream.MixedAudioStream.trackId:-1": "0xffffffff"
    },
    normal: {
        "agora::media::PRIMARY_CAMERA_SOURCE": "MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE",
        "agora::media::UNKNOWN_MEDIA_SOURCE": "MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE",
        "VIDEO_FRAME": "EXTERNAL_VIDEO_SOURCE_TYPE.VIDEO_FRAME",
        "rtc::TWO_BYTES_PER_SAMPLE": "BYTES_PER_SAMPLE.TWO_BYTES_PER_SAMPLE",
        "VIDEO_BUFFER_RAW_DATA": "VIDEO_BUFFER_TYPE.VIDEO_BUFFER_RAW_DATA",
        "VIDEO_PIXEL_DEFAULT": "VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_DEFAULT",
        "EGL_CONTEXT10": "EGL_CONTEXT_TYPE.EGL_CONTEXT10",
        "rtc::RAW_AUDIO_FRAME_OP_MODE_READ_ONLY": "RAW_AUDIO_FRAME_OP_MODE_TYPE.RAW_AUDIO_FRAME_OP_MODE_READ_ONLY",
        "FORMAT_MP4": "MediaRecorderContainerFormat.FORMAT_MP4",
        "STREAM_TYPE_BOTH": "MediaRecorderStreamType.STREAM_TYPE_BOTH",
        "FRAME_TYPE_PCM16": "AUDIO_FRAME_TYPE.FRAME_TYPE_PCM16",
        "media::base::RENDER_MODE_HIDDEN": "RENDER_MODE_TYPE.RENDER_MODE_HIDDEN",
        "AUDIO_SAMPLE_RATE_48000": "AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_48000",
        "ScreenCaptureSourceType_Unknown": "ScreenCaptureSourceType.ScreenCaptureSourceType_Unknown",
        "VIDEO_MIRROR_MODE_DISABLED": "VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED",
        "CHANNEL_PROFILE_LIVE_BROADCASTING": "CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING",
        "AUDIO_SCENARIO_DEFAULT": "AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT",
        "AREA_CODE_GLOB": "AREA_CODE.AREA_CODE_GLOB",
        "0.0": "0.0f",
        "NULL": "\"\"",
        "0.5": "0.5f",
        "OPTIONAL_NULLPTR": "\"\"",
        "__null": "\"\"",
        "DEFAULT_LOG_SIZE_IN_KB": "1024",
        "OPTIONAL_LOG_LEVEL_SPECIFIERLOG_LEVEL_INFO": "LOG_LEVEL.LOG_LEVEL_INFO"
    },
    reg: {
        "agora::media::base::*": "${-o*}",
        "rtc::*": "${-o*}",
        "media::base::*": "${-o*}",
        "agora::media::*": "${-o*}"
    }
};
