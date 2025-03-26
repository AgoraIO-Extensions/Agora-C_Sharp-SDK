import { Clazz, SimpleType, CXXTYPE, MemberFunction, CXXTerraNode, Variable } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { CustomHead, ProcessRawData } from "../rtc/type_definition";
import { typeConversionTable } from "../config/common/type_conversion_table.config";
import { matchReg, processVariableGetFromJson } from "./common";
import { variableNameConversionTable } from "../config/common/variable_name_conversion_table.config";
import { variableDefaultValueConversionTable } from "../config/common/variable_default_value_conversion_table.config";


//todo need 重构

//用来处理函数参数的单个形式参数类型 
//(char * channelName, char * deviceId) => (string channelName, ref string deviceId)
export function processMethodParameterFormalString(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);
    let nameString = processMethodParameterFormalVariableName(variable, processRawData);
    let defaultValueString = processMethodParameterFormalVariableDefaultValue(variable, processRawData);

    //typeString为空，说明这个参数被手动的标记为@remove,从参数列表中直接删除了。
    if (typeString == "") {
        return "";
    }

    if (typeString.includes("ref ")) {
        variable.user_data = variable.user_data || {};
        variable.user_data.isRef = true;
    }
    return typeString + " " + nameString + (defaultValueString ? " = " + defaultValueString : "");
}

//用来处理函数参数的单个形式参数类型 
//(char * channelName, char * deviceId) => (string , ref string)
export function processMethodParameterSignatureString(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);

    //typeString为空，说明这个参数被手动的标记为@remove,从参数列表中直接删除了。
    if (typeString == "") {
        return "";
    }

    if (typeString.includes("ref ")) {
        variable.user_data = variable.user_data || {};
        variable.user_data.isRef = true;
    }
    return typeString;
}


//用来处理函数参数的单个形式实参类型
//(channelName,deviceId) => (channelName, ref deviceId)
export function processMethodParameterActualString(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);

    //typeString为空，说明这个参数被手动的标记为@remove,从参数列表中直接删除了。
    if (typeString == "") {
        return "";
    }

    let nameString = processMethodParameterFormalVariableName(variable, processRawData);
    if (variable.user_data.isRef) {
        nameString = "ref " + nameString;
    }
    return nameString;
}

//用来处理函数的单个形式参数的类型转换到Unity应该是什么
export function processMethodParameterFormalVariableType(variable: Variable, processRawData: ProcessRawData): string {
    let typeSource = variable.type.source;
    let typeString = typeSource;
    const specialMethodParamKey =
        processRawData.clazz.name + "." +
        processRawData.method.name + "." +
        processRawData.parameter.name;

    const table = typeConversionTable;
    //匹配到了
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

    //是否匹配了普通
    if (table.normal[typeSource])
        return table.normal[typeSource];

    const reg = table.reg;
    for (let key in reg) {
        let inputTemplate: string = key as string;
        let outputTemplate: string = reg[key];

        let out = matchReg(inputTemplate, typeSource, outputTemplate);
        if (out) {
            return out;
        }
    }
    return typeString;
}

//用来处理函数的单个形式参数的变量名转换到Unity应该是什么
export function processMethodParameterFormalVariableName(variable: { name: string }, processRawData: ProcessRawData): string {
    let nameSource = variable.name;
    let nameString = nameSource;

    if (variableNameConversionTable.normal[nameSource]) {
        nameString = variableNameConversionTable.normal[nameSource];
    }
    return nameString;
}

//用来处理函数的单个形式参数的默认值 
export function processMethodParameterFormalVariableDefaultValue(variable: { default_value: string }, processRawData: ProcessRawData): string {
    let defaultValue = variable.default_value;
    if (defaultValue == "") {
        return "";
    }
    const table = variableDefaultValueConversionTable;
    const specialMethodParamKey =
        processRawData.clazz.name + "." +
        processRawData.method.name + "." +
        processRawData.parameter.name + ":" +
        defaultValue;

    //尝试匹配special_method_param
    if (table.special_method_param[specialMethodParamKey]) {
        defaultValue = table.special_method_param[specialMethodParamKey];
        if (defaultValue == "@remove") {
            return "";
        }
        else {
            return defaultValue;
        }
    }

    //尝试匹配了普通
    if (table.normal[defaultValue])
        return table.normal[defaultValue];

    //尝试匹配正则
    const reg = table.reg;
    for (let key in reg) {
        let inputTemplate: string = key as string;
        let outputTemplate: string = reg[key];

        let out = matchReg(inputTemplate, defaultValue, outputTemplate);
        if (out) {
            return out;
        }
    }
    return defaultValue;
}

//用来处理函数的单个参数被add进去json字符串
export function processMethodParameterAddToJson(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);

    //该参数已经被标记为@remove，从参数列表中直接删除了。
    if (typeString == "") {
        return "";
    }

    if (variable.user_data.isRef) {
        return "";
    }

    const key = variable.name;
    const value = processMethodParameterFormalVariableName(variable, processRawData);

    return `_param.Add("${key}", ${value});`;
}

export function processMethodRefParameterGetFromJson(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);

    //该参数已经被标记为@remove或者不是ref，从参数列表中直接删除了。
    if (typeString == "") {
        return "";
    }

    if (!variable.user_data.isRef) {
        return "";
    }

    const name = processMethodParameterFormalVariableName(variable, processRawData);
    const value = processVariableGetFromJson(variable, "_apiParam.Result", variable.name, processRawData);
    return `${name} = ${value};`;
}

export function processMethodParameterGetFromJsonUsedInCallback(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);

    //该参数已经被标记为@remove或者不是ref，从参数列表中直接删除了。
    if (typeString == "") {
        return "";
    }

    const name = variable.name;
    const value = processVariableGetFromJson(variable, "jsonData", name, processRawData);
    return value;
}
