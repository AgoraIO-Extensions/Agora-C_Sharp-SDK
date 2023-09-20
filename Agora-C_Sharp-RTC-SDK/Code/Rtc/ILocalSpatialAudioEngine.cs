namespace Agora.Rtc
{
    ///
    /// <summary>
    /// This class calculates user positions through the SDK to implement the spatial audio effect.
    ///
    /// Before calling other APIs in this class, you need to call the Initialize method to initialize this class.
    /// </summary>
    ///
    public abstract class ILocalSpatialAudioEngine
    {
        ///
        /// @ignore
        ///
        public abstract void Dispose();

#region terra ILocalSpatialAudioEngine

        ///
        /// @ignore
        ///
        public abstract int SetMaxAudioRecvCount(int maxCount);

        ///
        /// @ignore
        ///
        public abstract int SetAudioRecvRange(float range);

        ///
        /// @ignore
        ///
        public abstract int SetDistanceUnit(float unit);

        ///
        /// @ignore
        ///
        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        ///
        /// @ignore
        ///
        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int UpdatePlayerPositionInfo(int playerId, RemoteVoicePositionInfo positionInfo);

        ///
        /// @ignore
        ///
        public abstract int SetParameters(string @params);

        ///
        /// @ignore
        ///
        public abstract int MuteLocalAudioStream(bool mute);

        ///
        /// @ignore
        ///
        public abstract int MuteAllRemoteAudioStreams(bool mute);

        ///
        /// @ignore
        ///
        public abstract int SetZones(SpatialAudioZone[] zones, uint zoneCount);

        ///
        /// @ignore
        ///
        public abstract int SetPlayerAttenuation(int playerId, double attenuation, bool forceSet);

        ///
        /// @ignore
        ///
        public abstract int MuteRemoteAudioStream(uint uid, bool mute);

        ///
        /// <summary>
        /// Initializes ILocalSpatialAudioEngine.
        ///
        /// Before calling other methods of the ILocalSpatialAudioEngine class, you need to call this method to initialize ILocalSpatialAudioEngine.
        /// The SDK supports creating only one ILocalSpatialAudioEngine instance for an app.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Initialize();

        ///
        /// <summary>
        /// Updates the spatial position of the specified remote user.
        ///
        /// After successfully calling this method, the SDK calculates the spatial audio parameters based on the relative position of the local and remote user. Call this method after JoinChannel [2/2].
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter must be the same as the user ID passed in when the user joined the channel. </param>
        ///
        /// <param name="posInfo"> The spatial position of the remote user. See RemoteVoicePositionInfo. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateRemotePosition(uint uid, RemoteVoicePositionInfo posInfo);

        ///
        /// @ignore
        ///
        public abstract int UpdateRemotePositionEx(uint uid, RemoteVoicePositionInfo posInfo, RtcConnection connection);

        ///
        /// <summary>
        /// Removes the spatial position of the specified remote user.
        ///
        /// After successfully calling this method, the local user no longer hears the specified remote user. After leaving the channel, to avoid wasting resources, you can also call this method to delete the spatial position of the specified remote user.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter must be the same as the user ID passed in when the user joined the channel. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RemoveRemotePosition(uint uid);

        ///
        /// @ignore
        ///
        public abstract int RemoveRemotePositionEx(uint uid, RtcConnection connection);

        ///
        /// <summary>
        /// Removes the spatial positions of all remote users.
        ///
        /// After successfully calling this method, the local user no longer hears any remote users. After leaving the channel, to avoid wasting resources, you can also call this method to delete the spatial positions of all remote users.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ClearRemotePositions();

        ///
        /// @ignore
        ///
        public abstract int ClearRemotePositionsEx(RtcConnection connection);

        ///
        /// <summary>
        /// Sets the sound attenuation effect for the specified user.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter must be the same as the user ID passed in when the user joined the channel. </param>
        ///
        /// <param name="attenuation">
        /// For the user's sound attenuation coefficient, the value range is [0,1]. The values are as follows:
        /// 0: Broadcast mode, where the volume and timbre are not attenuated with distance, and the volume and timbre heard by local users do not change regardless of distance.
        /// (0,0.5): Weak attenuation mode, that is, the volume and timbre are only weakly attenuated during the propagation process, and the sound can travel farther than the real environment.
        /// 0.5: (Default) simulates the attenuation of the volume in the real environment; the effect is equivalent to not setting the speaker_attenuation parameter.
        /// (0.5,1]: Strong attenuation mode, that is, the volume and timbre attenuate rapidly during the propagation process.
        /// </param>
        ///
        /// <param name="forceSet">
        /// Whether to force the user's sound attenuation effect: true : Force attenuation to set the sound attenuation of the user. At this time, the attenuation coefficient of the sound insulation area set in the audioAttenuation of the SpatialAudioZone does not take effect for the user.
        /// If the sound source and listener are inside and outside the sound isolation area, the sound attenuation effect is determined by the audioAttenuation in SpatialAudioZone.
        /// If the sound source and the listener are in the same sound insulation area or outside the same sound insulation area, the sound attenuation effect is determined by attenuation in this method. false : Do not force attenuation to set the user's sound attenuation effect, as shown in the following two cases.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteAudioAttenuation(uint uid, double attenuation, bool forceSet);
#endregion terra ILocalSpatialAudioEngine
    }
}