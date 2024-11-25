import * as fs from "fs";
import { TemplateJoin } from "./Template";
import { Constructor } from "./terra";
import { type } from "os";
import path, { normalize } from "path";
import { ConfigTool } from "./ConfigTool";

export interface CppConstructor {
    //参数列表
    parameters: { type: string, name: string, value: string }[];
    //初始化列表
    initializes: { name: string, value: string }[];
    //body内部复制
    bodys: { name: string, value: string }[];
};
export class Tool {

    public static getCppConstructor(clazzName: string, filePath: string): CppConstructor[] {

        let baseName = path.basename(filePath);
        filePath = path.join(ConfigTool.getInstance().cxxOriginFileDir, baseName);
        // console.log("getCppConstructor " + filePath);
        let cppConstructors = [];
        let context = Tool.readFile(filePath);
        let reg = new RegExp(`^[ ]*${clazzName}\\([\\s\\S]*?\\)[\\s\\S]*?\\{[\\s\\S]*?\\}`, "gm");
        let array = context.match(reg);
        if (array) {
            for (let e of array) {
                let cppConstructor: CppConstructor = { parameters: [], initializes: [], bodys: [] };
                //解析参数列表
                let firstPos = e.indexOf("(");
                let endPos = e.indexOf(")");
                let parametersStr = e.substring(firstPos + 1, endPos);
                parametersStr = parametersStr.trim();
                if (parametersStr != "") {
                    let eachParameter = parametersStr.split(",");
                    for (let each of eachParameter) {
                        let eachTrim = each.trim();
                        //has default value
                        let value = null;
                        if (eachTrim.indexOf("=") != -1) {
                            value = eachTrim.substring(eachTrim.indexOf("=") + 1);
                            value = value.trim();
                            eachTrim = eachTrim.substring(0, eachTrim.indexOf("=") - 1);
                        }

                        let length = eachTrim.length;
                        let endPos = 0;
                        for (let i = length - 1; i >= 0; i--) {
                            let e = eachTrim.charAt(i);
                            if (e == " " || e == "*" || e == "&") {
                                endPos = i;
                                break;
                            }
                        }

                        let type = null;
                        let name = null;
                        if (endPos != 0) {
                            type = eachTrim.substring(0, endPos + 1).trim();
                            name = eachTrim.substring(endPos + 1, length).trim();
                        }
                        else {
                            type = eachTrim;
                            name = null;
                        }
                        cppConstructor.parameters.push({ type, name, value });
                    }
                }

                //解析初始化列表
                let initializePos = e.indexOf(":", e.indexOf(")"));
                //exclude :: 
                if (initializePos != -1 && e[initializePos + 1] != ':') {
                    let initializeStr = e.substring(initializePos + 1, e.indexOf("{"));
                    initializeStr = initializeStr.replace(/\ +/g, "");
                    initializeStr = initializeStr.replace(/[\r\n]/g, "");
                    let eachInitialize = initializeStr.split("),")
                    for (let i = 0; i < eachInitialize.length; i++) {
                        let each = eachInitialize[i];
                        let eachTrim = each.trim();
                        if (i != eachInitialize.length - 1) {
                            eachTrim = eachTrim + ")";
                        }
                        let length = eachTrim.length;
                        let leftPos = eachTrim.indexOf("(");
                        let name = eachTrim.substring(0, leftPos).trim();
                        let value = eachTrim.substring(leftPos + 1, length - 1).trim();
                        cppConstructor.initializes.push({ name, value });
                    }
                }

                //todo body有点沙雕。暂时不处理了
                cppConstructors.push(cppConstructor);
            }
        }
        return cppConstructors;
    }

    public static processNamespaces(replaceString: string, namespaces: string[]): string {
        //替换枚举的命名空间
        let array = replaceString.match(/\${NAME+SPACES_JOIN:.+?}/g);
        if (array) {
            for (let e of array) {
                let pos = e.indexOf(":");
                let configFile = e.substring(pos + 1, e.length - 1);
                let jsonStr = Tool.readFile(configFile);
                let json: TemplateJoin = JSON.parse(jsonStr);

                let newString = Tool._processNamespaces(namespaces, json);
                replaceString = replaceString.replace(e, newString);
            }
        }

        return replaceString;
    }

    public static _processNamespaces(namespaces: string[], info: TemplateJoin): string {
        let outputs: string[] = [];
        for (let namespace of namespaces) {
            let format = info.format;
            let matcheds = format.match(/\${-[a-z]+NAME_SPACE}/g)
            if (matcheds) {
                for (let m of matcheds) {
                    let newEnumzMatched = Tool.processString(m, namespace, 0);
                    format = format.replace(m, newEnumzMatched);
                }
            }
            outputs.push(format);
        }
        return outputs.join(info.split);
    }


