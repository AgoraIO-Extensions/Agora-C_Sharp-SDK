import { Clazz, SimpleType, CXXTYPE, MemberFunction, CXXTerraNode, Variable } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { CustomHead, ProcessRawData } from "../type_definition";
import { typeConversionTable } from "../config/common/type_conversion_table.config";
import { matchReg, processVariableGetFromJson } from "./common";
import { variableNameConversionTable } from "../config/common/variable_name_conversion_table.config";
import { variableDefaultValueConversionTable } from "../config/common/variable_default_value_conversion_table.config";

//(char * channelName, char * deviceId) => (string channelName, ref string deviceId)
//Process single formal parameter type of function parameters
export function processMethodParameterFormalString(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);
    let nameString = processMethodParameterFormalVariableName(variable, processRawData);
    let defaultValueString = processMethodParameterFormalVariableDefaultValue(variable, processRawData);

    //If typeString is empty, it means this parameter is manually marked as @remove and should be deleted from parameter list
    if (typeString == "") {
        return "";
    }

    if (typeString.includes("ref ")) {
        variable.user_data = variable.user_data || {};
        variable.user_data.isRef = true;
    }
    return typeString + " " + nameString + (defaultValueString ? " = " + defaultValueString : "");
}

//(char * channelName, char * deviceId) => (string , ref string)
//Process single formal parameter type of function parameters
export function processMethodParameterSignatureString(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);

    //If typeString is empty, it means this parameter is manually marked as @remove and should be deleted from parameter list
    if (typeString == "") {
        return "";
    }

    if (typeString.includes("ref ")) {
        variable.user_data = variable.user_data || {};
        variable.user_data.isRef = true;
    }
    return typeString;
}

//(char * channelName, char * deviceId) => (string , ref string)
//Process single formal parameter type of function parameters
export function processMethodParameterSignatureWithoutDecorateString(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);

    //If typeString is empty, it means this parameter is manually marked as @remove and should be deleted from parameter list
    if (typeString == "") {
        return "";
    }

    if (typeString.includes("ref ")) {
        typeString = typeString.replace("ref ", "");
    }
    return typeString;
}


//(channelName,deviceId) => (channelName, ref deviceId)
//Process single actual parameter type of function parameters
export function processMethodParameterActualString(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);

    //If typeString is empty, it means this parameter is manually marked as @remove and should be deleted from parameter list
    if (typeString == "") {
        return "";
    }

    let nameString = processMethodParameterFormalVariableName(variable, processRawData);
    if (variable.user_data.isRef) {
        nameString = "ref " + nameString;
    }
    return nameString;
}

//Convert single formal parameter type to Unity type
export function processMethodParameterFormalVariableType(variable: Variable, processRawData: ProcessRawData): string {
    let typeSource = variable.type.source;
    let typeString = typeSource;
    const specialMethodParamKey =
        processRawData.clazz.name + "." +
        processRawData.method.name + "." +
        processRawData.parameter.name;

    const table = typeConversionTable;
    //Matched special method parameter
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

//Convert single formal parameter variable name to Unity name
export function processMethodParameterFormalVariableName(variable: { name: string }, processRawData: ProcessRawData): string {
    let nameSource = variable.name;
    let nameString = nameSource;

    if (variableNameConversionTable.normal[nameSource]) {
        nameString = variableNameConversionTable.normal[nameSource];
    }
    return nameString;
}

//Process default value of single formal parameter
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

//Process single parameter to be added to json string
export function processMethodParameterAddToJson(variable: Variable, processRawData: ProcessRawData): string {
    let typeString = processMethodParameterFormalVariableType(variable, processRawData);

    //This parameter has been marked as @remove and should be deleted from parameter list
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

    //This parameter has been marked as @remove or is not ref, should be deleted from parameter list
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

    //This parameter has been marked as @remove or is not ref, should be deleted from parameter list
    if (typeString == "") {
        return "";
    }

    const name = variable.name;
    const value = processVariableGetFromJson(variable, "jsonData", name, processRawData);
    return value;
}
