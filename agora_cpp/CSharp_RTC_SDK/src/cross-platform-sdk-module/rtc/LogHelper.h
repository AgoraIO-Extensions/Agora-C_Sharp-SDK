//
//  LogHelper.hpp
//  agoraRTMCWrapper
//
//  Created by 张涛 on 2020/10/15.
//  Copyright © 2020 张涛. All rights reserved.
//

#ifndef AGORA_LOG_HELPER_H
#define AGORA_LOG_HELPER_H

#include <iostream>
#include <fstream>
#include <stdarg.h>

namespace agora {
    class LogHelper {
    private:
        FILE* fileStream = nullptr;

    private:
        LogHelper(const char* logPath) {
            startLogService(logPath);
        }

        ~LogHelper() {
            stopLogService();
        }

    public:
        static LogHelper& getInstance(const char* logPath) {
            static LogHelper logHelper(logPath);
            return logHelper;
        }


    private:
        void startLogService(const char* filePath) {
            if (fileStream)
                return;

            if (filePath)
                fileStream = fopen(filePath, "ab+");
        }

        void stopLogService() {
            if (fileStream) {
                fflush(fileStream);
                fclose(fileStream);
                fileStream = nullptr;
            }
        }

    public:
        void writeLog(const char* format, ...) {
            va_list la;
            va_start(la, format);

            if (!fileStream)
                return;

            vfprintf(fileStream, format, la);
            va_end(la);
            fprintf(fileStream, "\n");
            fflush(fileStream);
        }
    };
}

#endif
