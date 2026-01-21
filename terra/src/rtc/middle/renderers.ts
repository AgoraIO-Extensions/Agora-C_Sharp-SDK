import { Clazz, CXXFile, CXXTYPE, MemberFunction, CXXTerraNode } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext } from "@agoraio-extensions/terra-core";
import { renderWithConfiguration } from "@agoraio-extensions/terra_shared_configs";
import _ from "lodash";
import path from "path";
import { gen } from "./gen";

export default function (
    terraContext: TerraContext,
    args: any,
    originalParseResult: ParseResult
): RenderResult[] {
    const clonedParseResult = _.cloneDeep(originalParseResult);
    global.clonedParseResult = clonedParseResult;

    let interfaces = gen(clonedParseResult);

    const mediaRecorderInterface = interfaces.find((e) => {
        return e.name == "IMediaRecorder";
    });

    const musicPlayerInterface = interfaces.find((e) => {
        return e.name == "IMusicPlayer";
    });

    const mediaPlayerInterface = interfaces.find((e) => {
        return e.name == "IMediaPlayer";
    });

    const videoEffectObjectInterface = interfaces.find((e) => {
        return e.name == "IVideoEffectObject";
    });

    interfaces = interfaces.filter((e) => {
        return e.name != "IMediaRecorder" &&
            e.name != "IMusicPlayer" &&
            e.name != "IMediaPlayer" &&
            e.name != "IVideoEffectObject";
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

    const musicPlayerInterfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "interface_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "interface_file_media_player_content.mustache"),
        view: musicPlayerInterface
    });

    const mediaPlayerInterfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "interface_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "interface_file_media_player_content.mustache"),
        view: mediaPlayerInterface
    });

    const videoEffectObjectInterfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "interface_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "interface_file_video_effect_object_content.mustache"),
        view: videoEffectObjectInterface
    });

    return [
        ...interfaceResult,
        ...mediaRecorderInterfaceResult,
        ...musicPlayerInterfaceResult,
        ...mediaPlayerInterfaceResult,
        ...videoEffectObjectInterfaceResult
    ];
}
