//  AudioEffectManager.cs
//
//  Created by Yiqing Huang on June 2, 2021.
//  Modified by Yiqing Huang on June 8, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    [Obsolete(ObsoleteMethodWarning.IAudioEffectManagerWarning, false)]
    public abstract class IAudioEffectManager
    {
        [Obsolete(ObsoleteMethodWarning.GetEffectsVolumeWarning, false)]
        public abstract double GetEffectsVolume();

        [Obsolete(ObsoleteMethodWarning.SetEffectsVolumeWarning, false)]
        public abstract int SetEffectsVolume(int volume);

        [Obsolete(ObsoleteMethodWarning.PlayEffectWarning, false)]
        public abstract int PlayEffect(int soundId, string filePath, int loopCount, double pitch = 1.0,
            double pan = 0.0, int gain = 100, bool publish = false);

        [Obsolete(ObsoleteMethodWarning.StopEffectWarning, false)]
        public abstract int StopEffect(int soundId);

        [Obsolete(ObsoleteMethodWarning.StopAllEffectsWarning, false)]
        public abstract int StopAllEffects();

        [Obsolete(ObsoleteMethodWarning.PreloadEffectWarning, false)]
        public abstract int PreloadEffect(int soundId, string filePath);

        [Obsolete(ObsoleteMethodWarning.UnloadEffectWarning, false)]
        public abstract int UnloadEffect(int soundId);

        [Obsolete(ObsoleteMethodWarning.PauseEffectWarning, false)]
        public abstract int PauseEffect(int soundId);

        [Obsolete(ObsoleteMethodWarning.PauseAllEffectsWarning, false)]
        public abstract int PauseAllEffects();

        [Obsolete(ObsoleteMethodWarning.ResumeEffectWarning, false)]
        public abstract int ResumeEffect(int soundId);

        [Obsolete(ObsoleteMethodWarning.ResumeAllEffectsWarning, false)]
        public abstract int ResumeAllEffects();

        [Obsolete(ObsoleteMethodWarning.SetRemoteVoicePositionWarning, false)]
        public abstract int SetRemoteVoicePosition(uint uid, double pan, double gain);

        [Obsolete(ObsoleteMethodWarning.SetLocalVoicePitchWarning, false)]
        public abstract int SetLocalVoicePitch(double pitch);
    }

    [Obsolete]
    public sealed class AudioEffectManager : IAudioEffectManager
    {
        private bool _disposed;
        private AgoraRtcEngine _agoraRtcEngine;
        
        internal void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
            }

            _agoraRtcEngine = null;
            _disposed = true;
        }

        internal AudioEffectManager(AgoraRtcEngine agoraRtcEngine)
        {
            _agoraRtcEngine = agoraRtcEngine;
        }
        
        [Obsolete(ObsoleteMethodWarning.GetEffectsVolumeWarning, false)]
        public override double GetEffectsVolume()
        {
            return _agoraRtcEngine.GetEffectsVolume();
        }

        [Obsolete(ObsoleteMethodWarning.SetEffectsVolumeWarning, false)]
        public override int SetEffectsVolume(int volume)
        {
            return _agoraRtcEngine.SetEffectsVolume(volume);
        }

        [Obsolete(ObsoleteMethodWarning.PlayEffectWarning, false)]
        public override int PlayEffect(int soundId, string filePath, int loopCount, double pitch = 1.0,
            double pan = 0.0, int gain = 100, bool publish = false)
        {
            return _agoraRtcEngine.PlayEffect(soundId, filePath, loopCount, pitch, pan, gain, publish);
        }

        [Obsolete(ObsoleteMethodWarning.StopEffectWarning, false)]
        public override int StopEffect(int soundId)
        {
            return _agoraRtcEngine.StopEffect(soundId);
        }

        [Obsolete(ObsoleteMethodWarning.StopAllEffectsWarning, false)]
        public override int StopAllEffects()
        {
            return _agoraRtcEngine.StopAllEffects();
        }

        [Obsolete(ObsoleteMethodWarning.PreloadEffectWarning, false)]
        public override int PreloadEffect(int soundId, string filePath)
        {
            return _agoraRtcEngine.PreloadEffect(soundId, filePath);
        }

        [Obsolete(ObsoleteMethodWarning.UnloadEffectWarning, false)]
        public override int UnloadEffect(int soundId)
        {
            return _agoraRtcEngine.UnloadEffect(soundId);
        }

        [Obsolete(ObsoleteMethodWarning.PauseEffectWarning, false)]
        public override int PauseEffect(int soundId)
        {
            return _agoraRtcEngine.PauseEffect(soundId);
        }

        [Obsolete(ObsoleteMethodWarning.PauseAllEffectsWarning, false)]
        public override int PauseAllEffects()
        {
            return _agoraRtcEngine.PauseAllEffects();
        }

        [Obsolete(ObsoleteMethodWarning.ResumeEffectWarning, false)]
        public override int ResumeEffect(int soundId)
        {
            return _agoraRtcEngine.ResumeEffect(soundId);
        }

        [Obsolete(ObsoleteMethodWarning.ResumeAllEffectsWarning, false)]
        public override int ResumeAllEffects()
        {
            return _agoraRtcEngine.ResumeAllEffects();
        }

        [Obsolete(ObsoleteMethodWarning.SetRemoteVoicePositionWarning, false)]
        public override int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            return _agoraRtcEngine.SetRemoteVoicePosition(uid, pan, gain);
        }

        [Obsolete(ObsoleteMethodWarning.SetLocalVoicePitchWarning, false)]
        public override int SetLocalVoicePitch(double pitch)
        {
            return _agoraRtcEngine.SetLocalVoicePitch(pitch);
        }
        
        ~AudioEffectManager()
        {
            Dispose(false);
        }
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}