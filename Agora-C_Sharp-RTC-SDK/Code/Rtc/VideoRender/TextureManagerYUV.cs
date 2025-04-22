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

            _cachedVideoFrame = new TextureVideoFrame
            {
                type = (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420,
                yStride = _videoPixelWidth,
                height = _videoPixelHeight,
                width = _videoPixelWidth,
                uStride = _videoPixelWidth / 2,
                vStride = _videoPixelWidth / 2,
            };
        }



        internal override void ReFreshTexture()
        {
            TimeConsuming.End(1, "TextureYUV:onVideoFrame -> refresh start");
            TimeConsuming.Start(2);
            TextureVideoFrame tempVideoFrame = null;

            lock (_videoFrameLock)
            {
                if (_isFresh)
                {
                    tempVideoFrame = _cachedVideoFrame;
                    _isFresh = false;
                }
                else
                {
                    return;
                }
            }

            _canAttach = true;
            if (tempVideoFrame.width != _videoPixelWidth || tempVideoFrame.height != _videoPixelHeight)
            {
                _videoPixelWidth = tempVideoFrame.width;
                _videoPixelHeight = tempVideoFrame.height;
#if UNITY_2021_2_OR_NEWER
                _texture.Reinitialize(_cachedVideoFrame.yStride, _cachedVideoFrame.height);
                _uTexture.Reinitialize(_cachedVideoFrame.uStride, _cachedVideoFrame.height / 2);
                _vTexture.Reinitialize(_cachedVideoFrame.vStride, _cachedVideoFrame.height / 2);
#else
                _texture.Resize(_cachedVideoFrame.yStride, _cachedVideoFrame.height);
                _uTexture.Resize(_cachedVideoFrame.uStride, _cachedVideoFrame.height / 2);
                _vTexture.Resize(_cachedVideoFrame.vStride, _cachedVideoFrame.height / 2);
#endif
            }
            _texture.LoadRawTextureData(tempVideoFrame.yBuffer);
            _uTexture.LoadRawTextureData(tempVideoFrame.uBuffer);
            _vTexture.LoadRawTextureData(tempVideoFrame.vBuffer);
            _texture.Apply();
            _uTexture.Apply();
            _vTexture.Apply();

            if (_cachedVideoFrame.width == 0 || _cachedVideoFrame.width == _cachedVideoFrame.yStride)
            {
                YStrideScale = 1.0f;
            }
            else
            {
                YStrideScale = ((float)_cachedVideoFrame.width / (float)_cachedVideoFrame.yStride) - 0.02f;
            }
            TimeConsuming.End(2, "TextureYUV:refresh start -> refresh end");
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

        internal override void OnVideoFameEvent(ref IrisCVideoFrame videoFrame, ref IrisRtcVideoFrameConfig config, bool resize)
        {
            if (_videoFrameConfig.video_source_type != config.video_source_type)
                return;
            if (_videoFrameConfig.video_frame_format != config.video_frame_format)
                return;
            if (_videoFrameConfig.uid != config.uid)
                return;
            if (_videoFrameConfig.channelId != config.channelId)
                return;


            TextureVideoFrame tempVideoFrame = new TextureVideoFrame()
            {
                type = (int)videoFrame.type,
                width = videoFrame.width,
                height = videoFrame.height,
                yStride = videoFrame.yStride,
                uStride = videoFrame.uStride,
                vStride = videoFrame.vStride
            };

            int yBufferLength = videoFrame.yStride * videoFrame.height;
            int uBufferLength = videoFrame.uStride * videoFrame.height / 2;
            int vBufferLength = videoFrame.vStride * videoFrame.height / 2;

            tempVideoFrame.yBuffer = new byte[yBufferLength];
            Marshal.Copy(videoFrame.yBuffer, tempVideoFrame.yBuffer, 0, yBufferLength);
            tempVideoFrame.uBuffer = new byte[uBufferLength];
            Marshal.Copy(videoFrame.uBuffer, tempVideoFrame.uBuffer, 0, uBufferLength);
            tempVideoFrame.vBuffer = new byte[vBufferLength];
            Marshal.Copy(videoFrame.vBuffer, tempVideoFrame.vBuffer, 0, vBufferLength);

            lock (_videoFrameLock)
            {
                _cachedVideoFrame = tempVideoFrame;
                _isFresh = true;
            }
            TimeConsuming.Start(1);
        }

    }
}

#endif