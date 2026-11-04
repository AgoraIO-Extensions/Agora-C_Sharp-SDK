# Agent instructions

Generated code is immutable. Read and follow [AGENT.md](AGENT.md) before changing this repository. Put runtime fixes in handwritten partial classes or adapters; do not patch generated files or change Terra generation rules to bypass this constraint.

EP-916: 独立 Windows C# 构建入口为 `ci/build/csharp/`，由现有 Unity Job 的显式 `SDK_TARGET=CSharp` 分流；默认 Unity 行为和生成代码保持不变。Demo 位于同仓库，必须消费本次候选包。

EP-916：独立C#曲库回调在手写MusicContentCenterEventHandlerNative入口按Iris UTF-8字节契约解码并隔离异常，不补造requestId或修改生成分发。Windows x86/x64运行原生内存回调回归；Unity原有路径保留。
