import { Clazz, SimpleType, CXXTYPE, Enumz, Struct, CXXTerraNode, Variable } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, TerraNode, } from "@agoraio-extensions/terra-core";
import { CustomHead, ProcessRawData } from "../rtc/type_definition";
import { typeConversionTable } from "../config/common/type_conversion_table.config";
import { StringProcess } from "./string_process";
import { processMethodReturnTypeString } from "./method_process";
import { processMethodParameterFormalVariableDefaultValue, processMethodParameterFormalVariableType } from "./method_parameter_process";

export function isInterface(node: CXXTerraNode): boolean {
    if (node.__TYPE != CXXTYPE.Clazz)
        return false;

    const name = node.name;
    if (!name.startsWith("I"))
        return false;

    if (name.endsWith("Observer") ||
        name.endsWith("Sink") ||
        name.endsWith("EventHandler") ||
        name.endsWith("Provider"))
        return false;

    return true;
}

export function isCallback(node: CXXTerraNode): boolean {
    if (node.__TYPE != CXXTYPE.Clazz)
        return false;

    const name = node.name;
    if (!name.startsWith("I"))
        return false;

    if (name.endsWith("Observer") ||
        name.endsWith("Sink") ||
        name.endsWith("EventHandler") ||
        name.endsWith("Provider"))
        return true;

    return false;
}

export function isEnumz(type: SimpleType | Variable | CXXTerraNode | string): boolean {
    if (typeof type === 'string') {
        let clonedParseResult: ParseResult = global.clonedParseResult;
        let node = clonedParseResult.resolveNodeByName(type);
        return node.__TYPE == CXXTYPE.Enumz;
    }
    else if (type instanceof SimpleType || type instanceof Variable) {
        let realType = type instanceof Variable ? type.type : type;
        const clonedParseResult: ParseResult = global.clonedParseResult;
        const node = clonedParseResult.resolveNodeByType(realType);
        return node.__TYPE == CXXTYPE.Enumz;
    }
    else {
        return type.__TYPE == CXXTYPE.Enumz;
    }
}

export function isStructOrClazz(type: SimpleType | Variable | CXXTerraNode | string): boolean {
    if (typeof type === 'string') {
        let clonedParseResult: ParseResult = global.clonedParseResult;
        let node = clonedParseResult.resolveNodeByName(type);
        return node.__TYPE == CXXTYPE.Struct || node.__TYPE == CXXTYPE.Clazz;
    }
    else if (type instanceof SimpleType || type instanceof Variable) {
        let realType = type instanceof Variable ? type.type : type;
        const clonedParseResult: ParseResult = global.clonedParseResult;
        const node = clonedParseResult.resolveNodeByType(realType);
        return node.__TYPE == CXXTYPE.Struct || node.__TYPE == CXXTYPE.Clazz;
    }
    else {

        return type.__TYPE == CXXTYPE.Struct || type.__TYPE == CXXTYPE.Clazz;
    }
}

export function isStruct(type: SimpleType | Variable | CXXTerraNode | string): boolean {
    if (typeof type === 'string') {
        let clonedParseResult: ParseResult = global.clonedParseResult;
        let node = clonedParseResult.resolveNodeByName(type);
        return node.__TYPE == CXXTYPE.Struct;
    }
    else if (type instanceof SimpleType || type instanceof Variable) {
        let realType = type instanceof Variable ? type.type : type;
        const clonedParseResult: ParseResult = global.clonedParseResult;
        const node = clonedParseResult.resolveNodeByType(realType);
        return node.__TYPE == CXXTYPE.Struct;
    }
    else {
        return type.__TYPE == CXXTYPE.Struct;
    }
}

export function findCustomHead(node: Clazz | Enumz | Struct, customHeads: CustomHead[]): CustomHead {
    const nodeName = node.name;
    const nodeFullName = node.fullName;

    return customHeads.find((customHead) => {
        if (customHead.name_space) {
            const fullName = customHead.name_space?.join("::") + "::" + customHead.name
            if (nodeFullName == fullName)
                return true;
        }
        return nodeName == customHead.name;
    });

}

