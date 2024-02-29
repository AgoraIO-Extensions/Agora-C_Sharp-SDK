namespace Agora.Rtc
{
    #region terra IAgoraMediaEngine.h
    ///
    /// <summary>
    /// The channel mode.
    /// </summary>
    ///
    public enum AUDIO_MIXING_DUAL_MONO_MODE
    {
        ///
        /// <summary>
        /// 0: Original mode.
        /// </summary>
        ///
        AUDIO_MIXING_DUAL_MONO_AUTO = 0,

        ///
        /// <summary>
        /// 1: Left channel mode. This mode replaces the audio of the right channel with the audio of the left channel, which means the user can only hear the audio of the left channel.
        /// </summary>
        ///
        AUDIO_MIXING_DUAL_MONO_L = 1,

        ///
        /// <summary>
        /// 2: Right channel mode. This mode replaces the audio of the left channel with the audio of the right channel, which means the user can only hear the audio of the right channel.
        /// </summary>
        ///
        AUDIO_MIXING_DUAL_MONO_R = 2,

        ///
        /// <summary>
        /// 3: Mixed channel mode. This mode mixes the audio of the left channel and the right channel, which means the user can hear the audio of the left channel and the right channel at the same time.
        /// </summary>
        ///
        AUDIO_MIXING_DUAL_MONO_MIX = 3,
    }

    #endregion terra IAgoraMediaEngine.h
}