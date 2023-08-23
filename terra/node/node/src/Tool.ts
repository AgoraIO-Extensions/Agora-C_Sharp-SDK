import * as fs from "fs";
import { TemplateJoin } from "./Template";

export class Tool {

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

    private static _processNamespaces(namespaces: string[], info: TemplateJoin): string {
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
    private static _processStringWithO(input: string): string {
        return input;
    }

    //-l 首字母小写
    private static _processStringWithL(input: string): string {
        let first = input.charAt(0);
        first = first.toLowerCase();
        return first + input.substring(1, input.length);
    }

    //-m 全部字母大写
    private static _processStringWithM(input: string): string {
        return input.toUpperCase();
    }

    //-u 首字母大写
    private static _processStringWithU(input: string): string {
        let first = input.charAt(0);
        first = first.toUpperCase();
        return first + input.substring(1, input.length);
    }

    //-v 全部字母大写
    private static _processStringWithV(input: string): string {
        return input.toUpperCase();
    }

    //-r :首字母移除
    private static _processStringWithR(input: string): string {
        return input.substring(1, input.length);
    }

    //-t: 删除所有的下划线并且将下划线后的第一个字母给大写.比如 error_code => errorCode
    private static _processStringWithT(input: string): string {
        let array = input.split("_");
        for (let i = 1; i < array.length; i++) {
            array[i] = this._processStringWithU(array[i]);
        }

        return array.join("");
    }

    //-n: 追加后缀，例如joinChannel2
    private static _processStringWithN(input: string, repeat: number = 1): string {
        if (repeat < 2) {
            return input;
        }
        else {
            return input + repeat;
        }
    }

    //-s: 删除名字中的命名空间
    private static _processStringWithS(input: string, repeat: number = 1): string {
        let array = input.split("::");
        if (array && array.length > 1) {
            return array[array.length - 1];
        }
        return input;
    }

    //-c: 去除字符串里的&, *, 空格等等 等等 并将字母大写
    private static _processStringWithC(input: string, repeat: number = 1): string {
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
    private static _processStringWithY(input: string, repeat: number = 1): string {

        let array = input.split(" ");
        for (let i = 1; i < array.length; i++) {
            array[i] = this._processStringWithU(array[i]);
        }

        return array.join("");

    }

    //-p: 删除文字后边最后一个字符
    private static _processStringWithP(input: string, repeat: number = 1): string {
        return input.substring(0, input.length - 1);
    }

    //-e: 在字符串前加上=号，如果不为''的话
    private static _processStringWithE(input: string, repeat: number = 1): string {
        if (input != null && input != "") {
            return "=" + input;
        }
        return input;
    }

    public static readFile(fullPath: string): string {
        return fs.readFileSync(fullPath, 'utf-8');
    }
}