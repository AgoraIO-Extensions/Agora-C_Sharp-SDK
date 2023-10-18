#define AGORA_RTC
#define AGORA_RTM

using System;
using System.Collections;
using System.Collections.Specialized;

#if AGORA_RTC
using Agora.Rtc.LitJson;
#elif AGORA_RTM
using Agora.Rtm.LitJson;
#endif

#if AGORA_RTC
namespace Agora.Rtc
#elif AGORA_RTM
namespace Agora.Rtm
#endif
{
    public class Optional<T>
    {
        private T value;
        private bool hasValue;

        public Optional()
        {
            hasValue = false;
        }

        public bool HasValue()
        {
            return hasValue;
        }

        public T GetValue()
        {
            return this.value;
        }

        public void SetValue(T val)
        {
            this.hasValue = true;
            this.value = val;
        }

        public void SetEmpty()
        {
            this.hasValue = false;
        }

    }

    public interface IOptionalJsonParse
    {
        void ToJson(JsonWriter writer);
    }
}
