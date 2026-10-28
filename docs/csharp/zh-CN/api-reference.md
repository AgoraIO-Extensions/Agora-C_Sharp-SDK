# 常用 API 参考

[返回目录](README.md) · [回调与数据类型](callbacks-and-types.md) · [全部接口签名](api-index.md)

除工厂方法外，以下引擎方法均通过 `IRtcEngine` 实例调用，命名空间为 `Agora.Rtc`。设备方法通过相应管理器调用。代码块是接口签名参考，不是需要复制到应用中的实现。

## 通用约定

- 多数返回 `int` 的控制方法以 `0` 表示成功、负值表示失败；查询方法还可能返回计数、长度或 ID，应按对应接口说明判断，不要把所有正数当作错误。
- 异步方法返回成功表示请求被接受。进频道、退出频道、媒体播放和连接状态的最终结果通过回调报告。
- `ref` 参数是输入/输出位置，调用前先声明变量；读取输出前检查返回码。
- `Optional<T>` 表示“是否显式设置”，不是普通 `bool`/枚举。调用 `SetValue(...)` 指定值；不设置与设置 `false` 含义不同。
- 保存事件处理器和帧观察器的引用，使用期间不要提前回收。观察器中的 Native 指针/缓冲区不能在回调结束后继续持有使用。

## 引擎创建、初始化和释放

### `RtcEngine.CreateAgoraRtcEngine`

```csharp
public static IRtcEngine CreateAgoraRtcEngine()
public static IRtcEngineEx CreateAgoraRtcEngineEx()
```

创建普通或多频道扩展引擎。取得对象后先调用 `Initialize`。不要为同一通话的每个远端用户创建一个引擎。带 `IntPtr nativePtr` 的重载用于 Native 句柄集成，普通应用应使用无参工厂。

### `Initialize`

```csharp
int Initialize(RtcEngineContext context)
```

