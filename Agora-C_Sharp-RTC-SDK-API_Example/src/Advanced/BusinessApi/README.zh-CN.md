# 业务 API 测试面板

适用于独立 Windows C# Demo，不依赖 Unity。入口：主窗口 **业务 API 测试 → 打开业务 API 测试面板**。面板可放大，主窗口在此期间暂停操作；旧场景引擎已释放，避免两个引擎同时抢占设备。

本面板按《RTC需要使用到的接口.xlsx》的 Windows 需求增加了固定接口目录。它是手工验收工具，不会把“方法存在”“返回0”“离线自检通过”自动记为业务测试通过。Android/iOS/服务端、云端合流、业务 IM 和歌词录音不在本面板范围。

## 操作方式

1. 填 AppId 和本轮 Token。Token 不保存到配置文件；日志不记录命令原始入参。曲库初始化的独立 Token 在其 configuration 中填写。
2. 点击“初始化”，或选择 `IRtcEngine.Initialize`，生成并编辑 `context` 后执行。初始化成功后，面板自动注册引擎事件。修改初始化配置须先释放。
3. 设置频道、本地 UID、远端 UID。两个进程测试时分别使用如 `1001` / `2001`，远端 UID 填对方；不能两个进程都使用同一 UID。
4. 按对象/关键字选择 API 与重载，点击“生成入参”，编辑左侧 JSON 后执行。连接、UID、播放器或角色预设改变后应重新生成入参。
5. 右侧日志分别记录同步返回、`ref` 输出及真实回调；频道回调包含 RtcConnection，播放器事件包含 playerId。`GetConnectionState` 可随时查询；不要用 `JoinChannel` 返回0判断入会已完成。
6. “导出当前日志”保存当前有界日志；每轮测试结束及时导出。音频帧回调仅展示第1帧及每100帧的摘要。拥塞丢弃或容量截断会明确提示，不能把日志当作完整媒体帧记录。
7. 退出前停止 PCM 推送，分别停止播放器、退连接并观察结果，最后释放。直接关闭窗口也会清理本轮引擎和子对象，但不是异步退出回调验收。

### 参数规则

- 参数名和类型来自本分支真实 C# 签名。每个重载单独选择；没有调用任意类/方法的自由反射入口。
- JSON 枚举使用对应枚举名称或数值。`Optional<T>` 直接写 `true`、`false`、整数或字符串；`null` 表示未设置，不是把 SDK Optional 字段写成空引用。
- `token: "$token"` 使用上方本轮 Token；带连接的续期可使用 `UpdateChannelMediaOptionsEx` 的 `options.token`，同样支持该占位符。
- `byte[]` 使用数字数组或 Base64 字符串。“填UTF8测试消息”会写入带时间戳的样例字节和正确长度。`length` 是字节数，不是字符数；不能超过数组长度。
- 音频 metadata 在本 Native 4.5 接口中限1～255字节。空数据、越界长度、任意 Native 指针、不匹配的 PCM 长度在派发前被拒绝。验证 SDK 的错误行为时，应区别面板校验与真正的 SDK 返回。
- `ref` 参数先填写初值（如 streamId=0、requestId=""），执行后从日志 outputs 读取结果，再填入后续接口。面板不会假造 ID 或重放上轮输出。
- 观察器、事件处理器与播放器对象由面板持有，JSON 中保留 null。`DestroyMediaPlayer/DestroyMusicPlayer` 使用选中的播放器 ID，类型不匹配时拒绝。
- “填文件路径”对录音打开保存对话框，对媒体/测试文件打开选择对话框；也可以直接填写可访问的 URL 或嵌套配置。
- 耳返、曲库和技术预览 API 是否在当前交付包/设备/业务资质下可用，以真实返回和端到端测试为准。源码 `@ignore`、废弃方法会在说明里标注，不代表稳定支持承诺。

## 建议验收顺序

