//
//  event_tester_c.h
//
//  Created by DYF on 2020/11/2.
//  Copyright © 2020 Agora.io. All rights reserved.
//

#ifndef event_tester_c_h
#define event_tester_c_h

#include "../c_api/cross_platform_c_api_wrapper.h"

#ifdef __cplusplus
extern "C" {
#endif

void begin_rtc_engine_event_test(const char *caseFilePath,
                                 struct RtcEventHandler *eventHandler);
void compare_dump_rtc_engine_event_test_result(const char *caseFilePath,
                                               const char *dumpFilePath,
                                               struct RtcEventHandler *eventHandler);
void log_engine_event_case(const char *eventType, const char *parameter);

void begin_channel_event_test(const char *caseFilePath, const char *channelId,
                              struct ChannelEventHandler *eventHandler);
void compare_dump_channel_event_test_result(const char *caseFilePath,
                                            const char *dumpFilePath,
                                            const char *channelId,
                                            struct ChannelEventHandler *eventHandler);
void log_channel_event_case(const char *eventType, const char *parameter);

#ifdef __cplusplus
}
#endif

#endif /* event_tester_c_h */
