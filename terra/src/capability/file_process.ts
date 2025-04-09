import { CXXFile } from "@agoraio-extensions/cxx-parser";
import { ProcessRawData } from "../type_definition";

export function processCXXFile(cxxFile: CXXFile, processRawData: ProcessRawData) {
    cxxFile.user_data = cxxFile.user_data || {};
    let nameString = cxxFile.fileName;
    nameString = nameString.split(".")[0];
    if (nameString.startsWith('I')) {
        nameString = nameString.substring(1);
    }
    cxxFile.user_data.nameString = nameString;
}