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


# convert /**    */
def convertToCShapeDocs(str_):
    summary_list = []
    param_list = []
    return_list = []
    now_state = "summary"
    lines = str_.split("\n")
    for i in range(0, len(lines)):
        each_line = lines[i]
        if each_line == "*/":
            continue
        each_line = each_line.replace("/**", "")
        each_line = each_line.replace("*", "")
        each_line = each_line.strip()
        if (each_line == ""):
            continue
        
        if each_line.find("@param"):
            each_line = each_line.replace("@param", "")
            each_line = each_line.replace("[in]", "")
            split_line = each_line.splite(" ", 2)
            param_str = '<param name="' + \
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
            new_docs = convertToCShapeDocs(docs)
            content = content.replace(docs, new_docs)
        f = open(file_name, 'w')
        f.write(content)
        f.close()
