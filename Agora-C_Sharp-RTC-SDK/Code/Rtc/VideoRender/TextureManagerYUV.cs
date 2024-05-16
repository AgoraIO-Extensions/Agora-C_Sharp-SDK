#define USE_UNSAFE_CODE
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using System;
using System.Runtime.InteropServices;
#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
#endif
using UnityEngine;

namespace Agora.Rtc
{
    public class TextureManagerYUV : TextureManager
    {
        protected Texture2D _uTexture;
        protected Texture2D _vTexture;

        public new Texture2D Texture
        {
            get
            {
                return null;
            }
        }

        public Texture2D YTexture
        {
            get
            {

                return _texture;
            }
        }

        public Texture2D UTexture
        {
            get
            {

                return _uTexture;
            }
        }

        public Texture2D VTexture
        {
            get
            {

                return _vTexture;
            }
        }
#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
        protected NativeArray<byte> _uTextureNative;
        protected NativeArray<byte> _vTextureNative;
#endif

        public float YStrideScale = 1.0f;

        internal override void InitTexture()
        {
            try
            {
                _texture = new Texture2D(_videoPixelWidth, _videoPixelHeight, TextureFormat.R8, false);
                _texture.wrapMode = TextureWrapMode.Clamp;
                _texture.Apply();

                _uTexture = new Texture2D(_videoPixelWidth / 2, _videoPixelHeight / 2, TextureFormat.R8, false);
                _uTexture.wrapMode = TextureWrapMode.Clamp;
                _uTexture.Apply();

                _vTexture = new Texture2D(_videoPixelWidth / 2, _videoPixelHeight / 2, TextureFormat.R8, false);
                _vTexture.wrapMode = TextureWrapMode.Clamp;
                _vTexture.Apply();
            }
            catch (Exception e)
            {
                AgoraLog.LogError("Exception e = " + e);
            }
        }

