using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Agora.Rtc.Ut.Event
{
    public class FakeAudioSpectrumData
    {
        public IntPtr audioSpectrumData;
        public int dataLength;

        public FakeAudioSpectrumData(AudioSpectrumData data)
        {
            this.dataLength = data.dataLength;
            this.audioSpectrumData = Marshal.UnsafeAddrOfPinnedArrayElement(data.audioSpectrumData, 0);
        }
    };

    class FakeUserAudioSpectrumInfo
    {

        public uint uid;
        public FakeAudioSpectrumData spectrumData;

        public FakeUserAudioSpectrumInfo(UserAudioSpectrumInfo info)
        {
            this.uid = info.uid;
            this.spectrumData = new FakeAudioSpectrumData(info.spectrumData);
        }
    }

    [TestFixture]
    public partial class UnitTest_IAudioSpectrumObserver
    {
        public IRtcEngineEx Engine;
        public UTAudioSpectrumObserver EventHandler;
        public IMediaPlayer MediaPlayer;
        public UTAudioSpectrumObserver EventHandlerForMediaPlayer;
        public IntPtr FakeRtcEnginePtr;
        public IrisCApiParam2 ApiParam;
        public Dictionary<string, System.Object> jsonObj = new Dictionary<string, object>();

        [SetUp]
        public void Setup()
        {
            FakeRtcEnginePtr = DLLHelper.CreateFakeRtcEngine();
            Engine = RtcEngine.CreateAgoraRtcEngineEx(FakeRtcEnginePtr);
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            ApiParam.AllocResult();

            EventHandler = new UTAudioSpectrumObserver();
            EventHandler.TAG = "FOR_RTCENGINE";
            int ret = Engine.RegisterAudioSpectrumObserver(EventHandler);
            Assert.AreEqual(0, ret);

            EventHandlerForMediaPlayer = new UTAudioSpectrumObserver();
            EventHandlerForMediaPlayer.TAG = "FOR_MEDIAPLAYER";
            MediaPlayer = Engine.CreateMediaPlayer();
            ret = MediaPlayer.RegisterMediaPlayerAudioSpectrumObserver(EventHandlerForMediaPlayer, 10);

            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.UnregisterAudioSpectrumObserver();
            Assert.AreEqual(0, ret);

            ret = MediaPlayer.UnregisterMediaPlayerAudioSpectrumObserver();
            Assert.AreEqual(0, ret);

            Engine.Dispose();
            ApiParam.FreeResult();
        }

        [Test]
        public void Test_IAudioSpectrumObserver_OnLocalAudioSpectrum()
        {
            ApiParam.@event = AgoraApiType.IAUDIOSPECTRUMOBSERVER_ONLOCALAUDIOSPECTRUM_5822fed;

            jsonObj.Clear();

            AudioSpectrumData data = ParamsHelper.CreateParam<AudioSpectrumData>();
            FakeAudioSpectrumData fakeData = new FakeAudioSpectrumData(data);
            jsonObj.Add("data", fakeData);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalAudioSpectrumPassed(data));
            Assert.AreEqual(true, EventHandlerForMediaPlayer.OnLocalAudioSpectrumPassed(data));
        }

        [Test]
        public void Test_IAudioSpectrumObserver_OnRemoteAudioSpectrum()
        {
            ApiParam.@event = AgoraApiType.IAUDIOSPECTRUMOBSERVER_ONREMOTEAUDIOSPECTRUM_8ea2cde;

            jsonObj.Clear();

            UserAudioSpectrumInfo[] spectrums = ParamsHelper.CreateParam<UserAudioSpectrumInfo[]>();
            FakeUserAudioSpectrumInfo[] fakeSpectrums = new FakeUserAudioSpectrumInfo[spectrums.Length];
            for (int i = 0; i < spectrums.Length; i++)
            {
                fakeSpectrums[i] = new FakeUserAudioSpectrumInfo(spectrums[i]);
            }
            jsonObj.Add("spectrums", fakeSpectrums);

            uint spectrumNumber = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("spectrumNumber", spectrumNumber);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteAudioSpectrumPassed(spectrums, spectrumNumber));
            Assert.AreEqual(true, EventHandlerForMediaPlayer.OnRemoteAudioSpectrumPassed(spectrums, spectrumNumber));
        }
    }
}
