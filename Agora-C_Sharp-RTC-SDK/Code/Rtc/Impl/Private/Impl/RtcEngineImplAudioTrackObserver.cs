using System;
using System.Runtime.InteropServices;

namespace Agora.Rtc
{
    public partial class RtcEngineImpl
    {
        // Iris currently owns one audio-track observer; keep its callback handle alive until unregister/release.
        private RtcEventHandlerHandle _audioTrackObserverHandle = new RtcEventHandlerHandle();
        private uint _audioTrackObserverId;
        private IAudioTrackObserver _registeredAudioTrackObserver;

        public int RegisterAudioTrackObserver(uint id, IAudioTrackObserver observer)
        {
            if (observer == null) return -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT;
            if (_audioTrackObserverHandle.handle != IntPtr.Zero) return -(int)ERROR_CODE_TYPE.ERR_ALREADY_IN_USE;

            AudioTrackObserverNative.SetAudioTrackObserver(observer);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            AudioTrackObserverNative.CallbackObject = _callbackObject;
#endif
            AgoraRtcNative.AllocEventHandlerHandle(ref _audioTrackObserverHandle, AudioTrackObserverNative.OnEvent);
            int result = CallAudioTrackObserverApi(id, AgoraApiType.IMEDIAENGINE_REGISTERAUDIOTRACKOBSERVER_39ac049);
            if (result == 0)
            {
                _audioTrackObserverId = id;
                _registeredAudioTrackObserver = observer;
            }
            else ReleaseAudioTrackObserverHandle();
            return result;
        }

        public int UnregisterAudioTrackObserver(uint id, IAudioTrackObserver observer)
        {
            if (_audioTrackObserverHandle.handle == IntPtr.Zero) return 0;
            if (id != _audioTrackObserverId || !ReferenceEquals(observer, _registeredAudioTrackObserver))
                return -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT;
            int result = CallAudioTrackObserverApi(id, AgoraApiType.IMEDIAENGINE_UNREGISTERAUDIOTRACKOBSERVER_39ac049);
            if (result == 0) ReleaseAudioTrackObserverHandle();
            return result;
        }

        private int CallAudioTrackObserverApi(uint id, string api)
        {
            _param.Clear();
            _param.Add("id", id);
            string json = AgoraJson.ToJson(_param);
            var pointers = new[] { _audioTrackObserverHandle.handle };
            var pinned = GCHandle.Alloc(pointers, GCHandleType.Pinned);
            try
            {
                int ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, api, json, (uint)json.Length,
                    Marshal.UnsafeAddrOfPinnedArrayElement(pointers, 0), 1, ref _apiParam);
                return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            }
            finally { pinned.Free(); }
        }

        private void ReleaseAudioTrackObserverHandle()
        {
            AgoraRtcNative.FreeEventHandlerHandle(ref _audioTrackObserverHandle);
            _registeredAudioTrackObserver = null;
            AudioTrackObserverNative.SetAudioTrackObserver(null);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            AudioTrackObserverNative.CallbackObject = null;
#endif
        }
    }
}
