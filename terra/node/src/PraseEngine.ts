import * as fs from "fs";
import path, * as Path from "path";
import { config, exit } from "process";
import { ParamNameTrans } from "./ParamNameTrans";
import { ParseClassOrStruct } from "./ParseClassOrStruct";
import { ParseEnumz } from "./ParseEnumz";
import { TemplateClassStruct, TemplateEnumz, TemplateFile, TemplateType } from "./Template";
import { Tool } from "./Tool";
import { ParamTypeTrans } from "./ParamTypeTrans";
import { execSync } from 'child_process';
import { CXXFile } from "./terra";
import { ConfigTool } from "./ConfigTool";
import { ParamDefaultTrans } from "./ParamDefaultTrans";
import { ParseTemplate } from "./ParseTemplate";

export class ParseEngine {


    constructor(distPath: string, templatePath: string, tansPath: string, cxxFiles: CXXFile[], markStart: string, markEnd: string) {
        var configTool = ConfigTool.getInstance();
        configTool.loadDistMark(markStart, markEnd);
        configTool.loadParamTypeTrans(new ParamTypeTrans(path.join(tansPath, "param_type_trans.json")));
        configTool.loadParamNameFormalTrans(new ParamNameTrans(path.join(tansPath, "param_name_formal_trans.json")));
        configTool.loadParamNameActualTrans(new ParamNameTrans(path.join(tansPath, "param_name_actual_trans.json")));
        configTool.loadParamDefaultTrans(new ParamDefaultTrans(path.join(tansPath, "param_name_foraml_default_trans.json")));
        configTool.loadCXXFiles(cxxFiles);

        var parseTemplate = new ParseTemplate();
        var list: string[] = [];
        this._walkFile(templatePath, list, "");
        for (let e of list) {
            var distFileName = e.substring(0, e.length - 5);
            var fullDistFileName = path.join(distPath, distFileName);
            var fullTemplateFileName = path.join(templatePath, e);
            if (fs.existsSync(fullDistFileName)) {
                console.log(fullDistFileName + " : " + fullTemplateFileName);
                parseTemplate.parse(fullDistFileName, fullTemplateFileName);
                execSync(`clang-format -i ${fullDistFileName}`);
            }
        }
    }

    private _walkFile(rootPath: string, fileLsit: string[], midPath: string) {
        let list: string[] = fs.readdirSync(rootPath);
        for (let file of list) {
            let stat = fs.statSync(Path.join(rootPath, file));
            if (stat.isFile()) {
                fileLsit.push(Path.join(midPath, file));
            }
            else {
                this._walkFile(Path.join(rootPath, file), fileLsit, Path.join(midPath, file));
            }
        }
    }

    private _readString(rootPath: string, file: string): string {
        return Tool.readFile(Path.join(rootPath, file));
    }

}