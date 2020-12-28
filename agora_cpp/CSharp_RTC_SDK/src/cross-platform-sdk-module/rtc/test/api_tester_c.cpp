//
//  api_tester_c.cpp
//
//  Created by DYF on 2020/11/2.
//  Copyright © 2020 Agora.io. All rights reserved.
//

#include "api_tester_c.h"
#include "ApiTester.h"

class MyApiCaseHandler : public agora::common::APICaseHandler {
public:
  MyApiCaseHandler(FUNC_APICaseHandler apiCaseHandler)
      : apiCaseHandler_(apiCaseHandler) {}
  void handleAPICase(int apiType, const char *paramter) override {
    if (apiCaseHandler_) {
      apiCaseHandler_(apiType, paramter);
    }
  }

private:
  FUNC_APICaseHandler apiCaseHandler_ = nullptr;
};

#ifdef __cplusplus
extern "C" {
#endif

void begin_api_test(const char *caseFilePath,
                    FUNC_APICaseHandler apiCaseHandler) {
  MyApiCaseHandler handler(apiCaseHandler);
  BeginApiTest(caseFilePath, &handler);
}

void compare_and_dump_api_test_result(const char *caseFilePath,
                                      const char *dumpFilePath,
                                      FUNC_APICaseHandler apiCaseHandler) {
  MyApiCaseHandler handler(apiCaseHandler);
  CompareAndDumpApiTestResult(caseFilePath, dumpFilePath, &handler);
}

#ifdef __cplusplus
}
#endif
