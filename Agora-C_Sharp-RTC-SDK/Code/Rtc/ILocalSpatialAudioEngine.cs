using System;

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
        /// After successfully calling this method, the SDK calculates the spatial audio parameters based on the relative position of the local and remote user. Call this method after the JoinChannel [1/2] or JoinChannel [2/2] method.
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
        /// After successfully calling this method, the local user no longer hears the specified remote user. After leaving the channel, to avoid wasting computing resources, call this method to delete the spatial position information of the specified remote user. Otherwise, the user's spatial position information will be saved continuously. When the number of remote users exceeds the number of audio streams that can be received as set in SetMaxAudioRecvCount, the system automatically unsubscribes from the audio stream of the user who is furthest away based on relative distance.
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
        /// @ignore
        ///
        public abstract int ClearRemotePositionsEx(RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the maximum number of streams that a user can receive in a specified audio reception range.
        /// 
        /// If the number of receivable streams exceeds the set value, the local user receives the maxCount streams that are closest to the local user.
        /// </summary>
        ///
        /// <param name="maxCount"> The maximum number of streams that a user can receive within a specified audio reception range. The value of this parameter should be ≤ 16, and the default value is 10. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetMaxAudioRecvCount(int maxCount);

        ///
        /// <summary>
        /// Sets the audio reception range of the local user.
        /// 
        /// After the setting is successful, the local user can only hear the remote users within the setting range or belonging to the same team. You can call this method at any time to update the audio reception range.
        /// </summary>
        ///
        /// <param name="range"> The maximum audio reception range. The unit is meters. The value of this parameter must be greater than 0, and the default value is 20. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioRecvRange(float range);

        ///
        /// <summary>
        /// Sets the length (in meters) of the game engine distance per unit.
        /// 
        /// In a game engine, the unit of distance is customized, while in the Agora spatial audio algorithm, distance is measured in meters. By default, the SDK converts the game engine distance per unit to one meter. You can call this method to convert the game engine distance per unit to a specified number of meters.
        /// </summary>
        ///
        /// <param name="unit"> The number of meters that the game engine distance per unit is equal to. The value of this parameter must be greater than 0.00, and the default value is 1.00. For example, setting unit as 2.00 means the game engine distance per unit equals 2 meters. The larger the value is, the faster the sound heard by the local user attenuates when the remote user moves far away from the local user. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDistanceUnit(float unit);

        ///
        /// <summary>
        /// Updates the spatial position of the local user.
        /// 
        /// Under the ILocalSpatialAudioEngine class, this method needs to be used with UpdateRemotePosition. The SDK calculates the relative position between the local and remote users according to this method and the parameter settings in UpdateRemotePosition, and then calculates the user's spatial audio effect parameters.
        /// </summary>
        ///
        /// <param name="position"> The coordinates in the world coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn. And the front, right, and top coordinates correspond to the positive directions of Unity's Vector3 axes (z, x, and y, respectively). </param>
        ///
        /// <param name="axisForward"> The unit vector of the x axis in the coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn. And the front, right, and top coordinates correspond to the positive directions of Unity's Vector3 axes (z, x, and y, respectively). </param>
        ///
        /// <param name="axisRight"> The unit vector of the y axis in the coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn. </param>
        ///
        /// <param name="axisUp"> The unit vector of the z axis in the coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        ///
        /// <summary>
        /// Updates the spatial position of the media player.
        /// 
        /// After a successful update, the local user can hear the change in the spatial position of the media player.
        /// </summary>
        ///
        /// <param name="playerId"> The ID of the media player. </param>
        ///
        /// <param name="positionInfo"> The spatial position of the media player. See RemoteVoicePositionInfo. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdatePlayerPositionInfo(int playerId, RemoteVoicePositionInfo positionInfo);

        ///
        /// @ignore
        ///
        public abstract int SetParameters(string @params);

        ///
        /// <summary>
        /// Stops or resumes publishing the local audio stream.
        /// 
        /// This method does not affect any ongoing audio recording, because it does not disable the audio capture device.
        /// Call this method after the JoinChannel [1/2] or JoinChannel [2/2] method.
        /// When using the spatial audio effect, if you need to set whether to stop subscribing to the audio stream of a specified user, Agora recommends calling this method instead of the MuteLocalAudioStream method in IRtcEngine.
        /// A successful call of this method triggers the OnUserMuteAudio and OnRemoteAudioStateChanged callbacks on the remote client.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop publishing the local audio stream: true : Stop publishing the local audio stream. false : Publish the local audio stream. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteLocalAudioStream(bool mute);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the audio streams of all remote users.
        /// 
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users.
        /// Call this method after the JoinChannel [1/2] or JoinChannel [2/2] method.
        /// When using the spatial audio effect, if you need to set whether to stop subscribing to the audio streams of all remote users, Agora recommends calling this method instead of the MuteAllRemoteAudioStreams method in IRtcEngine.
        /// After calling this method, you need to call UpdateSelfPosition and UpdateRemotePosition to update the spatial location of the local user and the remote user; otherwise, the settings in this method do not take effect.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio streams of all remote users: true : Stop subscribing to the audio streams of all remote users. false : Subscribe to the audio streams of all remote users. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteAudioStreams(bool mute);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the audio stream of a specified user.
        /// 
        /// Call this method after the JoinChannel [1/2] or JoinChannel [2/2] method.
        /// When using the spatial audio effect, if you need to set whether to stop subscribing to the audio stream of a specified user, Agora recommends calling this method instead of the MuteRemoteAudioStream method in IRtcEngine.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter must be the same as the user ID passed in when the user joined the channel. </param>
        ///
        /// <param name="mute"> Whether to subscribe to the specified remote user's audio stream. true : Stop subscribing to the audio stream of the specified user. false : (Default) Subscribe to the audio stream of the specified user. The SDK decides whether to subscribe according to the distance between the local user and the remote user. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRemoteAudioStream(uint uid, bool mute);

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

        ///
        /// <summary>
        /// Sets the sound insulation area.
        /// 
        /// In virtual interactive scenarios, you can use this method to set the sound insulation area and sound attenuation coefficient. When the sound source (which can be the user or the media player) and the listener belong to the inside and outside of the sound insulation area, they can experience the attenuation effect of sound similar to the real environment when it encounters a building partition.
        /// When the sound source and the listener belong to the inside and outside of the sound insulation area, the sound attenuation effect is determined by the sound attenuation coefficient in SpatialAudioZone.
        /// If the user or media player is in the same sound insulation area, it is not affected by SpatialAudioZone, and the sound attenuation effect is determined by the attenuation parameter in SetPlayerAttenuation or SetRemoteAudioAttenuation. If you do not call SetPlayerAttenuation or SetRemoteAudioAttenuation, the default sound attenuation coefficient of the SDK is 0.5, which simulates the attenuation of the sound in the real environment.
        /// If the sound source and the receiver belong to two sound insulation areas, the receiver cannot hear the sound source. If this method is called multiple times, the last sound insulation area set takes effect.
        /// </summary>
        ///
        /// <param name="zones"> Sound insulation area settings. See SpatialAudioZone. When you set this parameter to NULL, it means clearing all sound insulation zones. On the Windows platform, it is necessary to ensure that the number of members in the zones array is equal to the value of zoneCount; otherwise, it may cause a crash. </param>
        ///
        /// <param name="zoneCount"> The number of sound insulation areas. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetZones(SpatialAudioZone[] zones, uint zoneCount);

        ///
        /// <summary>
        /// Sets the sound attenuation properties of the media player.
        /// </summary>
        ///
        /// <param name="playerId"> The ID of the media player. </param>
        ///
        /// <param name="attenuation">
        /// The sound attenuation coefficient of the remote user or media player. The value range is [0,1]. The values are as follows:
        /// 0: Broadcast mode, where the volume and timbre are not attenuated with distance, and the volume and timbre heard by local users do not change regardless of distance.
        /// (0,0.5): Weak attenuation mode, that is, the volume and timbre are only weakly attenuated during the propagation process, and the sound can travel farther than the real environment.
        /// 0.5: (Default) simulates the attenuation of the volume in the real environment; the effect is equivalent to not setting the speaker_attenuation parameter.
        /// (0.5,1]: Strong attenuation mode, that is, the volume and timbre attenuate rapidly during the propagation process.
        /// </param>
        ///
        /// <param name="forceSet">
        /// Whether to force the sound attenuation effect of the media player: true : Force attenuation to set the attenuation of the media player. At this time, the attenuation coefficient of the sound insulation are set in the audioAttenuation in the SpatialAudioZone does not take effect for the media player. false : Do not force attenuation to set the sound attenuation effect of the media player, as shown in the following two cases.
        /// If the sound source and listener are inside and outside the sound isolation area, the sound attenuation effect is determined by the audioAttenuation in SpatialAudioZone.
        /// If the sound source and the listener are in the same sound insulation area or outside the same sound insulation area, the sound attenuation effect is determined by attenuation in this method.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlayerAttenuation(int playerId, double attenuation, bool forceSet);

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
        #endregion terra ILocalSpatialAudioEngine
    }
}