import { ConfigTool } from "./ConfigTool";
import { Clazz, MemberFunction, MemberVariable } from "./terra";

export class SpeicalLogic {

    public cSharpSDK_Obsolete(clazzName: string, info: MemberFunction): string {
        var lines = info.comment.split("\n");
        for (var i = 0; i < lines.length; i++) {
            var line = lines[i];
            line = line.trim();
            if (line.includes("@deprecated")) {
                var out = line.replace("@deprecated", "");
                out = out.trim();
                return `[Obsolete("${out}")]`;
            }
        }
        return "";
    }

    public cSharpSDK_ImplJsonAdd(clazzName: string, info: MemberFunction): string {
        var lines = [];
        var configTool = ConfigTool.getInstance();
        for (let p of info.parameters) {
            var transType = configTool.paramTypeTrans.transType(clazzName, info.name, p.type.source, p.name);
            if (transType != "@remove" && transType != "byte[]" && transType.includes("ref ") == false) {
                lines.push(` _param.Add("${p.name}", ${configTool.paramNameFormalTrans.transType(clazzName, info.name, p.name)});`)
            }
        }
        return lines.join('\n');
    }

    public cSharpSDK_ImplResultGet(clazzName: string, info: MemberFunction): string {
        var transReturn = ConfigTool.getInstance().paramTypeTrans.transType(clazzName, info.name, info.return_type.source, info.return_type.name);
        var defaultValueMap = {
            int: 'nRet',
            long: 'nRet',
            ulong: '0',
            uint: '0',
            string: '""',
            bool: 'false',
            CONNECTION_STATE_TYPE: 'CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED',
            track_id_t: '0',
            float: '0'
        };
        var simpleType = ["int", "ulong", "uint", "long", "string", "bool", "track_id_t", "float"];
        var defaultValue = defaultValueMap[transReturn] || 'null';

        if (simpleType.includes(transReturn)) {
            //基本数据类型
            return `var result = nRet != 0 ? ${defaultValue} : (${transReturn})AgoraJson.GetData<${transReturn}>(_apiParam.Result, "result");`;
        }
        else if (transReturn.includes('[]')) {
            //是数组
            return `var result = nRet != 0 ? ${defaultValue} : (${transReturn})AgoraJson.JsonToStructArray<${transReturn.substring(0, transReturn.length - 2)}>(_apiParam.Result, "result");`;
        }
        else {
            //是结构体
            if (this.cSharpSDK_IsEnumz(transReturn)) {
                return `var result = nRet != 0 ? ${defaultValue} : (${transReturn})AgoraJson.JsonToStruct<int>(_apiParam.Result, "result");`;
            }
            else {
                return `var result = nRet != 0 ? ${defaultValue} : (${transReturn})AgoraJson.JsonToStruct<${transReturn}>(_apiParam.Result, "result");`;
            }
        }
    }

    public cSharpSDK_IsEnumz(paramType: string): boolean {
        if (paramType.includes('_') && paramType.toUpperCase() == paramType) {
            return true;
        }
        return false;
    }

    public cSharpSDK_ImplRefGet(clazzName: string, info: MemberFunction): string {
        var valueMap = [
            "int",
            "ulong",
            "uint",
            "string",
            "bool",
        ];
        var configTool = ConfigTool.getInstance();
        var lines = [];

        for (let p of info.parameters) {
            var transType = configTool.paramTypeTrans.transType(clazzName, info.name, p.type.source, p.name);
            if (transType.includes("ref ")) {
                //是ref类型
                transType = transType.substring(4);
                if (valueMap.includes(transType)) {
                    //基本数据类型
                    lines.push(`${p.name} = (${transType})AgoraJson.GetData<${transType}>(_apiParam.Result, "${p.name}");`);
                }
                else if (transType.includes('[]')) {
                    //是数组
                    lines.push(`${p.name} = AgoraJson.JsonToStructArray<${transType.substring(0, transType.length - 2)}>(_apiParam.Result, "${p.name}");`);
                }
                else {
                    //是结构体
                    if (this.cSharpSDK_IsEnumz(transType)) {
                        lines.push(`${p.name} = (${transType})AgoraJson.JsonToStruct<int>(_apiParam.Result, "${p.name}");`);
                    }
                    else {
                        lines.push(`${p.name} = AgoraJson.JsonToStruct<${transType}>(_apiParam.Result, "${p.name}");`);
                    }
                }
            }
        }
        if (lines.length > 0) {
            lines.unshift('if (nRet == 0){');
            lines.push('}');
        }

        return lines.join('\n');
    }

    public cSharpSDK_ImplPullAudioFrameAssignment(clazzName: string, m: MemberVariable): string {
        if (m.name != "buffer") {
            return `frame.${m.name} = f.${m.name};`;
        }
        return "";
    }

    public cSharpSDK_ScreenCaptureSourceInfoInternalMemberAssignment(clazzName: string, m: MemberVariable): string {
        if (m.type.source.includes("ThumbImageBuffer")) {
            return `screenCaptureSourceInfo.${m.name} = this.${m.name}.GenerateThumbImageBuffer();`
        }
        else {
            return `screenCaptureSourceInfo.${m.name} = this.${m.name};`
        }
    }

    public cSharpSDK_ScreenCaptureSourceInfoInternalMemberList(clazzName: string, m: MemberVariable): string {
        let transType = ConfigTool.getInstance().paramTypeTrans.transType(clazzName, null, m.type.source, m.name);
        if (transType.includes("ThumbImageBuffer")) {
            return `public ${transType}Internal ${m.name};`;
        }
        else {
            return `public ${transType} ${m.name};`;
        }
    }

    public cSharpSDK_ThumbImageBufferInternalMemberAssignment(clazzName: string, m: MemberVariable): string {
        if (m.name == 'buffer') {
            return ` byte[] thumbBuffer = new byte[length];
            if (imageBuffer.length > 0)
            {
                Marshal.Copy((IntPtr)(this.buffer), thumbBuffer, 0, (int)imageBuffer.length);
            }
            imageBuffer.buffer = thumbBuffer;`;
        }
        else {
            return `imageBuffer.${m.name} = this.${m.name};`
        }
    }

    public cSharpSDK_ThumbImageBufferInternalMemberList(clazzName: string, m: MemberVariable): string {
        let transType = ConfigTool.getInstance().paramTypeTrans.transType(clazzName, null, m.type.source, m.name);
        if (m.name == "buffer") {
            return `public IntPtr ${m.name};`;
        }
        else {
            return `public ${transType} ${m.name};`;
        }
    }

}