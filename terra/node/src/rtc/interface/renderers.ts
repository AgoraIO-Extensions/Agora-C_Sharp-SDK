import {
    Clazz,
    CXXFile,
    CXXTYPE,
    MemberFunction,
} from "@agoraio-extensions/cxx-parser";
import {
    ParseResult,
    RenderResult,
    TerraContext,
} from "@agoraio-extensions/terra-core";

import { renderWithConfiguration } from "@agoraio-extensions/terra_shared_configs";

import path from "path";
import _ from "lodash";
import { interfaceGen } from "./interfaceGen";

export default function (
    terraContext: TerraContext,
    args: any,
    originalParseResult: ParseResult
): RenderResult[] {
    global.originalParseResult = originalParseResult;
    const { interfaces, callbacks } = interfaceGen(originalParseResult);
    const interfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "interface_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "interface_file_content.mustache"),
        view: interfaces
    });

    return interfaceResult;
}
