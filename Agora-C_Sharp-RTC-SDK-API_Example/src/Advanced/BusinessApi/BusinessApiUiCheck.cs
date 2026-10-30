using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace C_Sharp_API_Example
{
    // Opt-in CI diagnostic. Renders the real Windows controls and validates every
    // allowlisted overload's argument editor without initializing/calling Native.
    internal static class BusinessApiUiCheck
    {
        internal static void Run(string reportPath)
        {
            reportPath = Path.GetFullPath(reportPath);
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));
            using var window = new Form { ClientSize = new Size(1250, 760), Text = "C# Windows 业务 API 测试" };
            var view = new BusinessApiView("", "ui-smoke");
            window.Controls.Add(view);
            window.Show(); Application.DoEvents();
            int count = view.VerifyOfflineUi();
            using (var bitmap = new Bitmap(window.Width, window.Height))
            {
                window.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
                bitmap.Save(Path.ChangeExtension(reportPath, ".png"));
            }
            File.WriteAllText(reportPath, JsonSerializer.Serialize(new
            {
                passed = true, overloads = count, native_calls = 0,
                architecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString(),
                visible = window.Visible, width = window.Width, height = window.Height
            }));
            window.Close();
        }
    }
}
