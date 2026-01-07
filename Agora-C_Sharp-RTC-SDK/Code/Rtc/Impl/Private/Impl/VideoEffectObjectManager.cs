using System.Collections.Generic;

namespace Agora.Rtc
{
    internal class VideoEffectObjectManager
    {
        private static VideoEffectObjectManager _instance;
        private readonly Dictionary<int, IVideoEffectObject> _videoEffectObjects = new Dictionary<int, IVideoEffectObject>();

        private VideoEffectObjectManager() { }

        public static VideoEffectObjectManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VideoEffectObjectManager();
                }
                return _instance;
            }
        }

        public void Add(int objectId, IVideoEffectObject videoEffectObject)
        {
            _videoEffectObjects[objectId] = videoEffectObject;
        }

        public IVideoEffectObject Get(int objectId)
        {
            _videoEffectObjects.TryGetValue(objectId, out var videoEffectObject);
            return videoEffectObject;
        }

        public void Release(int objectId)
        {
            if (_videoEffectObjects.ContainsKey(objectId))
            {
                _videoEffectObjects.Remove(objectId);
            }
        }
    }
}
