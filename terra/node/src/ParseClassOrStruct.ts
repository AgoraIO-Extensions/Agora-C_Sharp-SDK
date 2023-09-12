import { config, exit } from "process";
import { json } from "stream/consumers";
import { ParamNameTrans } from "./ParamNameTrans";
import { TemplateClassStruct, TemplateHeadTail, TemplateJoin } from "./Template"
import { Tool } from "./Tool";
import { ParamTypeTrans } from "./ParamTypeTrans";
import { ConfigTool } from "./ConfigTool";
import { MemberFunction, Clazz, MemberVariable } from "./terra"
import { SpeicalLogic } from "./SpecialLogic";

export class ParseClassOrStruct {

    public constructor() {

    }

    public parse(info: TemplateClassStruct, templateJson: any, clazz: Clazz = null): string {
        let result: string[] = [];
        let config: ConfigTool = ConfigTool.getInstance();
        clazz == null && (clazz = config.getClassOrStruct(info.name, info.namespaces));
        if (clazz == null) {
            console.error("cant find class or struct : " + info.name);
            exit(0);
        }
        let methodRepeatMap: Map<string, number> = new Map();
        this._parse(templateJson, clazz, info.trackBackFather ? info.trackBackFather : 0, result, info.name, info, methodRepeatMap);
        return result.join(info.memberSplitSymbol);
    }

    private _parse(templateJson: any, clazz: Clazz, trackBackFather: number, result: string[], clazzName: string, info: TemplateClassStruct, methodRepeatMap: Map<string, number>) {
        let config: ConfigTool = ConfigTool.getInstance();
        if (trackBackFather > 0) {
            for (let i = 0; i < clazz.base_clazzs.length; i++) {
                let baseClazz = config.getClassOrStruct(clazz.base_clazzs[i]);
                if (baseClazz) {
                    this._parse(templateJson, baseClazz, trackBackFather - 1, result, clazzName, info, methodRepeatMap);
                }
                else {
                    console.error("cant find baseClazz: " + clazz.base_clazzs[i]);
                }
            }
        }

        let outputStr: string = "";

        //开始解析头
        //开始头部
        if (info.headTailTemple) {
            let headTailTemple: TemplateHeadTail = templateJson[info.headTailTemple];
            let replaceString = headTailTemple.head;

            //替换枚举的命名空间
            replaceString = Tool.processNamespaces(replaceString, clazz.namespaces);

            let enumzArray = replaceString.match(/\${-[a-z]+CLAZZ_STRUCT_NAME}/g);
            if (enumzArray) {
                let enumzArrayLength = enumzArray.length;
                for (let i = 0; i < enumzArrayLength; i++) {
                    let enumzMatched = enumzArray[i];
                    let newEnumzMatched = Tool.processString(enumzMatched, clazzName, 0);
                    replaceString = replaceString.replace(enumzMatched, newEnumzMatched);
                }
            }


            //解析SPECIAL_CLAZZ_STRUCT_LOGIC
            let specialLogicArray = replaceString.match(/\${SPECIAL_CLAZZ_STRUCT_LOGIC:.+?}/g);
            if (specialLogicArray) {
                for (let e of specialLogicArray) {
                    let pos = e.indexOf(":");
                    let methodName = e.substring(pos + 1, e.length - 1);
                    let logic = new SpeicalLogic() as any;
                    var str = logic[methodName](clazz);
                    replaceString = replaceString.replace(e, str);
                }
            }

            outputStr += replaceString;
        }


        //todo 开始解析普通的成员变量
        if (info.commonMemberTemplate) {
            let commonReplaceString = templateJson[info.commonMemberTemplate];
            if (commonReplaceString == null) {
                console.error(`commonMemberTemplate: ${info.commonMemberTemplate} not found`);
                exit(0);
            }

            let memberLength = clazz.member_variables.length;
            for (let i = 0; i < memberLength; i++) {
                let m: MemberVariable = clazz.member_variables[i];
                if (info.includeMembers) {
                    //如果不在白名单里则跳过
                    if (info.includeMembers.includes(m.name) == false)
                        continue;
                }
                if (info.excludeMembers) {
                    //如果在黑名单里则跳过
                    if (info.excludeMembers.includes(m.name))
                        continue;
                }
                let replaceString = commonReplaceString;
                if (info.specialMembersTemplate && info.specialMembersTemplate[m.name]) {
                    //是否制定了method模板
                    replaceString = templateJson[info.specialMembersTemplate[m.name]];
                    if (replaceString == null) {
                        console.error(`specialMembersTemplate: ${m.name} not found`);
                        exit(0);
                    }
                }
                outputStr += this._parseMember(replaceString, m, clazzName);
                if (i != memberLength - 1) {
                    outputStr += info.memberSplitSymbol;
                }

            }
        }

        if (info.commonMethodTemplate) {
            //开始解析函数列表
            let commonReplaceString = templateJson[info.commonMethodTemplate];
            let methodLength = clazz.methods.length;

            for (let i = 0; i < methodLength; i++) {
                let m: MemberFunction = clazz.methods[i];

                if (info.includeMethods) {
                    //白名单里没有,则跳过
                    if (info.includeMethods.includes(m.name) == false)
                        continue;
                }

                if (info.excludeMethods) {
                    //黑名单里有，则跳过
                    if (info.excludeMethods.includes(m.name))
                        continue;
                }

                let replaceString = commonReplaceString;
                if (info.specialMethodsTemplate && info.specialMethodsTemplate[m.name]) {
                    //是否制定了method模板
                    replaceString = templateJson[info.specialMethodsTemplate[m.name]];
                }

                if (methodRepeatMap.has(m.name)) {
                    methodRepeatMap.set(m.name, methodRepeatMap.get(m.name) + 1);
                }
                else {
                    methodRepeatMap.set(m.name, 1);
                }
                outputStr += this._parseMethod(templateJson, replaceString, m, clazzName, methodRepeatMap.get(m.name));
                if (i != methodLength - 1) {
                    outputStr += info.methodSplitSymbol;
                }
            }
        }

        //开始尾巴
        if (info.headTailTemple) {
            let headTailTemple: TemplateHeadTail = templateJson[info.headTailTemple];
            if (headTailTemple == null) {
                console.error(`headTailTemple: ${info.headTailTemple} not found`);
            }
            let replaceString = headTailTemple.tail;

            //替换class的命名空间
            replaceString = Tool.processNamespaces(replaceString, clazz.namespaces);

            let enumzArray = replaceString.match(/\${-[a-z]+CLAZZ_STRUCT_NAME}/g);
            if (enumzArray) {
                let enumzArrayLength = enumzArray.length;
                for (let i = 0; i < enumzArrayLength; i++) {
                    let enumzMatched = enumzArray[i];
                    let newEnumzMatched = Tool.processString(enumzMatched, clazzName, 0);
                    replaceString = replaceString.replace(enumzMatched, newEnumzMatched);
                }

            }

            //解析SPECIAL_CLAZZ_STRUCT_LOGIC
            let specialLogicArray = replaceString.match(/\${SPECIAL_CLAZZ_STRUCT_LOGIC:.+?}/g);
            if (specialLogicArray) {
                for (let e of specialLogicArray) {
                    let pos = e.indexOf(":");
                    let methodName = e.substring(pos + 1, e.length - 1);
                    let logic = new SpeicalLogic() as any;
                    var str = logic[methodName](clazz);
                    replaceString = replaceString.replace(e, str);
                }
            }
            outputStr += replaceString;
        }

        if (outputStr != "") {
            result.push(outputStr);
        }
    }

