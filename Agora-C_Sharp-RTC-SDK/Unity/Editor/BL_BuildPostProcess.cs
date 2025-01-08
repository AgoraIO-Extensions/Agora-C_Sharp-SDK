#define AGORA_RTC


using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
#if UNITY_IOS || UNITY_VISIONOS
using UnityEditor.iOS.Xcode;
using UnityEditor.iOS.Xcode.Extensions;
#endif
using UnityEngine;

#if UNITY_OPENHARMONY
using UnityEditor.OpenHarmony;
using System;
using System.Text;
using System.Reflection;
#endif


#if AGORA_RTC
namespace Agora.Rtc
#else
namespace Agora.Rtm
#endif
{
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

#if UNITY_VISIONOS
            if (buildTarget == BuildTarget.VisionOS)
            {
                UpdatePermission(path + "/Info.plist");
            }
#endif

#if UNITY_OPENHARMONY
            if (buildTarget == BuildTarget.OpenHarmony)
            {
                if (!EditorUserBuildSettings.exportAsOpenHarmonyProject)
                {
                    Debug.LogError("[Agora] only support export OpenHarmonyProject!!! Please check Build Settings");
                }
                else
                {
                    MotifyOpenHarmmonyProject(path);
                }


            }
#endif
        }


#if UNITY_OPENHARMONY
        public static void MotifyOpenHarmmonyProject(string path)
        {
            Debug.Log("[Agora] motify OpenHarmoney project start");
            Debug.Log("[Agora] project path: " + path);

            MotifyJsonFile(Path.Combine(path, "build-profile.json5"), (jsonData) =>
            {
                var products = (Agora.Rtc.LitJson.JsonData)jsonData["app"]["products"][0];
                Agora.Rtc.LitJson.JsonData buildOption = products.ContainsKey("buildOption") ?
                    products["buildOption"] :
                    new Agora.Rtc.LitJson.JsonData();
                Agora.Rtc.LitJson.JsonData strictMode = buildOption.ContainsKey("strictMode") ? buildOption["strictMode"] : new Agora.Rtc.LitJson.JsonData();
                strictMode["useNormalizedOHMUrl"] = true;
                buildOption["strictMode"] = strictMode;
                products["buildOption"] = buildOption;
                return "add useNormalizedOHMUrl = true";
            });

            MotifyJsonFile(Path.Combine(path, "entry/oh-package.json5"), (jsonData) =>
            {
                jsonData["useNormalizedOHMUrl"] = true;
                Agora.Rtc.LitJson.JsonData dependencies = (Agora.Rtc.LitJson.JsonData)jsonData["dependencies"];
                var dependenciesKeys = dependencies.Keys;
                var keys = new List<string>();
                foreach (var key in dependenciesKeys) { keys.Add(key); }

                foreach (var key in keys)
                {
                    if (key == "AgoraRtcWrapper")
                    {
                        dependencies["@shengwang/rtc-wrapper"] = (string)dependencies[key];
                        dependencies.Remove(key);
                    }
                    else if (key.StartsWith("Agora") || key.StartsWith("agora"))
                    {
                        dependencies["@shengwang/rtc-full"] = (string)dependencies[key];
                        dependencies.Remove(key);
                    }
                }
                return "motify dependencices success";
            });

            MotifyJsonFile(Path.Combine(path, "entry/src/main/module.json5"), (jsonData) =>
            {
                string scriptPath = Assembly.GetExecutingAssembly().Location;
                string scriptDirectory = Path.GetDirectoryName(scriptPath);

                string assetsPath = Application.dataPath;
                string permissionPath = Path.Combine(assetsPath, "Agora-RTC-Plugin/Agora-Unity-RTC-SDK/Plugins/OpenHarmony/AgoraPermission.json");

                var permissionsString = File.ReadAllText(permissionPath);
                var permissionsList = Agora.Rtc.LitJson.JsonMapper.ToObject(permissionsString);

                var requestPermissions = (Agora.Rtc.LitJson.JsonData)jsonData["module"]["requestPermissions"];
                for (var i = 0; i < permissionsList.Count; i++)
                {
                    var e = (Agora.Rtc.LitJson.JsonData)permissionsList[i];
                    requestPermissions.Add(e);
                    Debug.Log("[Agora] add permission: " + (string)e["name"]);
                }
                return "add requestPermissions success";
            });

            var mainWorkerPath = Path.Combine(path, "entry/src/main/ets/workers/TuanjieMainWorker.ets");
            var mainWorkerString = File.ReadAllText(mainWorkerPath);
            mainWorkerString = mainWorkerString.Replace("import worker from '@ohos.worker';",
                "import worker from '@ohos.worker'; \nimport { AgoraRtcWrapperNativeRunInMainThread} from '../AgoraRtcWrapperNative';");
            mainWorkerString = mainWorkerString.Replace("this.threadWorker.onmessage = (msg) => {",
                " this.threadWorker.onmessage = (msg) => { \n if(AgoraRtcWrapperNativeRunInMainThread.onMessage(msg) == true) {\n        return;\n      }");
            File.WriteAllText(mainWorkerPath, mainWorkerString);
            Debug.LogFormat("[Agora] motify sucess: {0}", mainWorkerPath);

            var mainWorkerHandlerPath = Path.Combine(path, "entry/src/main/ets/workers/TuanjieMainWorkerHandler.ets");
            var mainWorkerHandlerString = File.ReadAllText(mainWorkerHandlerPath);
            mainWorkerHandlerString = mainWorkerHandlerString.Replace("import worker from '@ohos.worker';",
                "import worker from '@ohos.worker'; \nimport { AgoraRtcWrapperNative } from '../AgoraRtcWrapperNative'");
            mainWorkerHandlerString = mainWorkerHandlerString.Replace("workerPort.onmessage = (e)=> {", "" +
                "workerPort.onmessage = (e)=> { \n   if(AgoraRtcWrapperNative.onMessage(e) == true){\n    return;\n  }");
            File.WriteAllText(mainWorkerHandlerPath, mainWorkerHandlerString);
            Debug.LogFormat("[Agora] motify sucess: {0}", mainWorkerHandlerPath);

        }


        public static void MotifyJsonFile(string path, Func<Agora.Rtc.LitJson.JsonData, string> action)
        {
            string fileContext = File.ReadAllText(path);
            Agora.Rtc.LitJson.JsonData jsonData = Agora.Rtc.LitJson.JsonMapper.ToObject(fileContext);
            string ret = action(jsonData);
            StringBuilder sb = new StringBuilder();
            Agora.Rtc.LitJson.JsonWriter writer = new Agora.Rtc.LitJson.JsonWriter(sb);
            writer.PrettyPrint = true;
            jsonData.ToJson(writer);
            fileContext = sb.ToString();
            File.WriteAllText(path, fileContext);
            Debug.LogFormat("file:{0} motify {1}", path, ret);
        }
#endif



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
#endif


#if UNITY_VISIONOS || UNITY_IOS
    static void UpdatePermission(string pListPath)
    {
        PlistDocument plist = new PlistDocument();
        plist.ReadFromString(File.ReadAllText(pListPath));
        PlistElementDict rootDic = plist.root;
#if AGORA_RTC
        var cameraPermission = "NSCameraUsageDescription";
        var micPermission = "NSMicrophoneUsageDescription";
        rootDic.SetString(cameraPermission, "Video need to use camera");
        rootDic.SetString(micPermission, "Voice call need to user mic");
#endif
        File.WriteAllText(pListPath, plist.WriteToString());
    }     
#endif

    }
}

