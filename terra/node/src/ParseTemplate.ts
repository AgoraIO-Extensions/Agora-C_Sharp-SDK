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
        var templateJson: any = JSON.parse(fs.readFileSync(templatePath, { encoding: 'utf-8' }));
        var configTool: ConfigTool = ConfigTool.getInstance();
        var distLines: string[] = fs.readFileSync(distPath, { encoding: 'utf-8' }).split(/\r?\n/);
        var nodeName = null;
        for (var i = 0; i < distLines.length; i++) {
            var line = distLines[i];
            //未读取到node
            if (nodeName == null) {
                if (line.includes(configTool.distMarkStart)) {
                    line = line.trim();
                    nodeName = line.substring(configTool.distMarkStart.length + 1);
                }
            }
            else if (nodeName != null) {
                if (line.includes(configTool.distMarkEnd + " " + nodeName)) {
                    //读取到了结束字符
                    //todo 这里开始往里写值
                    var template = templateJson[nodeName];
                    if (template == null) {
                        distLines[i - 1] = `Not find node name: ${nodeName}`;
                    }
                    else {
                        if (template.type == TemplateType.ClazzStruct) {
                            var parseClassOrStruct = new ParseClassOrStruct();
                            distLines[i - 1] = parseClassOrStruct.parse(template, templateJson);
                        }
                        else if (template.type == TemplateType.Enumz) {
                            var parseEnumz = new ParseEnumz();
                            distLines[i - 1] = parseEnumz.parse(template, templateJson);
                        }
                        else if (template.type == TemplateType.File) {
                            var parseFile = new ParseFile();
                            distLines[i - 1] = parseFile.parse(template, templateJson);
                        }
                    }
                    nodeName = null;
                }
                else {
                    distLines[i] = "";
                }

            }
        }
        Tool.writeFile(distPath, distLines);
    }
}