    _parseMember(replaceString: string, member: MemberVariable, clazzName: string): string {
        var config = ConfigTool.getInstance();
        let memberClass = ConfigTool.getInstance().getClassOrStruct(member.name);
        if (memberClass) {
            replaceString = Tool.processNamespaces(replaceString, memberClass.namespaces);
        }

        //成员类型
        let typeArray = replaceString.match(/\${-[a-z]+MEMBER_TYPE}/g);
        if (typeArray) {
            let length = typeArray.length;
            for (let i = 0; i < length; i++) {
                let matched = typeArray[i];
                let newString = config.paramTypeTrans.transType(clazzName, null, member.type.source, member.name);
                newString = Tool.processString(matched, newString, 0);
                replaceString = replaceString.replace(matched, newString);
            }
        }

        let memberArray = replaceString.match(/\${-[a-z]+MEMBER_NAME}/g);
        if (memberArray) {
            let length = memberArray.length;
            for (let i = 0; i < length; i++) {
                let matched = memberArray[i];
                var newString = config.paramNameFormalTrans.transType(clazzName, null, member.name)
                newString = Tool.processString(matched, newString, 0);
                replaceString = replaceString.replace(matched, newString);
            }
        }

        //特殊member逻辑
        let specialMemberArray = replaceString.match(/\${SPECIAL_MEMBER_LOGIC:.+?}/g);
        if (specialMemberArray) {
            for (let e of specialMemberArray) {
                let pos = e.indexOf(":");
                let methodName = e.substring(pos + 1, e.length - 1);
                let logic = new SpeicalLogic() as any;
                var str = logic[methodName](clazzName, member);
                replaceString = replaceString.replace(e, str);
            }
        }

        return replaceString;
    }

