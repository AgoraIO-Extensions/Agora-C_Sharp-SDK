using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Agora.Rtc
{
    using IrisRtcEnginePtr = IntPtr;
    using RtcEngineHandle = IntPtr;
    using IrisEventHandlerMarshal = IntPtr;
    using IrisEventHandlerHandle = IntPtr;
    //using IrisRtcAudioFrameObserverHandle = IntPtr;
    //using IrisAudioEncodedFrameObserverHandle = IntPtr;
    //using IrisRtcVideoFrameObserverHandle = IntPtr;
    using IrisRtcRenderingHandle = IntPtr;
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
        ERR_RESIZED = 1,
        ERR_NO_CACHE = 2,
        ERR_NULL_POINTER = 3,
    };


    internal static class AgoraRtcNative
    {
        #region DllImport

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        public const string AgoraRtcLibName = "AgoraRtcWrapper";
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        public const string AgoraRtcLibName = "AgoraRtcWrapperUnity";
#elif UNITY_IPHONE || UNITY_VISIONOS
		public const string AgoraRtcLibName = "__Internal";
#else
        public const string AgoraRtcLibName = "AgoraRtcWrapper";
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
            string @params, UInt32 paramLength, IntPtr buffer, uint buffer_count, ref IrisRtcCApiParam apiParam,
            uint buffer0Length = 0, uint buffer1Length = 0, uint buffer2Length = 0, uint buffer3Length = 0)
        {
            apiParam.@event = func_name;
            apiParam.data = @params;
            apiParam.data_size = paramLength;
            apiParam.buffer = buffer;
            apiParam.buffer_count = buffer_count;

            IntPtr lengthPtr = IntPtr.Zero;
            if (buffer_count > 0)
            {
                int[] lengths = new int[4];
                lengths[0] = (int)buffer0Length;
                lengths[1] = (int)buffer1Length;
                lengths[2] = (int)buffer2Length;
                lengths[3] = (int)buffer3Length;
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
        internal static extern int CallIrisApi(IrisRtcEnginePtr engine_ptr, ref IrisRtcCApiParam apiParam);

        // IrisVideoFrameBufferManager
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcRenderingHandle CreateIrisRtcRendering(IrisRtcEnginePtr iris_api_engine_handle);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FreeIrisRtcRendering(IrisRtcRenderingHandle handle);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void AddVideoFrameCacheKey(IrisRtcRenderingHandle handle, ref IrisRtcVideoFrameConfig config);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void RemoveVideoFrameCacheKey(IrisRtcRenderingHandle handle, ref IrisRtcVideoFrameConfig config);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IRIS_VIDEO_PROCESS_ERR GetVideoFrameCache(IrisRtcRenderingHandle manager_ptr,
                                    ref IrisRtcVideoFrameConfig config,
                                    ref IrisCVideoFrame video_frame, out bool is_new_frame
                                 );

        internal static void AllocEventHandlerHandle(ref RtcEventHandlerHandle eventHandlerHandle, Rtc_Func_Event_Native onEvent)
        {
            eventHandlerHandle.cEvent = new IrisRtcCEventHandler
            {
                OnEvent = onEvent,
            };

            var cEventHandlerNativeLocal = new IrisRtcCEventHandlerNative
            {
                onEvent = Marshal.GetFunctionPointerForDelegate(eventHandlerHandle.cEvent.OnEvent),
            };

            eventHandlerHandle.marshal = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
            Marshal.StructureToPtr(cEventHandlerNativeLocal, eventHandlerHandle.marshal, true);
            eventHandlerHandle.handle = AgoraRtcNative.CreateIrisEventHandler(eventHandlerHandle.marshal);
        }

        internal static void FreeEventHandlerHandle(ref RtcEventHandlerHandle eventHandlerHandle)
        {
            AgoraRtcNative.DestroyIrisEventHandler(eventHandlerHandle.handle);
            eventHandlerHandle.handle = IntPtr.Zero;

            Marshal.FreeHGlobal(eventHandlerHandle.marshal);
            eventHandlerHandle.marshal = IntPtr.Zero;

            eventHandlerHandle.cEvent = new IrisRtcCEventHandler();
        }

        #endregion

        #region iris_rtc_high_performance_c_api

        // ILocalSpatialAudioEngine
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetMaxAudioRecvCount(RtcEngineHandle enginePtr, int maxCount);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetAudioRecvRange(RtcEngineHandle enginePtr, float range);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetDistanceUnit(RtcEngineHandle enginePtr, float unit);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_UpdateSelfPosition(RtcEngineHandle enginePtr,
          float positionX, float positionY, float positionZ, float axisForwardX,
          float axisForwardY, float axisForwardZ, float axisRightX, float axisRightY,
          float axisRightZ, float axisUpX, float axisUpY, float axisUpZ);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_UpdateSelfPositionEx(RtcEngineHandle enginePtr,
          float positionX, float positionY, float positionZ, float axisForwardX,
          float axisForwardY, float axisForwardZ, float axisRightX, float axisRightY,
          float axisRightZ, float axisUpX, float axisUpY, float axisUpZ,
          string channelId, uint localUid);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_UpdatePlayerPositionInfo(RtcEngineHandle enginePtr,
          int playerId, float positionX, float positionY, float positionZ,
          float forwardX, float forwardY, float forwardZ);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_MuteLocalAudioStream(RtcEngineHandle enginePtr, bool mute);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_MuteAllRemoteAudioStreams(RtcEngineHandle enginePtr, bool mute);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetZones(RtcEngineHandle enginePtr, IrisSpatialAudioZone[] zones, uint zoneCount);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetPlayerAttenuation(RtcEngineHandle enginePtr,
          int playerId, double attenuation, bool forceSet);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_MuteRemoteAudioStream(RtcEngineHandle enginePtr, uint uid, bool mute);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_UpdateRemotePosition(RtcEngineHandle engine_ptr,
          uint uid, float positionX, float positionY, float positionZ,
          float forwardX, float forwardY, float forwardZ);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_UpdateRemotePositionEx(RtcEngineHandle enginePtr,
          uint uid, float positionX, float positionY, float positionZ,
          float forwardX, float forwardY, float forwardZ, string channelId,
          uint localUid);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_RemoveRemotePosition(RtcEngineHandle enginePtr, uint uid);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_RemoveRemotePositionEx(RtcEngineHandle enginePtr,
          uint uid, string channelId, uint localUid);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_ClearRemotePositions(RtcEngineHandle enginePtr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_ClearRemotePositionsEx(RtcEngineHandle enginePtr,
           string channelId, uint localUid);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ILocalSpatialAudioEngine_SetRemoteAudioAttenuation(RtcEngineHandle enginePtr,
          uint uid, double attenuation, bool forceSet);

        //
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int IMediaEngine_PushAudioFrame(RtcEngineHandle enginePtr,
        ref IrisAudioFrame frame, uint trackId);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int IMediaEngine_PullAudioFrame(RtcEngineHandle enginePtr,
        ref IrisAudioFrame frame);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int IMediaEngine_PushVideoFrame(RtcEngineHandle enginePtr,
        ref IrisExternalVideoFrame frame, uint videoTrackId);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int IMediaEngine_PushEncodedVideoImage(RtcEngineHandle enginePtr,
        IntPtr imageBuffer, ulong length, ref IrisEncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId);
        #endregion

    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Rtc_Func_Event_Native(IntPtr param);

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcCEventParam
    {
        internal string @event;
        internal string data;
        internal uint data_size;

        internal IntPtr result;

        internal IntPtr buffer;
        internal IntPtr length;
        internal uint buffer_count;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcCApiParam
    {

        internal string Result
        {
            get
            {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                return Marshal.PtrToStringAnsi(result);
#else
                return StringFromNativeUtf8(result);
#endif
            }
        }

        internal void AllocResult()
        {
            if (result == IntPtr.Zero)
            {
                result = Marshal.AllocHGlobal(65536);
            }
        }

        internal void FreeResult()
        {
            if (result != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(result);
                result = IntPtr.Zero;
            }
        }

        internal string StringFromNativeUtf8(IntPtr nativeUtf8)
        {
            int len = 0;
            while (Marshal.ReadByte(nativeUtf8, len) != 0) ++len;
            byte[] buffer = new byte[len];
            Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        internal string @event;
        internal string data;
        internal uint data_size;

        internal IntPtr result;

        internal IntPtr buffer;
        internal IntPtr length;
        internal uint buffer_count;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcCEventHandlerNative
    {
        internal IntPtr onEvent;
    }

    internal struct IrisRtcCEventHandler
    {
        internal Rtc_Func_Event_Native OnEvent;
    }


    internal struct RtcEventHandlerHandle
    {
        internal IrisRtcCEventHandler cEvent;
        internal IrisEventHandlerMarshal marshal;
        internal IrisEventHandlerHandle handle;
    }

    #region callback native

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

    [StructLayout(LayoutKind.Sequential)]
    public struct IrisAudioFrame
    {
        public int type;
        public int samplesPerChannel;
        public int bytesPerSample;
        public int channels;
        public int samplesPerSec;
        public IntPtr buffer;
        public long renderTimeMs;
        public int avsync_type;
        public long presentationMs;
        public int audioTrackNumber;
        public uint rtpTimestamp;

        public IrisAudioFrame(AudioFrame frame)
        {
            this.type = (int)frame.type;
            this.samplesPerChannel = frame.samplesPerChannel;
            this.bytesPerSample = (int)frame.bytesPerSample;
            this.channels = frame.channels;
            this.samplesPerSec = frame.samplesPerSec;
            this.buffer = frame.buffer;
            this.renderTimeMs = frame.renderTimeMs;
            this.avsync_type = frame.avsync_type;
            this.presentationMs = frame.presentationMs;
            this.audioTrackNumber = frame.audioTrackNumber;
            this.rtpTimestamp = frame.rtpTimestamp;
        }
    };


    [StructLayout(LayoutKind.Sequential)]
    public struct IrisHdr10MetadataInfo
    {
        public ushort redPrimaryX;

        public ushort redPrimaryY;

        public ushort greenPrimaryX;

        public ushort greenPrimaryY;

        public ushort bluePrimaryX;

        public ushort bluePrimaryY;

        public ushort whitePointX;

        public ushort whitePointY;

        public uint maxMasteringLuminance;

        public uint minMasteringLuminance;

        public ushort maxContentLightLevel;

        public ushort maxFrameAverageLightLevel;

        public IrisHdr10MetadataInfo(Hdr10MetadataInfo hdr10MetadataInfo)
        {
            if (hdr10MetadataInfo != null)
            {
                this.redPrimaryX = hdr10MetadataInfo.redPrimaryX;
                this.redPrimaryY = hdr10MetadataInfo.redPrimaryY;
                this.greenPrimaryX = hdr10MetadataInfo.greenPrimaryX;
                this.greenPrimaryY = hdr10MetadataInfo.greenPrimaryY;
                this.bluePrimaryX = hdr10MetadataInfo.bluePrimaryX;
                this.bluePrimaryY = hdr10MetadataInfo.bluePrimaryY;
                this.whitePointX = hdr10MetadataInfo.whitePointX;
                this.whitePointY = hdr10MetadataInfo.whitePointY;
                this.maxMasteringLuminance = hdr10MetadataInfo.maxMasteringLuminance;
                this.minMasteringLuminance = hdr10MetadataInfo.minMasteringLuminance;
                this.maxContentLightLevel = hdr10MetadataInfo.maxContentLightLevel;
                this.maxFrameAverageLightLevel = hdr10MetadataInfo.maxFrameAverageLightLevel;
            }
            else
            {
                this.redPrimaryX = 0;
                this.redPrimaryY = 0;
                this.greenPrimaryX = 0;
                this.greenPrimaryY = 0;
                this.bluePrimaryX = 0;
                this.bluePrimaryY = 0;
                this.whitePointX = 0;
                this.whitePointY = 0;
                this.maxMasteringLuminance = 0;
                this.minMasteringLuminance = 0;
                this.maxContentLightLevel = 0;
                this.maxFrameAverageLightLevel = 0;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IrisColorSpace
    {
        public int primaries;
        public int transfer;
        public int matrix;
        public int range;

        public IrisColorSpace(ColorSpace colorSpace)
        {
            if (colorSpace != null)
            {
                this.primaries = (int)colorSpace.primaries;
                this.transfer = (int)colorSpace.transfer;
                this.matrix = (int)colorSpace.matrix;
                this.range = (int)colorSpace.range;
            }
            else
            {
                this.primaries = (int)PrimaryID.PRIMARYID_UNSPECIFIED;
                this.transfer = (int)TransferID.TRANSFERID_UNSPECIFIED;
                this.matrix = (int)MatrixID.MATRIXID_UNSPECIFIED;
                this.range = (int)RangeID.RANGEID_INVALID;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IrisExternalVideoFrame
    {
        public int type;
        public int format;
        public IntPtr buffer;
        public int stride;
        public int height;
        public int cropLeft;
        public int cropTop;
        public int cropRight;
        public int cropBottom;
        public int rotation;
        public long timestamp;
        public IntPtr eglContext;
        public int eglType;
        public int textureId;
        public long fenceObject;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public float[] matrix;
        public IntPtr metadataBuffer;
        public int metadataSize;
        public IntPtr alphaBuffer;
        public bool fillAlphaBuffer;
        public int alphaStitchMode;
        public IntPtr d3d11Texture2d;
        public int textureSliceIndex;
        public IrisHdr10MetadataInfo hdr10MetadataInfo;
        public IrisColorSpace colorSpace;

        public IrisExternalVideoFrame(ExternalVideoFrame frame)
        {
            this.type = (int)frame.type;
            this.format = (int)frame.format;
            this.buffer = frame.buffer == null ? IntPtr.Zero : Marshal.UnsafeAddrOfPinnedArrayElement(frame.buffer, 0);
            this.stride = frame.stride;
            this.height = frame.height;
            this.cropLeft = frame.cropLeft;
            this.cropTop = frame.cropTop;
            this.cropRight = frame.cropRight;
            this.cropBottom = frame.cropBottom;
            this.rotation = frame.rotation;
            this.timestamp = frame.timestamp;
            this.eglContext = frame.eglContext;
            this.eglType = (int)frame.eglType;
            this.textureId = frame.textureId;
            this.fenceObject = frame.fenceObject;
            if (frame.matrix != null && frame.matrix.Length == 16)
            {
                this.matrix = frame.matrix;
            }
            else
            {
                this.matrix = new float[16];
            }
            this.metadataBuffer = frame.metadataBuffer == null ? IntPtr.Zero : Marshal.UnsafeAddrOfPinnedArrayElement(frame.metadataBuffer, 0);
            this.metadataSize = frame.metadataSize;
            this.alphaBuffer = frame.alphaBuffer == null ? IntPtr.Zero : Marshal.UnsafeAddrOfPinnedArrayElement(frame.alphaBuffer, 0);
            this.fillAlphaBuffer = frame.fillAlphaBuffer;
            this.alphaStitchMode = (int)frame.alphaStitchMode;
            this.d3d11Texture2d = frame.d3d11Texture2d;
            this.textureSliceIndex = frame.textureSliceIndex;
            this.hdr10MetadataInfo = new IrisHdr10MetadataInfo(frame.hdr10MetadataInfo);
            this.colorSpace = new IrisColorSpace(frame.colorSpace);
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct IrisEncodedVideoFrameInfo
    {
        public uint uid;
        public int codecType;
        public int width;
        public int height;
        public int framesPerSecond;
        public int frameType;
        public int rotation;
        public int trackId;
        public long captureTimeMs;
        public long decodeTimeMs;
        public int streamType;
        public long presentationMs;

        public IrisEncodedVideoFrameInfo(EncodedVideoFrameInfo info)
        {
            this.uid = info.uid;
            this.codecType = (int)info.codecType;
            this.width = info.width;
            this.height = info.height;
            this.framesPerSecond = info.framesPerSecond;
            this.frameType = (int)info.frameType;
            this.rotation = (int)info.rotation;
            this.trackId = info.trackId;
            this.captureTimeMs = info.captureTimeMs;
            this.decodeTimeMs = info.decodeTimeMs;
            this.streamType = (int)info.streamType;
            this.presentationMs = info.presentationMs;
        }
    };


    #endregion
}