import sys
import os
import re
import shutil
import string

# root dir you want convert docs
root_dir = sys.argv[1]


def get_all_files(target_dir):
    files = []
    list_files = os.listdir(target_dir)
    for i in range(0, len(list_files)):
        each_file = os.path.join(target_dir, list_files[i])
        if os.path.isdir(each_file):
            files.extend(get_all_files(each_file))
        elif os.path.isfile(each_file):
            files.append(each_file)
    return files


def get_line_split_str(str_):
    lines = str_.split("\n")
    second_line = lines[1]
    split_list = ["\n"]
    for i in range(0, len(second_line)):
        if second_line[i] == ' ':
            split_list.append(' ')
        else:
            break
    split_list.pop()
    return ''.join(split_list)


# convert /**    */
def convert_to_c_shape_docs(str_):
    summary_list = []
    param_list = []
    return_list = []
    now_state = "summary"
    lines = str_.split("\n")
    for i in range(0, len(lines)):
        each_line = lines[i]
        each_line = each_line.strip()
        if each_line == "*/":
            continue
        each_line = each_line.replace("/**", "")
        each_line = each_line.replace("/*", "")
        each_line = each_line.replace("*", "")
        each_line = each_line.strip()
        if (each_line == ""):
            continue

        if each_line.find("@param") != -1:
            each_line = each_line.replace("@param", "")
            each_line = each_line.replace("[in]", "")
            each_line = each_line.strip()
            print(each_line)
            split_line = each_line.split(" ", 1)
            print(split_line)
            param_str = '/// <param name="' + \
                split_line[0].strip()+'"> ' + \
                split_line[1].strip() + '</param>'
            param_list.append(param_str)
            continue

        if each_line.find("@brief") != -1:
            each_line = each_line.replace("@brief", "")
            now_state = "summary"

        if each_line.find("@return") != -1:
            each_line = each_line.replace("@return", "")
            now_state = "return"

        if now_state == 'summary':
            summary_list.append(each_line.strip())
        else:
            return_list.append(each_line.strip())

    cs_docs_lines = []
    cs_docs_lines.append("///")

    # summary
    cs_docs_lines.append("/// <summary>")
    for i in range(0, len(summary_list)):
        cs_docs_lines.append("/// " + summary_list[i])
    cs_docs_lines.append("/// </summary>")
    cs_docs_lines.append("///")

    # param
    if len(param_list) > 0:
        for i in range(0, len(param_list)):
            cs_docs_lines.append(param_list[i])
        cs_docs_lines.append("///")

    # return
    if len(return_list) > 0:
        cs_docs_lines.append("/// <returns>")
        for i in range(0, len(return_list)):
            cs_docs_lines.append("/// " + return_list[i])
        cs_docs_lines.append("/// </returns>")
        cs_docs_lines.append("///")

    join_str = get_line_split_str(str_)
    return join_str.join(cs_docs_lines)


# convert //
def convert_to_c_shape_docs2(str_):
    line = str_.strip()
    line = line.replace("//", "")
    line = line.strip()

    cs_docs_lines = []
    cs_docs_lines.append("///")

    # summary
    cs_docs_lines.append("/// <summary>")
    cs_docs_lines.append("/// " + line)
    cs_docs_lines.append("/// </summary>")
    cs_docs_lines.append("///")

    return "\n".join(cs_docs_lines)


# convert /**    */
files = get_all_files(root_dir)
for i in range(0, len(files)):
    file_name = files[i]
    if file_name.endswith(".cs"):
        f = open(file_name, 'r', encoding='UTF-8')
        content = f.read()
        f.close()
        # match /** */
        re_str = r'\/\*(?:[^\*]|\*+[^\/\*])*\*+\/'
        result = re.findall(re_str, content)
        for j in range(0, len(result)):
            docs = result[j]
            new_docs = convert_to_c_shape_docs(docs)
            content = content.replace(docs, new_docs, 1)

        f = open(file_name, 'w')
        f.write(content)
        f.close()

        # clang-foramt
        os.system("clang-format -i " + file_name)



# # convert //
# files = ["/Users/xiayangqun/Documents/agoraSpace/Agora-C_Sharp-SDK/Agora-C_Sharp-RTC-SDK/Code/Rtm/Types/RtmResult.cs"]
# for i in range(0, len(files)):
#     for i in range(0, len(files)):
#         file_name = files[i]
#         if file_name.endswith(".cs") == False:
#             continue

#         f = open(file_name, 'r', encoding='UTF-8')
#         content = f.read()
#         f.close()

#         lines = content.split("\n")
#         for i in range(0,len(lines)):
#             each_line = lines[i]
#             if each_line.find("///") !=-1:
#                 continue

#             re_str = r'//.*'
#             print("each_line: " + each_line)
#             result = re.findall(re_str, each_line)
#             if len(result) == 0:
#                 continue
#             docs = result[0] 
#             new_docs = convert_to_c_shape_docs2(docs)
#             print(docs)
#             print(new_docs)
#             print("__________")
#             lines[i] = new_docs

#         content = "\n".join(lines)
#         f = open(file_name, 'w')
#         f.write(content)
#         f.close()
#         # clang-foramt
#         os.system("clang-format -i " + file_name)
        
os.system("dotnet format ../../Agora-C_Sharp_RTC-SDK_UT/Agora_C_Sharp_SDK_UT.sln")
