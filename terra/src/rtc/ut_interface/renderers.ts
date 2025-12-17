import { Clazz } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext } from "@agoraio-extensions/terra-core";
import { renderWithConfiguration } from "@agoraio-extensions/terra_shared_configs";

import path from "path";
import _ from "lodash";
import { gen } from "./gen";
export default function (
    terraContext: TerraContext,
    args: any,
    originalParseResult: ParseResult
): RenderResult[] {
    const clonedParseResult = _.cloneDeep(originalParseResult);
    global.clonedParseResult = clonedParseResult;
    const { interfaces, callbacks } = gen(clonedParseResult);

    const interfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "interface_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "interface_file_content.mustache"),
        view: interfaces
    });

    const callbackResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "callback_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "callback_file_content.mustache"),
        view: callbacks
    });

    return [
        ...interfaceResult,
        ...callbackResult,
    ];
}
