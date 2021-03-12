# Agora C# SDK
*[中文](Readme.zh.md) | English*

Use Agora RTC SDK with C#! 

## Prerequisites

- Visual Studio 2017+ with C++ (Windows)
- .NET

## Installation

### Method 1: Use NuGet (Recommended)

For Visual Studio users, please refer to [Usage](#Usage).

```bash
dotnet add package agora_rtc_sdk --version 3.2.1.2
```

### Method 2: Compile SDK

1. Clone the repository.

   ```bash
   git clone https://github.com/AgoraIO-Community/Agora-C_Sharp-SDK.git
   ```

2. Compile SDK.

   Open `agorartc/agorartc.sln` via Visual Studio. Build Solution. 

## Usage

A GUI demo has been contained in the repository.

### Method 1: Use NuGet (Recommended)

1. Open `OneToOneVideo/OneToOneVideo.sln` via Visual Studio.
2. In `Solution Explorer`, find `OneToOneVideo->Dependencies` and right click. Then, click `Manage NuGet Packages...`.
3. Click `Browse` button, search `agora_rtc_sdk` and install the package.
4. Find all DLL files showed in `Solution Explorer` and set the `Copy to Output Directory` property in `Properties->Advanced` to `Copy always`.
5. Run demo.

### Method 2: Use DLL files

By following [self-compiling SDK](#Method 2: Compile SDK) in Installation section, please follow the instructions below.

1. Download the required Native SDK.

   Download SDK [Agora Video SDK for Windows](https://download.agora.io/sdk/release/Agora_Native_SDK_for_Windows_v3_2_1_FULL.zip). Unzip the downloaded SDK package and copy all the `.dll` files `libs/x86_64` into `OneToOneVideo/OneToOneVideo` folder.

2. Copy other required DLL files.

   Copy `agorartc/agorartc/bin/debug/netcoreapp3.1/agorartc.dll` and  `iris.dll` into `OneToOneVideo/OneToOneVideo` folder.

3. Open `OneToOneVideo/OneToOneVideo.sln` via Visual Studio. Run demo.

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
