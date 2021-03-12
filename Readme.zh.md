# Agora C# SDK

*[English](README.md) | 中文*

Agora RTC C# SDK，目前支持 Windows 平台。

## 运行环境

- Visual Studio 2017+ with C++ (Windows)
- .NET

## 安装

### 方法一：使用 NuGet（推荐）

Visual Studio 用户请参考[使用方法](#使用方法)。

```bash
dotnet add package agora_rtc_sdk --version 3.2.1.1
```

### 方法二：编译 SDK

1. Clone当前仓库。

   ```bash
   git clone https://github.com/AgoraIO-Community/Agora-C_Sharp-SDK.git
   ```

3. 编译SDK。

   通过Visual Studio打开 `agorartc/agorartc.sln` 。生成解决方案。


## 使用方法

本仓库中包含一个图形化界面示例以供参考。

### 方法一：使用 NuGet（推荐）

1. 通过Visual Studio打开 `OneToOneVideo/OneToOneVideo.sln` 。
2. 在 `解决方案资源管理器` 中找到 `OneToOneVideo->引用` 并点击右键。然后点击 `管理 NuGet 程序包...` 。
3. 点击 `浏览` ，搜索 `agora_rtc_sdk` 并安装。
4. 在 `解决方案资源管理器` 中找到所有 DLL 文件，并将它们在 `属性` 中的 `复制到输出目录` 属性设置为 `始终复制`。
5. 运行示例。

### 方法二：使用 DLL 文件

对于在安装时[自行编译SDK](#方法二：编译SDK)的用户，请参照以下步骤。

1. 下载所需的SDK。

   在 [Agora Video SDK for Windows](https://download.agora.io/sdk/release/Agora_Native_SDK_for_Windows_v3_2_1_FULL.zip) 下载 SDK。解压缩之后，将 `libs/x86_64` 目录下所有的 `.dll` 文件复制到`OneToOneVideo/OneToOneVideo` 文件夹中。

2. 拷贝其他需要的DLL文件。

   将 `agorartc/agorartc/bin/debug/netcoreapp3.1/agorartc.dll` 和 `iris.dll` 拷贝至`OneToOneVideo/OneToOneVideo`文件夹中。

3. 通过Visual Studio打开 `OneToOneVideo/OneToOneVideo.sln` 。运行示例。

*如您还未获取App ID，您可以查看附录。*

## 帮助

如您需要了解关于我们API的更多信息，请参考[Agora C++ API](https://docs.agora.io/cn/Video/API%20Reference/cpp/v3.1.2/index.html)。

*C# API文档还在推进中，但我们已有的C++ API是相似的。*

## 附录

### 创建Agora账户并获取App ID

如果想要使用我们的SDK，您需要先获得一个App ID：

1. 在[agora.io](https://dashboard.agora.io/signin/)中注册一个账号。当您完成注册后，您将被链接至控制台。
2. 在控制台左侧点击**Projects** > **Project List**。
3. 请将您从控制台中获取的App ID保存，您将会在运行示例时使用（示例图形化界面中有输入框）。