| 模块 | 操作与可观察结果 |
| --- | --- |
| 生命周期/Token | Initialize → JoinChannel（自定义Token/UID/角色）→ OnJoinChannelSuccess；RenewToken/Token到期事件；LeaveChannel → OnLeaveChannel；Dispose后重新初始化。单频道/双连接分别记录。 |
| 设备 | GetAudioDeviceManager → EnumerateRecordingDevices / EnumeratePlaybackDevices；从结果复制 deviceId，再测选择、音量、静音与查询、跟随系统设备。热插拔后重新枚举。设备数组的 Length/name/id 替代旧集合API。 |
| 音频控制 | EnableLocalAudio 控制采集，MuteLocalAudioStream 控制发送，MuteRemoteAudioStream/MuteAllRemoteAudioStreams 控制订阅。检查两端听感、音量回调与状态，切勿把三种开关混为一谈。 |
| 音量/音效 | EnableAudioVolumeIndication 指定周期、smooth、reportVad；观察 OnAudioVolumeIndication。调整录音/播放/指定远端音量；测试耳返和变声，记录平台/设备返回。 |
| AudioMixing | StartAudioMixing（文件或URL、loopback、cycle、startPos）→ 状态回调 → 时长/进度 → pause/resume/seek → 播放/发布音量查询与设置 → stop。loopback=true仅本地播放，远端应使用false。 |
| MediaPlayer | CreateMediaPlayer返回ID并自动注册事件 → 选择ID → Open → OnPlayerSourceStateChanged就绪 → Play → Pause/Resume/Seek → GetDuration/GetPlayPosition/GetState/音量/循环 → Stop → DestroyMediaPlayer。可创建多个ID切换测试；事件按ID区分。 |
| 曲库 | GetMusicContentCenter → Initialize（独立configuration/Token/授权）→ RegisterEventHandler（初始化成功也自动注册）→ GetSongSimpleInfo/Preload/IsPreloaded → 观察结果和进度 → CreateMusicPlayer → 选中ID → IMusicPlayer.Open(songCode) / SetPlayMode → 播放/销毁。曲库访问需要业务资质，不能只凭RTC AppId判断可用。 |
| 录音 | StartAudioRecording配置路径/采样率/内容/质量 → 通话/伴奏 → StopAudioRecording → 检查本地文件大小、格式及回放。不同重载单独测试，不把返回0当作文件完整证明。 |
| 元数据 | 两端入会并按业务发布音频 → SendAudioMetadata或Ex → 对端OnAudioMetadataReceived核对连接、UID、字节数和hex/UTF8内容；测试中文、二进制、1/255字节。该接口属于技术预览，必须实际收发验证。 |
| 数据流 | CreateDataStream/Ex → 从outputs取streamId → SendStreamMessage/Ex → 对端OnStreamMessage核对内容与连接；观察OnStreamMessageError。业务进度/歌词消息可使用UTF8 JSON测试，不能以发送返回代替对端确认。 |
| 双连接/媒体选项 | 两个JoinChannelEx分别编辑connection；更新各自UpdateChannelMediaOptionsEx；验证指定连接的发送与接收；最后分别LeaveChannelEx。Token须与每条连接的频道/UID匹配。 |
| 转发/诊断 | StartOrUpdateChannelMediaRelay / StopChannelMediaRelay配置目标频道和Token，观察真实状态；GetNtpWallTimeInMs、SetParameters、日志设置与版本查询按业务场景测试。高级参数只使用业务已确认的键和值。 |

## 合唱 API 组合验证

这不是自动实现音频同步的生产合唱方案，而是将组合流程中的 API 和回调都变为可操作、可观察的测试入口。

1. 主唱进程创建播放器、取得 ID、Open 并等待播放器就绪。选择“主唱：麦克风+播放器”后，为对应 JoinChannelEx 生成入参；检查 `publishMediaPlayerId` 为本轮真实 ID、`publishMediaPlayerAudioTrack=true`。
2. 伴唱进程使用不同 UID，选择“伴唱：麦克风”，按业务分别加入合唱/观众连接。用 OnJoinChannelSuccess 核对各自连接，不能只检查两个 JoinChannelEx 的返回值。
3. GetNtpWallTimeInMs、播放器 GetPlayPosition 与数据流/音频metadata配合，传递实际播放位置和时间。远端必须核对消息内容、连接和播放位置；业务同步算法、网络抖动及端到端时延另做设备验收。
4. 切换伴奏或角色时使用 UpdateChannelMediaOptions/Ex，检查发布轨道和所选播放器。主唱停播/伴唱退出/重连分别测试。
5. 先 Stop 播放器，按对象类型 DestroyMediaPlayer / DestroyMusicPlayer，分别 LeaveChannelEx 并观察回调，最后释放引擎。
6. 观众混流、服务端编排、鉴权和歌词业务逻辑需要对应业务环境，面板不模拟这些成功结果。

## 自定义 PCM 音频

1. 入会前用 CreateCustomAudioTrack 创建轨道，记录日志里的 trackId（不是播放器ID）。
2. JoinChannel/Ex 的媒体选项设置 `publishCustomAudioTrack=true`、`publishCustomAudioTrackId=<实际trackId>`；若 trackType 为 AUDIO_TRACK_DIRECT，还须 `publishMicrophoneTrack=false`。
3. PCM区填写相同 trackId、采样率、单/双声道和16bit裸PCM文件路径；留空会发送440Hz测试音。点击开始后以20ms帧调用 PushAudioFrame，记录发送帧数及失败返回，对端核对声音。
4. 也可直接选择 PushAudioFrame，用 JSON 提交单帧 RawBuffer 测试。Raw Data 观察与推送外部音频是不同能力；RegisterAudioFrameObserver 可挂接录音/播放/混音等位置，摘要在日志显示。
5. 停止推送后再退连接/DestroyCustomAudioTrack。面板的UI计时器不提供硬实时精度，不能用于合唱时延或漂移指标验收。

## 自动检查的范围

`dotnet run --project ci/build/csharp/tests/BusinessDemoChecks.csproj -c Release` 在不初始化Native的情况下验证目录、类型转换、Optional、长度/PCM边界和事件日志。

Windows包的启动检查额外运行 `--business-api-ui-check <报告路径>`：打开真实WinForms面板、验证所有重载编辑器并保存PNG；不初始化Native、不发起通话。随后原有启动检查验证正式Demo主窗口及自包含运行时。上述检查均不代替x86/x64真机的音频、网络、设备、曲库或合唱QA。
