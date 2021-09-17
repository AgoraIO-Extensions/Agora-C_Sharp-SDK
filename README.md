# Agora C# SDK
*[中文](Readme.zh.md) | English*

Use Agora RTC SDK with C#! 

## Prerequisites

- Visual Studio 2019+ with C++ (Windows)
- .NET

## Usage

1. Clone the repository.

	```bash
	git clone https://github.com/AgoraIO-Community/Agora-C_Sharp-SDK.git
	```

	```bash
	git checkout dev/3.5.0.3
	```

2. Download required SDK.
    
	Open `Agora-C_Sharp-SDK/CSharp-API_Example/CSharp-API_Example.sln` via Visual Studio. select x64 platform.

	Download SDK [Agora Video SDK for Windows](https://artifactory-api.bj2.agoralab.co/artifactory/CSDC_repo/IRIS/3.5.0.3/iris_3.5.0.3_RTC_Windows_20210909_0439.zip). Unzip the downloaded SDK package and copy all the `.dll` files from `RTC/Agora_Native_SDK_for_Windows_FULL/libs/x86_64` and `x64/Release` to `Agora-C_Sharp-SDK/CSharp-API_Example/binx64/Debug/netcoreapp3.1` folder.
   
3. Build and Run

    Build CSharp-API_Example Project and Run.  
	Have fun!

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
