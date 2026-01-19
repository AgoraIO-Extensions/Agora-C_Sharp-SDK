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

        private static readonly float[] limitOffset = new float[] { 0.0627f, 0.5f, 0.5f };
        private static readonly float[] fullRangeOffset = new float[] { 0.0f, 0.5f, 0.5f };

        private static readonly float[] color601_full = new float[] {1.0f,      1.0f,      1.0f,       0.000000f, -0.344136f,
                                        1.772000f, 1.402000f, -0.714136f, 0.00000f};

        private static readonly float[] color601_limit = new float[] {1.164384f, 1.164384f, 1.164384f,  0.000000f, -0.391762f,
                                         2.017232f, 1.596027f, -0.812968f, 0.000000f};

        private static readonly float[] color709_full = new float[] {1.0f,      1.0f,      1.0f,       0.000000f, -0.187324f,
                                        1.855600f, 1.574800f, -0.468124f, 0.00000f};

        private static readonly float[] color709_limit = new float[] {1.164384f, 1.164384f, 1.164384f,  0.000000f, -0.213249f,
                                         2.112402f, 1.792741f, -0.532909f, 0.000000f};

        private static readonly float[] color2020_full = new float[] {1.0f,      1.0f,      1.0f,       0.000000f, -0.164553f,
                                         1.881400f, 1.474600f, -0.571353f, 0.00000f};

        private static readonly float[] color2020_limit = new float[] {1.164384f, 1.164384f, 1.164384f,  0.000000f, -0.187326f,
                                          2.141772f, 1.678674f, -0.650424f, 0.000000f};

        public static Matrix4x4 MergeMatrixWithOffsets(float[] matrix3x3_colMajor, float[] offsets)
        {

            if (matrix3x3_colMajor == null || matrix3x3_colMajor.Length != 9)
            {
                AgoraLog.LogError("matrix3x3_colMajor array must contain 9 elements (column-major)");
                return Matrix4x4.identity;
            }
            if (offsets == null || offsets.Length != 3)
            {
                AgoraLog.LogError("offsets array must contain 3 elements: [yOffset, uOffset, vOffset]");
                return Matrix4x4.identity;
            }

            Matrix4x4 matrix4x4 = Matrix4x4.identity;

            matrix4x4[0, 0] = matrix3x3_colMajor[0]; // M00
            matrix4x4[1, 0] = matrix3x3_colMajor[1]; // M10
            matrix4x4[2, 0] = matrix3x3_colMajor[2]; // M20

            matrix4x4[0, 1] = matrix3x3_colMajor[3]; // M01
            matrix4x4[1, 1] = matrix3x3_colMajor[4]; // M11
            matrix4x4[2, 1] = matrix3x3_colMajor[5]; // M21

            matrix4x4[0, 2] = matrix3x3_colMajor[6]; // M02
            matrix4x4[1, 2] = matrix3x3_colMajor[7]; // M12
            matrix4x4[2, 2] = matrix3x3_colMajor[8]; // M22

            float yOffset = offsets[0];
            float uOffset = offsets[1];
            float vOffset = offsets[2];

            matrix4x4[0, 3] = -(matrix4x4[0, 0] * yOffset +
                                  matrix4x4[0, 1] * uOffset +
                                  matrix4x4[0, 2] * vOffset);

            matrix4x4[1, 3] = -(matrix4x4[1, 0] * yOffset +
                                  matrix4x4[1, 1] * uOffset +
                                  matrix4x4[1, 2] * vOffset);

            matrix4x4[2, 3] = -(matrix4x4[2, 0] * yOffset +
                                  matrix4x4[2, 1] * uOffset +
                                  matrix4x4[2, 2] * vOffset);

            return matrix4x4;
        }

        public static Matrix4x4 GetMatrix4X4ByColorSpace(IrisColorSpace colorSpace)
        {
            float[] matrixArray = null;
            if (colorSpace.primaries == (int)PrimaryID.PRIMARYID_BT709)
            {
                matrixArray = (colorSpace.range == (int)RangeID.RANGEID_FULL) ? color709_full : color709_limit;
            }
            else if (colorSpace.primaries == (int)PrimaryID.PRIMARYID_BT2020)
            {
                matrixArray = (colorSpace.range == (int)RangeID.RANGEID_FULL) ? color2020_full : color2020_limit;
            }
            else
            {
                matrixArray = (colorSpace.range == (int)RangeID.RANGEID_FULL) ? color601_full : color601_limit;
            }

            float[] yuvOffset = (colorSpace.range == (int)RangeID.RANGEID_FULL) ? fullRangeOffset : limitOffset;
            return MergeMatrixWithOffsets(matrixArray, yuvOffset);
        }

        private TextureManagerYUV _textureManagerYUV;
        protected Material _material = null;
        protected float YStrideScale = 1.0f;
        protected PrimaryID _primaries = PrimaryID.PRIMARYID_UNSPECIFIED;

        protected RangeID _rangeID = RangeID.RANGEID_INVALID;

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

                    if (this._textureWidth != 0 && this._textureHeight != 0 && (this.YStrideScale != this._textureManagerYUV.YStrideScale))
                    {
                        if (_material != null)
                        {
                            _material.SetFloat("_yStrideScale", _textureManagerYUV.YStrideScale);
                        }
                        this.YStrideScale = this._textureManagerYUV.YStrideScale;
                    }

                    UpdateYUV2RGBMatrixIfNeed();
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
        }

        protected virtual void UpdateYUV2RGBMatrixIfNeed()
        {
            var colorSpace = _textureManagerYUV.ColorSpace;
            if (this._primaries != (PrimaryID)colorSpace.primaries || this._rangeID != (RangeID)colorSpace.range)
            {
                var matrix4x4 = GetMatrix4X4ByColorSpace(colorSpace);
                _material.SetMatrix("_yuv2rgb", matrix4x4);
                this._primaries = (PrimaryID)colorSpace.primaries;
                this._rangeID = (RangeID)colorSpace.range;
            }
        }
    }
}

#endif