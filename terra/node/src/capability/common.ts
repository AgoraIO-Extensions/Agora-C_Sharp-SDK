import { Clazz, SimpleType, CXXTYPE, MemberFunction, CXXTerraNode, Variable } from "@agoraio-extensions/cxx-parser";
import { ParseResult, RenderResult, TerraContext, } from "@agoraio-extensions/terra-core";
import { CustomHead, ProcessRawData } from "../config/common/types";
import { typeConversionTable } from "../config/common/type_conversion_table.config";
import { StringProcess } from "./string_process";

export function isInterface(node: CXXTerraNode): boolean {
    if (node.__TYPE != CXXTYPE.Clazz)
        return false;

    const name = node.name;
    if (!name.startsWith("I"))
        return false;

    if (name.endsWith("Observer") ||
        name.endsWith("Sink") ||
        name.endsWith("EventHandler") ||
        name.endsWith("Provider"))
        return false;

    return true;
}

export function isCallback(node: CXXTerraNode): boolean {
    if (node.__TYPE != CXXTYPE.Clazz)
        return false;

    const name = node.name;
    if (!name.startsWith("I"))
        return false;

    if (name.endsWith("Observer") ||
        name.endsWith("Sink") ||
        name.endsWith("EventHandler") ||
        name.endsWith("Provider"))
        return true;

    return false;
}

export function findCustomHead(node: Clazz, customHeads: CustomHead[]): CustomHead {
    const nodeName = node.name;
    const nodeFullName = node.fullName;

    return customHeads.find((customHead) => {
        if (customHead.name_space) {
            const fullName = customHead.name_space?.join("::") + "::" + customHead.name
            if (nodeFullName == fullName)
                return true;
        }
        return nodeName == customHead.name;
    });

}







export function matchReg(inputTemplate: string, cxxTypeSource: string, outputTemplate: string): string {
    let starPos = inputTemplate.indexOf("*");
    if (starPos == -1) {
        console.error("_matchReg error invalid inputTemplate: " + inputTemplate);
        return null;
    }

    let splitArray = inputTemplate.split("*");
    if (splitArray.length > 2) {
        console.error("_matchReg error invalid inputTemplate: " + inputTemplate);
        return null;
    }

    let findStr: string = null;

    if (splitArray[0] == "" && inputTemplate.endsWith(splitArray[1]) && cxxTypeSource.endsWith(splitArray[1])) {
        //类型于 *xxxxyy
        let suffixPos = cxxTypeSource.indexOf(splitArray[1]);
        findStr = cxxTypeSource.substring(0, suffixPos);
    }
    else if (splitArray[1] == "" && inputTemplate.startsWith(splitArray[0]) && cxxTypeSource.startsWith(splitArray[0])) {
        //类似于 xxyyy*
        findStr = cxxTypeSource.substring(splitArray[0].length, cxxTypeSource.length);
    }
    //类型于 xxx*yyy
    else if (cxxTypeSource.startsWith(splitArray[0]) && cxxTypeSource.endsWith(splitArray[1])) {
        let suffixPos = cxxTypeSource.indexOf(splitArray[1]);
        findStr = cxxTypeSource.substring(splitArray[0].length, suffixPos);
    }


    if (findStr) {
        let array = outputTemplate.match(/\${-[a-z]+\*}/g);
        if (array == null) {
            console.error("_matchReg error invalid outputTemplate: " + inputTemplate);
            return null;
        }

        let matchedString = array[0];
        let processedStr = StringProcess.processString(matchedString, findStr);

        outputTemplate = outputTemplate.replace(matchedString, processedStr);
        return outputTemplate;
    }

    return null;
}

//合并 IRtcEngineEventHandlerEx, IDirectCdnStreamingEventHandler 到 IRtcEngineEventHandler
export function processIRtcEngineEventHandler() {
    let clonedParseResult: ParseResult = global.clonedParseResult;
    const event = clonedParseResult.resolveNodeByName("IRtcEngineEventHandler") as Clazz;
    const eventEx = clonedParseResult.resolveNodeByName("IRtcEngineEventHandlerEx") as Clazz;

    eventEx.methods.forEach(methodEx => {
        const method = event.methods.find(m => m.name == methodEx.name);
        if (method) {
            method.user_data = method.user_data || {};
            method.user_data.isHide = true;
        }
    });

    event.methods.push(...eventEx.methods);
}

