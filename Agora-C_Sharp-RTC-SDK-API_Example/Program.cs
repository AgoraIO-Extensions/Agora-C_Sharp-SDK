using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_API_Example
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] commandLine)
        {
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (commandLine.Length == 2 && commandLine[0] == "--business-api-ui-check")
            {
                try { BusinessApiUiCheck.Run(commandLine[1]); return 0; }
                catch (Exception error)
                {
                    System.IO.File.WriteAllText(commandLine[1], System.Text.Json.JsonSerializer.Serialize(new { passed = false, error = error.ToString() }));
                    return 1;
                }
            }
            var form = new MainForm();
            var startupReport = Environment.GetEnvironmentVariable("AGORA_DEMO_STARTUP_REPORT");
            if (!string.IsNullOrWhiteSpace(startupReport))
            {
                // Opt-in startup evidence also works on a Windows CI service desktop.
                form.Shown += (sender, args) => form.BeginInvoke(new Action(() =>
                    System.IO.File.WriteAllText(startupReport, System.Text.Json.JsonSerializer.Serialize(new
                    {
                        process_id = Environment.ProcessId,
                        architecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString(),
                        runtime = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,
                        runtime_directory = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory(),
                        window_handle = form.Handle.ToInt64(),
                        window_title = form.Text,
                        visible = form.Visible
                    }))));
            }
            Application.Run(form);
            return 0;
        }
    }
}
