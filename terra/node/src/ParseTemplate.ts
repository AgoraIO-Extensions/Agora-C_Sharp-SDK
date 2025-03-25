import { ConfigTool } from "./ConfigTool";
import * as fs from 'fs'
import { TemplateType } from "./Template";
// import { ParseFile } from "./ParseFile";
import { ParseClassOrStruct } from "./ParseClassOrStruct";
import { ParseEnumz } from "./ParseEnumz";
import { ParseFile } from "./ParseFile";
import { Tool } from "./Tool";

export class ParseTemplate {

    public parse(distPath: string, templatePath: string) {
        let templateJson: any = JSON.parse(fs.readFileSync(templatePath, { encoding: 'utf-8' }));
        let configTool: ConfigTool = ConfigTool.getInstance();
        let distLines: string[] = fs.readFileSync(distPath, { encoding: 'utf-8' }).split(/\r?\n/);
        let nodeName = null;
        let i = 0;

        while (i < distLines.length) {
            let line = distLines[i];
            //Node not found yet
            if (nodeName == null) {
                if (line.includes(configTool.distMarkStart)) {
                    line = line.trim();
                    nodeName = line.substring(configTool.distMarkStart.length + 1);
                }
                i++;
            }
            else if (nodeName != null) {
                if (line.includes(configTool.distMarkEnd + " " + nodeName)) {
                    //End marker found
                    //todo Start writing values here
                    let template = templateJson[nodeName];
                    if (template == null) {
                        distLines.splice(i, 0, `Not find node name: ${nodeName}`);
                        i = i + 2;
                        return;
                    }
                    else {
                        if (template.type == TemplateType.ClazzStruct) {
                            let parseClassOrStruct = new ParseClassOrStruct();
                            distLines.splice(i, 0, parseClassOrStruct.parse(template, templateJson));
                            i = i + 2;
                        }
                        else if (template.type == TemplateType.Enumz) {
                            let parseEnumz = new ParseEnumz();
                            distLines.splice(i, 0, parseEnumz.parse(template, templateJson));
                            i = i + 2;
                        }
                        else if (template.type == TemplateType.File) {
                            let parseFile = new ParseFile();
                            distLines.splice(i, 0, parseFile.parse(template, templateJson));
                            i = i + 2;
                        }
                        if (distLines[i - 2] == null) {
                            //if cant find class,enum or file. Will not write file back. 
                            return;
                        }
                    }
                    nodeName = null;
                }
                else {
                    distLines.splice(i, 1);
                }

            }
        }
        Tool.writeFile(distPath, distLines);
    }
}