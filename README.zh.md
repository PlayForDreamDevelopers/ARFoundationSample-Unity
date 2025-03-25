[![en](https://img.shields.io/badge/lang-en-red.svg)](./README.md)

<br />
<div align="center">
    <a href="{{PROJECT_REPO_URL}}">
        <img src="https://www.pfdm.cn/en/static/img/logo.2b1b07e.png" alt="Logo" width="20%">
    </a>
    <h1 align="center">ARFoundation Unity Sample</h1>
    <p align="center">
        ARFoundation 在 PFDM 环境下的 Unity 示例
        <br />
        <a href="https://github.com/PlayForDreamDevelopers/ARFoundationSample-Unity/blob/main/README.zh.md"><strong>查看文档 »</strong></a>
        <br />
        <br />
        <a href="https://github.com/PlayForDreamDevelopers/ARFoundationSample-Unity#示例">查看示例"</a>
        &middot;
        <a href="https://github.com/PlayForDreamDevelopers/ARFoundationSample-Unity/issues/new?template=bug_report.yml">报告错误</a>
        &middot;
        <a href="https://github.com/PlayForDreamDevelopers/ARFoundationSample-Unity/issues/new?template=feature_request.yml">请求功能</a>
        &middot;
        <a href="https://github.com/PlayForDreamDevelopers/ARFoundationSample-Unity/issues/new?template=documentation_update.yml">改进文档</a>
    </p>

</div>

> [!tip]
>
> 2022 分支为 ARFoundation 5.1.6 版本 API，项目使用 Unity 版本为 Unity 2022.3.52f1
> 
> main 分支为 ARFoundation 6.0 版本 API ,项目使用 Unity 版本为 Unity 6000.0.40f1

## 关于项目

ARFoundationSample-Unity 是使用 ARFoundation 开发的一组示例场景，示例场景主要包括锚点，网格识别，摄像机等功能。开发者可以通过这些示例场景快速体验 PFDM 设备提供的能力

### 示例

此项目中的所有示例场景都可以在 `Assets/Scenes` 文件夹中找到，要了解有关每个场景中使用的 ARFoundation 组件的更多信息，请参阅 [AR Foundation Documentation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@6.1/manual/index.html)

#### Camera

演示相机功能的场景，提供 VST 功能

#### Plane Detection

平面检测功能，用于绘制当前环境中所识别到的平面信息

#### Anchors

此示例演示如何在手柄位置处创建锚点，以及如何保存/删除/加载锚点
> [!tip]
>
> 保存/加载锚点仅在 ARFoundation6.0 以上版本 API 中使用，2022 分支为 6.0 以下版本接口。如需参考保存/加载锚点功能需要使用 main 分支并使用 Unity6 以上版本打开工程。

#### Mesh

演示通过真实世界扫描数据构建网格信息

## 要求


- 2022 分支要求 Unity 2022.3.52f1 或更新版本
- main 分支要求 Unity6 以上或更新版本。
- Unity 包：
  -  [YVR Core](https://github.com/PlayForDreamDevelopers/com.yvr.core-mirror)
    -   [YVR Utilities](https://github.com/PlayForDreamDevelopers/com.yvr.Utilities-mirror)
    -   [YVR Interaction](https://github.com/PlayForDreamDevelopers/com.yvr.interaction-mirror)

