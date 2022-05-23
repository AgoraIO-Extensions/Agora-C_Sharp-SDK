using System;
using System.Collections;
using System.Collections.Specialized;
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
        public bool IsArray { get { return false; } }
        public bool IsBoolean { get { return false; } }
        public bool IsDouble { get { return false; } }
        public bool IsInt { get { return false; } }
        public bool IsLong { get { return false; } }
        public bool IsObject { get { return false; } }
        public bool IsString { get { return false; } }

        public bool GetBoolean() { return false; }
        public double GetDouble() { return 0.0; }
        public int GetInt() { return 0; }
        public JsonType GetJsonType() { return JsonType.None; }
        public long GetLong() { return 0L; }
        public string GetString() { return ""; }

        public void SetBoolean(bool val) { }
        public void SetDouble(double val) { }
        public void SetInt(int val) { }
        public void SetJsonType(JsonType type) { }
        public void SetLong(long val) { }
        public void SetString(string val) { }

        public virtual string ToJson() { throw new NotImplementedException(); }
        public virtual void ToJson(JsonWriter writer) { }


        bool IList.IsFixedSize { get { return true; } }
        bool IList.IsReadOnly { get { return true; } }

        object IList.this[int index]
        {
            get { return null; }
            set { }
        }

        int IList.Add(object value) { return 0; }
        void IList.Clear() { }
        bool IList.Contains(object value) { return false; }
        int IList.IndexOf(object value) { return -1; }
        void IList.Insert(int i, object v) { }
        void IList.Remove(object value) { }
        void IList.RemoveAt(int index) { }


        int ICollection.Count { get { return 0; } }
        bool ICollection.IsSynchronized { get { return false; } }
        object ICollection.SyncRoot { get { return null; } }

        void ICollection.CopyTo(Array array, int index) { }


        IEnumerator IEnumerable.GetEnumerator() { return null; }


        bool IDictionary.IsFixedSize { get { return true; } }
        bool IDictionary.IsReadOnly { get { return true; } }

        ICollection IDictionary.Keys { get { return null; } }
        ICollection IDictionary.Values { get { return null; } }

        object IDictionary.this[object key]
        {
            get { return null; }
            set { }
        }

        void IDictionary.Add(object k, object v) { }
        void IDictionary.Clear() { }
        bool IDictionary.Contains(object key) { return false; }
        void IDictionary.Remove(object key) { }

        IDictionaryEnumerator IDictionary.GetEnumerator() { return null; }


        object IOrderedDictionary.this[int idx]
        {
            get { return null; }
            set { }
        }

        IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
        {
            return null;
        }
        void IOrderedDictionary.Insert(int i, object k, object v) { }
        void IOrderedDictionary.RemoveAt(int i) { }


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
