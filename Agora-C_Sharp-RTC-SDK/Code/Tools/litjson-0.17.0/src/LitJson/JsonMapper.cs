#region Header
/**
 * JsonMapper.cs
 *   JSON to .Net object and object to JSON conversions.
 *
 * The authors disclaim copyright to this source code. For more details, see
 * the COPYING file included with this distribution.
 **/
#endregion


using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Agora.Rtc.LitJson
{
    internal struct PropertyMetadata
    {
        public MemberInfo Info;
        public bool IsField;
        public Type Type;
    }


    internal struct ArrayMetadata
    {
        private Type element_type;
        private bool is_array;
        private bool is_list;


        public Type ElementType
        {
            get
            {
                if (element_type == null)
                    return typeof(JsonData);

                return element_type;
            }

            set { element_type = value; }
        }

        public bool IsArray
        {
            get { return is_array; }
            set { is_array = value; }
        }

        public bool IsList
        {
            get { return is_list; }
            set { is_list = value; }
        }
    }


    internal struct ObjectMetadata
    {
        private Type element_type;
        private bool is_dictionary;

        private IDictionary<string, PropertyMetadata> properties;


        public Type ElementType
        {
            get
            {
                if (element_type == null)
                    return typeof(JsonData);

                return element_type;
            }

            set { element_type = value; }
        }

        public bool IsDictionary
        {
            get { return is_dictionary; }
            set { is_dictionary = value; }
        }

        public IDictionary<string, PropertyMetadata> Properties
        {
            get { return properties; }
            set { properties = value; }
        }
    }


    internal delegate void ExporterFunc(object obj, JsonWriter writer);
    public delegate void ExporterFunc<T>(T obj, JsonWriter writer);

    internal delegate object ImporterFunc(object input);
    public delegate TValue ImporterFunc<TJson, TValue>(TJson input);

    public delegate IJsonWrapper WrapperFactory();


    public class JsonMapper
    {
        #region Fields
        private static readonly int max_nesting_depth;

        private static readonly IFormatProvider datetime_format;

        private static readonly IDictionary<Type, ExporterFunc> base_exporters_table;
        private static readonly IDictionary<Type, ExporterFunc> custom_exporters_table;

        private static readonly IDictionary<Type,
                IDictionary<Type, ImporterFunc>> base_importers_table;
        private static readonly IDictionary<Type,
                IDictionary<Type, ImporterFunc>> custom_importers_table;

        private static readonly IDictionary<Type, ArrayMetadata> array_metadata;
        private static readonly object array_metadata_lock = new Object();

        private static readonly IDictionary<Type,
                IDictionary<Type, MethodInfo>> conv_ops;
        private static readonly object conv_ops_lock = new Object();

        private static readonly IDictionary<Type, ObjectMetadata> object_metadata;
        private static readonly object object_metadata_lock = new Object();

        private static readonly IDictionary<Type,
                IList<PropertyMetadata>> type_properties;
        private static readonly object type_properties_lock = new Object();

        private static readonly JsonWriter static_writer;
        private static readonly object static_writer_lock = new Object();
        #endregion


        #region Constructors
        static JsonMapper()
        {
            max_nesting_depth = 100;

            array_metadata = new Dictionary<Type, ArrayMetadata>();
            conv_ops = new Dictionary<Type, IDictionary<Type, MethodInfo>>();
            object_metadata = new Dictionary<Type, ObjectMetadata>();
            type_properties = new Dictionary<Type,
                            IList<PropertyMetadata>>();

            static_writer = new JsonWriter();

            datetime_format = DateTimeFormatInfo.InvariantInfo;

            base_exporters_table = new Dictionary<Type, ExporterFunc>();
            custom_exporters_table = new Dictionary<Type, ExporterFunc>();

            base_importers_table = new Dictionary<Type,
                                 IDictionary<Type, ImporterFunc>>();
            custom_importers_table = new Dictionary<Type,
                                   IDictionary<Type, ImporterFunc>>();

            RegisterBaseExporters();
            RegisterCustomExporters();
            RegisterBaseImporters();
            RegisterCustomImporters();
        }
        #endregion


        #region Private Methods
        private static void AddArrayMetadata(Type type)
        {
            if (array_metadata.ContainsKey(type))
                return;

            ArrayMetadata data = new ArrayMetadata();

            data.IsArray = type.IsArray;

            if (type.GetInterface("System.Collections.IList") != null)
                data.IsList = true;

            foreach (PropertyInfo p_info in type.GetProperties())
            {
                if (p_info.Name != "Item")
                    continue;

                ParameterInfo[] parameters = p_info.GetIndexParameters();

                if (parameters.Length != 1)
                    continue;

                if (parameters[0].ParameterType == typeof(int))
                    data.ElementType = p_info.PropertyType;
            }

            lock (array_metadata_lock)
            {
                try
                {
                    array_metadata.Add(type, data);
                }
                catch (ArgumentException)
                {
                    return;
                }
            }
        }

        private static void AddObjectMetadata(Type type)
        {
            if (object_metadata.ContainsKey(type))
                return;

            ObjectMetadata data = new ObjectMetadata();

            if (type.GetInterface("System.Collections.IDictionary") != null)
                data.IsDictionary = true;

            data.Properties = new Dictionary<string, PropertyMetadata>();

            foreach (PropertyInfo p_info in type.GetProperties())
            {
                if (p_info.Name == "Item")
                {
                    ParameterInfo[] parameters = p_info.GetIndexParameters();

                    if (parameters.Length != 1)
                        continue;

                    if (parameters[0].ParameterType == typeof(string))
                        data.ElementType = p_info.PropertyType;

                    continue;
                }

                PropertyMetadata p_data = new PropertyMetadata();
                p_data.Info = p_info;
                p_data.Type = p_info.PropertyType;

                data.Properties.Add(p_info.Name, p_data);
            }

            foreach (FieldInfo f_info in type.GetFields())
            {
                PropertyMetadata p_data = new PropertyMetadata();
                p_data.Info = f_info;
                p_data.IsField = true;
                p_data.Type = f_info.FieldType;

                data.Properties.Add(f_info.Name, p_data);
            }

            lock (object_metadata_lock)
            {
                try
                {
                    object_metadata.Add(type, data);
                }
                catch (ArgumentException)
                {
                    return;
                }
            }
        }

        private static void AddTypeProperties(Type type)
        {
            if (type_properties.ContainsKey(type))
                return;

            IList<PropertyMetadata> props = new List<PropertyMetadata>();

            foreach (PropertyInfo p_info in type.GetProperties())
            {
                if (p_info.Name == "Item")
                    continue;

                PropertyMetadata p_data = new PropertyMetadata();
                p_data.Info = p_info;
                p_data.IsField = false;
                props.Add(p_data);
            }

            foreach (FieldInfo f_info in type.GetFields())
            {
                PropertyMetadata p_data = new PropertyMetadata();
                p_data.Info = f_info;
                p_data.IsField = true;

                props.Add(p_data);
            }

            lock (type_properties_lock)
            {
                try
                {
                    type_properties.Add(type, props);
                }
                catch (ArgumentException)
                {
                    return;
                }
            }
        }

        private static MethodInfo GetConvOp(Type t1, Type t2)
        {
            lock (conv_ops_lock)
            {
                if (!conv_ops.ContainsKey(t1))
                    conv_ops.Add(t1, new Dictionary<Type, MethodInfo>());
            }

            if (conv_ops[t1].ContainsKey(t2))
                return conv_ops[t1][t2];

            MethodInfo op = t1.GetMethod(
                "op_Implicit", new Type[] { t2 });

            lock (conv_ops_lock)
            {
                try
                {
                    conv_ops[t1].Add(t2, op);
                }
                catch (ArgumentException)
                {
                    return conv_ops[t1][t2];
                }
            }

            return op;
        }

        private static object ReadValue(Type inst_type, JsonReader reader)
        {
            reader.Read();

            if (reader.Token == JsonToken.ArrayEnd)
                return null;

            Type underlying_type = Nullable.GetUnderlyingType(inst_type);
            Type value_type = underlying_type ?? inst_type;

            if (reader.Token == JsonToken.Null)
            {
#if NETSTANDARD1_5
                if (inst_type.IsClass() || underlying_type != null) {
                    return null;
                }
#else
                if (inst_type.IsClass || underlying_type != null)
                {
                    return null;
                }
#endif

                throw new JsonException(String.Format(
                            "Can't assign null to an instance of type {0}",
                            inst_type));
            }



            if (reader.Token == JsonToken.Double ||
                reader.Token == JsonToken.Int ||
                reader.Token == JsonToken.UInt ||
                reader.Token == JsonToken.Long ||
                reader.Token == JsonToken.ULong ||
                reader.Token == JsonToken.String ||
                reader.Token == JsonToken.Boolean)
            {

                Type json_type = reader.Value.GetType();

                if (value_type.IsAssignableFrom(json_type))
                    return reader.Value;


                // If there's a custom importer that fits, use it
                if (custom_importers_table.ContainsKey(json_type) &&
                    custom_importers_table[json_type].ContainsKey(
                        value_type))
                {

                    ImporterFunc importer =
                        custom_importers_table[json_type][value_type];

                    return importer(reader.Value);
                }

                // Maybe there's a base importer that works
                if (base_importers_table.ContainsKey(json_type) &&
                    base_importers_table[json_type].ContainsKey(
                        value_type))
                {

                    ImporterFunc importer =
                        base_importers_table[json_type][value_type];

                    return importer(reader.Value);
                }

                // Maybe it's an enum
#if NETSTANDARD1_5
                if (value_type.IsEnum())
                    return Enum.ToObject (value_type, reader.Value);
#else
                if (value_type.IsEnum)
                    return Enum.ToObject(value_type, reader.Value);
#endif
                // Try using an implicit conversion operator
                MethodInfo conv_op = GetConvOp(value_type, json_type);

                if (conv_op != null)
                    return conv_op.Invoke(null,
                                           new object[] { reader.Value });

                // No luck
                throw new JsonException(String.Format(
                        "Can't assign value '{0}' (type {1}) to type {2}",
                        reader.Value, json_type, inst_type));
            }

            object instance = null;

            if (reader.Token == JsonToken.ArrayStart)
            {

                AddArrayMetadata(inst_type);
                ArrayMetadata t_data = array_metadata[inst_type];

                if (!t_data.IsArray && !t_data.IsList)
                    throw new JsonException(String.Format(
                            "Type {0} can't act as an array",
                            inst_type));

                IList list;
                Type elem_type;

                if (!t_data.IsArray)
                {
                    list = (IList)Activator.CreateInstance(inst_type);
                    elem_type = t_data.ElementType;
                }
                else
                {
                    list = new ArrayList();
                    elem_type = inst_type.GetElementType();
                }

                list.Clear();

                while (true)
                {
                    object item = ReadValue(elem_type, reader);
                    if (item == null && reader.Token == JsonToken.ArrayEnd)
                        break;

                    list.Add(item);
                }

                if (t_data.IsArray)
                {
                    int n = list.Count;
                    instance = Array.CreateInstance(elem_type, n);

                    for (int i = 0; i < n; i++)
                        ((Array)instance).SetValue(list[i], i);
                }
                else
                    instance = list;

            }
            else if (reader.Token == JsonToken.ObjectStart)
            {

                AddObjectMetadata(value_type);
                ObjectMetadata t_data = object_metadata[value_type];

                instance = Activator.CreateInstance(value_type);

                while (true)
                {
                    reader.Read();

                    if (reader.Token == JsonToken.ObjectEnd)
                        break;

                    string property = (string)reader.Value;

                    if (t_data.Properties.ContainsKey(property))
                    {
                        PropertyMetadata prop_data =
                            t_data.Properties[property];

                        if (custom_importers_table.ContainsKey(prop_data.Type))
                        {
                            var dict = custom_importers_table[prop_data.Type];
                            reader.Read();

                            Object t;
                            if (reader.Value == null)
                            {
                                t = null;
                            }
                            else
                            {
                                var type = reader.Value.GetType();
                                if (dict.ContainsKey(type))
                                {
                                    var importer = dict[type];
                                    t = importer(reader.Value);
                                }
                                else
                                {
                                    throw new NotImplementedException("custom_importers_table miss: adapter" + prop_data.Type + " " + type);
                                }
                            }


                            if (prop_data.IsField)
                            {
                                ((FieldInfo)prop_data.Info).SetValue(
                                    instance, t);
                            }
                            else
                            {
                                PropertyInfo p_info =
                                (PropertyInfo)prop_data.Info;

                                if (p_info.CanWrite)
                                    p_info.SetValue(
                                        instance,
                                        t,
                                        null);
                                //else
                                //t;
                            }
                            //else
                            //{
                            //    var type = reader.Value.GetType();
                            //    if (dict.ContainsKey(type))
                            //    {
                            //        var importer = dict[type];
                            //        Object t = importer(reader.Value);

                            //    }
                            //    else
                            //    {
                            //        }
                            //}
                        }
                        else if (prop_data.IsField)
                        {
                            ((FieldInfo)prop_data.Info).SetValue(
                                instance, ReadValue(prop_data.Type, reader));
                        }
                        else
                        {
                            PropertyInfo p_info =
                                (PropertyInfo)prop_data.Info;

                            if (p_info.CanWrite)
                                p_info.SetValue(
                                    instance,
                                    ReadValue(prop_data.Type, reader),
                                    null);
                            else
                                ReadValue(prop_data.Type, reader);
                        }

                    }
                    else
                    {
                        if (!t_data.IsDictionary)
                        {

                            if (!reader.SkipNonMembers)
                            {
                                throw new JsonException(String.Format(
                                        "The type {0} doesn't have the " +
                                        "property '{1}'",
                                        inst_type, property));
                            }
                            else
                            {
                                ReadSkip(reader);
                                continue;
                            }
                        }

                      ((IDictionary)instance).Add(
                          property, ReadValue(
                              t_data.ElementType, reader));
                    }

                }

            }

            return instance;
        }

        private static IJsonWrapper ReadValue(WrapperFactory factory,
                                               JsonReader reader)
        {
            reader.Read();

            if (reader.Token == JsonToken.ArrayEnd ||
                reader.Token == JsonToken.Null)
                return null;

            IJsonWrapper instance = factory();

            if (reader.Token == JsonToken.String)
            {
                instance.SetString((string)reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.Double)
            {
                instance.SetDouble((double)reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.Int)
            {
                instance.SetInt((int)reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.UInt)
            {
                instance.SetUInt((uint)reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.Long)
            {
                instance.SetLong((long)reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.ULong)
            {
                instance.SetULong((ulong)reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.Boolean)
            {
                instance.SetBoolean((bool)reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.ArrayStart)
            {
                instance.SetJsonType(JsonType.Array);

                while (true)
                {
                    IJsonWrapper item = ReadValue(factory, reader);
                    if (item == null && reader.Token == JsonToken.ArrayEnd)
                        break;

                    ((IList)instance).Add(item);
                }
            }
            else if (reader.Token == JsonToken.ObjectStart)
            {
                instance.SetJsonType(JsonType.Object);

                while (true)
                {
                    reader.Read();

                    if (reader.Token == JsonToken.ObjectEnd)
                        break;

                    string property = (string)reader.Value;

                    ((IDictionary)instance)[property] = ReadValue(
                        factory, reader);
                }

            }

            return instance;
        }

        private static void ReadSkip(JsonReader reader)
        {
            ToWrapper(
                delegate { return new JsonMockWrapper(); }, reader);
        }

        private static void RegisterBaseExporters()
        {
            base_exporters_table[typeof(byte)] =
                delegate (object obj, JsonWriter writer)
                {
                    writer.Write(Convert.ToInt32((byte)obj));
                };

            base_exporters_table[typeof(char)] =
                delegate (object obj, JsonWriter writer)
                {
                    writer.Write(Convert.ToString((char)obj));
                };

            base_exporters_table[typeof(DateTime)] =
                delegate (object obj, JsonWriter writer)
                {
                    writer.Write(Convert.ToString((DateTime)obj,
                                                    datetime_format));
                };

            base_exporters_table[typeof(decimal)] =
                delegate (object obj, JsonWriter writer)
                {
                    writer.Write((decimal)obj);
                };

            base_exporters_table[typeof(sbyte)] =
                delegate (object obj, JsonWriter writer)
                {
                    writer.Write(Convert.ToInt32((sbyte)obj));
                };

            base_exporters_table[typeof(short)] =
                delegate (object obj, JsonWriter writer)
                {
                    writer.Write(Convert.ToInt32((short)obj));
                };

            base_exporters_table[typeof(ushort)] =
                delegate (object obj, JsonWriter writer)
                {
                    writer.Write(Convert.ToInt32((ushort)obj));
                };

            base_exporters_table[typeof(uint)] =
                delegate (object obj, JsonWriter writer)
                {
                    writer.Write(Convert.ToUInt64((uint)obj));
                };

            base_exporters_table[typeof(ulong)] =
                delegate (object obj, JsonWriter writer)
                {
                    writer.Write((ulong)obj);
                };

            base_exporters_table[typeof(DateTimeOffset)] =
                delegate (object obj, JsonWriter writer)
                {
                    writer.Write(((DateTimeOffset)obj).ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz", datetime_format));
                };



        }

        private static void RegisterCustomExporters()
        {

            //#region add for Optional<T>

            ////short
            //custom_exporters_table[typeof(Optional<short>)] =
            // delegate (object obj, JsonWriter writer)
            // {
            //     Optional<short> optional = (Optional<short>)obj;
            //     if (optional.HasValue())
            //     {
            //         writer.Write(optional.GetValue());
            //     }
            //     else
            //     {
            //         writer.Write(null);
            //     }
            // };

            ////unshort
            //custom_exporters_table[typeof(Optional<ushort>)] =
            //delegate (object obj, JsonWriter writer)
            //{
            //    Optional<ushort> optional = (Optional<ushort>)obj;
            //    if (optional.HasValue())
            //    {
            //        writer.Write(optional.GetValue());
            //    }
            //    else
            //    {
            //        writer.Write(null);
            //    }
            //};

            ////int
            //custom_exporters_table[typeof(Optional<int>)] =
            //  delegate (object obj, JsonWriter writer)
            //  {
            //      Optional<int> optional = (Optional<int>)obj;
            //      if (optional.HasValue())
            //      {
            //          writer.Write(optional.GetValue());
            //      }
            //      else
            //      {
            //          writer.Write(null);
            //      }
            //  };

            ////unint
            //custom_exporters_table[typeof(Optional<uint>)] =
            //  delegate (object obj, JsonWriter writer)
            //  {
            //      Optional<uint> optional = (Optional<uint>)obj;
            //      if (optional.HasValue())
            //      {
            //          writer.Write(optional.GetValue());
            //      }
            //      else
            //      {
            //          writer.Write(null);
            //      }
            //  };

            ////double
            //custom_exporters_table[typeof(Optional<double>)] =
            // delegate (object obj, JsonWriter writer)
            // {
            //     Optional<double> optional = (Optional<double>)obj;
            //     if (optional.HasValue())
            //     {
            //         writer.Write(optional.GetValue());
            //     }
            //     else
            //     {
            //         writer.Write(null);
            //     }
            // };

            ////float
            //custom_exporters_table[typeof(Optional<float>)] =
            // delegate (object obj, JsonWriter writer)
            // {
            //     Optional<float> optional = (Optional<float>)obj;
            //     if (optional.HasValue())
            //     {
            //         writer.Write(optional.GetValue());
            //     }
            //     else
            //     {
            //         writer.Write(null);
            //     }
            // };

            ////long
            //custom_exporters_table[typeof(Optional<long>)] =
            //delegate (object obj, JsonWriter writer)
            //{
            //    Optional<long> optional = (Optional<long>)obj;
            //    if (optional.HasValue())
            //    {
            //        writer.Write(optional.GetValue());
            //    }
            //    else
            //    {
            //        writer.Write(null);
            //    }
            //};

            ////unlong
            //custom_exporters_table[typeof(Optional<ulong>)] =
            //    delegate (object obj, JsonWriter writer)
            //{
            //    Optional<ulong> optional = (Optional<ulong>)obj;
            //    if (optional.HasValue())
            //    {
            //        writer.Write(optional.GetValue());
            //    }
            //    else
            //    {
            //        writer.Write(null);
            //    }
            //};

            ////bool
            //custom_exporters_table[typeof(Optional<bool>)] =
            //    delegate (object obj, JsonWriter writer)
            //    {
            //        Optional<bool> optional = (Optional<bool>)obj;
            //        if (optional.HasValue())
            //        {
            //            writer.Write(optional.GetValue());
            //        }
            //        else
            //        {
            //            writer.Write(null);
            //        }
            //    };

            ////string
            //custom_exporters_table[typeof(Optional<string>)] =
            //    delegate (object obj, JsonWriter writer)
            //    {
            //        Optional<string> optional = (Optional<string>)obj;
            //        if (optional.HasValue())
            //        {
            //            writer.Write(optional.GetValue());
            //        }
            //        else
            //        {
            //            writer.Write(null);
            //        }
            //    };


            ////NLP_AGGRESSIVENESS
            //custom_exporters_table[typeof(Optional<NLP_AGGRESSIVENESS>)] =
            //    delegate (object obj, JsonWriter writer)
            //    {
            //        Optional<NLP_AGGRESSIVENESS> optional = (Optional<NLP_AGGRESSIVENESS>)obj;
            //        if (optional.HasValue())
            //        {
            //            writer.Write((int)optional.GetValue());
            //        }
            //        else
            //        {
            //            writer.Write(null);
            //        }
            //    };

            ////CLIENT_ROLE_TYPE
            //custom_exporters_table[typeof(Optional<CLIENT_ROLE_TYPE>)] =
            //    delegate (object obj, JsonWriter writer)
            //    {
            //        Optional<CLIENT_ROLE_TYPE> optional = (Optional<CLIENT_ROLE_TYPE>)obj;
            //        if (optional.HasValue())
            //        {
            //            writer.Write((int)optional.GetValue());
            //        }
            //        else
            //        {
            //            writer.Write(null);
            //        }
            //    };

            ////AUDIENCE_LATENCY_LEVEL_TYPE
            //custom_exporters_table[typeof(Optional<AUDIENCE_LATENCY_LEVEL_TYPE>)] =
            //    delegate (object obj, JsonWriter writer)
            //    {
            //        Optional<AUDIENCE_LATENCY_LEVEL_TYPE> optional = (Optional<AUDIENCE_LATENCY_LEVEL_TYPE>)obj;
            //        if (optional.HasValue())
            //        {
            //            writer.Write((int)optional.GetValue());
            //        }
            //        else
            //        {
            //            writer.Write(null);
            //        }
            //    };

            ////VIDEO_STREAM_TYPE
            //custom_exporters_table[typeof(Optional<VIDEO_STREAM_TYPE>)] =
            //    delegate (object obj, JsonWriter writer)
            //    {
            //        Optional<VIDEO_STREAM_TYPE> optional = (Optional<VIDEO_STREAM_TYPE>)obj;
            //        if (optional.HasValue())
            //        {
            //            writer.Write((int)optional.GetValue());
            //        }
            //        else
            //        {
            //            writer.Write(null);
            //        }
            //    };

            ////CHANNEL_PROFILE_TYPE
            //custom_exporters_table[typeof(Optional<CHANNEL_PROFILE_TYPE>)] =
            //    delegate (object obj, JsonWriter writer)
            //    {
            //        Optional<CHANNEL_PROFILE_TYPE> optional = (Optional<CHANNEL_PROFILE_TYPE>)obj;
            //        if (optional.HasValue())
            //        {
            //            writer.Write((int)optional.GetValue());
            //        }
            //        else
            //        {
            //            writer.Write(null);
            //        }
            //    };

            ////THREAD_PRIORITY_TYPE
            //custom_exporters_table[typeof(Optional<THREAD_PRIORITY_TYPE>)] =
            //  delegate (object obj, JsonWriter writer)
            //  {
            //      Optional<THREAD_PRIORITY_TYPE> optional = (Optional<THREAD_PRIORITY_TYPE>)obj;
            //      if (optional.HasValue())
            //      {
            //          writer.Write((int)optional.GetValue());
            //      }
            //      else
            //      {
            //          writer.Write(null);
            //      }
            //  };

            //#endregion
        }

        private static void RegisterBaseImporters()
        {
            ImporterFunc importer;

            importer = delegate (object input)
            {
                return Convert.ToByte((int)input);
            };
            RegisterImporter(base_importers_table, typeof(int),
                              typeof(byte), importer);

            importer = delegate (object input)
            {
                return Convert.ToUInt64((int)input);
            };
            RegisterImporter(base_importers_table, typeof(int),
                              typeof(ulong), importer);

            importer = delegate (object input)
            {
                return Convert.ToInt64((int)input);
            };
            RegisterImporter(base_importers_table, typeof(int),
                              typeof(long), importer);

            importer = delegate (object input)
            {
                return Convert.ToUInt32((int)input);
            };
            RegisterImporter(base_importers_table, typeof(int),
                              typeof(uint), importer);

            importer = delegate (object input)
            {
                return Convert.ToSByte((int)input);
            };
            RegisterImporter(base_importers_table, typeof(int),
                              typeof(sbyte), importer);

            importer = delegate (object input)
            {
                return Convert.ToInt16((int)input);
            };
            RegisterImporter(base_importers_table, typeof(int),
                              typeof(short), importer);

            importer = delegate (object input)
            {
                return Convert.ToUInt16((int)input);
            };
            RegisterImporter(base_importers_table, typeof(int),
                              typeof(ushort), importer);

            importer = delegate (object input)
            {
                return Convert.ToUInt32((int)input);
            };
            RegisterImporter(base_importers_table, typeof(int),
                              typeof(uint), importer);

            importer = delegate (object input)
            {
                return Convert.ToSingle((int)input);
            };
            RegisterImporter(base_importers_table, typeof(int),
                              typeof(float), importer);

            importer = delegate (object input)
            {
                return Convert.ToDouble((int)input);
            };
            RegisterImporter(base_importers_table, typeof(int),
                              typeof(double), importer);


            importer = delegate (object input)
            {
                return Convert.ToInt64((uint)input);
            };
            RegisterImporter(base_importers_table, typeof(uint),
                              typeof(long), importer);


            importer = delegate (object input)
            {
                return Convert.ToUInt64((uint)input);
            };
            RegisterImporter(base_importers_table, typeof(uint),
                              typeof(ulong), importer);


            importer = delegate (object input)
            {
                return Convert.ToDecimal((double)input);
            };
            RegisterImporter(base_importers_table, typeof(double),
                              typeof(decimal), importer);

            importer = delegate (object input)
            {
                return Convert.ToSingle((double)input);
            };
            RegisterImporter(base_importers_table, typeof(double),
                typeof(float), importer);

            importer = delegate (object input)
            {
                return Convert.ToUInt32((long)input);
            };
            RegisterImporter(base_importers_table, typeof(long),
                              typeof(uint), importer);

            importer = delegate (object input)
            {
                return Convert.ToUInt64((long)input);
            };
            RegisterImporter(base_importers_table, typeof(long),
                              typeof(ulong), importer);

            importer = delegate (object input)
            {
                return Convert.ToChar((string)input);
            };
            RegisterImporter(base_importers_table, typeof(string),
                              typeof(char), importer);

            importer = delegate (object input)
            {
                return Convert.ToDateTime((string)input, datetime_format);
            };
            RegisterImporter(base_importers_table, typeof(string),
                              typeof(DateTime), importer);

            importer = delegate (object input)
            {
                return DateTimeOffset.Parse((string)input, datetime_format);
            };
            RegisterImporter(base_importers_table, typeof(string),
                typeof(DateTimeOffset), importer);

        }


        private static void RegisterCustomImporters()
        {

            ImporterFunc importer;

            #region add for Optional<T>
            //double
            importer = delegate (object input)
            {
                Optional<double> ret = new Optional<double>();
                ret.SetValue(Convert.ToDouble(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
                typeof(Optional<double>), typeof(double), importer);

            importer = delegate (object input)
            {
                Optional<double> ret = new Optional<double>();
                ret.SetValue(Convert.ToInt32(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<double>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<double> ret = new Optional<double>();
                ret.SetValue(Convert.ToInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<double>), typeof(long), importer);


            //float
            importer = delegate (object input)
            {
                Optional<float> ret = new Optional<float>();
                ret.SetValue((float)Convert.ToDouble(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<float>), typeof(double), importer);

            importer = delegate (object input)
            {
                Optional<float> ret = new Optional<float>();
                ret.SetValue((float)Convert.ToInt32(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<float>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<float> ret = new Optional<float>();
                ret.SetValue((float)Convert.ToInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<float>), typeof(long), importer);

            //short
            importer = delegate (object input)
            {
                Optional<short> ret = new Optional<short>();
                ret.SetValue((short)Convert.ToInt32(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<short>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<short> ret = new Optional<short>();
                ret.SetValue((short)Convert.ToUInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<short>), typeof(long), importer);

            importer = delegate (object input)
            {
                Optional<short> ret = new Optional<short>();
                ret.SetValue((short)Convert.ToDouble(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<short>), typeof(double), importer);

            //ushort
            importer = delegate (object input)
            {
                Optional<ushort> ret = new Optional<ushort>();
                ret.SetValue((ushort)Convert.ToInt32(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<ushort>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<ushort> ret = new Optional<ushort>();
                ret.SetValue((ushort)Convert.ToUInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<ushort>), typeof(long), importer);

            importer = delegate (object input)
            {
                Optional<ushort> ret = new Optional<ushort>();
                ret.SetValue((ushort)Convert.ToDouble(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<ushort>), typeof(double), importer);

            //int
            importer = delegate (object input)
            {
                Optional<int> ret = new Optional<int>();
                ret.SetValue(Convert.ToInt32(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<int>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<int> ret = new Optional<int>();
                ret.SetValue((int)Convert.ToDouble(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<int>), typeof(double), importer);

            importer = delegate (object input)
            {
                Optional<int> ret = new Optional<int>();
                ret.SetValue((int)Convert.ToUInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<int>), typeof(long), importer);

            //uint
            importer = delegate (object input)
            {
                Optional<uint> ret = new Optional<uint>();
                ret.SetValue((uint)Convert.ToInt32(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<uint>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<uint> ret = new Optional<uint>();
                ret.SetValue((uint)Convert.ToDouble(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<uint>), typeof(double), importer);

            importer = delegate (object input)
            {
                Optional<uint> ret = new Optional<uint>();
                ret.SetValue((uint)Convert.ToUInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<uint>), typeof(long), importer);

            //long
            importer = delegate (object input)
            {
                Optional<long> ret = new Optional<long>();
                ret.SetValue((long)Convert.ToInt32(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<long>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<long> ret = new Optional<long>();
                ret.SetValue((long)Convert.ToDouble(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<long>), typeof(double), importer);

            importer = delegate (object input)
            {
                Optional<long> ret = new Optional<long>();
                ret.SetValue((long)Convert.ToUInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<long>), typeof(long), importer);

            //ulong
            importer = delegate (object input)
            {
                Optional<ulong> ret = new Optional<ulong>();
                ret.SetValue((ulong)Convert.ToInt32(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<ulong>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<ulong> ret = new Optional<ulong>();
                ret.SetValue((ulong)Convert.ToDouble(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<ulong>), typeof(double), importer);

            importer = delegate (object input)
            {
                Optional<ulong> ret = new Optional<ulong>();
                ret.SetValue((ulong)Convert.ToUInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<ulong>), typeof(long), importer);

            //bool
            importer = delegate (object input)
            {
                Optional<bool> ret = new Optional<bool>();
                ret.SetValue((bool)Convert.ToBoolean(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<bool>), typeof(bool), importer);

            //string
            importer = delegate (object input)
            {
                Optional<string> ret = new Optional<string>();
                ret.SetValue((string)Convert.ToString(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
               typeof(Optional<string>), typeof(string), importer);

            ////enum NLP_AGGRESSIVENESS
            //importer = delegate (object input)
            //{
            //    Optional<NLP_AGGRESSIVENESS> ret = new Optional<NLP_AGGRESSIVENESS>();
            //    ret.SetValue((NLP_AGGRESSIVENESS)Convert.ToInt16(input));
            //    return ret;
            //};
            //RegisterImporter(custom_importers_table,
            //  typeof(Optional<NLP_AGGRESSIVENESS>), typeof(int), importer);

            //importer = delegate (object input)
            //{
            //    Optional<NLP_AGGRESSIVENESS> ret = new Optional<NLP_AGGRESSIVENESS>();
            //    ret.SetValue((NLP_AGGRESSIVENESS)Convert.ToUInt64(input));
            //    return ret;
            //};
            //RegisterImporter(custom_importers_table,
            //  typeof(Optional<NLP_AGGRESSIVENESS>), typeof(long), importer);

            //enum CLIENT_ROLE_TYPE
            importer = delegate (object input)
            {
                Optional<CLIENT_ROLE_TYPE> ret = new Optional<CLIENT_ROLE_TYPE>();
                ret.SetValue((CLIENT_ROLE_TYPE)Convert.ToInt16(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
              typeof(Optional<CLIENT_ROLE_TYPE>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<CLIENT_ROLE_TYPE> ret = new Optional<CLIENT_ROLE_TYPE>();
                ret.SetValue((CLIENT_ROLE_TYPE)Convert.ToUInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
              typeof(Optional<CLIENT_ROLE_TYPE>), typeof(long), importer);

            //AUDIENCE_LATENCY_LEVEL_TYPE
            importer = delegate (object input)
            {
                Optional<AUDIENCE_LATENCY_LEVEL_TYPE> ret = new Optional<AUDIENCE_LATENCY_LEVEL_TYPE>();
                ret.SetValue((AUDIENCE_LATENCY_LEVEL_TYPE)Convert.ToInt16(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
              typeof(Optional<AUDIENCE_LATENCY_LEVEL_TYPE>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<AUDIENCE_LATENCY_LEVEL_TYPE> ret = new Optional<AUDIENCE_LATENCY_LEVEL_TYPE>();
                ret.SetValue((AUDIENCE_LATENCY_LEVEL_TYPE)Convert.ToUInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
              typeof(Optional<AUDIENCE_LATENCY_LEVEL_TYPE>), typeof(long), importer);

            //VIDEO_STREAM_TYPE
            importer = delegate (object input)
            {
                Optional<VIDEO_STREAM_TYPE> ret = new Optional<VIDEO_STREAM_TYPE>();
                ret.SetValue((VIDEO_STREAM_TYPE)Convert.ToInt16(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
              typeof(Optional<VIDEO_STREAM_TYPE>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<VIDEO_STREAM_TYPE> ret = new Optional<VIDEO_STREAM_TYPE>();
                ret.SetValue((VIDEO_STREAM_TYPE)Convert.ToUInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
              typeof(Optional<VIDEO_STREAM_TYPE>), typeof(long), importer);


            //CHANNEL_PROFILE_TYPE
            importer = delegate (object input)
            {
                Optional<CHANNEL_PROFILE_TYPE> ret = new Optional<CHANNEL_PROFILE_TYPE>();
                ret.SetValue((CHANNEL_PROFILE_TYPE)Convert.ToInt16(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
              typeof(Optional<CHANNEL_PROFILE_TYPE>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<CHANNEL_PROFILE_TYPE> ret = new Optional<CHANNEL_PROFILE_TYPE>();
                ret.SetValue((CHANNEL_PROFILE_TYPE)Convert.ToUInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
              typeof(Optional<CHANNEL_PROFILE_TYPE>), typeof(long), importer);


            //THREAD_PRIORITY_TYPE
            importer = delegate (object input)
            {
                Optional<THREAD_PRIORITY_TYPE> ret = new Optional<THREAD_PRIORITY_TYPE>();
                ret.SetValue((THREAD_PRIORITY_TYPE)Convert.ToInt16(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
              typeof(Optional<THREAD_PRIORITY_TYPE>), typeof(int), importer);

            importer = delegate (object input)
            {
                Optional<THREAD_PRIORITY_TYPE> ret = new Optional<THREAD_PRIORITY_TYPE>();
                ret.SetValue((THREAD_PRIORITY_TYPE)Convert.ToUInt64(input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
              typeof(Optional<THREAD_PRIORITY_TYPE>), typeof(long), importer);

            //CacheStatistics
            importer = delegate (object input)
            {
                Optional<CacheStatistics> ret = new Optional<CacheStatistics>();
                ret.SetValue((CacheStatistics)JsonMapper.ToObject<CacheStatistics>((string)input));
                return ret;
            };
            RegisterImporter(custom_importers_table,
              typeof(Optional<CacheStatistics>), typeof(string), importer);

            #endregion

        }

        private static void RegisterImporter(
            IDictionary<Type, IDictionary<Type, ImporterFunc>> table,
            Type json_type, Type value_type, ImporterFunc importer)
        {
            if (!table.ContainsKey(json_type))
                table.Add(json_type, new Dictionary<Type, ImporterFunc>());

            table[json_type][value_type] = importer;
        }

        public static void WriteValue(object obj, JsonWriter writer,
                                        bool writer_is_private,
                                        int depth)
        {
            if (depth > max_nesting_depth)
                throw new JsonException(
                    String.Format("Max allowed object depth reached while " +
                                   "trying to export from type {0}",
                                   obj.GetType()));

            if (obj == null)
            {
                writer.Write(null);
                return;
            }

            if (obj is OptionalJsonParse)
            {
                ((OptionalJsonParse)obj).ToJson(writer);
                return;
            }


            if (obj is IJsonWrapper)
            {
                if (writer_is_private)
                    writer.TextWriter.Write(((IJsonWrapper)obj).ToJson());
                else
                    ((IJsonWrapper)obj).ToJson(writer);

                return;
            }

            if (obj is String)
            {
                writer.Write((string)obj);
                return;
            }

            if (obj is Double)
            {
                writer.Write((double)obj);
                return;
            }

            if (obj is Single)
            {
                writer.Write((float)obj);
                return;
            }

            if (obj is Int32)
            {
                writer.Write((int)obj);
                return;
            }

            if (obj is Boolean)
            {
                writer.Write((bool)obj);
                return;
            }

            if (obj is Int64)
            {
                writer.Write((long)obj);
                return;
            }

            if (obj is Array)
            {
                writer.WriteArrayStart();

                foreach (object elem in (Array)obj)
                    WriteValue(elem, writer, writer_is_private, depth + 1);

                writer.WriteArrayEnd();

                return;
            }

            if (obj is IList)
            {
                writer.WriteArrayStart();
                foreach (object elem in (IList)obj)
                    WriteValue(elem, writer, writer_is_private, depth + 1);
                writer.WriteArrayEnd();

                return;
            }

            if (obj is IDictionary)
            {
                writer.WriteObjectStart();
                foreach (DictionaryEntry entity in (IDictionary)obj)
                {
                    writer.WritePropertyName((string)entity.Key);
                    WriteValue(entity.Value, writer, writer_is_private,
                                depth + 1);
                }
                writer.WriteObjectEnd();

                return;
            }

            Type obj_type = obj.GetType();

            // See if there's a custom exporter for the object
            if (custom_exporters_table.ContainsKey(obj_type))
            {
                ExporterFunc exporter = custom_exporters_table[obj_type];
                exporter(obj, writer);

                return;
            }

            // If not, maybe there's a base exporter
            if (base_exporters_table.ContainsKey(obj_type))
            {
                ExporterFunc exporter = base_exporters_table[obj_type];
                exporter(obj, writer);

                return;
            }

            // Last option, let's see if it's an enum
            if (obj is Enum)
            {
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

                return;
            }

            // Okay, so it looks like the input should be exported as an
            // object
            AddTypeProperties(obj_type);
            IList<PropertyMetadata> props = type_properties[obj_type];

            writer.WriteObjectStart();
            foreach (PropertyMetadata p_data in props)
            {
                if (p_data.IsField)
                {
                    writer.WritePropertyName(p_data.Info.Name);
                    WriteValue(((FieldInfo)p_data.Info).GetValue(obj),
                                writer, writer_is_private, depth + 1);
                }
                else
                {
                    PropertyInfo p_info = (PropertyInfo)p_data.Info;

                    if (p_info.CanRead)
                    {
                        writer.WritePropertyName(p_data.Info.Name);
                        WriteValue(p_info.GetValue(obj, null),
                                    writer, writer_is_private, depth + 1);
                    }
                }
            }
            writer.WriteObjectEnd();
        }
        #endregion


        public static string ToJson(object obj)
        {
            lock (static_writer_lock)
            {
                static_writer.Reset();

                WriteValue(obj, static_writer, false, 0);

                return static_writer.ToString();
            }
        }

        public static void ToJson(object obj, JsonWriter writer)
        {
            WriteValue(obj, writer, false, 0);
        }

        public static JsonData ToObject(JsonReader reader)
        {
            return (JsonData)ToWrapper(
                delegate { return new JsonData(); }, reader);
        }

        public static JsonData ToObject(TextReader reader)
        {
            JsonReader json_reader = new JsonReader(reader);

            return (JsonData)ToWrapper(
                delegate { return new JsonData(); }, json_reader);
        }

        public static JsonData ToObject(string json)
        {
            return (JsonData)ToWrapper(
                delegate { return new JsonData(); }, json);
        }

        public static T ToObject<T>(JsonReader reader)
        {
            return (T)ReadValue(typeof(T), reader);
        }

        public static T ToObject<T>(TextReader reader)
        {
            JsonReader json_reader = new JsonReader(reader);

            return (T)ReadValue(typeof(T), json_reader);
        }

        public static T ToObject<T>(string json)
        {
            JsonReader reader = new JsonReader(json);

            return (T)ReadValue(typeof(T), reader);
        }

        public static object ToObject(string json, Type ConvertType)
        {
            JsonReader reader = new JsonReader(json);

            return ReadValue(ConvertType, reader);
        }

        public static IJsonWrapper ToWrapper(WrapperFactory factory,
                                              JsonReader reader)
        {
            return ReadValue(factory, reader);
        }

        public static IJsonWrapper ToWrapper(WrapperFactory factory,
                                              string json)
        {
            JsonReader reader = new JsonReader(json);

            return ReadValue(factory, reader);
        }

        public static void RegisterExporter<T>(ExporterFunc<T> exporter)
        {
            ExporterFunc exporter_wrapper =
                delegate (object obj, JsonWriter writer)
                {
                    exporter((T)obj, writer);
                };

            custom_exporters_table[typeof(T)] = exporter_wrapper;
        }

        public static void RegisterImporter<TJson, TValue>(
            ImporterFunc<TJson, TValue> importer)
        {
            ImporterFunc importer_wrapper =
                delegate (object input)
                {
                    return importer((TJson)input);
                };

            RegisterImporter(custom_importers_table, typeof(TJson),
                              typeof(TValue), importer_wrapper);
        }

        public static void UnregisterExporters()
        {
            custom_exporters_table.Clear();
        }

        public static void UnregisterImporters()
        {
            custom_importers_table.Clear();
        }
    }
}