    public static processString(rule: string, input: string, repeat: number = 1): string {

        let array = rule.match(/-[a-z]+/g);
        if (array == null) {
            console.error("processString error invalid: " + rule);
        }

        let e: string = array[0];
        e = e.substring(1, e.length);

        let length = e.length;
        for (let i = 0; i < length; i++) {
            let suffix = e.charAt(i);
            let funKey = "_processStringWith" + suffix.toUpperCase();
            if (Tool[funKey]) {
                input = Tool[funKey](input, repeat);
            }
            else {
                console.error("processString error invalid rule: " + rule);
            }
        }

        return input;
    }

    /*
        -o: 原始样子不做处理
    */
    public static _processStringWithO(input: string): string {
        return input;
    }

    //-l 首字母小写
    public static _processStringWithL(input: string): string {
        let first = input.charAt(0);
        first = first.toLowerCase();
        return first + input.substring(1, input.length);
    }

    //-m 全部字母大写
    public static _processStringWithM(input: string): string {
        return input.toUpperCase();
    }

    //-u 首字母大写
    public static _processStringWithU(input: string): string {
        let first = input.charAt(0);
        first = first.toUpperCase();
        return first + input.substring(1, input.length);
    }

    //-v 全部字母大写
    public static _processStringWithV(input: string): string {
        return input.toUpperCase();
    }

    //-r :首字母移除
    public static _processStringWithR(input: string): string {
        return input.substring(1, input.length);
    }

    //-t: 删除所有的下划线并且将下划线后的第一个字母给大写.比如 error_code => errorCode
    public static _processStringWithT(input: string): string {
        let array = input.split("_");
        for (let i = 1; i < array.length; i++) {
            array[i] = this._processStringWithU(array[i]);
        }

        return array.join("");
    }

    //-n: 追加后缀，例如joinChannel2
    public static _processStringWithN(input: string, repeat: number = 1): string {
        if (repeat < 2) {
            return input;
        }
        else {
            return input + repeat;
        }
    }

    //-s: 删除名字中的命名空间
    public static _processStringWithS(input: string, repeat: number = 1): string {
        let array = input.split("::");
        if (array && array.length > 1) {
            return array[array.length - 1];
        }
        return input;
    }

    //-c: 去除字符串里的&, *, 空格等等 等等 并将字母大写
    public static _processStringWithC(input: string, repeat: number = 1): string {
        let length = input.length;
        let up: boolean = false;
        let r: string[] = [];
        for (let i = 0; i < length; i++) {
            let e = input.charAt(i);
            if (e != "&" && e != "*" && e != " " && e != "<" && e != ">") {
                if (up) {
                    e = e.toUpperCase();
                    up = false;
                }
                r.push(e);
            }
            else {
                up = true;
            }
        }
        return r.join('');
    }

    //-y: 删除所有空格，并将空格后的第一个字母大写比如 err code => errCode
    public static _processStringWithY(input: string, repeat: number = 1): string {

        let array = input.split(" ");
        for (let i = 1; i < array.length; i++) {
            array[i] = this._processStringWithU(array[i]);
        }

        return array.join("");

    }

    //-p: 删除文字后边最后一个字符
    public static _processStringWithP(input: string, repeat: number = 1): string {
        return input.substring(0, input.length - 1);
    }

    //-e: 在字符串前加上=号，如果不为''的话
    public static _processStringWithE(input: string, repeat: number = 1): string {
        if (input != null && input != "") {
            return "=" + input;
        }
        return input;
    }

    //-f: 删除最前边的ref
    public static _processStringWithF(input: string, repeat: number = 1): string {
        if (input.startsWith("ref ")) {
            return input.substring(4, input.length);
        }
        else {
            return input;
        }
    }

    //-a: 删除最前边的@
    public static _processStringWithA(input: string, repeat: number = 1): string {
        if (input.startsWith("@")) {
            return input.substring(1, input.length);
        }
        else {
            return input;
        }
    }

    public static readFile(fullPath: string): string {
        return fs.readFileSync(fullPath, 'utf-8');
    }

    public static writeFile(fullPath: string, lines: string[], removeMultipleBlankLines: boolean = true) {
        if (removeMultipleBlankLines) {
            let newLines = [];
            newLines.push(lines[0]);
            for (let i = 1; i < lines.length; i++) {
                if (lines[i - 1].trim() == "" && lines[i].trim() == "")
                    continue;
                newLines.push(lines[i]);

            }
            fs.writeFileSync(fullPath, newLines.join("\n"), 'utf-8');
        }
        else {
            fs.writeFileSync(fullPath, lines.join("\n"), 'utf-8');
        }
    }
}