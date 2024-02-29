#define AGORA_RTC
#define AGORA_RTM

#if AGORA_RTC
namespace Agora.Rtc
#elif AGORA_RTM
namespace Agora.Rtm
#endif
{
    internal static partial class ObsoleteMethodWarning
    {
        internal const string GeneralWarning = "This method is deprecated.";
    }
}