import { ConfigTool } from "./ConfigTool";
import { ParamNameTrans } from "./ParamNameTrans";
import { ParseTemplate } from "./ParseTemplate";
import { ParamTypeTrans } from "./ParamTypeTrans";
import * as fs from 'fs';
import { execSync } from 'child_process';
import { ParamDefaultTrans } from "./ParamDefaultTrans";
import { ParseEngine } from "./PraseEngine";
import { Tool } from "./Tool";

var cxxiles = JSON.parse(fs.readFileSync("/Users/xiayangqun/Documents/agoraSpace/iris-ast/terra-cli/.dist/src/dump_json.json", { encoding: 'utf-8' }));

new ParseEngine(
    "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/Agora-C_Sharp-RTC-SDK/Code",
    "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/terra/node/templates/C_Sharp-SDK-Code",
    cxxiles,
    "#region terra",
    "#endregion terra"
);

var data = Tool.getCppConstructor("VideoTrackInfo", "/Users/xiayangqun/Documents/agoraSpace/iris-ast/agora_rtc_ast/tmp/AgoraBase.h")
console.log(JSON.stringify(data));