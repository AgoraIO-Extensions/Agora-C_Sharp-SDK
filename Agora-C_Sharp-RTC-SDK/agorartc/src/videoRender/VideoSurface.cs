//  VideoSurface.cs
//
//  Created by YuGuo Chen on October 9, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 

using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace agora.rtc
{
    public enum AgoraVideoSurfaceType
    {
        Renderer = 0,
        RawImage = 1,
    };

    public struct AgoraVideoStreamIdentity
    {
        public uint uid;
        public string channelId;
        public VIDEO_SOURCE_TYPE sourceType;
    }

    public sealed class AgoraVideoSurface : MonoBehaviour
    {
        [SerializeField] private AgoraVideoSurfaceType VideoSurfaceType = AgoraVideoSurfaceType.Renderer;
        [SerializeField] private bool FlipX = false;
        [SerializeField] private bool FlipY = false;
        [SerializeField] private int VideoPixelWidth = 1080;
        [SerializeField] private int VideoPixelHeight = 720;
        [SerializeField] private uint Uid = 0;
        [SerializeField] private string ChannelId = "";
        [SerializeField] private bool Enable = true;
        [SerializeField] private VIDEO_SOURCE_TYPE sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;


        private Component _renderer;
        private bool _needUpdateInfo = true;
        private bool _needResize = false;
        private Texture2D _texture;
        private IVideoStreamManager _videoStreamManager;
        private IrisVideoFrame _cachedVideoFrame = new IrisVideoFrame();

        private AgoraObjectPool<TextureManager, AgoraVideoStreamIdentity> _texturePool;
        private TextureManager _textureManager;
        private bool isFirstUser = false;

        private AgoraVideoStreamIdentity _identity;

        void Start()
        {
            CheckVideoSurfaceType();

            //instance AgoraObjectPool
            _texturePool = AgoraObjectPool<TextureManager, AgoraVideoStreamIdentity>.Instacne;
        }

        void Update()
        {
            var ret = false;

            if (_renderer == null || _needUpdateInfo)
            {
                AgoraLog.LogError("VideoSurface need to initialize engine first");
                return;
            }

            //GetVideoFrame
            if (isFirstUser || _textureManager?.GetUserCount() == 1) {
                _textureManager.RenewVideoFrame();
            }
            
            if (Enable)
            {
                if (IsBlankTexture())
                {
                    _identity = new AgoraVideoStreamIdentity();
                    _identity.uid = Uid;
                    _identity.channelId = ChannelId;
                    _identity.sourceType = sourceType;
                    _textureManager = _texturePool.GetObj(_identity);

                    if (_textureManager == null)
                    {
                        AgoraLog.Log("VideoSurface can't find _textureManager in pool");
                        _textureManager = new TextureManager();
                        _texturePool.AddObj(_identity, _textureManager);
                        _texture = GetTexture();
                        isFirstUser = true;
                    }
                    else
                    {
                        _texture = _textureManager.texture;
                    }
                    ApplyTexture(_texture);
                }
            }
            else
            {
                if (!IsBlankTexture())
                {
                    ApplyTexture(null);
                }
            }
        }

        void OnDestroy()
        {
            AgoraLog.Log(string.Format("VideoSurface channel: ${0}, user:{1} destroy", ChannelId, Uid));
            isFirstUser = false;

            _textureManager.Destroy();
        }

        private void CheckVideoSurfaceType()
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

        private Texture2D GetTexture()
        {
            _textureManager.SetVideoStreamIdentity(Uid, ChannelId, sourceType, VideoPixelWidth, VideoPixelHeight);
            _textureManager.InitTexture();
            _textureManager.EnableVideoFrameWithIdentity();
            return _textureManager.texture;
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

        public void SetForUser(uint uid = 0, string channelId = "",
            VIDEO_SOURCE_TYPE source_type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY, 
            int videoPixelWidth = 1080, int videoPixelHeight = 720)
        {
            Uid = uid;
            ChannelId = channelId;
            sourceType = source_type;
            VideoPixelWidth = videoPixelWidth;
            VideoPixelHeight = videoPixelHeight;
            _needUpdateInfo = false;
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
