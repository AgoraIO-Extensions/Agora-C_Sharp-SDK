import { Clazz, CXXFile, CXXTYPE, Enumz, Struct } from "@agoraio-extensions/cxx-parser";
import { ProcessRawData } from "../type_definition";
import { variableDefaultValueConversionTable } from "../config/common/variable_default_value_conversion_table.config";
import { ParseResult } from "@agoraio-extensions/terra-core";
import { CppConstructor, matchReg, processCppConstructor } from "./common";
import { typeConversionTable } from "../config/common/type_conversion_table.config";
import { processMethodParameterFormalVariableName } from "./method_parameter_process";
import * as path from 'path';

function processStructCtorVariableDefaultValue(type: { default_value: string, name: string }, processRawData: ProcessRawData) {
    let defaultValue = type.default_value;

    const table = variableDefaultValueConversionTable;
    const specialMethodParamKey =
        processRawData.clazz.name + "." +
        processRawData.clazz.name + "." +
        type.name + ":" +
        defaultValue;

    //Try to match special method parameter
    if (table.special_method_param[specialMethodParamKey]) {
        defaultValue = table.special_method_param[specialMethodParamKey];
        if (defaultValue == "@remove") {
            return "";
        }
        else {
            return defaultValue;
        }
    }

    //Try to match normal type
    if (table.normal[defaultValue])
        return table.normal[defaultValue];

    //Try to match regex pattern
    if (defaultValue) {
        const reg = table.reg;
        for (let key in reg) {
            let inputTemplate: string = key as string;
            let outputTemplate: string = reg[key];

            let out = matchReg(inputTemplate, defaultValue, outputTemplate);
            if (out) {
                return out;
            }
        }
    }

    return defaultValue;
}

function processStructCtorVariableType(type: { name: string, source: string }, processRawData: ProcessRawData) {
    let typeString = type.source;

    const specialMethodParamKey =
        processRawData.struct.name + "." +
        processRawData.struct.name + "." +
        type.name;

    const table = typeConversionTable;

    //Matched special class parameter
    if (table.special_method_param[specialMethodParamKey]) {
        typeString = table.special_method_param[specialMethodParamKey];
        if (typeString == "@remove") {
            return "";
        }
        else {
            typeString = table.special_method_param[specialMethodParamKey];
            return typeString;
        }
    }

    //Check if matched normal type
    if (table.normal[type.source])
        return table.normal[type.source];

    if (type.source) {
        const reg = table.reg;
        for (let key in reg) {
            let inputTemplate: string = key as string;
            let outputTemplate: string = reg[key];

            let out = matchReg(inputTemplate, type.source, outputTemplate);
            if (out) {
                return out;
            }
        }
    }

    return typeString;
}

function findTypeByName(name: string, processRawData: ProcessRawData) {
    for (let p of processRawData.struct.member_variables) {
        let transType = processStructCtorVariableType({ name: p.name, source: p.type.source }, processRawData);
        let transName = processMethodParameterFormalVariableName({ name: p.name }, processRawData);
        if (transName == name) {
            return transType;
        }
    }
    return "";
}

function addEnumzPrefixIfIsIsEnumz(value: string, processRawData: ProcessRawData) {
    const clonedParseResult: ParseResult = global.clonedParseResult;
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
    return value;
}

function isMemberHide(name: string, processRawData: ProcessRawData) {
    for (let e of processRawData.struct.member_variables) {
        if (e.name == name) {
            return e.user_data.isHide;
        }
    }
    return false;
}


//Who can understand this code?
export function processUnityConstructor(struct: Clazz, processRawData: ProcessRawData): string {

    const clonedParseResult: ParseResult = global.clonedParseResult;

    //todo if have folder, need to add folder name
    const file_path = path.join(
        "node_modules/@agoraio-extensions/terra_shared_configs/headers",
        global.args.headers_version,
        "include",
        processRawData.cxxFile.fileName
    );
    let cppConstructors: CppConstructor[] = processCppConstructor(struct.name, file_path);

    let lines: string[] = [];
    let baseClazz: Clazz | Struct = null;
    if (struct.base_clazzs.length > 0) {
        baseClazz = clonedParseResult.resolveNodeByName(struct.base_clazzs[0]) as Clazz | Struct;
    }
    for (let constructor of cppConstructors) {

        let constructorLines = [];

        //Parameter list
        if (constructor.parameters.length > 0) {
            let parametersLines = [];
            for (let p of constructor.parameters) {
                if (isMemberHide(p.name, processRawData))
                    continue;

                let transType = processStructCtorVariableType({ name: p.name, source: p.type }, processRawData);
                if (transType == "")
                    continue;

                let transName = processMethodParameterFormalVariableName({ name: p.name }, processRawData);
                let transValue = processStructCtorVariableDefaultValue({ name: p.name, default_value: p.value }, processRawData);
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

        //Parent class constructor is called in initialization list
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

        //Initialization list
        if (constructor.initializes.length > 0) {
            for (let p of constructor.initializes) {
                if (p.name == baseClazzName)
                    continue;

                if (isMemberHide(p.name, processRawData))
                    continue;

                let transType = findTypeByName(p.name, processRawData);
                let transName = processMethodParameterFormalVariableName({ name: p.name }, processRawData);
                let transValue = processStructCtorVariableDefaultValue({ name: p.name, default_value: p.value }, processRawData);

                if (transValue.includes(",") == false || transType == '' || transValue != p.value) {
                    constructorLines.push(`this.${transName} = ${addEnumzPrefixIfIsIsEnumz(transValue, processRawData)};`);
                }
                else {
                    if (transValue.startsWith(transType)) {
                        //Parse similar to: CameraCapturerConfiguration() : format(VideoFormat(0, 0, 0)) {}
                        constructorLines.push(`this.${transName} = new ${transValue};`)
                    }
                    else {
                        let params = transValue.split(",");
                        let transParams = [];
                        for (let p of params) {
                            transParams.push(addEnumzPrefixIfIsIsEnumz(p.trim(), processRawData));
                        }
                        constructorLines.push(`this.${transName} = new ${transType}(${transParams.join(",")});`)
                    }
                }
            }
        }
        constructorLines.push("}\n");
        lines.push(constructorLines.join('\n'));
    }

    //Generate full parameter constructor
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
            if (e.user_data.isHide)
                continue;

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
            if (e.user_data.isHide)
                continue;
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