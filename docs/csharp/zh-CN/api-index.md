# 接口签名索引

[返回目录](README.md) · [常用 API 中文说明](api-reference.md) · [回调与类型](callbacks-and-types.md)

本索引对应 `release/4.5` 的 `11826c107897d28699dbaec2d18ae99a308d4663`，从 RTC 根目录接口文件的 public abstract / virtual 方法声明核对，保留重载及默认参数。工厂方法另见 [RtcEngine](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/Impl/RtcEngine.cs)。

共 28 个接口类、711 条方法/回调签名。它是源码查找表，不表示所有方法均适用于 Windows；移动端专用、内部/定制、技术预览及废弃接口的限制须阅读链接处的完整注释。类型字段、枚举值和构造函数不计入方法数量。

源码链接的行号对应上述基线；文档分支若升级 SDK，需要重新核对索引。常用 Windows API 的中文参数、调用顺序及示例见其余文档。

## 模块目录

- [IRtcEngine](#irtcengine)：RTC 主引擎：频道、采集、发布订阅与媒体控制（336 条）
- [IRtcEngineEventHandler](#irtcengineeventhandler)：RTC 事件：频道、连接、媒体状态和统计回调（100 条）
- [IRtcEngineEx](#irtcengineex)：多频道扩展：显式传入 RtcConnection（61 条）
- [IAudioDeviceManager](#iaudiodevicemanager)：Windows 音频设备枚举、选择与测试（33 条）
- [IAudioEncodedFrameObserver](#iaudioencodedframeobserver)：编码后音频帧观察器（3 条）
- [IAudioFrameObserver](#iaudioframeobserver)：原始音频帧观察器（6 条）
- [IAudioPcmFrameSink](#iaudiopcmframesink)：PCM 音频帧接收接口（1 条）
- [IAudioSpectrumObserver](#iaudiospectrumobserver)：音频频谱观察器（2 条）
- [IAudioTrackObserver](#iaudiotrackobserver)：音频轨道观察器（1 条）
- [IFaceInfoObserver](#ifaceinfoobserver)：人脸信息观察器（1 条）
- [IH265Transcoder](#ih265transcoder)：H.265 转码扩展（5 条）
- [IH265TranscoderObserver](#ih265transcoderobserver)：H.265 转码事件（3 条）
- [ILocalSpatialAudioEngine](#ilocalspatialaudioengine)：本地空间音频（21 条）
- [IMediaPlayer](#imediaplayer)：媒体播放器控制（55 条）
- [IMediaPlayerCacheManager](#imediaplayercachemanager)：媒体播放器缓存管理（11 条）
- [IMediaPlayerCustomDataProvider](#imediaplayercustomdataprovider)：媒体播放器自定义数据源（2 条）
- [IMediaPlayerSourceObserver](#imediaplayersourceobserver)：媒体播放器状态回调（13 条）
- [IMediaRecorder](#imediarecorder)：媒体录制控制（3 条）
- [IMediaRecorderObserver](#imediarecorderobserver)：媒体录制事件（2 条）
- [IMetadataObserver](#imetadataobserver)：视频元数据观察器（3 条）
- [IMusicContentCenter](#imusiccontentcenter)：音乐内容中心扩展（17 条）
- [IMusicContentCenterEventHandler](#imusiccontentcentereventhandler)：音乐内容中心事件（5 条）
- [IMusicPlayer](#imusicplayer)：音乐播放器扩展（2 条）
- [IVideoDeviceManager](#ivideodevicemanager)：Windows 摄像头枚举、能力与选择（7 条）
- [IVideoEffectObject](#ivideoeffectobject)：视频效果对象（11 条）
- [IVideoEncodedFrameObserver](#ivideoencodedframeobserver)：编码后视频帧观察器（1 条）
- [IVideoFrameMetaInfo](#ivideoframemetainfo)：视频帧元信息（1 条）
- [IVideoFrameObserver](#ivideoframeobserver)：原始视频帧观察器（5 条）

## IRtcEngine

RTC 主引擎：频道、采集、发布订阅与媒体控制。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [Dispose](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L23) | `void Dispose(bool sync = false)` | 源码 @ignore 标记 |
| [SetParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L39) | `int SetParameters(string key, object value)` | — |
| [GetNativeHandler](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L55) | `int GetNativeHandler(ref IntPtr nativeHandler)` | — |
| [UnRegisterAudioEncodedFrameObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L67) | `int UnRegisterAudioEncodedFrameObserver()` | — |
| [InitEventHandler](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L83) | `int InitEventHandler(IRtcEngineEventHandler engineEventHandler)` | — |
| [GetAudioDeviceManager](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L94) | `IAudioDeviceManager GetAudioDeviceManager()` | — |
| [GetVideoDeviceManager](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L105) | `IVideoDeviceManager GetVideoDeviceManager()` | — |
| [GetMusicContentCenter](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L110) | `IMusicContentCenter GetMusicContentCenter()` | 源码 @ignore 标记 |
| [GetMediaPlayerCacheManager](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L123) | `IMediaPlayerCacheManager GetMediaPlayerCacheManager()` | — |
| [GetLocalSpatialAudioEngine](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L136) | `ILocalSpatialAudioEngine GetLocalSpatialAudioEngine()` | — |
| [GetH265Transcoder](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L141) | `IH265Transcoder GetH265Transcoder()` | 源码 @ignore 标记 |
| [SetMaxMetadataSize](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L158) | `int SetMaxMetadataSize(int size)` | — |
| [SendMetadata](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L178) | `int SendMetadata(Metadata metadata, VIDEO_SOURCE_TYPE source_type)` | — |
| [SetLocalVideoDataSourcePosition](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L198) | `int SetLocalVideoDataSourcePosition(VIDEO_MODULE_POSITION position)` | — |
| [RegisterVideoFrameObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L221) | `int RegisterVideoFrameObserver(IVideoFrameObserver observer, VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)` | — |
| [UnRegisterVideoFrameObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L233) | `int UnRegisterVideoFrameObserver()` | — |
| [RegisterVideoEncodedFrameObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L251) | `int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver observer, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)` | — |
| [UnRegisterVideoEncodedFrameObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L263) | `int UnRegisterVideoEncodedFrameObserver()` | — |
| [RegisterAudioFrameObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L283) | `int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)` | — |
| [UnRegisterAudioFrameObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L295) | `int UnRegisterAudioFrameObserver()` | — |
| [UnRegisterFaceInfoObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L309) | `int UnRegisterFaceInfoObserver()` | — |
| [Initialize](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L330) | `int Initialize(RtcEngineContext context)` | — |
| [GetVersion](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L343) | `string GetVersion(ref int build)` | — |
| [GetErrorDescription](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L356) | `string GetErrorDescription(int code)` | — |
| [QueryCodecCapability](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L380) | `int QueryCodecCapability(ref CodecCapInfo[] codecInfo, ref int size)` | — |
| [QueryDeviceScore](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L392) | `int QueryDeviceScore()` | — |
| [PreloadChannel](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L426) | `int PreloadChannel(string token, string channelId, uint uid)` | — |
| [PreloadChannelWithUserAccount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L468) | `int PreloadChannelWithUserAccount(string token, string channelId, string userAccount)` | — |
| [UpdatePreloadChannelToken](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L486) | `int UpdatePreloadChannelToken(string token)` | — |
| [JoinChannel](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L526) | `int JoinChannel(string token, string channelId, string info, uint uid)` | — |
| [JoinChannel](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L566) | `int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options)` | — |
| [UpdateChannelMediaOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L583) | `int UpdateChannelMediaOptions(ChannelMediaOptions options)` | — |
| [LeaveChannel](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L602) | `int LeaveChannel()` | — |
| [LeaveChannel](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L618) | `int LeaveChannel(LeaveChannelOptions options)` | — |
| [RenewToken](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L639) | `int RenewToken(string token)` | — |
| [SetChannelProfile](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L657) | `int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)` | — |
| [SetClientRole](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L676) | `int SetClientRole(CLIENT_ROLE_TYPE role)` | — |
| [SetClientRole](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L698) | `int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options)` | — |
| [StartEchoTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L714) | `int StartEchoTest(EchoTestConfiguration config)` | — |
| [StopEchoTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L729) | `int StopEchoTest()` | — |
| [EnableMultiCamera](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L759) | `int EnableMultiCamera(bool enabled, CameraCapturerConfiguration config)` | — |
| [EnableVideo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L773) | `int EnableVideo()` | — |
| [DisableVideo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L787) | `int DisableVideo()` | — |
| [StartPreview](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L801) | `int StartPreview()` | — |
| [StartPreview](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L817) | `int StartPreview(VIDEO_SOURCE_TYPE sourceType)` | — |
| [StopPreview](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L829) | `int StopPreview()` | — |
| [StopPreview](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L843) | `int StopPreview(VIDEO_SOURCE_TYPE sourceType)` | — |
| [StartLastmileProbeTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L859) | `int StartLastmileProbeTest(LastmileProbeConfig config)` | — |
| [StopLastmileProbeTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L871) | `int StopLastmileProbeTest()` | — |
| [SetVideoEncoderConfiguration](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L887) | `int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)` | — |
| [SetBeautyEffectOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L914) | `int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)` | — |
| [SetFaceShapeBeautyOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L919) | `int SetFaceShapeBeautyOptions(bool enabled, FaceShapeBeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)` | 源码 @ignore 标记 |
| [SetFaceShapeAreaOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L924) | `int SetFaceShapeAreaOptions(FaceShapeAreaOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)` | 源码 @ignore 标记 |
| [GetFaceShapeBeautyOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L929) | `int GetFaceShapeBeautyOptions(ref FaceShapeBeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)` | 源码 @ignore 标记 |
| [GetFaceShapeAreaOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L934) | `int GetFaceShapeAreaOptions(FACE_SHAPE_AREA shapeArea, ref FaceShapeAreaOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)` | 源码 @ignore 标记 |
| [SetFilterEffectOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L956) | `int SetFilterEffectOptions(bool enabled, FilterEffectOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)` | — |
| [CreateVideoEffectObject](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L961) | `IVideoEffectObject CreateVideoEffectObject(string bundlePath, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)` | 源码 @ignore 标记 |
| [DestroyVideoEffectObject](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L966) | `int DestroyVideoEffectObject(IVideoEffectObject videoEffectObject)` | 源码 @ignore 标记 |
| [SetLowlightEnhanceOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L990) | `int SetLowlightEnhanceOptions(bool enabled, LowlightEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)` | — |
| [SetVideoDenoiserOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1014) | `int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)` | — |
| [SetColorEnhanceOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1041) | `int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)` | — |
| [EnableVirtualBackground](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1085) | `int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)` | — |
| [SetupRemoteVideo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1104) | `int SetupRemoteVideo(VideoCanvas canvas)` | — |
| [SetupLocalVideo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1122) | `int SetupLocalVideo(VideoCanvas canvas)` | — |
| [SetVideoScenario](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1156) | `int SetVideoScenario(VIDEO_APPLICATION_SCENARIO_TYPE scenarioType)` | — |
| [SetVideoQoEPreference](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1161) | `int SetVideoQoEPreference(VIDEO_QOE_PREFERENCE_TYPE qoePreference)` | 源码 @ignore 标记 |
| [EnableAudio](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1175) | `int EnableAudio()` | — |
| [DisableAudio](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1189) | `int DisableAudio()` | — |
| [SetAudioProfile](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1208) | `int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)` | — |
| [SetAudioProfile](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1224) | `int SetAudioProfile(AUDIO_PROFILE_TYPE profile)` | — |
| [SetAudioScenario](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1238) | `int SetAudioScenario(AUDIO_SCENARIO_TYPE scenario)` | — |
| [EnableLocalAudio](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1254) | `int EnableLocalAudio(bool enabled)` | — |
| [MuteLocalAudioStream](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1270) | `int MuteLocalAudioStream(bool mute)` | — |
| [MuteAllRemoteAudioStreams](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1286) | `int MuteAllRemoteAudioStreams(bool mute)` | — |
| [MuteRemoteAudioStream](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1302) | `int MuteRemoteAudioStream(uint uid, bool mute)` | — |
| [MuteLocalVideoStream](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1318) | `int MuteLocalVideoStream(bool mute)` | — |
| [EnableLocalVideo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1336) | `int EnableLocalVideo(bool enabled)` | — |
| [MuteAllRemoteVideoStreams](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1352) | `int MuteAllRemoteVideoStreams(bool mute)` | — |
| [SetRemoteDefaultVideoStreamType](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1371) | `int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType)` | — |
| [MuteRemoteVideoStream](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1387) | `int MuteRemoteVideoStream(uint uid, bool mute)` | — |
| [SetRemoteVideoStreamType](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1410) | `int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType)` | — |
| [SetRemoteVideoSubscriptionOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1431) | `int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)` | — |
| [SetSubscribeAudioBlocklist](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1453) | `int SetSubscribeAudioBlocklist(uint[] uidList, int uidNumber)` | — |
| [SetSubscribeAudioAllowlist](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1475) | `int SetSubscribeAudioAllowlist(uint[] uidList, int uidNumber)` | — |
| [SetSubscribeVideoBlocklist](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1497) | `int SetSubscribeVideoBlocklist(uint[] uidList, int uidNumber)` | — |
| [SetSubscribeVideoAllowlist](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1519) | `int SetSubscribeVideoAllowlist(uint[] uidList, int uidNumber)` | — |
| [EnableAudioVolumeIndication](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1543) | `int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)` | — |
| [StartAudioRecording](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1561) | `int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)` | — |
| [StartAudioRecording](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1592) | `int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality)` | — |
| [StartAudioRecording](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1610) | `int StartAudioRecording(AudioRecordingConfiguration config)` | — |
| [RegisterAudioEncodedFrameObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1629) | `int RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer)` | — |
| [StopAudioRecording](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1641) | `int StopAudioRecording()` | — |
| [CreateMediaPlayer](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1655) | `IMediaPlayer CreateMediaPlayer()` | — |
| [DestroyMediaPlayer](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1669) | `int DestroyMediaPlayer(IMediaPlayer media_player)` | — |
| [CreateMediaRecorder](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1674) | `IMediaRecorder CreateMediaRecorder(RecorderStreamInfo info)` | 源码 @ignore 标记 |
| [DestroyMediaRecorder](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1679) | `int DestroyMediaRecorder(IMediaRecorder mediaRecorder)` | 源码 @ignore 标记 |
| [StartAudioMixing](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1709) | `int StartAudioMixing(string filePath, bool loopback, int cycle)` | — |
| [StartAudioMixing](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1746) | `int StartAudioMixing(string filePath, bool loopback, int cycle, int startPos)` | — |
| [StopAudioMixing](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1760) | `int StopAudioMixing()` | — |
| [PauseAudioMixing](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1774) | `int PauseAudioMixing()` | — |
| [ResumeAudioMixing](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1788) | `int ResumeAudioMixing()` | — |
| [SelectAudioTrack](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1806) | `int SelectAudioTrack(int index)` | — |
| [GetAudioTrackCount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1820) | `int GetAudioTrackCount()` | — |
| [AdjustAudioMixingVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1836) | `int AdjustAudioMixingVolume(int volume)` | — |
| [AdjustAudioMixingPublishVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1852) | `int AdjustAudioMixingPublishVolume(int volume)` | — |
| [GetAudioMixingPublishVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1866) | `int GetAudioMixingPublishVolume()` | — |
| [AdjustAudioMixingPlayoutVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1880) | `int AdjustAudioMixingPlayoutVolume(int volume)` | — |
| [GetAudioMixingPlayoutVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1894) | `int GetAudioMixingPlayoutVolume()` | — |
| [GetAudioMixingDuration](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1908) | `int GetAudioMixingDuration()` | — |
| [GetAudioMixingCurrentPosition](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1923) | `int GetAudioMixingCurrentPosition()` | — |
| [SetAudioMixingPosition](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1939) | `int SetAudioMixingPosition(int pos)` | — |
| [SetAudioMixingDualMonoMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1955) | `int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode)` | — |
| [SetAudioMixingPitch](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1971) | `int SetAudioMixingPitch(int pitch)` | — |
| [SetAudioMixingPlaybackSpeed](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L1992) | `int SetAudioMixingPlaybackSpeed(int speed)` | — |
| [GetEffectsVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2006) | `int GetEffectsVolume()` | — |
| [SetEffectsVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2020) | `int SetEffectsVolume(int volume)` | — |
| [PreloadEffect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2045) | `int PreloadEffect(int soundId, string filePath, int startPos = 0)` | — |
| [PlayEffect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2050) | `int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0)` | 源码 @ignore 标记 |
| [PlayAllEffects](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2084) | `int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false)` | — |
| [GetVolumeOfEffect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2098) | `int GetVolumeOfEffect(int soundId)` | — |
| [SetVolumeOfEffect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2114) | `int SetVolumeOfEffect(int soundId, int volume)` | — |
| [PauseEffect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2128) | `int PauseEffect(int soundId)` | — |
| [PauseAllEffects](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2140) | `int PauseAllEffects()` | — |
| [ResumeEffect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2154) | `int ResumeEffect(int soundId)` | — |
| [ResumeAllEffects](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2168) | `int ResumeAllEffects()` | — |
| [StopEffect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2184) | `int StopEffect(int soundId)` | — |
| [StopAllEffects](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2198) | `int StopAllEffects()` | — |
| [UnloadEffect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2214) | `int UnloadEffect(int soundId)` | — |
| [UnloadAllEffects](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2226) | `int UnloadAllEffects()` | — |
| [GetEffectDuration](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2247) | `int GetEffectDuration(string filePath)` | — |
| [SetEffectPosition](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2265) | `int SetEffectPosition(int soundId, int pos)` | — |
| [GetEffectCurrentPosition](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2281) | `int GetEffectCurrentPosition(int soundId)` | — |
| [EnableSoundPositionIndication](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2297) | `int EnableSoundPositionIndication(bool enabled)` | — |
| [SetRemoteVoicePosition](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2325) | `int SetRemoteVoicePosition(uint uid, double pan, double gain)` | — |
| [EnableSpatialAudio](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2343) | `int EnableSpatialAudio(bool enabled)` | — |
| [SetRemoteUserSpatialAudioParams](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2361) | `int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams @params)` | — |
| [SetVoiceBeautifierPreset](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2377) | `int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)` | — |
| [SetAudioEffectPreset](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2393) | `int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)` | — |
| [SetVoiceConversionPreset](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2409) | `int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset)` | — |
| [SetAudioEffectParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2448) | `int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)` | — |
| [SetVoiceBeautifierParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2475) | `int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2)` | — |
| [SetVoiceConversionParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2480) | `int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2)` | 源码 @ignore 标记 |
| [SetLocalVoicePitch](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2494) | `int SetLocalVoicePitch(double pitch)` | — |
| [SetLocalVoiceFormant](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2510) | `int SetLocalVoiceFormant(double formantRatio)` | — |
| [SetLocalVoiceEqualization](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2526) | `int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain)` | — |
| [SetLocalVoiceReverb](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2544) | `int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)` | — |
| [SetHeadphoneEQPreset](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2561) | `int SetHeadphoneEQPreset(HEADPHONE_EQUALIZER_PRESET preset)` | — |
| [SetHeadphoneEQParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2580) | `int SetHeadphoneEQParameters(int lowGain, int highGain)` | — |
| [EnableVoiceAITuner](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2598) | `int EnableVoiceAITuner(bool enabled, VOICE_AI_TUNER_TYPE type)` | — |
| [SetLogFile](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2614) | `int SetLogFile(string filePath)` | 源码含废弃说明 |
| [SetLogFilter](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2630) | `int SetLogFilter(uint filter)` | 源码含废弃说明 |
| [SetLogLevel](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2646) | `int SetLogLevel(LOG_LEVEL level)` | 源码含废弃说明 |
| [SetLogFileSize](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2673) | `int SetLogFileSize(uint fileSizeInKBytes)` | 源码含废弃说明 |
| [UploadLogFile](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2678) | `int UploadLogFile(ref string requestId)` | 源码 @ignore 标记 |
| [WriteLog](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2683) | `int WriteLog(LOG_LEVEL level, string fmt)` | 源码 @ignore 标记 |
| [SetLocalRenderMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2699) | `int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)` | 源码含废弃说明 |
| [SetRemoteRenderMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2720) | `int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)` | — |
| [SetLocalRenderTargetFps](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2736) | `int SetLocalRenderTargetFps(VIDEO_SOURCE_TYPE sourceType, int targetFps)` | — |
| [SetRemoteRenderTargetFps](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2750) | `int SetRemoteRenderTargetFps(int targetFps)` | — |
| [SetLocalRenderMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2755) | `int SetLocalRenderMode(RENDER_MODE_TYPE renderMode)` | 源码 @ignore 标记 |
| [SetLocalVideoMirrorMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2771) | `int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)` | 源码含废弃说明 |
| [EnableDualStreamMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2791) | `int EnableDualStreamMode(bool enabled)` | 源码含废弃说明 |
| [EnableDualStreamMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2814) | `int EnableDualStreamMode(bool enabled, SimulcastStreamConfig streamConfig)` | 源码含废弃说明 |
| [SetDualStreamMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2835) | `int SetDualStreamMode(SIMULCAST_STREAM_MODE mode)` | — |
| [SetSimulcastConfig](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2840) | `int SetSimulcastConfig(SimulcastConfig simulcastConfig)` | 源码 @ignore 标记 |
| [SetDualStreamMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2863) | `int SetDualStreamMode(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig)` | — |
| [EnableCustomAudioLocalPlayback](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2881) | `int EnableCustomAudioLocalPlayback(uint trackId, bool enabled)` | — |
| [SetRecordingAudioFrameParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2907) | `int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)` | — |
| [SetPlaybackAudioFrameParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2933) | `int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)` | — |
| [SetMixedAudioFrameParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2957) | `int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall)` | — |
| [SetEarMonitoringAudioFrameParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L2985) | `int SetEarMonitoringAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)` | — |
| [SetPlaybackAudioFrameBeforeMixingParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3007) | `int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel)` | — |
| [SetPlaybackAudioFrameBeforeMixingParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3012) | `int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel, int samplesPerCall)` | 源码 @ignore 标记 |
| [EnableAudioSpectrumMonitor](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3029) | `int EnableAudioSpectrumMonitor(int intervalInMS = 100)` | — |
| [DisableAudioSpectrumMonitor](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3043) | `int DisableAudioSpectrumMonitor()` | — |
| [RegisterAudioSpectrumObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3059) | `int RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer)` | — |
| [UnregisterAudioSpectrumObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3073) | `int UnregisterAudioSpectrumObserver()` | — |
| [AdjustRecordingSignalVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3094) | `int AdjustRecordingSignalVolume(int volume)` | — |
| [MuteRecordingSignal](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3112) | `int MuteRecordingSignal(bool mute)` | — |
| [AdjustPlaybackSignalVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3133) | `int AdjustPlaybackSignalVolume(int volume)` | — |
| [AdjustUserPlaybackSignalVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3156) | `int AdjustUserPlaybackSignalVolume(uint uid, int volume)` | — |
| [SetLocalPublishFallbackOption](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3161) | `int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)` | 源码 @ignore 标记 |
| [SetRemoteSubscribeFallbackOption](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3177) | `int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)` | — |
| [SetHighPriorityUserList](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3182) | `int SetHighPriorityUserList(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option)` | 源码 @ignore 标记 |
| [EnableExtension](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3187) | `int EnableExtension(string provider, string extension, ExtensionInfo extensionInfo, bool enable = true)` | 源码 @ignore 标记 |
| [SetExtensionProperty](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3192) | `int SetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, string value)` | 源码 @ignore 标记 |
| [GetExtensionProperty](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3197) | `int GetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, ref string value, int buf_len)` | 源码 @ignore 标记 |
| [EnableLoopbackRecording](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3222) | `int EnableLoopbackRecording(bool enabled, string deviceName = "")` | — |
| [AdjustLoopbackSignalVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3238) | `int AdjustLoopbackSignalVolume(int volume)` | — |
| [GetLoopbackRecordingVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3243) | `int GetLoopbackRecordingVolume()` | 源码 @ignore 标记 |
| [EnableInEarMonitoring](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3248) | `int EnableInEarMonitoring(bool enabled, int includeAudioFilters)` | 源码 @ignore 标记 |
| [SetInEarMonitoringVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3268) | `int SetInEarMonitoringVolume(int volume)` | — |
| [LoadExtensionProvider](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3286) | `int LoadExtensionProvider(string path, bool unload_after_use = false)` | — |
| [SetExtensionProviderProperty](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3306) | `int SetExtensionProviderProperty(string provider, string key, string value)` | — |
| [RegisterExtension](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3327) | `int RegisterExtension(string provider, string extension, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)` | — |
| [EnableExtension](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3348) | `int EnableExtension(string provider, string extension, bool enable = true, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)` | — |
| [SetExtensionProperty](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3372) | `int SetExtensionProperty(string provider, string extension, string key, string value, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)` | — |
| [GetExtensionProperty](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3396) | `int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)` | — |
| [SetCameraCapturerConfiguration](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3410) | `int SetCameraCapturerConfiguration(CameraCapturerConfiguration config)` | — |
| [CreateCustomVideoTrack](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3427) | `uint CreateCustomVideoTrack()` | — |
| [CreateCustomEncodedVideoTrack](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3432) | `uint CreateCustomEncodedVideoTrack(SenderOptions sender_option)` | 源码 @ignore 标记 |
| [DestroyCustomVideoTrack](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3446) | `int DestroyCustomVideoTrack(uint video_track_id)` | — |
| [DestroyCustomEncodedVideoTrack](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3451) | `int DestroyCustomEncodedVideoTrack(uint video_track_id)` | 源码 @ignore 标记 |
| [SwitchCamera](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3465) | `int SwitchCamera()` | — |
| [IsCameraZoomSupported](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3478) | `bool IsCameraZoomSupported()` | — |
| [IsCameraFaceDetectSupported](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3492) | `bool IsCameraFaceDetectSupported()` | — |
| [IsCameraTorchSupported](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3508) | `bool IsCameraTorchSupported()` | — |
| [IsCameraFocusSupported](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3522) | `bool IsCameraFocusSupported()` | — |
| [IsCameraAutoFocusFaceModeSupported](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3536) | `bool IsCameraAutoFocusFaceModeSupported()` | — |
| [SetCameraZoomFactor](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3554) | `int SetCameraZoomFactor(float factor)` | — |
| [EnableFaceDetection](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3570) | `int EnableFaceDetection(bool enabled)` | — |
| [GetCameraMaxZoomFactor](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3584) | `float GetCameraMaxZoomFactor()` | — |
| [SetCameraFocusPositionInPreview](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3604) | `int SetCameraFocusPositionInPreview(float positionX, float positionY)` | — |
| [SetCameraTorchOn](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3621) | `int SetCameraTorchOn(bool isOn)` | — |
| [SetCameraAutoFocusFaceModeEnabled](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3637) | `int SetCameraAutoFocusFaceModeEnabled(bool enabled)` | — |
| [IsCameraExposurePositionSupported](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3651) | `bool IsCameraExposurePositionSupported()` | — |
| [SetCameraExposurePosition](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3671) | `int SetCameraExposurePosition(float positionXinView, float positionYinView)` | — |
| [IsCameraExposureSupported](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3687) | `bool IsCameraExposureSupported()` | — |
| [SetCameraExposureFactor](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3707) | `int SetCameraExposureFactor(float factor)` | — |
| [IsCameraAutoExposureFaceModeSupported](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3721) | `bool IsCameraAutoExposureFaceModeSupported()` | — |
| [SetCameraAutoExposureFaceModeEnabled](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3738) | `int SetCameraAutoExposureFaceModeEnabled(bool enabled)` | — |
| [SetCameraStabilizationMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3754) | `int SetCameraStabilizationMode(CAMERA_STABILIZATION_MODE mode)` | — |
| [SetDefaultAudioRouteToSpeakerphone](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3774) | `int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker)` | — |
| [SetEnableSpeakerphone](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3790) | `int SetEnableSpeakerphone(bool speakerOn)` | — |
| [IsSpeakerphoneEnabled](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3803) | `bool IsSpeakerphoneEnabled()` | — |
| [SetRouteInCommunicationMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3828) | `int SetRouteInCommunicationMode(int route)` | — |
| [IsCameraCenterStageSupported](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3841) | `bool IsCameraCenterStageSupported()` | — |
| [EnableCameraCenterStage](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3857) | `int EnableCameraCenterStage(bool enabled)` | — |
| [GetScreenCaptureSources](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3876) | `ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen)` | — |
| [SetAudioSessionOperationRestriction](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3894) | `int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)` | — |
| [StartScreenCaptureByDisplayId](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3916) | `int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams)` | — |
| [StartScreenCaptureByScreenRect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3940) | `int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams)` | 源码含废弃说明 |
| [GetAudioDeviceInfo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3958) | `int GetAudioDeviceInfo(ref DeviceInfoMobile deviceInfo)` | — |
| [StartScreenCaptureByWindowId](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3980) | `int StartScreenCaptureByWindowId(long windowId, Rectangle regionRect, ScreenCaptureParameters captureParams)` | — |
| [SetScreenCaptureContentHint](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L3998) | `int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint)` | — |
| [UpdateScreenCaptureRegion](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4016) | `int UpdateScreenCaptureRegion(Rectangle regionRect)` | — |
| [UpdateScreenCaptureParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4035) | `int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)` | — |
| [StartScreenCapture](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4057) | `int StartScreenCapture(ScreenCaptureParameters2 captureParams)` | — |
| [StartScreenCaptureInApp](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4062) | `int StartScreenCaptureInApp(ScreenCaptureParameters2 captureParams)` | 源码 @ignore 标记 |
| [UpdateScreenCapture](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4084) | `int UpdateScreenCapture(ScreenCaptureParameters2 captureParams)` | — |
| [QueryScreenCaptureCapability](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4096) | `int QueryScreenCaptureCapability()` | — |
| [QueryCameraFocalLengthCapability](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4114) | `int QueryCameraFocalLengthCapability(ref FocalLengthInfo[] focalLengthInfos, ref int size)` | — |
| [SetExternalMediaProjection](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4130) | `int SetExternalMediaProjection(IntPtr mediaProjection)` | — |
| [SetScreenCaptureScenario](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4146) | `int SetScreenCaptureScenario(SCREEN_SCENARIO_TYPE screenScenario)` | — |
| [StopScreenCapture](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4158) | `int StopScreenCapture()` | — |
| [GetCallId](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4174) | `int GetCallId(ref string callId)` | — |
| [Rate](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4196) | `int Rate(string callId, int rating, string description)` | — |
| [Complain](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4217) | `int Complain(string callId, string description)` | — |
| [StartRtmpStreamWithoutTranscoding](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4238) | `int StartRtmpStreamWithoutTranscoding(string url)` | — |
| [StartRtmpStreamWithTranscoding](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4262) | `int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding)` | — |
| [UpdateRtmpTranscoding](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4278) | `int UpdateRtmpTranscoding(LiveTranscoding transcoding)` | — |
| [StartLocalVideoTranscoder](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4298) | `int StartLocalVideoTranscoder(LocalTranscoderConfiguration config)` | — |
| [UpdateLocalTranscoderConfiguration](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4314) | `int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config)` | — |
| [StopRtmpStream](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4330) | `int StopRtmpStream(string url)` | — |
| [StopLocalVideoTranscoder](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4344) | `int StopLocalVideoTranscoder()` | — |
| [StartLocalAudioMixer](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4363) | `int StartLocalAudioMixer(LocalAudioMixerConfiguration config)` | — |
| [UpdateLocalAudioMixerConfiguration](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4380) | `int UpdateLocalAudioMixerConfiguration(LocalAudioMixerConfiguration config)` | — |
| [StopLocalAudioMixer](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4395) | `int StopLocalAudioMixer()` | — |
| [StartCameraCapture](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4418) | `int StartCameraCapture(VIDEO_SOURCE_TYPE sourceType, CameraCapturerConfiguration config)` | — |
| [StopCameraCapture](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4434) | `int StopCameraCapture(VIDEO_SOURCE_TYPE sourceType)` | — |
| [SetCameraDeviceOrientation](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4454) | `int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)` | — |
| [SetScreenCaptureOrientation](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4459) | `int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)` | 源码 @ignore 标记 |
| [StartScreenCapture](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4477) | `int StartScreenCapture(VIDEO_SOURCE_TYPE sourceType, ScreenCaptureConfiguration config)` | — |
| [StopScreenCapture](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4493) | `int StopScreenCapture(VIDEO_SOURCE_TYPE sourceType)` | — |
| [GetConnectionState](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4504) | `CONNECTION_STATE_TYPE GetConnectionState()` | — |
| [SetRemoteUserPriority](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4509) | `int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)` | 源码 @ignore 标记 |
| [EnableEncryption](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4530) | `int EnableEncryption(bool enabled, EncryptionConfig config)` | — |
| [CreateDataStream](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4550) | `int CreateDataStream(ref int streamId, bool reliable, bool ordered)` | — |
| [CreateDataStream](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4568) | `int CreateDataStream(ref int streamId, DataStreamConfig config)` | — |
| [SendStreamMessage](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4592) | `int SendStreamMessage(int streamId, byte[] data, uint length)` | — |
| [AddVideoWatermark](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4611) | `int AddVideoWatermark(RtcImage watermark)` | 源码含废弃说明 |
| [AddVideoWatermark](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4637) | `int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)` | — |
| [ClearVideoWatermarks](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4649) | `int ClearVideoWatermarks()` | — |
| [PauseAudio](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4655) | `int PauseAudio()` | — |
| [ResumeAudio](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4661) | `int ResumeAudio()` | — |
| [EnableWebSdkInteroperability](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4678) | `int EnableWebSdkInteroperability(bool enabled)` | — |
| [SendCustomReportMessage](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4687) | `int SendCustomReportMessage(string id, string category, string @event, string label, int value)` | — |
| [RegisterMediaMetadataObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4706) | `int RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type)` | — |
| [UnregisterMediaMetadataObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4718) | `int UnregisterMediaMetadataObserver()` | — |
| [StartAudioFrameDump](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4723) | `int StartAudioFrameDump(string channel_id, uint uid, string location, string uuid, string passwd, long duration_ms, bool auto_upload)` | 源码 @ignore 标记 |
| [StopAudioFrameDump](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4728) | `int StopAudioFrameDump(string channel_id, uint uid, string location)` | 源码 @ignore 标记 |
| [SetAINSMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4752) | `int SetAINSMode(bool enabled, AUDIO_AINS_MODE mode)` | — |
| [RegisterLocalUserAccount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4781) | `int RegisterLocalUserAccount(string appId, string userAccount)` | — |
| [JoinChannelWithUserAccount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4826) | `int JoinChannelWithUserAccount(string token, string channelId, string userAccount)` | — |
| [JoinChannelWithUserAccount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4873) | `int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options)` | — |
| [GetUserInfoByUserAccount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4895) | `int GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo)` | — |
| [GetUserInfoByUid](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4917) | `int GetUserInfoByUid(uint uid, ref UserInfo userInfo)` | — |
| [StartOrUpdateChannelMediaRelay](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4942) | `int StartOrUpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)` | — |
| [StopChannelMediaRelay](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4957) | `int StopChannelMediaRelay()` | — |
| [PauseAllChannelMediaRelay](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4972) | `int PauseAllChannelMediaRelay()` | — |
| [ResumeAllChannelMediaRelay](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L4987) | `int ResumeAllChannelMediaRelay()` | — |
| [SetDirectCdnStreamingAudioConfiguration](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5001) | `int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile)` | — |
| [SetDirectCdnStreamingVideoConfiguration](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5017) | `int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config)` | — |
| [StartDirectCdnStreaming](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5035) | `int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options)` | — |
| [StopDirectCdnStreaming](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5047) | `int StopDirectCdnStreaming()` | — |
| [UpdateDirectCdnStreamingMediaOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5052) | `int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options)` | 源码 @ignore 标记 |
| [StartRhythmPlayer](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5074) | `int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config)` | — |
| [StopRhythmPlayer](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5088) | `int StopRhythmPlayer()` | — |
| [ConfigRhythmPlayer](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5106) | `int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config)` | — |
| [TakeSnapshot](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5130) | `int TakeSnapshot(uint uid, string filePath)` | — |
| [TakeSnapshot](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5148) | `int TakeSnapshot(uint uid, SnapshotConfig config)` | — |
| [EnableContentInspect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5166) | `int EnableContentInspect(bool enabled, ContentInspectConfig config)` | — |
| [AdjustCustomAudioPublishVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5184) | `int AdjustCustomAudioPublishVolume(uint trackId, int volume)` | — |
| [AdjustCustomAudioPlayoutVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5202) | `int AdjustCustomAudioPlayoutVolume(uint trackId, int volume)` | — |
| [SetCloudProxy](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5223) | `int SetCloudProxy(CLOUD_PROXY_TYPE proxyType)` | — |
| [SetLocalAccessPoint](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5228) | `int SetLocalAccessPoint(LocalAccessPointConfiguration config)` | 源码 @ignore 标记 |
| [SetAdvancedAudioOptions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5244) | `int SetAdvancedAudioOptions(AdvancedAudioOptions options, int sourceType = 0)` | — |
| [SetAVSyncSource](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5249) | `int SetAVSyncSource(string channelId, uint uid)` | 源码 @ignore 标记 |
| [EnableVideoImageSource](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5267) | `int EnableVideoImageSource(bool enable, ImageTrackOptions options)` | — |
| [GetCurrentMonotonicTimeInMs](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5281) | `long GetCurrentMonotonicTimeInMs()` | — |
| [EnableWirelessAccelerate](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5286) | `int EnableWirelessAccelerate(bool enabled)` | 源码 @ignore 标记 |
| [GetNetworkType](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5308) | `int GetNetworkType()` | — |
| [SetParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5324) | `int SetParameters(string parameters)` | — |
| [StartMediaRenderingTracing](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5341) | `int StartMediaRenderingTracing()` | — |
| [EnableInstantMediaRendering](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5356) | `int EnableInstantMediaRendering()` | — |
| [GetNtpWallTimeInMs](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5369) | `ulong GetNtpWallTimeInMs()` | — |
| [IsFeatureAvailableOnDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5384) | `bool IsFeatureAvailableOnDevice(FeatureType type)` | — |
| [SendAudioMetadata](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5389) | `int SendAudioMetadata(byte[] metadata, ulong length)` | 源码 @ignore 标记 |
| [QueryHDRCapability](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5394) | `int QueryHDRCapability(VIDEO_MODULE_TYPE videoModule, ref HDR_CAPABILITY capability)` | 源码 @ignore 标记 |
| [RegisterFaceInfoObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5412) | `int RegisterFaceInfoObserver(IFaceInfoObserver observer)` | — |
| [PushAudioFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5430) | `int PushAudioFrame(AudioFrame frame, uint trackId = 0)` | — |
| [PullAudioFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5446) | `int PullAudioFrame(AudioFrame frame)` | — |
| [SetExternalVideoSource](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5468) | `int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType, SenderOptions encodedVideoOption)` | — |
| [SetExternalRemoteEglContext](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5484) | `int SetExternalRemoteEglContext(IntPtr eglContext)` | — |
| [SetExternalAudioSource](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5490) | `int SetExternalAudioSource(bool enabled, int sampleRate, int channels, bool localPlayback = false, bool publish = true)` | — |
| [CreateCustomAudioTrack](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5511) | `uint CreateCustomAudioTrack(AUDIO_TRACK_TYPE trackType, AudioTrackConfig config)` | — |
| [DestroyCustomAudioTrack](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5525) | `int DestroyCustomAudioTrack(uint trackId)` | — |
| [SetExternalAudioSink](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5549) | `int SetExternalAudioSink(bool enabled, int sampleRate, int channels)` | — |
| [PushVideoFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5572) | `int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId = 0)` | — |
| [PushEncodedVideoImage](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5577) | `int PushEncodedVideoImage(byte[] imageBuffer, ulong length, EncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId = 0)` | 源码 @ignore 标记 |
| [EnableAudioTrackVolumeIndication](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5582) | `int EnableAudioTrackVolumeIndication(uint id, int interval)` | 源码 @ignore 标记 |
| [CreateLoopbackAudioTrack](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5587) | `uint CreateLoopbackAudioTrack(LoopbackAudioTrackConfig config)` | 源码 @ignore 标记 |
| [AdjustLoopbackAudioPublishVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5592) | `int AdjustLoopbackAudioPublishVolume(uint trackId, int volume)` | 源码 @ignore 标记 |
| [DestroyLoopbackAudioTrack](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5597) | `int DestroyLoopbackAudioTrack(uint trackId)` | 源码 @ignore 标记 |
| [RegisterAudioTrackObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5602) | `int RegisterAudioTrackObserver(uint id, IAudioTrackObserver observer)` | 源码 @ignore 标记 |
| [UnregisterAudioTrackObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs#L5607) | `int UnregisterAudioTrackObserver(uint id, IAudioTrackObserver observer)` | 源码 @ignore 标记 |

## IRtcEngineEventHandler

RTC 事件：频道、连接、媒体状态和统计回调。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnProxyConnected](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L39) | `void OnProxyConnected(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)` | — |
| [OnError](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L54) | `void OnError(int err, string msg)` | — |
| [OnLastmileProbeResult](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L67) | `void OnLastmileProbeResult(LastmileProbeResult result)` | — |
| [OnAudioDeviceStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L84) | `void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)` | — |
| [OnAudioMixingPositionChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L102) | `void OnAudioMixingPositionChanged(long position)` | — |
| [OnAudioMixingFinished](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L114) | `void OnAudioMixingFinished()` | — |
| [OnAudioEffectFinished](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L127) | `void OnAudioEffectFinished(int soundId)` | — |
| [OnVideoDeviceStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L144) | `void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)` | — |
| [OnUplinkNetworkInfoUpdated](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L157) | `void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info)` | — |
| [OnDownlinkNetworkInfoUpdated](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L164) | `void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info)` | 源码 @ignore 标记 |
| [OnLastmileQuality](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L177) | `void OnLastmileQuality(int quality)` | — |
| [OnFirstLocalVideoFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L196) | `void OnFirstLocalVideoFrame(VIDEO_SOURCE_TYPE source, int width, int height, int elapsed)` | — |
| [OnVideoBlackFrameDetected](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L203) | `void OnVideoBlackFrameDetected(VIDEO_SOURCE_TYPE source, int reason)` | 源码 @ignore 标记 |
| [OnLocalVideoEvent](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L210) | `void OnLocalVideoEvent(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_EVENT_TYPE @event)` | 源码 @ignore 标记 |
| [OnLocalVideoStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L227) | `void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_REASON reason)` | — |
| [OnCameraReady](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L239) | `void OnCameraReady()` | — |
| [OnCameraFocusAreaChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L258) | `void OnCameraFocusAreaChanged(int x, int y, int width, int height)` | — |
| [OnCameraExposureAreaChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L275) | `void OnCameraExposureAreaChanged(int x, int y, int width, int height)` | — |
| [OnFacePositionChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L302) | `void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle[] vecRectangle, int[] vecDistance, int numFaces)` | — |
| [OnVideoStopped](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L314) | `void OnVideoStopped()` | — |
| [OnAudioMixingStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L329) | `void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)` | — |
| [OnRhythmPlayerStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L344) | `void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_REASON reason)` | — |
| [OnContentInspectResult](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L351) | `void OnContentInspectResult(CONTENT_INSPECT_RESULT result)` | 源码 @ignore 标记 |
| [OnAudioDeviceVolumeChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L368) | `void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)` | — |
| [OnRtmpStreamingStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L385) | `void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_REASON reason)` | — |
| [OnRtmpStreamingEvent](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L398) | `void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)` | — |
| [OnTranscodingUpdated](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L409) | `void OnTranscodingUpdated()` | — |
| [OnAudioRoutingChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L422) | `void OnAudioRoutingChanged(int routing)` | — |
| [OnChannelMediaRelayStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L437) | `void OnChannelMediaRelayStateChanged(int state, int code)` | — |
| [OnLocalPublishFallbackToAudioOnly](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L444) | `void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)` | 源码 @ignore 标记 |
| [OnRemoteSubscribeFallbackToAudioOnly](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L461) | `void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)` | — |
| [OnPermissionError](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L474) | `void OnPermissionError(PERMISSION_TYPE permissionType)` | — |
| [OnLocalUserRegistered](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L489) | `void OnLocalUserRegistered(uint uid, string userAccount)` | — |
| [OnUserInfoUpdated](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L504) | `void OnUserInfoUpdated(uint uid, UserInfo info)` | — |
| [OnLocalVideoTranscoderError](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L519) | `void OnLocalVideoTranscoderError(TranscodingVideoStream stream, VIDEO_TRANSCODER_ERROR error)` | — |
| [OnAudioSubscribeStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L538) | `void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)` | — |
| [OnVideoSubscribeStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L557) | `void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)` | — |
| [OnAudioPublishStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L574) | `void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)` | — |
| [OnVideoPublishStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L593) | `void OnVideoPublishStateChanged(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)` | — |
| [OnExtensionEventWithContext](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L610) | `void OnExtensionEventWithContext(ExtensionContext context, string key, string value)` | — |
| [OnExtensionStartedWithContext](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L623) | `void OnExtensionStartedWithContext(ExtensionContext context)` | — |
| [OnExtensionStoppedWithContext](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L636) | `void OnExtensionStoppedWithContext(ExtensionContext context)` | — |
| [OnExtensionErrorWithContext](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L653) | `void OnExtensionErrorWithContext(ExtensionContext context, int error, string message)` | — |
| [OnJoinChannelSuccess](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L668) | `void OnJoinChannelSuccess(RtcConnection connection, int elapsed)` | — |
| [OnRejoinChannelSuccess](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L681) | `void OnRejoinChannelSuccess(RtcConnection connection, int elapsed)` | — |
| [OnAudioQuality](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L703) | `void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, ushort delay, ushort lost)` | — |
| [OnAudioVolumeIndication](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L729) | `void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)` | — |
| [OnLeaveChannel](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L744) | `void OnLeaveChannel(RtcConnection connection, RtcStats stats)` | — |
| [OnRtcStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L757) | `void OnRtcStats(RtcConnection connection, RtcStats stats)` | — |
| [OnNetworkQuality](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L776) | `void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)` | — |
| [OnIntraRequestReceived](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L783) | `void OnIntraRequestReceived(RtcConnection connection)` | 源码 @ignore 标记 |
| [OnFirstLocalVideoFramePublished](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L801) | `void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed)` | — |
| [OnFirstRemoteVideoDecoded](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L827) | `void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)` | — |
| [OnVideoSizeChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L848) | `void OnVideoSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation)` | — |
| [OnRemoteVideoStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L869) | `void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)` | — |
| [OnFirstRemoteVideoFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L890) | `void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)` | — |
| [OnUserJoined](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L908) | `void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)` | — |
| [OnUserOffline](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L927) | `void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)` | — |
| [OnUserMuteAudio](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L944) | `void OnUserMuteAudio(RtcConnection connection, uint remoteUid, bool muted)` | — |
| [OnUserMuteVideo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L961) | `void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted)` | — |
| [OnUserEnableVideo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L978) | `void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled)` | — |
| [OnUserEnableLocalVideo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L995) | `void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled)` | 源码含废弃说明 |
| [OnUserStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1002) | `void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state)` | 源码 @ignore 标记 |
| [OnLocalAudioStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1017) | `void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats)` | — |
| [OnRemoteAudioStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1032) | `void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)` | — |
| [OnLocalVideoStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1047) | `void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats)` | — |
| [OnRemoteVideoStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1062) | `void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)` | — |
| [OnConnectionLost](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1075) | `void OnConnectionLost(RtcConnection connection)` | — |
| [OnConnectionInterrupted](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1091) | `void OnConnectionInterrupted(RtcConnection connection)` | — |
| [OnConnectionBanned](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1104) | `void OnConnectionBanned(RtcConnection connection)` | 源码含废弃说明 |
| [OnStreamMessage](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1127) | `void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, ulong length, ulong sentTs)` | — |
| [OnStreamMessageError](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1150) | `void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)` | — |
| [OnRequestToken](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1167) | `void OnRequestToken(RtcConnection connection)` | — |
| [OnLicenseValidationFailure](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1174) | `void OnLicenseValidationFailure(RtcConnection connection, LICENSE_ERROR_TYPE reason)` | 源码 @ignore 标记 |
| [OnTokenPrivilegeWillExpire](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1193) | `void OnTokenPrivilegeWillExpire(RtcConnection connection, string token)` | — |
| [OnFirstLocalAudioFramePublished](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1212) | `void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed)` | — |
| [OnFirstRemoteAudioFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1230) | `void OnFirstRemoteAudioFrame(RtcConnection connection, uint userId, int elapsed)` | — |
| [OnFirstRemoteAudioDecoded](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1254) | `void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed)` | — |
| [OnLocalAudioStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1271) | `void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_REASON reason)` | — |
| [OnRemoteAudioStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1292) | `void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)` | — |
| [OnActiveSpeaker](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1309) | `void OnActiveSpeaker(RtcConnection connection, uint uid)` | — |
| [OnClientRoleChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1326) | `void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)` | — |
| [OnClientRoleChangeFailed](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1343) | `void OnClientRoleChangeFailed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)` | — |
| [OnRemoteAudioTransportStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1365) | `void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)` | — |
| [OnRemoteVideoTransportStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1387) | `void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)` | — |
| [OnConnectionStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1404) | `void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)` | — |
| [OnWlAccMessage](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1411) | `void OnWlAccMessage(RtcConnection connection, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)` | 源码 @ignore 标记 |
| [OnWlAccStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1418) | `void OnWlAccStats(RtcConnection connection, WlAccStats currentStats, WlAccStats averageStats)` | 源码 @ignore 标记 |
| [OnNetworkTypeChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1433) | `void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type)` | — |
| [OnEncryptionError](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1448) | `void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType)` | — |
| [OnUploadLogResult](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1455) | `void OnUploadLogResult(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason)` | 源码 @ignore 标记 |
| [OnUserAccountUpdated](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1462) | `void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string remoteUserAccount)` | 源码 @ignore 标记 |
| [OnSnapshotTaken](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1492) | `void OnSnapshotTaken(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode)` | — |
| [OnVideoRenderingTracingResult](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1511) | `void OnVideoRenderingTracingResult(RtcConnection connection, uint uid, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)` | — |
| [OnSetRtmFlagResult](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1518) | `void OnSetRtmFlagResult(RtcConnection connection, int code)` | 源码 @ignore 标记 |
| [OnTranscodedStreamLayoutInfo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1541) | `void OnTranscodedStreamLayoutInfo(RtcConnection connection, uint uid, int width, int height, int layoutCount, VideoLayout[] layoutlist)` | — |
| [OnAudioMetadataReceived](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1548) | `void OnAudioMetadataReceived(RtcConnection connection, uint uid, byte[] metadata, ulong length)` | 源码 @ignore 标记 |
| [OnMultipathStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1555) | `void OnMultipathStats(RtcConnection connection, MultipathStats stats)` | 源码 @ignore 标记 |
| [OnDirectCdnStreamingStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1572) | `void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_REASON reason, string message)` | — |
| [OnDirectCdnStreamingStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEventHandler.cs#L1585) | `void OnDirectCdnStreamingStats(DirectCdnStreamingStats stats)` | — |

## IRtcEngineEx

多频道扩展：显式传入 RtcConnection。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [SetParametersEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L23) | `int SetParametersEx(RtcConnection connection, string key, object value)` | 源码 @ignore 标记 |
| [JoinChannelEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L55) | `int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options)` | — |
| [LeaveChannelEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L73) | `int LeaveChannelEx(RtcConnection connection)` | — |
| [LeaveChannelEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L93) | `int LeaveChannelEx(RtcConnection connection, LeaveChannelOptions options)` | — |
| [LeaveChannelWithUserAccountEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L98) | `int LeaveChannelWithUserAccountEx(string channelId, string userAccount)` | 源码 @ignore 标记 |
| [LeaveChannelWithUserAccountEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L103) | `int LeaveChannelWithUserAccountEx(string channelId, string userAccount, LeaveChannelOptions options)` | 源码 @ignore 标记 |
| [UpdateChannelMediaOptionsEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L122) | `int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection)` | — |
| [SetVideoEncoderConfigurationEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L140) | `int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection)` | — |
| [SetupRemoteVideoEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L160) | `int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection)` | — |
| [MuteRemoteAudioStreamEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L178) | `int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection)` | — |
| [MuteRemoteVideoStreamEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L198) | `int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection)` | — |
| [SetRemoteVideoStreamTypeEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L223) | `int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection)` | — |
| [MuteLocalAudioStreamEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L241) | `int MuteLocalAudioStreamEx(bool mute, RtcConnection connection)` | — |
| [MuteLocalVideoStreamEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L260) | `int MuteLocalVideoStreamEx(bool mute, RtcConnection connection)` | — |
| [MuteAllRemoteAudioStreamsEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L280) | `int MuteAllRemoteAudioStreamsEx(bool mute, RtcConnection connection)` | — |
| [MuteAllRemoteVideoStreamsEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L298) | `int MuteAllRemoteVideoStreamsEx(bool mute, RtcConnection connection)` | — |
| [SetSubscribeAudioBlocklistEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L322) | `int SetSubscribeAudioBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection)` | — |
| [SetSubscribeAudioAllowlistEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L346) | `int SetSubscribeAudioAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection)` | — |
| [SetSubscribeVideoBlocklistEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L370) | `int SetSubscribeVideoBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection)` | — |
| [SetSubscribeVideoAllowlistEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L394) | `int SetSubscribeVideoAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection)` | — |
| [SetRemoteVideoSubscriptionOptionsEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L414) | `int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)` | — |
| [SetRemoteVoicePositionEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L443) | `int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection)` | — |
| [SetRemoteUserSpatialAudioParamsEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L448) | `int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams @params, RtcConnection connection)` | 源码 @ignore 标记 |
| [SetRemoteRenderModeEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L471) | `int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection)` | — |
| [EnableLoopbackRecordingEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L498) | `int EnableLoopbackRecordingEx(RtcConnection connection, bool enabled, string deviceName = "")` | — |
| [AdjustRecordingSignalVolumeEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L503) | `int AdjustRecordingSignalVolumeEx(int volume, RtcConnection connection)` | 源码 @ignore 标记 |
| [MuteRecordingSignalEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L508) | `int MuteRecordingSignalEx(bool mute, RtcConnection connection)` | 源码 @ignore 标记 |
| [AdjustUserPlaybackSignalVolumeEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L533) | `int AdjustUserPlaybackSignalVolumeEx(uint uid, int volume, RtcConnection connection)` | — |
| [GetConnectionStateEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L546) | `CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection)` | — |
| [EnableEncryptionEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L566) | `int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config)` | — |
| [CreateDataStreamEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L588) | `int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnection connection)` | 源码含废弃说明 |
| [CreateDataStreamEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L608) | `int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnection connection)` | — |
| [SendStreamMessageEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L636) | `int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection)` | — |
| [AddVideoWatermarkEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L664) | `int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection)` | — |
| [ClearVideoWatermarkEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L678) | `int ClearVideoWatermarkEx(RtcConnection connection)` | — |
| [SendCustomReportMessageEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L687) | `int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection)` | — |
| [EnableAudioVolumeIndicationEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L713) | `int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection)` | — |
| [StartRtmpStreamWithoutTranscodingEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L736) | `int StartRtmpStreamWithoutTranscodingEx(string url, RtcConnection connection)` | — |
| [StartRtmpStreamWithTranscodingEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L763) | `int StartRtmpStreamWithTranscodingEx(string url, LiveTranscoding transcoding, RtcConnection connection)` | — |
| [UpdateRtmpTranscodingEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L781) | `int UpdateRtmpTranscodingEx(LiveTranscoding transcoding, RtcConnection connection)` | — |
| [StopRtmpStreamEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L797) | `int StopRtmpStreamEx(string url, RtcConnection connection)` | — |
| [StartOrUpdateChannelMediaRelayEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L824) | `int StartOrUpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection)` | — |
| [StopChannelMediaRelayEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L841) | `int StopChannelMediaRelayEx(RtcConnection connection)` | — |
| [PauseAllChannelMediaRelayEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L858) | `int PauseAllChannelMediaRelayEx(RtcConnection connection)` | — |
| [ResumeAllChannelMediaRelayEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L875) | `int ResumeAllChannelMediaRelayEx(RtcConnection connection)` | — |
| [GetUserInfoByUserAccountEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L880) | `int GetUserInfoByUserAccountEx(string userAccount, ref UserInfo userInfo, RtcConnection connection)` | 源码 @ignore 标记 |
| [GetUserInfoByUidEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L885) | `int GetUserInfoByUidEx(uint uid, ref UserInfo userInfo, RtcConnection connection)` | 源码 @ignore 标记 |
| [EnableDualStreamModeEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L908) | `int EnableDualStreamModeEx(bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection)` | — |
| [SetDualStreamModeEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L933) | `int SetDualStreamModeEx(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection)` | — |
| [SetSimulcastConfigEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L938) | `int SetSimulcastConfigEx(SimulcastConfig simulcastConfig, RtcConnection connection)` | 源码 @ignore 标记 |
| [SetHighPriorityUserListEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L943) | `int SetHighPriorityUserListEx(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option, RtcConnection connection)` | 源码 @ignore 标记 |
| [TakeSnapshotEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L969) | `int TakeSnapshotEx(RtcConnection connection, uint uid, string filePath)` | — |
| [TakeSnapshotEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L989) | `int TakeSnapshotEx(RtcConnection connection, uint uid, SnapshotConfig config)` | — |
| [EnableContentInspectEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L1009) | `int EnableContentInspectEx(bool enabled, ContentInspectConfig config, RtcConnection connection)` | — |
| [StartMediaRenderingTracingEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L1026) | `int StartMediaRenderingTracingEx(RtcConnection connection)` | — |
| [SetParametersEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L1031) | `int SetParametersEx(RtcConnection connection, string parameters)` | 源码 @ignore 标记 |
| [GetCallIdEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L1049) | `int GetCallIdEx(ref string callId, RtcConnection connection)` | — |
| [SendAudioMetadataEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L1054) | `int SendAudioMetadataEx(RtcConnection connection, byte[] metadata, ulong length)` | 源码 @ignore 标记 |
| [EnableVideoImageSourceEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L1059) | `int EnableVideoImageSourceEx(bool enable, ImageTrackOptions options, RtcConnection connection)` | 源码 @ignore 标记 |
| [PreloadEffectEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L1064) | `int PreloadEffectEx(RtcConnection connection, int soundId, string filePath, int startPos = 0)` | 源码 @ignore 标记 |
| [PlayEffectEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngineEx.cs#L1069) | `int PlayEffectEx(RtcConnection connection, int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0)` | 源码 @ignore 标记 |

## IAudioDeviceManager

Windows 音频设备枚举、选择与测试。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [EnumeratePlaybackDevices](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L30) | `DeviceInfo[] EnumeratePlaybackDevices()` | — |
| [EnumerateRecordingDevices](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L44) | `DeviceInfo[] EnumerateRecordingDevices()` | — |
| [GetPlaybackDefaultDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L62) | `int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceName)` | — |
| [GetPlaybackDefaultDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L82) | `int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceTypeName, ref string deviceName)` | — |
| [GetRecordingDefaultDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L100) | `int GetRecordingDefaultDevice(ref string deviceId, ref string deviceName)` | — |
| [GetRecordingDefaultDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L120) | `int GetRecordingDefaultDevice(ref string deviceId, ref string deviceTypeName, ref string deviceName)` | — |
| [SetPlaybackDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L136) | `int SetPlaybackDevice(string deviceId)` | — |
| [GetPlaybackDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L152) | `int GetPlaybackDevice(ref string deviceId)` | — |
| [GetPlaybackDeviceInfo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L170) | `int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName)` | — |
| [GetPlaybackDeviceInfo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L190) | `int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName, ref string deviceTypeName)` | — |
| [SetPlaybackDeviceVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L206) | `int SetPlaybackDeviceVolume(int volume)` | — |
| [GetPlaybackDeviceVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L217) | `int GetPlaybackDeviceVolume(ref int volume)` | — |
| [SetRecordingDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L233) | `int SetRecordingDevice(string deviceId)` | — |
| [GetRecordingDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L249) | `int GetRecordingDevice(ref string deviceId)` | — |
| [GetRecordingDeviceInfo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L267) | `int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName)` | — |
| [GetRecordingDeviceInfo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L287) | `int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName, ref string deviceTypeName)` | — |
| [SetRecordingDeviceVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L303) | `int SetRecordingDeviceVolume(int volume)` | — |
| [GetRecordingDeviceVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L316) | `int GetRecordingDeviceVolume(ref int volume)` | — |
| [SetLoopbackDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L335) | `int SetLoopbackDevice(string deviceId)` | — |
| [GetLoopbackDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L351) | `int GetLoopbackDevice(ref string deviceId)` | — |
| [SetPlaybackDeviceMute](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L365) | `int SetPlaybackDeviceMute(bool mute)` | — |
| [GetPlaybackDeviceMute](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L376) | `int GetPlaybackDeviceMute(ref bool mute)` | — |
| [SetRecordingDeviceMute](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L390) | `int SetRecordingDeviceMute(bool mute)` | — |
| [GetRecordingDeviceMute](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L401) | `int GetRecordingDeviceMute(ref bool mute)` | — |
| [StartPlaybackDeviceTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L421) | `int StartPlaybackDeviceTest(string testAudioFilePath)` | — |
| [StopPlaybackDeviceTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L435) | `int StopPlaybackDeviceTest()` | — |
| [StartRecordingDeviceTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L452) | `int StartRecordingDeviceTest(int indicationInterval)` | — |
| [StopRecordingDeviceTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L466) | `int StopRecordingDeviceTest()` | — |
| [StartAudioDeviceLoopbackTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L487) | `int StartAudioDeviceLoopbackTest(int indicationInterval)` | — |
| [StopAudioDeviceLoopbackTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L504) | `int StopAudioDeviceLoopbackTest()` | — |
| [FollowSystemPlaybackDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L520) | `int FollowSystemPlaybackDevice(bool enable)` | — |
| [FollowSystemRecordingDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L536) | `int FollowSystemRecordingDevice(bool enable)` | — |
| [FollowSystemLoopbackDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioDeviceManager.cs#L552) | `int FollowSystemLoopbackDevice(bool enable)` | — |

## IAudioEncodedFrameObserver

编码后音频帧观察器。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnRecordAudioEncodedFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioEncodedFrameObserver.cs#L21) | `void OnRecordAudioEncodedFrame(IntPtr frameBuffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)` | 源码 @ignore 标记 |
| [OnPlaybackAudioEncodedFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioEncodedFrameObserver.cs#L28) | `void OnPlaybackAudioEncodedFrame(IntPtr frameBuffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)` | 源码 @ignore 标记 |
| [OnMixedAudioEncodedFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioEncodedFrameObserver.cs#L35) | `void OnMixedAudioEncodedFrame(IntPtr frameBuffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)` | 源码 @ignore 标记 |

## IAudioFrameObserver

原始音频帧观察器。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnPlaybackAudioFrameBeforeMixing](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioFrameObserver.cs#L33) | `bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame audioFrame)` | — |
| [OnRecordAudioFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioFrameObserver.cs#L53) | `bool OnRecordAudioFrame(string channelId, AudioFrame audioFrame)` | — |
| [OnPlaybackAudioFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioFrameObserver.cs#L73) | `bool OnPlaybackAudioFrame(string channelId, AudioFrame audioFrame)` | — |
| [OnMixedAudioFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioFrameObserver.cs#L93) | `bool OnMixedAudioFrame(string channelId, AudioFrame audioFrame)` | — |
| [OnEarMonitoringAudioFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioFrameObserver.cs#L111) | `bool OnEarMonitoringAudioFrame(AudioFrame audioFrame)` | — |
| [OnPlaybackAudioFrameBeforeMixing](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioFrameObserver.cs#L119) | `bool OnPlaybackAudioFrameBeforeMixing(string channelId, string userId, AudioFrame audioFrame)` | 源码 @ignore 标记 |

## IAudioPcmFrameSink

PCM 音频帧接收接口。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioPcmFrameSink.cs#L33) | `void OnFrame(AudioPcmFrame frame)` | — |

## IAudioSpectrumObserver

音频频谱观察器。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnLocalAudioSpectrum](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioSpectrumObserver.cs#L31) | `bool OnLocalAudioSpectrum(AudioSpectrumData data)` | — |
| [OnRemoteAudioSpectrum](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioSpectrumObserver.cs#L51) | `bool OnRemoteAudioSpectrum(UserAudioSpectrumInfo[] spectrums, uint spectrumNumber)` | — |

## IAudioTrackObserver

音频轨道观察器。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnAudioTrackVolumeIndication](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IAudioTrackObserver.cs#L19) | `void OnAudioTrackVolumeIndication(uint trackId, AudioTrackVolumeInfo volumeInfo)` | 源码 @ignore 标记 |

## IFaceInfoObserver

人脸信息观察器。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnFaceInfo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IFaceInfoObserver.cs#L42) | `bool OnFaceInfo(string outFaceInfo)` | — |

## IH265Transcoder

H.265 转码扩展。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [EnableTranscode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IH265Transcoder.cs#L19) | `int EnableTranscode(string token, string channel, uint uid)` | 源码 @ignore 标记 |
| [QueryChannel](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IH265Transcoder.cs#L24) | `int QueryChannel(string token, string channel, uint uid)` | 源码 @ignore 标记 |
| [TriggerTranscode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IH265Transcoder.cs#L29) | `int TriggerTranscode(string token, string channel, uint uid)` | 源码 @ignore 标记 |
| [RegisterTranscoderObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IH265Transcoder.cs#L34) | `int RegisterTranscoderObserver(IH265TranscoderObserver observer)` | 源码 @ignore 标记 |
| [UnregisterTranscoderObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IH265Transcoder.cs#L39) | `int UnregisterTranscoderObserver()` | 源码 @ignore 标记 |

## IH265TranscoderObserver

H.265 转码事件。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnEnableTranscode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IH265TranscoderObserver.cs#L19) | `void OnEnableTranscode(H265_TRANSCODE_RESULT result)` | 源码 @ignore 标记 |
| [OnQueryChannel](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IH265TranscoderObserver.cs#L24) | `void OnQueryChannel(H265_TRANSCODE_RESULT result, string originChannel, string transcodeChannel)` | 源码 @ignore 标记 |
| [OnTriggerTranscode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IH265TranscoderObserver.cs#L29) | `void OnTriggerTranscode(H265_TRANSCODE_RESULT result)` | 源码 @ignore 标记 |

## ILocalSpatialAudioEngine

本地空间音频。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [Dispose](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L23) | `void Dispose()` | 源码 @ignore 标记 |
| [Initialize](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L38) | `int Initialize()` | — |
| [UpdateRemotePosition](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L56) | `int UpdateRemotePosition(uint uid, RemoteVoicePositionInfo posInfo)` | — |
| [UpdateRemotePositionEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L61) | `int UpdateRemotePositionEx(uint uid, RemoteVoicePositionInfo posInfo, RtcConnection connection)` | 源码 @ignore 标记 |
| [RemoveRemotePosition](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L77) | `int RemoveRemotePosition(uint uid)` | — |
| [RemoveRemotePositionEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L82) | `int RemoveRemotePositionEx(uint uid, RtcConnection connection)` | 源码 @ignore 标记 |
| [ClearRemotePositionsEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L87) | `int ClearRemotePositionsEx(RtcConnection connection)` | 源码 @ignore 标记 |
| [UpdateSelfPositionEx](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L92) | `int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)` | 源码 @ignore 标记 |
| [SetMaxAudioRecvCount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L108) | `int SetMaxAudioRecvCount(int maxCount)` | — |
| [SetAudioRecvRange](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L124) | `int SetAudioRecvRange(float range)` | — |
| [SetDistanceUnit](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L140) | `int SetDistanceUnit(float unit)` | — |
| [UpdateSelfPosition](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L162) | `int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)` | — |
| [UpdatePlayerPositionInfo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L180) | `int UpdatePlayerPositionInfo(int playerId, RemoteVoicePositionInfo positionInfo)` | — |
| [SetParameters](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L185) | `int SetParameters(string @params)` | 源码 @ignore 标记 |
| [MuteLocalAudioStream](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L204) | `int MuteLocalAudioStream(bool mute)` | — |
| [MuteAllRemoteAudioStreams](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L223) | `int MuteAllRemoteAudioStreams(bool mute)` | — |
| [MuteRemoteAudioStream](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L242) | `int MuteRemoteAudioStream(uint uid, bool mute)` | — |
| [SetRemoteAudioAttenuation](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L270) | `int SetRemoteAudioAttenuation(uint uid, double attenuation, bool forceSet)` | — |
| [SetZones](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L291) | `int SetZones(SpatialAudioZone[] zones, uint zoneCount)` | — |
| [SetPlayerAttenuation](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L319) | `int SetPlayerAttenuation(int playerId, double attenuation, bool forceSet)` | — |
| [ClearRemotePositions](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/ILocalSpatialAudioEngine.cs#L333) | `int ClearRemotePositions()` | — |

## IMediaPlayer

媒体播放器控制。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [Dispose](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L23) | `void Dispose()` | — |
| [GetId](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L28) | `int GetId()` | 源码 @ignore 标记 |
| [InitEventHandler](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L37) | `int InitEventHandler(IMediaPlayerSourceObserver engineEventHandler)` | — |
| [Open](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L55) | `int Open(string url, long startPos)` | — |
| [OpenWithMediaSource](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L71) | `int OpenWithMediaSource(MediaSource source)` | — |
| [Play](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L83) | `int Play()` | — |
| [Pause](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L95) | `int Pause()` | — |
| [Stop](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L109) | `int Stop()` | — |
| [Resume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L121) | `int Resume()` | — |
| [Seek](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L138) | `int Seek(long newPos)` | — |
| [SetAudioPitch](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L154) | `int SetAudioPitch(int pitch)` | — |
| [GetDuration](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L168) | `int GetDuration(ref long duration)` | — |
| [GetPlayPosition](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L182) | `int GetPlayPosition(ref long pos)` | — |
| [GetStreamCount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L198) | `int GetStreamCount(ref long count)` | — |
| [GetStreamInfo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L214) | `int GetStreamInfo(long index, ref PlayerStreamInfo info)` | — |
| [SetLoopCount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L234) | `int SetLoopCount(int loopCount)` | — |
| [SetPlaybackSpeed](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L255) | `int SetPlaybackSpeed(int speed)` | — |
| [SelectAudioTrack](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L271) | `int SelectAudioTrack(int index)` | — |
| [SelectMultiAudioTrack](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L289) | `int SelectMultiAudioTrack(int playoutTrackIndex, int publishTrackIndex)` | — |
| [SetPlayerOption](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L307) | `int SetPlayerOption(string key, int value)` | — |
| [SetPlayerOption](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L325) | `int SetPlayerOption(string key, string value)` | — |
| [TakeScreenshot](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L330) | `int TakeScreenshot(string filename)` | 源码 @ignore 标记 |
| [SelectInternalSubtitle](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L335) | `int SelectInternalSubtitle(int index)` | 源码 @ignore 标记 |
| [SetExternalSubtitle](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L340) | `int SetExternalSubtitle(string url)` | 源码 @ignore 标记 |
| [GetState](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L351) | `MEDIA_PLAYER_STATE GetState()` | — |
| [Mute](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L365) | `int Mute(bool muted)` | — |
| [GetMute](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L379) | `int GetMute(ref bool muted)` | — |
| [AdjustPlayoutVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L397) | `int AdjustPlayoutVolume(int volume)` | — |
| [GetPlayoutVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L415) | `int GetPlayoutVolume(ref int volume)` | — |
| [AdjustPublishSignalVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L436) | `int AdjustPublishSignalVolume(int volume)` | — |
| [GetPublishSignalVolume](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L450) | `int GetPublishSignalVolume(ref int volume)` | — |
| [SetView](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L462) | `int SetView(view_t view)` | — |
| [SetRenderMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L476) | `int SetRenderMode(RENDER_MODE_TYPE renderMode)` | — |
| [RegisterAudioFrameObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L492) | `int RegisterAudioFrameObserver(IAudioPcmFrameSink observer)` | — |
| [RegisterAudioFrameObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L508) | `int RegisterAudioFrameObserver(IAudioPcmFrameSink observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)` | — |
| [UnregisterAudioFrameObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L520) | `int UnregisterAudioFrameObserver()` | — |
| [RegisterMediaPlayerAudioSpectrumObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L525) | `int RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS)` | 源码 @ignore 标记 |
| [UnregisterMediaPlayerAudioSpectrumObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L530) | `int UnregisterMediaPlayerAudioSpectrumObserver()` | 源码 @ignore 标记 |
| [SetAudioDualMonoMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L548) | `int SetAudioDualMonoMode(AUDIO_DUAL_MONO_MODE mode)` | — |
| [GetPlayerSdkVersion](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L554) | `string GetPlayerSdkVersion()` | — |
| [GetPlaySrc](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L565) | `string GetPlaySrc()` | — |
| [OpenWithAgoraCDNSrc](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L570) | `int OpenWithAgoraCDNSrc(string src, long startPos)` | 源码 @ignore 标记 |
| [GetAgoraCDNLineCount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L575) | `int GetAgoraCDNLineCount()` | 源码 @ignore 标记 |
| [SwitchAgoraCDNLineByIndex](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L580) | `int SwitchAgoraCDNLineByIndex(int index)` | 源码 @ignore 标记 |
| [GetCurrentAgoraCDNIndex](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L585) | `int GetCurrentAgoraCDNIndex()` | 源码 @ignore 标记 |
| [EnableAutoSwitchAgoraCDN](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L590) | `int EnableAutoSwitchAgoraCDN(bool enable)` | 源码 @ignore 标记 |
| [RenewAgoraCDNSrcToken](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L595) | `int RenewAgoraCDNSrcToken(string token, long ts)` | 源码 @ignore 标记 |
| [SwitchAgoraCDNSrc](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L600) | `int SwitchAgoraCDNSrc(string src, bool syncPts = false)` | 源码 @ignore 标记 |
| [SwitchSrc](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L625) | `int SwitchSrc(string src, bool syncPts = true)` | — |
| [PreloadSrc](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L645) | `int PreloadSrc(string src, long startPos)` | — |
| [PlayPreloadedSrc](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L661) | `int PlayPreloadedSrc(string src)` | — |
| [UnloadSrc](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L677) | `int UnloadSrc(string src)` | — |
| [SetSpatialAudioParams](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L693) | `int SetSpatialAudioParams(SpatialAudioParams @params)` | — |
| [SetSoundPositionParams](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L698) | `int SetSoundPositionParams(float pan, float gain)` | 源码 @ignore 标记 |
| [GetAudioBufferDelay](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayer.cs#L703) | `int GetAudioBufferDelay(ref int delayMs)` | 源码 @ignore 标记 |

## IMediaPlayerCacheManager

媒体播放器缓存管理。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [RemoveAllCaches](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCacheManager.cs#L30) | `int RemoveAllCaches()` | — |
| [RemoveOldCache](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCacheManager.cs#L44) | `int RemoveOldCache()` | — |
| [RemoveCacheByUri](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCacheManager.cs#L60) | `int RemoveCacheByUri(string uri)` | — |
| [SetCacheDir](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCacheManager.cs#L76) | `int SetCacheDir(string path)` | — |
| [SetMaxCacheFileCount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCacheManager.cs#L90) | `int SetMaxCacheFileCount(int count)` | — |
| [SetMaxCacheFileSize](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCacheManager.cs#L104) | `int SetMaxCacheFileSize(long cacheSize)` | — |
| [EnableAutoRemoveCache](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCacheManager.cs#L120) | `int EnableAutoRemoveCache(bool enable)` | — |
| [GetCacheDir](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCacheManager.cs#L138) | `int GetCacheDir(ref string path, int length)` | — |
| [GetMaxCacheFileCount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCacheManager.cs#L152) | `int GetMaxCacheFileCount()` | — |
| [GetMaxCacheFileSize](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCacheManager.cs#L166) | `long GetMaxCacheFileSize()` | — |
| [GetCacheFileCount](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCacheManager.cs#L178) | `int GetCacheFileCount()` | — |

## IMediaPlayerCustomDataProvider

媒体播放器自定义数据源。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnReadData](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCustomDataProvider.cs#L34) | `int OnReadData(IntPtr buffer, int bufferSize)` | — |
| [OnSeek](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerCustomDataProvider.cs#L62) | `long OnSeek(long offset, int whence)` | — |

## IMediaPlayerSourceObserver

媒体播放器状态回调。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnPlayerSourceStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L29) | `void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_REASON reason)` | — |
| [OnPositionChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L44) | `void OnPositionChanged(long positionMs, long timestampMs)` | — |
| [OnPlayerEvent](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L61) | `void OnPlayerEvent(MEDIA_PLAYER_EVENT eventCode, long elapsedTime, string message)` | — |
| [OnMetaData](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L76) | `void OnMetaData(byte[] data, int length)` | — |
| [OnPlayBufferUpdated](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L91) | `void OnPlayBufferUpdated(long playCachedBuffer)` | — |
| [OnPreloadEvent](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L104) | `void OnPreloadEvent(string src, PLAYER_PRELOAD_EVENT @event)` | — |
| [OnCompleted](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L111) | `void OnCompleted()` | 源码 @ignore 标记 |
| [OnAgoraCDNTokenWillExpire](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L118) | `void OnAgoraCDNTokenWillExpire()` | 源码 @ignore 标记 |
| [OnPlayerSrcInfoChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L131) | `void OnPlayerSrcInfoChanged(SrcInfo from, SrcInfo to)` | — |
| [OnPlayerInfoUpdated](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L144) | `void OnPlayerInfoUpdated(PlayerUpdatedInfo info)` | — |
| [OnPlayerCacheStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L157) | `void OnPlayerCacheStats(CacheStatistics stats)` | — |
| [OnPlayerPlaybackStats](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L170) | `void OnPlayerPlaybackStats(PlayerPlaybackStats stats)` | — |
| [OnAudioVolumeIndication](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaPlayerSourceObserver.cs#L183) | `void OnAudioVolumeIndication(int volume)` | — |

## IMediaRecorder

媒体录制控制。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [SetMediaRecorderObserver](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaRecorder.cs#L19) | `int SetMediaRecorderObserver(IMediaRecorderObserver callback)` | 源码 @ignore 标记 |
| [StartRecording](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaRecorder.cs#L24) | `int StartRecording(MediaRecorderConfiguration config)` | 源码 @ignore 标记 |
| [StopRecording](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaRecorder.cs#L29) | `int StopRecording()` | 源码 @ignore 标记 |

## IMediaRecorderObserver

媒体录制事件。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnRecorderStateChanged](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaRecorderObserver.cs#L19) | `void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderReasonCode reason)` | 源码 @ignore 标记 |
| [OnRecorderInfoUpdated](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMediaRecorderObserver.cs#L26) | `void OnRecorderInfoUpdated(string channelId, uint uid, RecorderInfo info)` | 源码 @ignore 标记 |

## IMetadataObserver

视频元数据观察器。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [GetMaxMetadataSize](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMetadataObserver.cs#L22) | `int GetMaxMetadataSize()` | — |
| [OnReadyToSendMetadata](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMetadataObserver.cs#L44) | `bool OnReadyToSendMetadata(ref Metadata metadata, VIDEO_SOURCE_TYPE source_type)` | — |
| [OnMetadataReceived](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMetadataObserver.cs#L57) | `void OnMetadataReceived(Metadata metadata)` | — |

## IMusicContentCenter

音乐内容中心扩展。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [Initialize](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L19) | `int Initialize(MusicContentCenterConfiguration configuration)` | 源码 @ignore 标记 |
| [RenewToken](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L24) | `int RenewToken(string token)` | 源码 @ignore 标记 |
| [RegisterEventHandler](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L29) | `int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler)` | 源码 @ignore 标记 |
| [UnregisterEventHandler](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L34) | `int UnregisterEventHandler()` | 源码 @ignore 标记 |
| [CreateMusicPlayer](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L39) | `IMusicPlayer CreateMusicPlayer()` | 源码 @ignore 标记 |
| [DestroyMusicPlayer](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L44) | `int DestroyMusicPlayer(IMusicPlayer music_player)` | 源码 @ignore 标记 |
| [GetMusicCharts](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L49) | `int GetMusicCharts(ref string requestId)` | 源码 @ignore 标记 |
| [GetMusicCollectionByMusicChartId](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L54) | `int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartId, int page, int pageSize, string jsonOption = "")` | 源码 @ignore 标记 |
| [SearchMusic](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L59) | `int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "")` | 源码 @ignore 标记 |
| [Preload](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L65) | `int Preload(long songCode, string jsonOption)` | — |
| [Preload](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L70) | `int Preload(ref string requestId, long songCode)` | 源码 @ignore 标记 |
| [RemoveCache](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L75) | `int RemoveCache(long songCode)` | 源码 @ignore 标记 |
| [GetCaches](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L80) | `int GetCaches(ref MusicCacheInfo[] cacheInfo, ref int cacheInfoSize)` | 源码 @ignore 标记 |
| [IsPreloaded](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L85) | `int IsPreloaded(long songCode)` | 源码 @ignore 标记 |
| [GetLyric](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L90) | `int GetLyric(ref string requestId, long songCode, int lyricType = 0)` | 源码 @ignore 标记 |
| [GetSongSimpleInfo](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L95) | `int GetSongSimpleInfo(ref string requestId, long songCode)` | 源码 @ignore 标记 |
| [GetInternalSongCode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenter.cs#L100) | `int GetInternalSongCode(long songCode, string jsonOption, ref long internalSongCode)` | 源码 @ignore 标记 |

## IMusicContentCenterEventHandler

音乐内容中心事件。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnMusicChartsResult](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenterEventHandler.cs#L19) | `void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStateReason reason)` | 源码 @ignore 标记 |
| [OnMusicCollectionResult](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenterEventHandler.cs#L24) | `void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStateReason reason)` | 源码 @ignore 标记 |
| [OnLyricResult](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenterEventHandler.cs#L29) | `void OnLyricResult(string requestId, long songCode, string lyricUrl, MusicContentCenterStateReason reason)` | 源码 @ignore 标记 |
| [OnSongSimpleInfoResult](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenterEventHandler.cs#L34) | `void OnSongSimpleInfoResult(string requestId, long songCode, string simpleInfo, MusicContentCenterStateReason reason)` | 源码 @ignore 标记 |
| [OnPreLoadEvent](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicContentCenterEventHandler.cs#L39) | `void OnPreLoadEvent(string requestId, long songCode, int percent, string lyricUrl, PreloadState state, MusicContentCenterStateReason reason)` | 源码 @ignore 标记 |

## IMusicPlayer

音乐播放器扩展。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [Open](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicPlayer.cs#L19) | `int Open(long songCode, long startPos = 0)` | 源码 @ignore 标记 |
| [SetPlayMode](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IMusicPlayer.cs#L24) | `int SetPlayMode(MusicPlayMode mode)` | 源码 @ignore 标记 |

## IVideoDeviceManager

Windows 摄像头枚举、能力与选择。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [EnumerateVideoDevices](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoDeviceManager.cs#L30) | `DeviceInfo[] EnumerateVideoDevices()` | — |
| [SetDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoDeviceManager.cs#L47) | `int SetDevice(string deviceIdUTF8)` | — |
| [GetDevice](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoDeviceManager.cs#L63) | `int GetDevice(ref string deviceIdUTF8)` | — |
| [NumberOfCapabilities](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoDeviceManager.cs#L79) | `int NumberOfCapabilities(string deviceIdUTF8)` | — |
| [GetCapability](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoDeviceManager.cs#L99) | `int GetCapability(string deviceIdUTF8, uint deviceCapabilityNumber, ref VideoFormat capability)` | — |
| [StartDeviceTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoDeviceManager.cs#L104) | `int StartDeviceTest(IntPtr hwnd)` | 源码 @ignore 标记 |
| [StopDeviceTest](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoDeviceManager.cs#L109) | `int StopDeviceTest()` | 源码 @ignore 标记 |

## IVideoEffectObject

视频效果对象。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [GetObjectId](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEffectObject.cs#L19) | `int GetObjectId()` | 源码 @ignore 标记 |
| [AddOrUpdateVideoEffect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEffectObject.cs#L24) | `int AddOrUpdateVideoEffect(uint nodeId, string templateName)` | 源码 @ignore 标记 |
| [RemoveVideoEffect](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEffectObject.cs#L29) | `int RemoveVideoEffect(uint nodeId)` | 源码 @ignore 标记 |
| [PerformVideoEffectAction](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEffectObject.cs#L34) | `int PerformVideoEffectAction(uint nodeId, VIDEO_EFFECT_ACTION actionId)` | 源码 @ignore 标记 |
| [SetVideoEffectStringParam](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEffectObject.cs#L39) | `int SetVideoEffectStringParam(string option, string key, string param)` | 源码 @ignore 标记 |
| [SetVideoEffectFloatParam](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEffectObject.cs#L44) | `int SetVideoEffectFloatParam(string option, string key, float param)` | 源码 @ignore 标记 |
| [SetVideoEffectIntParam](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEffectObject.cs#L49) | `int SetVideoEffectIntParam(string option, string key, int param)` | 源码 @ignore 标记 |
| [SetVideoEffectBoolParam](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEffectObject.cs#L54) | `int SetVideoEffectBoolParam(string option, string key, bool param)` | 源码 @ignore 标记 |
| [GetVideoEffectFloatParam](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEffectObject.cs#L59) | `float GetVideoEffectFloatParam(string option, string key)` | 源码 @ignore 标记 |
| [GetVideoEffectIntParam](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEffectObject.cs#L64) | `int GetVideoEffectIntParam(string option, string key)` | 源码 @ignore 标记 |
| [GetVideoEffectBoolParam](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEffectObject.cs#L69) | `bool GetVideoEffectBoolParam(string option, string key)` | 源码 @ignore 标记 |

## IVideoEncodedFrameObserver

编码后视频帧观察器。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnEncodedVideoFrameReceived](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoEncodedFrameObserver.cs#L37) | `bool OnEncodedVideoFrameReceived(uint uid, IntPtr imageBuffer, ulong length, EncodedVideoFrameInfo videoEncodedFrameInfo)` | — |

## IVideoFrameMetaInfo

视频帧元信息。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [GetMetaInfoStr](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoFrameMetaInfo.cs#L19) | `string GetMetaInfoStr(META_INFO_KEY key)` | 源码 @ignore 标记 |

## IVideoFrameObserver

原始视频帧观察器。

| 方法/回调 | C# 签名 | 标记 |
| --- | --- | --- |
| [OnCaptureVideoFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoFrameObserver.cs#L33) | `bool OnCaptureVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)` | — |
| [OnPreEncodeVideoFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoFrameObserver.cs#L56) | `bool OnPreEncodeVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)` | — |
| [OnMediaPlayerVideoFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoFrameObserver.cs#L64) | `bool OnMediaPlayerVideoFrame(VideoFrame videoFrame, int mediaPlayerId)` | 源码 @ignore 标记 |
| [OnRenderVideoFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoFrameObserver.cs#L86) | `bool OnRenderVideoFrame(string channelId, uint remoteUid, VideoFrame videoFrame)` | — |
| [OnTranscodedVideoFrame](../../../Agora-C_Sharp-RTC-SDK/Code/Rtc/IVideoFrameObserver.cs#L94) | `bool OnTranscodedVideoFrame(VideoFrame videoFrame)` | 源码 @ignore 标记 |
