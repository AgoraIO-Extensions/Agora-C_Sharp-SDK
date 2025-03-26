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
    global.args = args;

    let cxxFiles = gen(clonedParseResult);

    //删除不含有任何需要render节点的cxxFile,避免生成空白的文件
    cxxFiles = cxxFiles.filter((e) => {
        return e.nodes.some((node) => {
            return !node.user_data?.isHide;
        })
    });


    const result = renderWithConfiguration({
        fileNameTemplatePath: path.join(__dirname, "file_name.mustache"),
        fileContentTemplatePath: path.join(__dirname, "file_content.mustache"),
        view: cxxFiles
    });

    return result;
}
