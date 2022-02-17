//  VideoSurface.cs
//
//  Created by Yiqing Huang on June 2, 2021.
//  Modified by Tao Zhang on June 20, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 

using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;


namespace agora.rtc
{
    public enum AgoraVideoSurfaceType
    {
        Renderer = 0,
        RawImage = 1,
    };

    public sealed class VideoSurface : MonoBehaviour
    {
        [SerializeField] private AgoraEngineType AgoraEngineType = AgoraEngineType.MainProcess;
        [SerializeField] private AgoraVideoSurfaceType VideoSurfaceType = AgoraVideoSurfaceType.Renderer;
        [SerializeField] private int VideoPixelWidth = 1080;
        [SerializeField] private int VideoPixelHeight = 720;
        [SerializeField] private bool FlipX = false;
        [SerializeField] private bool FlipY = false;
        [SerializeField] private uint Uid = 0;
        [SerializeField] private string ChannelId = "";
        [SerializeField] private bool Enable = true;

        private Component _renderer;
        private bool _needUpdateInfo = true;
        private bool _needResize = false;
        private Texture2D _texture;
        private IVideoStreamManager _videoStreamManager;
        private IrisVideoFrame _cachedVideoFrame = new IrisVideoFrame();

        public VideoSurface()
        {
            _cachedVideoFrame.y_buffer = IntPtr.Zero;
            _cachedVideoFrame.u_buffer = IntPtr.Zero;
            _cachedVideoFrame.v_buffer = IntPtr.Zero;
        }

        public void SetEngineType(AgoraEngineType agoraEngineType = AgoraEngineType.MainProcess)
        {
            AgoraEngineType = agoraEngineType;
        }

        void Start()
        {
            if (VideoSurfaceType == AgoraVideoSurfaceType.Renderer)
            {
                _renderer = GetComponent<Renderer>();
            }

            if (_renderer == null || VideoSurfaceType == AgoraVideoSurfaceType.RawImage)
            {
                _renderer = GetComponent<RawImage>();
                if (_renderer != null)
                {
                    VideoSurfaceType = AgoraVideoSurfaceType.RawImage;
                }
            }

            if (_renderer == null)
            {
                AgoraLog.LogError("Unable to find surface render in VideoSurface component.");
            }
            else
            {
#if UNITY_EDITOR
                // this only applies to Editor, in case of material is too dark
                UpdateShader();
#endif
            }
        }

