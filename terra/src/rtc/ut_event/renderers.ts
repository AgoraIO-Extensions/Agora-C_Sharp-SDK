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
    const callbacks = gen(clonedParseResult);

    const eventsResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "callback_event_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "callback_event_content.mustache"),
        view: callbacks
    });

    return [
        ...eventsResult
    ];
}
