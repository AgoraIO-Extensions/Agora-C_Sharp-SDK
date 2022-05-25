/// <summary>
/// [Device Manager] Key Step：
/// 1. Create Engine and Initialize ：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler] EnableAudio、EnableVideo
/// ）
/// 
/// 2. Enumerate Device: GetAgoraRtcVideoDeviceManager  GetAgoraRtcAudioPlaybackDeviceManager GetAgoraRtcAudioRecordingDeviceManager
///    IAgoraRtcVideoDeviceManager::EnumerateVideoDevices  
///    IAgoraRtcAudioPlaybackDeviceManager::EnumeratePlaybackDevices 
///    IAgoraRtcAudioRecordingDeviceManager::EnumerateRecordingDevices
///
/// 3. Join Channel：（JoinChannel）
/// 
/// 4. Set device : IAgoraRtcVideoDeviceManager::SetDevice    
///                 IAgoraRtcAudioRecordingDeviceManager::SetRecordingDevice 
///                 IAgoraRtcAudioPlaybackDeviceManager::SetPlaybackDevice
/// 
/// 5. Leave Channel：（LeaveChannel）
/// 
/// 4. Exit：（Dispose）
/// <summary>

using System;
using agora.rtc;

namespace CSharp_API_Example
{
    public class DeviceManager : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string DeviceManager_TAG = "[DeviceManager] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;
      
        private IAgoraRtcVideoDeviceManager videoDeviceManager_ = null;
        private IAgoraRtcAudioPlaybackDeviceManager playbackDeviceManager_ = null;
        private IAgoraRtcAudioRecordingDeviceManager recordingDeviceManager_ = null;
        public DeviceManager(IntPtr localWindowId, IntPtr remoteWindowId)
        {
            local_win_id_ = localWindowId;
            remote_win_id_ = remoteWindowId;
        }

        internal override int Init(string appId, string channelId)
        {
            int ret = -1;
            app_id_ = appId;
            channel_id_ = channelId.Split(';').GetValue(0).ToString();

            if (null == rtc_engine_)
            {
                rtc_engine_ = AgoraRtcEngine.CreateAgoraRtcEngine();
            }

            LogConfig log_config = new LogConfig(agora_sdk_log_file_path_);
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, AREA_CODE.AREA_CODE_GLOB, log_config);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(DeviceManager_TAG + "Initialize", ret);
            // second way to set logfile
            //ret = rtc_engine_.SetLogFile(log_file_path);
            //CSharpForm.dump_handler_(DeviceManager_TAG + "SetLogFile", ret);

            event_handler_ = new DeviceManagerEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            ret = rtc_engine_.EnableAudio();
            CSharpForm.dump_handler_(DeviceManager_TAG + "EnableAudio", ret);

            ret = rtc_engine_.EnableVideo();
            CSharpForm.dump_handler_(DeviceManager_TAG + "EnableVideo", ret);

