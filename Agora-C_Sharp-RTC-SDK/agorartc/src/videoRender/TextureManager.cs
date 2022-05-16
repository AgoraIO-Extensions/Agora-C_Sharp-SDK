using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace agora.rtc
{
    internal enum IRIS_VIDEO_PROCESS_ERR {
        ERR_OK = 0,
        ERR_NULL_POINTER = 1,
        ERR_SIZE_NOT_MATCHING = 2,
        ERR_BUFFER_EMPTY = 5,
    };

    internal class TextureManager
    {
        private int VideoPixelWidth = 1080;
        private int VideoPixelHeight = 720;
        private uint Uid = 0;
        private string ChannelId = "";
        private VIDEO_SOURCE_TYPE sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
        private bool _needResize = false;
        private bool isFresh = false;

        private IVideoStreamManager _videoStreamManager;
        private IrisVideoFrame _cachedVideoFrame = new IrisVideoFrame();

        // refrence count
        private int useCount = 0;

        private Texture2D _texture;
        public Texture2D texture
        {
            get 
            {
                useCount++;
                AgoraLog.Log("TextureManager UseCount Add, Now is: " + useCount);
                return _texture;
            }
        }

        public TextureManager()
        {
            _cachedVideoFrame.y_buffer = IntPtr.Zero;
            _cachedVideoFrame.u_buffer = IntPtr.Zero;
            _cachedVideoFrame.v_buffer = IntPtr.Zero;
        }

        internal int GetUserCount()
        {
            return useCount;
        }

        internal void EnableVideoFrameWithIdentity()
        {
            var engine = AgoraRtcEngine.Get();
            if (engine != null)
            {
                if (_videoStreamManager == null)
                {
                    _videoStreamManager = ((AgoraRtcEngine) engine).GetVideoStreamManager();
                }

                if (_videoStreamManager != null)
                {
                    _videoStreamManager.EnableVideoFrameBuffer(VideoPixelWidth, VideoPixelHeight, sourceType, Uid, ChannelId);
                }
            
                _needResize = true;
                FreeMemory();
                _cachedVideoFrame = new IrisVideoFrame
                {
                    type = VIDEO_FRAME_TYPE.FRAME_TYPE_RGBA,
                    y_stride = VideoPixelWidth * 4,
                    height = VideoPixelHeight,
                    width = VideoPixelWidth,
                    y_buffer = Marshal.AllocHGlobal(VideoPixelWidth * VideoPixelHeight * 4)
                };
            }
        }

        internal void InitTexture()
        {
            try
            {
                _texture = new Texture2D(VideoPixelWidth, VideoPixelHeight, TextureFormat.RGBA32, false);
                _texture.Apply();
            }
            catch (Exception e)
            {
                AgoraLog.LogError("Exception e = " + e);
            }
        }

        internal void RenewVideoFrame()
        {
            var ret = _videoStreamManager.GetVideoFrame(ref _cachedVideoFrame, ref isFresh, sourceType, Uid, ChannelId);
            AgoraLog.LogWarning("GetVideoFrame" + ret + " width:" + _cachedVideoFrame.width + " height:" + _cachedVideoFrame.height);
            if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_BUFFER_EMPTY)
            {
                AgoraLog.LogWarning(string.Format("no video frame for user channel: {0} uid: {1}", ChannelId, Uid));
                return;
            }
            else if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_SIZE_NOT_MATCHING)
            {
                _needResize = true;
                VideoPixelWidth = _cachedVideoFrame.width;
                VideoPixelHeight = _cachedVideoFrame.height;
                FreeMemory();
                _cachedVideoFrame = new IrisVideoFrame
                {
                    type = VIDEO_FRAME_TYPE.FRAME_TYPE_RGBA,
                    y_stride = VideoPixelWidth * 4,
                    height = VideoPixelHeight,
                    width = VideoPixelWidth,
                    y_buffer = Marshal.AllocHGlobal(VideoPixelWidth * VideoPixelHeight * 4)
                };
            }

            if (isFresh)
            {
                try
                {
                    if (_needResize)
                    {
                        _texture.Resize(VideoPixelWidth, VideoPixelHeight);
                        // _texture.LoadRawTextureData(_cachedVideoFrame.y_buffer,
                        //     (int) VideoPixelWidth * (int) VideoPixelHeight * 4);
                        _texture.Apply();
                        _needResize = false;
                    }
                    else
                    {
                        _texture.LoadRawTextureData(_cachedVideoFrame.y_buffer,
                            (int) VideoPixelWidth * (int) VideoPixelHeight * 4);
                        _texture.Apply();
                    }
                }
                catch (Exception e)
                {
                    AgoraLog.Log("Exception e = " + e);
                }
            }
        }

        internal void SetVideoStreamIdentity(uint uid = 0, string channelId = "",
            VIDEO_SOURCE_TYPE source_type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY, 
            int videoPixelWidth = 1080, int videoPixelHeight = 720)
        {
            Uid = uid;
            ChannelId = channelId;
            sourceType = source_type;
            VideoPixelWidth = videoPixelWidth;
            VideoPixelHeight = videoPixelHeight;
        }

        internal void Destroy()
        {
            AgoraLog.Log(string.Format("VideoSurface channel: ${0}, user:{1} destroy", ChannelId, Uid));

            useCount --;
            AgoraLog.Log("TextureManager UseCount Minus, Now is: " + useCount);
            if (useCount >= 1) return;

            if (_videoStreamManager != null)
            {
                _videoStreamManager.DisableVideoFrameBuffer(sourceType, Uid, ChannelId);
                _videoStreamManager = null;
            }

            FreeMemory();
            DestroyTexture();
        }

        private void DestroyTexture()
        {
            if (_texture != null)
            {
                GameObject.Destroy(_texture);
                _texture = null;
            }
        }

        private void FreeMemory()
        {
            if (_cachedVideoFrame.y_buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_cachedVideoFrame.y_buffer);
            }
        }

    }
}