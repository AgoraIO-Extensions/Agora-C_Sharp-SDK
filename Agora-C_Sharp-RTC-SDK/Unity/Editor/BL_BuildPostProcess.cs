#define AGORA_RTC


using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Linq;
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
using UnityEngine.Profiling;
using Unity.Mathematics;
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
            string agoraError = "[Agora Error] Motify Open Harmony Project failed. Please contact Agora technical support";

            var buildProfileJson5FilePaths = Directory.GetFiles(path, "build-profile.json5", SearchOption.TopDirectoryOnly);
            if (buildProfileJson5FilePaths.Length > 0)
            {
                MotifyJsonFile(buildProfileJson5FilePaths[0], (jsonData) =>
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
            }
            else
            {
                Debug.LogError(agoraError);
            }


            string entryBuildProfileJson5Path = FindFileInDevEco(path, "build-profile.json5");
            if (entryBuildProfileJson5Path != null)
            {
                MotifyJsonFile(entryBuildProfileJson5Path, (jsonData) =>
                {
                    Agora.Rtc.LitJson.JsonData buildOption = jsonData.ContainsKey("buildOption") ?
                        jsonData["buildOption"] :
                        new Agora.Rtc.LitJson.JsonData();

                    // 处理 buildOption.arkOptions.runtimeOnly.packages（将旧包名替换为新包名）
                    if (buildOption.ContainsKey("arkOptions"))
                    {
                        var arkOptions = buildOption["arkOptions"];
                        if (arkOptions.ContainsKey("runtimeOnly"))
                        {
                            var runtimeOnly = arkOptions["runtimeOnly"];
                            if (runtimeOnly.ContainsKey("packages"))
                            {
                                var packages = runtimeOnly["packages"];
                                if (packages.IsArray)
                                {
                                    for (int i = 0; i < packages.Count; i++)
                                    {
                                        string packageName = (string)packages[i];
                                        if (packageName == "AgoraRtcWrapper")
                                        {
                                            packages[i] = "@shengwang/rtc-wrapper";
                                            Debug.Log("[Agora] Replace package: AgoraRtcWrapper -> @shengwang/rtc-wrapper");
                                        }
                                        else if (packageName.StartsWith("AgoraRtcSdk") || packageName.StartsWith("Agora") || packageName.StartsWith("agora"))
                                        {
                                            packages[i] = "@shengwang/rtc-full";
                                            Debug.Log("[Agora] Replace package: " + packageName + " -> @shengwang/rtc-full");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    return "update packages in entry build-profile.json5";
                });
            }
            else
            {
                Debug.LogError(agoraError);
            }


            string OhPackageJson5Path = FindFileInDevEco(path, "oh-package.json5");
            if (OhPackageJson5Path != null)
            {
                MotifyJsonFile(OhPackageJson5Path, (jsonData) =>
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
            }
            else
            {
                Debug.LogError(agoraError);
            }

            string moduleJson5Path = FindFileInDevEco(path, "module.json5");
            if (moduleJson5Path != null)
            {
                MotifyJsonFile(Path.Combine(path, moduleJson5Path), (jsonData) =>
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
            }
            else
            {
                Debug.LogError(agoraError);
            }


            var mainWorkerPath = FindFileInDevEco(path, "TuanjieMainWorker.ets");
            if (mainWorkerPath != null)
            {
                InsertCodeIntoFile(mainWorkerPath, 0, "import { AgoraRtcWrapperNative } from '../AgoraRtcWrapperNative';");
                InsertCodeIntoFileAppendSearchCode(mainWorkerPath,
                    "workerPort.onmessage",
                    "  // The worker thread handles Agora response messages from the OpenHarmony Main/UI thread.\n  if (AgoraRtcWrapperNative.onMessage(e) == true) { return; }");
            }
            else
            {
                Debug.LogError(agoraError);
            }


            var workerProxyPath = FindFileInDevEco(path, "WorkerProxy.ets");
            if (workerProxyPath != null)
            {
                InsertCodeIntoFile(workerProxyPath, 0, "import { AgoraRtcWrapperNativeRunInMainThread } from '../AgoraRtcWrapperNative';");
                InsertCodeIntoFileAppendSearchCode(workerProxyPath,
                    "this.threadWorker.onmessage",
                    "      // The OpenHarmony Main/UI thread handles messages coming from the worker thread.\n      if (AgoraRtcWrapperNativeRunInMainThread.onMessage(msg) == true) { return; }");
            }
            else
            {
                Debug.LogError(agoraError);
            }

            var tuanjieJSScriptRegisterPath = FindFileInDevEco(path, "TuanjieJSScriptRegister.ets");
            if (tuanjieJSScriptRegisterPath != null)
            {
                DeleteCodeFromFile(tuanjieJSScriptRegisterPath, "import 'AgoraRtc");
            }
            else
            {
                Debug.LogError(agoraError);
            }


        }


        public static string FindFileInDevEco(string rootPath, string file)
        {

            var filePaths = Directory.GetFiles(rootPath, file, SearchOption.AllDirectories);
            filePaths = filePaths.Where(filePath => !filePath.Contains("oh_modules") && !filePath.Contains("hvigor")).ToArray();

            // 优先查找 entry 目录（新结构）
            string filePath = filePaths.FirstOrDefault(filePath => filePath.Contains("entry"));
            // 如果找不到，尝试查找 tuanjieLib 目录
            if (filePath == null)
            {
                filePath = filePaths.FirstOrDefault(filePath => filePath.Contains("tuanjieLib"));
            }
            // 如果还是找不到，返回第一个匹配的文件（兼容旧结构）
            if (filePath == null && filePaths.Length > 0)
            {
                filePath = filePaths[0];
            }
            return filePath;
        }


        public static void InsertCodeIntoFile(string filePath, int line, string code)
        {
            // Read all lines from the file into a list
            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            // Insert the code at the specified line
            lines.Insert(line, code);

            // Write the modified lines back to the file
            File.WriteAllLines(filePath, lines);
        }

        public static void InsertCodeIntoFileAppendSearchCode(string filePath, string searchCode, string code)
        {
            // Read all lines from the file into a list
            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            // Find the first line that contains the searchCode
            int lineIndex = -1;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(searchCode))
                {
                    lineIndex = i;
                    break;
                }
            }

            // If the searchCode is found, insert the code on the next line
            if (lineIndex != -1)
            {
                // Split code by newlines to support multi-line insertion
                string[] codeLines = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                
                // Insert the code lines on the next line (in reverse order to maintain correct order)
                for (int i = codeLines.Length - 1; i >= 0; i--)
                {
                    lines.Insert(lineIndex + 1, codeLines[i]);
                }

                // Write the modified lines back to the file
                File.WriteAllLines(filePath, lines);
            }
            else
            {
                string agoraError = "[Agora Error] Motify Open Harmony Project failed. Please contact Agora technical support";
                Debug.LogError(agoraError);
            }
        }


        public static void DeleteCodeFromFile(string filePath, string searchCode)
        {
            // Read all lines from the file into a list
            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            // Filter out lines that contain the searchCode
            lines.RemoveAll(line => line.Contains(searchCode));

            // Write the modified lines back to the file
            File.WriteAllLines(filePath, lines);

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

