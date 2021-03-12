using System;
using agorartc;

namespace RtcAudioDeviceManagerApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var audioDeviceManagerApiTest = new AgoraRtcAudioDeviceManagerApiTest(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\test\\test_result\\audio_api_test_result.json",
                new MyEventHandler(), AgoraRtcEngine.CreateRtcEngine());
            audioDeviceManagerApiTest.BeginApiTestByFile(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\iris\\case\\AudioApiTest.json");
        }
    }

    internal class MyEventHandler : IRtcEngineEventHandlerBase
    {
        public override void OnApiTest(int apiType, string @params)
        {
            var apiTypeEnum = (CApiTypeAudioDeviceManager) apiType;
            switch (apiTypeEnum)
            {
                case CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceCount:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().GetDeviceCount();
                    break;
                case CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceInfoByIndex:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().GetDeviceInfoByIndex(
                        (int) AgoraUtil.GetData<int>(@params, "index"),
                        out var deviceName1, out var deviceId1);
                    Console.WriteLine(">>> \"CreateAudioPlaybackDeviceManager\" deviceName: {0}, deviceId: {1}",
                        deviceName1, deviceId1);
                    break;
                case CApiTypeAudioDeviceManager.kSetCurrentAudioPlaybackDeviceId:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().SetCurrentDevice(
                        (string) AgoraUtil.GetData<string>(@params, "deviceId"));
                    break;
                case CApiTypeAudioDeviceManager.kGetCurrentAudioPlaybackDeviceId:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().GetCurrentDevice();
                    break;
                case CApiTypeAudioDeviceManager.kGetCurrentAudioPlaybackDeviceInfo:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().GetCurrentDeviceInfo(
                        out var deviceId2, out var deviceName2);
                    Console.WriteLine(">>> \"GetCurrentDeviceInfo\" deviceName: {0}, deviceId: {1}",
                        deviceName2, deviceId2);
                    break;
                case CApiTypeAudioDeviceManager.kSetAudioPlaybackDeviceVolume:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().SetDeviceVolume(
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceVolume:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().GetDeviceVolume();
                    break;
                case CApiTypeAudioDeviceManager.kSetAudioPlaybackDeviceMute:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().SetDeviceMute(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceMute:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().GetDeviceMute();
                    break;
                case CApiTypeAudioDeviceManager.kStartAudioPlaybackDeviceTest:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().StartDeviceTest(
                        (string) AgoraUtil.GetData<string>(@params, "testAudioFilePath"));
                    break;
                case CApiTypeAudioDeviceManager.kStopAudioPlaybackDeviceTest:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().StopDeviceTest();
                    break;
                case CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceCount:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioRecordingDeviceManager().GetDeviceCount();
                    break;
                case CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceInfoByIndex:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioRecordingDeviceManager().GetDeviceInfoByIndex(
                        (int) AgoraUtil.GetData<int>(@params, "index"),
                        out var deviceName3, out var deviceId3);
                    Console.WriteLine(">>> \"GetDeviceInfoByIndex\" deviceName: {0}, deviceId: {1}",
                        deviceName3, deviceId3);
                    break;
                case CApiTypeAudioDeviceManager.kSetCurrentAudioRecordingDeviceId:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioRecordingDeviceManager().SetCurrentDevice(
                        (string) AgoraUtil.GetData<string>(@params, "deviceId"));
                    break;
                case CApiTypeAudioDeviceManager.kGetCurrentAudioRecordingDeviceId:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioRecordingDeviceManager().GetCurrentDevice();
                    break;
                case CApiTypeAudioDeviceManager.kGetCurrentAudioRecordingDeviceInfo:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioRecordingDeviceManager().GetCurrentDeviceInfo(
                        out var deviceId4, out var deviceName4);
                    Console.WriteLine(">>> \"GetCurrentDeviceInfo\" deviceName: {0}, deviceId: {1}",
                        deviceName4, deviceId4);
                    break;
                case CApiTypeAudioDeviceManager.kSetAudioRecordingDeviceVolume:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioRecordingDeviceManager().SetDeviceVolume(
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceVolume:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioRecordingDeviceManager().GetDeviceVolume();
                    break;
                case CApiTypeAudioDeviceManager.kSetAudioRecordingDeviceMute:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioRecordingDeviceManager().SetDeviceMute(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceMute:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioRecordingDeviceManager().GetDeviceMute();
                    break;
                case CApiTypeAudioDeviceManager.kStartAudioRecordingDeviceTest:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioRecordingDeviceManager().StartDeviceTest(
                        (string) AgoraUtil.GetData<string>(@params, "testAudioFilePath"));
                    break;
                case CApiTypeAudioDeviceManager.kStopAudioRecordingDeviceTest:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioRecordingDeviceManager().StopDeviceTest();
                    break;
                case CApiTypeAudioDeviceManager.kStartAudioDeviceLoopbackTest:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().StartDeviceLoopbackTest(
                        (int) AgoraUtil.GetData<int>(@params, "indicationInterval"));
                    break;
                case CApiTypeAudioDeviceManager.kStopAudioDeviceLoopbackTest:
                    AgoraRtcEngine.CreateRtcEngine().CreateAudioPlaybackDeviceManager().StopDeviceLoopbackTest();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}