export function matchReg(inputTemplate: string, cxxTypeSource: string, outputTemplate: string): string {
    let starPos = inputTemplate.indexOf("*");
    if (starPos == -1) {
        console.error("_matchReg error invalid inputTemplate: " + inputTemplate);
        return null;
    }

    let splitArray = inputTemplate.split("*");
    if (splitArray.length > 2) {
        console.error("_matchReg error invalid inputTemplate: " + inputTemplate);
        return null;
    }

    let findStr: string = null;

    if (splitArray[0] == "" && inputTemplate.endsWith(splitArray[1]) && cxxTypeSource.endsWith(splitArray[1])) {
        //类型于 *xxxxyy
        let suffixPos = cxxTypeSource.indexOf(splitArray[1]);
        findStr = cxxTypeSource.substring(0, suffixPos);
    }
    else if (splitArray[1] == "" && inputTemplate.startsWith(splitArray[0]) && cxxTypeSource.startsWith(splitArray[0])) {
        //类似于 xxyyy*
        findStr = cxxTypeSource.substring(splitArray[0].length, cxxTypeSource.length);
    }
    //类型于 xxx*yyy
    else if (cxxTypeSource.startsWith(splitArray[0]) && cxxTypeSource.endsWith(splitArray[1])) {
        let suffixPos = cxxTypeSource.indexOf(splitArray[1]);
        findStr = cxxTypeSource.substring(splitArray[0].length, suffixPos);
    }


    if (findStr) {
        let array = outputTemplate.match(/\${-[a-z]+\*}/g);
        if (array == null) {
            console.error("_matchReg error invalid outputTemplate: " + inputTemplate);
            return null;
        }

        let matchedString = array[0];
        let processedStr = StringProcess.processString(matchedString, findStr);

        outputTemplate = outputTemplate.replace(matchedString, processedStr);
        return outputTemplate;
    }

    return null;
}

//合并 IRtcEngineEventHandlerEx 到 IRtcEngineEventHandler并将IRtcEngineEventHandler并将里不带Connecton的删除
//将IRtcEngineEventHandlerEx的函数签名里的Ex都删除掉。
export function processIRtcEngineEventHandler() {
    let clonedParseResult: ParseResult = global.clonedParseResult;
    const event = clonedParseResult.resolveNodeByName("IRtcEngineEventHandler") as Clazz;
    const eventEx = clonedParseResult.resolveNodeByName("IRtcEngineEventHandlerEx") as Clazz;

    eventEx.methods.forEach(methodEx => {
        const method = event.methods.find(m => m.name == methodEx.name);
        if (method) {
            method.user_data = method.user_data || {};
            method.user_data.isHide = true;
        }

        let keyEx = methodEx.user_data?.IrisApiIdParser?.key;
        let valueEx = methodEx.user_data?.IrisApiIdParser?.value;
        keyEx = keyEx.replace("EX_", "_");
        valueEx = valueEx.replace("Ex_", "_");

        methodEx.user_data.IrisApiIdParser = {
            key: keyEx,
            value: valueEx
        };
    });

    event.methods.push(...eventEx.methods);

}

// 处理IAudioFrameObserverBase的apiKey
export function processIAudioFrameObserverBase() {
    let clonedParseResult: ParseResult = global.clonedParseResult;
    const event = clonedParseResult.resolveNodeByName("IAudioFrameObserverBase") as Clazz;

    event.methods.forEach(method => {
        let keyEx = method.user_data?.IrisApiIdParser?.key;
        let valueEx = method.user_data?.IrisApiIdParser?.value;
        keyEx = keyEx.replace("BASE_", "_");
        valueEx = valueEx.replace("Base_", "_");

        method.user_data.IrisApiIdParser = {
            key: keyEx,
            value: valueEx
        };
    });
}


// 有点丑陋
//返回类似于 
// (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId")
// (string)AgoraJson.JsonToStructArray<string>(_apiParam.Result, "result")
// (int)AgoraJson.GetData<int>(_apiParam.Result, "result")
// (int)AgoraJson.JsonToStruct<int>(_apiParam.Result, "result")
export function processVariableGetFromJson(type: SimpleType | Variable, jsonMapVariableName: string, jsonKeyVariableName: string, processRawData: ProcessRawData): string {
    let typeString = "";
    if (type instanceof Variable) {
        typeString = processMethodParameterFormalVariableType(type, processRawData);
        if (typeString.includes('ref ') || typeString.includes('out ')) {
            typeString = typeString.substring(4);
        }
    }
    else {
        typeString = processMethodReturnTypeString(type, processRawData);
    }

    var simpleType = ["int", "ulong", "uint", "long", "string", "bool", "track_id_t", "float"];

    if (simpleType.includes(typeString)) {
        //基本数据类型
        return `(${typeString})AgoraJson.GetData<${typeString}>(${jsonMapVariableName}, "${jsonKeyVariableName}")`;
    }
    else if (typeString.includes('[]')) {
        //是数组
        return `(${typeString})AgoraJson.JsonToStructArray<${typeString.substring(0, typeString.length - 2)}>(${jsonMapVariableName}, "${jsonKeyVariableName}")`;
    }
    else {
        //是结构体
        if (isEnumz(type)) {
            return `(${typeString})AgoraJson.GetData<int>(${jsonMapVariableName}, "${jsonKeyVariableName}")`;
        }
        else {
            return `(${typeString})AgoraJson.JsonToStruct<${typeString}>(${jsonMapVariableName}, "${jsonKeyVariableName}")`;
        }
    }
}

