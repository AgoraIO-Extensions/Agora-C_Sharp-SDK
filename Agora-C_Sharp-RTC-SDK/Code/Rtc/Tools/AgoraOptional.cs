using System;
using System.Collections;
using System.Collections.Specialized;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
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


    public class OptionalJsonParse 
    {
        public virtual void ToJson(JsonWriter writer)
        {
            throw new NotImplementedException();
        }

        public virtual void WriteEnum(LitJson.JsonWriter writer, Object obj)

        {
            Type obj_type = obj.GetType();
            Type e_type = Enum.GetUnderlyingType(obj_type);

            if (e_type == typeof(long))
                writer.Write((long)obj);
            else if (e_type == typeof(uint))
                writer.Write((uint)obj);
            else if (e_type == typeof(ulong))
                writer.Write((ulong)obj);
            else if (e_type == typeof(ushort))
                writer.Write((ushort)obj);
            else if (e_type == typeof(short))
                writer.Write((short)obj);
            else if (e_type == typeof(byte))
                writer.Write((byte)obj);
            else if (e_type == typeof(sbyte))
                writer.Write((sbyte)obj);
            else
                writer.Write((int)obj);
        }

    }

}
