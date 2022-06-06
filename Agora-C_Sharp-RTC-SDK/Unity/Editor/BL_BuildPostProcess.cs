using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

#if UNITY_IOS
using UnityEditor.iOS.Xcode;
using UnityEditor.iOS.Xcode.Extensions;
#endif

using UnityEngine;

public class BL_BuildPostProcess
{
    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget buildTarget, string path)
    {
        if (buildTarget == BuildTarget.iOS)
        {
#if UNITY_IOS
            LinkLibraries(path);
            UpdatePermission(path + "/Info.plist");
#endif
        }
    }

    //public static void DisableBitcode(string projPath)
    //{
    //    PBXProject proj = new PBXProject();
    //    proj.ReadFromString(File.ReadAllText(projPath));

//    string target = GetTargetGuid(proj);
//    proj.SetBuildProperty(target, "ENABLE_BITCODE", "false");
//    File.WriteAllText(projPath, proj.WriteToString());
//}

#if UNITY_IOS
    static string GetTargetGuid(PBXProject proj)
    {
#if UNITY_2019_3_OR_NEWER
        return proj.GetUnityMainTargetGuid();
#else
        return proj.TargetGuidByName("Unity-iPhone");
#endif
    }
#endif

#if UNITY_IOS
    static void LinkLibraries(string path)
    {
        // linked library
        string projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
        PBXProject proj = new PBXProject();
        proj.ReadFromFile(projPath);
        string target = GetTargetGuid(proj);


        string defaultLocationInProj = "Agora-RTC-Plugin/Agora-Unity-RTC-SDK/Plugins/iOS";

        DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(path, "Frameworks/"+ defaultLocationInProj));
        FileInfo[] fileInfos = directoryInfo.GetFiles();
        DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();

        Debug.Log("fileInfo:"+ fileInfos.Length);
        List<string> frameworks = new List<string>();
        foreach (var fileInfo in fileInfos)
        {
            frameworks.Add(fileInfo.Name);
            //Debug.Log(fileInfo.Name);
        }

        foreach (var fileInfo in directoryInfos)
        {
            frameworks.Add(fileInfo.Name);
            //Debug.Log(fileInfo.Name);
        }


        foreach (var file in frameworks)
        {
            string fullPath = Path.Combine(defaultLocationInProj, file);
            string fileGuid = proj.AddFile(fullPath, "Frameworks/" + fullPath, PBXSourceTree.Sdk);
            PBXProjectExtensions.AddFileToEmbedFrameworks(proj, target, fileGuid);
        }

       
        proj.SetBuildProperty(target, "LD_RUNPATH_SEARCH_PATHS", "$(inherited) @executable_path/Frameworks");

        // done, write to the project file
        File.WriteAllText(projPath, proj.WriteToString());
    }

    static void UpdatePermission(string pListPath)
    {

        PlistDocument plist = new PlistDocument();
        plist.ReadFromString(File.ReadAllText(pListPath));
        PlistElementDict rootDic = plist.root;
        var cameraPermission = "NSCameraUsageDescription";
        var micPermission = "NSMicrophoneUsageDescription";
        rootDic.SetString(cameraPermission, "Video need to use camera");
        rootDic.SetString(micPermission, "Voice call need to user mic");
        File.WriteAllText(pListPath, plist.WriteToString());
    }
#endif
}

