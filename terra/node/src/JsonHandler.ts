// import * as fs from "fs";
// import * as path from "path";

// export enum CXXTYPE {
//     IncludeDirective = "IncludeDirective",
//     Clazz = "Clazz",
//     Struct = "Struct",
//     MemberFunction = "MemberFunction",
//     Variable = "Variable",
//     SimpleType = "SimpleType",
//     MemberVariable = "MemberVariable",
//     EnumConstant = "EnumConstant",
//     Enumz = "Enumz",
// }

// export interface BaseNode {
//     name: string;
//     namespaces: string[];
//     file_path: string;
//     parent_name: string;
// }

// export interface IncludeDirective extends BaseNode {
//     __TYPE: CXXTYPE;
//     include_file_path: string;
// }

// export interface Constructor {
//     name: string;
//     parameters: Variable[];
// }

// export interface Clazz extends BaseNode {
//     __TYPE: CXXTYPE;
//     constructors: Constructor[];
//     methods: MemberFunction[];
//     member_variables: MemberVariable[];
//     base_clazzs: string[];
// }

// export interface Struct extends Clazz {

// }

// export interface Enumz {
//     __TYPE: CXXTYPE;
//     name: string;
//     namespaces: string[];
//     parent_name: string;
//     enum_constants: EnumConstant[];
// }

// export interface MemberFunction extends BaseNode {
//     is_virtual: boolean;
//     return_type: SimpleType;

//     parameters: Variable[];
//     access_specifier: string;
//     is_overriding: boolean;
//     signature: string;
// }

// export interface Variable {
//     __TYPE: CXXTYPE;
//     name: string;
//     type: SimpleType;
//     default_value: string;
//     is_output: boolean;
// }

// export enum SimpleTypeKind {
//     value_t = 100,
//     pointer_t = 101,
//     reference_t = 102,
//     array_t = 103
// };

// export interface SimpleType {
//     name: string;
//     source: string;
//     kind: SimpleTypeKind;
//     is_const: boolean;
//     is_builtin_type: boolean;
// }

// export interface MemberVariable {
//     name: string;
//     type: SimpleType;
//     is_mutable: boolean;
//     access_specifier: string;
// }

// export interface EnumConstant {
//     __TYPE: CXXTYPE;
//     name: string;
//     value: string;
// }

// export class JsonHandler {
//     //users下的文件夹名字，例如xiayangqun
//     private readonly _path: string;
//     private readonly _jsonMap: Map<string, any[]> = new Map();
//     private readonly _format: string;

//     public constructor(userPath: string) {
//         this._path = userPath;
//         let fullPath = process.cwd() + "/../users/" + userPath + "/json";
//         let files: string[] = fs.readdirSync(fullPath);
//         for (let file of files) {
//             let jsonPath = path.join(fullPath, file);
//             // console.log(jsonPath);
//             let jsonStr = fs.readFileSync(jsonPath, 'utf-8');
//             let json = JSON.parse(jsonStr);
//             this._jsonMap.set(file, json);
//         }
//     }

//     public getClassOrStruct(name: string, namespaces: string = null): Clazz | Struct {
//         for (let e of this._jsonMap) {
//             let array: any[] = e[1];
//             for (let v of array) {
//                 if ((v.__TYPE == CXXTYPE.Clazz || v.__TYPE == CXXTYPE.Struct) && v.name == name) {
//                     if (namespaces && v.namespaces) {
//                         if (namespaces == v.namespaces.join("::")) {
//                             return v;
//                         }
//                     }
//                     else {
//                         return v;
//                     }
//                 }
//             }
//         }
//     }

//     public getEnumz(name: string): Enumz {
//         for (let e of this._jsonMap) {
//             let array: any[] = e[1];
//             for (let v of array) {
//                 if (v.__TYPE == CXXTYPE.Enumz && v.name == name) {
//                     return v;
//                 }
//             }
//         }
//     }

//     public getArrayByFile(file: string): any[] {
//         return this._jsonMap.get(file);
//     }
// }
