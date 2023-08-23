
export enum TemplateType {
    ClazzStruct = "ClazzStruct",
    Enumz = "Enumz",
    File = "File",
};

export interface TemplateHeadTail {
    head: string;
    tail: string;
}

export interface TemplateClassStruct {
    type: TemplateType;

    //类或者结构体名字例如 “IRtcEngine”
    name: string;
    //命名空间
    namespaces?:string;
    //头尾
    headTailTemple?: string;

    //包含的方法或者不包含的方法
    includeMethods?: string[];
    excludeMethods?: string[];
    //方法之间的分割符号
    methodSplitSymbol?: string;
    commonMethodTemplate?: string;

    //Map<string,string>
    specialMethodsTemplate?: object;

    //包含的成员或者不包含的方法
    includeMembers?: string[];
    excludeMembers?: string[];
    memberSplitSymbol?: string;

    commonMemberTemplate?: string;
    specialMembersTemplate?: object;

    //是否要追溯父节点, 1表示追溯1层。n表示追溯n层
    trackBackFather?: number;
};



export interface TemplateEnumz {
    type: TemplateType
    //枚举的名字。 IAgoraRtcEngine.h
    name: string;


    headTailTemple?: string;
    //
    commonFieldTemple?: string,
    FieldSplitSymbol?: string,

    specialFieldTemplate?: object;

    includeField?: string[];
    excludeField?: string[];
};


export interface TemplateFile {
    //File
    type: TemplateType;

    //文件的名字。 IAgoraRtcEngine.h
    name: string;

    //Class的模板
    commonClassStructTemplate: string,
    //Map<string,string>
    specialClassStructTemplate?: object;

    includeClassStruct?: string[];
    excludeClassStruct?: string[];


    //Enum
    commmonEnumTemplate: string,
    specialEnumTemplate?: object;

    includeEnum?: string[];
    excludeEnum?: string[];

    //分隔符号
    splitSymbol:string;
};



export interface TemplateJoin {
    format: string;
    split: string;
}