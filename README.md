[![zh](https://img.shields.io/badge/lang-zh-green.svg)](./README.zh.md)

<br />
<div align="center">
    <a href="{{PROJECT_REPO_URL}}">
        <img src="https://www.pfdm.cn/en/static/img/logo.2b1b07e.png" alt="Logo" width="20%">
    </a>
    <h1 align="center">ARFoundation Unity Sample</h1>
    <p align="center">
        Unity sample projects for ARFoundation on PFDM devices
        <br />
        <a href="https://github.com/PlayForDreamDevelopers/ARFoundationSample-Unity/blob/main/README.md"><strong>Explore Documentation »</strong></a>
        <br />
        <br />
        <a href="https://github.com/PlayForDreamDevelopers/ARFoundationSample-Unity#examples">View Examples</a>
        &middot;
        <a href="https://github.com/PlayForDreamDevelopers/ARFoundationSample-Unity/issues/new?template=bug_report.yml">Report Bug</a>
        &middot;
        <a href="https://github.com/PlayForDreamDevelopers/ARFoundationSample-Unity/issues/new?template=feature_request.yml">Request Feature</a>
        &middot;
        <a href="https://github.com/PlayForDreamDevelopers/ARFoundationSample-Unity/issues/new?template=documentation_update.yml">Improve Docs</a>
    </p>
</div>

> [!TIP]
>
> The **2022 branch** uses ARFoundation 5.1.6 API and requires **Unity 2022.3.52f1** or newer.  
> The **main branch** uses ARFoundation 6.0 API and requires **Unity 6000.0.40f1** or newer.

## About the Project

ARFoundationSample-Unity is a collection of sample scenes developed with ARFoundation. These scenes demonstrate core functionalities such as anchors, plane detection, and camera features. Developers can quickly explore the capabilities provided by PFDM devices through these examples.

### Examples

All sample scenes can be found in the `Assets/Scenes` folder. For detailed information about ARFoundation components used in each scene, refer to the [AR Foundation Documentation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@6.1/manual/index.html).

#### Camera

A scene demonstrating camera functionalities, including **Video See-Through (VST)** support.

#### Plane Detection

Detects and visualizes planes in the environment using ARFoundation's plane tracking system.

#### Anchors

This example shows how to create anchors at controller positions, and how to save/delete/load anchors.
> [!TIP]
>
> **Anchor saving/loading** is only available in ARFoundation 6.0+ APIs. The 2022 branch uses pre-6.0 APIs. To use this feature, switch to the **main branch** and open the project with **Unity 6** or newer.

#### Mesh

Demonstrates real-time 3D mesh generation by scanning and reconstructing real-world environments.

## Requirements

- **2022 branch**: Unity 2022.3.52f1 or newer.
- **main branch**: Unity 6000.0.40f1 or newer.
- **Unity Packages**:
  - [YVR Core](https://github.com/PlayForDreamDevelopers/com.yvr.core-mirror)
  - [YVR Utilities](https://github.com/PlayForDreamDevelopers/com.yvr.Utilities-mirror)
  - [YVR Interaction](https://github.com/PlayForDreamDevelopers/com.yvr.interaction-mirror)