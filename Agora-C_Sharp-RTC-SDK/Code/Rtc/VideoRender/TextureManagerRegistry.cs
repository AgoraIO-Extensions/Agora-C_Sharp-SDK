#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS

using System.Collections.Generic;
using UnityEngine;

namespace Agora.Rtc
{
    /// <summary>
    /// Global registry for TextureManager instances
    /// Allows updating connection info from callbacks like OnLocalVideoStats
    /// </summary>
    public static class TextureManagerRegistry
    {
        private static Dictionary<string, TextureManager> _registry = new Dictionary<string, TextureManager>();

        /// <summary>
        /// Generate a unique key for TextureManager lookup
        /// </summary>
        private static string GenerateKey(uint uid, string channelId, VIDEO_SOURCE_TYPE sourceType)
        {
            return $"{uid}_{channelId}_{sourceType}";
        }

        /// <summary>
        /// Register a TextureManager instance
        /// </summary>
        public static void Register(uint uid, string channelId, VIDEO_SOURCE_TYPE sourceType, TextureManager textureManager)
        {
            string key = GenerateKey(uid, channelId, sourceType);

            if (_registry.ContainsKey(key))
            {
                Debug.LogWarning($"TextureManagerRegistry: Replacing existing TextureManager for key: {key}");
            }

            _registry[key] = textureManager;
            Debug.Log($"TextureManagerRegistry: Registered TextureManager - Key: {key}");
        }

        /// <summary>
        /// Unregister a TextureManager instance
        /// </summary>
        public static void Unregister(uint uid, string channelId, VIDEO_SOURCE_TYPE sourceType)
        {
            string key = GenerateKey(uid, channelId, sourceType);

            if (_registry.Remove(key))
            {
                Debug.Log($"TextureManagerRegistry: Unregistered TextureManager - Key: {key}");
            }
        }

        /// <summary>
        /// Find TextureManager by sourceType (for local video when uid/channelId are unknown)
        /// </summary>
        public static TextureManager FindBySourceType(VIDEO_SOURCE_TYPE sourceType)
        {
            foreach (var kvp in _registry)
            {
                if (kvp.Key.EndsWith($"_{sourceType}"))
                {
                    return kvp.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// Update connection info for matching TextureManager instances
        /// This is called from OnLocalVideoStats callback
        /// </summary>
        public static void UpdateConnectionInfo(uint uid, string channelId, VIDEO_SOURCE_TYPE sourceType)
        {
            // Try exact match first
            string key = GenerateKey(uid, channelId, sourceType);
            if (_registry.TryGetValue(key, out TextureManager exactMatch))
            {
                exactMatch.UpdateConnectionInfo(uid, channelId, sourceType);
                Debug.Log($"TextureManagerRegistry: Updated connection info (exact match) - UID: {uid}, Channel: {channelId}, Source: {sourceType}");
                return;
            }

            // If no exact match, find by sourceType (for cases where initial uid/channelId were 0/"")
            TextureManager manager = FindBySourceType(sourceType);
            if (manager != null)
            {
                manager.UpdateConnectionInfo(uid, channelId, sourceType);

                // Re-register with new key
                Unregister(0, "", sourceType); // Remove old entry
                Register(uid, channelId, sourceType, manager);

                Debug.Log($"TextureManagerRegistry: Updated connection info (by sourceType) - UID: {uid}, Channel: {channelId}, Source: {sourceType}");
            }
            else
            {
                Debug.LogWarning($"TextureManagerRegistry: No TextureManager found for UID: {uid}, Channel: {channelId}, Source: {sourceType}");
            }
        }

        /// <summary>
        /// Clear all registered TextureManagers
        /// </summary>
        public static void Clear()
        {
            _registry.Clear();
            Debug.Log("TextureManagerRegistry: Cleared all registrations");
        }

        /// <summary>
        /// Get count of registered TextureManagers
        /// </summary>
        public static int GetCount()
        {
            return _registry.Count;
        }
    }
}

#endif
