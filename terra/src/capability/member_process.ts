import { MemberVariable } from "@agoraio-extensions/cxx-parser";
import { ProcessRawData } from "../type_definition";
import { typeConversionTable } from "../config/common/type_conversion_table.config";
import { matchReg } from "./common";
import { processMethodParameterFormalVariableName } from "./method_parameter_process";

export function processMemberWithCustomHead(member: MemberVariable, processRawData: ProcessRawData) {
    member.user_data = member.user_data || {};

    if (processRawData.customHead.hide_members?.includes(member.name)) {
        member.user_data.isHide = true;
    }
    else {
        member.user_data.isHide = false;
    }

    if (processRawData.customHead.hide_to_json?.includes(member.name)) {
        member.user_data.isHideToJson = true;
    }
    else {
        member.user_data.isHideToJson = false;
    }
}

export function processMember(member: MemberVariable, processRawData: ProcessRawData) {
    processMemberType(member, processRawData);
}



function processMemberType(member: MemberVariable, processRawData: ProcessRawData) {
    member.user_data = member.user_data || {};
    let { source, optional } = processMemberTypeWithOptional(member, processRawData);
    let typeString = processMemberTypeSource(source, processRawData);
    if (typeString == "") {
        member.user_data.isHide = true;
        return;
    }
    member.user_data.typeWithoutOptionalString = typeString;
    if (optional) {
        member.user_data.optional = true;
        member.user_data.typeString = `Optional<${typeString}>`;
        member.user_data.valueString = `new Optional<${typeString}>()`;
    }
    else {
        member.user_data.optional = false;
        member.user_data.typeString = typeString;
    }
    member.user_data.nameString = processMethodParameterFormalVariableName({ name: member.name }, processRawData);
}

function processMemberTypeWithOptional(member: MemberVariable, processRawData: ProcessRawData): { source: string, optional: boolean } {
    let source = member.type.source;
    if (source.includes('Optional<')) {
        source = source.substring(source.indexOf('<') + 1, source.length - 1);
        return { source, optional: true };
    }
    return { source, optional: false };
}

//Used to process the type conversion of a single formal parameter of a function to what it should be in Unity
export function processMemberTypeSource(typeSource: string, processRawData: ProcessRawData): string {

    let typeString = typeSource;
    const specialMethodParamKey =
        processRawData.struct.name + "." + processRawData.member.name;

    const table = typeConversionTable;

    //匹配到了special_class_param
    if (table.special_class_param[specialMethodParamKey]) {
        typeString = table.special_class_param[specialMethodParamKey];
        if (typeString == "@remove") {
            return "";
        }
        else {
            typeString = table.special_class_param[specialMethodParamKey];
            return typeString;
        }
    }

    //Check if matched with normal type
    if (table.normal[typeSource])
        return table.normal[typeSource];

    const reg = table.reg;
    for (let key in reg) {
        let inputTemplate: string = key as string;
        let outputTemplate: string = reg[key];

        let out = matchReg(inputTemplate, typeSource, outputTemplate);
        if (out) {
            return out;
        }
    }
    return typeString;
}

