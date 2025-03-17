export interface CustomHead {
    name: string;
    name_space?: string[];
    //custom methods will be added to the interface
    custom_methods?: string[];
    //methods will be excluded from the interface
    exclude_methods?: string[];
    //macros will be added to the methods
    methods_with_macros?: {
        name: string;
        macro: string;
    }[];
    // will extend the parent class
    parent?: string;
    // will merge the nodes methods, and the node will be hidden is isHide is true
    merge_nodes?: { name: string, isHide: boolean }[];
    // will hide the interface
    isHide?: boolean;
};