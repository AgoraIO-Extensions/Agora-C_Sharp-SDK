const { execSync } = require("child_process");
const fs = require("fs");
const path = require("path");


function readFile(fullPath: string): string {
    return fs.readFileSync(fullPath, 'utf-8');
}

function writeFile(fullPath: string, lines: string[], removeMultipleBlankLines: boolean = true) {
    if (removeMultipleBlankLines) {
        let newLines = [];
        newLines.push(lines[0]);
        for (let i = 1; i < lines.length; i++) {
            if (lines[i - 1].trim() == "" && lines[i].trim() == "")
                continue;
            newLines.push(lines[i]);

        }
        fs.writeFileSync(fullPath, newLines.join("\n"), 'utf-8');
    }
    else {
        fs.writeFileSync(fullPath, lines.join("\n"), 'utf-8');
    }
}

let InterfaceDirPath = [
    "../Agora-C_Sharp-RTC-SDK/Code/Rtc",
    "../Agora-C_Sharp-RTC-SDK/Code/Rtc/Types"
];

let UnityDirPath = [
    "../Agora-C_Sharp-RTC-SDK/Code/Rtc/VideoRender/VideoSurface.cs",
    "../Agora-C_Sharp-RTC-SDK/Code/Rtc/VideoRender/VideoSurfaceYUV.cs",
    "../Agora-C_Sharp-RTC-SDK/Code/Rtc/VideoRender/VideoSurfaceYUVA.cs",
]

let DocPath = "./unity_ng_json_template_en.json";


function DeleteOldDocWithFile(filePath: string) {
    let context = fs.readFileSync(filePath, { encoding: 'utf-8' });
    let readLines = context.split('\n');
    let writeLines = [];
    for (let line of readLines) {
        let lineTrim = line.trim();
        if (lineTrim.startsWith('///') ||
            lineTrim.startsWith('//') ||
            lineTrim.startsWith('/* ') ||
            lineTrim.startsWith('/**') ||
            lineTrim.startsWith('*') ||
            lineTrim.endsWith('*/')) {
            continue;
        }
        writeLines.push(line);
    }
    writeFile(filePath, writeLines);
}

function DeleteAllOldDoc() {
    for (let dirPath of InterfaceDirPath) {
        dirPath = path.join(process.cwd(), dirPath);
        let fileList = fs.readdirSync(dirPath);
        for (let file of fileList) {
            file = path.join(dirPath, file);
            let state = fs.statSync(file);
            if (state.isFile()) {
                DeleteOldDocWithFile(file);
            }
        }
    }

    for (let filePath of UnityDirPath) {
        filePath = path.join(process.cwd(), filePath);
        DeleteOldDocWithFile(filePath);
    }
}

enum ContentType {
    None,
    //class as parameter
    Clazz,
    Enumz,
    //real interface, IRtcEngine, IRtcEngineEx like
    Apiz,
    //IAudioFrameObserver like
    Callbackz
};

interface Content {
    type: ContentType,
    name: string,
    braces: string[]
};


let RepeartMap = {};

function GetMethodName(clazzName: string, methodName: string): string {
    if (RepeartMap[`${clazzName}_${methodName}`] == undefined) {
        RepeartMap[`${clazzName}_${methodName}`] = 1;
        return methodName;
    }
    else {
        RepeartMap[`${clazzName}_${methodName}`]++;
        return methodName + RepeartMap[`${clazzName}_${methodName}`];
    }
}

function SwapIfHadObsolete(lines: string[], i: number) {
    let upLine = lines[i - 1].trim();
    if (upLine.startsWith('[Obsolete') || upLine.startsWith("#if") || upLine.startsWith('[Flags]')) {
        let temp = lines[i];
        lines[i] = lines[i - 1];
        lines[i - 1] = temp;
    }
}


