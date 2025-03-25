import * as fs from "fs";
import { Tool } from "./Tool";

//Read type_trans.json and use it for type conversion
export class ParamTypeTrans {

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

    public transType(clazzName: string, funName: string, cxxTypeSource: string, cxxParamName: string): string {
        // // if (cxxTypeSource == 'uid_t') {
        console.log(cxxTypeSource + " : " + cxxParamName);
        // // }

        if (funName == null || funName == "") {
            //Match class member attributes
            let clazzParamType = clazzName + "." + cxxParamName;
            if (this._specialClzzParamMap[clazzParamType]) {
                return this._specialClzzParamMap[clazzParamType];
            }
        }
        else {
            //Match method name attributes
            let methodParamType = clazzName + "." + funName + "." + cxxParamName;
            // console.log("class.method.name:" + methodParamType)
            if (this._specialMethodParamMap[methodParamType]) {
                return this._specialMethodParamMap[methodParamType];
            }
        }

        //Match normal types
        if (this._normalMap[cxxTypeSource])
            return this._normalMap[cxxTypeSource];

        for (let key in this._regMap) {
            let inputTemplate: string = key as string;
            let outputTemplate: string = this._regMap[key];

            let out = this._matchReg(inputTemplate, cxxTypeSource, outputTemplate);
            if (out) {
                return out;
            }
        }


        return cxxTypeSource;
    }

    private _matchReg(inputTemplate: string, cxxTypeSource: string, outputTemplate: string): string {
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

        if (splitArray[0] == "" && inputTemplate.endsWith(splitArray[1]) && cxxTypeSource.endsWith(splitArray[1])) {
            //Pattern like *xxxxyy
            let suffixPos = cxxTypeSource.indexOf(splitArray[1]);
            findStr = cxxTypeSource.substring(0, suffixPos);
        }
        else if (splitArray[1] == "" && inputTemplate.startsWith(splitArray[0]) && cxxTypeSource.startsWith(splitArray[0])) {
            //Pattern like xxyyy*
            findStr = cxxTypeSource.substring(splitArray[0].length, cxxTypeSource.length);
        }
            //Pattern like xxx*yyy
        else if (cxxTypeSource.startsWith(splitArray[0]) && cxxTypeSource.endsWith(splitArray[1])) {
            let suffixPos = cxxTypeSource.indexOf(splitArray[1]);
            findStr = cxxTypeSource.substring(splitArray[0].length, suffixPos);
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