import { Clazz, CXXFile, CXXTYPE, MemberFunction, CXXTerraNode } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext } from "@agoraio-extensions/terra-core";
import { renderWithConfiguration } from "@agoraio-extensions/terra_shared_configs";
import { gen } from "./gen";
import _ from "lodash";
import path from "path";

export default function (
    terraContext: TerraContext,
    args: any,
    originalParseResult: ParseResult
): RenderResult[] {
    const clonedParseResult = _.cloneDeep(originalParseResult);
    global.clonedParseResult = clonedParseResult;

    let cxxFiles = gen(clonedParseResult);

    const result = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "file_content.mustache"),
        view: cxxFiles
    });

    return result;
}
