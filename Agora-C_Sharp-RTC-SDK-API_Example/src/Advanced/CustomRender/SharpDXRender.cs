using System;
using System.Drawing;
using Agora.Rtc;
using SharpDX;

// https://learn.microsoft.com/en-us/windows/win32/direct3d9/direct3d-rendering
// https://github.com/sharpdx/SharpDX
// https://blog.csdn.net/u013113678/article/details/121296452

namespace C_Sharp_API_Example.src.Advanced.CustomRender
{
    class SharpDXRender : BaseRender
    {
        // render
        private bool disposing_ = false;
        private IntPtr handle_ = IntPtr.Zero;
        private Size size_ = new Size();
        private DataType data_type_ = DataType.kYUV420;

        // d3d
        private SharpDX.Direct3D9.Direct3D d3d_ = new SharpDX.Direct3D9.Direct3D();
        private SharpDX.Direct3D9.Device d3d_device_ = null;
        private SharpDX.Direct3D9.Surface d3d_offscreen_surface_ = null;
        private SharpDX.Direct3D9.Surface d3d_backend_surface_ = null;
        private SharpDX.Direct3D9.Font d3d_fps_font_ = null;
        private Size d3d_offscreen_surface_buffer_size_ = new Size();
        private Size d3d_backend_surface_buffer_size_ = new Size();

        public SharpDXRender()
        {

        }

        #region override BaseRender
        public override void Dispose()
        {
            if (disposing_ == true)
                return;

            disposing_ = true;

            StopFpsTimer();

            if (d3d_fps_font_ != null)
                d3d_fps_font_.Dispose();

            if (d3d_offscreen_surface_ != null)
                d3d_offscreen_surface_.Dispose();

            if (d3d_backend_surface_ != null)
                d3d_backend_surface_.Dispose();

            if (d3d_device_ != null)
                d3d_device_.Dispose();

            d3d_.Dispose();
        }

        public override CustomVideoBoxRenderType GetRenderType()
        {
            return data_type_ == DataType.kBGRA ? CustomVideoBoxRenderType.kSharpDX_BGRA : CustomVideoBoxRenderType.kSharpDX_YUV420;
        }

        public override bool Initialize(IntPtr handle, Size size, DataType dataType)
        {
            handle_ = handle;
            size_ = size;
            data_type_ = dataType;

            if (!AutoCreateD3DDevice(1920, 1080, size.Width, size.Height))
            {
                return false;
            }

            StartFpsTimer();

            return true;
        }

        public override void UpdateSize(Size size)
        {
            size_ = size;
        }

