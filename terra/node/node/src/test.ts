import { ConfigTool } from "./ConfigTool";
import { ParamNameTrans } from "./ParamNameTrans";
import { ParseTemplate } from "./ParseTemplate";
import { ParamTypeTrans } from "./ParamTypeTrans";
import * as fs from 'fs';
import { execSync } from 'child_process';
import { ParamDefaultTrans } from "./ParamDefaultTrans";
import { ParseEngine } from "./PraseEngine";
import { Tool } from "./Tool";
// ConfigTool.getInstance().loadDistMark("#region terra", "#endregion terra");
// ConfigTool.getInstance().loadParamTypeTrans(new ParamTypeTrans("/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/terra/node/templates/C_Sharp-SDK-Code/param_type_trans.json"));
// ConfigTool.getInstance().loadParamNameFormalTrans(new ParamNameTrans("/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/terra/node/templates/C_Sharp-SDK-Code/param_name_formal_trans.json"));
// ConfigTool.getInstance().loadParamNameActualTrans(new ParamNameTrans("/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/terra/node/templates/C_Sharp-SDK-Code/param_name_actual_trans.json"));
// ConfigTool.getInstance().loadParamDefaultTrans(new ParamDefaultTrans("/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/terra/node/templates/C_Sharp-SDK-Code/param_name_foraml_default_trans.json"));

var cxxiles = JSON.parse(fs.readFileSync("/Users/xiayangqun/Documents/agoraSpace/iris-ast/terra-cli/.dist/src/dump_json.json", { encoding: 'utf-8' }));
// ConfigTool.getInstance().loadCXXFiles(cxxiles);

// var parse = new ParseTemplate();
// parse.parse("/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs",
//     "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/terra/node/templates/C_Sharp-SDK-Code/Rtc/IRtcEngine.cs.json");
// var fileName = "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/Agora-C_Sharp-RTC-SDK/Code/Rtc/IRtcEngine.cs";
// execSync(`clang-format -i ${fileName}`);

new ParseEngine(
    "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/Agora-C_Sharp-RTC-SDK/Code",
    "/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK-NG/terra/node/templates/C_Sharp-SDK-Code",
    cxxiles,
    "#region terra",
    "#endregion terra"
);

console.log("++++++++++++++++");

// Tool.getCppConstructor("MediaRecorderConfiguration", "/Users/xiayangqun/Documents/agoraSpace/iris-ast/agora_rtc_ast/tmp/AgoraMediaBase.h")
