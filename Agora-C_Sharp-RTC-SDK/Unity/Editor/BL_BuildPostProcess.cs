#if UNITY_STANDALONE_WIN
using System.IO;
using UnityEditor;

public class BL_BuildPostProcess
{
    [UnityEditor.Callbacks.PostProcessBuild(999)]
    public static void OnPostprocessBuild(UnityEditor.BuildTarget BuildTarget, string path)
    {
        var arch = BuildTarget == BuildTarget.StandaloneWindows64 ? "x86_64/" : "x86/";
        var exeName = "AgoraRtcScreenSharing.exe";
        var strPathFrom = UnityEngine.Application.dataPath + "/Agora-Plugin/Agora-Unity-RTC-SDK/Plugins/" + arch + exeName;
        UnityEngine.Debug.LogFormat("src path: {0}", strPathFrom);
        var nIdxSlash = path.LastIndexOf('/');
        var nIdxDot = path.LastIndexOf('.');
        var strRootTarget = path.Substring(0, nIdxSlash);
        var strPluginsTarget = strRootTarget + path.Substring(nIdxSlash, nIdxDot - nIdxSlash) + "_Data/Plugins/";
        var strPathTargetFile = File.Exists(strPluginsTarget + arch)
            ? strPluginsTarget + arch + exeName
            : strPluginsTarget + exeName;
        var strPathTargetFileBackup = strPluginsTarget + arch + exeName;
        File.Copy(strPathFrom, strPathTargetFile);
        File.Copy(strPathFrom, strPathTargetFileBackup);
        UnityEngine.Debug.Log("Copy " + strPathFrom + " to " + strPathTargetFile);
        UnityEngine.Debug.Log("Copy " + strPathFrom + " to " + strPathTargetFileBackup);
    }
}
#endif

#if UNITY_IPHONE || UNITY_STANDALONE_OSX
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
#if UNITY_IPHONE
using UnityEditor.iOS.Xcode;
using UnityEditor.iOS.Xcode.Extensions;
#endif

public class BL_BuildPostProcess
{

    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget buildTarget, string path)
    {
        if (buildTarget == BuildTarget.iOS)
        {
#if UNITY_IPHONE
            LinkLibraries(path);
            UpdatePermission(path + "/Info.plist");
#endif
        }
    }
