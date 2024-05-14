using System;
using System.Collections.Generic;
namespace Agora.Rtc
{
    public sealed class VideoFrameMetaInfo : IVideoFrameMetaInfo
    {
        private Dictionary<string, string> _data;

        public VideoFrameMetaInfo(Dictionary<string, string> data)
        {
            this._data = data;
        }

        public override string GetMetaInfoStr(META_INFO_KEY key)
        {
            var stringKey = key.ToString();
            if (_data.ContainsKey(stringKey))
            {
                return _data[stringKey];
            }
            return null;
        }
    }
}