    _parseMethod(templateJson: any, replaceString: string, method: MemberFunction, clazzName: string, repeat: number): string {
        var config: ConfigTool = ConfigTool.getInstance();
        //类名字
        let clazzArray = replaceString.match(/\${-[a-z]+CLAZZ_STRUCT_NAME}/g);
        if (clazzArray) {
            let clazzArrayLength = clazzArray.length;
            for (let i = 0; i < clazzArrayLength; i++) {
                let clazzMatched = clazzArray[i];
                let newClassName = Tool.processString(clazzMatched, clazzName, repeat);
                replaceString = replaceString.replace(clazzMatched, newClassName);
            }
        }

        //方法名字
        let methodArray = replaceString.match(/\${-[a-z]+METHOD_NAME}/g);
        if (methodArray) {
            let methodArrayLength = methodArray.length;
            for (let i = 0; i < methodArrayLength; i++) {
                let methodMatched = methodArray[i];
                let newMethodName = Tool.processString(methodMatched, method.name, repeat);
                replaceString = replaceString.replace(methodMatched, newMethodName);
            }
        }

        //方法的返回值
        let returnArray = replaceString.match(/\${-[a-z]+METHOD_RETURN_TYPE}/g);
        if (returnArray) {
            let returnArrayLength = returnArray.length;
            for (let i = 0; i < returnArrayLength; i++) {
                let returnMatched = returnArray[i];
                let newReturn = config.paramTypeTrans.transType(clazzName, method.name, method.return_type.source, "return");
                replaceString = replaceString.replace(returnMatched, newReturn);
            }
        }

        //参数列表
        let paramArray = replaceString.match(/\${METHOD_PARAM_JOIN:.+?}/g);
        if (paramArray) {
            for (let e of paramArray) {
                let pos = e.indexOf(":");
                let configKey = e.substring(pos + 1, e.length - 1);
                let str = this._paraseParamJoin(templateJson, configKey, method, clazzName, repeat);
                replaceString = replaceString.replace(e, str);
            }
        }

        //特殊method逻辑
        let specialMethodArray = replaceString.match(/\${SPECIAL_METHOD_LOGIC:.+?}/g);
        if (specialMethodArray) {
            for (let e of specialMethodArray) {
                let pos = e.indexOf(":");
                let methodName = e.substring(pos + 1, e.length - 1);
                let logic = new SpeicalLogic() as any;
                var str = logic[methodName](clazzName, method, repeat);
                replaceString = replaceString.replace(e, str);
            }
        }

        return replaceString;
    }

    _paraseParamJoin(templateJson: any, configKey: string, method: MemberFunction, clazzName: string, repeat: number) {
        var config: ConfigTool = ConfigTool.getInstance();
        let json: TemplateJoin = templateJson[configKey];
        let outputStrings: string[] = [];
        let parameters = method.parameters;
        let length = parameters.length;

        for (let i = 0; i < length; i++) {

            let str = json.format;

            //参数的命名空间
            let memberClass = ConfigTool.getInstance().getClassOrStruct(parameters[i].name);
            if (memberClass) {
                str = Tool.processNamespaces(str, memberClass.namespaces);
            }

            //函数名字的替换
            //方法名字
            let methodArray = str.match(/\${-[a-z]+METHOD_NAME}/g);
            if (methodArray) {
                let methodArrayLength = methodArray.length;
                for (let i = 0; i < methodArrayLength; i++) {
                    let methodMatched = methodArray[i];
                    let newMethodName = Tool.processString(methodMatched, method.name, repeat);
                    str = str.replace(methodMatched, newMethodName);
                }
            }

            //参数类型
            let typeArray: string[] = str.match(/\${-[a-z]+PARAM_TYPE}/g);
            if (typeArray) {
                var needContinue = false;
                for (let e of typeArray) {
                    let transType = config.paramTypeTrans.transType(clazzName, method.name, parameters[i].type.source, parameters[i].name);
                    if (transType == "@remove") {
                        needContinue = true;
                        break;
                    }
                    let newType = Tool.processString(e, transType);
                    str = str.replace(e, newType);
                }
                if (needContinue)
                    continue;
            }

            //参数的名字(形式参数)
            let nameArray: string[] = str.match(/\${-[a-z]+PARAM_NAME_FORMAL}/g);
            if (nameArray) {
                for (let e of nameArray) {
                    let newName = config.paramNameFormalTrans.transType(clazzName, method.name, parameters[i].name)
                    let newType = Tool.processString(e, newName);
                    str = str.replace(e, newType);
                }
            }

            //参数的名字(实际参数)
            nameArray = str.match(/\${-[a-z]+PARAM_NAME_ACTUAL}/g);
            if (nameArray) {
                var needContinue = false;
                for (let e of nameArray) {
                    let newName = config.paramNameActualTrans.transType(clazzName, method.name, parameters[i].name)
                    newName = Tool.processString(e, newName);
                    str = str.replace(e, newName);
                    if (newName == "@remove") {
                        needContinue = true;
                        break;
                    }
                }
                if (needContinue)
                    continue;
            }

            //参数的默认值
            nameArray = str.match(/\${-[a-z]+PARAM_NAME_FORMAL_DEFAULT}/g);
            if (nameArray) {
                for (let e of nameArray) {
                    let newName = config.paramDefaultTrans.transType(clazzName, method.name, parameters[i].type.source, parameters[i].name, parameters[i].default_value)
                    if (newName == "@remove") {
                        newName = "";
                    }
                    let newType = Tool.processString(e, newName);
                    str = str.replace(e, newType);
                    if (newName == "@remove") {
                        needContinue = true;
                        break;
                    }
                }
            }

            outputStrings.push(str);
        }
        return outputStrings.join(json.split);
    }
}