#if UNITY_IPHONE
    public static void DisableBitcode(string projPath)
    {
        PBXProject proj = new PBXProject();
        proj.ReadFromString(File.ReadAllText(projPath));

        string target = GetTargetGuid(proj);
        proj.SetBuildProperty(target, "ENABLE_BITCODE", "false");
        File.WriteAllText(projPath, proj.WriteToString());
    }

    static string GetTargetGuid(PBXProject proj)
    {
#if UNITY_2019_3_OR_NEWER
        return proj.GetUnityFrameworkTargetGuid();
#else
        return proj.TargetGuidByName("Unity-iPhone");
#endif
    }

    static string[] ProjectFrameworks = new string[] {
        "Accelerate.framework",
        "CoreTelephony.framework",
        "CoreText.framework",
        "CoreML.framework",
        "Metal.framework",
        "VideoToolbox.framework",
        "libiPhone-lib.a",
        "libresolv.tbd",
    };


    static void LinkLibraries(string path)
    {
        // linked library
        string projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
        PBXProject proj = new PBXProject();
        proj.ReadFromFile(projPath);
        string target = GetTargetGuid(proj);


        // embedded frameworks
#if UNITY_2019_3_OR_NEWER
        target = proj.GetUnityMainTargetGuid();
#endif
        string defaultLocationInProj = "Agora-Plugin/Agora-Unity-RTC-SDK/Plugins/iOS";
        const string AgoraRtcWrapperFrameworkName = "AgoraRtcWrapper.framework";
        const string AgoraRtcKitFrameworkName = "AgoraRtcKit.framework";
        const string AgorafdkaacFrameworkName = "Agorafdkaac.framework";
        const string AgoraffmpegFrameworkName = "Agoraffmpeg.framework";
        const string AgoraSoundTouchFrameworkName = "AgoraSoundTouch.framework";
        const string AgoraAIDenoiseExtensionFrameworkName = "AgoraAIDenoiseExtension.framework";
        const string AgoraCoreFrameworkName = "AgoraCore.framework";
        const string AgoraDav1dExtensionFrameworkName = "AgoraDav1dExtension.framework";
        const string AgoraJNDExtensionFrameworkName = "AgoraJNDExtension.framework";


        string AgoraRtcWrapperFrameworkPath = Path.Combine(defaultLocationInProj, AgoraRtcWrapperFrameworkName);
        string AgoraRtcKitFrameworkPath = Path.Combine(defaultLocationInProj, AgoraRtcKitFrameworkName);
        string AgorafdkaacFrameworkPath = Path.Combine(defaultLocationInProj, AgorafdkaacFrameworkName);
        string AgoraffmpegFrameworkPath = Path.Combine(defaultLocationInProj, AgoraffmpegFrameworkName);
        string AgoraSoundTouchFrameworkPath = Path.Combine(defaultLocationInProj, AgoraSoundTouchFrameworkName);
        string AgoraAIDenoiseExtensionFrameworkPath = Path.Combine(defaultLocationInProj, AgoraAIDenoiseExtensionFrameworkName);
        string AgoraCoreFrameworkPath = Path.Combine(defaultLocationInProj, AgoraCoreFrameworkName);
        string AgoraDav1dExtensionFrameworkPath = Path.Combine(defaultLocationInProj, AgoraDav1dExtensionFrameworkName);
        string AgoraJNDExtensionFrameworkPath = Path.Combine(defaultLocationInProj, AgoraJNDExtensionFrameworkName);


        string fileGuid = proj.AddFile(AgoraRtcWrapperFrameworkPath, "Frameworks/" + AgoraRtcWrapperFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraRtcKitFrameworkPath, "Frameworks/" + AgoraRtcKitFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgorafdkaacFrameworkPath, "Frameworks/" + AgorafdkaacFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraSoundTouchFrameworkPath, "Frameworks/" + AgoraSoundTouchFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraAIDenoiseExtensionFrameworkPath, "Frameworks/" + AgoraAIDenoiseExtensionFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraCoreFrameworkPath, "Frameworks/" + AgoraCoreFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);

        // Start Tag for video SDK only (If the framework is video only, please place it inside the scope)
        fileGuid = proj.AddFile(AgoraffmpegFrameworkPath, "Frameworks/" + AgoraffmpegFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraDav1dExtensionFrameworkPath, "Frameworks/" + AgoraDav1dExtensionFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraJNDExtensionFrameworkPath, "Frameworks/" + AgoraJNDExtensionFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        // End Tag

        proj.SetBuildProperty(target, "LD_RUNPATH_SEARCH_PATHS", "$(inherited) @executable_path/Frameworks");

        // done, write to the project file
        File.WriteAllText(projPath, proj.WriteToString());
    }
#endif
    /// <summary>
    ///   Update the permission 
    /// </summary>
    /// <param name="pListPath">path to the Info.plist file</param>
    static void UpdatePermission(string pListPath)
    {
#if UNITY_IPHONE
        PlistDocument plist = new PlistDocument();
        plist.ReadFromString(File.ReadAllText(pListPath));
        PlistElementDict rootDic = plist.root;
        var cameraPermission = "NSCameraUsageDescription";
        var micPermission = "NSMicrophoneUsageDescription";
        rootDic.SetString(cameraPermission, "Video need to use camera");
        rootDic.SetString(micPermission, "Voice call need to user mic");
        File.WriteAllText(pListPath, plist.WriteToString());
#endif
    }

}
#endif