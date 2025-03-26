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

    interfaces = interfaces.filter((e) => {
        return !e.user_data?.isHide;
    });

    return interfaces;
}
















