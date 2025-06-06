#region Generated by `terra/node/src/rtc/ut/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

using NUnit.Framework;
using Agora.Rtc;
using System;
using view_t = System.UInt64;
namespace Agora.Rtc.Ut
{
    public partial class UnitTest_IMusicPlayer
    {
        [Test]
        public void Test_Open_303b92e()
        {
            var songCode = ParamsHelper.CreateParam<long>();

            var startPos = ParamsHelper.CreateParam<long>();

            var nRet = @interface.Open(songCode, startPos);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetPlayMode_748bee0()
        {
            var mode = ParamsHelper.CreateParam<MusicPlayMode>();

            var nRet = @interface.SetPlayMode(mode);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_Open_e43f201()
        {
            var url = ParamsHelper.CreateParam<string>();

            var startPos = ParamsHelper.CreateParam<long>();

            var nRet = @interface.Open(url, startPos);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_Play()
        {
            var nRet = @interface.Play();
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_Pause()
        {
            var nRet = @interface.Pause();
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_Stop()
        {
            var nRet = @interface.Stop();
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_Resume()
        {
            var nRet = @interface.Resume();
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_Seek_f631116()
        {
            var newPos = ParamsHelper.CreateParam<long>();

            var nRet = @interface.Seek(newPos);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetAudioPitch_46f8ab7()
        {
            var pitch = ParamsHelper.CreateParam<int>();

            var nRet = @interface.SetAudioPitch(pitch);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetDuration_b12f121()
        {
            var duration = ParamsHelper.CreateParam<long>();

            var nRet = @interface.GetDuration(ref duration);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetPlayPosition_b12f121()
        {
            var pos = ParamsHelper.CreateParam<long>();

            var nRet = @interface.GetPlayPosition(ref pos);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetStreamCount_b12f121()
        {
            var count = ParamsHelper.CreateParam<long>();

            var nRet = @interface.GetStreamCount(ref count);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetStreamInfo_0fa63fa()
        {
            var index = ParamsHelper.CreateParam<long>();

            var info = ParamsHelper.CreateParam<PlayerStreamInfo>();

            var nRet = @interface.GetStreamInfo(index, ref info);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetLoopCount_46f8ab7()
        {
            var loopCount = ParamsHelper.CreateParam<int>();

            var nRet = @interface.SetLoopCount(loopCount);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetPlaybackSpeed_46f8ab7()
        {
            var speed = ParamsHelper.CreateParam<int>();

            var nRet = @interface.SetPlaybackSpeed(speed);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SelectAudioTrack_46f8ab7()
        {
            var index = ParamsHelper.CreateParam<int>();

            var nRet = @interface.SelectAudioTrack(index);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SelectMultiAudioTrack_4e92b3c()
        {
            var playoutTrackIndex = ParamsHelper.CreateParam<int>();

            var publishTrackIndex = ParamsHelper.CreateParam<int>();

            var nRet = @interface.SelectMultiAudioTrack(playoutTrackIndex, publishTrackIndex);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetPlayerOption_4d05d29()
        {
            var key = ParamsHelper.CreateParam<string>();

            var value = ParamsHelper.CreateParam<int>();

            var nRet = @interface.SetPlayerOption(key, value);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetPlayerOption_ccad422()
        {
            var key = ParamsHelper.CreateParam<string>();

            var value = ParamsHelper.CreateParam<string>();

            var nRet = @interface.SetPlayerOption(key, value);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_TakeScreenshot_3a2037f()
        {
            var filename = ParamsHelper.CreateParam<string>();

            var nRet = @interface.TakeScreenshot(filename);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SelectInternalSubtitle_46f8ab7()
        {
            var index = ParamsHelper.CreateParam<int>();

            var nRet = @interface.SelectInternalSubtitle(index);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetExternalSubtitle_3a2037f()
        {
            var url = ParamsHelper.CreateParam<string>();

            var nRet = @interface.SetExternalSubtitle(url);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetState()
        {
            var nRet = @interface.GetState();
            Assert.AreEqual(MEDIA_PLAYER_STATE.PLAYER_STATE_IDLE, nRet);
        }


        [Test]
        public void Test_Mute_5039d15()
        {
            var muted = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.Mute(muted);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetMute_c93e9d4()
        {
            var muted = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.GetMute(ref muted);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_AdjustPlayoutVolume_46f8ab7()
        {
            var volume = ParamsHelper.CreateParam<int>();

            var nRet = @interface.AdjustPlayoutVolume(volume);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetPlayoutVolume_9cfaa7e()
        {
            var volume = ParamsHelper.CreateParam<int>();

            var nRet = @interface.GetPlayoutVolume(ref volume);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_AdjustPublishSignalVolume_46f8ab7()
        {
            var volume = ParamsHelper.CreateParam<int>();

            var nRet = @interface.AdjustPublishSignalVolume(volume);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetPublishSignalVolume_9cfaa7e()
        {
            var volume = ParamsHelper.CreateParam<int>();

            var nRet = @interface.GetPublishSignalVolume(ref volume);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetView_cb1a81f()
        {
            var view = ParamsHelper.CreateParam<view_t>();

            var nRet = @interface.SetView(view);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetRenderMode_bedb5ae()
        {
            var renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();

            var nRet = @interface.SetRenderMode(renderMode);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_UnregisterMediaPlayerAudioSpectrumObserver_09064ce()
        {
            var nRet = @interface.UnregisterMediaPlayerAudioSpectrumObserver();
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetAudioDualMonoMode_30c9672()
        {
            var mode = ParamsHelper.CreateParam<AUDIO_DUAL_MONO_MODE>();

            var nRet = @interface.SetAudioDualMonoMode(mode);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetPlayerSdkVersion()
        {
            var nRet = @interface.GetPlayerSdkVersion();
            Assert.AreEqual("", nRet);
        }


        [Test]
        public void Test_GetPlaySrc()
        {
            var nRet = @interface.GetPlaySrc();
            Assert.AreEqual("", nRet);
        }


        [Test]
        public void Test_OpenWithAgoraCDNSrc_e43f201()
        {
            var src = ParamsHelper.CreateParam<string>();

            var startPos = ParamsHelper.CreateParam<long>();

            var nRet = @interface.OpenWithAgoraCDNSrc(src, startPos);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetAgoraCDNLineCount()
        {
            var nRet = @interface.GetAgoraCDNLineCount();
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SwitchAgoraCDNLineByIndex_46f8ab7()
        {
            var index = ParamsHelper.CreateParam<int>();

            var nRet = @interface.SwitchAgoraCDNLineByIndex(index);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetCurrentAgoraCDNIndex()
        {
            var nRet = @interface.GetCurrentAgoraCDNIndex();
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_EnableAutoSwitchAgoraCDN_5039d15()
        {
            var enable = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.EnableAutoSwitchAgoraCDN(enable);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_RenewAgoraCDNSrcToken_e43f201()
        {
            var token = ParamsHelper.CreateParam<string>();

            var ts = ParamsHelper.CreateParam<long>();

            var nRet = @interface.RenewAgoraCDNSrcToken(token, ts);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SwitchAgoraCDNSrc_7a174df()
        {
            var src = ParamsHelper.CreateParam<string>();

            var syncPts = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.SwitchAgoraCDNSrc(src, syncPts);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SwitchSrc_7a174df()
        {
            var src = ParamsHelper.CreateParam<string>();

            var syncPts = ParamsHelper.CreateParam<bool>();

            var nRet = @interface.SwitchSrc(src, syncPts);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_PreloadSrc_e43f201()
        {
            var src = ParamsHelper.CreateParam<string>();

            var startPos = ParamsHelper.CreateParam<long>();

            var nRet = @interface.PreloadSrc(src, startPos);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_PlayPreloadedSrc_3a2037f()
        {
            var src = ParamsHelper.CreateParam<string>();

            var nRet = @interface.PlayPreloadedSrc(src);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_UnloadSrc_3a2037f()
        {
            var src = ParamsHelper.CreateParam<string>();

            var nRet = @interface.UnloadSrc(src);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetSpatialAudioParams_5035667()
        {
            var @params = ParamsHelper.CreateParam<SpatialAudioParams>();

            var nRet = @interface.SetSpatialAudioParams(@params);
            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_SetSoundPositionParams_f282d50()
        {
            var pan = ParamsHelper.CreateParam<float>();

            var gain = ParamsHelper.CreateParam<float>();

            var nRet = @interface.SetSoundPositionParams(pan, gain);
            Assert.AreEqual(0, nRet);
        }


    }
}