using System;
using agora.rtc.LitJson;

namespace agora.rtc
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

    
    public class OptionalJsonParse : LitJson.IJsonWrapper
    {
        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public virtual bool IsArray => throw new NotImplementedException();

        public virtual bool IsBoolean => throw new NotImplementedException();

        public virtual bool IsDouble => throw new NotImplementedException();

        public virtual bool IsInt => throw new NotImplementedException();

        public virtual bool IsLong => throw new NotImplementedException();

        public virtual bool IsObject => throw new NotImplementedException();

        public virtual bool IsString => throw new NotImplementedException();

        public virtual bool IsFixedSize => throw new NotImplementedException();

        public virtual bool IsReadOnly => throw new NotImplementedException();

        public virtual ICollection Keys => throw new NotImplementedException();

        public virtual ICollection Values => throw new NotImplementedException();

        public virtual int Count => throw new NotImplementedException();

        public virtual bool IsSynchronized => throw new NotImplementedException();

        public virtual object SyncRoot => throw new NotImplementedException();

        public virtual int Add(object value)
        {
            throw new NotImplementedException();
        }

        public virtual void Add(object key, object value)
        {
            throw new NotImplementedException();
        }

        public virtual void Clear()
        {
            throw new NotImplementedException();
        }

        public virtual bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public virtual void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public virtual bool GetBoolean()
        {
            throw new NotImplementedException();
        }

        public virtual double GetDouble()
        {
            throw new NotImplementedException();
        }

        public virtual IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public virtual int GetInt()
        {
            throw new NotImplementedException();
        }

        public virtual JsonType GetJsonType()
        {
            throw new NotImplementedException();
        }

        public virtual long GetLong()
        {
            throw new NotImplementedException();
        }

        public virtual string GetString()
        {
            throw new NotImplementedException();
        }

        public virtual int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(int index, object key, object value)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public virtual void SetBoolean(bool val)
        {
            throw new NotImplementedException();
        }

        public virtual void SetDouble(double val)
        {
            throw new NotImplementedException();
        }

        public virtual void SetInt(int val)
        {
            throw new NotImplementedException();
        }

        public virtual void SetJsonType(JsonType type)
        {
            throw new NotImplementedException();
        }

        public virtual void SetLong(long val)
        {
            throw new NotImplementedException();
        }

        public virtual void SetString(string val)
        {
            throw new NotImplementedException();
        }

        public virtual string ToJson()
        {
            throw new NotImplementedException();
        }

        public virtual void ToJson(JsonWriter writer)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void WriteEnum(LitJson.JsonWriter writer, Object obj)
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
