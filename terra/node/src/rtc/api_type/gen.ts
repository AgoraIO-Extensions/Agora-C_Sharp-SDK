import { Clazz, CXXFile, CXXTYPE, MemberFunction, CXXTerraNode } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { findCustomHead, isCallback, isInterface, processIRtcEngineEventHandler } from "../../capability/common";
import { CustomHead } from "../../config/common/types";
import { customHeads } from "../../config/api_type/custom_heads.config";
import { processClassCommonAttributes, processClassWithCustomHeadPost, processClassWithCustomHeadPre } from "../../capability/class_process";


export function gen(clonedParseResult: ParseResult): MemberFunction[] {

    processIRtcEngineEventHandler();

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

    interfaces.forEach((e) => {
        processClassCommonAttributes(e, { clazz: e });
        const customHead = findCustomHead(e, customHeads);
        if (customHead) {
            processClassWithCustomHeadPre(e, customHead, { clazz: e });
        }
    });

    interfaces.forEach((e) => {
        const customHead = findCustomHead(e, customHeads);
        if (customHead) {
            processClassWithCustomHeadPost(e, customHead, { clazz: e });
        }
    });

    callbacks.forEach((e) => {
        processClassCommonAttributes(e, { clazz: e });
        const customHead = findCustomHead(e, customHeads);
        if (customHead) {
            processClassWithCustomHeadPre(e, customHead, { clazz: e });
        }
    });

    callbacks.forEach((e) => {
        const customHead = findCustomHead(e, customHeads);
        if (customHead) {
            processClassWithCustomHeadPost(e, customHead, { clazz: e });
        }
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
















