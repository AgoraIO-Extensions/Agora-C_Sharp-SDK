import { Clazz, CXXFile, Enumz, CXXTerraNode } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { customHeads } from "../../config/struct_enum/custom_heads.config";
import { findCustomHead, isCallback, isInterface, isEnumz } from "../../capability/common";
import { processClassCommonAttributes, processClassWithCustomHeadPost, processClassWithCustomHeadPre } from "../../capability/class_process";
import { processEnumCommonAttributes, processEnumWithCustomHead } from "../../capability/enum_process";
import { processCXXFile } from "../../capability/file_process";
import { processStructCommonAttributes, processStructWithCustomHead } from "../../capability/struct_process";


export function gen(clonedParseResult: ParseResult): CXXFile[] {

    clonedParseResult.nodes.forEach((cxxFile: CXXFile) => {
        processCXXFile(cxxFile, {});
        cxxFile.nodes.forEach((node: CXXTerraNode) => {
            if (isInterface(node) || isCallback(node)) {
                node.user_data = node.user_data || {};
                node.user_data.isHide = true;
            }
            else if (isEnumz(node)) {
                const enumz = node as Enumz;
                let customHead = findCustomHead(enumz, customHeads);
                if (customHead)
                    processEnumWithCustomHead(enumz, { cxxFile, enumz, customHead });
                processEnumCommonAttributes(enumz, { cxxFile, enumz });
            }
            else {
                //must be struct
                const struct = node as Clazz;
                let customHead = findCustomHead(struct, customHeads);
                if (customHead)
                    processStructWithCustomHead(struct, { cxxFile, struct, customHead });
                processStructCommonAttributes(struct, { cxxFile, struct });
            }
        });
    });

    return clonedParseResult.nodes as CXXFile[];
}
















