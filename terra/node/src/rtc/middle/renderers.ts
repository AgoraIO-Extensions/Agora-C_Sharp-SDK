import { Clazz, CXXFile, CXXTYPE, MemberFunction, CXXTerraNode } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext } from "@agoraio-extensions/terra-core";
import { renderWithConfiguration } from "@agoraio-extensions/terra_shared_configs";
import _ from "lodash";
import path from "path";
import { middleGen } from "./middle_gen";

export default function (
    terraContext: TerraContext,
    args: any,
    originalParseResult: ParseResult
): RenderResult[] {
    const clonedParseResult = _.cloneDeep(originalParseResult);
    global.clonedParseResult = clonedParseResult;

    let interfaces = middleGen(clonedParseResult);

    const mediaRecorderInterface = interfaces.find((e) => {
        return e.name == "IMediaRecorder";
    });

    const musicPlayerInterface = interfaces.find((e) => {
        return e.name == "IMusicPlayer";
    });

    const mediaPlayerInterface = interfaces.find((e) => {
        return e.name == "IMediaPlayer";
    });

    interfaces = interfaces.filter((e) => {
        return e.name != "IMediaRecorder" &&
            e.name != "IMusicPlayer" &&
            e.name != "IMediaPlayer";
    });

    const interfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "middle_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "middle_file_content.mustache"),
        view: interfaces
    });

    const mediaRecorderInterfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "middle_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "middle_file_media_recorder_content.mustache"),
        view: mediaRecorderInterface
    });

    const musicPlayerInterfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "middle_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "middle_file_music_player_content.mustache"),
        view: musicPlayerInterface
    });

    const mediaPlayerInterfaceResult: RenderResult[] = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "middle_file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "middle_file_music_player_content.mustache"),
        view: mediaPlayerInterface
    });

    return [
        ...interfaceResult,
        ...mediaRecorderInterfaceResult,
        ...musicPlayerInterfaceResult,
        ...mediaPlayerInterfaceResult
    ];
}
