import { callbackify } from "util";
import { ConfigTool } from "./ConfigTool";
import { CppConstructor, Tool } from "./Tool";
import { CXXTYPE, Clazz, EnumConstant, Enumz, MemberFunction, MemberVariable, Struct } from "./terra";
import { copyFile } from "fs";
import { publicDecrypt } from "crypto";
import { start } from "repl";
import { irisApiId } from "@agoraio-extensions/terra_shared_configs"
export class SpeicalLogic {

    public cSharpSDK_MethodObsolete(clazzName: string, info: MemberFunction, repeart: number, belongToClazzName: string): string {
        var lines = info.comment.split("\n");
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
            let des = deprecatedArray.join(" ");
            des = des.replaceAll("@deprecated", "");
            des = des.replaceAll("  ", " ");
            des = des.replaceAll('"', '\\"')
            des = des.trim();
            return `[Obsolete("${des}")]\n`;
        }
        else {
            return "";
        };
    }

    public cSharpSDK_EnumConstantObsolete(enumzName: string, constant: EnumConstant, belongToEnumzName: string) {
        let comment = constant.comment;
        if (!comment)
            return "";

        var lines = constant.comment.split("\n");
        for (var i = 0; i < lines.length; i++) {
            var line = lines[i];
            line = line.trim();
            if (line.includes("@deprecated")) {
                var out = line.replace("@deprecated", "");
                out = out.trim();
                return `[Obsolete("${out}")]\n`;
            }
        }
        return "";
    }

    public cSharpSDK_ImplJsonAdd(clazzName: string, info: MemberFunction, repeart: number, belongToClazzName: string): string {
        var lines = [];
        var configTool = ConfigTool.getInstance();
        for (let p of info.parameters) {
            var transType = configTool.paramTypeTrans.transType(clazzName, info.name, p.type.source, p.name);
            if (transType != "@remove" && transType != "byte[]" && transType.includes("ref ") == false) {
                lines.push(` _param.Add("${p.name}", ${configTool.paramNameFormalTrans.transType(clazzName, info.name, p.name)});`)
            }
        }
        if (lines.length > 0) {
            return lines.join('\n') + "\n";
        }
        else {
            return "";
        }
    }

    public cSharpSDK_ImplResultGet(clazzName: string, info: MemberFunction, repeart: number, belongToClazzName: string): string {
        var transReturn = ConfigTool.getInstance().paramTypeTrans.transType(clazzName, info.name, info.return_type.source, info.return_type.name);
        var defaultValueMap = {
            int: 'nRet',
            long: 'nRet',
            ulong: '0',
            uint: '0',
            string: '""',
            bool: 'false',
            CONNECTION_STATE_TYPE: 'CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED',
            MEDIA_PLAYER_STATE: 'MEDIA_PLAYER_STATE.PLAYER_STATE_FAILED',
            track_id_t: '0',
            float: '0'
        };
        var simpleType = ["int", "ulong", "uint", "long", "string", "bool", "track_id_t", "float"];
        var defaultValue = defaultValueMap[transReturn] || 'null';

        if (simpleType.includes(transReturn)) {
            //基本数据类型
            return `var result = nRet != 0 ? ${defaultValue} : (${transReturn})AgoraJson.GetData<${transReturn}>(_apiParam.Result, "result");`;
        }
        else if (transReturn.includes('[]')) {
            //是数组
            return `var result = nRet != 0 ? ${defaultValue} : (${transReturn})AgoraJson.JsonToStructArray<${transReturn.substring(0, transReturn.length - 2)}>(_apiParam.Result, "result");`;
        }
        else {
            //是结构体
            if (this.cSharpSDK_IsEnumz(transReturn)) {
                return `var result = nRet != 0 ? ${defaultValue} : (${transReturn})AgoraJson.GetData<int>(_apiParam.Result, "result");`;
            }
            else {
                return `var result = nRet != 0 ? ${defaultValue} : (${transReturn})AgoraJson.JsonToStruct<${transReturn}>(_apiParam.Result, "result");`;
            }
        }
    }

    public cSharpSDK_IsEnumz(paramType: string): boolean {
        let config = ConfigTool.getInstance();
        for (let e of config.cxxFiles) {
            let nodes = e.nodes;
            for (let node of nodes) {
                if (node.name == paramType) {
                    return node.__TYPE == CXXTYPE.Enumz;
                }
            }
        }
        return false;
    }

    public cSharpSDK_IsClazzOrStruct(paramType: string): boolean {
        let config = ConfigTool.getInstance();
        for (let e of config.cxxFiles) {
            let nodes = e.nodes;
            for (let node of nodes) {
                if (node.name == paramType) {
                    return node.__TYPE == CXXTYPE.Clazz || node.__TYPE == CXXTYPE.Struct;
                }
            }
        }
        return false;
    }

    public cSharpSDK_ImplRefGet(clazzName: string, info: MemberFunction, repeart: number, belongToClazzName: string): string {
        var valueMap = [
            "int",
            "ulong",
            "uint",
            "string",
            "bool",
        ];
        var configTool = ConfigTool.getInstance();
        var lines = [];

        for (let p of info.parameters) {
            var transType = configTool.paramTypeTrans.transType(clazzName, info.name, p.type.source, p.name);
            if (transType.includes("ref ")) {
                //是ref类型
                let jsonString = this.cSharpSDK_GetValueFromJson(clazzName, info.name, p.type.source, p.name, "_apiParam.Result");
                lines.push(`${p.name} =${jsonString};`);
            }
        }
        if (lines.length > 0) {
            lines.unshift('if (nRet == 0){');
            lines.push('}');
        }

        return lines.join('\n');
    }

    public cSharpSDK_ImplPullAudioFrameAssignment(clazzName: string, m: MemberVariable, repeart: number, belongToClazzName: string): string {
        if (m.name != "buffer") {
            return `frame.${m.name} = f.${m.name};`;
        }
        return "";
    }

    public cSharpSDK_ScreenCaptureSourceInfoInternalMemberAssignment(clazzName: string, m: MemberVariable, repeart: number, belongToClazzName: string): string {
        if (m.type.source.includes("ThumbImageBuffer")) {
            let array: string[] = [];
            array.push(`if(this.${m.name} !=null) {`);
            array.push(`screenCaptureSourceInfo.${m.name} = this.${m.name}.GenerateThumbImageBuffer();}`);
            array.push(`else {`);
            array.push(`screenCaptureSourceInfo.${m.name} = new ThumbImageBuffer(new byte[0], 0, 0, 0);}`)
            return array.join("\n");
        }
        else {
            return `screenCaptureSourceInfo.${m.name} = this.${m.name};`
        }
    }

    public cSharpSDK_ScreenCaptureSourceInfoInternalMemberList(clazzName: string, m: MemberVariable, repeart: number, belongToClazzName: string): string {
        let transType = ConfigTool.getInstance().paramTypeTrans.transType(clazzName, null, m.type.source, m.name);
        if (transType.includes("ThumbImageBuffer")) {
            return `public ${transType}Internal ${m.name};`;
        }
        else {
            return `public ${transType} ${m.name};`;
        }
    }

    public cSharpSDK_ThumbImageBufferInternalMemberAssignment(clazzName: string, m: MemberVariable, repeart: number, belongToClazzName: string): string {
        if (m.name == 'buffer') {
            return ` byte[] thumbBuffer = new byte[length];
            if (length > 0)
            {
                Marshal.Copy((this.buffer), thumbBuffer, 0, (int)length);
            }
            imageBuffer.buffer = thumbBuffer;`;
        }
        else {
            return `imageBuffer.${m.name} = this.${m.name};`
        }
    }

    public cSharpSDK_ThumbImageBufferInternalMemberList(clazzName: string, m: MemberVariable, repeart: number, belongToClazzName: string): string {
        let transType = ConfigTool.getInstance().paramTypeTrans.transType(clazzName, null, m.type.source, m.name);
        if (m.name == "buffer") {
            return `public IntPtr ${m.name};`;
        }
        else {
            return `public ${transType} ${m.name};`;
        }
    }

    public cSharpSDK_ExternalVideoFrameInternalMemberAssignment(clazzName: string, m: MemberVariable, repeart: number, belongToClazzName: string): string {
        let excludeList = ["buffer", "eglContext", "metadata_buffer", "alphaBuffer", "d3d11_texture_2d"];
        if (excludeList.includes(m.name)) {
            return "";
        }
        else {
            return `this.${m.name} = frame.${m.name};`;
        }
    }

    public cSharpSDK_ExternalVideoFrameInternalMemberList(clazzName: string, m: MemberVariable, repeart: number, belongToClazzName: string): string {
        let excludeList = ["buffer", "eglContext", "metadata_buffer", "alphaBuffer", "d3d11_texture_2d"];
        if (excludeList.includes(m.name)) {
            return "";
        }
        else {
            let transType = ConfigTool.getInstance().paramTypeTrans.transType(clazzName, null, m.type.source, m.name);
            return `public ${transType} ${m.name};`;
        }
    }

    public cSharpSDK_VideoFrameMemberList(clazzName: string, m: MemberVariable, repeart: number, belongToClazzName: string): string {
        if (m.name == "pixelBuffer") return '';
        let transType = ConfigTool.getInstance().paramTypeTrans.transType(clazzName, null, m.type.source, m.name);
        if (m.name == "metadata_buffer") {
            return `public IntPtr ${m.name};`;
        }
        if (m.type.source == "uint8_t*" && m.name != "metadata_buffer") {
            let str1 = `public byte[] ${m.name};`;
            let str2 = `public IntPtr ${m.name}Ptr;`;
            return `${str1}\n\n${str2}`;
        }
        else {
            return `public ${transType} ${m.name};`;
        }
    }

    // public cSharpSDK_ClazzStructConstructor(clazz: Clazz): string {
    //     if (clazz.name == "UserAudioSpectrumInfo") {
    //         return "";
    //     }

    //     let config = ConfigTool.getInstance();
    //     let cppConstructors: CppConstructor[] = Tool.getCppConstructor(clazz.name, clazz.file_path);
    //     let lines = [];
    //     for (let constructor of cppConstructors) {
    //         let constructorLines = [];

    //         //参数列表
    //         if (constructor.parameters.length > 0) {
    //             let parametersLines = [];
    //             for (let p of constructor.parameters) {
    //                 let transType = config.paramTypeTrans.transType(clazz.name, clazz.name, p.type, p.name);
    //                 let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, p.name);
    //                 let transValue = config.paramDefaultTrans.transType(clazz.name, clazz.name, p.type, p.name, p.value == null ? "" : p.value);
    //                 console.log("xxxxxxxxxxxxxxx " + p.value + " " + transValue);
    //                 if (transValue == null || transValue == "@remove") {
    //                     parametersLines.push(`${transType} ${transName}`);
    //                 }
    //                 else {
    //                     parametersLines.push(`${transType} ${transName} = ${transValue}`);
    //                 }
    //             }
    //             let parametersStr = parametersLines.join(",");
    //             constructorLines.push(`public ${clazz.name}(${parametersStr})`);
    //         }
    //         else {
    //             constructorLines.push(`public ${clazz.name}()`);
    //         }

    //         //初始化构造列表里调用了父类构造
    //         let baseClazzName = clazz.base_clazzs.length > 0 ? clazz.base_clazzs[0] : "";
    //         if (constructor.initializes.length > 0) {
    //             for (let e of constructor.initializes) {
    //                 if (e.name == baseClazzName) {
    //                     constructorLines.push(`:base(${e.value})`);
    //                     break;
    //                 }
    //             }
    //         }
    //         constructorLines.push(`{`);

    //         //初始化构造列表
    //         if (constructor.initializes.length > 0) {
    //             for (let e of constructor.initializes) {
    //                 if (e.name == baseClazzName)
    //                     continue;
    //                 let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, e.name);
    //                 let transValue = config.paramDefaultTrans.transType(clazz.name, clazz.name, null, e.name, e.value);
    //                 constructorLines.push(`this.${transName} = ${transValue};`);
    //             }
    //         }


    //         constructorLines.push("}");
    //         lines.push(constructorLines.join('\n'));
    //     }

    //     //生成全量参数构造
    //     let needFullParamCtor = true;
    //     for (let e of cppConstructors) {
    //         if (e.parameters.length == clazz.member_variables.length) {
    //             needFullParamCtor = false;
    //             break;
    //         }
    //     }
    //     if (needFullParamCtor) {
    //         let constructorLines = [];
    //         let parametersLines = [];
    //         for (let e of clazz.member_variables) {
    //             let transType = config.paramTypeTrans.transType(clazz.name, clazz.name, e.type.source, e.name);
    //             let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, e.name);
    //             parametersLines.push(`${transType} ${transName}`);
    //         }
    //         let parametersStr = parametersLines.join(",");
    //         constructorLines.push(`public ${clazz.name}(${parametersStr})\n{`);
    //         for (let e of clazz.member_variables) {
    //             let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, e.name);
    //             constructorLines.push(`this.${transName} = ${transName};`);
    //         }
    //         constructorLines.push(`}`);
    //         lines.push(constructorLines.join('\n'));
    //     }

    //     return lines.join('\n\n');
    // }

    public cSharpSDK_AudioFrameConstructor(clazz: Clazz): string {
        let config = ConfigTool.getInstance();
        let cppConstructors: CppConstructor[] = Tool.getCppConstructor(clazz.name, clazz.file_path);
        let constructor = cppConstructors[0];
        let lines = [];


        lines.push(`public ${clazz.name}()\n{`);
        //初始化构造列表
        if (constructor.initializes.length > 0) {
            for (let e of constructor.initializes) {
                let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, e.name);
                let transValue = config.paramDefaultTrans.transType(clazz.name, clazz.name, null, e.name, e.value);
                lines.push(`this.${transName} = ${transValue};`);
            }
        }
        lines.push(`this.RawBuffer = new byte[0];`);
        lines.push(`}\n\n`)

        //全量构造函数
        let constructorLines = [];
        let parametersLines = [];
        for (let e of clazz.member_variables) {
            let transType = config.paramTypeTrans.transType(clazz.name, clazz.name, e.type.source, e.name);
            let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, e.name);
            parametersLines.push(`${transType} ${transName}`);
        }
        let parametersStr = parametersLines.join(",");
        constructorLines.push(`public ${clazz.name}(${parametersStr})\n{`);
        for (let e of clazz.member_variables) {
            let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, e.name);
            constructorLines.push(`this.${transName} = ${transName};`);
        }
        constructorLines.push(`}\n\n`);
        lines.push(constructorLines.join('\n'));

        return lines.join(`\n`);
    }

    public cSharpSDK_VideoFrameConstructor(clazz: Clazz): string {
        let config = ConfigTool.getInstance();
        let cppConstructors: CppConstructor[] = Tool.getCppConstructor(clazz.name, clazz.file_path);
        let constructor = cppConstructors[0];
        let lines = [];


        lines.push(`public ${clazz.name}()\n{`);
        //初始化构造列表
        if (constructor.initializes.length > 0) {
            for (let e of constructor.initializes) {
                if (e.name == "pixelBuffer")
                    continue;
                else if (e.name.includes('Buffer')) {
                    lines.push(`this.${e.name} = new byte[0];`);
                    lines.push(`this.${e.name}Ptr = IntPtr.Zero;`);
                }
                else {
                    let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, e.name);
                    let transValue = config.paramDefaultTrans.transType(clazz.name, clazz.name, null, e.name, e.value);
                    lines.push(`this.${transName} = ${transValue};`);
                }
            }
        }
        lines.push(`this.matrix = new float[16];`);
        lines.push(`}`)
        return lines.join(`\n`);
    }

    public cSharpSDK_ClazzAndStructWithOptional(clazz: Clazz | Struct): string {
        let judgmentHadOptinal = (clazz: Clazz | Struct): boolean => {
            for (let e of clazz.member_variables) {
                if (e.type.source.includes('Optional<')) {
                    return true;
                    break;
                }
            }
            return false;
        }

        let config = ConfigTool.getInstance();
        let baseClazz: Clazz | Struct = null;
        if (clazz.base_clazzs.length > 0) {
            baseClazz = config.getClassOrStruct(clazz.base_clazzs[0]);
        }
        let thisHadOptional = false;
        let baseHadOptional = false;
        thisHadOptional = judgmentHadOptinal(clazz);
        baseHadOptional = baseClazz && judgmentHadOptinal(baseClazz);

        var lines = [];
        let parentClass: string = clazz.base_clazzs.join(",");
        if ((thisHadOptional && !baseHadOptional) ||
            (baseHadOptional && !thisHadOptional)
        ) {
            lines.push(`public class ${clazz.name} :${parentClass == "" ? "" : parentClass + ","} IOptionalJsonParse{`);
        }
        else {
            lines.push(`public class ${clazz.name}${parentClass != "" ? ':' + parentClass : ''}{`);
        }

        //members
        for (let e of clazz.member_variables) {
            if (clazz.name == "RtcEngineContext" && e.name == "eventHandler")
                continue;
            if (clazz.name == "RtcEngineContextS" && e.name == "eventHandlerS")
                continue;

            if (clazz.name == "MusicContentCenterConfiguration" && e.name == "eventHandler")
                continue;

            let transType = "";
            if (e.type.source.includes('Optional<')) {
                let midName = this.cSharpSDK_getMidTypeFromOptinal(e.type.source);
                midName = config.paramTypeTrans.transType(clazz.name, null, midName, e.name);
                //Optional<agora::rtc::VIDEO_STREAM_TYPE> ==> Optional<VIDEO_STREAM_TYPE>
                transType = `Optional<${midName}>`;
            }
            else {
                transType = config.paramTypeTrans.transType(clazz.name, null, e.type.source, e.name);
            }
            let tranName = config.paramNameFormalTrans.transType(clazz.name, null, e.name);
            if (e.type.source.includes('Optional<')) {
                lines.push(`public ${transType} ${tranName} = new ${transType}();\n`);
            }
            else {
                lines.push(`public ${transType} ${tranName};\n`);
            }
        }

        //constructor
        if (true/*clazz.name != "SpatialAudioZone"*/) {

            let cppConstructors: CppConstructor[] = Tool.getCppConstructor(clazz.name, clazz.file_path);
            for (let constructor of cppConstructors) {
                if (clazz.name == "ScreenCaptureSourceInfo" && constructor.initializes.length == 7)
                    continue;


                let constructorLines = [];

                //参数列表
                if (constructor.parameters.length > 0) {
                    let parametersLines = [];
                    for (let p of constructor.parameters) {
                        if (clazz.name == "RtcEngineContext" && p.name == "eventHandler")
                            continue;
                        let transType = config.paramTypeTrans.transType(clazz.name, clazz.name, p.type, p.name);
                        if (transType == "@remove")
                            continue;
                        let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, p.name);
                        let transValue = config.paramDefaultTrans.transType(clazz.name, clazz.name, p.type, p.name, p.value);
                        console.log("constructor.parameters " + p.value + " " + transValue);
                        if (transValue == null || transValue == "@remove") {
                            parametersLines.push(`${transType} ${transName}`);
                        }
                        else {
                            parametersLines.push(`${transType} ${transName} = ${transValue}`);
                        }
                    }
                    let parametersStr = parametersLines.join(",");
                    constructorLines.push(`public ${clazz.name}(${parametersStr})`);
                }
                else {
                    constructorLines.push(`public ${clazz.name}()`);
                }

                //初始化构造列表里调用了父类构造
                let baseClazzName = clazz.base_clazzs.length > 0 ? clazz.base_clazzs[0] : "";
                if (constructor.initializes.length > 0) {
                    for (let e of constructor.initializes) {
                        if (e.name == baseClazzName) {
                            constructorLines.push(`:base(${e.value})`);
                            break;
                        }
                    }
                }
                constructorLines.push(`{`);


                //初始化构造列表
                if (constructor.initializes.length > 0) {
                    for (let e of constructor.initializes) {
                        if (clazz.name == "RtcEngineContext" && e.name == "eventHandler")
                            continue;
                        if (clazz.name == "RtcEngineContextS" && e.name == "eventHandlerS")
                            continue;
                        if (clazz.name == "MusicContentCenterConfiguration" && e.name == "eventHandler")
                            continue;
                        if (e.name == baseClazzName)
                            continue;
                        let transType = this.cSharpSDK_FindType(e.name, clazz);
                        let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, e.name);
                        let transValue = config.paramDefaultTrans.transType(clazz.name, clazz.name, null, e.name, e.value);
                        if (transValue.includes(",") == false || transType == '' || transValue != e.value) {
                            constructorLines.push(`this.${transName} = ${this.cSharpSDK_AddEnumzPrefixIfIsIsEnumz(transValue)};`);
                        }
                        else {
                            let params = transValue.split(",");
                            let transParams = [];
                            for (let p of params) {
                                transParams.push(this.cSharpSDK_AddEnumzPrefixIfIsIsEnumz(p.trim()));
                            }
                            constructorLines.push(`this.${transName} = new ${transType}(${transParams.join(",")});`)
                        }
                    }
                }
                constructorLines.push("}\n");
                lines.push(constructorLines.join('\n'));
            }

            //生成全量参数构造
            let needFullParamCtor = true;
            let needEmptyParamCtor = true;
            let baseAndThisMemberLength = clazz.member_variables.length + (baseClazz ? baseClazz.member_variables.length : 0);
            for (let e of cppConstructors) {
                if (e.parameters.length == baseAndThisMemberLength) {
                    needFullParamCtor = false;
                }
                if (e.parameters.length == 0) {
                    needEmptyParamCtor = false;
                }
            }
            let generateParamersLines = (clazz: Clazz | Struct, parametersLines: string[]) => {
                for (let e of clazz.member_variables) {
                    if (clazz.name == "RtcEngineContext" && e.name == "eventHandler")
                        continue;
                    if (clazz.name == "RtcEngineContextS" && e.name == "eventHandlerS")
                        continue;
                    let transType = "";
                    if (e.type.source.includes('Optional<')) {
                        let midName = this.cSharpSDK_getMidTypeFromOptinal(e.type.source);
                        midName = config.paramTypeTrans.transType(clazz.name, clazz.name, midName, e.name);
                        //Optional<agora::rtc::VIDEO_STREAM_TYPE> ==> Optional<VIDEO_STREAM_TYPE>
                        transType = `Optional<${midName}>`;
                    }
                    else {
                        transType = config.paramTypeTrans.transType(clazz.name, clazz.name, e.type.source, e.name);
                    }
                    let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, e.name);
                    parametersLines.push(`${transType} ${transName}`);
                }
            }


            if (needFullParamCtor) {
                let constructorLines = [];
                let parametersLines = [];
                if (baseClazz) {
                    generateParamersLines(baseClazz, parametersLines);
                }
                generateParamersLines(clazz, parametersLines);
                let parametersStr = parametersLines.join(",");
                constructorLines.push(`public ${clazz.name}(${parametersStr})`);

                if (baseClazz) {
                    //C# only support single-inheritance
                    let baseParamters: string[] = [];
                    for (let e of baseClazz.member_variables) {
                        let transName = config.paramNameFormalTrans.transType(baseClazz.name, baseClazz.name, e.name);
                        baseParamters.push(transName);
                    }
                    constructorLines.push(`: base(${baseParamters.join(',')})`);
                }
                constructorLines.push('{');

                for (let e of clazz.member_variables) {
                    if (clazz.name == "RtcEngineContext" && e.name == "eventHandler")
                        continue;
                    if (clazz.name == "RtcEngineContextS" && e.name == "eventHandlerS")
                        continue;
                    let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, e.name);
                    constructorLines.push(`this.${transName} = ${transName};`);
                }
                constructorLines.push(`}`);
                lines.push(constructorLines.join('\n'));
            }
            if (needEmptyParamCtor) {
                lines.push(`public ${clazz.name}(){\n}\n`);
            }
        }

        //ToJson
        if (thisHadOptional || baseHadOptional) {
            if (thisHadOptional) {
                lines.push(`\npublic virtual void ToJson(JsonWriter writer){`);
            }
            else {
                lines.push(`\npublic override void ToJson(JsonWriter writer){`);
            }
            lines.push(`writer.WriteObjectStart();\n`);
            let writeJson = (clazz: Clazz | Struct, lines: string[]) => {
                for (let e of clazz.member_variables) {
                    if (clazz.name == "RtcEngineContext" && e.name == "eventHandler")
                        continue;
                    if (clazz.name == "RtcEngineContextS" && e.name == "eventHandlerS")
                        continue;
                    if (clazz.name == "MediaSource" && e.name == "provider")
                        continue;

                    let transType = config.paramTypeTrans.transType(clazz.name, null, e.type.source, e.name);
                    let transName = config.paramNameFormalTrans.transType(clazz.name, null, e.name);

                    if (transType.includes('Optional<')) {
                        let midName = this.cSharpSDK_getMidTypeFromOptinal(transType);
                        midName = config.paramTypeTrans.transType(clazz.name, null, midName, e.name);
                        //Optional<agora::rtc::VIDEO_STREAM_TYPE> ==> Optional<VIDEO_STREAM_TYPE>
                        transType = `Optional<${midName}>`;
                        lines.push(`if (this.${transName}.HasValue()){`);
                        lines.push(`writer.WritePropertyName("${transName}");`)
                        if (this.cSharpSDK_IsClazzOrStruct(this.cSharpSDK_getMidTypeFromOptinal(transType))) {
                            lines.push(`JsonMapper.WriteValue(this.${transName}.GetValue(), writer, false, 0);`)
                        }
                        else if (this.cSharpSDK_IsEnumz(this.cSharpSDK_getMidTypeFromOptinal(transType))) {
                            lines.push(`AgoraJson.WriteEnum(writer, this.${transName}.GetValue());`)
                        }
                        else {
                            lines.push(`writer.Write(this.${transName}.GetValue());`)
                        }
                        lines.push(`}\n`);
                    }
                    else if (this.cSharpSDK_IsClazzOrStruct(transType)) {
                        //是class或者struct
                        lines.push(`writer.WritePropertyName("${transName}");`);
                        lines.push(`JsonMapper.WriteValue(this.${transName}, writer, false, 0);\n`);
                    }
                    else {
                        //是普通变量
                        lines.push(`writer.WritePropertyName("${transName}");`)
                        if (this.cSharpSDK_IsEnumz(transType)) {
                            lines.push(`AgoraJson.WriteEnum(writer, this.${transName});\n`)
                        }
                        else {
                            lines.push(`writer.Write(this.${transName});\n`)
                        }
                    }
                }
            }
            baseHadOptional && writeJson(baseClazz, lines);
            writeJson(clazz, lines);
            lines.push(`writer.WriteObjectEnd();`);
            lines.push(`}`)
        }

        lines.push(`}`);
        return lines.join('\n');
    }

    public cSharpSDK_FindType(name, clazz: Clazz | Struct): string {
        let config = ConfigTool.getInstance();
        for (let e of clazz.member_variables) {
            let transType = config.paramTypeTrans.transType(clazz.name, clazz.name, e.type.source, e.name);
            let transName = config.paramNameFormalTrans.transType(clazz.name, clazz.name, e.name);
            if (transName == name) {
                return transType;
            }
        }
        return "";
    }

    public cSharpSDK_AddEnumzPrefixIfIsIsEnumz(name: string): string {
        let config: ConfigTool = ConfigTool.getInstance();
        for (let c of config.cxxFiles) {
            let nodes = c.nodes;
            for (let node of nodes) {
                if (node.__TYPE == CXXTYPE.Enumz) {
                    let enumz: Enumz = node as Enumz;
                    for (let e of enumz.enum_constants) {
                        if (e.name == name) {
                            return `${enumz.name}.${name}`;
                        }
                    }

                }
            }
        }
        return name;
    }

    public cSharpSDK_getMidTypeFromOptinal(OptionalName: string) {
        return OptionalName.substring(OptionalName.indexOf('<') + 1, OptionalName.length - 1);
    }

    public cSharpSDK_AppendPlayerId(clazzName: string, fun: MemberFunction) {
        let length = 0;
        for (let p of fun.parameters) {
            let tranName = ConfigTool.getInstance().paramNameActualTrans.transType(clazzName, fun.name, p.name);
            if (tranName != "@remove" && tranName != "") {
                length++;
            }
        }

        if (length > 0) {
            return "playerId, ";
        }
        else {
            return "playerId";
        }
    }

    public cSharpSDK_AppendPlayerIdWithInt(clazzName: string, fun: MemberFunction, repeart: number, belongToClazzName: string) {
        let length = 0;
        for (let p of fun.parameters) {
            let tranName = ConfigTool.getInstance().paramNameActualTrans.transType(clazzName, fun.name, p.name);
            if (tranName != "@remove" && tranName != "") {
                length++;
            }
        }

        if (length > 0) {
            return "int playerId, ";
        }
        else {
            return "int playerId";
        }
    }
    public cSharpSDK_AppendNativeHandle(clazzName: string, fun: MemberFunction, repeart: number, belongToClazzName: string) {
        let length = 0;
        for (let p of fun.parameters) {
            let tranName = ConfigTool.getInstance().paramNameActualTrans.transType(clazzName, fun.name, p.name);
            if (tranName != "@remove" && tranName != "") {
                length++;
            }
        }

        if (length > 0) {
            return "_nativeHandle, ";
        }
        else {
            return "_nativeHandle";
        }
    }

    public cSharpSDK_AppendNativeHandleWithString(clazzName: string, fun: MemberFunction, repeart: number, belongToClazzName: string) {
        let length = 0;
        for (let p of fun.parameters) {
            let tranName = ConfigTool.getInstance().paramNameActualTrans.transType(clazzName, fun.name, p.name);
            if (tranName != "@remove" && tranName != "") {
                length++;
            }
        }

        if (length > 0) {
            return "string nativeHandle, ";
        }
        else {
            return "string nativeHandle";
        }
    }

    public cSharpSDK_GetRtcEventHandlerData(excludes: string[]): { clazzName: string, m: MemberFunction, repeart: number }[] {
        let returns: { clazzName: string, m: MemberFunction, repeart: number }[] = [];
        let config = ConfigTool.getInstance();
        let excludeMethods = [
            "eventHandlerType"
        ]
        excludeMethods.push(...excludes);
        let bothMethods = [
            "onLocalVideoStateChanged"
        ];

        let pushHandler = (handlerName: string, handlerExName: string, returns: { clazzName: string, m: MemberFunction, repeart: number }[]) => {
            let eventHandlerMethods = config.getClassOrStruct(handlerName).methods;
            let eventHandlerExMethods = config.getClassOrStruct(handlerExName).methods;

            for (let m of eventHandlerMethods) {
                if (excludeMethods.includes(m.name))
                    continue;
                if (bothMethods.includes(m.name)) {
                    returns.push({ clazzName: handlerName, m: m, repeart: 1 });
                    continue;
                }

                let mEx = eventHandlerExMethods.find((e) => { return e.name == m.name });
                if (mEx == null) {
                    returns.push({ clazzName: handlerName, m: m, repeart: 1 });
                }
            }
        };

        // push IRtcEngineEventHandler, IRtcEngineEventHandlerEx
        pushHandler("IRtcEngineEventHandler", "IRtcEngineEventHandlerEx", returns);

        let pushHandlerEx = (handlerExName, returns: { clazzName: string, m: MemberFunction, repeart: number }[]) => {
            let eventHandlerExMethods = config.getClassOrStruct(handlerExName).methods;
            for (let m of eventHandlerExMethods) {
                if (excludeMethods.includes(m.name))
                    continue;
                let mBase = returns.find((e) => { return e.m.name == m.name && (e.clazzName == "IRtcEngineEventHandlerBase" || e.clazzName == "IRtcEngineEventHandler" || e.clazzName == "IRtcEngineEventHandlerS") });
                returns.push({ clazzName: handlerExName, m: m, repeart: mBase ? 2 : 1 });
            }
        }
        pushHandlerEx("IRtcEngineEventHandlerEx", returns);
        return returns;
    }

    public cSharpSDK_GenerateRtcEngineEventHandlerBaseInterface(clazz: Clazz): string {
        let lines = [];
        let config = ConfigTool.getInstance();
        let allMethodDatas = this.cSharpSDK_GetRtcEventHandlerData([]);

        for (let data of allMethodDatas) {
            let clazzName = data.clazzName;
            if (clazzName != "IRtcEngineEventHandlerBase")
                continue;

            let m = data.m;
            let paramslines = [];
            for (let p of m.parameters) {
                let transType = config.paramTypeTrans.transType(clazzName, m.name, p.type.source, p.name);
                let transName = config.paramNameFormalTrans.transType(clazzName, m.name, p.name);
                if (transType == "@remove")
                    continue;
                paramslines.push(`${transType} ${transName}`);
            }
            let methodName = Tool._processStringWithU(m.name);
            lines.push(`public virtual void ${methodName}(${paramslines.join(", ")}){\n }`);
        }

        return lines.join("\n\n");
    }

    public cSharpSDK_GenerateRtcEngineEventHandlerInterface(clazz: Clazz): string {
        let lines = [];
        let config = ConfigTool.getInstance();
        let allMethodDatas = this.cSharpSDK_GetRtcEventHandlerData([]);

        for (let data of allMethodDatas) {
            let clazzName = data.clazzName;
            if (clazzName != "IRtcEngineEventHandler" && clazzName != "IRtcEngineEventHandlerEx")
                continue;

            let m = data.m;
            let paramslines = [];
            for (let p of m.parameters) {
                let transType = config.paramTypeTrans.transType(clazzName, m.name, p.type.source, p.name);
                let transName = config.paramNameFormalTrans.transType(clazzName, m.name, p.name);
                if (transType == "@remove")
                    continue;
                paramslines.push(`${transType} ${transName}`);
            }
            let methodName = Tool._processStringWithU(m.name);
            lines.push(`public virtual void ${methodName}(${paramslines.join(", ")}){\n }`);
        }

        return lines.join("\n\n");
    }

    public cSharpSDK_GenerateRtcEngineEventHandlerSInterface(clazz: Clazz): string {
        let lines = [];
        let config = ConfigTool.getInstance();
        let allMethodDatas = this.cSharpSDK_GetRtcEventHandlerData([]);

        for (let data of allMethodDatas) {
            let clazzName = data.clazzName;
            if (clazzName != "IRtcEngineEventHandlerS" && clazzName != "IRtcEngineEventHandlerExS")
                continue;

            let m = data.m;
            let paramslines = [];
            for (let p of m.parameters) {
                let transType = config.paramTypeTrans.transType(clazzName, m.name, p.type.source, p.name);
                let transName = config.paramNameFormalTrans.transType(clazzName, m.name, p.name);
                if (transType == "@remove")
                    continue;
                paramslines.push(`${transType} ${transName}`);
            }
            let methodName = Tool._processStringWithU(m.name);
            lines.push(`public virtual void ${methodName}(${paramslines.join(", ")}){\n }`);
        }

        return lines.join("\n\n");
    }

    public cSharpSDK_GenerateRtcEngineEventHandlerBaseNative(clazz: Clazz): string {
        let lines = [];
        let config = ConfigTool.getInstance();
        let allMethodDatas = this.cSharpSDK_GetRtcEventHandlerData([]);

        for (let data of allMethodDatas) {
            let clazzName = data.clazzName;
            if (clazzName != "IRtcEngineEventHandlerBase")
                continue;

            let eachM = this.cSharpSDK_GenerateIRtcEngineEventHandlerEachMethondNative(clazzName, data.m, null);
            lines.push(eachM);
        }
        return lines.join("\n\n");
    }

    public cSharpSDK_GenerateRtcEngineEventHandlerNative(clazz: Clazz): string {
        let lines = [];
        let config = ConfigTool.getInstance();
        let allMethodDatas = this.cSharpSDK_GetRtcEventHandlerData([]);

        for (let data of allMethodDatas) {
            let clazzName = data.clazzName;
            if (clazzName != "IRtcEngineEventHandler" && clazzName != "IRtcEngineEventHandlerEx")
                continue;

            if (data.m.name == "onStreamMessage")
                continue;
            if (data.m.name == "onAudioMetadataReceived")
                continue;

            let eachM = this.cSharpSDK_GenerateIRtcEngineEventHandlerEachMethondNative(clazzName, data.m, null);
            lines.push(eachM);
        }
        return lines.join("\n\n");
    }

    public cSharpSDK_GenerateRtcEngineEventHandlerSNative(clazz: Clazz): string {
        let lines = [];
        let config = ConfigTool.getInstance();
        let allMethodDatas = this.cSharpSDK_GetRtcEventHandlerData([]);

        for (let data of allMethodDatas) {
            let clazzName = data.clazzName;
            if (clazzName != "IRtcEngineEventHandlerS" && clazzName != "IRtcEngineEventHandlerExS")
                continue;

            if (data.m.name == "onStreamMessage")
                continue;

            let eachM = this.cSharpSDK_GenerateIRtcEngineEventHandlerEachMethondNative(clazzName, data.m, "IRtcEngineEventHandlerS");
            lines.push(eachM);
        }
        return lines.join("\n\n");
    }

    public cSharpSDK_GenerateIRtcEngineEventHandlerEachMethondNative(clazzName: string, m: MemberFunction, forcedConversion: string): string {
        let lines = [];
        let switchKey = `AgoraEventType.EVENT_${Tool.processString("-rv", clazzName)}_${Tool.processString("-v", m.name, 1)}`;
        let handlerNameMap = {
            "IDirectCdnStreamingEventHandler": "rtcEngineEventHandler"
        }
        let handlerName = handlerNameMap[clazzName] || "commonEventHandler";
        lines.push(`case ${switchKey}:\n{`);
        lines.push(`#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID`);
        lines.push(`CallbackObject._CallbackQueue.EnQueue(() => {`);
        lines.push(`#endif`);
        lines.push(`if (rtcEngineEventHandler == null) return;`);
        let methodName = Tool._processStringWithU(m.name);
        let eventHandlerName = forcedConversion ? `((${forcedConversion})rtcEngineEventHandler)` : "rtcEngineEventHandler";
        lines.push(`${eventHandlerName}.${methodName}(`);

        let paramslines = [];

        for (let p of m.parameters) {
            let jsonString = this.cSharpSDK_GetValueFromJson(clazzName, m.name, p.type.source, p.name, "jsonData");
            if (jsonString != null)
                paramslines.push(jsonString);
        }

        lines.push(`${paramslines.join(",\n")}`);

        lines.push(`); `);
        lines.push(`#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID`);
        lines.push(`}); `);
        lines.push(`#endif`);
        lines.push(`break;\n}`);

        return lines.join("\n");

    }

    public cSharpSDK_GenerateRtcEngineEventHandler(clazz: Clazz): string {
        let lines = [];
        let allMethods = this.cSharpSDK_GetRtcEventHandlerData([]);
        let containClazzName = [
            "IRtcEngineEventHandlerBase",
            "IRtcEngineEventHandler",
            "IRtcEngineEventHandlerEx"
        ]
        for (let data of allMethods) {
            if (!containClazzName.includes(data.clazzName))
                continue;
            lines.push(this.cSharpSDK_GenerateEventHandlerImpl(data.clazzName, data.m, data.repeart, data.clazzName));
        }
        return lines.join('\n');
    }

    public cSharpSDK_GenerateRtcEngineEventHandlerS(clazz: Clazz): string {
        let lines = [];
        let allMethods = this.cSharpSDK_GetRtcEventHandlerData([]);
        let containClazzName = [
            "IRtcEngineEventHandlerBase",
            "IRtcEngineEventHandlerS",
            "IRtcEngineEventHandlerExS"
        ]
        for (let data of allMethods) {
            if (!containClazzName.includes(data.clazzName))
                continue;
            lines.push(this.cSharpSDK_GenerateEventHandlerImpl(data.clazzName, data.m, data.repeart, data.clazzName));
        }
        return lines.join('\n');
    }

    public cSharpSDK_GenerateDirectCdnStreamingEventHandler(clazz: Clazz): string {
        let lines = [];
        for (let m of clazz.methods) {
            lines.push(this.cSharpSDK_GenerateEventHandlerImpl(clazz.name, m, 1, clazz.name));
        }
        return lines.join('\n');
    }

    protected cSharpSDK_GenerateEventHandlerImpl(clazzName: string, m: MemberFunction, repeart: number, belongToClazzName: string): string {
        let config = ConfigTool.getInstance();
        let lines = [];
        let paramsArray0: string[] = [];
        let paramsArray1: string[] = [];
        let paramsArray2: string[] = [];
        for (let p of m.parameters) {
            let transType = config.paramTypeTrans.transType(clazzName, m.name, p.type.source, p.name);
            let transName = config.paramNameFormalTrans.transType(clazzName, m.name, p.name);
            let transActive = config.paramNameActualTrans.transType(clazzName, m.name, p.name);
            if (transType == "@remove")
                continue;
            paramsArray0.push(`${transType}`);
            paramsArray1.push(`${transType} ${transName}`);
            paramsArray2.push(`${transActive}`)
        }
        let eventName = `Event${Tool.processString('-u', m.name)}` + (repeart > 1 ? repeart : "");
        lines.push(`public event Action${paramsArray0.length == 0 ? "" : "<" + paramsArray0.join(",") + ">"} ${eventName};`);
        lines.push(``);
        lines.push(`public override void ${Tool.processString('-u', m.name)}(${paramsArray1.join(",")})\n{`);
        lines.push(`if (${eventName} == null) return;`);
        lines.push(`${eventName}.Invoke(${paramsArray2.join(',')});`);
        lines.push(`}\n`);
        return lines.join('\n');
    }

    public cSharpSDK_GetValueFromJson(clazzName: string, funName: string, originType: string, originName: string, jsonMapName: string) {
        let config = ConfigTool.getInstance();
        let transType = config.paramTypeTrans.transType(clazzName, funName, originType, originName);
        if (transType.startsWith('ref '))
            transType = transType.substring(4);
        let transName = config.paramNameFormalTrans.transType(clazzName, funName, originName);
        if (transType == "@remove")
            return null;

        var simpleType = ["view_t", "int", "ulong", "uint", "long", "string", "bool", "double", "float", "ushort", "short", "byte"];
        if (simpleType.includes(transType)) {
            //基本数据类型
            return `(${transType})AgoraJson.GetData <${transType}>(${jsonMapName}, "${originName}")`;
        }
        else if (transType.includes('[]')) {
            //是数组
            let elementType = transType.substring(0, transType.length - 2);
            if (simpleType.includes(elementType)) {

                return `AgoraJson.GetDataArray${Tool.processString("-u", elementType)}(${jsonMapName}, "${originName}")`;
            }
            else {
                return `AgoraJson.JsonToStructArray<${transType.substring(0, transType.length - 2)}> (${jsonMapName}, "${originName}")`;
            }
        }
        else {
            //是枚举或者结构体 
            if (this.cSharpSDK_IsEnumz(transType)) {
                return `(${transType})AgoraJson.GetData<int>(${jsonMapName}, "${originName}")`;
            }
            else {
                return `AgoraJson.JsonToStruct < ${transType}> (${jsonMapName}, "${originName}")`;
            }
        }
    }

    public cSharpSDK_GenerateCommonEventHandlerNative(clazzName: string, m: MemberFunction, repeart: number, belongToClazzName: string): string {
        let lines = [];
        let switchKey = `AgoraEventType.EVENT_${Tool.processString("-rv", belongToClazzName)}_${Tool.processString("-v", m.name, repeart)}`;
        let handlerNameMap = {
            "IDirectCdnStreamingEventHandler": "rtcEngineEventHandler"
        }
        let handlerName = handlerNameMap[clazzName] || "commonEventHandler";
        lines.push(`case ${switchKey}:\n{`);
        lines.push(`#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID`);
        lines.push(`CallbackObject._CallbackQueue.EnQueue(() => {`);
        lines.push(`#endif`);
        lines.push(`if (${handlerName} == null) return;`);
        let methodName = Tool._processStringWithU(m.name);
        lines.push(`${handlerName}.${methodName}(`);

        let paramslines = [];

        for (let p of m.parameters) {
            let jsonString = this.cSharpSDK_GetValueFromJson(clazzName, m.name, p.type.source, p.name, "jsonData");
            if (jsonString != null)
                paramslines.push(jsonString);
        }

        lines.push(`${paramslines.join(",\n")}`);

        lines.push(`); `);
        lines.push(`#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID`);
        lines.push(`}); `);
        lines.push(`#endif`);
        lines.push(`break;\n}`);

        return lines.join("\n");

    }

    public cSharpSDK_GenerateMediaPlayerSourceObserverNative(clazzName: string, m: MemberFunction, repeart: number, belongToClazzName: string): string {
        let lines = [];
        let switchKey = `AgoraEventType.EVENT_${Tool.processString("-rv", belongToClazzName)}_${Tool.processString("-v", m.name, repeart)}`;
        lines.push(`case ${switchKey}:\n{`);
        lines.push(`#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID`);
        lines.push(`CallbackObject._CallbackQueue.EnQueue(() => {`);
        lines.push(`#endif`);
        lines.push(`if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;`);
        let methodName = Tool._processStringWithU(m.name);
        lines.push(`mediaPlayerSourceObserverDic[playerId].${methodName}(`);

        let paramslines = [];

        for (let p of m.parameters) {
            let jsonString = this.cSharpSDK_GetValueFromJson(clazzName, m.name, p.type.source, p.name, "jsonData");
            if (jsonString != null)
                paramslines.push("\t" + jsonString);
        }

        lines.push(`${paramslines.join(",\n")}`);

        lines.push(`); `);
        lines.push(`#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID`);
        lines.push(`});`);
        lines.push(`#endif`);
        lines.push(`break;\n}`);

        return lines.join("\n");

    }

    public cSharpSDK_GenerateH265TranscoderObserverNative(clazzName: string, m: MemberFunction, repeart: number, belongToClazzName: string): string {
        let lines = [];

        let switchKey = `AgoraEventType.EVENT_${Tool.processString("-rv", belongToClazzName)}_${Tool.processString("-v", m.name, repeart)}`;
        lines.push(`case ${switchKey}:\n{`);
        lines.push(`#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID`);
        lines.push(`CallbackObject._CallbackQueue.EnQueue(() => {`);
        lines.push(`#endif`);
        lines.push(`if (EventHandler == null) return;`);
        let methodName = Tool._processStringWithU(m.name);
        lines.push(`EventHandler.${methodName}(`);

        let paramslines = [];

        for (let p of m.parameters) {
            let jsonString = this.cSharpSDK_GetValueFromJson(clazzName, m.name, p.type.source, p.name, "jsonData");
            if (jsonString != null)
                paramslines.push("\t" + jsonString);
        }

        lines.push(`${paramslines.join(",\n")}`);

        lines.push(`); `);
        lines.push(`#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID`);
        lines.push(` }); `);
        lines.push(`#endif`);
        lines.push(`break;\n}`);

        return lines.join("\n");

    }



    public cSharpSDK_GenerateMusicContentCenterEventHandlerNative(clazzName: string, m: MemberFunction, repeart: number, belongToClazzName: string): string {
        let lines = [];
        let switchKey = `AgoraEventType.EVENT_${Tool.processString("-rv", belongToClazzName)}_${Tool.processString("-v", m.name, repeart)}`;
        lines.push(`case ${switchKey}:\n{`);
        lines.push(`#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID`);
        lines.push(`CallbackObject._CallbackQueue.EnQueue(() => {`);
        lines.push(`#endif`);
        lines.push(`if (EventHandler == null) return;`);
        let methodName = Tool._processStringWithU(m.name);
        lines.push(`EventHandler.${methodName}(`);

        let paramslines = [];

        for (let p of m.parameters) {
            let jsonString = this.cSharpSDK_GetValueFromJson(clazzName, m.name, p.type.source, p.name, "jsonData");
            if (jsonString != null)
                paramslines.push("\t" + jsonString);
        }

        lines.push(`${paramslines.join(",\n")}`);

        lines.push(`); `);
        lines.push(`#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID`);
        lines.push(` }); `);
        lines.push(`#endif`);
        lines.push(`break;\n}`);

        return lines.join("\n");

    }

    public cSharpSDK_UTEventReturnValue(clazzName: string, m: MemberFunction, repeart: number, belongToClazzName: string): string {
        let map = {
            bool: "true",
            int64_t: "0",
            int: "0"
        };

        let value = map[m.return_type.source];
        if (value == null) {
            return "";
        }
        else {
            return `return ${value};\n`;
        }
    }

    public cSharpSDK_GenerateUTRtcEngineEventHandler(clazz: Clazz): string {
        let lines = [];
        let config = ConfigTool.getInstance();
        let allMethodDatas = this.cSharpSDK_GetRtcEventHandlerData([]);
        let includeClassStruct = [
            "IRtcEngineEventHandler",
            "IRtcEngineEventHandlerEx"
        ];

        for (let data of allMethodDatas) {
            if (includeClassStruct.includes(data.clazzName) == false)
                continue;
            let clazzName = data.clazzName;
            let m = data.m;
            let repeart = data.repeart;
            lines.push(this.cSharpSDK_GenerateUTCommonEventHandlerEachMethod(clazzName, m, repeart, clazzName));
        }
        return lines.join("\n\n");
    }

    public cSharpSDK_GenerateUTCommonEventHandlerEachMethod(clazzName: string, m: MemberFunction, repeart: number, belongToClazzName: string): string {
        let config = ConfigTool.getInstance();
        let funLines = [];
        let methodName = Tool.processString('-un', m.name, repeart);
        funLines.push(`public bool ${methodName}_be_trigger = false;`);

        let paramslines = [];
        for (let p of m.parameters) {
            let transType = config.paramTypeTrans.transType(clazzName, m.name, p.type.source, p.name);
            let transName = config.paramNameFormalTrans.transType(clazzName, m.name, p.name);

            if (transType == "@remove")
                continue;
            funLines.push(`public ${transType} ${methodName}_${transName};`);
            paramslines.push(`${transType} ${transName}`);
        }
        let tranReturn = config.paramTypeTrans.transType(clazzName, m.name, m.return_type.source, "return");
        funLines.push(`public override ${tranReturn} ${Tool.processString('-u', m.name, repeart)}(${paramslines.join(", ")})\n{`);
        funLines.push(`${methodName}_be_trigger = true;`);

        for (let p of m.parameters) {
            let transType = config.paramTypeTrans.transType(clazzName, m.name, p.type.source, p.name);
            let transName = config.paramNameFormalTrans.transType(clazzName, m.name, p.name);

            if (transType == "@remove")
                continue;
            funLines.push(`${methodName}_${transName}=${transName};`);
        }
        funLines.push(`}\n`);

        funLines.push(`public bool ${methodName}Passed(${paramslines.join(", ")})\n{`);
        funLines.push(`if(${methodName}_be_trigger == false)\n return false;`);
        for (let p of m.parameters) {
            let transType = config.paramTypeTrans.transType(clazzName, m.name, p.type.source, p.name);
            let transName = config.paramNameFormalTrans.transType(clazzName, m.name, p.name);

            if (transType == "@remove")
                continue;

            funLines.push(`//if (ParamsHelper.Compare<${transType}>(${methodName}_${transName}, ${transName}) == false)`);
            funLines.push(`//return false;`);
        }
        funLines.push(`return true;}`);
        funLines.push("//////////////////");
        return funLines.join("\n");
    }

    public cSharpSDK_GenerateUnitTest_ICommonObserver(clazzName: string, m: MemberFunction, repeat: number, belongToClazzName: string, passed: boolean = true): string {
        let lines = [];
        lines.push(`[Test]`)
        lines.push(`public void Test_${clazzName}_${Tool.processString('-un', m.name, repeat)}()`)
        lines.push(`{`)

        let className = Tool.processString('-rv', clazzName, 1);
        // let methodName = Tool.processString('-nv', m.name, repeat);

        let methodName = m.name == "onLocalVideoStateChanged" ?
            Tool.processString('-v', m.name, repeat) :
            Tool.processString('-nv', m.name, repeat);

        let config = ConfigTool.getInstance();
        lines.push(`ApiParam.@event = AgoraEventType.EVENT_${className}_${methodName};\n`);
        lines.push(`jsonObj.Clear();\n`);
        let paramsLines = [];
        for (let p of m.parameters) {
            let transType = config.paramTypeTrans.transType(clazzName, m.name, p.type.source, p.name);
            transType = Tool.processString('-f', transType);
            let transName = config.paramNameFormalTrans.transType(clazzName, m.name, p.name);
            if (transType == "@remove")
                continue;
            lines.push(`${transType} ${transName} = ParamsHelper.CreateParam<${transType}>();`);
            lines.push(`jsonObj.Add("${p.name}", ${transName});\n`);
            paramsLines.push(`${config.paramNameActualTrans.transType(clazzName, m.name, p.name)}`);
        }
        lines.push(`var jsonString = LitJson.JsonMapper.ToJson(jsonObj);`)
        lines.push(`ApiParam.data = jsonString;`);
        lines.push(`ApiParam.data_size = (uint)jsonString.Length;\n`);
        lines.push(`int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);`);
        lines.push(`Assert.AreEqual(0, ret);`);

        lines.push(`Assert.AreEqual(${passed}, EventHandler.${Tool.processString('-un', m.name, repeat)}Passed(${paramsLines.join(',')}));`);
        lines.push(`}`)
        return lines.join("\n");
    }

    public cSharpSDK_GenerateUnitTest_IAudioSpectrumObserver(clazzName: string, m: MemberFunction, repeat: number, belongToClazzName: string): string {
        let config = ConfigTool.getInstance();
        let lines = [];
        let prefixString = this.cSharpSDK_GenerateUnitTest_ICommonObserver(clazzName, m, repeat, belongToClazzName);
        prefixString = prefixString.substring(0, prefixString.length - 2);
        lines.push(prefixString);
        let paramsLines = [];
        for (let p of m.parameters) {
            paramsLines.push(`${config.paramNameActualTrans.transType(clazzName, m.name, p.name)}`);
        }
        lines.push(`Assert.AreEqual(true, EventHandlerForMediaPlayer.${Tool.processString('-u', m.name)}Passed(${paramsLines.join(',')}));`)
        lines.push(`}`);
        return lines.join('\n');
    }

    public cSharpSDK_GenerateUnitTest_IRtcEngineEventHandler(clazz: Clazz): string {
        let lines = [];
        let allData = this.cSharpSDK_GetRtcEventHandlerData([]);
        let includeClassStruct = [
            "IRtcEngineEventHandler",
            "IRtcEngineEventHandlerEx"
        ];
        let excludeMethods = [
            "onFacePositionChanged",
            "onCameraCapturerConfigurationChanged",
        ];
        for (let data of allData) {
            if (includeClassStruct.includes(data.clazzName) == false)
                continue;
            let str = this.cSharpSDK_GenerateUnitTest_ICommonObserver(data.clazzName, data.m, data.repeart, data.clazzName, !excludeMethods.includes(data.m.name));
            lines.push(str);
        }

        return lines.join("\n\n");
    }

    public cSharpSDK_GenerateCallApiKey(clazzName: string, m: MemberFunction, repeat: number, belongToClazzName: string): string {
        // return `"${Tool.processString('-r', clazzName)}_${Tool.processString('-n', m.name)}${repeat > 1 ? repeat : ""}"`;
        let specialKeyMap = {

        }

        let key = `AgoraApiType.FUNC_${Tool.processString("-rv", belongToClazzName)}_${Tool.processString("-vn", m.name, repeat)}`;
        if (specialKeyMap[key] == null) {
            return key;
        }
        else {
            return specialKeyMap[key];
        }
    }

    public cSharpSDK_GenerateCallApiKeyWithH265(clazzName: string, m: MemberFunction, repeat: number, belongToClazzName: string): string {
        let clazz: any = ConfigTool.getInstance().getClassOrStruct(clazzName) as any;
        return irisApiId(clazz, m as any, { toUpperCase: false });
    }

    public cSharpSDK_GenerateCallApiKeyWitRtcEngineEventEx(clazzName: string, m: MemberFunction, repeat: number, belongToClazzName: string): string {
        let clazz: any = ConfigTool.getInstance().getClassOrStruct(clazzName) as any;
        let apiId = irisApiId(clazz, m as any, { toUpperCase: false });
        return apiId.replace("Ex", "");
    }
}