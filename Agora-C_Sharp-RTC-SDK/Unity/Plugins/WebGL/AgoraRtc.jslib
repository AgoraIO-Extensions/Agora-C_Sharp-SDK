var AgoraRtc = {
    $AgoraTool: {
        //对dynCall做一个封装
        agoraDynCall: function (sign, ptr, args) {
            if (typeof dynCall == "undefined")
                return Runtime.dynCall(sign, ptr, args);
            else
                return dynCall(sign, ptr, args);
        },

        agoraToString: function (ptrToSomeCString) {
            if (typeof UTF8ToString == "undefined")
                return Pointer_stringify(ptrToSomeCString);
            else
                return UTF8ToString(ptrToSomeCString);
        },

        bufferFromString: function (str) {
            var bufferSize = lengthBytesUTF8(str) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(str, buffer, bufferSize);
            return buffer;
        },

        //key:value => int, object
        ptrMap: {},
        mapIndex: 0,

        putPtr: function (ptr) {
            this.mapIndex++;
            this.ptrMap[this.mapIndex] = ptr;
            return this.mapIndex;
        },

        getPtr: function (mapIndex) {
            return this.ptrMap[mapIndex];
        },

        clearPtr: function (mapIndex) {
            delete this.ptrMap[mapIndex];
        },


        /**
        *
        * @param ptr
        * @param size
        * @param heap HEAP8, HEAPU8, HEAP16, HEAPU16, HEAP32, HEAPU32, HEAPF32, HEAPF64;
        * @returns
        */
        arrFromPtr: function (ptr, size, heap) {
            // 返回不生成数组的 HEAP 子数组（值复制）
            var startIndex = ptr / heap.BYTES_PER_ELEMENT;
            return heap.subarray(startIndex, startIndex + size);
        }

    },


    //return int
    CreateIrisApiEngine: function () {
        var engine_ptr = AgoraWrapper.CreateIrisApiEngine();
        var mapIndex = AgoraTool.putPtr(engine_ptr);
        return mapIndex;
    },


    DestroyIrisApiEngine: function (mapIndex) {
        var engine_ptr = AgoraTool.getPtr(mapIndex);
        AgoraWrapper.DestroyIrisApiEngine(engine_ptr);
        AgoraTool.clearPtr(mapIndex);
    },

    SetIrisRtcEngineEventHandler: function (engine_ptr_map_index, onEvent_ptr) {
        var engine_ptr = AgoraTool.getPtr(engine_ptr_map_index);
        var eventHandler = {
            onEvent: function (event, data, buffer, length, buffer_count) {
                var event_buffer = AgoraTool.bufferFromString(event);
                var data_buffer = AgoraTool.bufferFromString(data);
                AgoraTool.agoraDynCall("viiiii", onEvent_ptr, [event_buffer, data_buffer, 0, 0, 0])
            }
        };
        var irisEventHandlerHandle = AgoraWrapper.SetIrisRtcEngineEventHandler(engine_ptr, eventHandler);
        var handlerHandleMapIndex = AgoraTool.ptrMap(irisEventHandlerHandle);
        return handlerHandleMapIndex;
    },

    UnsetIrisRtcEngineEventHandler: function (engine_ptr_map_index, handle_map_index) {
        var engine_ptr = AgoraTool.getPtr(engine_ptr_map_index);
        var handle = AgoraTool.getPtr(handle_map_index);
        AgoraWrapper.UnsetIrisRtcEngineEventHandler(engine_ptr, handle);
        AgoraTool.clearPtr(handle_map_index);
    },

    CallIrisApi: function (engine_ptr_map_index, func_name_ptr, params_ptr, paramLength, bufferPtr, bufferLength) {
        var engine_ptr = AgoraTool.getPtr(engine_ptr_map_index);
        func_name = AgoraTool.agoraToString(func_name_ptr);
        params = AgoraTool.agoraToString(params_ptr);
        var result = {};
        AgoraWrapper.CallIrisApi(engine_ptr, func_name, params, paramLength, null, null, result);
        var str = JSON.stringify(result);
        //如果一个_malloc 出来的buffer,作为返回值返回给C#了，那么ILL2CPP会帮助你去_free这个buffer.否则需要显示的调用_free(buffer)才行
        var buffer = AgoraTool.bufferFromString(str);
        return buffer;
    },

    Attach: function (engine_ptr_map_index, manager_ptr_map_index) {
        var engine_ptr = AgoraTool.getPtr(engine_ptr_map_index);
        var manager_ptr = AgoraTool.getPtr(manager_ptr_map_index);
        AgoraWrapper.Attach(engine_ptr, manager_ptr);
    },

    Detach: function (engine_ptr_map_index, manager_ptr_map_index) {
        var engine_ptr = AgoraTool.getPtr(engine_ptr_map_index);
        var manager_ptr = AgoraTool.getPtr(manager_ptr_map_index);
        AgoraWrapper.Detach(engine_ptr, manager_ptr);
        AgoraTool.clearPtr(manager_ptr_map_index);
    },

    CreateIrisVideoFrameBufferManager: function () {
        var frameBufferManager = AgoraWrapper.CreateIrisVideoFrameBufferManager();
        var mapIndex = AgoraTool.putPtr(frameBufferManager);
        return mapIndex;
    },

    FreeIrisVideoFrameBufferManager: function (manager_ptr_map_index) {
        var manager_ptr = AgoraTool.getPtr(manager_ptr_map_index);
        AgoraWrapper.FreeIrisVideoFrameBufferManager(manager_ptr);
        AgoraTool.clearPtr(manager_ptr_map_index);
    },

    EnableVideoFrameBufferByConfig: function (manager_ptr_map_index,
        buffer_type, buffer_onVideoFrameReceived, buffer_bytes_per_row_alignment,
        config_type, config_id, config_key_ptr
    ) {
        var config_key = AgoraTool.agoraToString(config_key_ptr);
        var buffer = {
            type: buffer_type,
            OnVideoFrameReceived: buffer_onVideoFrameReceived,
            bytes_per_row_alignment: buffer_bytes_per_row_alignment
        };
        var config = {
            type: config_type,
            id: config_id,
            key: config_key
        };

        var manager_ptr = AgoraTool.getPtr(manager_ptr_map_index);
        var videoFrameBufferDelegateHandle = AgoraWrapper.EnableVideoFrameBufferByConfig(manager_ptr, buffer, config);
        var videoFrameBufferDelegateHandle_map_index = AgoraTool.putPtr(videoFrameBufferDelegateHandle);
        return videoFrameBufferDelegateHandle_map_index;
    },

    DisableVideoFrameBufferByDelegate: function (manager_ptr_map_index, handle_map_index) {
        var manager_ptr = AgoraTool.getPtr(manager_ptr_map_index);
        var handle = AgoraTool.getPtr(handle_map_index);
        AgoraWrapper.DisableVideoFrameBufferByDelegate(manager_ptr, handle);
    },

    DisableVideoFrameBufferByConfig: function (manager_ptr_map_index,
        config_type, config_id, config_key_ptr) {
        var config_key = AgoraTool.agoraToString(config_key_ptr);
        var manager_ptr = AgoraTool.getPtr(manager_ptr_map_index);
        var config = {
            type: config_type,
            id: config_id,
            key: config_key
        };
        AgoraWrapper.DisableVideoFrameBufferByConfig(manager_ptr, config);
    },

    DisableAllVideoFrameBuffer: function (manager_ptr_map_index) {
        var manager_ptr = AgoraTool.getPtr(manager_ptr_map_index);
        AgoraWrapper.DisableAllVideoFrameBuffer(manager_ptr);
    },

    UpdateTextureRawData: function (manager_ptr_map_index, nativeTexturePtr, type, id, channelName, sizePtr) {
        var manager_ptr = AgoraTool.getPtr(manager_ptr_map_index);
        var config = {
            type: type,
            id: id,
            key: channelName
        };
        var videoParams = AgoraWrapper.GetVideoFrameByConfig(manager_ptr, config);

        console.log(videoParams);


        if (videoParams == null)
            return false;

        if (videoParams.is_new_frame == false)
            return false;

        var videoTrack = videoParams.video_track;

        if (!videoTrack.isPlaying)
            return false;

        var v = videoTrackAny._player.videoElement;

        if (!(v.videoWidth > 0 && v.videoHeight > 0)) {
            return false;
        }


        //在这里可以把视频的宽高传递给C#层
        var array = AgoraTool.arrFromPtr(sizePtr, 2, HEAP32);
        array[0] = v.videoWidth;
        array[1] = v.videoHeight;


        //GL， GLctx 是 Unity 在jslib里注入的全局对象
        GLctx.deleteTexture(GL.textures[nativeTexturePtr]);
        var t = GLctx.createTexture();
        t.name = nativeTexturePtr;

        GL.textures[nativeTexturePtr] = t;

        GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[nativeTexturePtr]);
        GLctx.texParameteri(
            GLctx.TEXTURE_2D,
            GLctx.TEXTURE_WRAP_S,
            GLctx.CLAMP_TO_EDGE
        );
        GLctx.texParameteri(
            GLctx.TEXTURE_2D,
            GLctx.TEXTURE_WRAP_T,
            GLctx.CLAMP_TO_EDGE
        );
        GLctx.texParameteri(
            GLctx.TEXTURE_2D,
            GLctx.TEXTURE_MIN_FILTER,
            GLctx.LINEAR
        );
        GLctx.texImage2D(
            GLctx.TEXTURE_2D,
            0,
            GLctx.RGBA,
            GLctx.RGBA,
            GLctx.UNSIGNED_BYTE,
            v
        );

        return true;
    },


    //useless
    RegisterAudioFrameObserver: function () { },
    UnRegisterAudioFrameObserver: function () { },
    RegisterVideoFrameObserver: function () { },
    UnRegisterVideoFrameObserver: function () { },
    RegisterAudioEncodedFrameObserver: function () { },
    UnRegisterAudioEncodedFrameObserver: function () { },
    RegisterVideoEncodedImageReceiver: function () { },
    UnRegisterVideoEncodedImageReceiver: function () { },
    DisableVideoFrameBufferByUid: function () { },
    GetVideoFrame: function () { },
    StartDumpVideo: function () { },
    StopDumpVideo: function () { },
    ConvertVideoFrame: function () { },
    ClearVideoFrame: function () { },
    SetIrisMediaPlayerEventHandler: function () { },
    UnsetIrisMediaPlayerEventHandler: function () { },
    RegisterMediaPlayerAudioFrameObserver: function () { },
    UnRegisterMediaPlayerAudioFrameObserver: function () { },
    RegisterMediaPlayerAudioSpectrumObserver: function () { },
    UnRegisterMediaPlayerAudioSpectrumObserver: function () { },
    MediaPlayerOpenWithSource: function () { },
    MediaPlayerUnOpenWithSource: function () { },
    SetIrisCloudAudioEngineEventHandler: function () { },
    UnsetIrisCloudAudioEngineEventHandler: function () { },
    RegisterMediaMetadataObserver: function () { },
    UnRegisterMediaMetadataObserver: function () { }

};


autoAddDeps(AgoraRtc, '$AgoraTool');
mergeInto(LibraryManager.library, AgoraRtc);