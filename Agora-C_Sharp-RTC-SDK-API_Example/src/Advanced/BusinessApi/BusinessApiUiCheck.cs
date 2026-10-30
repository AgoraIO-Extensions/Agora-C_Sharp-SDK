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
            using var window = new MainForm();
            window.Show(); Application.DoEvents();
            window.SelectBusinessSceneForCheck(0);
            int count = window.VerifyBusinessScenes();
            for (int index = 0; index < BusinessApiView.SceneNames.Length; index++)
            {
                window.SelectBusinessSceneForCheck(index); Application.DoEvents();
                using var bitmap = new Bitmap(window.Width, window.Height);
                window.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
                string name = Path.GetFileNameWithoutExtension(reportPath) + ".scene" + index + ".png";
                bitmap.Save(Path.Combine(Path.GetDirectoryName(reportPath), name));
            }
            File.WriteAllText(reportPath, JsonSerializer.Serialize(new
            {
                passed = true, overloads = count, scene_count = BusinessApiView.SceneNames.Length,
                standalone_popup = false, generic_argument_editor = false,
                architecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString(),
                visible = window.Visible, width = window.Width, height = window.Height
            }));
            window.Close();
        }
    }
}
