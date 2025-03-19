import { Clazz, SimpleType, CXXTYPE, MemberFunction, CXXTerraNode, Variable } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { CustomHead, ProcessRawData } from "../config/common/types";
import { typeConversionTable } from "../config/common/type_conversion_table.config";
import { StringProcess } from "./string_process";
import { processMethodName, processMethodObsolete, processMethodParameters, processMethodReturn } from "./method_process";

export function processClassWithCustomHeadPre(clazz: Clazz, customHead: CustomHead, processRawData: ProcessRawData) {
    let clonedParseResult: ParseResult = global.clonedParseResult;
    clazz.user_data = clazz.user_data || {};
    clazz.user_data.isHide = customHead.isHide;
    clazz.user_data.customMethods = customHead.custom_methods;
    clazz.user_data.parent = customHead.parent;
    clazz.user_data.isAbstract = customHead.isAbstract;
    clazz.methods.forEach(method => {
        method.user_data = method.user_data || {};
        if (customHead.hide_methods?.includes(method.name)) {
            method.user_data.isHide = true;
        }
        customHead.methods_with_macros?.forEach(methodWithMacro => {
            if (method.name === methodWithMacro.name) {
                method.user_data.macro = methodWithMacro.macro;
            }
        });
    });
}

export function processClassWithCustomHeadPost(clazz: Clazz, customHead: CustomHead, processRawData: ProcessRawData) {
    let clonedParseResult: ParseResult = global.clonedParseResult;
    customHead.merge_nodes?.forEach(nodeInfo => {
        const mergeNodeClazz = clonedParseResult.resolveNodeByName(nodeInfo.name) as Clazz;
        if (mergeNodeClazz) {
            mergeNodeClazz.user_data = mergeNodeClazz.user_data || {};
            clazz.user_data = clazz.user_data || {};
            if (mergeNodeClazz.user_data.customMethods) {
                clazz.user_data.customMethods = clazz.user_data.customMethods || [];
                clazz.user_data.customMethods.push(...mergeNodeClazz.user_data.customMethods);
            }
            clazz.methods.push(...mergeNodeClazz.methods);
            mergeNodeClazz.user_data.isHide = nodeInfo.isHide;
        }
        else {
            console.error(`mergeNodeClazz ${nodeInfo.name} not found in processClassWithCustomHeadPost`);
        }
    });
}


export function processClassCommonAttributes(clazz: Clazz, processRawData: ProcessRawData) {
    clazz.methods.forEach(method => {
        processRawData.method = method;
        processClassName(clazz, processRawData);
        processMethodObsolete(method, processRawData);
        processMethodName(method, processRawData);
        processMethodReturn(method, processRawData);
        processMethodParameters(method, processRawData);
    });
}

//处理类名在不同的文件中的显示
export function processClassName(clazz: Clazz, processRawData: ProcessRawData) {
    clazz.user_data = clazz.user_data || {};
    const name = clazz.name;
    const interfaceName = name;
    const middleName = StringProcess.processString("-r", name);
    const implName = StringProcess.processString("-r", name) + "Impl";
    clazz.user_data.interfaceNameString = interfaceName;
    clazz.user_data.middleNameString = middleName;
    clazz.user_data.implNameString = implName;
}