        public override void DeliverFrame(VideoFrame videoFrame)
        {
            if (disposing_) return;

            if (data_type_ == DataType.kBGRA && videoFrame.type != VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_BGRA && videoFrame.type != VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_RGBA)
                return;

            if (data_type_ == DataType.kYUV420 && videoFrame.type != VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_I420)
                return;

            if (AutoCreateD3DDevice(videoFrame.width, videoFrame.height, size_.Width, size_.Height) != true)
            {
                Console.WriteLine("d3d failed to create d3d device when deliver frame");
                return;
            }

            #region lock offscreen surface
            SharpDX.DataRectangle locked_data = new DataRectangle();

            const int MAX_TRY = 3;
            int times = 0;
            do
            {
                bool need_retry = false;
                try
                {
                    locked_data = d3d_offscreen_surface_.LockRectangle(SharpDX.Direct3D9.LockFlags.DoNotWait);
                }
                catch (SharpDX.SharpDXException e)
                {
                    // D3DERR_WASSTILLDRAWING
                    if (e.Message.Contains("WASSTILLDRAWING"))
                        need_retry = true;
                    else
                    {
                        Console.WriteLine("d3d lock surface failed {0}", e.Message);
                        return;
                    }
                }

                if (need_retry != true)
                    break;

                times++;

                // should sleep in microseconds

            } while (times < MAX_TRY);


            if (locked_data.DataPointer == IntPtr.Zero)
            {
                Console.WriteLine("d3d failed to lock offscreen surface");
                return;
            }

            if (data_type_ == DataType.kBGRA)
            {
                for (int i = 0; i < videoFrame.height; i++)
                {
                    CopyMemory(locked_data.DataPointer + locked_data.Pitch * i, videoFrame.yBufferPtr + i * videoFrame.yStride, Math.Min(videoFrame.yStride, locked_data.Pitch));
                }
            }
            else if (data_type_ == DataType.kYUV420)
            {
                // copy y data with stride
                IntPtr dst_y_ptr = locked_data.DataPointer;
                for (int i = 0; i < videoFrame.height; i++)
                {
                    CopyMemory(dst_y_ptr + i * locked_data.Pitch, videoFrame.yBufferPtr + i * videoFrame.yStride, Math.Min(videoFrame.yStride, locked_data.Pitch));
                }

                // coz dst data is yv12
                // copy v data with stride
                IntPtr dst_u_ptr = dst_y_ptr + locked_data.Pitch * videoFrame.height;
                for (int i = 0; i < videoFrame.height / 2; i++)
                {
                    CopyMemory(dst_u_ptr + i * locked_data.Pitch / 2, videoFrame.vBufferPtr + i * videoFrame.vStride, Math.Min(videoFrame.vStride, locked_data.Pitch / 2));
                }

                // coz dst data is yv12
                // copy u data with stride
                IntPtr dst_v_ptr = dst_u_ptr + locked_data.Pitch / 2 * videoFrame.height / 2;
                for (int i = 0; i < videoFrame.height / 2; i++)
                {
                    CopyMemory(dst_v_ptr + i * locked_data.Pitch / 2, videoFrame.uBufferPtr + i * videoFrame.uStride, Math.Min(videoFrame.uStride, locked_data.Pitch / 2));
                }
            }


            d3d_offscreen_surface_.UnlockRectangle();
            #endregion // lock offscreen surface

            #region present
            // clear with black
            d3d_device_.Clear(SharpDX.Direct3D9.ClearFlags.Target, new SharpDX.Mathematics.Interop.RawColorBGRA(0, 0, 0, 255), 1.0f, 0);

            // begin scene
            d3d_device_.BeginScene();

            // stretch copy
            System.Drawing.Rectangle dest_rect = CalcDestRectangle(new Size(videoFrame.width, videoFrame.height), d3d_backend_surface_buffer_size_);
            // StretchRectangle will throw exception when rectangle is odd but the rectangle of frame is always no-odd so we only recalc rectangle the dst rectangle
            SharpDX.Mathematics.Interop.RawRectangle src_native_rect = new SharpDX.Mathematics.Interop.RawRectangle(0, 0, videoFrame.width, videoFrame.height);
            SharpDX.Mathematics.Interop.RawRectangle dst_native_rect = new SharpDX.Mathematics.Interop.RawRectangle(OddRectangleValue(dest_rect.X), OddRectangleValue(dest_rect.Y), OddRectangleValue(dest_rect.Right), OddRectangleValue(dest_rect.Bottom));
            d3d_device_.StretchRectangle(d3d_offscreen_surface_, src_native_rect, d3d_backend_surface_, dst_native_rect, SharpDX.Direct3D9.TextureFilter.Linear);

            if (d3d_fps_font_ != null)
            {
                string tips_fps = "FPS:" + GetCurrentFps().ToString();
                SharpDX.Mathematics.Interop.RawRectangle font_rect = d3d_fps_font_.MeasureText(null,
                    tips_fps,
                    new SharpDX.Mathematics.Interop.RawRectangle(0, 0, d3d_backend_surface_buffer_size_.Width, d3d_backend_surface_buffer_size_.Height),
                    SharpDX.Direct3D9.FontDrawFlags.Center | SharpDX.Direct3D9.FontDrawFlags.VerticalCenter);
                d3d_fps_font_.DrawText(null,
                    tips_fps,
                    d3d_backend_surface_buffer_size_.Width - (font_rect.Right - font_rect.Left) - 10,
                    10,
                    new SharpDX.Mathematics.Interop.RawColorBGRA(0, 0, 255, 255));
            }

            // end scene
            d3d_device_.EndScene();

            // present
            d3d_device_.Present();
            #endregion // present

            FeedOneFrame();
        }

        public override bool NeedInvoke()
        {
            return false;
        }
        #endregion // override BaseRender

        #region base d3d functions

        private bool EnumValidAdapter(ref int adapter_index, ref SharpDX.Direct3D9.Format adapter_format, ref SharpDX.Direct3D9.DeviceType device_type)
        {
            const int D3DADAPTER_DEFAULT = 0;

            SharpDX.Direct3D9.DisplayMode mode = d3d_.GetAdapterDisplayMode(D3DADAPTER_DEFAULT);
            if (mode.Format == SharpDX.Direct3D9.Format.X8R8G8B8 &&
                !d3d_.CheckDeviceType(D3DADAPTER_DEFAULT, SharpDX.Direct3D9.DeviceType.Hardware, mode.Format, mode.Format, true))
            {
                Console.WriteLine("d3d check device type failed");
            }

            adapter_format = mode.Format;

            // set default preferences
            adapter_index = D3DADAPTER_DEFAULT;
            device_type = SharpDX.Direct3D9.DeviceType.Hardware;

            // we prefer to use NVIDIA
            foreach (var adapter in d3d_.Adapters)
            {
                var identifier = d3d_.GetAdapterIdentifier(adapter.Adapter);
                if (identifier.Description.Contains("PerfHUD"))
                {
                    adapter_index = adapter.Adapter;
                    device_type = SharpDX.Direct3D9.DeviceType.Reference;
                    break;
                }
            }

            var adapter_identifier = d3d_.GetAdapterIdentifier(adapter_index);
            Console.WriteLine("d3d decide to use adapter: {0} \r\n" +
                " Description: {1}\r\n" +
                " Driver: {2} \r\n" +
                " VendorId: {3}\r\n" +
                " DeviceId: {4}\r\n",
                adapter_index,
                adapter_identifier.Description,
                adapter_identifier.Driver,
                adapter_identifier.VendorId,
                adapter_identifier.DeviceId);

            return true;
        }

