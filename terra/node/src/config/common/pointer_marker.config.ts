import { CXXTYPE } from "@agoraio-extensions/cxx-parser";


export interface PointerArrayNameMapping {
  ptrName: string;
  lengthName: string;
}

export interface NodeInfo {
  __TYPE: CXXTYPE;
  name: string;
  namespaces: string[];
}

export interface PointerMarker {
  node: NodeInfo;
  pointerArrayNameMappings?: PointerArrayNameMapping[];
  pointerNames?: string[];
}

export const markers: PointerMarker[] = [
  //rtc begin
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "LiveTranscoding",
      namespaces: ["agora", "rtc"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "transcodingUsers",
        lengthName: "userCount",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "LocalTranscoderConfiguration",
      namespaces: ["agora", "rtc"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "videoInputStreams",
        lengthName: "streamCount",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "DownlinkNetworkInfo",
      namespaces: ["agora", "rtc"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "peer_downlink_info",
        lengthName: "total_received_video_count",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "ChannelMediaRelayConfiguration",
      namespaces: ["agora", "rtc"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "destInfos",
        lengthName: "destCount",
      },
    ],
    pointerNames: ["srcInfo"],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "ExternalVideoFrame",
      namespaces: ["agora", "media", "base"],
    },
    pointerNames: [
      "buffer",
      "eglContext",
      "metadataBuffer",
      "alphaBuffer",
      "d3d11Texture2d",
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "VideoFrame",
      namespaces: ["agora", "media", "base"],
    },
    pointerNames: [
      "yBuffer",
      "uBuffer",
      "vBuffer",
      "metadata_buffer",
      "sharedContext",
      "d3d11Texture2d",
      "alphaBuffer",
      "pixelBuffer",
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "LocalSpatialAudioConfig",
      namespaces: ["agora", "rtc"],
    },
    pointerNames: ["rtcEngine"],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "ThumbImageBuffer",
      namespaces: ["agora", "rtc"],
    },
    pointerNames: ["buffer"],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "LocalAudioMixerConfiguration",
      namespaces: ["agora", "rtc"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "audioInputStreams",
        lengthName: "streamCount",
      },
    ],
  },
  //rtc end

  //rtm begin
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "UserList",
      namespaces: ["agora", "rtm"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "users",
        lengthName: "userCount",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "TopicOptions",
      namespaces: ["agora", "rtm"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "users",
        lengthName: "userCount",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "UserState",
      namespaces: ["agora", "rtm"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "states",
        lengthName: "statesCount",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "IntervalInfo",
      namespaces: ["agora", "rtm"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "userStateList",
        lengthName: "userStateCount",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "SnapshotInfo",
      namespaces: ["agora", "rtm"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "userStateList",
        lengthName: "userCount",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "PresenceEvent",
      namespaces: ["agora", "rtm"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "stateItems",
        lengthName: "stateItemCount",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "TopicInfo",
      namespaces: ["agora", "rtm"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "publishers",
        lengthName: "publisherCount",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "TopicEvent",
      namespaces: ["agora", "rtm"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "topicInfos",
        lengthName: "topicInfoCount",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "LockEvent",
      namespaces: ["agora", "rtm"],
    },
    pointerArrayNameMappings: [
      {
        ptrName: "lockDetailList",
        lengthName: "count",
      },
    ],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "MessageEvent",
      namespaces: ["agora", "rtm"],
    },
    pointerNames: ["message"],
  },
  {
    node: {
      __TYPE: CXXTYPE.Struct,
      name: "HistoryMessage",
      namespaces: ["agora", "rtm"],
    },
    pointerNames: ["message"],
  },
  //rtm end
];
