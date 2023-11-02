import sys
import os
import re
import shutil


number_code_list = [
    "Code/Rtc/Event/MediaRecorderObserver.cs",
    "Code/Rtc/Event/RtcEngineEventHandler.cs",
    "Code/Rtc/IAudioFrameObserver.cs",
    # "Code/Rtc/IAudioSpectrumObserver.cs",
    "Code/Rtc/IH265Transcoder.cs",
    "Code/Rtc/ILocalSpatialAudioEngine.cs",
    "Code/Rtc/IMediaRecorder.cs",
    "Code/Rtc/IMediaRecorderObserver.cs",
    "Code/Rtc/IMetadataObserver.cs",
    "Code/Rtc/IRtcEngine.cs",
    "Code/Rtc/IRtcEngineEx.cs",
    "Code/Rtc/IRtcEngineEventHandler.cs",
    "Code/Rtc/IVideoEncodedFrameObserver.cs",
    "Code/Rtc/IVideoFrameObserver.cs",
    "Code/Rtc/Impl/H265Transcoder.cs",
    "Code/Rtc/Impl/LocalSpatialAudioEngine.cs",
    "Code/Rtc/Impl/MediaRecorder.cs",
    "Code/Rtc/Impl/RtcEngine.cs",
    "Code/Rtc/Impl/Private/Impl/H265TranscoderImpl.cs",
    "Code/Rtc/Impl/Private/Impl/SpatialAudioEngineImpl.cs",
    "Code/Rtc/Impl/Private/Impl/MediaRecorderImpl.cs",
    "Code/Rtc/Impl/Private/Impl/RtcEngineImpl.cs",
    "Code/Rtc/VideoRender/TextureManager.cs",
    "Code/Rtc/VideoRender/TextureManagerYUV.cs",
    "Code/Rtc/VideoRender/VideoSurface.cs",
    "Code/Rtc/VideoRender/VideoSurfaceYUV.cs",
    "Code/Rtc/Types/AgoraBase.cs",
    # "Code/Rtc/Types/AgoraMediaBase.cs",
    "Code/Rtc/Types/AgoraRtcEngine.cs",
    "Code/Rtc/Types/AgoraRtcEngineEx.cs",
    "Code/Rtc/Types/AgoraSpatialAudio.cs"
]

string_code_list = [
    "Code/Rtc/Event/MediaRecorderObserverS.cs",
    "Code/Rtc/Event/RtcEngineEventHandlerS.cs",
    "Code/Rtc/IAudioSpectrumObserverS.cs",
    "Code/Rtc/IH265TranscoderS.cs",
    "Code/Rtc/ILocalSpatialAudioEngineS.cs",
    "Code/Rtc/IMediaRecorderS.cs",
    "Code/Rtc/IMediaRecorderObserverS.cs",
    "Code/Rtc/IMetadataObserverS.cs",
    "Code/Rtc/IRtcEngineS.cs",
    "Code/Rtc/IRtcEngineExS.cs",
    "Code/Rtc/IRtcEngineEventHandlerS.cs",
    "Code/Rtc/IVideoEncodedFrameObserverS.cs",
    "Code/Rtc/IVideoFrameObserverS.cs",
    "Code/Rtc/Impl/H265TranscoderS.cs",
    "Code/Rtc/Impl/LocalSpatialAudioEngineS.cs",
    "Code/Rtc/Impl/MediaRecorderS.cs",
    "Code/Rtc/Impl/RtcEngineS.cs",
    "Code/Rtc/Impl/Private/Impl/H265TranscoderImplS.cs",
    "Code/Rtc/Impl/Private/Impl/SpatialAudioEngineImplS.cs",
    "Code/Rtc/Impl/Private/Impl/MediaRecorderImplS.cs",
    "Code/Rtc/Impl/Private/Impl/RtcEngineImplS.cs",
    "Code/Rtc/VideoRender/TextureManagerS.cs",
    "Code/Rtc/VideoRender/TextureManagerYUVS.cs",
    "Code/Rtc/VideoRender/VideoSurfaceS.cs",
    "Code/Rtc/VideoRender/VideoSurfaceYUVS.cs",
    "Code/Rtc/Types/AgoraBaseS.cs",
    "Code/Rtc/Types/AgoraMediaBaseS.cs",
    "Code/Rtc/Types/AgoraRtcEngineS.cs",
    "Code/Rtc/Types/AgoraRtcEngineExS.cs",
    "Code/Rtc/Types/AgoraSpatialAudioS.cs"
]




# xxxx/xxxx/Agora-C_Sharp-RTC-SDK
ROOT = sys.argv[1]
RTC = sys.argv[2]
RTM = sys.argv[3]
NUMBER_UID = sys.argv[4]
STRING_UID = sys.argv[5]
FULL = sys.argv[6]
VOICE = sys.argv[7]

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

def replace_key_word_in_path(file_path, key_word, replace_word):
    files = get_all_files(file_path)
    for i in range(0, len(files)):
        file_name = files[i]
        if file_name.endswith(".cs"):
            # print(file_name)
            f = open(file_name, 'r', encoding='UTF-8')
            content = f.read()
            content = content.replace(key_word, replace_word)
            f.close()
            f = open(file_name, 'w')
            f.write(content)
            f.close()


# remove number uid code without number uid
if NUMBER_UID == 'false':
    for i in range(0, len(number_code_list)):
        full_path = os.path.join(ROOT, number_code_list[i])
        if os.path.isfile(full_path):
            os.remove(full_path)
        else :
            print('can not remove: {0}. becasue no such file'.format(full_path))

# remove string uid code without string uid
if STRING_UID == 'false':
    for i in range(0, len(string_code_list)):
        full_path = os.path.join(ROOT, string_code_list[i])
        if os.path.isfile(full_path):
            os.remove(full_path)
        else :
            print('can not remove: {0}. becasue no such file'.format(full_path))


#remove rtc code without rtc
if RTC == 'false' and os.path.isdir(os.path.join(ROOT, "Code/Rtc")):
    shutil.rmtree(os.path.join(ROOT, "Code/Rtc"))

# remove rtm code without rtm
if RTM == 'false' and os.path.isdir(os.path.join(ROOT, "Code/Rtm")):
    shutil.rmtree(os.path.join(ROOT, "Code/Rtm"))

# remove define without RTC
if RTC == 'false':
    remove_key_word_in_path(ROOT, '#define AGORA_RTC')

# remove define without RTM
if RTM == 'false':
    remove_key_word_in_path(ROOT, '#define AGORA_RTM')

if NUMBER_UID == 'false':
    remove_key_word_in_path(ROOT, '#define AGORA_NUMBER_UID')

if STRING_UID == 'false':
    remove_key_word_in_path(ROOT, '#define AGORA_STRING_UID')


if RTC == 'false':
    shutil.rmtree(os.path.join(ROOT, 'Resources'))
    os.mkdir(os.path.join(ROOT, 'Resources'))

if RTC == 'false':
    replace_key_word_in_path(os.path.join(ROOT,'Unity/Editor'), 'Agora-RTC-Plugin/Agora-Unity-RTC-SDK/Plugins/iOS','Agora-RTM-Plugin/Agora-Unity-RTM-SDK/Plugins/iOS')

