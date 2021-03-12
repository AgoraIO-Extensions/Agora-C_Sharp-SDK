using System;
using agorartc;

namespace RtcVideoDeviceManagerApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var videoDeviceManagerApiTest = new AgoraRtcVideoDeviceManagerApiTest(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\test\\test_result\\video_api_test_result.json",
                new MyEventHandler(), AgoraRtcEngine.CreateRtcEngine());
            videoDeviceManagerApiTest.BeginApiTestByFile(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\iris\\case\\VideoApiTest.json");
        }
    }

    internal class MyEventHandler : IRtcEngineEventHandlerBase
    {
        public override void OnApiTest(int apiType, string @params)
        {
            var apiTypeEnum = (CApiTypeVideoDeviceManager) apiType;
            switch (apiTypeEnum)
            {
                case CApiTypeVideoDeviceManager.kGetVideoDeviceCount:
                    AgoraRtcEngine.CreateRtcEngine().CreateVideoDeviceManager().GetDeviceCount();
                    break;
                case CApiTypeVideoDeviceManager.kGetVideoDeviceInfoByIndex:
                    AgoraRtcEngine.CreateRtcEngine().CreateVideoDeviceManager().GetDeviceInfoByIndex(
                        (int) AgoraUtil.GetData<int>(@params, "index"),
                        out var deviceName, out var deviceId);
                    Console.WriteLine(">>> \"CreateAudioPlaybackDeviceManager\" deviceName: {0}, deviceId: {1}",
                        deviceName, deviceId);
                    break;
                case CApiTypeVideoDeviceManager.kSetCurrentVideoDeviceId:
                    AgoraRtcEngine.CreateRtcEngine().CreateVideoDeviceManager().SetCurrentDevice(
                        (string) AgoraUtil.GetData<string>(@params, "deviceId"));
                    break;
                case CApiTypeVideoDeviceManager.kGetCurrentVideoDeviceId:
                    AgoraRtcEngine.CreateRtcEngine().CreateVideoDeviceManager().GetCurrentDevice();
                    break;
                case CApiTypeVideoDeviceManager.kStartVideoDeviceTest:
                    AgoraRtcEngine.CreateRtcEngine().CreateVideoDeviceManager().StartDeviceTest(
                        (ulong) AgoraUtil.GetData<ulong>(@params, "hwnd"));
                    break;
                case CApiTypeVideoDeviceManager.kStopVideoDeviceTest:
                    AgoraRtcEngine.CreateRtcEngine().CreateVideoDeviceManager().StopDeviceTest();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
