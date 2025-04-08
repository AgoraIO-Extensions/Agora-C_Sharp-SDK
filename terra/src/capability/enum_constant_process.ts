import { ProcessRawData } from "../type_definition";
import { Clazz, Enumz, EnumConstant } from "@agoraio-extensions/cxx-parser";
import { processNodeObsolete } from "./common";

export function processEnumConstant(enumConstant: EnumConstant, processRawData: ProcessRawData) {
    processNodeObsolete(enumConstant, processRawData);
}