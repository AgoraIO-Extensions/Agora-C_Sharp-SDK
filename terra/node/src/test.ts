import { ConfigTool } from "./ConfigTool";
import { ParamNameTrans } from "./ParamNameTrans";
import { ParseTemplate } from "./ParseTemplate";
import { ParamTypeTrans } from "./ParamTypeTrans";
import * as fs from 'fs';
import { execSync } from 'child_process';
import { ParamDefaultTrans } from "./ParamDefaultTrans";
import { ParseEngine } from "./PraseEngine";
import { Tool } from "./Tool";
import { AddAllDocTag, AddAllDocContetnt, DeleteAllOldDoc } from "./DocHelper";

var cxxiles = JSON.parse(fs.readFileSync("/Users/xiayangqun/Documents/agoraSpace/iris-ast/terra-cli/.dist/src/dump_json.json", { encoding: 'utf-8' }));

new ParseEngine(
    "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/Agora-C_Sharp-RTC-SDK/Code",
    "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/terra/templates/C_Sharp-SDK-Code",
    "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/terra/templates/C_Sharp-SDK-Trans",
    cxxiles,
    "#region terra",
    "#endregion terra"
);

new ParseEngine(
    "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/Agora-C_Sharp_RTC-SDK_UT/ut",
    "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/terra/templates/C_Sharp-SDK-UT",
    "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/terra/templates/C_Sharp-SDK-Trans",
    cxxiles,
    "#region terra",
    "#endregion terra"
);

// var data = Tool.getCppConstructor("VideoTrackInfo", "/Users/xiayangqun/Documents/agoraSpace/iris-ast/agora_rtc_ast/tmp/AgoraBase.h")
// console.log(JSON.stringify(data));
execSync("dotnet format ../../Agora-C_Sharp_RTC-SDK_UT/Agora_C_Sharp_SDK_UT.sln");
DeleteAllOldDoc();
AddAllDocTag();
AddAllDocContetnt();
execSync("dotnet format ../../Agora-C_Sharp_RTC-SDK_UT/Agora_C_Sharp_SDK_UT.sln");



