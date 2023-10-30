
//类(结构体名字)
${-oCLAZZ_STRUCT_NAME}
//真正属于谁，有的方法是从父类继承来的
${-oBELONG_TO}

//方法名字
${-oMETHOD_NAME}
${-oMETHOD_RETURN_TYPE}

//制定特殊函数
${SPECIAL_METHOD_LOGIC:cSharpSDK_MethodObsolete}
//制定特殊的成员
${SPECIAL_MEMBER_LOGIC:cSharpSDK_MethodObsolete}
${SPECIAL_CLAZZ_STRUCT_LOGIC:cSharpSDK_MethodObsolete}

//参数Join的制定格式
${METHOD_PARAM_JOIN:xxxxx.txt}
    //参数类型
    ${-oPARAM_TYPE}
    //参数名字(形参)
    ${-oPARAM_NAME_FORMAL}
    //参数名字(实参)
    ${-oPARAM_NAME_ACTUAL}
    //形式参数的默认值
    ${-oPARAM_NAME_FORMAL_DEFAULT}

//成员名字
${-oMEMBER_NAME}
//成员类型
${-oMEMBER_TYPE}


//枚举的名字
${-oENUMZ_NAME}


//枚举成员的名字和值
${-oENUMZ_FIELD_NAME}
${-oENUMZ_FIELD_VALUE}

${-oENUMZ_FIELD_NAME:0}
${-oENUMZ_FIELD_VALUE:0}

//命名空间的Join
${NAME_SPACES_JOIN:namespace_join.txt}
//单个namespace
${-oNAME_SPACE}

-o :不做任何变动
-l :首字母小写
-m :全部字母大写
-u :首字母大写
-v :全部字母大写
-r :首字母移除
-t :删除所有的下划线并且将下划线后的第一个字母给大写.比如 error_code => errorCode
-y :删除所有空格，并将空格后的第一个字母大写比如 err code => errCode
-n :有的时候会有相同名字的成员函数多个.加上这个前缀之后，比如第二个joinChannel会变成joinChannel2
-s :删除名字里的命名空间，比如名字叫 media::base::IVideoObserver => IVideoObserver
-c :去除字符后边的 &， * 等字符传
-p :从末尾删除一个文字
-e :在转化后的字符前边加上一个 = 号，如果字符串不为空的话
-d :使用在枚举值上，即使枚举值为空，也会推测出当前的枚举值，并且写入。注意应该总是将d放在第一位
-f :删除最开头的ref
-a :删除最开头的@

以上规则可以自由组合，比如
-ut: 先首字母大写,然后再删除所有的下划线并且将下划线后的第一个字母给大写.比如 error_code => Error_code => ErrorCode



