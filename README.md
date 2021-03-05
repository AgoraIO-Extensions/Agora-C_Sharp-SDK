# Agora C# SDK
*[中文](Readme.zh.md) | English*

Use Agora RTC SDK with C#! 

## Prerequisites

- Visual Studio 2017+ with C++ (Windows)
- .NET

## Installation

1. Clone the repository.

   ```bash
   git clone https://github.com/AgoraIO-Community/Agora-C_Sharp-SDK.git
   ```

2. Download the required SDK.

   Download SDK [Agora Video SDK for Windows](https://download.agora.io/sdk/release/Agora_Native_SDK_for_Windows_v3_1_2_FULL.zip). Unzip the downloaded SDK package and copy the `agora_rtc_sdk.dll` and `agora_rtc_sdk.lib` files from `libs/x86_64` into `agora_cpp/CSharp_RTC_SDK/lib`.

3. Compile SDK.

   Open `agora_cpp/agora_cpp.sln` via Visual Studio. Build Solution. The generated dynamic library lies in `agora_cpp/x64/Debug` named `agora_cpp.dll`.
   
   Open `agorartc/agorartc.sln` via Visual Studio. Build Solution. 

## Usage

A GUI demo has been contained in the repository.

1. Add the required dynamic libraries and the SDK folder into the project.

   Copy `agora_cpp/x64/Debug/agora_cpp.dll` and  `agora_cpp/CSharp_RTC_SDK/lib/agora_rtc_sdk.dll` into `OneToOneVideo/OneToOneVideo` folder.

2. Open `OneToOneVideo/OneToOneVideo.sln` via Visual Studio. Run Demo.

   *If you do not have an App ID, see Appendix.*

## Help

For more information about our API, please refer to [Agora C++ API](https://docs.agora.io/en/Video/API%20Reference/cpp/v3.1.2/index.html).

*C# API reference is on proceeding while C++ API is similar.*

## Appendix

### Create an Account and Obtain an App ID

To use our SDK, you must obtain an app ID: 

1. Create a developer account at [agora.io](https://dashboard.agora.io/signin/). Once you finish the sign-up process, you are redirected to the dashboard.
2. Navigate in the dashboard tree on the left to **Projects** > **Project List**.
3. Copy the app ID that you obtained from the dashboard into a text file. You will use it when you run demo (there is an input box in our GUI demo).
