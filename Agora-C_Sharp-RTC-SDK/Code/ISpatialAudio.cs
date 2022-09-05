namespace Agora.Rtc
{
    ///
    /// <summary>
    /// This class calculates user positions through the SDK to implement the spatial audio effect.
    /// </summary>
    ///
    public abstract class ILocalSpatialAudioEngine
    {
        ///
        /// <summary>
        /// Destroys ILocalSpatialAudioEngine .
        /// This method releases all resources under ILocalSpatialAudioEngine. When the user does not need to use the spatial audio effect, you can call this method to release resources for other operations.After calling this method, you can no longer use any of the APIs under ILocalSpatialAudioEngine. To use the spatial audio effect again, you need to wait until the Dispose method execution to complete before calling Initialize to create a new ILocalSpatialAudioEngine.Call this method before the Dispose method under IRtcEngine .
        /// </summary>
        ///
        public abstract void Dispose();

        ///
        /// <summary>
        /// Initializes ILocalSpatialAudioEngine .
        /// Before calling other methods of the ILocalSpatialAudioEngine class, you need to call this method to initialize ILocalSpatialAudioEngine.The SDK supports creating only one ILocalSpatialAudioEngine instance for an app.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Initialize();

        ///
        /// <summary>
        /// Sets the maximum number of streams that a user can receive in a specified audio reception range.
        /// If the number of receivable streams exceeds the set value, the local user receives the maxCount streams that are closest to the local user. If there are users who belong to the same team as the local user in the room, the local user receives the audio of the teammates first. For example, when maxCount is set to 3, if there are five remote users in the room, two of whom belong to the same team as the local user, and three of whom belong to different teams but are within the audio reception range of the local user, the local user can hear the two teammates and the one user from a different team closest to the local user.
        /// </summary>
        ///
        /// <param name="maxCount"> The maximum number of streams that a user can receive within a specified audio reception range.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetMaxAudioRecvCount(int maxCount);

        ///
        /// <summary>
        /// Sets the audio reception range of the local user.
        /// After the setting is successful, the local user can only hear the remote users within the setting range or belonging to the same team. You can call this method at any time to update the audio reception range.
        /// </summary>
        ///
        /// <param name="range"> The maximum audio reception range. The unit is meters. The value must be greater than 0.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioRecvRange(float range);

        ///
        /// <summary>
        /// Sets the length (in meters) of the game engine distance per unit.
        /// In a game engine, the unit of distance is customized, while in the Agora spatial audio algorithm, distance is measured in meters. By default, the SDK converts the game engine distance per unit to one meter. You can call this method to convert the game engine distance per unit to a specified number of meters.
        /// </summary>
        ///
        /// <param name="unit"> The number of meters that the game engine distance per unit is equal to. This parameter must be greater than 0.00. For example, setting unit as 2.00 means the game engine distance per unit equals 2 meters.The larger the value is, the faster the sound heard by the local user attenuates when the remote user moves far away from the local user.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDistanceUnit(float unit);

        ///
        /// <summary>
        /// Updates the spatial position of the local user.
        /// Under the ILocalSpatialAudioEngine class, this method needs to be used with UpdateRemotePosition . The SDK calculates the relative position between the local and remote users according to this method and the parameter settings in UpdateRemotePosition, and then calculates the user's spatial audio effect parameters.
        /// </summary>
        ///
        /// <param name="position"> The coordinates in the world coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.</param>
        ///
        /// <param name="axisForward"> The unit vector of the x axis in the coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.</param>
        ///
        /// <param name="axisRight"> The unit vector of the y axis in the coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.</param>
        ///
        /// <param name="axisUp"> The unit vector of the z axis in the coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        ///
        /// @ignore
        ///
        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        ///
        /// <summary>
        /// Updates the spatial position of the media player.
        /// After a successful update, the local user can hear the change in the spatial position of the media player.
        /// </summary>
        ///
        /// <param name="playerId"> The ID of the media player. </param>
        ///
        /// <param name="position"> The coordinates in the world coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.</param>
        ///
        /// <param name="forward"> The unit vector of the x axis in the coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward);

        ///
        /// @ignore
        ///
        public abstract int SetParameters(string @params);

        ///
        /// <summary>
        /// Stops or resumes publishing the local audio stream.
        /// This method does not affect any ongoing audio recording, because it does not disable the audio capture device.Call this method after JoinChannel [2/2] .When using the spatial audio effect, if you need to set whether to publish the local audio stream, Agora recommends calling this method instead of the MuteLocalAudioStream method under IRtcEngine .
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop publishing the local audio stream.true: Stop publishing the local audio stream.false: Publish the local audio stream.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteLocalAudioStream(bool mute);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the audio streams of all remote users.
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users.Call this method after JoinChannel [2/2] .When using the spatial audio effect, if you need to set whether to stop subscribing to the audio streams of all remote users, Agora recommends calling this method instead of the MuteAllRemoteAudioStreams method under IRtcEngine .
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio streams of all remote users:true: Stop subscribing to the audio streams of all remote users.false: Subscribe to the audio streams of all remote users.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteAudioStreams(bool mute);

        ///
        /// <summary>
        /// Updates the spatial position of the specified remote user.
        /// After successfully calling this method, the SDK calculates the spatial audio parameters based on the relative position of the local and remote user.Call this method after the JoinChannel [2/2] method.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter must be the same as the user ID passed in when the user joined the channel.</param>
        ///
        /// <param name="position"> The coordinates in the world coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.</param>
        ///
        /// <param name="forward"> The unit vector of the x axis in the coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateRemotePosition(uint uid, float[] position, float[] forward);

        ///
        /// @ignore
        ///
        public abstract int UpdateRemotePositionEx(uint uid, float[] position, float[] forward, RtcConnection connection);

        ///
        /// <summary>
        /// Removes the spatial position of the specified remote user.
        /// After successfully calling this method, the local user no longer hears the specified remote user.After leaving the channel, to avoid wasting resources, you can also call this method to delete the spatial position of the specified remote user.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter must be the same as the user ID passed in when the user joined the channel.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
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
        /// After successfully calling this method, the local user no longer hears any remote users.After leaving the channel, to avoid wasting resources, you can also call this method to delete the spatial positions of all remote users.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ClearRemotePositions();

        ///
        /// @ignore
        ///
        public abstract int ClearRemotePositionsEx(RtcConnection connection);
    }
}