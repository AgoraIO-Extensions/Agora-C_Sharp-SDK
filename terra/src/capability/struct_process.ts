import { Clazz, CXXFile, CXXTYPE, Enumz, Struct } from "@agoraio-extensions/cxx-parser";
import { ProcessRawData } from "../type_definition";
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
        return member.user_data?.optional;
    });
    if (hasOptional) {
        struct.user_data.parent = "IOptionalJsonParse"
        struct.user_data.optional = true;
        processStructToJson(struct, processRawData);
    }
    else {
        struct.user_data.optional = false;
    }
}

//生成ToJson
function processStructToJson(struct: Clazz, processRawData: ProcessRawData) {
    if (struct.name == "CameraCapturerConfiguration") {
        console.log("fuck me");
    }
    for (let memebr of struct.member_variables) {
        if (memebr.user_data.isHide || memebr.user_data.isHideToJson)
            continue;
        let typeWithoutOptionalString = memebr.user_data.typeWithoutOptionalString;
        if (isStructOrClazz(typeWithoutOptionalString)) {
            memebr.user_data.isStructOrClazz = true;
        }
        else if (isEnumz(typeWithoutOptionalString)) {
            memebr.user_data.isEnumz = true;
        }
        else {
            memebr.user_data.isOther = true;
        }
    }
}

