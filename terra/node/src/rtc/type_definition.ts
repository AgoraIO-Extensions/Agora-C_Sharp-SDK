import { Clazz, Enumz, Struct, MemberFunction, CXXFile, Variable, MemberVariable } from "@agoraio-extensions/cxx-parser";
export interface CustomHead {
    name: string;
    name_space?: string[];
    //custom methods will be added to the interface
    custom_methods?: string[];
    //methods will be excluded from the interface
    hide_methods?: string[];
    //macros will be added to the methods
    methods_with_macros?: {
        name: string;
        macro: string;
    }[];
    // will extend the parent class
    parent?: string;
    // will merge the nodes methods, 
    merge_nodes?: {
        name: string,
        //and the node will be hidden is isHide is true
        isHide: boolean,
        //if override_method_hide is true, the method will be deepClone to node and method's isHide will be reset to self hide_methods
        override_method_hide?: boolean
    }[];
    // will hide the interface
    isHide?: boolean;

    /*callback config bengin*/
    //all method will be abstract
    isAbstract?: boolean;
    //if true, the callback from this class will be cross thread
    isCallbackCrossThread?: boolean;
    //Name of the dictionary that holds multiple listeners, if any
    listenersMapName?: string
    //Name of the key used to retrieve from the listeners dictionary, if there are multiple listeners
    listenersMapKey?: string
    //Data type of the key used to retrieve from the listeners dictionary, if there are multiple listeners
    listenersMapKeyType?: string
    //Name of the single listener, if there's only one listener
    listenerName?: string
    /*callback config end*/

    /*struct config begin*/
    //the struct attributes
    attributes?: string[],
    //the struct members will be hidden
    hide_members?: string[],
    //the struct members will not be serialized to json
    hide_to_json?: string[],
    /*struct config end*/
};

export interface ProcessRawData {
    cxxFile?: CXXFile;
    //the class 
    clazz?: Clazz;
    //the enum
    enumz?: Enumz;
    //the struct
    struct?: Struct;
    //the method
    method?: MemberFunction;
    //the parameter
    parameter?: Variable;
    //the parameter index
    index?: number;
    //the member
    member?: MemberVariable;
    //the custom head
    customHead?: CustomHead;
};


export interface ConversionTable {
    special_class_param: Record<string, string>;
    special_method_param: Record<string, string>;
    normal: Record<string, string>;
    reg: Record<string, string>;
}