        private bool AutoCreateD3DDevice(int frame_width, int frame_height, int wnd_width, int wnd_height)
        {
            if (d3d_backend_surface_buffer_size_.Width == wnd_width && d3d_backend_surface_buffer_size_.Height == wnd_height &&
                d3d_offscreen_surface_buffer_size_.Width == frame_width && d3d_offscreen_surface_buffer_size_.Height == frame_height)
                return true;

            if (d3d_fps_font_ != null)
                d3d_fps_font_.Dispose();

            if (d3d_offscreen_surface_ != null)
                d3d_offscreen_surface_.Dispose();

            if (d3d_backend_surface_ != null)
                d3d_backend_surface_.Dispose();

            if (d3d_device_ != null)
                d3d_device_.Dispose();

            int adapter_index = -1;
            SharpDX.Direct3D9.Format adapter_format = SharpDX.Direct3D9.Format.X8R8G8B8;
            SharpDX.Direct3D9.DeviceType device_type = SharpDX.Direct3D9.DeviceType.Hardware;

            // enum a valid adapter to use
            if (!EnumValidAdapter(ref adapter_index, ref adapter_format, ref device_type) ||
                adapter_index == -1)
            {
                Console.WriteLine("d3d enum valid adapter failed with index: {0}", adapter_index);
                return false;
            }

            // create d3d device, should recreate device when width or height of frame changed
            SharpDX.Direct3D9.PresentParameters present_params = new SharpDX.Direct3D9.PresentParameters(
                wnd_width /* backBufferWidth */,
                wnd_height /* backBufferHeight */,
                adapter_format /* backBufferFormat */,
                1 /* backBufferCount */,
                SharpDX.Direct3D9.MultisampleType.None /* multiSampleType */,
                0 /* multiSampleQuality */,
                SharpDX.Direct3D9.SwapEffect.Copy /* swapEffect */,
                handle_ /* deviceWindowHandle */,
                true /* windowed */,
                false /* enableAutoDepthStencil */,
                SharpDX.Direct3D9.Format.Unknown /* autoDepthStencilFormat */,
                SharpDX.Direct3D9.PresentFlags.Video /* presentFlags */,
                0 /* fullScreenRefreshRateInHz */,
                SharpDX.Direct3D9.PresentInterval.Default /* presentationInterval */);

            d3d_device_ = new SharpDX.Direct3D9.Device(d3d_, adapter_index, device_type, IntPtr.Zero,
                SharpDX.Direct3D9.CreateFlags.Multithreaded | SharpDX.Direct3D9.CreateFlags.SoftwareVertexProcessing,
                present_params);

            SharpDX.Direct3D9.FontDescription font_description = new SharpDX.Direct3D9.FontDescription()
            {
                Height = 24,
                Italic = false,
                CharacterSet = SharpDX.Direct3D9.FontCharacterSet.Ansi,
                FaceName = "Arial",
                MipLevels = 0,
                OutputPrecision = SharpDX.Direct3D9.FontPrecision.TrueType,
                PitchAndFamily = SharpDX.Direct3D9.FontPitchAndFamily.Default,
                Quality = SharpDX.Direct3D9.FontQuality.ClearType,
                Weight = SharpDX.Direct3D9.FontWeight.Thin
            };

            d3d_fps_font_ = new SharpDX.Direct3D9.Font(d3d_device_, font_description);

            d3d_offscreen_surface_ = SharpDX.Direct3D9.Surface.CreateOffscreenPlain(d3d_device_,
                frame_width,
                frame_height,
                data_type_ == DataType.kBGRA ? SharpDX.Direct3D9.Format.X8R8G8B8 : (SharpDX.Direct3D9.Format)842094169 /* MAKEFOURCC('Y', 'V', '1', '2') */,
                SharpDX.Direct3D9.Pool.Default);

            d3d_backend_surface_ = d3d_device_.GetBackBuffer(0, 0);

            d3d_device_.SetRenderState(SharpDX.Direct3D9.RenderState.CullMode, 1 /* D3DCULL_NONE = 1 */);
            d3d_device_.SetRenderState(SharpDX.Direct3D9.RenderState.Lighting, false);

            d3d_offscreen_surface_buffer_size_.Width = frame_width;
            d3d_offscreen_surface_buffer_size_.Height = frame_height;

            d3d_backend_surface_buffer_size_.Width = wnd_width;
            d3d_backend_surface_buffer_size_.Height = wnd_height;

            return true;
        }
        #endregion // base d3d functions
    }
}
