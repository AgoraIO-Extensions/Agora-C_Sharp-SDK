//  AgoraRtcSpatialAudioEngineEventHandler.cs
//
//  Created by YuGuo Chen on May 11, 2022.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    public delegate void OnTokenWillExpireHandler();
  
    public delegate void OnConnectionStateChangeHandler(SAE_CONNECTION_STATE_TYPE state, SAE_CONNECTION_CHANGED_REASON_TYPE reason);

    public delegate void OnTeammateLeftHandler(uint uid);

    public delegate void OnTeammateJoinedHandler(uint uid);

    public class AgoraRtcCloudSpatialAudioEngineEventHandler : IAgoraRtcCloudSpatialAudioEngineEventHandler
    {
        public event OnTokenWillExpireHandler EventOnTokenWillExpire;
        public event OnConnectionStateChangeHandler EventOnConnectionStateChange;
        public event OnTeammateLeftHandler EventOnTeammateLeft;
        public event OnTeammateJoinedHandler EventOnTeammateJoined;

        private static AgoraRtcCloudSpatialAudioEngineEventHandler eventInstance = null;

        public static AgoraRtcCloudSpatialAudioEngineEventHandler GetInstance()
        {
            return eventInstance ?? (eventInstance = new AgoraRtcCloudSpatialAudioEngineEventHandler());
        }

        public override void OnTokenWillExpire()
        {
            EventOnTokenWillExpire?.Invoke();
        }
  
        public override void OnConnectionStateChange(SAE_CONNECTION_STATE_TYPE state, SAE_CONNECTION_CHANGED_REASON_TYPE reason)
        {
            EventOnConnectionStateChange?.Invoke(state, reason);
        }

        public override void OnTeammateLeft(uint uid)
        {
            EventOnTeammateLeft?.Invoke(uid);
        }

        public override void OnTeammateJoined(uint uid)
        {
            EventOnTeammateJoined?.Invoke(uid);
        }
    }
}