using Agora.Rtc;
using NUnit.Framework;

namespace Agora.Rtc.Ut
{
    public class UnitTest_ConstructorCompatibility
    {
        private static Optional<T> Empty<T>()
        {
            return new Optional<T>();
        }

        [Test]
        public void VideoCanvas_OldFullConstructor_UsesDefaultRotation()
        {
            var canvas = new VideoCanvas(
                uid: 1,
                subviewUid: 2,
                view: 3,
                backgroundColor: 4,
                renderMode: RENDER_MODE_TYPE.RENDER_MODE_HIDDEN,
                mirrorMode: VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO,
                setupMode: VIDEO_VIEW_SETUP_MODE.VIDEO_VIEW_SETUP_REPLACE,
                sourceType: VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY,
                mediaPlayerId: 5,
                cropArea: new Rectangle(),
                enableAlphaMask: false,
                position: VIDEO_MODULE_POSITION.POSITION_POST_CAPTURER);

            Assert.AreEqual(VIDEO_ORIENTATION.VIDEO_ORIENTATION_0, canvas.rotation);
        }

        [Test]
        public void ChannelMediaOptions_OldFullConstructor_LeavesNewOptionsEmpty()
        {
            var options = new ChannelMediaOptions(
                publishCameraTrack: Empty<bool>(),
                publishSecondaryCameraTrack: Empty<bool>(),
                publishThirdCameraTrack: Empty<bool>(),
                publishFourthCameraTrack: Empty<bool>(),
                publishMicrophoneTrack: Empty<bool>(),
                publishScreenCaptureAudio: Empty<bool>(),
                publishScreenCaptureVideo: Empty<bool>(),
                publishScreenTrack: Empty<bool>(),
                publishSecondaryScreenTrack: Empty<bool>(),
                publishThirdScreenTrack: Empty<bool>(),
                publishFourthScreenTrack: Empty<bool>(),
                publishCustomAudioTrack: Empty<bool>(),
                publishCustomAudioTrackId: Empty<int>(),
                publishCustomVideoTrack: Empty<bool>(),
                publishEncodedVideoTrack: Empty<bool>(),
                publishMediaPlayerAudioTrack: Empty<bool>(),
                publishMediaPlayerVideoTrack: Empty<bool>(),
                publishTranscodedVideoTrack: Empty<bool>(),
                publishMixedAudioTrack: Empty<bool>(),
                publishLipSyncTrack: Empty<bool>(),
                autoSubscribeAudio: Empty<bool>(),
                autoSubscribeVideo: Empty<bool>(),
                enableAudioRecordingOrPlayout: Empty<bool>(),
                publishMediaPlayerId: Empty<int>(),
                clientRoleType: Empty<CLIENT_ROLE_TYPE>(),
                audienceLatencyLevel: Empty<AUDIENCE_LATENCY_LEVEL_TYPE>(),
                defaultVideoStreamType: Empty<VIDEO_STREAM_TYPE>(),
                channelProfile: Empty<CHANNEL_PROFILE_TYPE>(),
                audioDelayMs: Empty<int>(),
                mediaPlayerAudioDelayMs: Empty<int>(),
                token: Empty<string>(),
                enableBuiltInMediaEncryption: Empty<bool>(),
                publishRhythmPlayerTrack: Empty<bool>(),
                isInteractiveAudience: Empty<bool>(),
                customVideoTrackId: Empty<uint>(),
                isAudioFilterable: Empty<bool>(),
                parameters: Empty<string>(),
                enableMultipath: Empty<bool>(),
                uplinkMultipathMode: Empty<MultipathMode>(),
                downlinkMultipathMode: Empty<MultipathMode>(),
                preferMultipathType: Empty<MultipathType>());

            Assert.IsFalse(options.publishLoopbackAudioTrack.HasValue());
            Assert.IsFalse(options.publishLoopbackAudioTrackId.HasValue());
            Assert.IsFalse(options.channelType.HasValue());
        }

        [Test]
        public void RtcEngineContext_OldFullConstructor_UsesEmptyParameters()
        {
            var context = new RtcEngineContext(
                appId: "app-id",
                context: 0,
                channelProfile: CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING,
                license: string.Empty,
                audioScenario: AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT,
                areaCode: AREA_CODE.AREA_CODE_GLOB,
                logConfig: new LogConfig(),
                threadPriority: Empty<THREAD_PRIORITY_TYPE>(),
                useExternalEglContext: false,
                domainLimit: false,
                autoRegisterAgoraExtensions: true);

            Assert.AreEqual(string.Empty, context.parameters);
        }
    }
}
