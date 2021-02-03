cmake_minimum_required(VERSION 3.17)
project(agora_cpp)

add_library(agora_cpp SHARED
        iris/src/c/iris_c_api.cc
        iris/src/internal/json_to_struct.cc
        iris/src/internal/metadata_observer.cc
        iris/src/internal/rtc_channel_event_handler.cc
        iris/src/internal/rtc_engine_event_handler.cc
        iris/src/internal/struct_extensions.cc
        iris/src/internal/struct_to_json.cc
        iris/src/iris_channel.cc
        iris/src/iris_device_manager.cc
        iris/src/iris_engine.cc)
include_directories(iris/include)
target_link_libraries(agora_cpp ../lib/agora_rtc_sdk)