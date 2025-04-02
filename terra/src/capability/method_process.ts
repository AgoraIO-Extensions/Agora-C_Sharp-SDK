import { Clazz, SimpleType, CXXTYPE, MemberFunction, CXXTerraNode, Variable } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { CustomHead, ProcessRawData } from "../type_definition";
import { typeConversionTable } from "../config/common/type_conversion_table.config";
import {
    processMethodParameterActualString,
    processMethodParameterAddToJson,
    processMethodParameterFormalString,
    processMethodParameterFormalVariableName,
    processMethodParameterGetFromJsonUsedInCallback,
    processMethodParameterSignatureString,
    processMethodParameterSignatureWithoutDecorateString,
    processMethodRefParameterGetFromJson
} from "./method_parameter_process";
import { matchReg, processNodeObsolete, processVariableGetFromJson } from "./common";
import { methodReturnDefaultValueTable } from "../config/common/method_return_default_value_table.config";

export function processMethods(methods: MemberFunction[], processRawData: ProcessRawData) {
    methods.forEach(method => {
        processRawData.method = method;
        method.user_data = method.user_data || {};
        processMethodCommonAttributes(method, processRawData);
        processMethodHide(method, processRawData);
        processMethodMacro(method, processRawData);
        processNodeObsolete(method, processRawData);
        processMethodName(method, processRawData);
        processMethodReturn(method, processRawData);
        processMethodParameters(method, processRawData);
        processMethodHash(method, processRawData);
    });
}

export function processMethodHide(method: MemberFunction, processRawData: ProcessRawData) {
    const customHead = processRawData.customHead;
    if (customHead?.hide_methods?.includes(method.name)) {
        method.user_data.isHide = true;
    }
}

export function processMethodMacro(method: MemberFunction, processRawData: ProcessRawData) {
    const customHead = processRawData.customHead;
    customHead?.methods_with_macros?.forEach(methodWithMacro => {
        if (method.name === methodWithMacro.name) {
            method.user_data.macro = methodWithMacro.macro;
        }
    });
}

export function processMethodCommonAttributes(method: MemberFunction, processRawData: ProcessRawData) {
    const customHead = processRawData.customHead;
    if (customHead) {
        method.user_data.isCallbackCrossThread = customHead.is_callback_cross_thread;
        method.user_data.listenersMapName = customHead.listeners_map_name;
        method.user_data.listenersMapKey = customHead.listeners_map_key;
        method.user_data.listenersMapKeyType = customHead.listeners_map_key_type;
        method.user_data.listenerName = customHead.listener_name;
    }
}

//Process function name
export function processMethodName(method: MemberFunction, processRawData: ProcessRawData) {
    const name = method.name;
    const capitalizedName = name.charAt(0).toUpperCase() + name.slice(1);
    method.user_data = method.user_data || {};
    method.user_data.nameString = capitalizedName;
}

//Process function return value
export function processMethodReturn(method: MemberFunction, processRawData: ProcessRawData) {
    const returnType = method.return_type;
    const returnTypeString = processMethodReturnTypeString(returnType, processRawData);
    const returnValueString = processMethodReturnValueString(returnType, processRawData);
    const returnValueGetFromJsonString = processMethodReturnValueGetFromJson(method, processRawData);
    method.user_data = method.user_data || {};
    method.user_data.returnTypeString = returnTypeString;
    method.user_data.returnValueString = returnValueString;
    method.user_data.returnValueGetFromJsonString = returnValueGetFromJsonString;
}

