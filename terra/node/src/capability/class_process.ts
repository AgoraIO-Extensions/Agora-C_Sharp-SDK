import { Clazz, SimpleType, CXXTYPE, MemberFunction, CXXTerraNode, Variable } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { CustomHead, ProcessRawData } from "../rtc/type_definition";
import { typeConversionTable } from "../config/common/type_conversion_table.config";
import { StringProcess } from "./string_process";
import { processMethods } from "./method_process";
import _ from "lodash";

export function processClassWithCustomHeadPre(clazz: Clazz, processRawData: ProcessRawData) {
    const customHead = processRawData.customHead;
    clazz.user_data = clazz.user_data || {};
    clazz.user_data.isHide = customHead.isHide;
    clazz.user_data.customMethods = customHead.custom_methods;
    clazz.user_data.parent = customHead.parent;
    clazz.user_data.isAbstract = customHead.isAbstract;
    clazz.user_data.isCallbackCrossThread = customHead.isCallbackCrossThread;
    clazz.user_data.listenersMapName = customHead.listenersMapName;
    clazz.user_data.listenersMapKey = customHead.listenersMapKey;
    clazz.user_data.listenersMapKeyType = customHead.listenersMapKeyType;
    clazz.user_data.listenerName = customHead.listenerName;
}

export function processClassWithCustomHeadPost(clazz: Clazz, processRawData: ProcessRawData) {
    let clonedParseResult: ParseResult = global.clonedParseResult;
    const customHead = processRawData.customHead;
    customHead?.merge_nodes?.forEach(nodeInfo => {
        const mergeNodeClazz = clonedParseResult.resolveNodeByName(nodeInfo.name) as Clazz;
        if (mergeNodeClazz) {
            mergeNodeClazz.user_data = mergeNodeClazz.user_data || {};
            clazz.user_data = clazz.user_data || {};
            if (mergeNodeClazz.user_data.customMethods) {
                clazz.user_data.customMethods = clazz.user_data.customMethods || [];
                clazz.user_data.customMethods.push(...mergeNodeClazz.user_data.customMethods);
            }
            mergeNodeClazz.user_data.isHide = nodeInfo.isHide;

            let clonedMergeNoodeMehtods = _.cloneDeep(mergeNodeClazz.methods);
            if (nodeInfo.override_method_hide) {
                clonedMergeNoodeMehtods.forEach(method => {
                    method.user_data.isHide = false;
                });
                clonedMergeNoodeMehtods.forEach(method => {
                    method.user_data = method.user_data || {};
                    if (customHead.hide_methods?.includes(method.name)) {
                        method.user_data.isHide = true;
                    }
                });
            }
            clazz.methods.push(...clonedMergeNoodeMehtods);
        }
        else {
            console.error(`mergeNodeClazz ${nodeInfo.name} not found in processClassWithCustomHeadPost`);
        }
    });
}

export function processClassCommonAttributes(clazz: Clazz, processRawData: ProcessRawData) {
    processClassName(clazz, processRawData);
    processMethods(clazz.methods, processRawData);
}

//处理类名在不同的文件中的显示
export function processClassName(clazz: Clazz, processRawData: ProcessRawData) {
    clazz.user_data = clazz.user_data || {};
    const name = clazz.name;
    const interfaceName = name;
    const middleName = StringProcess.processString("-r", name);
    const implName = StringProcess.processString("-r", name) + "Impl";
    const observerName = StringProcess.processString("-r", name) + "Native";
    clazz.user_data.interfaceNameString = interfaceName;
    clazz.user_data.middleNameString = middleName;
    clazz.user_data.implNameString = implName;
    clazz.user_data.observerNameString = observerName;
}