function AddDocTagWithFile(filePath: string) {
    let content: Content = {
        type: ContentType.None,
        name: "",
        braces: []
    };
    let callbackSuffix = [
        "observer",
        "sink",
        "eventhandler",
        "dataprovider"
    ];
    let str = fs.readFileSync(filePath, { encoding: 'utf-8' });
    let lines = str.split('\n');
    let lineLength = lines.length;
    let i = 0;
    while (i < lineLength) {
        let line = lines[i];
        line = line.trim();
        if (content.type == ContentType.None) {
            let matchEnumArray = line.match(/^public enum ([a-zA-Z0-9_]+)/)
            if (matchEnumArray != null) {
                content.type = ContentType.Enumz;
                content.name = matchEnumArray[1].toLowerCase().replaceAll('_', '');
                lines.splice(i, 0, `/* enum_${content.name} */`);
                SwapIfHadObsolete(lines, i);
                i = i + 2;
                lineLength++;
                continue;
            }
            let matchClassArray = line.match(/^public class ([a-zA-Z0-9_]+)/)
            if (matchClassArray != null) {
                content.type = ContentType.Clazz;
                content.name = matchClassArray[1].toLowerCase().replaceAll('_', '');
                lines.splice(i, 0, `/* class_${content.name} */`);
                SwapIfHadObsolete(lines, i);
                i = i + 2;
                lineLength++;
                continue;
            }
            let matchApiArray = line.match(/^public abstract class ([a-zA-Z0-9_]+)/);
            if (matchApiArray != null) {
                let clazzName = matchApiArray[1].toLowerCase().replaceAll('_', '');
                let isCallback = callbackSuffix.some((e) => {
                    return clazzName.endsWith(e);
                });
                if (isCallback) {
                    content.type = ContentType.Callbackz;
                }
                else {
                    content.type = ContentType.Apiz;
                }
                content.name = clazzName;
                lines.splice(i, 0, `/* class_${content.name} */`);
                SwapIfHadObsolete(lines, i);
                i = i + 2;
                lineLength++;
                continue;
            }
        }
        else if (content.type == ContentType.Enumz) {
            if (line.endsWith(',')) {
                let enumParamName: string;
                if (line.includes('=')) {
                    enumParamName = line.substring(0, line.indexOf('='));
                }
                else {
                    enumParamName = line.substring(0, line.indexOf(','))
                }
                enumParamName = enumParamName.trim();
                lines.splice(i, 0, `/* enum_${content.name}_${enumParamName} */`)
                SwapIfHadObsolete(lines, i);
                i = i + 2;
                lineLength++;
                continue;
            }
        }
        else if (content.type == ContentType.Clazz) {
            let matchParamsArray = line.match(/^public ([a-zA-Z0-9_<>\[\]]+) ([a-zA-Z0-9_]+)(;| =)/)
            if (matchParamsArray != null) {
                lines.splice(i, 0, `/* class_${content.name}_${matchParamsArray[2]} */`);
                SwapIfHadObsolete(lines, i);
                i = i + 2;
                lineLength++;
                continue;
            }
            matchParamsArray = line.match(/^public event (\S+) (\S+);/)
            if (matchParamsArray != null) {
                let apiName = matchParamsArray[2].toLowerCase();
                lines.splice(i, 0, `/* callback_${content.name}_${apiName} */`);
                SwapIfHadObsolete(lines, i);
                i = i + 2;
                lineLength++;
                continue;
            }
            let matchApiArray = line.match(/^public (virtual|abstract) ([\S]+) ([a-zA-Z0-9_]+)\([\s\S]*\)/)
            if (matchApiArray != null) {
                let apiName = matchApiArray[3].toLowerCase();
                apiName = GetMethodName(content.name, apiName);
                lines.splice(i, 0, `/* api_${content.name}_${apiName} */`);
                SwapIfHadObsolete(lines, i);
                i = i + 2;
                lineLength++;
                continue;
            }
        }
        else if (content.type == ContentType.Apiz) {
            let matchApiArray = line.match(/^public abstract ([\S]+) ([a-zA-Z0-9_]+)\([\s\S]*\)/)
            if (matchApiArray != null) {
                let apiName = matchApiArray[2].toLowerCase();
                apiName = GetMethodName(content.name, apiName);
                lines.splice(i, 0, `/* api_${content.name}_${apiName} */`);
                SwapIfHadObsolete(lines, i);
                i = i + 2;
                lineLength++;
                continue;
            }
        }
        else if (content.type == ContentType.Callbackz) {
            let matchApiArray = line.match(/^public (virtual|abstract) ([\S]+) ([a-zA-Z0-9_]+)\([\s\S]*\)/)
            if (matchApiArray != null) {
                let apiName = matchApiArray[3].toLowerCase();
                apiName = GetMethodName(content.name, apiName);
                lines.splice(i, 0, `/* callback_${content.name}_${apiName} */`);
                SwapIfHadObsolete(lines, i);
                i = i + 2;
                lineLength++;
                continue;
            }

        }

        if (content.type != ContentType.None) {
            if (line.includes('{')) {
                content.braces.push('{')
            }
            else if (line.includes('}')) {
                content.braces.pop();
                if (content.braces.length == 0) {
                    content.type = ContentType.None;
                    content.name = "";
                }
            }
        }
        i++;
    }

    writeFile(filePath, lines);
}


