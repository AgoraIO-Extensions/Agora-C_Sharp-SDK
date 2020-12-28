# Agora C# SDK

*[English](README.md) | 中文*

Agora RTC C# SDK，目前支持 Windows 平台。

## 运行环境

- Visual Studio 2017+ with C++ (Windows)
- .NET

## 安装

1. Clone当前仓库。

   ```bash
   git clone https://github.com/AgoraIO-Community/Agora-C_Sharp-SDK.git
   ```

2. 下载所需的SDK。

   在 [Agora Video SDK for Windows](https://download.agora.io/sdk/release/Agora_Native_SDK_for_Windows_v3_1_2_FULL.zip) 下载 SDK。解压缩之后，将 `libs/x86_64` 目录下的 `agora_rtc_sdk.dll` 和 `agora_rtc_sdk.lib` 复制到仓库的根目录。

3. 编译SDK。

   通过Visual Studio打开`agora_cpp/agora_cpp.sln`。生成解决方案。生成的DLL动态库`agora_cpp.dll`位于`agora_cpp/x64/Debug`。


## 使用方法

本仓库中包含一个图形化界面示例以供参考。

1. 将所需的动态库和SDK文件夹添加至项目中。

   将`agora_cpp/x64/Debug/agora_cpp.dll`、`agora_cpp/CSharp_RTC_SDK/lib/agora_rtc_sdk.dll`和`agorartc`拷贝至`OneToOneVideo/OneToOneVideo`文件夹中。

2. 通过Visual Studio打开`OneToOneVideo/OneToOneVideo.sln`。运行示例。

   *如您还未获取App ID，您可以查看附录。*

## 附录

### 创建Agora账户并获取App ID

如果想要使用我们的SDK，您需要先获得一个App ID：

1. 在[agora.io](https://dashboard.agora.io/signin/)中注册一个账号。当您完成注册后，您将被链接至控制台。
2. 在控制台左侧点击**Projects** > **Project List**。
3. 请将您从控制台中获取的App ID保存，您将会在运行示例时使用（示例图形化界面中有输入框）。