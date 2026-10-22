using System;
using Agora.Rtc;

internal static class Program
{
    private static int Main(string[] args)
    {
        try
        {
            string arch = IntPtr.Size == 8 ? "x64" : "x86";
            if (args.Length != 2 || arch != args[0]) throw new Exception("Unexpected process architecture");
            var assembly = typeof(IRtcEngine).Assembly;
            if (assembly.GetName().Version.ToString() != "4.5.3.6") throw new Exception("Unexpected managed SDK version");
            Console.WriteLine("PROCESS=" + arch + " TARGET=" + args[1] + " CLR=" + Environment.Version);
            Console.WriteLine("MANAGED=" + assembly.Location);
            bool initialize = Environment.GetEnvironmentVariable("CONSUMER_REQUIRE_INITIALIZE") == "true";
            string appId = Environment.GetEnvironmentVariable("CONSUMER_APP_ID");
            if (initialize && (String.IsNullOrEmpty(appId) || appId.Length != 32))
                throw new Exception("Initialization requires a runtime App ID");
            for (int attempt = 0; attempt < 3; attempt++)
            {
                IRtcEngine engine = null;
                try
                {
                    engine = RtcEngine.CreateAgoraRtcEngine();
                    if (initialize)
                    {
                        var context = new RtcEngineContext { appId = appId };
                        context.logConfig.filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sdk-" + attempt + ".log");
                        int result = engine.Initialize(context);
                        Console.WriteLine("INITIALIZE_RESULT=" + result + " ATTEMPT=" + attempt);
                        if (result != 0) throw new Exception("SDK Initialize failed: " + result);
                    }
                    int build = 0;
                    string version = engine.GetVersion(ref build);
                    if (String.IsNullOrEmpty(version) || !version.StartsWith("4.5."))
                        throw new Exception("Unexpected native version: " + version);
                    Console.WriteLine("NATIVE_VERSION=" + version + " BUILD=" + build + " ATTEMPT=" + attempt);
                }
                finally
                {
                    if (engine != null) engine.Dispose(true);
                }
            }
            Console.WriteLine("CONSUMER_PASS");
            return 0;
        }
        catch (Exception error)
        {
            Console.Error.WriteLine(error);
            return 1;
        }
    }
}
