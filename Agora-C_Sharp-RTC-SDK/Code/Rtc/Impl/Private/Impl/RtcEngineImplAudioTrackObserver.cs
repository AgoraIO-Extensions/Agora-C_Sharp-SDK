using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Agora.Rtc
{
    public partial class RtcEngineImpl
    {
        private sealed class AudioTrackRegistration
        {
            internal IAudioTrackObserver Observer;
            internal RtcEventHandlerHandle Handle = new RtcEventHandlerHandle();
            internal HashSet<uint> Tracks = new HashSet<uint>();
        }
        private readonly List<AudioTrackRegistration> _audioTrackRegistrations = new List<AudioTrackRegistration>();

        public int RegisterAudioTrackObserver(uint id, IAudioTrackObserver observer)
        {
            if (observer == null) return -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT;
            var registration = _audioTrackRegistrations.Find(item => ReferenceEquals(item.Observer, observer));
            if (registration != null && registration.Tracks.Contains(id)) return -(int)ERROR_CODE_TYPE.ERR_ALREADY_IN_USE;
            bool isNew = registration == null;
            if (isNew)
            {
                registration = new AudioTrackRegistration { Observer = observer };
                AgoraRtcNative.AllocEventHandlerHandle(ref registration.Handle, AudioTrackObserverNative.OnEvent);
                AudioTrackObserverNative.SetAudioTrackObserver(registration.Handle.handle, observer);
            }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            AudioTrackObserverNative.CallbackObject = _callbackObject;
#endif
            int result;
            try { result = CallAudioTrackObserverApi(id, AgoraApiType.IMEDIAENGINE_REGISTERAUDIOTRACKOBSERVER_39ac049, registration.Handle.handle); }
            catch { if (isNew) FreeAudioTrackRegistration(registration); throw; }
            if (result == 0)
            {
                registration.Tracks.Add(id);
                if (isNew) _audioTrackRegistrations.Add(registration);
            }
            else if (isNew) FreeAudioTrackRegistration(registration);
            return result;
        }

        public int UnregisterAudioTrackObserver(uint id, IAudioTrackObserver observer)
        {
            if (observer == null) return -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT;
            var registration = _audioTrackRegistrations.Find(item => ReferenceEquals(item.Observer, observer));
            if (registration == null || !registration.Tracks.Contains(id))
                return -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT;
            int result = CallAudioTrackObserverApi(id, AgoraApiType.IMEDIAENGINE_UNREGISTERAUDIOTRACKOBSERVER_39ac049, registration.Handle.handle);
            if (result == 0)
            {
                registration.Tracks.Remove(id);
                if (registration.Tracks.Count == 0)
                {
                    _audioTrackRegistrations.Remove(registration);
                    FreeAudioTrackRegistration(registration);
                }
            }
            return result;
        }

        private int CallAudioTrackObserverApi(uint id, string api, IntPtr handle)
        {
            _param.Clear();
            _param.Add("id", id);
            string json = AgoraJson.ToJson(_param);
            var pointers = new[] { handle };
            var pinned = GCHandle.Alloc(pointers, GCHandleType.Pinned);
            try
            {
                int ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, api, json, (uint)json.Length,
                    Marshal.UnsafeAddrOfPinnedArrayElement(pointers, 0), 1, ref _apiParam);
                return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            }
            finally { pinned.Free(); }
        }

        private void UnregisterAllAudioTrackObservers()
        {
            foreach (var registration in _audioTrackRegistrations.ToArray())
                foreach (var id in new List<uint>(registration.Tracks))
                    UnregisterAudioTrackObserver(id, registration.Observer);
        }

        private static void FreeAudioTrackRegistration(AudioTrackRegistration registration)
        {
            AudioTrackObserverNative.SetAudioTrackObserver(registration.Handle.handle, null);
            AgoraRtcNative.FreeEventHandlerHandle(ref registration.Handle);
        }

        private void ReleaseAudioTrackObserverHandle()
        {
            foreach (var registration in _audioTrackRegistrations) FreeAudioTrackRegistration(registration);
            _audioTrackRegistrations.Clear();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            AudioTrackObserverNative.CallbackObject = null;
#endif
        }
    }
}
