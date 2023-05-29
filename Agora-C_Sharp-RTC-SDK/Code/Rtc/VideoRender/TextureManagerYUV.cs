#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Agora.Rtc
{
    public class TextureManagerYUV : TextureManager
    {
        private Texture2D _uTexture;
        private Texture2D _vTexture;

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
                yBuffer = Marshal.AllocHGlobal(_videoPixelWidth * _videoPixelHeight),
                uStride = _videoPixelWidth / 2,
                uBuffer = Marshal.AllocHGlobal(_videoPixelWidth / 2 * _videoPixelHeight / 2),
                vStride = _videoPixelWidth / 2,
                vBuffer = Marshal.AllocHGlobal(_videoPixelWidth / 2 * _videoPixelHeight / 2),
            };
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
                _needResize = true;

                FreeMemory();

                _cachedVideoFrame.type = (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420;

                _cachedVideoFrame.yBuffer = Marshal.AllocHGlobal(_cachedVideoFrame.yStride * _cachedVideoFrame.height);
                _cachedVideoFrame.uBuffer = Marshal.AllocHGlobal(_cachedVideoFrame.uStride * _cachedVideoFrame.height / 2);
                _cachedVideoFrame.vBuffer = Marshal.AllocHGlobal(_cachedVideoFrame.vStride * _cachedVideoFrame.height / 2);

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
                if (_needResize)
                {
                    _texture.Resize(_cachedVideoFrame.yStride, _cachedVideoFrame.height);
                    _texture.Apply();
                    _uTexture.Resize(_cachedVideoFrame.uStride, _cachedVideoFrame.height / 2);
                    _uTexture.Apply();
                    _vTexture.Resize(_cachedVideoFrame.vStride, _cachedVideoFrame.height / 2);
                    _vTexture.Apply();

                    _videoPixelWidth = _cachedVideoFrame.width;
                    _videoPixelHeight = _cachedVideoFrame.height;
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