        void Update()
        {
            var ret = false;
            var isFresh = false;

            var engine = GetEngine();

            if (engine == null || _renderer == null || _needUpdateInfo || _videoStreamManager == null)
            {
                AgoraLog.LogError("VideoSurface need to initialize engine first");
                return;
            }

            EnableFilpTextureApply(FlipX, FlipY);

            if (Enable)
            {
                isFresh = false;
                ret = _videoStreamManager.GetVideoFrame(ref _cachedVideoFrame, ref isFresh, Uid, ChannelId);
                if (!ret)
                {
                    AgoraLog.LogWarning(string.Format("no video frame for user channel: {0} uid: {1}", ChannelId, Uid));
                    return;
                }

                if (IsBlankTexture())
                {
                    if (isFresh)
                    {
                        try
                        {
                            _texture = new Texture2D(VideoPixelWidth, VideoPixelHeight, TextureFormat.RGBA32, false);
                            _texture.LoadRawTextureData(_cachedVideoFrame.y_buffer,
                                (int) VideoPixelWidth * (int) VideoPixelHeight * 4);
                            ApplyTexture(_texture);
                            _texture.Apply();
                        }
                        catch (Exception e)
                        {
                            AgoraLog.LogError("Exception e = " + e);
                        }
                    }
                }
                else
                {
                    if (_texture == null)
                    {
                        AgoraLog.LogError(
                            "You didn't initialize native texture, please remove native texture and initialize it by agora.");
                        return;
                    }

                    if (isFresh)
                    {
                        try
                        {
                            if (_needResize)
                            {
                                _texture.Resize(VideoPixelWidth, VideoPixelHeight);
                                _texture.LoadRawTextureData(_cachedVideoFrame.y_buffer,
                                    (int) VideoPixelWidth * (int) VideoPixelHeight * 4);
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
                            AgoraLog.LogError("Exception e = " + e);
                        }
                    }
                }
            }
            else
            {
                if (!IsBlankTexture())
                {
                    ApplyTexture(null);
                    DestroyTexture();
                }
            }
        }

        private IAgoraRtcEngine GetEngine()
        {
            var engine = AgoraRtcEngine.Get(AgoraEngineType);
            if (_needUpdateInfo && engine != null)
            {
                if (_videoStreamManager == null)
                {
                    _videoStreamManager = ((AgoraRtcEngine) engine).GetVideoStreamManager();
                }

                if (_videoStreamManager != null)
                    _videoStreamManager.EnableVideoFrameCache(VideoPixelWidth, VideoPixelHeight, Uid, ChannelId);
                _needUpdateInfo = false;
                _needResize = true;
                FreeMemory();
                _cachedVideoFrame = new IrisVideoFrame
                {
                    type = VIDEO_FRAME_TYPE.FRAME_TYPE_RGBA,
                    y_stride = VideoPixelWidth * 4,
                    height = VideoPixelHeight,
                    y_buffer = Marshal.AllocHGlobal(VideoPixelWidth * VideoPixelHeight * 4)
                };
            }

            return engine;
        }

        private bool IsBlankTexture()
        {
            if (VideoSurfaceType == AgoraVideoSurfaceType.Renderer)
            {
                var rd = (_renderer as Renderer);
                return rd.material.mainTexture == null || !(rd.material.mainTexture is Texture2D);
            }
            else if (VideoSurfaceType == AgoraVideoSurfaceType.RawImage)
            {
                var rd = (_renderer as RawImage);
                return (rd.texture == null);
            }
            else
            {
                return true;
            }
        }

        private void ApplyTexture(Texture2D texture)
        {
            if (VideoSurfaceType == AgoraVideoSurfaceType.Renderer)
            {
                var rd = _renderer as Renderer;
                rd.material.mainTexture = texture;
            }
            else if (VideoSurfaceType == AgoraVideoSurfaceType.RawImage)
            {
                var rd = _renderer as RawImage;
                rd.texture = texture;
            }
        }

        private void UpdateShader()
        {
            var mesh = GetComponent<MeshRenderer>();
            if (mesh != null)
            {
                mesh.material = new Material(Shader.Find("Unlit/Texture"));
            }
        }

        public void SetForUser(uint uid = 0, string channelId = "", int videoPixelWidth = 1080,
            int videoPixelHeight = 720)
        {
            Uid = uid;
            ChannelId = channelId;
            VideoPixelWidth = videoPixelWidth;
            VideoPixelHeight = videoPixelHeight;
            _needUpdateInfo = true;
        }

        void OnDestroy()
        {
            AgoraLog.Log(string.Format("VideoSurface channel: ${0}, user:{1} destroy", ChannelId, Uid));

            if (GetEngine() != null && _videoStreamManager != null)
            {
                _videoStreamManager.DisableVideoFrameCache(Uid, ChannelId);
                _videoStreamManager = null;
            }

            FreeMemory();
            DestroyTexture();
        }

        private void DestroyTexture()
        {
            if (_texture != null)
            {
                Destroy(_texture);
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

        public void EnableFilpTextureApply(bool flipX, bool flipY)
        {
            if (FlipX != flipX)
            {
                transform.localScale =
                    new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                FlipX = flipX;
            }

            if (FlipY != flipY)
            {
                transform.localScale =
                    new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
                FlipY = flipY;
            }
        }

        public void SetEnable(bool enable)
        {
            Enable = enable;
        }
    }
}

#endif