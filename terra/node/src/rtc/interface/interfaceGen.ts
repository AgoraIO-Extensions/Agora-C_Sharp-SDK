import { Clazz, CXXFile, CXXTYPE, MemberFunction, CXXTerraNode } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { findCustomHead, isCallback, isInterface, processClassCommonAttributes, processClassWithCustomHeadPost, processClassWithCustomHeadPre } from "../../utils/common";
import { CustomHead } from "../../config/common/types";
import { customHeads } from "../../config/interface/custom_heads.config";


export function interfaceGen(originalParseResult: ParseResult): { interfaces: CXXTerraNode[], callbacks: CXXTerraNode[] } {

    let interfaces: Clazz[] = [];
    let callbacks: Clazz[] = [];

    originalParseResult.nodes.forEach((file: CXXFile) => {
        file.nodes.forEach((node: CXXTerraNode) => {
            if (isInterface(node)) {
                interfaces.push(node as Clazz);
            } else if (isCallback(node)) {
                callbacks.push(node as Clazz);
            }
        });
    });

    interfaces.forEach((e) => {
        processClassCommonAttributes(e);
        const customHead = findCustomHead(e, customHeads);
        if (customHead) {
            processClassWithCustomHeadPre(e, customHead);
        }
    });

    interfaces.forEach((e) => {
        const customHead = findCustomHead(e, customHeads);
        if (customHead) {
            processClassWithCustomHeadPost(e, customHead);
        }
    });


    callbacks.forEach((e) => {
        processClassCommonAttributes(e);
        const customHead = findCustomHead(e, customHeads);
        if (customHead) {
            processClassWithCustomHeadPre(e, customHead);
        }
    });

    callbacks.forEach((e) => {
        const customHead = findCustomHead(e, customHeads);
        if (customHead) {
            processClassWithCustomHeadPost(e, customHead);
        }
    });


    interfaces = interfaces.filter((e) => {
        return !e.user_data?.isHide;
    });

    callbacks = callbacks.filter((e) => {
        return !e.user_data?.isHide;
    });

    return { interfaces, callbacks };
}
















