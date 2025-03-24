import { Clazz, CXXFile, CXXTYPE, Enumz, Struct } from "@agoraio-extensions/cxx-parser";
import { ProcessRawData } from "../rtc/type_definition";
import { processMember, processMemberTypeSource } from "./member_process";
import { isEnumz, isStructOrClazz, processCppConstructor } from "./common";
import { processMethodParameterFormalVariableDefaultValue, processMethodParameterFormalVariableName } from "./method_parameter_process";
import { ParseResult } from "@agoraio-extensions/terra-core";

export function processStructWithCustomHead(struct: Clazz, processRawData: ProcessRawData) {
    struct.user_data = struct.user_data || {};
    struct.user_data.isHide = processRawData.customHead.isHide;
}


export function processStructCommonAttributes(struct: Clazz, processRawData: ProcessRawData) {
    struct.user_data = struct.user_data || {};
    struct.user_data.isStruct = true;
    for (const member of struct.member_variables) {
        processRawData.member = member;
        processMember(member, processRawData);
    }


    //生成构造函数
    struct.user_data.unityConstructorString = processUnityConstructor(struct, processRawData);

    //生成ToJson
    const hasOptional = struct.member_variables.some(member => {
        return member.user_data?.isOptional;
    });
    if (hasOptional) {
        struct.user_data.parent = "IOptionalJsonParse"
        struct.user_data.toJsonString = processToJson(struct, processRawData);
    }
}


//这段代码谁能看的懂哦.
function processUnityConstructor(struct: Clazz, processRawData: ProcessRawData): string {
    const clonedParseResult: ParseResult = global.clonedParseResult;

    const file_path = processRawData.cxxFile.file_path;
    let cppConstructors = processCppConstructor(struct.name, file_path);
    let lines: string[] = [];
    let baseClazz: Clazz | Struct = null;
    if (struct.base_clazzs.length > 0) {
        baseClazz = clonedParseResult.resolveNodeByName(struct.base_clazzs[0]) as Clazz | Struct;
    }
    for (let constructor of cppConstructors) {

        let constructorLines = [];

        //参数列表
        if (constructor.parameters.length > 0) {
            let parametersLines = [];
            for (let p of constructor.parameters) {

                let transType = processMemberTypeSource(p.type, processRawData);
                if (transType == "")
                    continue;

                let transName = processMethodParameterFormalVariableName({ name: p.name }, processRawData);
                let transValue = processMethodParameterFormalVariableDefaultValue({ default_value: p.value }, processRawData);
                if (!transValue) {
                    parametersLines.push(`${transType} ${transName}`);
                }
                else {
                    parametersLines.push(`${transType} ${transName} = ${transValue}`);
                }
            }
            let parametersStr = parametersLines.join(",");
            constructorLines.push(`public ${struct.name}(${parametersStr})`);
        }
        else {
            constructorLines.push(`public ${struct.name}()`);
        }

        //初始化构造列表里调用了父类构造
        let baseClazzName = struct.base_clazzs.length > 0 ? struct.base_clazzs[0] : "";
        if (constructor.initializes.length > 0) {
            for (let e of constructor.initializes) {
                if (e.name == baseClazzName) {
                    constructorLines.push(`:base(${e.value})`);
                    break;
                }
            }
        }
        constructorLines.push(`{`);


        let _findTypeByName = (name: string, processRawData: ProcessRawData) => {
            for (let p of processRawData.struct.member_variables) {
                let transType = processMemberTypeSource(p.source, processRawData);
                let transName = processMethodParameterFormalVariableName({ name: p.name }, processRawData);
                if (transName == name) {
                    return transType;
                }
            }
            return "";
        }

        let _addEnumzPrefixIfIsIsEnumz = (value: string, processRawData: ProcessRawData) => {
            for (let c of clonedParseResult.nodes) {
                let cxxFile = c as CXXFile;
                let nodes = cxxFile.nodes;
                for (let node of nodes) {
                    if (node.__TYPE == CXXTYPE.Enumz) {
                        let enumz: Enumz = node as Enumz;
                        for (let e of enumz.enum_constants) {
                            if (e.name == value) {
                                return `${enumz.name}.${value}`;
                            }
                        }

                    }
                }
            }
            return name;
        }

        //初始化构造列表
        if (constructor.initializes.length > 0) {
            for (let p of constructor.initializes) {
                if (p.name == baseClazzName)
                    continue;
                let transType = _findTypeByName(p.name, processRawData);
                let transName = processMethodParameterFormalVariableName({ name: p.name }, processRawData);
                let transValue = processMethodParameterFormalVariableDefaultValue({ default_value: p.value }, processRawData);
                if (transValue.includes(",") == false || transType == '' || transValue != p.value) {
                    constructorLines.push(`this.${transName} = ${_addEnumzPrefixIfIsIsEnumz(transValue, processRawData)};`);
                }
                else {
                    if (transValue.startsWith(transType)) {
                        //解析类似这种  CameraCapturerConfiguration() : format(VideoFormat(0, 0, 0)) {}
                        constructorLines.push(`this.${transName} = new ${transValue};`)
                    }
                    else {
                        let params = transValue.split(",");
                        let transParams = [];
                        for (let p of params) {
                            transParams.push(_addEnumzPrefixIfIsIsEnumz(p.trim(), processRawData));
                        }
                        constructorLines.push(`this.${transName} = new ${transType}(${transParams.join(",")});`)
                    }
                }
            }
        }
        constructorLines.push("}\n");
        lines.push(constructorLines.join('\n'));
    }

    //生成全量参数构造
    let needFullParamCtor = true;
    let needEmptyParamCtor = true;
    let baseAndThisMemberLength = struct.member_variables.length + (baseClazz ? baseClazz.member_variables.length : 0);
    for (let e of cppConstructors) {
        if (e.parameters.length == baseAndThisMemberLength) {
            needFullParamCtor = false;
        }
        if (e.parameters.length == 0) {
            needEmptyParamCtor = false;
        }
    }
    let _generateParamersLines = (clazz: Clazz | Struct, parametersLines: string[]) => {
        for (let e of clazz.member_variables) {
            let transType = e.user_data.typeString;
            let transName = processMethodParameterFormalVariableName({ name: e.name }, processRawData);
            parametersLines.push(`${transType} ${transName}`);
        }
    }


    if (needFullParamCtor) {
        let constructorLines = [];
        let parametersLines = [];
        if (baseClazz) {
            _generateParamersLines(baseClazz, parametersLines);
        }
        _generateParamersLines(struct, parametersLines);
        let parametersStr = parametersLines.join(",");
        constructorLines.push(`public ${struct.name}(${parametersStr})`);

        if (baseClazz) {
            //C# only support single-inheritance
            let baseParamters: string[] = [];
            for (let e of baseClazz.member_variables) {
                let transName = processMethodParameterFormalVariableName({ name: e.name }, processRawData);
                baseParamters.push(transName);
            }
            constructorLines.push(`: base(${baseParamters.join(',')})`);
        }
        constructorLines.push('{');

        for (let e of struct.member_variables) {
            let transName = processMethodParameterFormalVariableName({ name: e.name }, processRawData);
            constructorLines.push(`this.${transName} = ${transName};`);
        }
        constructorLines.push(`}`);
        lines.push(constructorLines.join('\n'));
    }
    if (needEmptyParamCtor) {
        lines.push(`public ${struct.name}(){\n}\n`);
    }
    return lines.join('\n');
}

