import { ParamDefaultTrans } from "./ParamDefaultTrans";
import { ParamNameTrans } from "./ParamNameTrans";
import { ParamTypeTrans } from "./ParamTypeTrans";
import { CXXTYPE, CXXFile, TerraNode, Clazz, Struct, Enumz } from "./terra"
export class ConfigTool {

    private static _instance: ConfigTool = null;
    public static getInstance(): ConfigTool {
        if (this._instance == null) {
            this._instance = new ConfigTool();
        }
        return this._instance;
    }

    public cxxOriginFileDir: string = "";
    public cxxFiles: CXXFile[] = null;
    public distMarkStart: string = "";
    public distMarkEnd: string = "";
    public paramNameFormalTrans: ParamNameTrans = null;
    public paramNameActualTrans: ParamNameTrans = null;
    public paramDefaultTrans: ParamDefaultTrans = null;
    public paramTypeTrans: ParamTypeTrans = null;

    public loadDistMark(markStart: string, markEnd: string): void {
        this.distMarkStart = markStart;
        this.distMarkEnd = markEnd;
    }

    public loadCXXOriginFileDir(dir: string) {
        this.cxxOriginFileDir = dir;
    }

    public loadCXXFiles(cxxFiles: CXXFile[]) {
        this.cxxFiles = cxxFiles;
    }

    public loadParamNameFormalTrans(paramTrans: ParamNameTrans) {
        this.paramNameFormalTrans = paramTrans;
    }
    public loadParamNameActualTrans(paramTrans: ParamNameTrans) {
        this.paramNameActualTrans = paramTrans;
    }

    public loadParamTypeTrans(typeTrans: ParamTypeTrans) {
        this.paramTypeTrans = typeTrans;
    }

    public loadParamDefaultTrans(defaultTrans: ParamDefaultTrans) {
        this.paramDefaultTrans = defaultTrans;
    }

    /*AgoraBase.h*/
    public getTerraNodeByHeadFile(headFile: string): TerraNode[] {
        for (var i = 0; i < this.cxxFiles.length; i++) {
            var cxxFile = this.cxxFiles[i];
            if (cxxFile.file_path.endsWith(headFile)) {
                return cxxFile.nodes;
            }
        }
        console.error('cant find ' + headFile);
        return null;
    }

    public getClassOrStruct(name: string, namespaces: string = null, fileName: string = null): Clazz | Struct {
        for (let e of this.cxxFiles) {
            if (fileName && e.file_path.endsWith(fileName) == false)
                continue;
            let array: any[] = e.nodes;
            for (let v of array) {
                if ((v.__TYPE == CXXTYPE.Clazz || v.__TYPE == CXXTYPE.Struct) && v.name == name) {
                    if (namespaces && v.namespaces) {
                        if (namespaces == v.namespaces.join("::")) {
                            return v;
                        }
                    }
                    else {
                        return v;
                    }
                }
            }
        }

        console.warn("getClassOrStruct error:" + name);

    }

    public getEnumz(name: string, fileName: string = null): Enumz {
        for (let e of this.cxxFiles) {
            if (fileName && e.file_path.endsWith(fileName) == false)
                continue;

            let array: any[] = e.nodes;
            for (let v of array) {
                if (v.__TYPE == CXXTYPE.Enumz && v.name == name) {
                    return v;
                }
            }
        }

    }
}