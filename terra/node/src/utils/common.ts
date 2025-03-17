import {
    Clazz,
    CXXFile,
    CXXTYPE,
    MemberFunction,
    CXXTerraNode
} from "@agoraio-extensions/cxx-parser";
import {
    ParseResult,
    RenderResult,
    TerraContext,
} from "@agoraio-extensions/terra-core";
import { CustomHead } from "../config/common/types";


export function isInterface(node: CXXTerraNode): boolean {
    if (node.__TYPE != CXXTYPE.Clazz)
        return false;

    const name = node.name;
    if (!name.startsWith("I"))
        return false;

    if (name.endsWith("Observer") ||
        name.endsWith("Sink") ||
        name.endsWith("EventHandler"))
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
        name.endsWith("EventHandler"))
        return true;

    return false;
}

export function findCustomHead(node: Clazz, customHeads: CustomHead[]): CustomHead {
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

export function processClassWithCustomHeadPre(clazz: Clazz, customHead: CustomHead) {
    let originalParseResult: ParseResult = global.originalParseResult;
    clazz.user_data = clazz.user_data || {};
    clazz.user_data.isHide = customHead.isHide;
    clazz.user_data.customMethods = customHead.custom_methods;
    clazz.user_data.parent = customHead.parent;
    clazz.methods.forEach(method => {
        method.user_data = method.user_data || {};
        if (customHead.exclude_methods?.includes(method.name)) {
            method.user_data.isHide = true;
        }
        customHead.methods_with_macros?.forEach(methodWithMacro => {
            if (method.name === methodWithMacro.name) {
                method.user_data.macro = methodWithMacro.macro;
            }
        });
    });
}

export function processClassWithCustomHeadPost(clazz: Clazz, customHead: CustomHead) {
    let originalParseResult: ParseResult = global.originalParseResult;
    customHead.merge_nodes?.forEach(nodeInfo => {
        const mergeNodeClazz = originalParseResult.resolveNodeByName(nodeInfo.name) as Clazz;
        if (mergeNodeClazz) {
            mergeNodeClazz.user_data = mergeNodeClazz.user_data || {};
            clazz.user_data = clazz.user_data || {};
            if (mergeNodeClazz.user_data.customMethods) {
                clazz.user_data.customMethods = clazz.user_data.customMethods || [];
                clazz.user_data.customMethods.push(...mergeNodeClazz.user_data.customMethods);
            }
            mergeNodeClazz.methods.push(...mergeNodeClazz.methods);
            mergeNodeClazz.user_data.isHide = nodeInfo.isHide;
        }
        else {
            console.error(`mergeNodeClazz ${nodeInfo.name} not found in processClassWithCustomHeadPost`);
        }
    });
}


export function processClassCommonAttributes(clazz: Clazz) {
    clazz.methods.forEach(method => {
        processMethodName(method);
        processMethodReturn(method);
        processMethodParam(method);
    });
}

export function processMethodName(method: MemberFunction) {
    const name = method.name;
    const capitalizedName = name.charAt(0).toUpperCase() + name.slice(1);
    method.user_data = method.user_data || {};
    method.user_data.nameString = capitalizedName;
}

export function processMethodReturn(method: MemberFunction) {
    const returnType = method.return_type;
    const returnTypeString = returnType.name;
    method.user_data = method.user_data || {};
    method.user_data.returnTypeString = returnTypeString;
}

export function processMethodParam(method: MemberFunction) {
    const parameters = method.parameters;
    parameters.forEach(param => {
        param.user_data = param.user_data || {};
        param.user_data.formalParameterString = "hello";
        param.user_data.actualParameterString = "hello";
        param.user_data.paramAddString = "hello";
        param.user_data.jsonGetString = "hello";
    });
    method.user_data.formalParameterString = method.parameters.map(param => param.user_data.formalParameterString).join(", ");
    method.user_data.actualParameterString = method.parameters.map(param => param.user_data.actualParameterString).join(", ");
    method.user_data.paramAddString = method.parameters.map(param => param.user_data.paramAddString).join(";\n");
    method.user_data.jsonGetString = method.parameters.map(param => param.user_data.jsonGetString).join(";\n");
}


