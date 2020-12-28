//
//  event_tester_c.cpp
//
//  Created by DYF on 2020/11/2.
//  Copyright © 2020 Agora.io. All rights reserved.
//

#include "event_tester_c.h"
#include "../common/rapidjson/istreamwrapper.h"
#include "../common/rapidjson/ostreamwrapper.h"
#include "../common/rapidjson/stringbuffer.h"
#include "../common/rapidjson/writer.h"
#include "LogJson.h"
#include <fstream>
#include <vector>

using namespace agora::common;
using namespace rapidjson;

LogJson &get_engine_event_JsonLogger() {
  static LogJson engine_LogJson;
  return engine_LogJson;
}

LogJson &get_channel_event_JsonLogger() {
  static LogJson channelLogJson;
  return channelLogJson;
}

#ifdef __cplusplus
extern "C" {
#endif

// -- Tester for RtcEventHandler

void begin_rtc_engine_event_test(const char *caseFilePath,
                                 struct RtcEventHandler *eventHandler) {
  std::ifstream ifs(caseFilePath);
  rapidjson::IStreamWrapper isw(ifs);

  get_engine_event_JsonLogger().clearJsonData();

  rapidjson::Document caseDoc;
  caseDoc.ParseStream(isw);

  for (auto &v : caseDoc.GetArray()) {
    std::string type = v["event_type"].GetString();
    Value &param = v["param"];
    if (type == "onJoinChannelSuccess") {
      eventHandler->onJoinChannelSuccess(param["channel"].GetString(),
                                         param["uid"].GetUint(),
                                         param["elapsed"].GetInt());
    } else if (type == "onLeaveChannel") {
      auto &v = param["stats"];
      auto duration = v["duration"].GetUint();
      auto txBytes = v["txBytes"].GetUint();
      auto rxBytes = v["rxBytes"].GetUint();
      auto txAudioBytes = v["txAudioBytes"].GetUint();
      auto txVideoBytes = v["txVideoBytes"].GetUint();
      auto rxAudioBytes = v["rxAudioBytes"].GetUint();
      auto rxVideoBytes = v["rxVideoBytes"].GetUint();
      auto txKBitRate = (unsigned short)v["txKBitRate"].GetInt();
      auto rxKBitRate = (unsigned short)v["rxKBitRate"].GetInt();
      auto rxAudioKBitRate = (unsigned short)v["rxAudioKBitRate"].GetInt();
      auto txAudioKBitRate = (unsigned short)v["txAudioKBitRate"].GetInt();
      auto rxVideoKBitRate = (unsigned short)v["rxVideoKBitRate"].GetInt();
      auto txVideoKBitRate = (unsigned short)v["txVideoKBitRate"].GetInt();
      auto lastmileDelay = (unsigned short)v["lastmileDelay"].GetInt();
      auto txPacketLossRate = (unsigned short)v["txPacketLossRate"].GetInt();
      auto rxPacketLossRate = (unsigned short)v["rxPacketLossRate"].GetInt();
      auto userCount = v["userCount"].GetUint();
      auto cpuAppUsage = v["cpuAppUsage"].GetDouble();
      auto cpuTotalUsage = v["cpuTotalUsage"].GetDouble();
      auto gatewayRtt = v["gatewayRtt"].GetInt();
      auto memoryAppUsageRatio = v["memoryAppUsageRatio"].GetDouble();
      auto memoryTotalUsageRatio = v["memoryTotalUsageRatio"].GetDouble();
      auto memoryAppUsageInKbytes = v["memoryAppUsageInKbytes"].GetDouble();
      eventHandler->onLeaveChannel(
          duration, txBytes, rxBytes, txAudioBytes, txVideoBytes, rxAudioBytes,
          rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate,
          txAudioKBitRate, rxVideoKBitRate, txVideoKBitRate, lastmileDelay,
          txPacketLossRate, rxPacketLossRate, userCount, cpuAppUsage,
          cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio,
          memoryAppUsageInKbytes);

    } else if (type == "onRejoinChannelSuccess") {
      eventHandler->onReJoinChannelSuccess(param["channel"].GetString(),
                                           param["uid"].GetUint(),
                                           param["elapsed"].GetInt());
    } else if (type == "onUserJoined") {
      eventHandler->onUserJoined(param["uid"].GetUint(),
                                 param["elapsed"].GetInt());
    } else if (type == "onClientRoleChanged") {
      eventHandler->onClientRoleChanged(
          CLIENT_ROLE_TYPE(param["oldRole"].GetInt()),
          CLIENT_ROLE_TYPE(param["newRole"].GetInt()));
    } else if (type == "onUserOffline") {
      eventHandler->onUserOffline(
          param["uid"].GetUint(),
          USER_OFFLINE_REASON_TYPE(param["reason"].GetInt()));
    } else if (type == "onUserMuteAudio") {
      eventHandler->onUserMuteAudio(param["uid"].GetUint(),
                                    param["muted"].GetBool());
    } else if (type == "onFirstRemoteVideoDecoded") {
      eventHandler->onFirstRemoteVideoDecoded(
          param["uid"].GetUint(), param["width"].GetInt(),
          param["height"].GetInt(), param["elapsed"].GetInt());
    } else if (type == "onUserMuteVideo") {
      eventHandler->onUserMuteVideo(param["uid"].GetUint(),
                                    param["muted"].GetBool());
    } else if (type == "onAudioRouteChanged") {
      eventHandler->onAudioRouteChanged(
          AUDIO_ROUTE_TYPE(param["routing"].GetInt()));
    } else if (type == "onConnectionLost") {
      eventHandler->onConnectionLost();
    } else if (type == "onRequestToken") {
      eventHandler->onRequestToken();
    } else if (type == "onAudioVolumeIndication") {
      int speakerNumber = (int)param["speakers"].GetArray().Size();
      std::vector<uid_t> uids;
      std::vector<unsigned int> volumes;
      std::vector<unsigned int> vads;
      std::vector<const char *> channelIds;
      for (int i = 0; i < speakerNumber; i++) {
        auto &v = param["speakers"][i];

        auto uid = v["uid"].GetUint();
        auto volume = v["volume"].GetUint();
        auto vad = v["vad"].GetUint();
        auto channelId = v["channelId"].GetString();
        uids.push_back(uid);
        volumes.push_back(volume);
        vads.push_back(vad);
        channelIds.push_back(channelId);
      }
      int totalVolume = param["totalVolume"].GetInt();

      eventHandler->onAudioVolumeIndication(uids.data(), volumes.data(),
                                            vads.data(), channelIds.data(),
                                            speakerNumber, totalVolume);
    } else if (type == "onWarning") {
      eventHandler->onWarning(param["warn"].GetInt(), param["msg"].GetString());
    } else if (type == "onError") {
      eventHandler->onError(param["err"].GetInt(), param["msg"].GetString());
    } else if (type == "onRtcStats") {
      auto &v = param["stats"];
      auto duration = v["duration"].GetUint();
      auto txBytes = v["txBytes"].GetUint();
      auto rxBytes = v["rxBytes"].GetUint();
      auto txAudioBytes = v["txAudioBytes"].GetUint();
      auto txVideoBytes = v["txVideoBytes"].GetUint();
      auto rxAudioBytes = v["rxAudioBytes"].GetUint();
      auto rxVideoBytes = v["rxVideoBytes"].GetUint();
      auto txKBitRate = (unsigned short)v["txKBitRate"].GetInt();
      auto rxKBitRate = (unsigned short)v["rxKBitRate"].GetInt();
      auto rxAudioKBitRate = (unsigned short)v["rxAudioKBitRate"].GetInt();
      auto txAudioKBitRate = (unsigned short)v["txAudioKBitRate"].GetInt();
      auto rxVideoKBitRate = (unsigned short)v["rxVideoKBitRate"].GetInt();
      auto txVideoKBitRate = (unsigned short)v["txVideoKBitRate"].GetInt();
      auto lastmileDelay = (unsigned short)v["lastmileDelay"].GetInt();
      auto txPacketLossRate = (unsigned short)v["txPacketLossRate"].GetInt();
      auto rxPacketLossRate = (unsigned short)v["rxPacketLossRate"].GetInt();
      auto userCount = v["userCount"].GetUint();
      auto cpuAppUsage = v["cpuAppUsage"].GetDouble();
      auto cpuTotalUsage = v["cpuTotalUsage"].GetDouble();
      auto gatewayRtt = v["gatewayRtt"].GetInt();
      auto memoryAppUsageRatio = v["memoryAppUsageRatio"].GetDouble();
      auto memoryTotalUsageRatio = v["memoryTotalUsageRatio"].GetDouble();
      auto memoryAppUsageInKbytes = v["memoryAppUsageInKbytes"].GetDouble();
      eventHandler->onRtcStats(
          duration, txBytes, rxBytes, txAudioBytes, txVideoBytes, rxAudioBytes,
          rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate,
          txAudioKBitRate, rxVideoKBitRate, txVideoKBitRate, lastmileDelay,
          txPacketLossRate, rxPacketLossRate, userCount, cpuAppUsage,
          cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio,
          memoryAppUsageInKbytes);
    } else if (type == "onAudioMixingFinished") {
      eventHandler->onAudioMixingFinished();
    } else if (type == "onVideoSizeChanged") {
      eventHandler->onVideoSizeChanged(
          param["uid"].GetUint(), param["width"].GetInt(),
          param["height"].GetInt(), param["rotation"].GetInt());
    } else if (type == "onConnectionInterrupted") {
      eventHandler->onConnectionInterrupted();
    } else if (type == "onMicrophoneEnabled") {
      eventHandler->onMicrophoneEnabled(param["enabled"].GetBool());
    } else if (type == "onFirstRemoteAudioFrame") {
      eventHandler->onFirstRemoteAudioFrame(param["uid"].GetUint(),
                                            param["elapsed"].GetInt());
    } else if (type == "onFirstLocalAudioFrame") {
      eventHandler->onFirstLocalAudioFrame(param["elapsed"].GetInt());
    } else if (type == "onApiCallExecuted") {
      eventHandler->onApiCallExecuted(param["err"].GetInt(),
                                      param["api"].GetString(),
                                      param["result"].GetString());
    } else if (type == "onLastmileQuality") {
      eventHandler->onLastmileQuality(param["quality"].GetInt());
    } else if (type == "onLastmileProbeResult") {
      int state = param["result"]["state"].GetInt();
      unsigned int upLinkPacketLossRate =
          param["result"]["uplinkReport"]["packetLossRate"].GetUint();
      unsigned int upLinkjitter =
          param["result"]["uplinkReport"]["jitter"].GetUint();
      unsigned int upLinkAvailableBandwidth =
          param["result"]["uplinkReport"]["availableBandwidth"].GetUint();
      unsigned int downLinkPacketLossRate =
          param["result"]["downlinkReport"]["packetLossRate"].GetUint();
      unsigned int downLinkJitter =
          param["result"]["downlinkReport"]["jitter"].GetUint();
      unsigned int downLinkAvailableBandwidth =
          param["result"]["downlinkReport"]["availableBandwidth"].GetUint();
      unsigned int rtt = param["result"]["rtt"].GetUint();
      eventHandler->onLastmileProbeResult(
          state, upLinkPacketLossRate, upLinkjitter, upLinkAvailableBandwidth,
          downLinkPacketLossRate, downLinkJitter, downLinkAvailableBandwidth,
          rtt);
    } else if (type == "onAudioQuality") {
      eventHandler->onAudioQuality(param["uid"].GetUint(),
                                   param["quality"].GetInt(),
                                   (unsigned short)param["delay"].GetUint(),
                                   (unsigned short)param["lost"].GetUint());
    } else if (type == "onRemoteVideoTransportStats") {
      eventHandler->onRemoteVideoTransportStats(
          param["uid"].GetUint(), (unsigned short)param["delay"].GetUint(),
          (unsigned short)param["lost"].GetUint(),
          (unsigned short)param["rxKBitRate"].GetUint());
    } else if (type == "onRemoteAudioTransportStats") {
      eventHandler->onRemoteAudioTransportStats(
          param["uid"].GetUint(), (unsigned short)param["delay"].GetUint(),
          (unsigned short)param["lost"].GetUint(),
          (unsigned short)param["rxKBitRate"].GetUint());
    } else if (type == "onStreamInjectedStatus") {
      eventHandler->onStreamInjectedStatus(param["url"].GetString(),
                                           param["uid"].GetUint(),
                                           param["status"].GetInt());
    } else if (type == "onTranscodingUpdated") {
      eventHandler->onTranscodingUpdated();
    } else if (type == "onStreamUnpublished") {
      eventHandler->onStreamUnpublished(param["url"].GetString());
    } else if (type == "onStreamPublished") {
      eventHandler->onStreamPublished(param["url"].GetString(),
                                      param["error"].GetInt());
    } else if (type == "onAudioDeviceVolumeChanged") {
      eventHandler->onAudioDeviceVolumeChanged(
          (MEDIA_DEVICE_TYPE)param["deviceType"].GetInt(),
          param["volume"].GetInt(), param["muted"].GetBool());
    } else if (type == "onActiveSpeaker") {
      eventHandler->onActiveSpeaker(param["uid"].GetUint());
    } else if (type == "onMediaEngineStartCallSuccess") {
      eventHandler->onMediaEngineStartCallSuccess();
    } else if (type == "onMediaEngineLoadSuccess") {
      eventHandler->onMediaEngineLoadSuccess();
    } else if (type == "onStreamMessageError") {
      eventHandler->onStreamMessageError(
          param["uid"].GetUint(), param["streamId"].GetInt(),
          param["code"].GetInt(), param["missed"].GetInt(),
          param["cached"].GetInt());
    } else if (type == "onStreamMessage") {
      eventHandler->onStreamMessage(
          param["uid"].GetUint(), param["streamId"].GetInt(),
          param["data"].GetString(), (size_t)param["length"].GetUint64());
    } else if (type == "onConnectionBanned") {
      eventHandler->onConnectionBanned();
    } else if (type == "onVideoStopped") {
      eventHandler->onVideoStopped();
    } else if (type == "onTokenPrivilegeWillExpire") {
      eventHandler->onTokenPrivilegeWillExpire(param["token"].GetString());
    } else if (type == "onNetworkQuality") {
      eventHandler->onNetworkQuality(param["uid"].GetUint(),
                                     param["txQuality"].GetInt(),
                                     param["rxQuality"].GetInt());
    } else if (type == "onLocalVideoStats") {
      auto &v = param["stats"];
      auto sentBitrate = v["sentBitrate"].GetInt();
      auto sentFrameRate = v["sentFrameRate"].GetInt();
      auto encoderOutputFrameRate = v["encoderOutputFrameRate"].GetInt();
      auto rendererOutputFrameRate = v["rendererOutputFrameRate"].GetInt();
      auto targetBitrate = v["targetBitrate"].GetInt();
      auto targetFrameRate = v["targetFrameRate"].GetInt();
      auto qualityAdaptIndication =
          (QUALITY_ADAPT_INDICATION)v["qualityAdaptIndication"].GetInt();
      auto encodedBitrate = v["encodedBitrate"].GetInt();
      auto encodedFrameWidth = v["encodedFrameWidth"].GetInt();
      auto encodedFrameHeight = v["encodedFrameHeight"].GetInt();
      auto encodedFrameCount = v["encodedFrameCount"].GetInt();
      auto codecType = (VIDEO_CODEC_TYPE)v["codecType"].GetInt();
      auto txPacketLossRate = (unsigned short)v["txPacketLossRate"].GetUint();
      auto captureFrameRate = v["captureFrameRate"].GetInt();
      eventHandler->onLocalVideoStats(
          sentBitrate, sentFrameRate, encoderOutputFrameRate,
          rendererOutputFrameRate, targetBitrate, targetFrameRate,
          qualityAdaptIndication, encodedBitrate, encodedFrameWidth,
          encodedFrameHeight, encodedFrameCount, codecType);
    } else if (type == "onLocalAudioStats") {
      auto &v = param["stats"];
      auto numChannels = v["numChannels"].GetInt();
      auto sentSampleRate = v["sentSampleRate"].GetInt();
      auto sentBitrate = v["sentBitrate"].GetInt();
      auto txPacketLossRate = (unsigned short)v["txPacketLossRate"].GetUint();
      eventHandler->onLocalAudioStats(numChannels, sentSampleRate, sentBitrate);
    } else if (type == "onRemoteVideoStats") {
      auto &v = param["stats"];
      auto uid = v["uid"].GetUint();
      auto delay = v["delay"].GetInt();
      auto width = v["width"].GetInt();
      auto height = v["height"].GetInt();
      auto receivedBitrate = v["receivedBitrate"].GetInt();
      auto decoderOutputFrameRate = v["decoderOutputFrameRate"].GetInt();
      auto rendererOutputFrameRate = v["rendererOutputFrameRate"].GetInt();
      auto packetLossRate = v["packetLossRate"].GetInt();
      auto rxStreamType = (REMOTE_VIDEO_STREAM_TYPE)v["rxStreamType"].GetInt();
      auto totalFrozenTime = v["totalFrozenTime"].GetInt();
      auto frozenRate = v["frozenRate"].GetInt();
      auto totalActiveTime = v["totalActiveTime"].GetInt();
      auto publishDuration = v["publishDuration"].GetInt();
      eventHandler->onRemoteVideoStats(
          uid, delay, width, height, receivedBitrate, decoderOutputFrameRate,
          rendererOutputFrameRate, packetLossRate, rxStreamType,
          totalFrozenTime, frozenRate, totalActiveTime);
    } else if (type == "onRemoteAudioStats") {
      auto &v = param["stats"];
      auto uid = v["uid"].GetUint();
      auto quality = v["quality"].GetInt();
      auto networkTransportDelay = v["networkTransportDelay"].GetInt();
      auto jitterBufferDelay = v["jitterBufferDelay"].GetInt();
      auto audioLossRate = v["audioLossRate"].GetInt();
      auto numChannels = v["numChannels"].GetInt();
      auto receivedSampleRate = v["receivedSampleRate"].GetInt();
      auto receivedBitrate = v["receivedBitrate"].GetInt();
      auto totalFrozenTime = v["totalFrozenTime"].GetInt();
      auto frozenRate = v["frozenRate"].GetInt();
      auto totalActiveTime = v["totalActiveTime"].GetInt();
      auto publishDuration = v["publishDuration"].GetInt();
      eventHandler->onRemoteAudioStats(
          uid, quality, networkTransportDelay, jitterBufferDelay, audioLossRate,
          numChannels, receivedSampleRate, receivedBitrate, totalFrozenTime,
          frozenRate, totalActiveTime);
    } else if (type == "onFirstLocalVideoFrame") {
      eventHandler->onFirstLocalVideoFrame(param["width"].GetInt(),
                                           param["height"].GetInt(),
                                           param["elapsed"].GetInt());
    } else if (type == "onFirstRemoteVideoFrame") {
      eventHandler->onFirstRemoteVideoFrame(
          param["uid"].GetUint(), param["width"].GetInt(),
          param["height"].GetInt(), param["elapsed"].GetInt());
    } else if (type == "onUserEnableVideo") {
      eventHandler->onUserEnableVideo(param["uid"].GetUint(),
                                      param["enabled"].GetBool());
    } else if (type == "onAudioDeviceStateChanged") {
      eventHandler->onAudioDeviceStateChanged(param["deviceId"].GetString(),
                                              param["deviceType"].GetInt(),
                                              param["deviceState"].GetInt());
    } else if (type == "onCameraReady") {
      eventHandler->onCameraReady();
    } else if (type == "onCameraFocusAreaChanged") {
      eventHandler->onCameraFocusAreaChanged(
          param["x"].GetInt(), param["y"].GetInt(), param["width"].GetInt(),
          param["height"].GetInt());
    } else if (type == "onCameraExposureAreaChanged") {
      eventHandler->onCameraExposureAreaChanged(
          param["x"].GetInt(), param["y"].GetInt(), param["width"].GetInt(),
          param["height"].GetInt());
    } else if (type == "onRemoteAudioMixingBegin") {
      eventHandler->onRemoteAudioMixingBegin();
    } else if (type == "onRemoteAudioMixingEnd") {
      eventHandler->onRemoteAudioMixingEnd();
    } else if (type == "onAudioEffectFinished") {
      eventHandler->onAudioEffectFinished(param["soundId"].GetInt());
    } else if (type == "onVideoDeviceStateChanged") {
      eventHandler->onVideoDeviceStateChanged(param["deviceId"].GetString(),
                                              param["deviceType"].GetInt(),
                                              param["deviceState"].GetInt());
    } else if (type == "onRemoteVideoStateChanged") {
      eventHandler->onRemoteVideoStateChanged(
          param["uid"].GetUint(), (REMOTE_VIDEO_STATE)param["state"].GetInt(),
          (REMOTE_VIDEO_STATE_REASON)param["reason"].GetInt(),
          param["elapsed"].GetInt());
    } else if (type == "onUserEnableLocalVideo") {
      eventHandler->onUserEnableLocalVideo(param["uid"].GetUint(),
                                           param["enabled"].GetBool());
    } else if (type == "onLocalPublishFallbackToAudioOnly") {
      eventHandler->onLocalPublishFallbackToAudioOnly(
          param["isFallbackOrRecover"].GetBool());
    } else if (type == "onRemoteSubscribeFallbackToAudioOnly") {
      eventHandler->onRemoteSubscribeFallbackToAudioOnly(
          param["uid"].GetUint(), param["isFallbackOrRecover"].GetBool());
    } else if (type == "onConnectionStateChanged") {
      eventHandler->onConnectionStateChanged(
          (CONNECTION_STATE_TYPE)param["state"].GetInt(),
          (CONNECTION_CHANGED_REASON_TYPE)param["reason"].GetInt());
    } else if (type == "onAudioMixingStateChanged") {
      eventHandler->onAudioMixingStateChanged(
          (AUDIO_MIXING_STATE_TYPE)param["state"].GetInt(),
          (AUDIO_MIXING_ERROR_TYPE)param["errorCode"].GetInt());
    } else if (type == "onFirstRemoteAudioDecoded") {
      eventHandler->onFirstRemoteAudioDecoded(param["uid"].GetUint(),
                                              param["elapsed"].GetInt());
    } else if (type == "onLocalVideoStateChanged") {
      eventHandler->onLocalVideoStateChanged(
          (LOCAL_VIDEO_STREAM_STATE)param["localVideoState"].GetInt(),
          (LOCAL_VIDEO_STREAM_ERROR)param["error"].GetInt());
    } else if (type == "onRtmpStreamingStateChanged") {
      eventHandler->onRtmpStreamingStateChanged(
          param["url"].GetString(),
          (RTMP_STREAM_PUBLISH_STATE)param["state"].GetInt(),
          (RTMP_STREAM_PUBLISH_ERROR)param["errCode"].GetInt());
    } else if (type == "onNetworkTypeChanged") {
      eventHandler->onNetworkTypeChanged((NETWORK_TYPE)param["type"].GetInt());
    } else if (type == "onLocalUserRegistered") {
      eventHandler->onLocalUserRegistered(param["uid"].GetUint(),
                                          param["userAccount"].GetString());
    } else if (type == "onUserInfoUpdated") {
      auto uid = param["uid"].GetUint();
      auto &v = param["info"];
      auto userId = v["uid"].GetUint();
      auto userAccount = v["userAccount"].GetString();

      eventHandler->onUserInfoUpdated(uid, userId, (char *)userAccount);
    } else if (type == "onLocalAudioStateChanged") {
      eventHandler->onLocalAudioStateChanged(
          (LOCAL_AUDIO_STREAM_STATE)param["state"].GetInt(),
          (LOCAL_AUDIO_STREAM_ERROR)param["error"].GetInt());
    } else if (type == "onRemoteAudioStateChanged") {
      eventHandler->onRemoteAudioStateChanged(
          param["uid"].GetUint(), (REMOTE_AUDIO_STATE)param["state"].GetInt(),
          (REMOTE_AUDIO_STATE_REASON)param["reason"].GetInt(),
          param["elapsed"].GetInt());
    } else if (type == "onChannelMediaRelayStateChanged") {
      eventHandler->onChannelMediaRelayStateChanged(
          (CHANNEL_MEDIA_RELAY_STATE)param["state"].GetInt(),
          (CHANNEL_MEDIA_RELAY_ERROR)param["code"].GetInt());
    } else if (type == "onChannelMediaRelayEvent") {
      eventHandler->onChannelMediaRelayEvent(
          (CHANNEL_MEDIA_RELAY_EVENT)param["code"].GetInt());
    }

    else if (type == "onFacePositionChanged") {
      //      Rectangle *vecRenctangle = nullptr;
      //      int *vecDistance = nullptr;
      //      int faceCount = (int)param["vecRectangle"].GetArray().Size();
      //      if (faceCount > 0) {
      //        vecRenctangle = new Rectangle[faceCount];
      //        vecDistance = new int[faceCount];
      //        for (int i = 0; i < faceCount; i++) {
      //          json_to_object(param["vecRectangle"][i], vecRenctangle[i]);
      //          vecDistance[i] = param["vecDistance"][i].GetInt();
      //        }
      //      }
      //      eventHandler->onFacePositionChanged(
      //          param["imageWidth"].GetInt(), param["imageHeight"].GetInt(),
      //          vecRenctangle, vecDistance, param["numFaces"].GetInt());
      //      delete[] vecRenctangle;
      //      delete[] vecDistance;
    }
  }
  eventHandler->onTestEnd();
}
void compare_dump_rtc_engine_event_test_result(const char *caseFilePath,
                                               const char *dumpFilePath,
                                               struct RtcEventHandler *eventHandler) {
  get_engine_event_JsonLogger().compareAndDumpResult(caseFilePath,
                                                     dumpFilePath);
}
void log_engine_event_case(const char *eventType, const char *parameter) {
  get_engine_event_JsonLogger().logJson(eventType, parameter);
}

// -- Tester for ChannelEventHandler
void begin_channel_event_test(const char *caseFilePath, const char *channelId,
                              struct ChannelEventHandler *eventHandler) {
  std::ifstream ifs(caseFilePath);
  rapidjson::IStreamWrapper isw(ifs);

  get_channel_event_JsonLogger().clearJsonData();

  Document caseDoc;
  caseDoc.ParseStream(isw);

  for (auto &v : caseDoc.GetArray()) {
    std::string type = v["event_type"].GetString();
    Value &param = v["param"];
    if (type == "onChannelWarning") {
      eventHandler->onWarning(channelId, param["warn"].GetInt(),
                              param["msg"].GetString());
    } else if (type == "onChannelError") {
      eventHandler->onError(channelId, param["err"].GetInt(),
                            param["msg"].GetString());
    } else if (type == "onJoinChannelSuccess") {
      eventHandler->onJoinChannelSuccess(channelId, param["uid"].GetUint(),
                                         param["elapsed"].GetInt());
    } else if (type == "onRejoinChannelSuccess") {
      eventHandler->onRejoinChannelSuccess(channelId, param["uid"].GetUint(),
                                           param["elapsed"].GetInt());
    } else if (type == "onLeaveChannel") {
      auto &v = param["stats"];
      auto duration = v["duration"].GetUint();
      auto txBytes = v["txBytes"].GetUint();
      auto rxBytes = v["rxBytes"].GetUint();
      auto txAudioBytes = v["txAudioBytes"].GetUint();
      auto txVideoBytes = v["txVideoBytes"].GetUint();
      auto rxAudioBytes = v["rxAudioBytes"].GetUint();
      auto rxVideoBytes = v["rxVideoBytes"].GetUint();
      auto txKBitRate = (unsigned short)v["txKBitRate"].GetInt();
      auto rxKBitRate = (unsigned short)v["rxKBitRate"].GetInt();
      auto rxAudioKBitRate = (unsigned short)v["rxAudioKBitRate"].GetInt();
      auto txAudioKBitRate = (unsigned short)v["txAudioKBitRate"].GetInt();
      auto rxVideoKBitRate = (unsigned short)v["rxVideoKBitRate"].GetInt();
      auto txVideoKBitRate = (unsigned short)v["txVideoKBitRate"].GetInt();
      auto lastmileDelay = (unsigned short)v["lastmileDelay"].GetInt();
      auto txPacketLossRate = (unsigned short)v["txPacketLossRate"].GetInt();
      auto rxPacketLossRate = (unsigned short)v["rxPacketLossRate"].GetInt();
      auto userCount = v["userCount"].GetUint();
      auto cpuAppUsage = v["cpuAppUsage"].GetDouble();
      auto cpuTotalUsage = v["cpuTotalUsage"].GetDouble();
      auto gatewayRtt = v["gatewayRtt"].GetInt();
      auto memoryAppUsageRatio = v["memoryAppUsageRatio"].GetDouble();
      auto memoryTotalUsageRatio = v["memoryTotalUsageRatio"].GetDouble();
      auto memoryAppUsageInKbytes = v["memoryAppUsageInKbytes"].GetDouble();

      eventHandler->onLeaveChannel(
          channelId, duration, txBytes, rxBytes, txAudioBytes, txVideoBytes,
          rxAudioBytes, rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate,
          txAudioKBitRate, rxVideoKBitRate, txVideoKBitRate, lastmileDelay,
          txPacketLossRate, rxPacketLossRate, userCount, cpuAppUsage,
          cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio,
          memoryAppUsageInKbytes);
    } else if (type == "onClientRoleChanged") {
      eventHandler->onClientRoleChanged(channelId, param["oldRole"].GetInt(),
                                        param["newRole"].GetInt());
    } else if (type == "onUserJoined") {
      eventHandler->onUserJoined(channelId, param["uid"].GetUint(),
                                 param["elapsed"].GetInt());
    } else if (type == "onUserOffline") {
      eventHandler->onUserOffLine(
          channelId, param["uid"].GetUint(),
          (USER_OFFLINE_REASON_TYPE)param["reason"].GetInt());
    } else if (type == "onConnectionLost") {
      eventHandler->onConnectionLost(channelId);
    } else if (type == "onRequestToken") {
      eventHandler->onRequestToken(channelId);
    } else if (type == "onTokenPrivilegeWillExpire") {
      eventHandler->onTokenPrivilegeWillExpire(channelId,
                                               param["token"].GetString());
    } else if (type == "onRtcStats") {
      auto &v = param["stats"];
      auto duration = v["duration"].GetUint();
      auto txBytes = v["txBytes"].GetUint();
      auto rxBytes = v["rxBytes"].GetUint();
      auto txAudioBytes = v["txAudioBytes"].GetUint();
      auto txVideoBytes = v["txVideoBytes"].GetUint();
      auto rxAudioBytes = v["rxAudioBytes"].GetUint();
      auto rxVideoBytes = v["rxVideoBytes"].GetUint();
      auto txKBitRate = (unsigned short)v["txKBitRate"].GetInt();
      auto rxKBitRate = (unsigned short)v["rxKBitRate"].GetInt();
      auto rxAudioKBitRate = (unsigned short)v["rxAudioKBitRate"].GetInt();
      auto txAudioKBitRate = (unsigned short)v["txAudioKBitRate"].GetInt();
      auto rxVideoKBitRate = (unsigned short)v["rxVideoKBitRate"].GetInt();
      auto txVideoKBitRate = (unsigned short)v["txVideoKBitRate"].GetInt();
      auto lastmileDelay = (unsigned short)v["lastmileDelay"].GetInt();
      auto txPacketLossRate = (unsigned short)v["txPacketLossRate"].GetInt();
      auto rxPacketLossRate = (unsigned short)v["rxPacketLossRate"].GetInt();
      auto userCount = v["userCount"].GetUint();
      auto cpuAppUsage = v["cpuAppUsage"].GetDouble();
      auto cpuTotalUsage = v["cpuTotalUsage"].GetDouble();
      auto gatewayRtt = v["gatewayRtt"].GetInt();
      auto memoryAppUsageRatio = v["memoryAppUsageRatio"].GetDouble();
      auto memoryTotalUsageRatio = v["memoryTotalUsageRatio"].GetDouble();
      auto memoryAppUsageInKbytes = v["memoryAppUsageInKbytes"].GetDouble();
      eventHandler->onRtcStats(
          channelId, duration, txBytes, rxBytes, txAudioBytes, txVideoBytes,
          rxAudioBytes, rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate,
          txAudioKBitRate, rxVideoKBitRate, txVideoKBitRate, lastmileDelay,
          txPacketLossRate, rxPacketLossRate, userCount, cpuAppUsage,
          cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio,
          memoryAppUsageInKbytes);
    } else if (type == "onNetworkQuality") {
      eventHandler->onNetworkQuality(channelId, param["uid"].GetUint(),
                                     param["txQuality"].GetInt(),
                                     param["rxQuality"].GetInt());
    } else if (type == "onRemoteVideoStats") {
      auto &v = param["stats"];
      auto uid = v["uid"].GetUint();
      auto delay = v["delay"].GetInt();
      auto width = v["width"].GetInt();
      auto height = v["height"].GetInt();
      auto receivedBitrate = v["receivedBitrate"].GetInt();
      auto decoderOutputFrameRate = v["decoderOutputFrameRate"].GetInt();
      auto rendererOutputFrameRate = v["rendererOutputFrameRate"].GetInt();
      auto packetLossRate = v["packetLossRate"].GetInt();
      auto rxStreamType = (REMOTE_VIDEO_STREAM_TYPE)v["rxStreamType"].GetInt();
      auto totalFrozenTime = v["totalFrozenTime"].GetInt();
      auto frozenRate = v["frozenRate"].GetInt();
      auto totalActiveTime = v["totalActiveTime"].GetInt();
      auto publishDuration = v["publishDuration"].GetInt();
      eventHandler->onRemoteVideoStats(
          channelId, uid, delay, width, height, receivedBitrate,
          decoderOutputFrameRate, rendererOutputFrameRate, packetLossRate,
          rxStreamType, totalFrozenTime, frozenRate, totalActiveTime);
    } else if (type == "onRemoteAudioStats") {
      auto &v = param["stats"];
      auto uid = v["uid"].GetUint();
      auto quality = v["quality"].GetInt();
      auto networkTransportDelay = v["networkTransportDelay"].GetInt();
      auto jitterBufferDelay = v["jitterBufferDelay"].GetInt();
      auto audioLossRate = v["audioLossRate"].GetInt();
      auto numChannels = v["numChannels"].GetInt();
      auto receivedSampleRate = v["receivedSampleRate"].GetInt();
      auto receivedBitrate = v["receivedBitrate"].GetInt();
      auto totalFrozenTime = v["totalFrozenTime"].GetInt();
      auto frozenRate = v["frozenRate"].GetInt();
      auto totalActiveTime = v["totalActiveTime"].GetInt();
      auto publishDuration = v["publishDuration"].GetInt();
      eventHandler->onRemoteAudioStats(
          channelId, uid, quality, networkTransportDelay, jitterBufferDelay,
          audioLossRate, numChannels, receivedSampleRate, receivedBitrate,
          totalFrozenTime, frozenRate, totalActiveTime);
    } else if (type == "onRemoteAudioStateChanged") {
      eventHandler->onRemoteAudioStateChanged(
          channelId, param["uid"].GetUint(),
          (REMOTE_AUDIO_STATE)param["state"].GetInt(),
          (REMOTE_AUDIO_STATE_REASON)param["reason"].GetInt(),
          param["elapsed"].GetInt());
    } else if (type == "onActiveSpeaker") {
      eventHandler->onActiveSpeaker(channelId, param["uid"].GetUint());
    } else if (type == "onVideoSizeChanged") {
      eventHandler->onVideoSizeChanged(
          channelId, param["uid"].GetUint(), param["width"].GetInt(),
          param["height"].GetInt(), param["rotation"].GetInt());
    } else if (type == "onRemoteVideoStateChanged") {
      eventHandler->onRemoteVideoStateChanged(
          channelId, param["uid"].GetUint(),
          (REMOTE_VIDEO_STATE)param["state"].GetInt(),
          (REMOTE_VIDEO_STATE_REASON)param["reason"].GetInt(),
          param["elapsed"].GetInt());
    } else if (type == "onStreamMessage") {
      eventHandler->onStreamMessage(
          channelId, param["uid"].GetUint(), param["streamId"].GetInt(),
          param["data"].GetString(), param["length"].GetInt());
    } else if (type == "onStreamMessageError") {
      eventHandler->onStreamMessageError(
          channelId, param["uid"].GetUint(), param["streamId"].GetInt(),
          param["code"].GetInt(), param["missed"].GetInt(),
          param["cached"].GetInt());
    } else if (type == "onChannelMediaRelayStateChanged") {
      eventHandler->onMediaRelayStateChanged(
          channelId, (CHANNEL_MEDIA_RELAY_STATE)param["state"].GetInt(),
          (CHANNEL_MEDIA_RELAY_ERROR)param["code"].GetInt());
    } else if (type == "onChannelMediaRelayEvent") {
      eventHandler->onMediaRelayEvent(
          channelId, (CHANNEL_MEDIA_RELAY_EVENT)param["code"].GetInt());
    } else if (type == "onRtmpStreamingStateChanged") {
      eventHandler->onRtmpStreamingStateChanged(
          channelId, param["url"].GetString(),
          (RTMP_STREAM_PUBLISH_STATE)param["state"].GetInt(),
          (RTMP_STREAM_PUBLISH_ERROR)param["errCode"].GetInt());
    } else if (type == "onTranscodingUpdated") {
      eventHandler->onTranscodingUpdated(channelId);
    } else if (type == "onStreamInjectedStatus") {
      eventHandler->onStreamInjectedStatus(channelId, param["url"].GetString(),
                                           param["uid"].GetUint(),
                                           param["status"].GetInt());
    } else if (type == "onLocalPublishFallbackToAudioOnly") {
      eventHandler->onLocalPublishFallbackToAudioOnly(
          channelId, param["isFallbackOrRecover"].GetBool());
    } else if (type == "onRemoteSubscribeFallbackToAudioOnly") {
      eventHandler->onRemoteSubscribeFallbackToAudioOnly(
          channelId, param["uid"].GetUint(),
          param["isFallbackOrRecover"].GetBool());
    } else if (type == "onConnectionStateChanged") {
      eventHandler->onConnectionStateChanged(
          channelId, (CONNECTION_STATE_TYPE)param["state"].GetInt(),
          (CONNECTION_CHANGED_REASON_TYPE)param["reason"].GetInt());
    }

    eventHandler->onTestEnd(channelId);
  }
}
void compare_dump_channel_event_test_result(const char *caseFilePath,
                                            const char *dumpFilePath,
                                            const char *channelId,
                                            struct ChannelEventHandler *eventHandler) {
  get_channel_event_JsonLogger().compareAndDumpResult(caseFilePath,
                                                      dumpFilePath);
}
void log_channel_event_case(const char *eventType, const char *parameter) {
  get_channel_event_JsonLogger().logJson(eventType, parameter);
}

#ifdef __cplusplus
}
#endif
