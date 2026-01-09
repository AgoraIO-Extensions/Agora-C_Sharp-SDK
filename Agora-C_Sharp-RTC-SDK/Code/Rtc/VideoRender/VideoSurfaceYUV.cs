#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS

using UnityEngine;
using UnityEngine.UI;

namespace Agora.Rtc
{

    ///
    /// <summary>
    /// Porivdes APIs for rendering videos. This class inherits all APIs from the VideoSurface class, but enables you to render video images with high resolutions (such as 4K) faster and at higher frame rates. As of v4.2.0, Agora Unity SDK does not support rendering different video sources with both VideoSurface and VideoSurfaceYUV at the same time. Specifically, after successfully creating IRtcEngine, if the first view is rendered with VideoSurfaceYUV, then only VideoSurfaceYUV can be used for rendering throughout the entire lifecycle of IRtcEngine.
    /// </summary>
    ///
    public class VideoSurfaceYUV : VideoSurface
    {
        private TextureManagerYUV _textureManagerYUV;
        protected Material _material = null;
        protected float YStrideScale = 1.0f;
        protected int matrixType = 0;

        void Start()
        {
            FrameType = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420;
            CheckVideoSurfaceType();
        }

        void Update()
        {
            if (_renderer == null || _needUpdateInfo) return;

            if (Enable)
            {
                if (_textureManagerYUV == null)
                {
                    string textureManagerName = this.GenerateTextureManagerUniqueName();
                    _TextureManagerGameObject = GameObject.Find(textureManagerName);

                    if (_TextureManagerGameObject == null)
                    {
                        _TextureManagerGameObject = new GameObject(textureManagerName);
                        _TextureManagerGameObject.hideFlags = HideFlags.HideInHierarchy;

                        _textureManagerYUV = _TextureManagerGameObject.AddComponent<TextureManagerYUV>();
                        _textureManagerYUV.SetVideoStreamIdentity(Uid, ChannelId, SourceType, FrameType);
                        _textureManagerYUV.EnableVideoFrameWithIdentity();
                        
                        // ? Apply metric reporting setting to TextureManagerYUV
                        _textureManagerYUV.SetEnableMetricReporting(true);
                    }
                    else
                    {
                        _textureManagerYUV = _TextureManagerGameObject.GetComponent<TextureManagerYUV>();
                    }
                }
                else if (_textureManagerYUV && !_hasAttach && _textureManagerYUV.CanTextureAttach())
                {
                    UpdateShader();
                    ApplyTexture(_textureManagerYUV.YTexture, _textureManagerYUV.UTexture, _textureManagerYUV.VTexture);
                    _textureManagerYUV.Attach();
                    _hasAttach = true;
                }

                if (_textureManagerYUV)
                {
                    if (this._textureWidth != _textureManagerYUV.Width || this._textureHeight != _textureManagerYUV.Height)
                    {
                        this._textureWidth = _textureManagerYUV.Width;
                        this._textureHeight = _textureManagerYUV.Height;

                        if (this._textureWidth != 0 && this._textureHeight != 0)
                        {
                            this.InvokeOnTextureSizeModify();
                        }
                    }

                    if (this._textureWidth != 0 && this._textureHeight != 0 && (this.YStrideScale != this._textureManagerYUV.YStrideScale || this.matrixType != this._textureManagerYUV.ColorSpace.matrix))
                    {
                        if (_material != null)
                        {
                            _material.SetFloat("_yStrideScale", _textureManagerYUV.YStrideScale);
                            SetYUV2RGB(_material, (MatrixID)this._textureManagerYUV.ColorSpace.matrix, (RangeID)this._textureManagerYUV.ColorSpace.range);
                        }
                        this.YStrideScale = this._textureManagerYUV.YStrideScale;
                        this.matrixType = this._textureManagerYUV.ColorSpace.matrix;
                    }

                }
            }
            else
            {
                if (_hasAttach && !IsBlankTexture())
                {
                    DestroyTextureManager();
                    ApplyTexture(null, null, null);
                }
            }
        }

        void OnDestroy()
        {
            AgoraLog.Log(string.Format("VideoSurface YUV channel: ${0}, user:{1} destroy", ChannelId, Uid));
            DestroyTextureManager();
        }

        protected override void CheckVideoSurfaceType()
        {
            if (VideoSurfaceType == VideoSurfaceType.Renderer)
            {
                _renderer = GetComponent<Renderer>();
            }

            if (_renderer == null || VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                _renderer = GetComponent<RawImage>();
                if (_renderer != null)
                {
                    VideoSurfaceType = VideoSurfaceType.RawImage;
                }
            }

            if (_renderer == null)
            {
                AgoraLog.LogError("Unable to find surface render in VideoSurfaceYUV component.");
            }
        }

        protected override bool IsBlankTexture()
        {
            if (VideoSurfaceType == VideoSurfaceType.Renderer)
            {
                var rd = (_renderer as Renderer);
                return rd.material.mainTexture == null || !(rd.material.mainTexture is Texture2D);
            }
            else if (VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                var rd = (_renderer as RawImage);
                return (rd.texture == null);
            }
            else
            {
                return true;
            }
        }

