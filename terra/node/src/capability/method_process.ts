import { Clazz, SimpleType, CXXTYPE, MemberFunction, CXXTerraNode, Variable } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { CustomHead, ProcessRawData } from "../rtc/type_definition";
import { typeConversionTable } from "../config/common/type_conversion_table.config";
import {
    processMethodParameterActualString,
    processMethodParameterAddToJson,
    processMethodParameterFormalString,
    processMethodParameterGetFromJsonUsedInCallback,
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
        method.user_data.isCallbackCrossThread = customHead.isCallbackCrossThread;
        method.user_data.listenersMapName = customHead.listenersMapName;
        method.user_data.listenersMapKey = customHead.listenersMapKey;
        method.user_data.listenersMapKeyType = customHead.listenersMapKeyType;
        method.user_data.listenerName = customHead.listenerName;
    }
}

//处理函数的名字
export function processMethodName(method: MemberFunction, processRawData: ProcessRawData) {
    const name = method.name;
    const capitalizedName = name.charAt(0).toUpperCase() + name.slice(1);
    method.user_data = method.user_data || {};
    method.user_data.nameString = capitalizedName;
}

//处理函数的返回值
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





//处理函数的参数列表
export function processMethodParameters(method: MemberFunction, processRawData: ProcessRawData) {
    const parameters = method.parameters;
    parameters.forEach((parameter, index) => {
        processRawData.parameter = parameter;
        processRawData.index = index;
        parameter.user_data = parameter.user_data || {};
        parameter.user_data.formalParameterString = processMethodParameterFormalString(parameter, processRawData);
        parameter.user_data.actualParameterString = processMethodParameterActualString(parameter, processRawData);
        parameter.user_data.parameterAddToJsonString = processMethodParameterAddToJson(parameter, processRawData);
        parameter.user_data.refParameterGetFromJsonGetString = processMethodRefParameterGetFromJson(parameter, processRawData);
        parameter.user_data.parameterGetFromJsonUsedInCallback = processMethodParameterGetFromJsonUsedInCallback(parameter, processRawData);
    });

    method.user_data = method.user_data || {};

    //interface.ts 文件中的形参
    let formalParameterStringArray = [];
    method.parameters.forEach(param => {
        if (param.user_data.formalParameterString) {
            formalParameterStringArray.push(param.user_data.formalParameterString);
        }
    });
    method.user_data.formalParameterString = formalParameterStringArray.join(", ");

    //mid.ts 文件中的实参
    let actualParameterStringArray = [];
    method.parameters.forEach(param => {
        if (param.user_data.actualParameterString) {
            actualParameterStringArray.push(param.user_data.actualParameterString);
        }
    });
    method.user_data.actualParameterString = actualParameterStringArray.join(", ");

    //impl.ts 文件中的_params.add()
    let parameterAddToJsonStringArray = [];
    method.parameters.forEach(param => {
        if (param.user_data.parameterAddToJsonString) {
            parameterAddToJsonStringArray.push(param.user_data.parameterAddToJsonString);
        }
    });
    method.user_data.parameterAddToJsonString = parameterAddToJsonStringArray.join("\n");

    //impl.ts 文件中的getFromJson
    let parameterGetFromJsonGetStringArray = [];
    method.parameters.forEach(param => {
        if (param.user_data.refParameterGetFromJsonGetString) {
            parameterGetFromJsonGetStringArray.push(param.user_data.refParameterGetFromJsonGetString);
        }
    });
    method.user_data.refParameterGetFromJsonGetString = parameterGetFromJsonGetStringArray.join("\n");

    //observerNative.ts 文件中的getFromJson
    let parameterGetFromJsonUsedInCallbackArray = [];
    method.parameters.forEach(param => {
        if (param.user_data.parameterGetFromJsonUsedInCallback) {
            parameterGetFromJsonUsedInCallbackArray.push(param.user_data.parameterGetFromJsonUsedInCallback);
        }
    });
    method.user_data.parameterGetFromJsonUsedInCallback = parameterGetFromJsonUsedInCallbackArray.join(",\n\t\t\t\t\t\t\t");
}

//用来转换函数的返回值
export function processMethodReturnTypeString(type: SimpleType, processRawData: ProcessRawData): string {
    //是否匹配了普通
    const typeSource = type.source;
    if (typeConversionTable.normal[typeSource]) {
        return typeConversionTable.normal[typeSource];
    }

    //是否匹配了正则
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

//处理回调函数的函数体内的默认返回值。返回值用在两个地方：1. 回调函数体内 2. API接口体内   
export function processMethodReturnValueString(type: SimpleType, processRawData: ProcessRawData): { callback: string, interface: string, impl: string } {
    const typeString = processMethodReturnTypeString(type, processRawData);
    let defaultResult = {
        callback: "config this to method_return_default_value_table.config.ts",
        interface: "config this to method_return_default_value_table.config.ts",
        impl: "config this to method_return_default_value_table.config.ts"
    };

    return methodReturnDefaultValueTable[typeString] || defaultResult;
}

// 得到类似
// var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
// var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");
export function processMethodReturnValueGetFromJson(method: MemberFunction, processRawData: ProcessRawData) {
    const defaultValue = processMethodReturnValueString(method.return_type, processRawData).impl;
    const returnValueGetFromString = `var result = nRet != 0 ? ${defaultValue} :${processVariableGetFromJson(method.return_type, "_apiParam.Result", "result", processRawData)}`;
    method.user_data = method.user_data || {};
    method.user_data.returnValueGetFromString = returnValueGetFromString;
}