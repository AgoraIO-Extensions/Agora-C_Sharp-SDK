import { Clazz, CXXFile, CXXTYPE, MemberFunction, CXXTerraNode, Variable } from "@agoraio-extensions/cxx-parser";
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
    //如果具有多个监听者，则这个监听者字典的名字叫什么
    listenersMapName?: string
    //如果具有多个监听者，则从这个监听者字典里取出去关键字的名字叫什么 
    listenersMapKey?: string
    //如果具有多个监听者，则从这个监听者字典里取出去关键字的的数据类型叫什么
    listenersMapKeyType?: string
    //如果只是单个监听者，则这个监听者的名字叫什么
    listenerName?: string
    /*callback config end*/
};

export interface ProcessRawData {
    //the class 
    clazz?: Clazz;
    //the method
    method?: MemberFunction;
    //the parameter
    parameter?: Variable;
    //the parameter index
    index?: number;
    //the custom head
    customHead?: CustomHead;
};


export interface ConversionTable {
    special_class_param: Record<string, string>;
    special_method_param: Record<string, string>;
    normal: Record<string, string>;
    reg: Record<string, string>;
}

