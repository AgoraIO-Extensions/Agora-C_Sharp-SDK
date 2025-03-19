import { Clazz, SimpleType, CXXTYPE, MemberFunction, CXXTerraNode, Variable } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { CustomHead, ProcessRawData } from "../config/common/types";
import { typeConversionTable } from "../config/common/type_conversion_table.config";
import { matchReg } from "./common";
import { variableNameConversionTable } from "../config/common/variable_name_conversion_table.config";
import { variableDefaultValueConversionTable } from "../config/common/variable_default_value_conversion_table.config";

//用来处理函数参数的单个形式参数类型 
//(char * channelName, char * deviceId) => (string channelName, ref string deviceId)
export function processMethodParameterFormalString(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);
    let nameString = processMethodParameterFormalName(variable, processRawData);
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

//用来处理函数参数的单个形式实参类型
//(channelName,deviceId) => (channelName, ref deviceId)
export function processMethodParameterActualString(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);

    //typeString为空，说明这个参数被手动的标记为@remove,从参数列表中直接删除了。
    if (typeString == "") {
        return "";
    }

    let nameString = processMethodParameterFormalName(variable, processRawData);
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
export function processMethodParameterFormalName(variable: Variable, processRawData: ProcessRawData): string {
    let nameSource = variable.name;
    let nameString = nameSource;

    if (variableNameConversionTable.normal[nameSource]) {
        nameString = variableNameConversionTable.normal[nameSource];
    }
    return nameString;
}

//用来处理函数的单个形式参数的默认值 
export function processMethodParameterFormalVariableDefaultValue(variable: Variable, processRawData: ProcessRawData): string {
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