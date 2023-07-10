import sys
import os
import re
import shutil

# xxxx/xxxx/Agora-C_Sharp-RTC-SDK
ROOT = sys.argv[1]
RTC = sys.argv[2]
RTM = sys.argv[3]

print('remove code by macor.py {0},{1},{2}'.format(ROOT, RTC, RTM))


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


def remove_key_word_in_path(file_path, key_word):
    files = get_all_files(file_path)
    for i in range(0, len(files)):
        file_name = files[i]
        if file_name.endswith(".cs"):
            # print(file_name)
            f = open(file_name, 'r', encoding='UTF-8')
            content = f.read()
            content = content.replace(key_word, '')
            f.close()
            f = open(file_name, 'w')
            f.write(content)
            f.close()


if RTC == 'false' and os.path.isdir(os.path.join(ROOT, "Code/Rtc")):
    shutil.rmtree(os.path.join(ROOT, "Code/Rtc"))

if RTM == 'false' and os.path.isdir(os.path.join(ROOT, "Code/Rtm")):
    shutil.rmtree(os.path.join(ROOT, "Code/Rtm"))

if RTC == 'false':
    remove_key_word_in_path(ROOT, '#define AGORA_RTC')

if RTM == 'false':
    remove_key_word_in_path(ROOT, '#define AGORA_RTM')

if RTC == 'false':
    shutil.rmtree(os.path.join(ROOT, 'Resource'))
    os.mkdir(os.path.join(ROOT, 'Resource'))