        internal override void InitIrisVideoFrame()
        {

            _cachedVideoFrame = new IrisCVideoFrame
            {
                type = (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420,
                yStride = _videoPixelWidth,
                height = _videoPixelHeight,
                width = _videoPixelWidth,
                uStride = _videoPixelWidth / 2,
                vStride = _videoPixelWidth / 2,
                alphaBuffer = IntPtr.Zero,
            };
#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
            _textureNative = _texture.GetRawTextureData<byte>();
            _uTextureNative = _uTexture.GetRawTextureData<byte>();
            _vTextureNative = _vTexture.GetRawTextureData<byte>();
            unsafe
            {
                _cachedVideoFrame.yBuffer = (IntPtr)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(_textureNative);
                _cachedVideoFrame.uBuffer = (IntPtr)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(_uTextureNative);
                _cachedVideoFrame.vBuffer = (IntPtr)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(_vTextureNative);
            }
#else
            _cachedVideoFrame.yBuffer = Marshal.AllocHGlobal(_videoPixelWidth * _videoPixelHeight);
            _cachedVideoFrame.uBuffer = Marshal.AllocHGlobal(_videoPixelWidth / 2 * _videoPixelHeight / 2);
            _cachedVideoFrame.vBuffer = Marshal.AllocHGlobal(_videoPixelWidth / 2 * _videoPixelHeight / 2);
#endif
        }



        internal override void ReFreshTexture()
        {
            var ret = _videoStreamManager.GetVideoFrame(ref _cachedVideoFrame, ref isFresh, _sourceType, _uid, _channelId, _frameType);




            if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_NO_CACHE)
            {
                _canAttach = false;
                return;
            }
            else if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_RESIZED)
            {
                _videoPixelWidth = _cachedVideoFrame.width;
                _videoPixelHeight = _cachedVideoFrame.height;

#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
#if UNITY_2021_2_OR_NEWER
                _texture.Reinitialize(_cachedVideoFrame.yStride, _cachedVideoFrame.height);
#else
                _texture.Resize(_cachedVideoFrame.yStride, _cachedVideoFrame.height);
#endif
                _texture.Apply();
#if UNITY_2021_2_OR_NEWER
                _uTexture.Reinitialize(_cachedVideoFrame.uStride, _cachedVideoFrame.height / 2);
#else
                _uTexture.Resize(_cachedVideoFrame.uStride, _cachedVideoFrame.height / 2);
#endif
                _uTexture.Apply();
#if UNITY_2021_2_OR_NEWER
                _vTexture.Reinitialize(_cachedVideoFrame.vStride, _cachedVideoFrame.height / 2);
#else
                _vTexture.Resize(_cachedVideoFrame.vStride, _cachedVideoFrame.height / 2);
#endif
                _vTexture.Apply();
                _textureNative = _texture.GetRawTextureData<byte>();
                _uTextureNative = _uTexture.GetRawTextureData<byte>();
                _vTextureNative = _vTexture.GetRawTextureData<byte>();
                unsafe
                {
                    _cachedVideoFrame.yBuffer = (IntPtr)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(_textureNative);
                    _cachedVideoFrame.uBuffer = (IntPtr)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(_uTextureNative);
                    _cachedVideoFrame.vBuffer = (IntPtr)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(_vTextureNative);
                }
#else

                _needResize = true;
                FreeMemory();
                _cachedVideoFrame.type = (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420;
                _cachedVideoFrame.yBuffer = Marshal.AllocHGlobal(_cachedVideoFrame.yStride * _cachedVideoFrame.height);
                _cachedVideoFrame.uBuffer = Marshal.AllocHGlobal(_cachedVideoFrame.uStride * _cachedVideoFrame.height / 2);
                _cachedVideoFrame.vBuffer = Marshal.AllocHGlobal(_cachedVideoFrame.vStride * _cachedVideoFrame.height / 2);
#endif
                if (_cachedVideoFrame.width == 0 || _cachedVideoFrame.width == _cachedVideoFrame.yStride)
                {
                    YStrideScale = 1.0f;
                }
                else
                {
                    YStrideScale = ((float)_cachedVideoFrame.width / (float)_cachedVideoFrame.yStride) - 0.02f;
                }

                return;
            }
            else
            {
                _canAttach = true;
            }

            if (isFresh == false)
            {
                return;
            }

            try
            {
#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
                _texture.Apply();
                _uTexture.Apply();
                _vTexture.Apply();
#else
                if (_needResize)
                {
#if UNITY_2021_2_OR_NEWER
                    _texture.Reinitialize(_cachedVideoFrame.yStride, _cachedVideoFrame.height);
#else
                    _texture.Resize(_cachedVideoFrame.yStride, _cachedVideoFrame.height);
#endif
                    _texture.Apply();
#if UNITY_2021_2_OR_NEWER
                    _uTexture.Reinitialize(_cachedVideoFrame.uStride, _cachedVideoFrame.height / 2);
#else
                    _uTexture.Resize(_cachedVideoFrame.uStride, _cachedVideoFrame.height / 2);
#endif
                    _uTexture.Apply();
#if UNITY_2021_2_OR_NEWER
                    _vTexture.Reinitialize(_cachedVideoFrame.vStride, _cachedVideoFrame.height / 2);
#else
                    _vTexture.Resize(_cachedVideoFrame.vStride, _cachedVideoFrame.height / 2);
#endif
                    _vTexture.Apply();

                   
                    _needResize = false;
                }

                _texture.LoadRawTextureData(_cachedVideoFrame.yBuffer,
                    (int)_cachedVideoFrame.yStride * (int)_videoPixelHeight);
                _texture.Apply();
                _uTexture.LoadRawTextureData(_cachedVideoFrame.uBuffer,
                    (int)_cachedVideoFrame.uStride * (int)_videoPixelHeight / 2);
                _uTexture.Apply();
                _vTexture.LoadRawTextureData(_cachedVideoFrame.vBuffer,
                    (int)_cachedVideoFrame.vStride * (int)_videoPixelHeight / 2);
                _vTexture.Apply();
#endif

            }
            catch (Exception e)
            {
                AgoraLog.Log("Exception e = " + e);
            }

        }

        protected override void DestroyTexture()
        {
            if (_texture != null)
            {
                GameObject.Destroy(_texture);
                _texture = null;
            }
            if (_uTexture != null)
            {
                GameObject.Destroy(_uTexture);
                _uTexture = null;
            }
            if (_vTexture != null)
            {
                GameObject.Destroy(_vTexture);
                _vTexture = null;
            }
        }

        private void FreeMemory()
        {
#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
            _cachedVideoFrame.yBuffer = IntPtr.Zero;
            _cachedVideoFrame.uBuffer = IntPtr.Zero;
            _cachedVideoFrame.vBuffer = IntPtr.Zero;
#else

            if (_cachedVideoFrame.yBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_cachedVideoFrame.yBuffer);
                _cachedVideoFrame.yBuffer = IntPtr.Zero;
            }

            if (_cachedVideoFrame.uBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_cachedVideoFrame.uBuffer);
                _cachedVideoFrame.uBuffer = IntPtr.Zero;
            }

            if (_cachedVideoFrame.vBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_cachedVideoFrame.vBuffer);
                _cachedVideoFrame.vBuffer = IntPtr.Zero;
            }
#endif
        }

        override internal void Attach()
        {
            _refCount++;
            AgoraLog.Log("TextureManager YUV refCount Add, Now is: " + _refCount);
        }

        override internal void Detach()
        {
            if (_refCount > 0)
            {
                _refCount--;
                AgoraLog.Log("TextureManager YUV refCount Minus, Now is: " + _refCount);
            }
            return;
        }

    }
}

#endif