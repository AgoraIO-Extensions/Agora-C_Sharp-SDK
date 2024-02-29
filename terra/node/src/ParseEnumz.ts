import { exit } from "process";
import { InferencePriority } from "typescript";
import { ParamNameTrans } from "./ParamNameTrans";
import { TemplateEnumz, TemplateHeadTail, TemplateJoin } from "./Template";
import { Tool } from "./Tool";
import { ParamTypeTrans } from "./ParamTypeTrans";
import { ConfigTool } from "./ConfigTool";
import { EnumConstant, Enumz } from "./terra";
import { SpeicalLogic } from "./SpecialLogic";

export class ParseEnumz {

    public constructor() {

    }

    public parse(info: TemplateEnumz, templateJson: any, enumz: Enumz = null): string {
        let config = ConfigTool.getInstance();
        let result: string[] = [];

        enumz == null && (enumz = config.getEnumz(info.name));
        if (enumz == null) {
            console.error("cant find enumz  : " + info.name);
            return null;
        }

        this._parse(enumz, result, info.name, info, templateJson);
        return result.join(info.FieldSplitSymbol);
    }

    private _parse(enumz: Enumz, result: string[], enumzName: string, info: TemplateEnumz, templateJson: any) {
        let outputStr: string = "";
        //开始头部
        if (info.headTailTemple) {
            let headTailTemple: TemplateHeadTail = templateJson[info.headTailTemple];
            let replaceString = headTailTemple.head;

            //替换枚举的命名空间
            replaceString = Tool.processNamespaces(replaceString, enumz.namespaces);

            //替换枚举名字
            let enumzArray = replaceString.match(/\${-[a-z]+ENUMZ_NAME}/g);
            if (enumzArray) {
                let enumzArrayLength = enumzArray.length;
                for (let i = 0; i < enumzArrayLength; i++) {
                    let enumzMatched = enumzArray[i];
                    let newEnumzMatched = Tool.processString(enumzMatched, enumzName, 0);
                    replaceString = replaceString.replace(enumzMatched, newEnumzMatched);
                }
            }

            //替换制定的枚举序列: name
            enumzArray = replaceString.match(/\${-[a-z]+ENUMZ_FIELD_NAME:[0-9]+}/g);
            if (enumzArray) {
                let enumzArrayLength = enumzArray.length;
                for (let i = 0; i < enumzArrayLength; i++) {
                    let enumzMatched = enumzArray[i];
                    let index = enumzMatched.lastIndexOf(":");
                    let numberString = enumzMatched.substring(index + 1, enumzMatched.length - 1);
                    let number = parseInt(numberString);
                    let fieldName = enumz.enum_constants[number].name;
                    let newEnumzMatched = Tool.processString(enumzMatched, fieldName, 0);
                    replaceString = replaceString.replace(enumzMatched, newEnumzMatched);
                }
            }

            //替换制定的枚举序列: name value
            enumzArray = replaceString.match(/\${-[a-z]+ENUMZ_FIELD_VALUE:[0-9]+}/g);
            if (enumzArray) {
                let enumzArrayLength = enumzArray.length;
                for (let i = 0; i < enumzArrayLength; i++) {
                    let enumzMatched = enumzArray[i];
                    let index = enumzMatched.lastIndexOf(":");
                    let numberString = enumzMatched.substring(index + 1, enumzMatched.length - 1);
                    let number = parseInt(numberString);
                    let fieldName = enumz.enum_constants[number].value;
                    let newEnumzMatched = Tool.processString(enumzMatched, fieldName, 0);
                    replaceString = replaceString.replace(enumzMatched, newEnumzMatched);
                }
            }


            outputStr += replaceString;
        }

        if (info.commonFieldTemple) {
            let commonReplaceString = templateJson[info.commonFieldTemple];
            if (commonReplaceString == null) {
                console.error(`commonFieldTemple : ${info.commonFieldTemple} not found`)
                exit(0);
            }
            let fieldLength = enumz.enum_constants.length;

            for (let i = 0; i < fieldLength; i++) {
                let f: EnumConstant = enumz.enum_constants[i];
                if (info.includeField && info.includeField.includes(f.name) == false) {
                    //如果有白名单
                    continue;
                }
                if (info.excludeField && info.excludeField.includes(f.name)) {
                    //如果有黑名单
                    continue;
                }

                let replaceString = commonReplaceString;
                if (info.specialFieldTemplate && info.specialFieldTemplate[f.name]) {
                    //是否有定制的模板
                    replaceString = templateJson[info.specialFieldTemplate[f.name]];
                    if (replaceString == null) {
                        console.error(`specialFieldTemplate: ${info.specialFieldTemplate[f.name]} not find`)
                        exit(0);
                    }
                }

                //替换枚举的命名空间
                replaceString = Tool.processNamespaces(replaceString, enumz.namespaces);

                //替换枚举名字
                let enumzArray = replaceString.match(/\${-[a-z]+ENUMZ_NAME}/g);
                if (enumzArray) {
                    let enumzArrayLength = enumzArray.length;
                    for (let i = 0; i < enumzArrayLength; i++) {
                        let enumzMatched = enumzArray[i];
                        let newEnumzMatched = Tool.processString(enumzMatched, enumzName, 0);
                        replaceString = replaceString.replace(enumzMatched, newEnumzMatched);
                    }
                }

                //替换field_name
                enumzArray = replaceString.match(/\${-[a-z]+ENUMZ_FIELD_NAME}/g);
                if (enumzArray) {
                    let enumzArrayLength = enumzArray.length;
                    for (let i = 0; i < enumzArrayLength; i++) {
                        let enumzMatched = enumzArray[i];
                        let newEnumzMatched = Tool.processString(enumzMatched, f.name, 0);
                        replaceString = replaceString.replace(enumzMatched, newEnumzMatched);
                    }
                }

                //替换field_value
                enumzArray = replaceString.match(/\${-[a-z]+ENUMZ_FIELD_VALUE}/g);
                if (enumzArray) {
                    let enumzArrayLength = enumzArray.length;
                    for (let i = 0; i < enumzArrayLength; i++) {
                        let enumzMatched = enumzArray[i];
                        let curValue = f.value;
                        let newEnumzMatched = Tool.processString(enumzMatched, curValue, 0);
                        replaceString = replaceString.replace(enumzMatched, newEnumzMatched);
                    }

                }

                //SPECIAL_ENUMCONSTANT_LOGIC
                let specialEnumConstantArray = replaceString.match(/\${SPECIAL_ENUMCONSTANT_LOGIC:.+?}/g);
                if (specialEnumConstantArray) {
                    for (let e of specialEnumConstantArray) {
                        let pos = e.indexOf(":");
                        let methodName = e.substring(pos + 1, e.length - 1);
                        let logic = new SpeicalLogic() as any;
                        var str = logic[methodName](enumzName, f);
                        replaceString = replaceString.replace(e, str);
                    }
                }

                if (i != fieldLength - 1) {
                    replaceString += info.FieldSplitSymbol;
                }

                outputStr += replaceString;
            }
        }

        //开始尾巴
        if (info.headTailTemple) {
            let headTailTemple: TemplateHeadTail = templateJson[info.headTailTemple];
            if (headTailTemple == null) {
                console.error(`headTailTemple : ${info.headTailTemple} not found`);
                exit(0);
            }
            let replaceString = headTailTemple.tail;

            //替换枚举的命名空间
            replaceString = Tool.processNamespaces(replaceString, enumz.namespaces);

            let enumzArray = replaceString.match(/\${-[a-z]+ENUMZ_NAME}/g);
            if (enumzArray) {
                let enumzArrayLength = enumzArray.length;
                for (let i = 0; i < enumzArrayLength; i++) {
                    let enumzMatched = enumzArray[i];
                    let newEnumzMatched = Tool.processString(enumzMatched, enumzName, 0);
                    replaceString = replaceString.replace(enumzMatched, newEnumzMatched);
                }

            }
            outputStr += replaceString;
        }



        result.push(outputStr);
    }
}