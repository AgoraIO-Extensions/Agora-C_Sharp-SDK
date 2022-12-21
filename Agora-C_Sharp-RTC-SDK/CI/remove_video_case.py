import sys
import os
import re 
import shutil

# xxxx/xxxx/Assets/Agora-RTC-Plugin/API-Example
root_dir = sys.argv[1]
print ("because package only audio. remove video case now")
print ("root_dir " + root_dir)

video_list = [
    {'dir_name':'Examples/Basic/JoinChannelVideo', 'scene_name':'BasicVideoCallScene'},

    {'dir_name':'Examples/Advanced/ContentInspect', 'scene_name':'ContentInspectScene'},
    {'dir_name':'Examples/Advanced/CustomCaptureVideo', 'scene_name':'CustomCaptureVideoScene'},
    {'dir_name':'Examples/Advanced/DualCamera', 'scene_name':'DualCameraScene'},
    {'dir_name':'Examples/Advanced/ProcessVideoRawData', 'scene_name':'ProcessVideoRawDataScene'},
    {'dir_name':'Examples/Advanced/PushEncodedVideoImage', 'scene_name':'PushEncodedVideoImageScene'},
    {'dir_name':'Examples/Advanced/RenderWithYUV', 'scene_name':'RenderWithYUV'},
    {'dir_name':'Examples/Advanced/ScreenShare', 'scene_name':'ScreenShareScene'},
    {'dir_name':'Examples/Advanced/ScreenShareWhileVideoCall', 'scene_name':'ScreenShareWhileVideoCallScene'},
    {'dir_name':'Examples/Advanced/SetBeautyEffectOptions', 'scene_name':'SetBeautyEffectOptionsScene'},
    {'dir_name':'Examples/Advanced/SetVideoEncodeConfiguration', 'scene_name':'SetVideoEncodeConfigurationScene'},
    {'dir_name':'Examples/Advanced/TakeSnapshot', 'scene_name':'TakeSnapshotScene'},
    {'dir_name':'Examples/Advanced/VirtualBackground', 'scene_name':'VirtualBackgroundScene'},
    {'dir_name':'Examples/Advanced/WriteBackVideoRawData', 'scene_name':'WriteBackVideoRawDataScene'},
]

home_cs_file = open(root_dir + '/Home.cs')
home_cs_string = home_cs_file.read()
home_cs_file.close()

length = len(video_list)
for i in range(length):
    e = video_list[i]
    # delete case files
    dir_name = e['dir_name']
    print("remove ing :" + root_dir + "/" + dir_name)
    if os.path.exists(root_dir + "/" + dir_name):
        shutil.rmtree(root_dir + "/" + dir_name)
        os.remove(root_dir + "/" + dir_name + ".meta")
    else:
        print (root_dir + "/" + dir_name + "not exists")

    #remove scene name from home.cs
    scene_name = e['scene_name']
    pa = re.compile(r'"'+ scene_name + r'",{0,1}')
    home_cs_string = pa.sub("",home_cs_string)
    

home_cs_file = open(root_dir + '/Home.cs','w')
home_cs_file.write(home_cs_string)
home_cs_file.close()


