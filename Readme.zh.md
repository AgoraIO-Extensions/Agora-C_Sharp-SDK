# Agora C# SDK

*[English](README.md) | 中文*

Agora RTC C# SDK，目前支持 Windows 平台。

- **独立 Windows C# SDK 4.5：[中文版 API 文档](docs/csharp/zh-CN/README.md)**，包括接入步骤、.NET Framework 4.5.2 说明、常用 API、回调、类型与接口签名索引。
- 您可以在 [文档中心](https://docportal.shengwang.cn/cn/video-call-4.x/API%20Reference/cs_ng/v4.2.0/API/rtc_api_overview_ng.html)找到完整的API文档(Unity)
- 您可以在 [发版说明](https://docportal.shengwang.cn/cn/video-call-4.x/release_cs_ng?platform=Windows)找到完整的发版说明(Unity)

## 运行环境

- SDK：`net40` / `netstandard2.0` 托管资产；.NET Framework 4.5.2 应用可引用 `net40` 资产，实际运行还需部署匹配位数的完整 Native/Iris 依赖。
- 本分支 WinForms Demo：`net10.0-windows`；编译源码需要 .NET 10 SDK 和 Windows 桌面开发环境。发布的 Demo 按 x86/x64 自带运行时。
- 请明确选择 x86 或 x64，详见[接入与运行环境](docs/csharp/zh-CN/integration.md)。

## 使用方法

1. Clone仓库

   ```bash
   git clone https://github.com/AgoraIO-Extensions/Agora-C_Sharp-SDK.git
   ```

2. 打开示例工程

	以Debug、X64为例。
	通过Visual Studio打开 `Agora-C_Sharp-SDK/Agora-C_Sharp-RTC-SDK-API_Example/C_Sharp-API_Example.sln`解决方案，选择x64平台。

3. 编译、运行示例


*如您还未获取App ID，您可以查看附录。*

## 帮助

独立 Windows C# 项目请先参考[本仓库的中文 API 文档](docs/csharp/zh-CN/README.md)。Unity 的旧版本文档仅供对应 Unity 版本参考，不作为本分支独立 SDK 的签名依据。

## 附录

### 创建Agora账户并获取App ID

如果想要使用我们的SDK，您需要先获得一个App ID：

1. 在[agora.io](https://dashboard.agora.io/signin/)中注册一个账号。当您完成注册后，您将被链接至控制台。
2. 在控制台左侧点击**Projects** > **Project List**。
3. 请将您从控制台中获取的App ID保存，您将会在运行示例时使用（示例图形化界面中有输入框）。