function AddAllDocTag() {
    for (let dirPath of InterfaceDirPath) {
        dirPath = path.join(process.cwd(), dirPath);
        let fileList = fs.readdirSync(dirPath);
        for (let file of fileList) {
            file = path.join(dirPath, file);
            let state = fs.statSync(file);
            if (state.isFile()) {
                AddDocTagWithFile(file);
            }
        }
    }

    for (let filePath of UnityDirPath) {
        filePath = path.join(process.cwd(), filePath);
        AddDocTagWithFile(filePath);
    }
}

interface DocData {
    id: string,
    name: string,
    description: string,
    parameters: any[],
    returns: string,
    is_hide: boolean
};

function SplitDocTag(str: string): { clazzName: string, paramName: string | null } {
    let splitArray = str.split("_");
    if (splitArray.length == 2) {
        return { clazzName: splitArray[1], paramName: null };
    }
    else {
        let clazzName = splitArray[1];
        splitArray.shift();
        splitArray.shift();
        let paramName = splitArray.join('_');
        return { clazzName, paramName };
    }
}

function GetDocs(): DocData[] {
    let docPath = path.join(process.cwd(), DocPath);
    let str = fs.readFileSync(docPath, { encoding: 'utf-8' });
    str = SwapString(str, "api_irtcengine_enableextension", "api_irtcengine_enableextension2");
    str = SwapString(str, "api_irtcengine_setextensionproperty", "api_irtcengine_setextensionproperty2");
    str = str.replaceAll("iaudioframeobserverbase", "iaudioframeobserver")
    str = str.replaceAll("api_iaudioframeobserver", "callback_iaudioframeobserver")
    str = str.replaceAll("ibasespatialaudioengine", "ilocalspatialaudioengine")
    str = str.replaceAll("api_imediaengine", "api_irtcengine")
    str = str.replaceAll("pushaudioframe0", "pushaudioframe")
    str = str.replaceAll("\"api_irtcengine_enabledualstreammode2\"", "\"api_irtcengine_delete\"")
    str = str.replaceAll("\"api_irtcengine_enabledualstreammode3\"", "\"api_irtcengine_enabledualstreammode2\"")
    str = str.replaceAll("\"api_getmediaplayercachemanager\"", "\"api_irtcengine_getmediaplayercachemanager\"")
    str = str.replaceAll("\"api_iagoraparameter_setparameters\"", "\"api_irtcengine_setparameters2\"")
    str = str.replaceAll("\"api_irtcengine_getnativehandle\"", "\"api_irtcengine_getnativehandler\"")
    str = str.replaceAll("class_deviceinfo", "class_deviceinfomobile")
    str = str.replaceAll("class_videodeviceinfo", "class_deviceinfo")
    str = str.replaceAll("api_irtcengine_addhandler", "api_irtcengine_initeventhandler");
    str = str.replaceAll("api_irtcengine_playeffect2", "api_irtcengine_playeffect");
    str = str.replaceAll("api_irtcengine_setremoterendermode2", "api_irtcengine_setremoterendermode");
    str = str.replaceAll("api_irtcengine_setremoterendermode2", "api_irtcengine_enableinearmonitoring");
    str = str.replaceAll("api_imediaengine_setexternalaudiosource2", "api_irtcengine_setexternalaudiosource");
    str = str.replaceAll("callback_idirectcdnstreamingeventhandler_ondirectcdnstreamingstatechanged", "callback_irtcengineeventhandler_ondirectcdnstreamingstatechanged");
    str = str.replaceAll("callback_idirectcdnstreamingeventhandler_ondirectcdnstreamingstats", "callback_irtcengineeventhandler_ondirectcdnstreamingstats");
    str = str.replaceAll("api_Imediaplayer_selectmultiaudiotrack", "api_imediaplayer_selectmultiaudiotrack");
    str = str.replaceAll("api_imediaengine_registerfaceinfoobserver", "api_irtcengine_registerfaceinfoobserver");
    str = str.replaceAll("api_imediaengine_unregisterfaceinfoobserver", "api_irtcengine_unregisterfaceinfoobserver");
    str = str.replaceAll("api_irtcengine_startechotest3", "api_irtcengine_startechotest");


    fs.writeFileSync(path.join(process.cwd(), "process_json"), str);

    let obj = JSON.parse(str);
    return obj as DocData[];
}

