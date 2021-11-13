# Agora C# SDK

*[English](README.md) | 中文*

Agora RTC C# SDK，目前支持 Windows 平台。

## 运行环境

- Visual Studio 2019+ with C++ (Windows)
- .NET

## 使用方法

1. Clone仓库

   ```bash
   git clone https://github.com/AgoraIO-Community/Agora-C_Sharp-SDK.git
   ```

   ```bash
   git checkout dev/3.5.0.3
   ```

2. 下载运行所需的SDK

	以Debug、X64为例。
	通过Visual Studio打开 `Agora-C_Sharp-SDK/CSharp-API_Example/CSharp-API_Example.sln`解决方案，选择x64平台。

   在 [Agora Video SDK for Windows](https://artifactory-api.bj2.agoralab.co/artifactory/CSDC_repo/IRIS/3.5.0.3/iris_3.5.0.3_RTC_Windows_20210909_0439.zip) 下载 SDK。解压缩之后，将 `RTC/Agora_Native_SDK_for_Windows_FULL/libs/x86_64`以及`x64/Release` 目录下所有的 `.dll` 文件复制到`Agora-C_Sharp-SDK/CSharp-API_Example/binx64/Debug/netcoreapp3.1` 文件夹中。

3. 编译、运行示例


*如您还未获取App ID，您可以查看附录。*

## 帮助

如您需要了解关于我们API的更多信息，请参考[Agora C++ API](https://docs.agora.io/cn/Video/API%20Reference/cpp/v3.5.0/index.html)。

*C# API文档还在推进中，但我们已有的C++ API是相似的。*

## 附录

### 创建Agora账户并获取App ID

如果想要使用我们的SDK，您需要先获得一个App ID：

1. 在[agora.io](https://dashboard.agora.io/signin/)中注册一个账号。当您完成注册后，您将被链接至控制台。
2. 在控制台左侧点击**Projects** > **Project List**。
3. 请将您从控制台中获取的App ID保存，您将会在运行示例时使用（示例图形化界面中有输入框）。