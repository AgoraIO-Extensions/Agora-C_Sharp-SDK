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
import path from "path";

let jsonPath = getTerraJsonPath();
console.log(jsonPath);
let cxxiles = JSON.parse(fs.readFileSync(jsonPath, { encoding: 'utf-8' }));

new ParseEngine(
    path.join(__dirname, "../../../Agora-C_Sharp-RTC-SDK/Code"),
    path.join(__dirname, "../../../terra/templates/C_Sharp-SDK-Code"),
    path.join(__dirname, "../../../terra/templates/C_Sharp-SDK-Trans"),
    cxxiles,
    "#region terra",
    "#endregion terra",
    path.join(__dirname, "../../../../terra_shared_configs/headers/rtc_4.3.1/include")
);

new ParseEngine(
    path.join(__dirname, "../../../Agora-C_Sharp_RTC-SDK_UT/ut"),
    path.join(__dirname, "../../../terra/templates/C_Sharp-SDK-UT"),
    path.join(__dirname, "../../../terra/templates/C_Sharp-SDK-Trans"),
    cxxiles,
    "#region terra",
    "#endregion terra",
    path.join(__dirname, "../../../../terra_shared_configs/headers/rtc_4.3.1/include")
);

execSync("dotnet format ../../Agora-C_Sharp_RTC-SDK_UT/Agora_C_Sharp_SDK_UT.sln");

// add doc 
DeleteAllOldDoc();
AddAllDocTag();
AddAllDocContetnt();
execSync("dotnet format ../../Agora-C_Sharp_RTC-SDK_UT/Agora_C_Sharp_SDK_UT.sln");


function getTerraJsonPath(): string {
    let jsonDir = path.join(__dirname, "../.terra/cxx_parser");
    let jsonFiles = fs.readdirSync(jsonDir).filter(file => file.startsWith("dump_json_"));
    return path.join(jsonDir, jsonFiles[0]);
}


