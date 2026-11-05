# 回调与数据类型

[返回目录](README.md) · [API 参考](api-reference.md) · [接口索引](api-index.md)

## 事件处理器

继承 `IRtcEngineEventHandler`，重写业务需要的事件，通过 `InitEventHandler` 注册。未重写的方法采用默认空实现。

```csharp
using System;
using Agora.Rtc;

public sealed class CallEvents : IRtcEngineEventHandler
{
    public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
    {
        Console.WriteLine("已加入频道 {0}，本地 UID={1}，耗时={2}ms",
            connection.channelId, connection.localUid, elapsed);
    }

    public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
    {
        // 将 UI 更新及远端画面绑定安排到应用 UI 线程。
        Console.WriteLine("远端用户加入：" + remoteUid);
    }

    public override void OnError(int err, string msg)
    {
        Console.WriteLine("SDK 错误 {0}: {1}", err, msg);
    }
}
```

不要假定所有回调都是 UI 线程，也不要把回调到达顺序替代会话身份核对。UI 异步任务执行时应检查窗体、引擎和频道是否仍有效。对于媒体帧观察器，还需遵守缓冲区有效期和读写模式。

## 常用回调签名

以下为 `IRtcEngineEventHandler` 中的实际签名，重写时加上 `public override`。

```csharp
void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
void OnLeaveChannel(RtcConnection connection, RtcStats stats)
void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
void OnUserOffline(RtcConnection connection, uint remoteUid,
                   USER_OFFLINE_REASON_TYPE reason)
void OnError(int err, string msg)
void OnConnectionStateChanged(RtcConnection connection,
    CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
void OnTokenPrivilegeWillExpire(RtcConnection connection, string token)
void OnRequestToken(RtcConnection connection)
void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source,
    LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_REASON reason)
void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid,
    REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
void OnAudioVolumeIndication(RtcConnection connection,
    AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId,
    byte[] data, ulong length, ulong sentTs)
void OnStreamMessageError(RtcConnection connection, uint remoteUid,
    int streamId, int code, int missed, int cached)
```

| 事件 | 参数及应用处理 |
| --- | --- |
| `OnJoinChannelSuccess` | `connection` 包含真实频道和本地 UID，`elapsed` 为加入耗时（毫秒）；此时更新入会状态 |
| `OnLeaveChannel` | `stats` 为本次通话统计；解除该连接的业务状态，不在回调中同步销毁引擎 |
| `OnUserJoined` | `remoteUid` 为远端用户；可安排创建/绑定远端画面。直播场景不应把此事件当作所有观众的完整名单 |
| `OnUserOffline` | 根据 `reason` 解除该用户的画面和状态；离线事件本身不提供业务永久离线保证 |
| `OnError` | 保留 `err`、`msg` 和触发前后的调用顺序，以便诊断 |
| `OnConnectionStateChanged` | 同时读取 `state` 与 `reason`；按连接分别处理重连、失败和断开 |
| `OnTokenPrivilegeWillExpire` | 提前请求服务端新 Token；回调中的 `token` 不是新生成的 Token |
| `OnRequestToken` | 需要取得有效 Token 并续期，不在媒体回调线程阻塞请求 |
| `OnLocalVideoStateChanged` | `source` 区分摄像头、屏幕等本地源；结合状态和原因定位采集/编码问题 |
| `OnRemoteVideoStateChanged` | 按 `connection` 与 `remoteUid` 识别视频，`elapsed` 单位为毫秒 |
| `OnAudioVolumeIndication` | `speakers` 为音量信息列表，`speakerNumber` 为数量，`totalVolume` 为汇总音量；不是音频 PCM 缓冲区 |
| `OnStreamMessage` | `length` 是字节数，按该长度读取 `data`；`sentTs` 为发送时间戳，不能未经核对就当作 Unix 毫秒时间 |
| `OnStreamMessageError` | `code` 为错误码，`missed/cached` 为消息统计，应用按业务需要处理缺失 |

## RtcEngineContext

初始化参数定义位于 [AgoraRtcEngineGen.cs](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/Types/AgoraRtcEngineGen.cs)。

| 字段 | 说明 |
| --- | --- |
| `appId` | 项目 App ID；不是 App Certificate，也不是 Token |
| `channelProfile` | 初始频道场景；进频道时的媒体选项也可显式配置 |
| `audioScenario` | 音频使用场景 |
| `logConfig` | 日志路径、级别和大小等配置；路径应可写 |

## RtcConnection

定义位于 [AgoraRtcEngineExGen.cs](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/Types/AgoraRtcEngineExGen.cs)。

| 字段 | 说明 |
| --- | --- |
| `channelId` | 频道名 |
| `localUid` | 本地数字 UID；自动分配 UID 时以入会回调值为准 |

