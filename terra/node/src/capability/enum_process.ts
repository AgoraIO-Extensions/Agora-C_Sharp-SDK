import { Clazz, Enumz } from "@agoraio-extensions/cxx-parser";
import { ProcessRawData } from "../rtc/type_definition";
import { processNodeObsolete } from "./common";
import { processEnumConstant } from "./enum_constant_process";

export function processEnumWithCustomHead(enumz: Enumz, processRawData: ProcessRawData) {
    enumz.user_data = enumz.user_data || {};
    enumz.user_data.parent = processRawData.customHead.parent;
    enumz.user_data.attributes = processRawData.customHead.attributes;
}

export function processEnumCommonAttributes(enumz: Enumz, processRawData: ProcessRawData) {
    enumz.user_data = enumz.user_data || {};
    enumz.user_data.isEnumz = true;
    enumz.enum_constants.forEach(enumConstant => {
        processEnumConstant(enumConstant, processRawData);
    });
}