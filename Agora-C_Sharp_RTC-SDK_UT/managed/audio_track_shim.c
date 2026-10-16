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
void *CreateIrisEventHandler(void *callback) { (void)callback; handles++; return malloc(1); }
void DestroyIrisEventHandler(void *handle) { if (handle) { handles--; free(handle); } }
int TestLiveHandles(void) { return handles; }
int CallIrisApi(void *engine, ApiParam *param) {
  (void)engine;
  /* A failed Native registration must not destroy another track's observer. */
  int result = strstr(param->data, "99") ? -2 : 0;
  sprintf(param->result, "{\"result\":%d}", result);
  return 0;
}