function SwapString(src: string, str1: string, str2: string): string {
    src = src.replace(str1, "ABCDEF");
    src = src.replace(str2, str1);
    src = src.replace("ABCDEF", str2);
    return src;
}




function FindDocWithId(id: string, docs: DocData[]) {
    return docs.find((e) => { return e.id == id });
}

function GenerateEnumOrClassDoc(doc: DocData) {
    let lines = [];
    if (doc == null || doc.is_hide) {
        lines.push(`///`);
        lines.push(`/// @ignore`);
        lines.push(`///`);
    }
    else {
        lines.push(`///`);
        lines.push(`/// <summary>`);
        let splitLines = doc.description.split('\n');
        for (let e of splitLines) {
            lines.push(`/// ${e}`);
        }
        lines.push(`/// </summary>`);
        lines.push(`///`);
    }
    return lines.join('\n');
}

function GenerateEnumOrClassParamDoc(doc: DocData, paramName: string) {
    let lines = [];
    let result: any = null;
    if (doc) {
        let parameters = doc.parameters;
        result = parameters.find((e) => {
            return e[paramName] != undefined
        });
    }

    if (doc == null || doc.is_hide || result == null) {
        lines.push(`///`);
        lines.push(`/// @ignore`);
        lines.push(`///`);
    }
    else {
        lines.push(`///`);
        lines.push(`/// <summary>`);
        let splitLines = result[paramName].split('\n');
        for (let e of splitLines) {
            lines.push(`/// ${e}`);
        }
        lines.push(`/// </summary>`);
        lines.push(`///`);
    }
    return lines.join('\n');
}