            videoDeviceManager_ = rtc_engine_.GetAgoraRtcVideoDeviceManager();
            playbackDeviceManager_ = rtc_engine_.GetAgoraRtcAudioPlaybackDeviceManager();
            recordingDeviceManager_ = rtc_engine_.GetAgoraRtcAudioRecordingDeviceManager();

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(DeviceManager_TAG + "LeaveChannel", ret);
                videoDeviceManager_ = null;
                recordingDeviceManager_ = null;
                playbackDeviceManager_ = null;
                rtc_engine_.Dispose();
                rtc_engine_ = null;
            }
            return ret;
        }

        internal override int JoinChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                VideoEncoderConfiguration config = new VideoEncoderConfiguration(960, 540, FRAME_RATE.FRAME_RATE_FPS_30, 5, BITRATE.STANDARD_BITRATE, BITRATE.COMPATIBLE_BITRATE);
                ret = rtc_engine_.SetVideoEncoderConfiguration(config);
                CSharpForm.dump_handler_(DeviceManager_TAG + "SetVideoEncoderConfiguration", ret);

                ret = rtc_engine_.JoinChannel("", channel_id_, "info");
                CSharpForm.dump_handler_(DeviceManager_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(DeviceManager_TAG + "LeaveChannel", ret);
            }
            return ret;
        }

        public override void SetVideoDevice(string id)
        {
            int ret = -1;
            if (null != videoDeviceManager_)
            {
                ret = videoDeviceManager_.SetDevice(id);
                CSharpForm.dump_handler_(DeviceManager_TAG + "SetVideoDevice", ret);
                CSharpForm.dump_handler_(DeviceManager_TAG + "id:" + id, 0);
            }
        }
        public override void SetRecordingDevice(string id)
        {
            int ret = -1;
            if (null != recordingDeviceManager_)
            {
                ret = recordingDeviceManager_.SetRecordingDevice(id);
                CSharpForm.dump_handler_(DeviceManager_TAG + "SetRecordingDevice", ret);
                CSharpForm.dump_handler_(DeviceManager_TAG + "id:" + id, 0);
            }
        }
        public override void SetPlaybackDevice(string id)
        {
            int ret = -1;
            if (null != playbackDeviceManager_)
            {
                ret = playbackDeviceManager_.SetPlaybackDevice(id);
                CSharpForm.dump_handler_(DeviceManager_TAG + "SetPlaybackDevice", ret);
                CSharpForm.dump_handler_(DeviceManager_TAG + "id:" + id, 0);
            }
        }
        internal override string GetSDKVersion()
        {
            if (null == rtc_engine_)
                return "-" + (ERROR_CODE_TYPE.ERR_NOT_INITIALIZED).ToString();

            return rtc_engine_.GetVersion();
        }

        internal override IAgoraRtcEngine GetEngine()
        {
            return rtc_engine_;
        }

        internal string GetChannelId()
        {
            return channel_id_;
        }

        internal IntPtr GetLocalWinId()
        {
            return local_win_id_;
        }

        internal IntPtr GetRemoteWinId()
        {
            return remote_win_id_;
        }

        public override agora.rtc.DeviceInfo[] GetVideoDevices() {
            if(videoDeviceManager_ != null)
            {
                return videoDeviceManager_.EnumerateVideoDevices();
            }
            return null;
        }
        public override agora.rtc.DeviceInfo[] GetRecordingDevices()
        {
            if (recordingDeviceManager_ != null)
            {
                return recordingDeviceManager_.EnumerateRecordingDevices();
            }
            return null;
        }
         public override agora.rtc.DeviceInfo[] GetPlaybackDevices()
        {
            if (playbackDeviceManager_ != null)
            {
                return playbackDeviceManager_.EnumeratePlaybackDevices();
            }
            return null;
        }
    }

    // override if need
    internal class DeviceManagerEventHandler : IAgoraRtcEngineEventHandler
    {
        private DeviceManager DeviceManager_inst_ = null;
        public DeviceManagerEventHandler(DeviceManager _DeviceManager) {
            DeviceManager_inst_ = _DeviceManager;
        }

        public override void OnWarning(int warn, string msg)
        {
            Console.WriteLine("=====>OnWarning {0} {1}", warn, msg);
        }

        public override void OnError(int error, string msg)
        {
            Console.WriteLine("=====>OnError {0} {1}", error, msg);
        }

        public override void OnJoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnJoinChannelSuccess channel={0} uid={1}", channel, uid);
            VideoCanvas vs = new VideoCanvas((ulong)DeviceManager_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = DeviceManager_inst_.GetEngine().SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo ret={0}", ret);
        }

        public override void OnRejoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnRejoinChannelSuccess");
        }

        public override void OnLeaveChannel(RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel duration={0}", stats.duration);
        }

        public override void OnUserJoined(uint uid, int elapsed)
        {
            VideoCanvas vs = new VideoCanvas((ulong)0, RENDER_MODE_TYPE.RENDER_MODE_FIT, DeviceManager_inst_.GetChannelId());
            int ret = DeviceManager_inst_.GetEngine().SetupLocalVideo(vs);
            VideoCanvas vs2 = new VideoCanvas((ulong)DeviceManager_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, DeviceManager_inst_.GetChannelId());
            ret = DeviceManager_inst_.GetEngine().SetupLocalVideo(vs2);
            Console.WriteLine("----->OnUserJoined uid={0}", uid);
            if (DeviceManager_inst_.GetRemoteWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((ulong)DeviceManager_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, DeviceManager_inst_.GetChannelId(), uid);
           ret = DeviceManager_inst_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline reason={0}", reason);
        }

        public override void OnStreamMessage(uint uid, int streamId, byte[] data, uint length)
        {
          
        }
    }
}
