/* Test-only Iris transport: exercise the real managed registration methods. */
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <stdint.h>
typedef struct {
  const char *event, *data;
  unsigned data_size;
  char *result;
  void *buffer, *length;
  unsigned buffer_count;
} ApiParam;
static int handles;
static char last_data[65536];
const char *TestLastData(void) { return last_data; }
void *CreateIrisEventHandler(void *callback) { (void)callback; handles++; return malloc(1); }
void DestroyIrisEventHandler(void *handle) { if (handle) { handles--; free(handle); } }
int TestLiveHandles(void) { return handles; }
int CallIrisApi(void *engine, ApiParam *param) {
  (void)engine;
  snprintf(last_data, sizeof(last_data), "%s", param->data);
  if (strcmp(param->event, "RtcEngine_getLoopbackRecordingSources_89105d0") == 0) {
    if (strstr(param->data, "\"flags\":0")) return -2;
    strcpy(param->result, "{\"result\":[{\"appName\":\"中文播放器\",\"windowTitle\":\"测试\",\"processIds\":[7,4294967295],\"processCount\":2}]}");
    return 0;
  }
  if (strcmp(param->event, "MusicContentCenter_sendExtRequest_5651f34") == 0) {
    strcpy(param->result, "{\"result\":0,\"requestId\":\"ext-4538\"}");
    return 0;
  }
  /* A failed Native registration must not destroy another track's observer. */
  int result = strstr(param->data, "99") ? -2 : 0;
  sprintf(param->result, "{\"result\":%d}", result);
  return 0;
}
