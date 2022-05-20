using System;
using System.Collections;
using agora.rtc.LitJson;

namespace agora.rtc
{
    using int64_t = Int64;
    using view_t = UInt64;
    using uint64_t = UInt64;


    internal class AudioFrameWithoutBuffer
    {
        public AudioFrameWithoutBuffer()
        {
        }

        public AudioFrameWithoutBuffer(AUDIO_FRAME_TYPE type, int samples, BYTES_PER_SAMPLE bytesPerSample, int channels,
            int samplesPerSec, long renderTimeMs, int avsync_type)
        {
            this.type = type;
            this.samples = samples;
            this.bytesPerSample = bytesPerSample;
            this.channels = channels;
            this.samplesPerSec = samplesPerSec;
            this.renderTimeMs = renderTimeMs;
            this.avsync_type = avsync_type;
        }

        /** The type of the audio frame. See #AUDIO_FRAME_TYPE
		 */
        public AUDIO_FRAME_TYPE type { set; get; }

        /** The number of samples per channel in the audio frame.
		 */
        public int samples { set; get; } //number of samples for each channel in this frame

        /**The number of bytes per audio sample, which is usually 16-bit (2-byte).
		 */
        public BYTES_PER_SAMPLE bytesPerSample { set; get; } //number of bytes per sample: 2 for PCM16

        /** The number of audio channels.
		 - 1: Mono
		 - 2: Stereo (the data is interleaved)
		 */
        public int channels { set; get; } //number of channels (data are interleaved if stereo)

        /** The sample rate.
		 */
        public int samplesPerSec { set; get; } //sampling rate

        /** The timestamp of the external audio frame. You can use this parameter for the following purposes:
		 - Restore the order of the captured audio frame.
		 - Synchronize audio and video frames in video-related scenarios, including where external video sources are used.
		 */
        public long renderTimeMs { set; get; }

        /** Reserved parameter.
		 */
        public int avsync_type { set; get; }
    }

    public struct VideoFrameBufferConfig
    {
        public VIDEO_SOURCE_TYPE type;
        public uint id;
        public string key;
    }


    internal enum IRIS_VIDEO_PROCESS_ERR
    {
        ERR_OK = 0,
        ERR_NULL_POINTER = 1,
        ERR_SIZE_NOT_MATCHING = 2,
        ERR_BUFFER_EMPTY = 5,
    };


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

        IEnumerator  IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