        protected void ApplyTexture(Texture2D texture, Texture2D uTexture, Texture2D vTexture)
        {
            if (VideoSurfaceType == VideoSurfaceType.Renderer)
            {
                var rd = _renderer as Renderer;
                rd.material.mainTexture = texture;
                rd.material.SetTexture("_UTex", uTexture);
                rd.material.SetTexture("_VTex", vTexture);
            }
            else if (VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                var rd = _renderer as RawImage;
                rd.texture = texture;
                rd.material.SetTexture("_UTex", uTexture);
                rd.material.SetTexture("_VTex", vTexture);
            }
        }

        protected override void DestroyTextureManager()
        {
            if (_textureManagerYUV == null) return;

            if (_hasAttach == true)
            {
                _textureManagerYUV.Detach();
                _hasAttach = false;
            }

            if (_textureManagerYUV.GetRefCount() <= 0)
            {
                Destroy(_TextureManagerGameObject);
            }
            _textureManagerYUV = null;
        }

        protected override void UpdateShader()
        {

            if (VideoSurfaceType == VideoSurfaceType.Renderer)
            {
                var rd = _renderer as Renderer;
                rd.material = new Material(Shader.Find("Unlit/RendererShader601"));
                _material = rd.material;
            }
            else if (VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                var rd = _renderer as RawImage;
                rd.material = new Material(Shader.Find("UI/RendererShader601"));
                _material = rd.material;
            }

            _material.SetFloat("_yStrideScale", _textureManagerYUV.YStrideScale);
            SetYUV2RGB(_material, (MatrixID)this._textureManagerYUV.ColorSpace.matrix, (RangeID)this._textureManagerYUV.ColorSpace.range);
        }

        private void SetYUV2RGB(Material mat, MatrixID matrixID, RangeID rangeID)
        {
            if (matrixID == MatrixID.MATRIXID_BT709)
            {
                if (rangeID == RangeID.RANGEID_FULL)
                {
                    mat.SetMatrix("_yuv2rgb", new Matrix4x4()
                    {
                        m00 = 1f,
                        m01 = 0f,
                        m02 = 1.5748f,
                        m03 = -0.7874f,
                        m10 = 1f,
                        m11 = -0.1873f,
                        m12 = -0.4681f,
                        m13 = 0.3277f,
                        m20 = 1f,
                        m21 = 1.8556f,
                        m22 = 0f,
                        m23 = -0.9278f,
                        m30 = 0f,
                        m31 = 0f,
                        m32 = 0f,
                        m33 = 1f
                    });
                }
                else
                {
                    mat.SetMatrix("_yuv2rgb", new Matrix4x4()
                    {
                        m00 = 1.1644f,
                        m01 = 0f,
                        m02 = 1.7927f,
                        m03 = -0.9729f,
                        m10 = 1.1644f,
                        m11 = -0.2132f,
                        m12 = -0.5329f,
                        m13 = 0.3015f,
                        m20 = 1.1644f,
                        m21 = 2.1124f,
                        m22 = 0f,
                        m23 = -1.1334f,
                        m30 = 0f,
                        m31 = 0f,
                        m32 = 0f,
                        m33 = 1f
                    });
                }
            }
            else
            {
                if (rangeID == RangeID.RANGEID_FULL)
                {
                    mat.SetMatrix("_yuv2rgb", new Matrix4x4()
                    {
                        m00 = 1f,
                        m01 = 0f,
                        m02 = 1.402f,
                        m03 = -0.701f,
                        m10 = 1f,
                        m11 = -0.3441f,
                        m12 = -0.7141f,
                        m13 = 0.5291f,
                        m20 = 1f,
                        m21 = 1.772f,
                        m22 = 0f,
                        m23 = -0.886f,
                        m30 = 0f,
                        m31 = 0f,
                        m32 = 0f,
                        m33 = 1f
                    });
                }
                else
                {
                    mat.SetMatrix("_yuv2rgb", new Matrix4x4()
                    {
                        m00 = 1.1644f,
                        m01 = 0f,
                        m02 = 1.596f,
                        m03 = -0.8742f,
                        m10 = 1.1644f,
                        m11 = -0.3918f,
                        m12 = -0.813f,
                        m13 = 0.5317f,
                        m20 = 1.1644f,
                        m21 = 2.0172f,
                        m22 = 0f,
                        m23 = -1.0856f,
                        m30 = 0f,
                        m31 = 0f,
                        m32 = 0f,
                        m33 = 1f
                    });
                }
            }
        }

        /// <summary>
        /// Enable or disable metric reporting for this VideoSurfaceYUV
        /// </summary>
   /// <param name="enable">True to enable reporting, false to disable</param>
        public override void SetEnableMetricReporting(bool enable)
        {   
   // Update the TextureManagerYUV if it already exists
  if (_textureManagerYUV != null)
            {
  _textureManagerYUV.SetEnableMetricReporting(enable);
  }
        }

        /// <summary>
        /// Check if metric reporting is enabled for this VideoSurfaceYUV
      /// </summary>
   /// <returns>True if reporting is enabled, false otherwise</returns>
        public override bool IsMetricReportingEnabled()
  {
            if (_textureManagerYUV != null)
     {
                return _textureManagerYUV.IsMetricReportingEnabled();
        }
        return false;
        }

    }
}

#endif