//生成ToJson
function processToJson(struct: Clazz, processRawData: ProcessRawData): string {

    let lines: string[] = [];

    lines.push(`\npublic virtual void ToJson(JsonWriter writer){`);
    lines.push(`writer.WriteObjectStart();\n`);
    let writeJson = (clazz: Clazz | Struct, lines: string[]) => {
        for (let memebr of clazz.member_variables) {
            if (memebr.user_data.isHide)
                continue;

            let typeWithoutOptionalString = memebr.user_data.typeWithoutOptionalString;
            let typeString = memebr.user_data.typeString;
            let nameString = memebr.user_data.nameString;
            if (memebr.user_data.isOptional) {
                lines.push(`if (this.${nameString}.HasValue()){`);
                lines.push(`writer.WritePropertyName("${nameString}");`)
                if (isStructOrClazz(typeWithoutOptionalString)) {
                    lines.push(`JsonMapper.WriteValue(this.${nameString}.GetValue(), writer, false, 0);`)
                }
                else if (isEnumz(typeWithoutOptionalString)) {
                    lines.push(`AgoraJson.WriteEnum(writer, this.${nameString}.GetValue());`)
                }
                else {
                    lines.push(`writer.Write(this.${nameString}.GetValue());`)
                }
            }
            else if (isStructOrClazz(typeWithoutOptionalString)) {
                //是class或者struct
                lines.push(`writer.WritePropertyName("${nameString}");`);
                lines.push(`JsonMapper.WriteValue(this.${nameString}, writer, false, 0);\n`);
            }
            else if (isEnumz(typeWithoutOptionalString)) {
                lines.push(`writer.WritePropertyName("${nameString}");`)
                lines.push(`AgoraJson.WriteEnum(writer, this.${nameString});\n`)
            }
            else {
                lines.push(`writer.WritePropertyName("${nameString}");`)
                lines.push(`writer.Write(this.${nameString});\n`)
            }
        }

    }
    writeJson(struct, lines);
    lines.push(`writer.WriteObjectEnd();`);
    lines.push(`}`)
    return lines.join('\n');
}
