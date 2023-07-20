using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Agora.Rtc
{
    using IrisRtcEnginePtr = IntPtr;
    using IrisEventHandlerMarshal = IntPtr;
    using IrisEventHandlerHandle = IntPtr;
    //using IrisRtcAudioFrameObserverHandle = IntPtr;
    //using IrisAudioEncodedFrameObserverHandle = IntPtr;
    //using IrisRtcVideoFrameObserverHandle = IntPtr;
    using IrisVideoFrameBufferManagerPtr = IntPtr;
    using IrisVideoFrameBufferDelegateHandle = IntPtr;
    //using IrisRtcVideoEncodedFrameObserverHandle = IntPtr;
    //using IrisMediaPlayerAudioFrameObserverHandle = IntPtr;
    //using IrisMediaPlayerAudioSpectrumObserverHandle = IntPtr;
    //using IrisMetaDataObserverHandle = IntPtr;
    //using IrisMediaPlayerCustomDataProviderHandle = IntPtr;
    //using IrisRtcAudioSpectrumObserverHandle = IntPtr;
    //using IrisRtcCAudioSpectrumObserver = IntPtr;


    internal enum IRIS_VIDEO_PROCESS_ERR
    {
        ERR_OK = 0,
        ERR_NULL_POINTER = 1,
        ERR_SIZE_NOT_MATCHING = 2,
        ERR_BUFFER_EMPTY = 5,
        ERR_FRAM_TYPE_NOT_MATCHING = 6
    };


    internal static class AgoraRtcNative
    {
        #region DllImport

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        private const string AgoraRtcLibName = "AgoraRtcWrapper";
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        private const string AgoraRtcLibName = "AgoraRtcWrapperUnity";
#elif UNITY_IPHONE
		private const string AgoraRtcLibName = "__Internal";
#else
        private const string AgoraRtcLibName = "AgoraRtcWrapper";
#endif

        // IrisRtcEngine
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcEnginePtr CreateIrisApiEngine(IntPtr engine);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisApiEngine(IrisRtcEnginePtr engine_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEventHandlerHandle CreateIrisEventHandler(IrisEventHandlerMarshal event_Handler);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisEventHandler(IrisEventHandlerHandle handle);

        internal static int CallIrisApiWithArgs(IrisRtcEnginePtr engine_ptr, string func_name,
            string @params, UInt32 paramLength, IntPtr buffer, uint buffer_count, ref IrisCApiParam apiParam,
            uint buffer0Length = 0, uint buffer1Length = 0, uint buffer2Length = 0)
        {
            apiParam.@event = func_name;
            apiParam.data = @params;
            apiParam.data_size = paramLength;
            apiParam.buffer = buffer;
            apiParam.buffer_count = buffer_count;

            IntPtr lengthPtr = IntPtr.Zero;
            if (buffer_count > 0)
            {
                int[] lengths = new int[3];
                lengths[0] = (int)buffer0Length;
                lengths[1] = (int)buffer1Length;
                lengths[2] = (int)buffer2Length;
                lengthPtr = Marshal.AllocHGlobal(lengths.Length * sizeof(int));
                Marshal.Copy(lengths, 0, lengthPtr, (int)lengths.Length);
            }
            apiParam.length = lengthPtr;
            int retval = CallIrisApi(engine_ptr, ref apiParam);

            if (lengthPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(lengthPtr);
            }

            return retval;
        }


        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisApi(IrisRtcEnginePtr engine_ptr, ref IrisCApiParam apiParam);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Attach(IrisRtcEnginePtr engine_ptr, IrisVideoFrameBufferManagerPtr manager_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Detach(IrisRtcEnginePtr engine_ptr, IrisVideoFrameBufferManagerPtr manager_ptr);


        // IrisVideoFrameBufferManager
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisVideoFrameBufferManagerPtr CreateIrisVideoFrameBufferManager();

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void
        FreeIrisVideoFrameBufferManager(IrisVideoFrameBufferManagerPtr manager_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisVideoFrameBufferDelegateHandle EnableVideoFrameBuffer(
            IrisVideoFrameBufferManagerPtr manager_ptr, ref IrisCVideoFrameBufferNative buffer,
            uint uid = 0, string channel_id = "");

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void
        DisableVideoFrameBufferByUid(IrisVideoFrameBufferManagerPtr manager_ptr,
                                    uint uid = 0, string channel_id = "");

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IRIS_VIDEO_PROCESS_ERR GetVideoFrame(IrisVideoFrameBufferManagerPtr manager_ptr,
                                    ref IrisVideoFrame video_frame, out bool is_new_frame,
                                    uint uid, string channel_id = "");

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisVideoFrameBufferDelegateHandle EnableVideoFrameBufferByConfig(
            IrisVideoFrameBufferManagerPtr manager_ptr, ref IrisCVideoFrameBufferNative buffer,
            ref IrisVideoFrameBufferConfig config);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DisableVideoFrameBufferByDelegate(
            IrisVideoFrameBufferManagerPtr manager_ptr,
            IrisVideoFrameBufferDelegateHandle handle);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void
        DisableVideoFrameBufferByConfig(IrisVideoFrameBufferManagerPtr manager_ptr,
                                    ref IrisVideoFrameBufferConfig config, IrisVideoFrameBufferDelegateHandle handle);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void
        DisableAllVideoFrameBuffer(IrisVideoFrameBufferManagerPtr manager_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IRIS_VIDEO_PROCESS_ERR GetVideoFrameByConfig(IrisVideoFrameBufferManagerPtr manager_ptr,
                                    ref IrisVideoFrame video_frame, out bool is_new_frame,
                                    ref IrisVideoFrameBufferConfig config);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool StartDumpVideo(IrisVideoFrameBufferManagerPtr manager_ptr, VIDEO_SOURCE_TYPE type, string dir);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool StopDumpVideo(IrisVideoFrameBufferManagerPtr manager_ptr);

        // Iris Media Base
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool AlignAndConvertVideoFrame(ref IrisVideoFrame dst, ref IrisVideoFrame src);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ClearVideoFrame(ref IrisVideoFrame video_frame);

        // IrisMediaPlayerPtr
        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern IrisEventHandlerHandle SetIrisMediaPlayerEventHandler(IrisRtcEnginePtr engine_ptr, IntPtr event_handler);

        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void UnsetIrisMediaPlayerEventHandler(IrisRtcEnginePtr engine_ptr, IrisEventHandlerHandle handle);

        // media player audio frame observer 
        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern IrisMediaPlayerAudioFrameObserverHandle
        //    RegisterMediaPlayerAudioFrameObserver(IrisRtcEnginePtr engine_ptr, IntPtr observer, string @params);

        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void UnRegisterMediaPlayerAudioFrameObserver(
        //    IrisRtcEnginePtr engine_ptr, IrisMediaPlayerAudioFrameObserverHandle handle, string @params);

        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern IrisMediaPlayerAudioSpectrumObserverHandle
        //    RegisterMediaPlayerAudioSpectrumObserver(IrisRtcEnginePtr engine_ptr, IntPtr observer, string @params);

        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void UnRegisterMediaPlayerAudioSpectrumObserver(
        //    IrisRtcEnginePtr engine_ptr, IrisMediaPlayerAudioSpectrumObserverHandle handle, string @params);


        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern IrisMediaPlayerCustomDataProviderHandle MediaPlayerOpenWithCustomSource(IrisRtcEnginePtr engine_ptr, IntPtr provider, string @params);

        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int MediaPlayerUnOpenWithCustomSource(IrisRtcEnginePtr engine_ptr,
        //                    IrisMediaPlayerCustomDataProviderHandle handle, string @params);

        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern IrisMediaPlayerCustomDataProviderHandle MediaPlayerOpenWithMediaSource(IrisRtcEnginePtr engine_ptr, IntPtr provider, string @params);

        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int MediaPlayerUnOpenWithMediaSource(IrisRtcEnginePtr engine_ptr,
        //                    IrisMediaPlayerCustomDataProviderHandle handle, string @params);


        //IrisCloudSpatialAudioEnginePtr
        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern IrisEventHandlerHandle SetIrisCloudAudioEngineEventHandler(IrisRtcEnginePtr engine_ptr, IntPtr event_handler);

        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void UnsetIrisCloudAudioEngineEventHandler(IrisRtcEnginePtr engine_ptr, IrisEventHandlerHandle handle);

        ////IrisMetaDataObserver
        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern IrisMetaDataObserverHandle RegisterMediaMetadataObserver(IrisRtcEnginePtr engine_ptr, IntPtr observer, string @params);

        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void UnRegisterMediaMetadataObserver(IrisRtcEnginePtr engine_ptr, IrisMetaDataObserverHandle handle, string @params);

        ////IrisMediaRecorderObserver
        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern IrisEventHandlerHandle SetIrisMediaRecorderEventHandler(IrisRtcEnginePtr engine_ptr, IntPtr event_handler);

        //[DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void UnsetIrisMediaRecorderEventHandler(IrisRtcEnginePtr engine_ptr, IrisEventHandlerHandle handle);

        #endregion

        #region iris_rtc_high_performance_c_api
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetMaxAudioRecvCount(IrisRtcEnginePtr enginePtr, int maxCount);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetAudioRecvRange(IrisRtcEnginePtr enginePtr, float range);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetDistanceUnit(IrisRtcEnginePtr enginePtr, float unit);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_UpdateSelfPosition(IrisRtcEnginePtr enginePtr,
          float positionX, float positionY, float positionZ, float axisForwardX,
          float axisForwardY, float axisForwardZ, float axisRightX, float axisRightY,
          float axisRightZ, float axisUpX, float axisUpY, float axisUpZ);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_UpdateSelfPositionEx(IrisRtcEnginePtr enginePtr,
          float positionX, float positionY, float positionZ, float axisForwardX,
          float axisForwardY, float axisForwardZ, float axisRightX, float axisRightY,
          float axisRightZ, float axisUpX, float axisUpY, float axisUpZ,
          string channelId, uint localUid);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_UpdatePlayerPositionInfo(IrisRtcEnginePtr enginePtr,
          int playerId, float positionX, float positionY, float positionZ,
          float forwardX, float forwardY, float forwardZ);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_MuteLocalAudioStream(IrisRtcEnginePtr enginePtr, bool mute);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_MuteAllRemoteAudioStreams(IrisRtcEnginePtr enginePtr, bool mute);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetZones(IrisRtcEnginePtr enginePtr, IrisSpatialAudioZone[] zones, uint zoneCount);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetPlayerAttenuation(IrisRtcEnginePtr enginePtr,
          int playerId, double attenuation, bool forceSet);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_MuteRemoteAudioStream(IrisRtcEnginePtr enginePtr, uint uid, bool mute);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_UpdateRemotePosition(IrisRtcEnginePtr engine_ptr,
          uint uid, float positionX, float positionY, float positionZ,
          float forwardX, float forwardY, float forwardZ);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_UpdateRemotePositionEx(IrisRtcEnginePtr enginePtr,
          uint uid, float positionX, float positionY, float positionZ,
          float forwardX, float forwardY, float forwardZ, string channelId,
          uint localUid);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_RemoveRemotePosition(IrisRtcEnginePtr enginePtr, uint uid);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_RemoveRemotePositionEx(IrisRtcEnginePtr enginePtr,
          uint uid, string channelId, uint localUid);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_ClearRemotePositions(IrisRtcEnginePtr enginePtr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_ClearRemotePositionsEx(IrisRtcEnginePtr enginePtr,
           string channelId, uint localUid);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetRemoteAudioAttenuation(IrisRtcEnginePtr enginePtr,
          uint uid, double attenuation, bool forceSet);

        #endregion

    }


 

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCVideoFrameBufferNative
    {
        internal int type;
        internal IntPtr OnVideoFrameReceived;
        internal int bytes_per_row_alignment;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct IrisSpatialAudioZone
    {
        public int zoneSetId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] position;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] forward;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] right;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] up;
        public float forwardLength;
        public float rightLength;
        public float upLength;
        public float audioAttenuation;

        public IrisSpatialAudioZone(SpatialAudioZone zone)
        {
            this.zoneSetId = zone.zoneSetId;
            this.position = zone.position;
            this.forward = zone.forward;
            this.right = zone.right;
            this.up = zone.up;
            this.forwardLength = zone.forwardLength;
            this.rightLength = zone.rightLength;
            this.upLength = zone.upLength;
            this.audioAttenuation = zone.audioAttenuation;
        }
    };
}