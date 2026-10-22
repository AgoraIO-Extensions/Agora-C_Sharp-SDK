# Agent instructions

Generated code is immutable. Read and follow [AGENT.md](AGENT.md) before changing this repository. Put runtime fixes in handwritten partial classes or adapters; do not patch generated files or change Terra generation rules to bypass this constraint.

EP-916: 独立 Windows C# 构建入口为 `ci/build/csharp/`，由现有 Unity Job 的显式 `SDK_TARGET=CSharp` 分流；默认 Unity 行为和生成代码保持不变。Demo 位于同仓库，必须消费本次候选包。
