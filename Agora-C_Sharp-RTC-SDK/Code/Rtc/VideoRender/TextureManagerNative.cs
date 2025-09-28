using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace Agora.Rtc
{
    /// <summary>
    /// 修复版本的TextureManagerNative - 解决Unity不出图问题
    /// 主要修复: 正确的纹理ID获取 + 强制GPU同步
    /// </summary>
    public class TextureManagerNative : TextureManager
    {
        private Texture2D _nativeTexture;
        private IntPtr _nativeTexturePtr;

        public Texture2D Texture
        {
            get { return _nativeTexture; }
        }

        internal override void InitTexture()
        {
            try
            {
                // 创建Unity纹理，这将作为渲染目标
                _nativeTexture = new Texture2D(_videoPixelWidth, _videoPixelHeight, TextureFormat.RGBA32, false);
                _nativeTexture.wrapMode = TextureWrapMode.Clamp;
                _nativeTexture.filterMode = FilterMode.Point;
                
                // **关键修复**: 初始化为透明纹理，避免显示灰色
                InitializeTransparentTexture(_nativeTexture);
                
                // **关键修复1**: 确保纹理在GPU上创建
                _nativeTexture.Apply(); // updateMipmaps=true, makeNoLongerReadable=false
                
                // 获取Unity纹理的原生指针
                _nativeTexturePtr = _nativeTexture.GetNativeTexturePtr();

                AgoraLog.Log($"InitTexture: Created Unity texture {_videoPixelWidth}x{_videoPixelHeight}");
                AgoraLog.Log($"InitTexture: Unity texture ptr: {_nativeTexturePtr}");
                AgoraLog.Log($"InitTexture: Unity graphics API: {SystemInfo.graphicsDeviceType}");
            }
            catch (Exception e)
            {
                AgoraLog.LogError("Exception in InitTexture: " + e);
            }
        }

        internal override void InitIrisVideoFrame()
        {
            // **关键修复2**: 正确获取OpenGL纹理ID
            int unityTextureId = 0;
            if (_nativeTexture != null && _nativeTexturePtr != IntPtr.Zero)
            {
                try
                {
                    // 在Android OpenGL ES环境下，Unity的GetNativeTexturePtr()通常直接返回OpenGL纹理ID
                    // 但我们需要安全地处理不同的图形API
                    if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES3 ||
                        SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES2)
                    {
                        // 对于OpenGL ES，纹理指针在大多数情况下就是纹理ID
                        // 需要将IntPtr安全转换为int
                        long ptrValue = _nativeTexturePtr.ToInt64();
                        if (ptrValue > 0 && ptrValue <= int.MaxValue)
                        {
                            unityTextureId = (int)ptrValue;
                            AgoraLog.Log($"InitIrisVideoFrame: 获取OpenGL ES纹理ID: {unityTextureId} (ptr: 0x{ptrValue:X})");
                        }
                        else
                        {
                            AgoraLog.LogWarning($"InitIrisVideoFrame: 纹理指针值异常: 0x{ptrValue:X}");
                        }
                    }
                    else
                    {
                        // 对于其他图形API，记录警告但尝试转换
                        AgoraLog.LogWarning($"InitIrisVideoFrame: 未完全支持的图形API: {SystemInfo.graphicsDeviceType}");
                        long ptrValue = _nativeTexturePtr.ToInt64();
                        if (ptrValue > 0 && ptrValue <= int.MaxValue)
                        {
                            unityTextureId = (int)ptrValue;
                        }
                    }
                }
                catch (Exception e)
                {
                    AgoraLog.LogError($"InitIrisVideoFrame: 获取纹理ID失败: {e}");
                    unityTextureId = 0;
                }
            }
            else
            {
                AgoraLog.LogError("InitIrisVideoFrame: Unity纹理或纹理指针为空");
            }
            
            // 初始化IrisCVideoFrame结构
            _cachedVideoFrame = new IrisCVideoFrame
            {
                type = (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_TEXTURE_2D,
                width = _videoPixelWidth,
                height = _videoPixelHeight,
                textureId = unityTextureId,     
                sharedContext = IntPtr.Zero
            };
            
            AgoraLog.Log($"InitIrisVideoFrame: Unity textureId={unityTextureId}, Graphics API={SystemInfo.graphicsDeviceType}");
        }

        internal override void ReFreshTexture()
        {
            // **关键修复3**: 在每次调用前确保纹理ID正确
            if (_nativeTexture != null && _nativeTexturePtr != IntPtr.Zero)
            {
                // 重新获取纹理指针（可能已变化）
                _nativeTexturePtr = _nativeTexture.GetNativeTexturePtr();
                
                // 安全地转换纹理指针为纹理ID
                try
                {
                    long ptrValue = _nativeTexturePtr.ToInt64();
                    if (ptrValue > 0 && ptrValue <= int.MaxValue)
                    {
                        int unityTextureId = (int)ptrValue;
                        _cachedVideoFrame.textureId = unityTextureId;
                        AgoraLog.Log($"ReFreshTexture: Updated Unity textureId to {unityTextureId} (ptr: 0x{ptrValue:X})");
                    }
                    else
                    {
                        AgoraLog.LogWarning($"ReFreshTexture: 无效的纹理指针值: 0x{ptrValue:X}");
                    }
                }
                catch (Exception e)
                {
                    AgoraLog.LogError($"ReFreshTexture: 纹理ID转换失败: {e}");
                }
            }

            var ret = _videoStreamManager.GetVideoFrame(ref _cachedVideoFrame, ref isFresh, _sourceType, _uid, _channelId, _frameType);
            //IRIS_VIDEO_PROCESS_ERR ret = 0;
            //_nativeTexture.Apply();

            if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_NO_CACHE)
            {
                _canAttach = false;
                return;
            }
            else if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_RESIZED)
            {
                _videoPixelWidth = _cachedVideoFrame.width;
                _videoPixelHeight = _cachedVideoFrame.height;
                
                AgoraLog.Log($"ReFreshTexture: Resizing texture to {_videoPixelWidth}x{_videoPixelHeight}");
                ReinitializeTexture();
            }
            else
            {
                _canAttach = true;
            }

            if (isFresh == false)
            {
                return;
            }

            // **关键修复4**: 强制GPU同步和Unity渲染管线更新
            if (_cachedVideoFrame.textureId != 0)
            {
                AgoraLog.Log($"ReFreshTexture: Unity textureId {_cachedVideoFrame.textureId} updated by native layer");
                // 使用专门的纹理同步方法
                //ForceTextureSync();
            }
            else
            {
                AgoraLog.LogWarning("ReFreshTexture: No Unity textureId found after native binding");
            }
        }
        
        // **关键修复5**: 纹理同步辅助方法（使用Unity内建API）
        private void ForceTextureSync()
        {
            try
            {
                if (_nativeTexture != null)
                {
                    // 多种方式确保Unity识别纹理更新
                    //GL.InvalidateState();                         // 强制OpenGL状态同步
                    _nativeTexture.Apply();          // 纹理内容同步（不生成mipmap）
                    //Graphics.SetRenderTarget(_nativeTexture);    // 设置为渲染目标
                    //Graphics.SetRenderTarget(null);              // 清除渲染目标
                    
                    AgoraLog.Log("ForceTextureSync: Unity纹理同步完成");
                }
            }
            catch (Exception e)
            {
                AgoraLog.LogError($"ForceTextureSync: 纹理同步失败: {e}");
            }
        }
    
        private void ReinitializeTexture()
        {
            if (_nativeTexture != null)
            {
#if UNITY_2021_2_OR_NEWER
                _nativeTexture.Reinitialize(_videoPixelWidth, _videoPixelHeight);
#else
                _nativeTexture.Resize(_videoPixelWidth, _videoPixelHeight);
#endif
                
                // 重新初始化时也设置为透明
                InitializeTransparentTexture(_nativeTexture);
                
                _nativeTexture.Apply();
                _nativeTexturePtr = _nativeTexture.GetNativeTexturePtr();
                
                AgoraLog.Log($"Texture reinitialized: {_videoPixelWidth}x{_videoPixelHeight}, new ptr: {_nativeTexturePtr}");
            }
        }

        /// <summary>
        /// 初始化纹理为透明状态，避免显示灰色
        /// </summary>
        /// <param name="texture">要初始化的纹理</param>
        private void InitializeTransparentTexture(Texture2D texture)
        {
            if (texture == null) return;
            
            try
            {
                // 使用透明色填充整个纹理
                Color32 transparentColor = new Color32(0, 0, 0, 0);
                Color32[] transparentPixels = new Color32[texture.width * texture.height];
                
                // 批量填充，比逐个赋值更高效
                for (int i = 0; i < transparentPixels.Length; i++)
                {
                    transparentPixels[i] = transparentColor;
                }
                
                texture.SetPixels32(transparentPixels);
                
                AgoraLog.Log($"InitializeTransparentTexture: 纹理已初始化为透明 {texture.width}x{texture.height}");
            }
            catch (Exception e)
            {
                AgoraLog.LogError($"InitializeTransparentTexture: 初始化透明纹理失败: {e}");
            }
        }

        protected override void DestroyTexture()
        {
            if (_nativeTexture != null)
            {
                GameObject.Destroy(_nativeTexture);
                _nativeTexture = null;
            }
            _nativeTexturePtr = IntPtr.Zero;
            
            AgoraLog.Log("Texture destroyed");
        }

        override internal void Attach()
        {
            _refCount++;
            AgoraLog.Log("TextureManager Native refCount Add, Now is: " + _refCount);
        }

        override internal void Detach()
        {
            if (_refCount > 0)
            {
                _refCount--;
                AgoraLog.Log("TextureManager Native refCount Minus, Now is: " + _refCount);
            }
        }
    }
}
