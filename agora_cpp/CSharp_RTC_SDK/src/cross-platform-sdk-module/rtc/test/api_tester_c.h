//
//  api_tester_c.h
//
//  Created by DYF on 2020/11/2.
//  Copyright © 2020 Agora.io. All rights reserved.
//

#ifndef api_tester_c_h
#define api_tester_c_h

#ifdef __cplusplus
extern "C" {
#endif


typedef void (*FUNC_APICaseHandler)(int apiType, const char *paramter);

void begin_api_test(const char *caseFilePath,
                    FUNC_APICaseHandler apiCaseHandler);

void compare_and_dump_api_test_result(const char *caseFilePath,
                                      const char *dumpFilePath,
                                      FUNC_APICaseHandler apiCaseHandler);

#ifdef __cplusplus
}
#endif

#endif /* api_tester_c_h */