//处理node的commen中的obsolete
export function processNodeObsolete(node: { comment: string, user_data?: any }, processRawData: ProcessRawData) {
    var lines = node.comment.split("\n");
    let startIndex = -1;
    let endIndex = -1;
    for (var i = 0; i < lines.length; i++) {
        var line = lines[i];
        line = line.trim();
        if (line.includes("@deprecated")) {
            startIndex = i;
            endIndex = i;
            break;
        }
    }

    if (startIndex != -1) {
        for (let i = startIndex; i < lines.length; i++) {
            let line = lines[i].trim();
            if (i > startIndex && line.startsWith("@")) {
                endIndex = i - 1;
                break;
            }
            if (line.endsWith(".")) {
                endIndex = i;
                break;
            }
            if (line == "") {
                endIndex = i - 1;
                break;
            }
        }
        let deprecatedArray = lines.slice(startIndex, endIndex + 1);
        let obsolete = deprecatedArray.join(" ");
        obsolete = obsolete.replaceAll("@deprecated", "");
        obsolete = obsolete.replaceAll("  ", " ");
        obsolete = obsolete.replaceAll('"', '\\"')
        obsolete = obsolete.trim();
        node.user_data = node.user_data || {};
        node.user_data.obsolete = obsolete;
    }
}

export interface CppConstructor {
    //参数列表
    parameters: { type: string, name: string, value: string }[];
    //初始化列表
    initializes: { name: string, value: string }[];
    //body内部复制
    bodys: { name: string, value: string }[];
};

export function processCppConstructor(clazzName: string, fullFilePath: string): CppConstructor[] {

    let cppConstructors = [];
    let context = fs.readFileSync(fullFilePath, 'utf-8');
    let reg = new RegExp(`^[ ]*${clazzName}\\([\\s\\S]*?\\)[\\s\\S]*?\\{[\\s\\S]*?\\}`, "gm");
    let array = context.match(reg);
    if (array) {
        for (let e of array) {
            let cppConstructor: CppConstructor = { parameters: [], initializes: [], bodys: [] };
            //解析参数列表
            let firstPos = e.indexOf("(");
            let endPos = e.indexOf(")");
            let parametersStr = e.substring(firstPos + 1, endPos);
            parametersStr = parametersStr.trim();
            if (parametersStr != "") {
                let eachParameter = parametersStr.split(",");
                for (let each of eachParameter) {
                    let eachTrim = each.trim();
                    //has default value
                    let value = null;
                    if (eachTrim.indexOf("=") != -1) {
                        value = eachTrim.substring(eachTrim.indexOf("=") + 1);
                        value = value.trim();
                        eachTrim = eachTrim.substring(0, eachTrim.indexOf("=") - 1);
                    }

                    let length = eachTrim.length;
                    let endPos = 0;
                    for (let i = length - 1; i >= 0; i--) {
                        let e = eachTrim.charAt(i);
                        if (e == " " || e == "*" || e == "&") {
                            endPos = i;
                            break;
                        }
                    }

                    let type = null;
                    let name = null;
                    if (endPos != 0) {
                        type = eachTrim.substring(0, endPos + 1).trim();
                        name = eachTrim.substring(endPos + 1, length).trim();
                    }
                    else {
                        type = eachTrim;

                        name = StringProcess.processString("-l", type) // Tool._processStringWithL(type);
                    }
                    cppConstructor.parameters.push({ type, name, value });
                }
            }

            //解析初始化列表
            let initializePos = e.indexOf(":", e.indexOf(")"));
            if (initializePos != -1) {
                let initializeStr = e.substring(initializePos + 1, e.indexOf("{"));
                initializeStr = initializeStr.replace(/\ +/g, "");
                initializeStr = initializeStr.replace(/[\r\n]/g, "");
                let eachInitialize = initializeStr.split("),")
                for (let i = 0; i < eachInitialize.length; i++) {
                    let each = eachInitialize[i];
                    let eachTrim = each.trim();
                    if (i != eachInitialize.length - 1) {
                        eachTrim = eachTrim + ")";
                    }
                    let length = eachTrim.length;
                    let leftPos = eachTrim.indexOf("(");
                    let name = eachTrim.substring(0, leftPos).trim();
                    let value = eachTrim.substring(leftPos + 1, length - 1).trim();
                    cppConstructor.initializes.push({ name, value });
                }
            }
            //todo body有点沙雕。暂时不处理了
            cppConstructors.push(cppConstructor);
        }
    }
    return cppConstructors;
}