function GenerateCallbackOrApi(doc: DocData): string {
    let lines = [];
    if (doc == null || doc.is_hide) {
        lines.push(`///`);
        lines.push(`/// @ignore`);
        lines.push(`///`);
    }
    else {
        lines.push(`///`);
        lines.push(`/// <summary>`);
        let splitLines = doc.description.split('\n');
        for (let e of splitLines) {
            lines.push(`/// ${e.trim()}`);
        }
        lines.push(`/// </summary>`);

        if (doc.parameters.length > 0) {
            lines.push(`///`);
            for (let i = 0; i < doc.parameters.length; i++) {
                let e = doc.parameters[i];
                let keys = Object.keys(e);
                let key = keys[0];
                if (key == null) {
                    console.error('error id ' + doc.id);
                    continue;
                }
                let paramArray = e[key].split('\n');
                if (paramArray.length == 1) {
                    lines.push(`/// <param name="${key}"> ${e[key].trim()} </param>`);
                }
                else {
                    lines.push(`/// <param name="${key}">`);
                    for (let eachParam of paramArray) {
                        lines.push(`/// ${eachParam.trim()}`);
                    }
                    lines.push(`/// </param>`);
                }

                if (i != doc.parameters.length - 1) {
                    lines.push(`///`);
                }
            }
        }

        if (doc.returns != "") {
            lines.push(`///`);
            lines.push(`/// <returns>`);
            let splitArray = doc.returns.split('\n');
            for (let r of splitArray) {
                r = r.replaceAll("<", "&lt;").replaceAll(">", "&gt;");
                lines.push(`/// ${r.trim()}`);
            }
            lines.push(`/// </returns>`);
        }

        lines.push(`///`);
    }
    return lines.join('\n');

}


function AddDocContentWithFile(filePath: string, docs: DocData[]) {
    let str = fs.readFileSync(filePath, { encoding: 'utf-8' });
    let lines = str.split('\n');
    for (let i = 0; i < lines.length; i++) {
        let line = lines[i].trim();
        let matchDocTagArray = line.match(/^\/\* ([a-zA-Z0-9_]+) \*\//);
        if (matchDocTagArray != null) {
            let id = matchDocTagArray[1];

            let { clazzName, paramName } = SplitDocTag(id);
            if (paramName == null) {
                let doc: DocData = FindDocWithId(id, docs);
                lines[i] = GenerateEnumOrClassDoc(doc);
            }
            else if (id.startsWith('enum') || id.startsWith('class')) {
                let doc: DocData = FindDocWithId(`${id.split('_')[0]}_${clazzName}`, docs);
                lines[i] = GenerateEnumOrClassParamDoc(doc, paramName);
            }
            else if (id.startsWith('callback') || id.startsWith('api')) {
                let doc: DocData = FindDocWithId(id, docs);
                lines[i] = GenerateCallbackOrApi(doc);
            }
        }
    }

    writeFile(filePath, lines);
}

function AddAllDocContetnt() {
    let docs = GetDocs();
    for (let dirPath of InterfaceDirPath) {
        dirPath = path.join(process.cwd(), dirPath);
        let fileList = fs.readdirSync(dirPath);
        for (let file of fileList) {
            file = path.join(dirPath, file);
            let state = fs.statSync(file);
            if (state.isFile()) {
                AddDocContentWithFile(file, docs);
            }
        }
    }

    for (let filePath of UnityDirPath) {
        filePath = path.join(process.cwd(), filePath);
        AddDocContentWithFile(filePath, docs);
    }
}

function removeAllFileKeyWord(from: string, to: string) {
    for (let dirPath of InterfaceDirPath) {
        dirPath = path.join(process.cwd(), dirPath);
        let fileList = fs.readdirSync(dirPath);
        for (let file of fileList) {
            file = path.join(dirPath, file);
            let state = fs.statSync(file);
            if (state.isFile()) {
                replaceKeyWord(file, from, to);
            }
        }
    }

    for (let filePath of UnityDirPath) {
        filePath = path.join(process.cwd(), filePath);
        replaceKeyWord(filePath, from, to);
    }

}

function replaceKeyWord(fullPath: string, from: string, to: string) {
    let str = readFile(fullPath);
    str = str.replaceAll(from, to);
    fs.writeFileSync(fullPath, str);
}


let unityDefine = "#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS";

function AndDocAndFormat() {
    DeleteAllOldDoc();
    AddAllDocTag();
    AddAllDocContetnt();
    removeAllFileKeyWord(unityDefine, "#if true");
    execSync("dotnet format ../Agora-C_Sharp_RTC-SDK_UT/Agora_C_Sharp_SDK_UT.sln");
    removeAllFileKeyWord("#if true", unityDefine);
}


AndDocAndFormat();








