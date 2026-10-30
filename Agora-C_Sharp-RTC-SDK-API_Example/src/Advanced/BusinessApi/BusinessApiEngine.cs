using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    // Owned by one test tab. All native commands and disposal run on the UI thread;
    // native callbacks only enqueue immutable log messages through the view.
    internal sealed class BusinessApiEngine : IEngine
    {
        private readonly BusinessApiView view;
        private IRtcEngineEx Engine => (IRtcEngineEx)rtc_engine_;
        private readonly Dictionary<int, IMediaPlayer> players = new Dictionary<int, IMediaPlayer>();
        private readonly Dictionary<int, IMediaPlayerSourceObserver> playerObservers = new Dictionary<int, IMediaPlayerSourceObserver>();
        private IMusicContentCenter music;
        private IMusicContentCenterEventHandler musicObserver;
        private IRtcEngineEventHandler events;
        private IAudioFrameObserver frames;
        private int generation;
        private Timer pcmTimer;
        private FileStream pcmFile;
        private readonly HashSet<uint> audioTracks = new HashSet<uint>();

        internal BusinessApiEngine(BusinessApiView view) { this.view = view; }
        internal bool Initialized => rtc_engine_ != null;
        private void Log(string name, object data) => view.Log(name + " " + BusinessApiJson.Result(data));
        private Action<string, object> NewSink()
        {
            int epoch = generation;
            return (name, data) => { if (epoch == generation) Log("回调 " + name, data); };
        }

        internal override int Init(string appId)
        {
            if (Initialized) return 0;
            return Initialize(new RtcEngineContext { appId = appId });
        }
        private int Initialize(RtcEngineContext context)
        {
            if (Initialized) throw new InvalidOperationException("引擎已初始化；更改上下文前先释放。");
            if (string.IsNullOrWhiteSpace(context.appId)) context.appId = view.AppId;
            if (string.IsNullOrWhiteSpace(context.appId)) throw new ArgumentException("请填写AppId。");
            generation++;
            rtc_engine_ = RtcEngine.CreateAgoraRtcEngineEx();
            try
            {
                int ret = Engine.Initialize(context);
                Log("Initialize 返回", ret);
                if (ret < 0) { UnInit(); return ret; }
                events = new BusinessRtcEvents(NewSink());
                ret = Engine.InitEventHandler(events);
                Log("InitEventHandler 返回", ret);
                if (ret < 0) UnInit();
                return ret;
            }
            catch { UnInit(); throw; }
        }
        internal override int JoinChannel(string channelId)
        {
            RequireEngine();
            var options = new ChannelMediaOptions();
            options.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
            options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);
            options.publishMicrophoneTrack.SetValue(true);
            int ret = Engine.JoinChannel(view.Token, channelId.Split(';')[0], view.Uid, options);
            Log("JoinChannel 返回（入会结果见回调）", ret);
            return ret;
        }
        internal override int LeaveChannel()
        {
            if (!Initialized) return 0;
            int ret = Engine.LeaveChannel();
            Log("LeaveChannel 返回（退出结果见回调）", ret);
            return ret;
        }
        internal override int UnInit() => Release(false);
        private int Release(bool sync)
        {
            StopPcm();
            if (!Initialized) return 0;
            generation++; // Discard old callbacks before native teardown/reinitialization.
            try
            {
                foreach (var pair in players.ToArray())
                {
                    try { DestroyPlayer(pair.Key); }
                    catch (Exception e) { view.Log("播放器清理异常: " + e.GetType().Name); }
                }
                foreach (var id in audioTracks.ToArray())
                    Log("DestroyCustomAudioTrack", Engine.DestroyCustomAudioTrack(id));
                if (frames != null) Log("UnRegisterAudioFrameObserver", Engine.UnRegisterAudioFrameObserver());
                if (music != null) Log("UnregisterEventHandler", music.UnregisterEventHandler());
                Engine.Dispose(sync);
                view.Log("引擎已释放；这不表示异步退出回调已完成。");
            }
            finally
            {
                rtc_engine_ = null; events = null; frames = null; music = null; musicObserver = null;
                players.Clear(); playerObservers.Clear(); audioTracks.Clear();
            }
            return 0;
        }
        private void RequireEngine()
        {
            if (!Initialized) throw new InvalidOperationException("请先初始化引擎。");
        }
        private IMediaPlayer Player()
        {
            if (!players.TryGetValue(view.PlayerId, out var player))
                throw new InvalidOperationException("先创建播放器，再选择日志中返回的播放器ID。");
            return player;
        }
        private IMusicContentCenter Music()
        {
            music ??= Engine.GetMusicContentCenter();
            return music ?? throw new InvalidOperationException("当前包未提供曲库对象。");
        }
        private int RegisterPlayer(IMediaPlayer player)
        {
            int id = player.GetId();
            players[id] = player;
            var observer = new BusinessPlayerEvents(NewSink(), id);
            playerObservers[id] = observer;
            int ret = player.InitEventHandler(observer);
            Log("播放器事件注册", new { playerId = id, result = ret });
            view.SelectPlayer(id);
            return id;
        }
        private int DestroyPlayer(int id)
        {
            var player = players[id];
            int ret = player is IMusicPlayer mp ? Music().DestroyMusicPlayer(mp) : Engine.DestroyMediaPlayer(player);
            if (ret >= 0) { players.Remove(id); playerObservers.Remove(id); }
            Log("销毁播放器", new { playerId = id, result = ret });
            return ret;
        }

        internal void Execute(BusinessApiOperation op, string json)
        {
            // Parse even special commands so misspelled/unsafe inputs cannot be silently ignored.
            object[] args = BusinessApiJson.ReadArguments(op, json);
            string name = op.Method.Name;
            var parameters = op.Method.GetParameters();
            for (int n = 0; n < parameters.Length; n++)
                if (parameters[n].Name == "token" && args[n] is string t && t == "$token") args[n] = view.Token;
            foreach (var media in args.OfType<ChannelMediaOptions>())
                if (media.token != null && media.token.HasValue() && media.token.GetValue() == "$token") media.token.SetValue(view.Token);
            if (op.Target == "IRtcEngine" && name == "Initialize")
            { Initialize((RtcEngineContext)args[0]); return; }
            RequireEngine();
            if (op.Target == "IRtcEngine" && name == "Dispose") { Release(args.Length != 0 && (bool)args[0]); return; }
            if (name == "CreateMediaPlayer")
            {
                var player = Engine.CreateMediaPlayer() ?? throw new InvalidOperationException("CreateMediaPlayer返回null。");
                Log(name, new { playerId = RegisterPlayer(player) }); return;
            }
            if (name == "CreateMusicPlayer")
            {
                var player = Music().CreateMusicPlayer() ?? throw new InvalidOperationException("CreateMusicPlayer返回null；请检查曲库鉴权。");
                Log(name, new { playerId = RegisterPlayer(player) }); return;
            }
            if (name == "DestroyMediaPlayer" || name == "DestroyMusicPlayer")
            {
                bool isMusic = Player() is IMusicPlayer;
                if ((name == "DestroyMusicPlayer") != isMusic)
                    throw new InvalidOperationException("播放器类型不匹配；普通播放器和曲库播放器使用各自销毁接口。");
                DestroyPlayer(view.PlayerId); return;
            }
            if (op.Target == "IRtcEngine" && name == "InitEventHandler")
            { Log(name, Engine.InitEventHandler(events)); return; }
            if (op.Target == "IMediaPlayer" && name == "InitEventHandler")
            { Log(name, Player().InitEventHandler(playerObservers[view.PlayerId])); return; }
            if (name == "RegisterEventHandler")
            { musicObserver = new BusinessMusicEvents(NewSink()); Log(name, Music().RegisterEventHandler(musicObserver)); return; }
            if (name == "RegisterAudioFrameObserver")
            {
                var next = new BusinessAudioFrames(NewSink());
                int ret = Engine.RegisterAudioFrameObserver(next, (AUDIO_FRAME_POSITION)args[1], (OBSERVER_MODE)args[2]);
                if (ret >= 0) frames = next;
                Log(name, ret);
                return;
            }
            object target = op.Target switch
            {
                "IRtcEngine" => Engine, "IRtcEngineEx" => Engine,
                "IAudioDeviceManager" => Engine.GetAudioDeviceManager(),
                "IMediaPlayer" => Player(),
                "IMusicPlayer" => Player() is IMusicPlayer mp ? mp : throw new InvalidOperationException("请选择曲库播放器ID。"),
                "IMusicContentCenter" => Music(),
                _ => throw new InvalidOperationException("未知操作对象。")
            };
            object result;
            try { result = op.Method.Invoke(target, args); }
            catch (TargetInvocationException e) { throw e.InnerException ?? e; }
            if (name == "CreateCustomAudioTrack" && result is uint track && track != uint.MaxValue)
                audioTracks.Add(track);
            if (name == "DestroyCustomAudioTrack" && result is int destroyed && destroyed >= 0)
                audioTracks.Remove((uint)args[0]);
            if (name == "Initialize" && op.Target == "IMusicContentCenter" && result is int init && init >= 0)
            { musicObserver = new BusinessMusicEvents(NewSink()); Log("曲库事件注册", Music().RegisterEventHandler(musicObserver)); }
            var outputs = new Dictionary<string, object>();
            var ps = op.Method.GetParameters();
            for (int n = 0; n < ps.Length; n++) if (ps[n].ParameterType.IsByRef) outputs[ps[n].Name] = args[n];
            if (result is IRtcEngine || result is IAudioDeviceManager || result is IMusicContentCenter)
                result = new { available = result != null };
            Log(op.Api, new { result, outputs });
            // A 0 return is never recorded as an asynchronous join/play/relay success.
        }

        internal void StartPcm(string filePath, int sampleRate, int channels, uint trackId)
        {
            RequireEngine(); StopPcm();
            if (!audioTracks.Contains(trackId)) throw new ArgumentException("请先创建自定义音频轨道，并使用返回的trackId。");
            if (!new[] { 8000, 16000, 32000, 44100, 48000 }.Contains(sampleRate) || (channels != 1 && channels != 2))
                throw new ArgumentException("请选择支持的PCM采样率和1/2声道。");
            if (!string.IsNullOrWhiteSpace(filePath)) pcmFile = File.OpenRead(filePath);
            int samples = sampleRate / 50; long frameIndex = 0; int pushed = 0;
            var frame = new AudioFrame { channels = channels, samplesPerSec = sampleRate,
                samplesPerChannel = samples, RawBuffer = new byte[samples * channels * 2] };
            pcmTimer = new Timer { Interval = 20 };
            pcmTimer.Tick += (sender, args) =>
            {
                try
                {
                    if (pcmFile != null)
                    {
                        int count = 0;
                        while (count < frame.RawBuffer.Length)
                        { int n = pcmFile.Read(frame.RawBuffer, count, frame.RawBuffer.Length - count); if (n == 0) break; count += n; }
                        if (count == 0) { view.Log("PCM文件发送完成，帧数=" + pushed); StopPcm(); return; }
                        Array.Clear(frame.RawBuffer, count, frame.RawBuffer.Length - count);
                    }
                    else
                    {
                        for (int s = 0; s < samples; s++)
                        {
                            short value = (short)(Math.Sin(2 * Math.PI * 440 * (frameIndex++) / sampleRate) * 4000);
                            for (int c = 0; c < channels; c++)
                            { int i = (s * channels + c) * 2; frame.RawBuffer[i] = (byte)value; frame.RawBuffer[i + 1] = (byte)(value >> 8); }
                        }
                    }
                    frame.renderTimeMs = Environment.TickCount64;
                    BusinessApiJson.ValidateFrame(frame);
                    int ret = Engine.PushAudioFrame(frame, trackId); pushed++;
                    if (ret < 0) { Log("PushAudioFrame失败", ret); StopPcm(); }
                    else if (pushed % 50 == 0) Log("PushAudioFrame进度", new { frames = pushed, trackId });
                }
                catch (Exception e) { view.Log("PCM推送中止: " + e.GetType().Name); StopPcm(); }
            };
            pcmTimer.Start(); view.Log("PCM推送开始：20ms一帧；空文件路径使用440Hz测试音。此计时不用于精密时延验收。");
        }
        internal void StopPcm()
        {
            if (pcmTimer != null) { pcmTimer.Stop(); pcmTimer.Dispose(); pcmTimer = null; }
            pcmFile?.Dispose(); pcmFile = null;
        }
    }
}
