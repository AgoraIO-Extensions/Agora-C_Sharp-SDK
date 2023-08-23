import { match } from "assert";
import { Console } from "console";
import path from "path";
import { exit } from "process";
import { json } from "stream/consumers";
import { InferencePriority } from "typescript";
import { ParamNameTrans } from "./ParamNameTrans";
import { ParseClassOrStruct } from "./ParseClassOrStruct";
import { ParseEnumz } from "./ParseEnumz";
import { TemplateClassStruct, TemplateFile, TemplateHeadTail, TemplateJoin, TemplateEnumz } from "./Template"
import { Tool } from "./Tool";
import { ParamTypeTrans } from "./ParamTypeTrans";
import { ConfigTool } from "./ConfigTool";
import { CXXTYPE, Clazz, Enumz, Struct, TerraNode } from "./terra";

export class ParseFile {

    public constructor() {

    }

    public parse(info: TemplateFile, templateJson: any): string {
        let config = ConfigTool.getInstance();
        let array: TerraNode[] = config.getTerraNodeByHeadFile(info.name)
        if (array == null) {
            console.error("parseFile failed, no such file: " + info.name);
            exit(0);
        }

        let outputStr = "";

        for (let e of array) {
            if (e.__TYPE == CXXTYPE.Enumz) {
                if (info.commmonEnumTemplate == null)
                    continue;
                //枚举
                let enumz = e as unknown as Enumz;
                if (info.includeEnum && info.includeEnum.includes(enumz.name) == false) {
                    continue;
                }
                if (info.excludeEnum && info.excludeEnum.includes(enumz.name) == true) {
                    continue;
                }

                let templatePath = info.commmonEnumTemplate;
                if (info.specialEnumTemplate && info.specialEnumTemplate[enumz.name]) {
                    templatePath = info.specialEnumTemplate[enumz.name];
                }


                let templateEnumz: TemplateEnumz = templateJson[info.commmonEnumTemplate];
                if (templateEnumz == null) {
                    console.error(`templateEnumz : ${info.commmonEnumTemplate} not found`);
                    exit(0);
                }

                templateEnumz.name = enumz.name;
                let parseEnumz = new ParseEnumz();
                outputStr += parseEnumz.parse(templateEnumz, templateJson, e as Enumz);
                outputStr += info.splitSymbol;
            }
            else if (e.__TYPE == CXXTYPE.Clazz || e.__TYPE == CXXTYPE.Struct) {
                if (info.commonClassStructTemplate == null)
                    continue;

                //解析class或者结构体
                let structOrClass: Struct | Clazz = e as unknown as (Struct | Clazz);
                if (info.includeClassStruct && info.includeClassStruct.includes(structOrClass.name) == false) {
                    continue;
                }
                if (info.excludeClassStruct && info.excludeClassStruct.includes(structOrClass.name) == true) {
                    continue;
                }

                let templatePath = info.commonClassStructTemplate;
                if (info.specialClassStructTemplate && info.specialClassStructTemplate[structOrClass.name]) {
                    templatePath = info.specialClassStructTemplate[structOrClass.name];
                }


                let templateClassStruct: TemplateClassStruct = templateJson[info.commonClassStructTemplate];
                if (templateClassStruct == null) {
                    console.error(`templateClassStruct : ${info.commmonEnumTemplate} not found`);
                    exit(0);
                }
                templateClassStruct.name = structOrClass.name;
                let parseClassOrStruct = new ParseClassOrStruct();
                outputStr += parseClassOrStruct.parse(templateClassStruct, templateJson);
                outputStr += info.splitSymbol;
            }
        }

        return outputStr;
    }


}




