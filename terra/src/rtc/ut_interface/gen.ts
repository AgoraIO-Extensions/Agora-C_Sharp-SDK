import { Clazz, CXXFile, CXXTYPE, MemberFunction, CXXTerraNode } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { findCustomHead, isCallback, isInterface, processIAudioFrameObserverBase, processIRtcEngineEventHandler, processIVideoFrameObserver } from "../../capability/common";
import { CustomHead } from "../../type_definition";
import { customHeads } from "../../config/ut_interface/custom_heads.config";
import { processClassCommonAttributes, processClassWithCustomHeadPost, processClassWithCustomHeadPre } from "../../capability/class_process";


export function gen(clonedParseResult: ParseResult): { interfaces: Clazz[], callbacks: Clazz[] } {

    processIRtcEngineEventHandler();
    processIAudioFrameObserverBase();
    processIVideoFrameObserver();

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

    // Don't merge these three forEach loops, as each process needs to run on all elements before moving to the next process
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

    return { interfaces, callbacks };
}
