//Process function parameter list
export function processMethodParameters(method: MemberFunction, processRawData: ProcessRawData) {
    const parameters = method.parameters;
    parameters.forEach((parameter, index) => {
        processRawData.parameter = parameter;
        processRawData.index = index;
        parameter.user_data = parameter.user_data || {};
        parameter.user_data.formalParameterString = processMethodParameterFormalString(parameter, processRawData);
        parameter.user_data.signatureParameterString = processMethodParameterSignatureString(parameter, processRawData);
        parameter.user_data.signatureWithoutDecorateParameterString = processMethodParameterSignatureWithoutDecorateString(parameter, processRawData);
        parameter.user_data.actualParameterString = processMethodParameterActualString(parameter, processRawData);
        parameter.user_data.parameterAddToJsonString = processMethodParameterAddToJson(parameter, processRawData);
        parameter.user_data.refParameterGetFromJsonGetString = processMethodRefParameterGetFromJson(parameter, processRawData);
        parameter.user_data.parameterGetFromJsonUsedInCallback = processMethodParameterGetFromJsonUsedInCallback(parameter, processRawData);
        parameter.user_data.nameString = processMethodParameterFormalVariableName(parameter, processRawData);
        parameter.user_data.isHide = parameter.user_data.formalParameterString == "";
    });

    method.user_data = method.user_data || {};
    let _method_attributes = (method: MemberFunction, key: string, seq: string) => {
        let attributesArray = [];
        method.parameters.forEach(param => {
            if (param.user_data[key]) {
                attributesArray.push(param.user_data[key]);
            }
        });
        method.user_data[key] = attributesArray.join(seq);
    }
    //Formal parameters in interface.ts file
    _method_attributes(method, "formalParameterString", ", ");
    //Actual parameters in mid.ts file
    _method_attributes(method, "actualParameterString", ", ");
    //_params.add() in impl.ts file
    _method_attributes(method, "parameterAddToJsonString", "\n");
    //getFromJson in impl.ts file
    _method_attributes(method, "refParameterGetFromJsonGetString", "\n");
    //getFromJson in observerNative.ts file
    _method_attributes(method, "parameterGetFromJsonUsedInCallback", ",\n\t\t\t\t\t\t\t");
    //Parameter signature
    _method_attributes(method, "signatureParameterString", ", ");
}

export function processMethodHash(method: MemberFunction, processRawData: ProcessRawData) {
    let value: string = method.user_data.IrisApiIdParser.value;
    if (value.split("_").length == 3) {
        method.user_data.hash = value.split("_").pop();
    }
}

//Convert function return value
export function processMethodReturnTypeString(type: SimpleType, processRawData: ProcessRawData): string {
    //Check if matched normal type
    const typeSource = type.source;
    if (typeConversionTable.normal[typeSource]) {
        return typeConversionTable.normal[typeSource];
    }

    //Check if matched regex pattern
    const reg = typeConversionTable.reg;
    for (let key in reg) {
        let inputTemplate: string = key as string;
        let outputTemplate: string = reg[key];
        let out = matchReg(inputTemplate, typeSource, outputTemplate);
        if (out) {
            return out;
        }
    }

    return typeSource;
}

//Process default return value in callback function body. Return value is used in two places: 1. Inside callback function body 2. Inside API interface body
export function processMethodReturnValueString(type: SimpleType, processRawData: ProcessRawData): { callback: string, interface: string, impl: string, ut: string } {
    const typeString = processMethodReturnTypeString(type, processRawData);
    let defaultResult = {
        callback: "config this to method_return_default_value_table.config.ts",
        interface: "config this to method_return_default_value_table.config.ts",
        impl: "config this to method_return_default_value_table.config.ts",
        ut: "config this to method_return_default_value_table.config.ts"
    };

    return methodReturnDefaultValueTable[typeString] || defaultResult;
}

// Get similar to:
// var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
// var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");
export function processMethodReturnValueGetFromJson(method: MemberFunction, processRawData: ProcessRawData) {
    const defaultValue = processMethodReturnValueString(method.return_type, processRawData).impl;
    const returnValueGetFromString = `var result = nRet != 0 ? ${defaultValue} :${processVariableGetFromJson(method.return_type, "_apiParam.Result", "result", processRawData)}`;
    method.user_data = method.user_data || {};
    method.user_data.returnValueGetFromString = returnValueGetFromString;
}