多频道时二者共同定位连接。`localUid` 与 `remoteUid` 不能混用。

## ChannelMediaOptions

定义位于 [AgoraRtcEngineGen.cs](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/Types/AgoraRtcEngineGen.cs)。字段使用 `Optional<T>`，例如：

```csharp
ChannelMediaOptions options = new ChannelMediaOptions();
options.publishMicrophoneTrack.SetValue(true);
options.publishCameraTrack.SetValue(false);
options.autoSubscribeAudio.SetValue(true);
options.autoSubscribeVideo.SetValue(true);
```

| 字段 | 类型 | 说明 |
| --- | --- | --- |
| `channelProfile` | `Optional<CHANNEL_PROFILE_TYPE>` | 频道场景 |
| `clientRoleType` | `Optional<CLIENT_ROLE_TYPE>` | 主播/观众角色 |
| `publishMicrophoneTrack` | `Optional<bool>` | 发布麦克风音频 |
| `publishCameraTrack` | `Optional<bool>` | 发布主摄像头视频 |
| `publishScreenTrack` | `Optional<bool>` | Windows 屏幕视频轨道发布开关 |
| `publishSecondaryScreenTrack` | `Optional<bool>` | 第二路屏幕视频轨道发布开关 |
| `publishCustomAudioTrack` | `Optional<bool>` | 发布自定义音频轨道 |
| `publishCustomVideoTrack` | `Optional<bool>` | 发布自定义视频轨道 |
| `customVideoTrackId` | `Optional<uint>` | 对应自定义视频轨道 ID |
| `autoSubscribeAudio` / `autoSubscribeVideo` | `Optional<bool>` | 自动订阅远端音频/视频 |
| `publishMediaPlayerId` | `Optional<int>` | 需要发布的媒体播放器 ID |
| `publishMediaPlayerAudioTrack` / `publishMediaPlayerVideoTrack` | `Optional<bool>` | 发布播放器音频/视频 |

只接收的观众应关闭不需要的发布选项，并使用相应角色。更新时不设置的字段表示没有显式提供该项，不等于将其重置成 false。移动端 `publishScreenCaptureAudio/Video` 不替代 Windows 的屏幕轨道选项。

## VideoCanvas

定义位于 [AgoraBaseGen.cs](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/Types/AgoraBaseGen.cs)。

| 字段 | 说明 |
| --- | --- |
| `uid` | 远端画布对应的远端 UID；不是 HWND |
| `view` | 当前 C# 定义为 `UInt64` 的窗口句柄值；从有效 HWND 转换，不能随意填写整数 |
| `renderMode` | 画面适配方式：`RENDER_MODE_FIT` 保留完整画面，比例不一致时可能留边；`RENDER_MODE_HIDDEN` 填满并可能裁切 |
| `mirrorMode` | 显示镜像配置；本地显示镜像与编码发送镜像不是同一个设置 |
| `sourceType` | 指定视频源类型，使用多路视频源时与采集/发布路径保持一致 |

不要将 `surfaceTexture` 或 Unity 对象当作 Windows WinForms 视频窗口使用。控件句柄重建或销毁后，重新处理画布绑定。

## VideoEncoderConfiguration

定义位于 [AgoraBaseGen.cs](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/Types/AgoraBaseGen.cs)。

| 字段 | 说明 |
| --- | --- |
| `dimensions` | `VideoDimensions`，编码尺寸，单位像素 |
| `frameRate` | 目标编码帧率，单位帧/秒 |
| `bitrate` | 码率，单位 Kbps；支持 SDK 特殊码率常量 |
| `minBitrate` | 最低码率约束，避免未经评估强制过高下限 |
| `orientationMode` | 编码方向策略 |
| `degradationPreference` | 带宽受限时的质量降级偏好 |
| `mirrorMode` | 发送视频的镜像策略，不等同于本地预览镜像 |

## 类型与错误码查找

| 定义文件 | 主要内容 |
| --- | --- |
| [AgoraBaseGen.cs](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/Types/AgoraBaseGen.cs) | 连接、视频画布、编码、音视频基础枚举 |
| [AgoraRtcEngineGen.cs](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/Types/AgoraRtcEngineGen.cs) | 引擎上下文、频道媒体选项和引擎相关类型 |
| [AgoraRtcEngineExGen.cs](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/Types/AgoraRtcEngineExGen.cs) | 多频道连接 |
| [AgoraMediaBaseGen.cs](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/Types/AgoraMediaBaseGen.cs) | 音视频帧和媒体基础类型 |

遇到负返回值时记录原始值，并结合 `GetErrorDescription` 与对应状态回调。不同方法的详细错误含义、适用阶段及平台范围以本分支该方法的注释为准；不要把同步返回码、连接变化原因和媒体状态枚举当作同一套编号。
