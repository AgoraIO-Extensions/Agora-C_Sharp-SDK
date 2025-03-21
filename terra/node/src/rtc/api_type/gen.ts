import { Clazz, CXXFile, CXXTYPE, MemberFunction, CXXTerraNode } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { findCustomHead, isCallback, isInterface, processIAudioFrameObserverBase, processIRtcEngineEventHandler } from "../../capability/common";
import { CustomHead } from "../../config/common/types";
import { customHeads } from "../../config/api_type/custom_heads.config";
import { processClassCommonAttributes, processClassWithCustomHeadPost, processClassWithCustomHeadPre } from "../../capability/class_process";


export function gen(clonedParseResult: ParseResult): MemberFunction[] {

    processIRtcEngineEventHandler();
    processIAudioFrameObserverBase();
    let interfaces: Clazz[] = [];
    let callbacks: Clazz[] = [];

    clonedParseResult.nodes.forEach((file: CXXFile) => {
        file.nodes.forEach((node: CXXTerraNode) => {
            if (isInterface(node)) {
                interfaces.push(node as Clazz);
            } else if (isCallback(node)) {
                callbacks.push(node as Clazz);
            }
        });
    });

    // 不要合并这个三个forEach，因为需要每个流程都对所有元素走一遍，再走下一个流程
    interfaces.forEach((e) => {
        const customHead = findCustomHead(e, customHeads);
        customHead && processClassWithCustomHeadPre(e, { customHead: customHead, clazz: e });
    });

    interfaces.forEach((e) => {
        const customHead = findCustomHead(e, customHeads);
        processClassCommonAttributes(e, { customHead: customHead, clazz: e });
    });

    interfaces.forEach((e) => {
        const customHead = findCustomHead(e, customHeads);
        customHead && processClassWithCustomHeadPost(e, { customHead: customHead, clazz: e });
    });

    // 不要合并这个三个forEach，因为需要每个流程都对所有元素走一遍，再走下一个流程
    callbacks.forEach((e) => {
        const customHead = findCustomHead(e, customHeads);
        customHead && processClassWithCustomHeadPre(e, { customHead: customHead, clazz: e });
    });

    callbacks.forEach((e) => {
        const customHead = findCustomHead(e, customHeads);
        processClassCommonAttributes(e, { customHead: customHead, clazz: e });
    });

    callbacks.forEach((e) => {
        const customHead = findCustomHead(e, customHeads);
        customHead && processClassWithCustomHeadPost(e, { customHead: customHead, clazz: e });
    });

    interfaces = interfaces.filter((e) => {
        return !e.user_data?.isHide;
    });

    callbacks = callbacks.filter((e) => {
        return !e.user_data?.isHide;
    });

    let interfaceMethods: MemberFunction[] = interfaces.map((e) => {
        return e.methods;
    }).flat();

    let callbackMethods: MemberFunction[] = callbacks.map((e) => {
        return e.methods;
    }).flat();

    let methods: MemberFunction[] = [...interfaceMethods, ...callbackMethods];

    return methods;
}
















