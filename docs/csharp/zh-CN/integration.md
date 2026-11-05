# 接入与运行环境

[返回目录](README.md) · [API 参考](api-reference.md) · [回调与类型](callbacks-and-types.md)

## 1. 选择目标框架和位数

SDK 的打包工程提供 `net40` 和 `netstandard2.0` 托管资产。面向 .NET Framework 4.5.2 的业务应用使用 `net40` 资产；业务应用不用跟随 Demo 改成 .NET 10。

在 Visual Studio 的项目构建设置中明确选择 `x86` 或 `x64`。64 位 Windows 也可以运行 x86 应用，此时必须加载 x86 本地 DLL。不要仅依据操作系统位数选包，也不要依赖 `AnyCPU` 自动猜测架构。

编译仓库中的 Demo 源码需要 .NET 10 SDK 和 Windows 桌面开发环境；发布的自包含 Demo 已携带对应 .NET 运行时，但仍需要系统级 Native 依赖和摄像头/麦克风访问权限。

## 2. 安装候选 NuGet 包

将交付的 `agora_rtc_sdk.4.5.3.6-alpha.3.nupkg` 放入本地目录，例如 `C:\AgoraPackages`，作为 NuGet 本地包源。SDK 包不需要解压后再放进该源。

使用支持 PackageReference 的项目时，将包源加到 `NuGet.Config`，保留业务工程已有的其他源：

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="AgoraLocal" value="C:\AgoraPackages" />
  </packageSources>
</configuration>
```

在项目文件中添加：

```xml
<PropertyGroup>
  <PlatformTarget>x64</PlatformTarget>
</PropertyGroup>
<ItemGroup>
  <PackageReference Include="agora_rtc_sdk" Version="4.5.3.6-alpha.3" />
</ItemGroup>
```

在 .NET Framework 4.5.2 工程中保留原来的 `v4.5.2` 目标设置；不要把上面的属性片段当作完整工程文件。旧式 `packages.config` 工程也可通过 Visual Studio 的 NuGet 包管理器选择本地源安装。

当前包的 [MSBuild targets](../../../ci/build/csharp/agora_rtc_sdk.targets) 在 `PlatformTarget` 为 `x86` 或 `x64` 时，将对应 `runtimes/win-<位数>/native/` 中的文件复制到输出/发布目录。部署前检查最终目录，不能只检查 NuGet 还原成功。

## 3. 使用 SDK ZIP

手工引用时，在业务工程中添加与目标框架兼容的 `agorartc.dll`，并把**同一交付包、同一架构**的完整 Native/Iris 依赖放到可执行文件目录。不要混用 Unity 包、其他版本 Iris 或另一架构的 DLL。

SDK 包同时涉及托管程序集和本地 DLL。`agorartc.dll` 是托管程序集，`agoraRtcWrapper.dll` 是 Iris 桥接库；其他 Native DLL 也必须完整部署。以交付目录为准，不要只挑这两个文件。

## 4. 最小音视频调用流程

下面展示 WinForms 应用的关键调用顺序，使用本分支的实际 API。代码分步放入现有窗体，不是一个可独立运行的完整项目。完整应用需接入回调、Token 获取和退出处理。

先在窗体中准备两个有效的显示控件，例如 `localPanel` 和 `remotePanel`。在它们的 HWND 已创建后，从 UI 线程获取句柄。

```csharp
using System;
using Agora.Rtc;

// 以下字段和方法放在业务窗体或会话控制类中。
private IRtcEngine engine;
private IRtcEngineEventHandler handler;

private static void Check(int result, string api)
{
    if (result < 0)
        throw new InvalidOperationException(api + " failed: " + result);
}

private void InitializeRtc(string appId, IRtcEngineEventHandler eventHandler)
{
    engine = RtcEngine.CreateAgoraRtcEngine();
    handler = eventHandler; // 保留引用，生命周期覆盖整个会话。
    try
    {
        RtcEngineContext context = new RtcEngineContext();
        context.appId = appId;
        Check(engine.Initialize(context), "Initialize");
        Check(engine.InitEventHandler(handler), "InitEventHandler");
        Check(engine.EnableVideo(), "EnableVideo");
    }
    catch
    {
        engine.Dispose();
        engine = null;
        handler = null;
        throw;
    }
}

private void PreviewLocalVideo(IntPtr hwnd)
{
    VideoCanvas canvas = new VideoCanvas();
    canvas.view = unchecked((ulong)hwnd.ToInt64());
    canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;
    Check(engine.SetupLocalVideo(canvas), "SetupLocalVideo");
    Check(engine.StartPreview(), "StartPreview");
}