初始化引擎。`context.appId` 为项目 App ID；可通过 `context.logConfig.filePath` 指定可写的日志文件位置。返回 `0` 后再调用音视频、频道和设备接口。初始化失败时释放本次引擎并记录错误，不继续进频道。参数字段见[类型说明](callbacks-and-types.md#rtcenginecontext)。

### `InitEventHandler`

```csharp
int InitEventHandler(IRtcEngineEventHandler engineEventHandler)
```

注册继承自 `IRtcEngineEventHandler` 的业务对象。本版本以继承并重写 `On...` 方法接收事件，不使用 Unity 脚本绑定方式。应在发起进频道前注册，避免漏掉入会事件。回调中不执行耗时操作或可能阻塞 SDK 的调用。

### `Dispose`

```csharp
void Dispose(bool sync = false)
```

释放引擎。`sync` 控制同步释放行为，默认 `false`；不要在 SDK 回调中执行释放，尤其不能在回调中等待同步释放完成。释放后旧引擎及从它获取的子对象不能再用于发起操作。重复进入业务页面时，应由应用统一管理创建和释放次数。

### 版本与错误说明

```csharp
string GetVersion(ref int build)
string GetErrorDescription(int code)
```

`GetVersion` 返回版本字符串并输出构建号；`GetErrorDescription` 用于将错误码转成可读说明。保留原始数值、API 名称和回调原因码，不要仅凭描述字符串作程序分支。

## 频道、角色和 Token

### `JoinChannel`

```csharp
int JoinChannel(string token, string channelId, uint uid,
                ChannelMediaOptions options)
int JoinChannel(string token, string channelId, string info, uint uid)
```

| 参数 | 说明 |
| --- | --- |
| `token` | 业务服务生成的 RTC Token，需匹配本次频道和 UID；是否允许空值取决于项目鉴权配置 |
| `channelId` | 频道名称；通信双方使用同一 App ID 和频道名称 |
| `uid` | 本地用户数字 ID；频道内应唯一。传 `0` 时由 SDK 分配，以成功回调中的 `connection.localUid` 为准；Token 必须与该选择相匹配 |
| `options` | 本次频道的角色、发布和订阅配置；建议显式设置所需轨道 |
| `info` | 旧重载的附加信息参数；新接入优先使用媒体选项重载 |

返回 `0` 后等待 `OnJoinChannelSuccess`，不要立即把界面置为“已入会”。同一实例的单频道使用应先完成退出，再加入新频道；并行频道使用扩展接口。

### `UpdateChannelMediaOptions`

```csharp
int UpdateChannelMediaOptions(ChannelMediaOptions options)
```

在已加入的频道中更新发布/订阅配置，例如从摄像头切换到屏幕轨道。仅设置本次要修改的 `Optional<T>` 字段。开启采集不等于发布：屏幕采集后仍须把对应的 `publishScreenTrack` 设置为 `true`。

### `LeaveChannel`

```csharp
int LeaveChannel()
int LeaveChannel(LeaveChannelOptions options)
```

离开频道，最终通过 `OnLeaveChannel` 返回统计。`options` 提供退出时的附加停止选项；完整字段见类型源码。退出频道不销毁引擎，也不等于停止本地预览。

### 频道场景与用户角色

```csharp
int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)
int SetClientRole(CLIENT_ROLE_TYPE role)
int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options)
```

`profile` 指定频道场景，例如 `CHANNEL_PROFILE_LIVE_BROADCASTING`。直播场景中的主播 `CLIENT_ROLE_BROADCASTER` 可发布媒体，观众 `CLIENT_ROLE_AUDIENCE` 用于接收。`ClientRoleOptions` 配置角色的附加选项。可在进频道时通过 `ChannelMediaOptions` 显式设置 `channelProfile` 和 `clientRoleType`；不要同时维护相互冲突的配置来源。

### `RenewToken`

```csharp
int RenewToken(string token)
```

更新有效 Token。在 `OnTokenPrivilegeWillExpire` 中通知业务层提前向服务端请求新 Token，取得后调用该方法；`OnRequestToken` 表示需要重新取得 Token。不要在回调线程阻塞等待网络请求，不在客户端保存 App Certificate 生成生产 Token。Token 更新不是重新创建引擎。

## 视频采集、显示与发送

```csharp
int EnableVideo()
int DisableVideo()
int EnableLocalVideo(bool enabled)
int MuteLocalVideoStream(bool mute)
int SetupLocalVideo(VideoCanvas canvas)
int SetupRemoteVideo(VideoCanvas canvas)
int StartPreview()
int StartPreview(VIDEO_SOURCE_TYPE sourceType)
int StopPreview()
int StopPreview(VIDEO_SOURCE_TYPE sourceType)
```

| 方法 | 中文说明与调用要点 |
| --- | --- |
| `EnableVideo` / `DisableVideo` | 开启/关闭视频模块；不等同于只隐藏某个窗口或只暂停发送 |
| `EnableLocalVideo` | `enabled` 控制本地视频采集；与发布轨道选项共同决定远端能否接收 |
| `MuteLocalVideoStream` | `mute=true` 停止发送本地视频，不应据此认为摄像头一定已释放 |
| `SetupLocalVideo` | 绑定本地画面与 Windows HWND；使用 `VideoCanvas.view`，见类型说明 |
| `SetupRemoteVideo` | 为 `canvas.uid` 绑定远端画面；`uid` 必须是对应远端用户，不能传自己的本地 UID |
| `StartPreview` | 在本地开始预览，可在进频道前执行；显式 `sourceType` 用于选择视频源 |
| `StopPreview` | 停止对应预览；窗口销毁前停止使用其句柄 |

本地预览正常只证明本地采集/显示路径工作，不证明已发布视频。远端显示仍依赖成功入会、对端发布、本端订阅及有效的远端画布。

### 编码配置与远端订阅

```csharp
int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
int MuteRemoteVideoStream(uint uid, bool mute)
int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType)
```

`config` 设置发送视频的分辨率、帧率、码率等，建议在开始通话前完成配置。`dimensions` 单位为像素、`frameRate` 单位为帧/秒、`bitrate` 单位为 Kbps；特殊码率值使用 SDK 的 `BITRATE` 常量，不猜测数值。

`MuteRemoteVideoStream` 以远端 `uid` 为粒度控制视频接收，`mute=true` 暂停接收。`SetRemoteVideoStreamType` 选择远端视频流类型，需要对端实际提供相应流，不能仅通过接收端设置凭空创建小流。

## 音频采集、播放和音量

```csharp
int EnableAudio()
int DisableAudio()
int EnableLocalAudio(bool enabled)
int MuteLocalAudioStream(bool mute)
int MuteRemoteAudioStream(uint uid, bool mute)
int SetAudioProfile(AUDIO_PROFILE_TYPE profile)
int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)
int AdjustRecordingSignalVolume(int volume)
int AdjustPlaybackSignalVolume(int volume)
int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)
```

| 方法 | 参数与行为 |
| --- | --- |
| `EnableAudio` / `DisableAudio` | 控制音频模块；音频模块与视频模块相互独立 |
| `EnableLocalAudio` | `enabled=false` 关闭本地音频采集；不要与只停止发送混淆 |
| `MuteLocalAudioStream` | `mute=true` 不发送本地音频，主要用于业务静音 |
| `MuteRemoteAudioStream` | 控制指定远端 `uid` 的音频接收；不改变该用户的采集/发布配置 |
| `SetAudioProfile` | `profile` 选择音质，带 `scenario` 的重载额外指定音频场景；优先在入会前配置 |
| `AdjustRecordingSignalVolume` | 调整采集信号音量，范围 `[0,400]`；`100` 为原始音量，放大可能失真 |
| `AdjustPlaybackSignalVolume` | 调整播放信号音量，范围 `[0,400]`；与 Windows 设备音量不同 |
| `EnableAudioVolumeIndication` | `interval` 为回调间隔（毫秒），非正值关闭；`smooth` 为平滑系数 `[0,10]`，`reportVad` 控制本地人声检测报告。结果通过 `OnAudioVolumeIndication` 获取 |

### 音乐混音

```csharp
int StartAudioMixing(string filePath, bool loopback, int cycle)
int StartAudioMixing(string filePath, bool loopback, int cycle, int startPos)
int StopAudioMixing()
```

`filePath` 为可访问的媒体路径；`loopback=true` 仅本地播放，`false` 同时向远端发送；`cycle` 指定循环次数，`-1` 表示无限循环，`startPos` 为起始播放位置（毫秒）。需检查文件/网络可访问性、格式和播放状态回调；调用成功不等于已读到媒体数据。

## Windows 设备管理

先取得设备管理器：

```csharp
IAudioDeviceManager GetAudioDeviceManager()
IVideoDeviceManager GetVideoDeviceManager()
```

| 对象 | 方法 | 说明 |
| --- | --- | --- |
| 音频管理器 | `DeviceInfo[] EnumerateRecordingDevices()` | 枚举录音设备 |
| 音频管理器 | `DeviceInfo[] EnumeratePlaybackDevices()` | 枚举播放设备 |
| 音频管理器 | `int SetRecordingDevice(string deviceId)` | 选择录音设备，使用枚举得到的 ID |
| 音频管理器 | `int SetPlaybackDevice(string deviceId)` | 选择播放设备，不等同于修改 Windows 默认设备 |
| 音频管理器 | `int GetRecordingDevice(ref string deviceId)` | 输出当前录音设备 ID |
| 音频管理器 | `int GetPlaybackDevice(ref string deviceId)` | 输出当前播放设备 ID |
| 音频管理器 | `int SetRecordingDeviceVolume(int volume)` | Windows 录音设备音量，范围 `[0,255]` |
| 音频管理器 | `int SetPlaybackDeviceVolume(int volume)` | Windows 播放设备音量，范围 `[0,255]` |
| 音频管理器 | `int StartRecordingDeviceTest(int indicationInterval)` / `int StopRecordingDeviceTest()` | 开始/结束录音设备测试；间隔单位为毫秒 |
| 音频管理器 | `int StartPlaybackDeviceTest(string testAudioFilePath)` / `int StopPlaybackDeviceTest()` | 播放测试文件并结束测试 |
| 视频管理器 | `DeviceInfo[] EnumerateVideoDevices()` | 枚举摄像头 |
| 视频管理器 | `int SetDevice(string deviceIdUTF8)` | 选择摄像头，不能把显示名称当作设备 ID |
| 视频管理器 | `int GetDevice(ref string deviceIdUTF8)` | 输出当前摄像头 ID |
| 视频管理器 | `int NumberOfCapabilities(string deviceIdUTF8)` | 获取设备支持的能力数量；正数是数量，不是错误 |
| 视频管理器 | `int GetCapability(string deviceIdUTF8, uint deviceCapabilityNumber, ref VideoFormat capability)` | 按能力索引取得视频格式 |

设备热插拔后重新枚举，并处理设备状态回调。管理器依赖所属引擎，不在引擎释放后继续使用。设备测试结束后显式停止，再进入正常通话流程。

## Windows 屏幕共享

```csharp
ScreenCaptureSourceInfo[] GetScreenCaptureSources(
    SIZE thumbSize, SIZE iconSize, bool includeScreen)
int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect,
                                 ScreenCaptureParameters captureParams)
int StartScreenCaptureByWindowId(long windowId, Rectangle regionRect,
                                ScreenCaptureParameters captureParams)
int UpdateScreenCaptureRegion(Rectangle regionRect)
int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
int StopScreenCapture()
```

`GetScreenCaptureSources` 枚举可共享来源，`thumbSize` 和 `iconSize` 指定缩略图和图标尺寸，`includeScreen` 控制是否包含显示器。根据来源类型选用显示器 ID 或窗口 ID，不把二者混用。

`regionRect` 为相对捕获源的区域，`captureParams` 设置屏幕共享编码参数。该轨道的编码配置使用 `ScreenCaptureParameters`，不是摄像头的 `SetVideoEncoderConfiguration`。C# 参数遵循本分支的类型，不把其他语言文档中的 `nil` 直接复制成 C# 代码。

采集成功后，通过 `JoinChannel(..., options)` 或已入会后的 `UpdateChannelMediaOptions` 设置 `publishScreenTrack=true`。单一路视频切换场景还应把 `publishCameraTrack=false`。结束共享时停止采集并更新发布选项。共享屏幕视频不等于自动共享系统音频。

`StartScreenCaptureByScreenRect` 在本分支源码中已标注废弃，新的显示器共享接入优先使用 `StartScreenCaptureByDisplayId`。不要使用移动端专用的屏幕共享接口替代 Windows HWND/显示器接入。

## 多频道

```csharp
int JoinChannelEx(string token, RtcConnection connection,
                  ChannelMediaOptions options)
int LeaveChannelEx(RtcConnection connection)
int UpdateChannelMediaOptionsEx(ChannelMediaOptions options,
                                RtcConnection connection)
int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection)
```

以上方法由 `IRtcEngineEx` 提供，使用 `RtcEngine.CreateAgoraRtcEngineEx()` 创建。`RtcConnection` 的频道名和本地 UID 标识一条连接；后续 `Ex` 操作必须传入对应连接。不同连接的 Token 分别匹配各自频道/UID，不能用单一“已入会”布尔值代替每条连接的状态。

完整示例：[JoinMultipleChannel](../../../Agora-C_Sharp-RTC-SDK-API_Example/src/Advanced/JoinMultipleChannel/JoinMultipleChannel.cs)。

## 原始音视频帧

```csharp
int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver,
    AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
int RegisterVideoFrameObserver(IVideoFrameObserver observer,
    VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position,
    OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
int SetRecordingAudioFrameParameters(int sampleRate, int channel,
    RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
int SetPlaybackAudioFrameParameters(int sampleRate, int channel,
    RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
```

实现观察器后，根据处理阶段选择 `position`，视频还需选择 `formatPreference`。`OBSERVER_MODE.INTPTR` 路径涉及 Native 缓冲区，使用指针前确认格式、宽高/步长、采样数和通道数；需异步处理时先复制有效数据。

音频参数中，`sampleRate` 单位为 Hz，`channel` 为声道数，`samplesPerCall` 为每次回调采样点数。使用 SDK 所支持的组合，不把音频参数设定当作可以任意改变设备硬件能力。

回调位于媒体处理路径，禁止执行文件/网络长任务或等待 UI；修改数据前确认当前回调是否允许写入。完整例子见 [ProcessRawData](../../../Agora-C_Sharp-RTC-SDK-API_Example/src/Advanced/ProcessRawData/ProcessRawData.cs)，注销和扩展观察器签名见接口索引。

## 数据流

```csharp
int CreateDataStream(ref int streamId, bool reliable, bool ordered)
int CreateDataStream(ref int streamId, DataStreamConfig config)
int SendStreamMessage(int streamId, byte[] data, uint length)
```

创建成功后使用输出的 `streamId` 发送字节数组，`length` 为实际字节数，不能超过数组有效长度。可靠/有序选项及频率、大小限制以本分支接口注释为准；不要把 RTC 数据流当作无上限的文件传输或持久消息服务。

接收端通过 `OnStreamMessage` 取得 `byte[]`，按实际 `length` 解码；失败通过 `OnStreamMessageError` 处理。发送返回成功不代表业务对端已经处理该消息。

## 媒体播放器及其他扩展

```csharp
IMediaPlayer CreateMediaPlayer()
int DestroyMediaPlayer(IMediaPlayer media_player)
```

播放器提供独立的事件处理器、打开/播放/暂停/定位接口；播放器生命周期由所属引擎管理，销毁后不能继续使用原对象。向频道发布播放器轨道还需配置 `publishMediaPlayerId` 及音视频发布选项。

空间音频、媒体录制、音频频谱、编码帧和播放器完整接口通过[签名索引](api-index.md)进入对应源码。不要将接口索引中的移动端专用、`@ignore` 或技术预览方法作为 Windows 稳定功能承诺。
