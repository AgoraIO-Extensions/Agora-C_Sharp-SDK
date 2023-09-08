import * as fs from "fs";
import { Tool } from "./Tool";

//读取param_trans.json并且用来做 变量名字的转换
export class ParamNameTrans {

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

    public transType(clazzName: string, funName: string, cxxParamName: string): string {

        if (funName == null || funName == "") {
            //是否匹配 类的成员属性
            let clazzParamType = clazzName + "." + cxxParamName;
            if (this._specialClzzParamMap[clazzParamType]) {
                return this._specialClzzParamMap[clazzParamType];
            }
        }
        else {
            //是否匹配了 方法名字属性
            let methodParamType = clazzName + "." + funName + "." + cxxParamName;
            if (this._specialMethodParamMap[methodParamType]) {
                return this._specialMethodParamMap[methodParamType];
            }
        }

        //是否匹配了普通
        if (this._normalMap[cxxParamName])
            return this._normalMap[cxxParamName];

        for (let key in this._regMap) {

            let inputTemplate: string = key as string;
            let outputTemplate: string = this._regMap[key];

            let out = this._matchReg(inputTemplate, cxxParamName, outputTemplate);
            if (out) {
                return out;
            }
        }


        return cxxParamName;
    }

    private _matchReg(inputTemplate: string, cxxParamName: string, outputTemplate: string): string {
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

        if (splitArray[0] == "" && inputTemplate.endsWith(splitArray[1]) && cxxParamName.endsWith(splitArray[1])) {
            //类型于 *xxxxyy
            let suffixPos = cxxParamName.indexOf(splitArray[1]);
            findStr = cxxParamName.substring(0, suffixPos);
        }
        else if (splitArray[1] == "" && inputTemplate.startsWith(splitArray[0]) && cxxParamName.startsWith(splitArray[0])) {
            //类似于 xxyyy*
            findStr = cxxParamName.substring(splitArray[0].length, cxxParamName.length);
        }
        //类型于 xxx*yyy
        else if (cxxParamName.startsWith(splitArray[0]) && cxxParamName.endsWith(splitArray[1])) {
            let suffixPos = cxxParamName.indexOf(splitArray[1]);
            findStr = cxxParamName.substring(splitArray[0].length, suffixPos);
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