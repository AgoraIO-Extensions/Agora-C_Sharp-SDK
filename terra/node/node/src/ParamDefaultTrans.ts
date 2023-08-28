import * as fs from "fs";
import { Tool } from "./Tool";

//读取type_trans.json并且用来做类型装换的
export class ParamDefaultTrans {

    private _normalMap: any;
    private _specialClzzParamMap: any;
    private _specialMethodParamMap: any;
    private _regMap: any;

    constructor(path: string) {
        let data = fs.readFileSync(path, "utf-8");
        let json = JSON.parse(data);
        this._specialMethodParamMap = json.special_method_param;
        this._specialClzzParamMap = json.special_class_param;
        this._normalMap = json.normal;
        this._regMap = json.reg;
    }

    public transType(clazzName: string, funName: string, cxxTypeSource: string, cxxParamName: string, defaultValue: string): string {


        var retval = defaultValue;
        do {
            if (funName == null || funName == "") {
                //是否匹配 类的成员属性
                let clazzParamType = clazzName + "." + cxxParamName + ":" + defaultValue;
                if (this._specialClzzParamMap[clazzParamType]) {
                    retval = this._specialClzzParamMap[clazzParamType];
                    break;
                }
            }
            else {
                //是否匹配了 方法名字属性
                let methodParamType = clazzName + "." + funName + "." + cxxParamName + ":" + defaultValue;
                if (this._specialMethodParamMap[methodParamType]) {
                    retval = this._specialMethodParamMap[methodParamType];
                    break;
                }
            }

            if (this._normalMap[defaultValue]) {
                retval = this._normalMap[defaultValue];
                break;
            }

            //匹配正则
            if (defaultValue != null) {
                for (let key in this._regMap) {
                    let inputTemplate: string = key as string;
                    let outputTemplate: string = this._regMap[key];
                    let out = this._matchReg(inputTemplate, defaultValue, outputTemplate);
                    if (out) {
                        retval = out;
                        break;
                    }
                }
            }
        } while (false);

        return retval;
    }

    private _matchReg(inputTemplate: string, defaultValue: string, outputTemplate: string): string {
        let starPos = inputTemplate.indexOf("*");
        if (starPos == -1) {
            console.error("_matchReg error invalid inputTemplate: " + inputTemplate);
            return null;
        }

        let splitArray = inputTemplate.split("*");
        if (splitArray.length > 2) {
            console.error("_matchReg error invalid inputTemplate: " + inputTemplate);
            return null;
        }

        let findStr: string = null;

        if (splitArray[0] == "" && inputTemplate.endsWith(splitArray[1]) && defaultValue.endsWith(splitArray[1])) {
            //类型于 *xxxxyy
            let suffixPos = defaultValue.indexOf(splitArray[1]);
            findStr = defaultValue.substring(0, suffixPos);
        }
        else if (splitArray[1] == "" && inputTemplate.startsWith(splitArray[0]) && defaultValue.startsWith(splitArray[0])) {
            //类似于 xxyyy*
            findStr = defaultValue.substring(splitArray[0].length, defaultValue.length);
        }
        //类型于 xxx*yyy
        else if (defaultValue.startsWith(splitArray[0]) && defaultValue.endsWith(splitArray[1])) {
            let suffixPos = defaultValue.indexOf(splitArray[1]);
            findStr = defaultValue.substring(splitArray[0].length, suffixPos);
        }


        if (findStr) {
            let array = outputTemplate.match(/\${-[a-z]+\*}/g);
            if (array == null) {
                console.error("_matchReg error invalid outputTemplate: " + inputTemplate);
                return null;
            }

            let matchedString = array[0];
            let processedStr = Tool.processString(matchedString, findStr);

            outputTemplate = outputTemplate.replace(matchedString, processedStr);
            return outputTemplate;
        }

        return null;
    }



};