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
        const string AgoraffmpegFrameworkName = "Agoraffmpeg.framework";
        const string AgoraVideoProcessFrameworkName = "AgoraVideoProcessExtension.framework";
        const string AgoraPvcExtensionFrameworkName = "AgoraPvcExtension.framework";
        const string AgoraRtcCryptoLoaderFrameworkName = "AgoraRtcCryptoLoader.framework";
        const string AgoraRtmKitFrameworkName = "AgoraRtmKit.framework";
        const string AgoraVideoSegmentationExtensionFrameworkName = "AgoraVideoSegmentationExtension.framework";
        const string BeQuicFrameworkName = "BeQuic.framework";
        const string AgoraRtmLoaderFramework = "AgoraRtmLoader.framework";


        string AgoraRtcWrapperFrameworkPath = Path.Combine(defaultLocationInProj, AgoraRtcWrapperFrameworkName);
        string AgoraRtcKitFrameworkPath = Path.Combine(defaultLocationInProj, AgoraRtcKitFrameworkName);
        string AgoraffmpegFrameworkPath = Path.Combine(defaultLocationInProj, AgoraffmpegFrameworkName);
        string AgoraVideoProcessPath = Path.Combine(defaultLocationInProj, AgoraVideoProcessFrameworkName);
        string AgoraPvcExtensionPath = Path.Combine(defaultLocationInProj, AgoraPvcExtensionFrameworkName);
        string AgoraRtcCryptoLoaderPath = Path.Combine(defaultLocationInProj, AgoraRtcCryptoLoaderFrameworkName);
        string AgoraRtmKitPath = Path.Combine(defaultLocationInProj, AgoraRtmKitFrameworkName);
        string AgoraVideoSegmentationExtensionPath = Path.Combine(defaultLocationInProj, AgoraVideoSegmentationExtensionFrameworkName);
        string BeQuicPath = Path.Combine(defaultLocationInProj, BeQuicFrameworkName);
        string AgoraRtmLoaderPath = Path.Combine(defaultLocationInProj, AgoraRtmLoaderFramework); ;


        string fileGuid = proj.AddFile(AgoraRtcWrapperFrameworkPath, "Frameworks/" + AgoraRtcWrapperFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraRtcKitFrameworkPath, "Frameworks/" + AgoraRtcKitFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraPvcExtensionPath, "Frameworks/" + AgoraPvcExtensionPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraRtcCryptoLoaderPath, "Frameworks/" + AgoraRtcCryptoLoaderPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraRtmKitPath, "Frameworks/" + AgoraRtmKitPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(BeQuicPath, "Frameworks/" + BeQuicPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraRtmLoaderPath, "Frameworks/" + AgoraRtmLoaderPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);


        // Start Tag for video SDK only (If the framework is video only, please place it inside the scope)
        fileGuid = proj.AddFile(AgoraffmpegFrameworkPath, "Frameworks/" + AgoraffmpegFrameworkPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraVideoProcessPath, "Frameworks/" + AgoraVideoProcessPath, PBXSourceTree.Sdk);
        PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        fileGuid = proj.AddFile(AgoraVideoSegmentationExtensionPath, "Frameworks/" + AgoraVideoSegmentationExtensionPath, PBXSourceTree.Sdk);
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