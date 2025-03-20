import { Clazz, CXXFile, CXXTYPE, MemberFunction, CXXTerraNode } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { customHeads } from "../../config/middle/custom_heads.config";
import { findCustomHead, isInterface } from "../../capability/common";
import { processClassCommonAttributes, processClassWithCustomHeadPost, processClassWithCustomHeadPre } from "../../capability/class_process";


export function gen(clonedParseResult: ParseResult): Clazz[] {

    let interfaces: Clazz[] = [];

    clonedParseResult.nodes.forEach((file: CXXFile) => {
        file.nodes.forEach((node: CXXTerraNode) => {
            if (isInterface(node)) {
                interfaces.push(node as Clazz);
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

    interfaces = interfaces.filter((e) => {
        return !e.user_data?.isHide;
    });

    return interfaces;
}
















