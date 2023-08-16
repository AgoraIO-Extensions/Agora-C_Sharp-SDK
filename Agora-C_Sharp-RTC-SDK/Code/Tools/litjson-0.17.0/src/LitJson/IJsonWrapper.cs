#region Header
/**
 * IJsonWrapper.cs
 *   Interface that represents a type capable of handling all kinds of JSON
 *   data. This is mainly used when mapping objects through JsonMapper, and
 *   it's implemented by JsonData.
 *
 * The authors disclaim copyright to this source code. For more details, see
 * the COPYING file included with this distribution.
 **/
#endregion

#define AGORA_RTC
#define AGORA_RTM

using System.Collections;
using System.Collections.Specialized;

#if AGORA_RTC
namespace Agora.Rtc.LitJson
#elif AGORA_RTM
namespace Agora.Rtm.LitJson
#endif
{
    public enum JsonType
    {
        None,

        Object,
        Array,
        String,
        Int,
        UInt,
        Long,
        ULong,
        Double,
        Boolean
    }

    public interface IJsonWrapper : IList, IOrderedDictionary
    {
        bool IsArray   { get; }
        bool IsBoolean { get; }
        bool IsDouble  { get; }
        bool IsInt     { get; }
        bool IsUInt    { get; }
        bool IsLong    { get; }
        bool IsULong   { get; }
        bool IsObject  { get; }
        bool IsString  { get; }

        bool     GetBoolean ();
        double   GetDouble ();
        int      GetInt ();
        uint      GetUInt();
        JsonType GetJsonType ();
        long     GetLong ();
        ulong    GetULong();
        string   GetString ();

        void SetBoolean  (bool val);
        void SetDouble   (double val);
        void SetInt      (int val);
        void SetUInt     (uint val);
        void SetJsonType (JsonType type);
        void SetLong     (long val);
        void SetULong    (ulong val);
        void SetString   (string val);

        string ToJson ();
        void   ToJson (JsonWriter writer);
    }
}
