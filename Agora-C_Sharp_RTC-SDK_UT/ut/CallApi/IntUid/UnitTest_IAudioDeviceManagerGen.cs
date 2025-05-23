#region Generated by `terra/node/src/rtc/ut/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

using NUnit.Framework;
using Agora.Rtc;
using System;
using view_t = System.UInt64;
namespace Agora.Rtc.Ut
{
    public partial class UnitTest_IAudioDeviceManager
    {
        [Test]
        public void Test_SetPlaybackDevice_4ad5f6e()
        {
            var deviceId = ParamsHelper.CreateParam<string>();

            var nRet = @interface.SetPlaybackDevice(deviceId);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetPlaybackDevice_73b9872()
        {
            var deviceId = ParamsHelper.CreateParam<string>();

            var nRet = @interface.GetPlaybackDevice(ref deviceId);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetPlaybackDeviceInfo_5540658()
        {
            var deviceId = ParamsHelper.CreateParam<string>();

            var deviceName = ParamsHelper.CreateParam<string>();

            var nRet = @interface.GetPlaybackDeviceInfo(ref deviceId, ref deviceName);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetPlaybackDeviceInfo_ed3a96d()
        {
            var deviceId = ParamsHelper.CreateParam<string>();

            var deviceName = ParamsHelper.CreateParam<string>();

            var deviceTypeName = ParamsHelper.CreateParam<string>();

            var nRet = @interface.GetPlaybackDeviceInfo(ref deviceId, ref deviceName, ref deviceTypeName);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetPlaybackDeviceVolume_46f8ab7()
        {
            var volume = ParamsHelper.CreateParam<int>();

            var nRet = @interface.SetPlaybackDeviceVolume(volume);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetPlaybackDeviceVolume_915cb25()
        {
            var volume = ParamsHelper.CreateParam<int>();

            var nRet = @interface.GetPlaybackDeviceVolume(ref volume);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetRecordingDevice_4ad5f6e()
        {
            var deviceId = ParamsHelper.CreateParam<string>();

            var nRet = @interface.SetRecordingDevice(deviceId);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetRecordingDevice_73b9872()
        {
            var deviceId = ParamsHelper.CreateParam<string>();

            var nRet = @interface.GetRecordingDevice(ref deviceId);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetRecordingDeviceInfo_5540658()
        {
            var deviceId = ParamsHelper.CreateParam<string>();

            var deviceName = ParamsHelper.CreateParam<string>();

            var nRet = @interface.GetRecordingDeviceInfo(ref deviceId, ref deviceName);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetRecordingDeviceInfo_ed3a96d()
        {
            var deviceId = ParamsHelper.CreateParam<string>();

            var deviceName = ParamsHelper.CreateParam<string>();

            var deviceTypeName = ParamsHelper.CreateParam<string>();

            var nRet = @interface.GetRecordingDeviceInfo(ref deviceId, ref deviceName, ref deviceTypeName);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetRecordingDeviceVolume_46f8ab7()
        {
            var volume = ParamsHelper.CreateParam<int>();

            var nRet = @interface.SetRecordingDeviceVolume(volume);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetRecordingDeviceVolume_915cb25()
        {
            var volume = ParamsHelper.CreateParam<int>();

            var nRet = @interface.GetRecordingDeviceVolume(ref volume);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetLoopbackDevice_4ad5f6e()
        {
            var deviceId = ParamsHelper.CreateParam<string>();

            var nRet = @interface.SetLoopbackDevice(deviceId);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetLoopbackDevice_73b9872()
        {
            var deviceId = ParamsHelper.CreateParam<string>();

            var nRet = @interface.GetLoopbackDevice(ref deviceId);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetPlaybackDeviceMute_5039d15()
        {
            var mute = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.SetPlaybackDeviceMute(mute);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetPlaybackDeviceMute_d942327()
        {
            var mute = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.GetPlaybackDeviceMute(ref mute);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetRecordingDeviceMute_5039d15()
        {
            var mute = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.SetRecordingDeviceMute(mute);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetRecordingDeviceMute_d942327()
        {
            var mute = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.GetRecordingDeviceMute(ref mute);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_StartPlaybackDeviceTest_3a2037f()
        {
            var testAudioFilePath = ParamsHelper.CreateParam<string>();

            var nRet = @interface.StartPlaybackDeviceTest(testAudioFilePath);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_StopPlaybackDeviceTest()
        {
            var nRet = @interface.StopPlaybackDeviceTest();
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_StartRecordingDeviceTest_46f8ab7()
        {
            var indicationInterval = ParamsHelper.CreateParam<int>();

            var nRet = @interface.StartRecordingDeviceTest(indicationInterval);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_StopRecordingDeviceTest()
        {
            var nRet = @interface.StopRecordingDeviceTest();
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_StartAudioDeviceLoopbackTest_46f8ab7()
        {
            var indicationInterval = ParamsHelper.CreateParam<int>();

            var nRet = @interface.StartAudioDeviceLoopbackTest(indicationInterval);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_StopAudioDeviceLoopbackTest()
        {
            var nRet = @interface.StopAudioDeviceLoopbackTest();
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_FollowSystemPlaybackDevice_5039d15()
        {
            var enable = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.FollowSystemPlaybackDevice(enable);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_FollowSystemRecordingDevice_5039d15()
        {
            var enable = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.FollowSystemRecordingDevice(enable);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_FollowSystemLoopbackDevice_5039d15()
        {
            var enable = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.FollowSystemLoopbackDevice(enable);
            Assert.AreEqual(0, nRet);
        }


    }
}