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
    let { interfaces, callbacks } = gen(clonedParseResult);

    //interfaces process begin
    const mediaRecorderInterface = interfaces.find((e) => {
        return e.name == "IMediaRecorder";
    });

    const mediaPlayerInterface = interfaces.find((e) => {
        return e.name == "IMediaPlayer";
    });

    const musicPlayerInterface = interfaces.find((e) => {
        return e.name == "IMusicPlayer";
    });

    musicPlayerInterface.methods.forEach((e) => {
        if (e.parent.name == "IMediaPlayer") {
            e.user_data = e.user_data || {};
            e.user_data.isMediaPlayerMethod = true;
        }
    });

    interfaces = interfaces.filter((e) => {
        return e.name != "IMediaRecorder" &&
            e.name != "IMusicPlayer" &&
            e.name != "IMediaPlayer";
    });


    const interfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "interface_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "interface_file_content.mustache"),
        view: interfaces
    });

    const mediaRecorderInterfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "interface_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "interface_file_media_recorder_content.mustache"),
        view: mediaRecorderInterface
    });

    const mediaPlayerInterfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "interface_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "interface_file_media_player_content.mustache"),
        view: mediaPlayerInterface
    });

    const musicPlayerInterfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "interface_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "interface_file_music_player_content.mustache"),
        view: musicPlayerInterface
    });
    //interfaces process end

    const callbackResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "callback_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "callback_file_content.mustache"),
        view: callbacks
    });


    return [
        ...interfaceResult,
        ...mediaRecorderInterfaceResult,
        ...musicPlayerInterfaceResult,
        ...mediaPlayerInterfaceResult,
        ...callbackResult
    ];
}
