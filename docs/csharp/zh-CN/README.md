# Windows C# RTC SDK 中文文档

适用版本：`release/4.5`，独立 Windows C# RTC SDK `4.5.3.6-alpha.3`。接口核对基线：`11826c107897d28699dbaec2d18ae99a308d4663`。

本文面向 WinForms、WPF 和其他 Windows .NET 应用，命名空间为 `Agora.Rtc`。Unity 的 `MonoBehaviour`、`VideoSurface` 和 Unity 生命周期不属于这里的接入方式。

## 阅读顺序

| 文档 | 内容 |
| --- | --- |
| [接入与运行环境](integration.md) | .NET Framework 4.5.2、NuGet/ZIP、x86/x64、本地 DLL、通话调用示例 |
| [常用 API 参考](api-reference.md) | 初始化、进退频道、Token、音视频、设备、屏幕共享、原始帧和数据流 |
| [回调与数据类型](callbacks-and-types.md) | 事件签名、异步结果、线程处理、媒体选项和常用类型 |
| [接口签名索引](api-index.md) | 本分支接口声明及源码定位，用于查找其余方法和重载 |

常用 API 页提供独立 Windows 接入所需的中文语义、参数和调用约束；签名索引保留其他模块的声明入口。共享源码还包含其他平台、预览和定制接口，**接口存在不等于 Windows 支持该功能**；使用扩展功能前需核对对应源码注释的平台限制和交付包能力。

## 交付物与兼容性

| 项目 | 本版本情况 |
| --- | --- |
| 平台 | Windows，x86 和 x64；按应用进程位数选择 |
| NuGet 包 | `agora_rtc_sdk`，托管程序集 `agorartc.dll` |
| SDK 目标框架 | `net40`、`netstandard2.0`，见 [打包工程](../../../ci/build/csharp/agorartc.csproj) |
| .NET Framework 4.5.2 应用 | 可引用包中的 `net40` 资产；这不要求将业务工程升级到 .NET 10 |
| 仓库 WinForms Demo | 目标框架 `net10.0-windows`；交付 Demo 按 x86/x64 自带运行时 |
| 示例源码 | [API Example](../../../Agora-C_Sharp-RTC-SDK-API_Example/src) |

`.NET Framework 4.5.2` 的托管框架兼容性依据是 SDK 的 `net40` 构建目标。实际部署仍须满足 Native DLL、VC++ 运行库、Windows 版本、设备和权限要求；该结论不表示本次在每个 .NET Framework/Windows 组合上完成过设备通话验收。

SDK ZIP 包含两种架构的依赖；Demo 分为 x86/x64 两个 ZIP。不要将只含托管程序集的目录作为完整 SDK 运行环境。

## 版本边界

本页不表示制品已发布到公开 NuGet 源。测试候选包可从交付的 `.nupkg` 建立本地包源安装；具体步骤见接入文档。Native 依赖为 `4.5.3.6`，Iris 依赖为 `4.5.3.6-build.8`。

SDK 示例、返回值和接口名称以本分支为准。其他版本的 Unity 文档不能直接作为当前独立 Windows SDK 的接口签名依据。升级 SDK 后，应重新核对方法重载、数据类型、回调和 Native/Iris 配套版本。
