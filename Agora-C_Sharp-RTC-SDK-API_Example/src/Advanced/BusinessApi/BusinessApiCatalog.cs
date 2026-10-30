using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    // Fixed business allowlist. JSON can edit arguments, never select arbitrary types or methods.
    internal sealed class BusinessApiOperation
    {
        public string Api { get; }
        public string Description { get; }
        public string SourceRows { get; }
        public MethodInfo Method { get; }
        public string Target => Api.Split('.')[0];
        public BusinessApiOperation(string api, string description, string rows, MethodInfo method)
        { Api = api; Description = description; SourceRows = rows; Method = method; }
        public override string ToString() => Api + "(" + string.Join(", ", Method.GetParameters().Select(p => p.ParameterType.Name + " " + p.Name)) + ")";

        private static readonly Dictionary<string, Type> Types = new Dictionary<string, Type>
        {
            ["IRtcEngine"] = typeof(IRtcEngine), ["IRtcEngineEx"] = typeof(IRtcEngineEx),
            ["IAudioDeviceManager"] = typeof(IAudioDeviceManager),
            ["IMediaPlayer"] = typeof(IMediaPlayer), ["IMusicPlayer"] = typeof(IMusicPlayer),
            ["IMusicContentCenter"] = typeof(IMusicContentCenter)
        };
        private static readonly string[][] Requirements = new string[][]
        {
            new[] { "IAudioDeviceManager.EnumeratePlaybackDevices", "获取扬声器设备列表", "374、375、437、438、532、541" },
            new[] { "IAudioDeviceManager.EnumerateRecordingDevices", "获取麦克风设备列表", "368、369、431、432、532、540" },
            new[] { "IAudioDeviceManager.FollowSystemPlaybackDevice", "跟随系统默认音频设备", "531" },
            new[] { "IAudioDeviceManager.FollowSystemRecordingDevice", "跟随系统默认音频设备", "531" },
            new[] { "IAudioDeviceManager.GetPlaybackDeviceMute", "获取扬声器开关状态", "376、379、439、442" },
            new[] { "IAudioDeviceManager.GetPlaybackDeviceVolume", "获取扬声器播放音量", "377、440" },
            new[] { "IAudioDeviceManager.GetRecordingDeviceMute", "获取麦克风开关状态", "370、378、433、441" },
            new[] { "IAudioDeviceManager.GetRecordingDeviceVolume", "获取麦克风采集音量", "371、434" },
            new[] { "IAudioDeviceManager.SetPlaybackDevice", "选择扬声器设备", "384、447、533、546" },
            new[] { "IAudioDeviceManager.SetPlaybackDeviceMute", "开启/关闭音频播放设备", "361、366、424、429、553" },
            new[] { "IAudioDeviceManager.SetPlaybackDeviceVolume", "设置播放设备音量", "554" },
            new[] { "IAudioDeviceManager.SetRecordingDevice", "选择麦克风设备", "383、446、533、545" },
            new[] { "IAudioDeviceManager.SetRecordingDeviceMute", "静音/取消静音录音设备", "555" },
            new[] { "IAudioDeviceManager.SetRecordingDeviceVolume", "设置麦克风采集音量", "385、448、556" },
            new[] { "IMediaPlayer.AdjustPlayoutVolume", "设置伴奏音量", "414" },
            new[] { "IMediaPlayer.AdjustPublishSignalVolume", "设置音乐远端推送音量", "526" },
            new[] { "IMediaPlayer.GetDuration", "获取伴奏文件总时长", "408" },
            new[] { "IMediaPlayer.GetId", "获取 MediaPlayer 的 ID（用于 publishMediaPlayerId 推流）", "613" },
            new[] { "IMediaPlayer.GetPlayPosition", "获取伴奏当前播放进度", "407" },
            new[] { "IMediaPlayer.GetPlayoutVolume", "获取伴奏音量", "409" },
            new[] { "IMediaPlayer.GetPublishSignalVolume", "查询播放器发布音量", "补充" },
            new[] { "IMediaPlayer.GetState", "查询伴奏是否播放结束", "410" },
            new[] { "IMediaPlayer.InitEventHandler", "设置合唱事件回调", "549" },
            new[] { "IMediaPlayer.Mute", "播放器本地静音", "场景补充" },
            new[] { "IMediaPlayer.Open", "开始播放伴奏（播放器）", "402、417" },
            new[] { "IMediaPlayer.Pause", "暂停播放伴奏", "411" },
            new[] { "IMediaPlayer.Play", "开始播放伴奏（播放器）", "402、417" },
            new[] { "IMediaPlayer.Resume", "继续播放伴奏", "412" },
            new[] { "IMediaPlayer.Seek", "设置伴奏播放进度", "413" },
            new[] { "IMediaPlayer.SetLoopCount", "开始播放伴奏（播放器）", "402、417" },
            new[] { "IMediaPlayer.Stop", "停止播放伴奏（播放器）", "405、420" },
            new[] { "IMusicContentCenter.CreateMusicPlayer", "创建曲库播放器", "补充" },
            new[] { "IMusicContentCenter.DestroyMusicPlayer", "销毁曲库播放器", "补充" },
            new[] { "IMusicContentCenter.GetSongSimpleInfo", "生成音乐播放 URI", "355" },
            new[] { "IMusicContentCenter.Initialize", "获取引擎单例", "510、527、535、575" },
            new[] { "IMusicContentCenter.IsPreloaded", "查询音乐是否已预加载", "528" },
            new[] { "IMusicContentCenter.Preload", "开始下载音乐资源", "357、529" },
            new[] { "IMusicContentCenter.RegisterEventHandler", "设置音乐预加载回调", "530" },
            new[] { "IMusicContentCenter.RenewToken", "更新曲库Token", "补充" },
            new[] { "IMusicPlayer.Open", "打开曲库歌曲", "场景补充" },
            new[] { "IMusicPlayer.SetPlayMode", "停止合唱伴唱", "495" },
            new[] { "IRtcEngine.AdjustAudioMixingPlayoutVolume", "设置伴奏音量", "398、414、525" },
            new[] { "IRtcEngine.AdjustAudioMixingPublishVolume", "设置音乐远端推送音量", "526" },
            new[] { "IRtcEngine.AdjustPlaybackSignalVolume", "设置扬声器播放音量", "386、449、534" },
            new[] { "IRtcEngine.AdjustRecordingSignalVolume", "设置麦克风采集音量", "385、448" },
            new[] { "IRtcEngine.AdjustUserPlaybackSignalVolume", "设置扬声器播放音量", "386、449、534" },
            new[] { "IRtcEngine.CreateCustomAudioTrack", "创建自定义音频轨道", "补充" },
            new[] { "IRtcEngine.CreateDataStream", "发送自定义消息（透传）", "512" },
            new[] { "IRtcEngine.CreateMediaPlayer", "开始播放伴奏（播放器）", "402、417" },
            new[] { "IRtcEngine.DestroyCustomAudioTrack", "销毁自定义音频轨道", "补充" },
            new[] { "IRtcEngine.DestroyMediaPlayer", "结束合唱", "494" },
            new[] { "IRtcEngine.GetErrorDescription", "解释SDK错误码", "补充" },
            new[] { "IRtcEngine.Dispose", "反初始化（销毁引擎）", "358、470、487、504、536、574" },
            new[] { "IRtcEngine.EnableAudioVolumeIndication", "获取麦克风实时音量", "367、372、373、430、435、436、505" },
            new[] { "IRtcEngine.EnableInEarMonitoring", "开启/关闭耳返", "364、427" },
            new[] { "IRtcEngine.EnableLocalAudio", "开启/关闭音频采集设备", "360、365、423、428、537" },
            new[] { "IRtcEngine.EnableLoopbackRecording", "开始采集系统声音作为伴奏", "403、406、418、421、565、573" },
            new[] { "IRtcEngine.GetAudioDeviceManager", "获取设备管理对象", "508" },
            new[] { "IRtcEngine.GetAudioMixingCurrentPosition", "获取伴奏当前播放进度", "391、407、522" },
            new[] { "IRtcEngine.GetAudioMixingDuration", "获取伴奏文件总时长", "392、408" },
            new[] { "IRtcEngine.GetAudioMixingPlayoutVolume", "获取伴奏音量", "393、409" },
            new[] { "IRtcEngine.GetConnectionState", "查询是否已在房间内", "459、476" },
            new[] { "IRtcEngine.GetMusicContentCenter", "创建版权音乐对象", "527" },
            new[] { "IRtcEngine.GetNtpWallTimeInMs", "获取网络时间戳", "577、578" },
            new[] { "IRtcEngine.GetVersion", "获取 SDK 版本号", "457、474、509、576" },
            new[] { "IRtcEngine.InitEventHandler", "注册引擎事件处理器", "549" },
            new[] { "IRtcEngine.Initialize", "初始化引擎", "356、458、461、462、466、475、478、479、483、501、510、535、542、551、575" },
            new[] { "IRtcEngine.JoinChannel", "进入语音房间", "454、471、538" },
            new[] { "IRtcEngine.LeaveChannel", "退出语音房间", "455、472、506、539" },
            new[] { "IRtcEngine.MuteAllRemoteAudioStreams", "开启/关闭下行音频接收", "362、380、425、443、460、463、477、480" },
            new[] { "IRtcEngine.MuteLocalAudioStream", "开启/关闭音频采集设备", "360、363、365、381、423、426、428、444、460、463、537、544" },
            new[] { "IRtcEngine.MuteRemoteAudioStream", "添加音频黑名单（屏蔽指定用户）", "359、382、422、445、486、511、557" },
            new[] { "IRtcEngine.PauseAudioMixing", "暂停播放伴奏", "395、411" },
            new[] { "IRtcEngine.PlayEffect", "获取音效管理对象", "507" },
            new[] { "IRtcEngine.PushAudioFrame", "推送外部音频帧（自定义采集）", "621" },
            new[] { "IRtcEngine.RegisterAudioFrameObserver", "注册音频帧观察器", "补充" },
            new[] { "IRtcEngine.RenewToken", "更新频道Token", "补充" },
            new[] { "IRtcEngine.ResumeAudioMixing", "继续播放伴奏", "396、412" },
            new[] { "IRtcEngine.SendAudioMetadata", "发送 SEI 消息", "513" },
            new[] { "IRtcEngine.SendCustomReportMessage", "设置 App 版本号（上报用）", "465、482" },
            new[] { "IRtcEngine.SendStreamMessage", "发送自定义消息（透传）", "512" },
            new[] { "IRtcEngine.SetAudioMixingPosition", "设置伴奏播放进度", "397、413、523" },
            new[] { "IRtcEngine.SetAudioProfile", "切换房间音质类型", "488、490、497、498、547" },
            new[] { "IRtcEngine.SetAudioScenario", "切换房间音质类型", "488、490、497、498、547" },
            new[] { "IRtcEngine.SetChannelProfile", "进入语音房间", "471、538、548" },
            new[] { "IRtcEngine.SetClientRole", "设置用户角色（主播/观众）", "550" },
            new[] { "IRtcEngine.SetInEarMonitoringVolume", "开启/关闭耳返", "364、427" },
            new[] { "IRtcEngine.SetLogFile", "设置日志级别", "467、468、484、485、516、517" },
            new[] { "IRtcEngine.SetLogFileSize", "开启/关闭日志压缩", "515" },
            new[] { "IRtcEngine.SetLogLevel", "设置日志级别", "467、468、484、485、516、517" },
            new[] { "IRtcEngine.SetParameters", "设置高级参数（透传）", "464、469、481、502、552" },
            new[] { "IRtcEngine.SetSubscribeAudioBlocklist", "添加音频黑名单（屏蔽指定用户）", "422、445、486" },
            new[] { "IRtcEngine.SetVoiceConversionPreset", "设置变声效果", "400、415" },
            new[] { "IRtcEngine.StartAudioMixing", "开始播放伴奏", "401、416、558、564" },
            new[] { "IRtcEngine.StartAudioRecording", "开始录音", "388、450、451、518、559、563" },
            new[] { "IRtcEngine.StartOrUpdateChannelMediaRelay", "开启跨房连麦", "493、499、560" },
            new[] { "IRtcEngine.StopAudioMixing", "停止播放伴奏", "404、419、566、572" },
            new[] { "IRtcEngine.StopAudioRecording", "停止录音", "390、452、453、567、571" },
            new[] { "IRtcEngine.StopChannelMediaRelay", "停止跨房连麦", "496、500、568" },
            new[] { "IRtcEngine.UnRegisterAudioFrameObserver", "注销音频帧观察器", "补充" },
            new[] { "IRtcEngine.UpdateChannelMediaOptions", "更新频道媒体选项", "623" },
            new[] { "IRtcEngineEx.CreateDataStreamEx", "开始合唱（指定成员）", "492" },
            new[] { "IRtcEngineEx.JoinChannelEx", "创建子实例（多房间）", "503" },
            new[] { "IRtcEngineEx.LeaveChannelEx", "离开指定连接", "494、569" },
            new[] { "IRtcEngineEx.SendAudioMetadataEx", "开始合唱（指定成员）", "492" },
            new[] { "IRtcEngineEx.SendStreamMessageEx", "开始合唱（指定成员）", "492、562" },
            new[] { "IRtcEngineEx.UpdateChannelMediaOptionsEx", "更新频道媒体选项（多频道）", "624" },
        };

        public static List<BusinessApiOperation> Create()
        {
            var result = new List<BusinessApiOperation>();
            foreach (var row in Requirements)
            {
                var parts = row[0].Split('.');
                var methods = Types[parts[0]].GetMethods().Where(m => m.Name == parts[1]).ToArray();
                if (methods.Length == 0) throw new InvalidOperationException("SDK缺少业务接口: " + row[0]);
                foreach (var method in methods.OrderBy(m => m.GetParameters().Length).ThenBy(m => m.ToString()))
                    result.Add(new BusinessApiOperation(row[0], row[1], row[2], method));
            }
            return result;
        }
    }
}