private void JoinRtc(string token, string channelId, uint uid)
{
    ChannelMediaOptions options = new ChannelMediaOptions();
    options.channelProfile.SetValue(
        CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
    options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);
    options.publishMicrophoneTrack.SetValue(true);
    options.publishCameraTrack.SetValue(true);
    options.autoSubscribeAudio.SetValue(true);
    options.autoSubscribeVideo.SetValue(true);
    Check(engine.JoinChannel(token, channelId, uid, options), "JoinChannel");
    // 这里仅表示调用被接受；收到 OnJoinChannelSuccess 才更新“已加入”。
}

private void BindRemoteVideo(uint remoteUid, IntPtr hwnd)
{
    VideoCanvas canvas = new VideoCanvas();
    canvas.uid = remoteUid;
    canvas.view = unchecked((ulong)hwnd.ToInt64());
    canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;
    Check(engine.SetupRemoteVideo(canvas), "SetupRemoteVideo");
}

private void ShutdownRtc()
{
    if (engine == null) return;
    // 在应用自身的退出路径调用，不在 SDK 回调里销毁。
    // 如需展示退出结果，先 LeaveChannel，等待 OnLeaveChannel 后再释放。
    engine.StopPreview();
    engine.LeaveChannel();
    engine.Dispose();
    engine = null;
    handler = null;
}
```

业务类继承 `IRtcEngineEventHandler`，在 `OnJoinChannelSuccess` 中记录实际 UID，在 `OnUserJoined` 中安排远端画面绑定，在 Token 回调中通知业务服务续期。回调签名见[回调参考](callbacks-and-types.md)。

WinForms 更新控件使用 `BeginInvoke`，WPF 使用 `Dispatcher.BeginInvoke`。排队工作执行时再次确认窗体未关闭、引擎未释放、会话仍是原会话；不要把过期回调绑定到新建会话。WPF 可通过 Windows HWND 宿主承载视频，不能把任意 WPF 对象当作 `VideoCanvas.view`。

App ID 由应用配置传入；不要在示例仓库提交真实 App ID、App Certificate 或 Token。Token 由业务服务生成，必须匹配 App ID、频道名和 UID。不要把空 Token 当作所有项目通用的接入方式。

## 5. 正常退出与再次加入

`LeaveChannel` 是异步退出；观察 `OnLeaveChannel`。本地预览可独立于频道存在，退出频道不等于停止预览。准备离开通话界面时显式调用 `StopPreview`；应用彻底结束 RTC 使用时再 `Dispose`。

不要在 `OnLeaveChannel` 等 SDK 回调内部同步销毁引擎。将清理安排到应用线程，并防止重复清理、回调执行期间控件销毁，以及销毁后继续调用设备管理器/媒体播放器。

## 6. 常见问题

| 现象 | 排查方向 |
| --- | --- |
| `DllNotFoundException` | Native/Iris DLL 是否完整、是否在加载路径、其间接依赖是否缺失；按交付要求安装匹配的 Microsoft VC++ 运行库 |
| `BadImageFormatException` | 进程 `x86/x64` 与所有本地 DLL 是否一致；不要混放两种架构的同名 DLL |
| EXE 启动闪退，提示缺少 WindowsDesktop 运行时 | 区分旧 Demo 与当前自包含 Demo；.NET Framework SDK 用户无需安装 Demo 的 .NET 10 来引用 `net40` 程序集 |
| `Initialize` 返回负数 | App ID、日志目录写权限、Native/Iris 配套版本及初始化顺序 |
| `JoinChannel` 返回 0 但未入会 | 检查 `OnError`、`OnConnectionStateChanged`、Token 权限和 `OnJoinChannelSuccess`；返回 0 不是入会完成 |
| 有预览但远端看不到视频 | 是否已入会、是否主播、`publishCameraTrack` 是否为 true、是否误发布屏幕/自定义轨道 |
| 远端黑屏 | 远端 UID、视频发布/订阅状态、HWND 是否仍有效、`SetupRemoteVideo` 返回值及视频状态回调 |
| 静音后摄像头/麦克风仍被占用 | `MuteLocal*Stream` 控制发送；要控制采集使用 `EnableLocalAudio/Video`，并区分 `StopPreview` |

提交问题时附 SDK 版本、进程架构、Windows 版本、复现顺序、API 返回值和 SDK 日志。日志可包含业务标识，分享前按应用要求处理。
