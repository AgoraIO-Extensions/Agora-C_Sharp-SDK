import { Clazz, CXXFile, CXXTYPE, Enumz, Struct } from "@agoraio-extensions/cxx-parser";
import { ProcessRawData } from "../rtc/type_definition";
import { processMember, processMemberTypeSource, processMemberWithCustomHead } from "./member_process";
import { isEnumz, isStructOrClazz, matchReg, processCppConstructor } from "./common";
import { processMethodParameterFormalVariableDefaultValue, processMethodParameterFormalVariableName } from "./method_parameter_process";
import { ParseResult } from "@agoraio-extensions/terra-core";
import { variableDefaultValueConversionTable } from "../config/common/variable_default_value_conversion_table.config";
import { processUnityConstructor } from "./struct_ctor_process";

export function processStructWithCustomHead(struct: Clazz, processRawData: ProcessRawData) {
    struct.user_data = struct.user_data || {};
    struct.user_data.isHide = processRawData.customHead.is_hide;
    struct.user_data.custom_members = processRawData.customHead.custom_members;
    struct.member_variables.forEach(member => {
        processRawData.member = member;
        processMemberWithCustomHead(member, processRawData);
    });
}

export function processStructCommonAttributes(struct: Clazz, processRawData: ProcessRawData) {
    struct.user_data = struct.user_data || {};
    struct.user_data.isStruct = true;
    for (const member of struct.member_variables) {
        processRawData.member = member;
        processMember(member, processRawData);
    }

    //生成构造函数
    struct.user_data.unityConstructorString = processUnityConstructor(struct, processRawData);

    //生成ToJson
    const hasOptional = struct.member_variables.some(member => {
        return member.user_data?.isOptional;
    });
    if (hasOptional) {
        struct.user_data.parent = "IOptionalJsonParse"
        struct.user_data.toJsonString = processToJson(struct, processRawData);
    }
}

//生成ToJson
function processToJson(struct: Clazz, processRawData: ProcessRawData): string {

    let lines: string[] = [];

    lines.push(`\npublic virtual void ToJson(JsonWriter writer){`);
    lines.push(`writer.WriteObjectStart();\n`);
    let writeJson = (clazz: Clazz | Struct, lines: string[]) => {
        for (let memebr of clazz.member_variables) {
            if (memebr.user_data.isHide || memebr.user_data.isHideToJson)
                continue;

            let typeWithoutOptionalString = memebr.user_data.typeWithoutOptionalString;
            let typeString = memebr.user_data.typeString;
            let nameString = memebr.user_data.nameString;

            if (memebr.user_data.isOptional) {
                lines.push(`if (this.${nameString}.HasValue()){`);
            }

            lines.push(`writer.WritePropertyName("${nameString}");`)
            if (isStructOrClazz(typeWithoutOptionalString)) {
                lines.push(`JsonMapper.WriteValue(this.${nameString}${memebr.user_data.isOptional ? ".GetValue()" : ""}, writer, false, 0);`)
            }
            else if (isEnumz(typeWithoutOptionalString)) {
                lines.push(`AgoraJson.WriteEnum(writer, this.${nameString}${memebr.user_data.isOptional ? ".GetValue()" : ""});`)
            }
            else {
                lines.push(`writer.Write(this.${nameString}${memebr.user_data.isOptional ? ".GetValue()" : ""});`)
            }

            if (memebr.user_data.isOptional) {
                lines.push(`}`)
            }
            lines.push(`\n`);

        }
    }
    writeJson(struct, lines);
    lines.push(`writer.WriteObjectEnd();`);
    lines.push(`}`)
    return lines.join('\n');
}
