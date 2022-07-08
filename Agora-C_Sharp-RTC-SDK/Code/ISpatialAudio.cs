namespace Agora.Rtc
{
    ///
    /// <summary>
    /// This class calculates user positions through the Agora Spatial Audio Server to implement the spatial audio effect.
    /// This class inherits from . Before calling other APIs in this class, you need to call the Initialize method to initialize this class.
    /// </summary>
    ///
    public abstract class ICloudSpatialAudioEngine
    {        
        ///
        /// <summary>
        /// Adds the ICloudSpatialAudioEventHandler event handler.
        /// </summary>
        ///
        /// <param name="eventHandler"> The callback to be added. See ICloudSpatialAudioEventHandler for details.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract void InitEventHandler(ICloudSpatialAudioEventHandler engineEventHandler);
        
        ///
        /// <summary>
        /// Initializes ICloudSpatialAudioEngine .
        /// Before calling other methods of the ICloudSpatialAudioEngine class, you need to call this method to initialize ICloudSpatialAudioEngine.
        /// The SDK supports creating only one ICloudSpatialAudioEngine instance for an app.
        /// </summary>
        ///
        /// <param name="config"> The configuration of ICloudSpatialAudioEngine. See CloudSpatialAudioConfig for details.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// -2: The parameter is invalid.
        /// -7: The SDK is not initialized.
        /// -22: The resource request failed. The app uses too many system resources and fails to allocate any resources.
        /// -101: The App ID is invalid.
        /// </returns>
        ///
        public abstract int Initialize(CloudSpatialAudioConfig config);

        ///
        /// <summary>
        /// Destroys ICloudSpatialAudioEngine .
        /// This method releases all resources under ICloudSpatialAudioEngine. When the user does not need to use the spatial audio effect, you can call this method to release resources for other operations.
        /// After calling this method, you can no longer use any of the APIs under ICloudSpatialAudioEngine or ICloudSpatialAudioEventHandler . To use the spatial audio effect again, you need to wait until the Dispose method execution to complete before calling Initialize to create a new ICloudSpatialAudioEngine.Call this method before the Dispose method under IRtcEngine .
        /// </summary>
        ///
        public abstract void Dispose();

        ///
        /// <summary>
        /// Sets the maximum number of streams that a user can receive in a specified audio reception range.
        /// If the number of receivable streams exceeds the set value, the local user receives the maxCount streams that are closest to the local user. If there are users who belong to the same team as the local user in the room, the local user receives the audio of the teammates first. For example, when maxCount is set to 3, if there are five remote users in the room, two of whom belong to the same team as the local user, and three of whom belong to different teams but are within the audio reception range of the local user, the local user can hear the two teammates and the one user from a different team closest to the local user.
        /// You can call this method either before or after EnterRoom , with the following differences:
        /// If you call this method before EnterRoom, this method takes effect when entering the room.
        /// If you call this method after EnterRoom, this method takes effect immediately and changes the current maximum number of received streams of the local user.
        /// </summary>
        ///
        /// <param name="maxCount"> The maximum number of streams that a user can receive within a specified audio reception range.</param>
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
        /// After the setting is successful, the local user can only hear the remote users within the setting range or belonging to the same team. You can call this method at any time to update the audio reception range.
        /// Agora recommends calling this method before EnterRoom .
        /// </summary>
        ///
        /// <param name="range"> The maximum audio reception range. The unit is meters. The value must be greater than 0.</param>
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
        /// In a game engine, the unit of distance is customized, while in the Agora spatial audio algorithm, distance is measured in meters. By default, the SDK converts the game engine distance per unit to one meter. You can call this method to convert the game engine distance per unit to a specified number of meters.
        /// Agora recommends calling this method before EnterRoom .
        /// </summary>
        ///
        /// <param name="unit"> The number of meters that the game engine distance per unit is equal to. This parameter must be greater than 0.00. For example, setting unit as 2.00 means the game engine distance per unit equals 2 meters.The larger the value is, the faster the sound heard by the local user attenuates when the remote user moves far away from the local user.</param>
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
        /// When this method is called under different classes, the effect is different:
        /// When this method is called under the ICloudSpatialAudioEngine class, the SDK updates the spatial position of the local user to the Agora Spatial Audio Server. The Agora Spatial Audio Server calculates the user's spatial audio effect parameters according to the world coordinates and audio reception range of the local and remote users.
        /// Under the ILocalSpatialAudioEngine class, this method needs to be used with UpdateRemotePosition . The SDK calculates the relative position between the local and remote users according to this method and the parameter settings in UpdateRemotePosition, and then calculates the user's spatial audio effect parameters. 
        /// Call this method after EnterRoom .
        /// If you call this method under the ICloudSpatialAudioEngine class, note the following:
        /// When you call this method multiple times, Agora recommends a call interval of [120,7000) milliseconds; otherwise, the SDK and the Agora Spatial Audio Server lose synchronization.
        /// If the distance between the current spatial position and the last position is less than 0.2 meters or the rotation angle in each direction is less than 15 degrees, the SDK does not update the current spatial position.
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
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        ///
        /// <summary>
        /// Updates the spatial position of the media player.
        /// After a successful update, the local user can hear the change in the spatial position of the media player.
        /// </summary>
        ///
        /// <param name="playerId"> The media player ID, which can be obtained in GetId .</param>
        ///
        /// <param name="positionInfo"> The spatial position of the media player. See RemoteVoicePositionInfo for details.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward);

        public abstract int SetParameters(string @params);

        ///
        /// <summary>
        /// Stops or resumes publishing the local audio stream.
        /// This method does not affect any ongoing audio recording, because it does not disable the audio capture device.
        /// Call this method after JoinChannel [2/2] .
        /// When using the spatial audio effect, if you need to set whether to publish the local audio stream, Agora recommends calling this method instead of the MuteLocalAudioStream method under IRtcEngine .
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop publishing the local audio stream.
        ///  true: Stop publishing the local audio stream.
        ///  false: Publish the local audio stream.</param>
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
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users. Call this method after JoinChannel [2/2] .
        /// When using the spatial audio effect, if you need to set whether to stop subscribing to the audio streams of all remote users, Agora recommends calling this method instead of the MuteAllRemoteAudioStreams method under IRtcEngine .
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio streams of all remote users:
        ///  true: Stop subscribing to the audio streams of all remote users.
        ///  false: Subscribe to the audio streams of all remote users. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteAudioStreams(bool mute);

        ///
        /// <summary>
        /// Enables or disables the calculation of spatial audio effect parameters by the Agora Spatial Audio Server.
        /// Once enabled, users can hear the spatial audio effect of remote users, as well as their spatial position changes.You can call this method either before or after EnterRoom , with the following differences:
        /// If you call this method before EnterRoom, this method takes effect when entering the room.
        /// If you call this method after EnterRoom, this method takes effect immediately.
        /// </summary>
        ///
        /// <param name="enable"> Whether to enable the calculation of spatial audio effect parameters within the audio reception range:
        ///  true: Enable the calculation.
        ///  false: Disable the calculation.</param>
        ///
        /// <param name="applyToTeam"> Whether to enable the calculation of spatial audio effect parameters in the team:
        ///  true: Enable the calculation.
        ///  false: Disable the calculation.
        ///  This parameter only takes effect when the enable parameter is true.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableSpatializer(bool enable, bool applyToTeam);

        ///
        /// <summary>
        /// Sets the team ID.
        /// In the same room, no matter what the audio range mode and audio reception range are, users with the same team ID can hear each other. Whether users with different team IDs can hear each other is determined by the audio range mode and audio reception range.Call this method before EnterRoom . A user can only have one team ID in a room, and the team ID cannot be changed after entering the room.
        /// </summary>
        ///
        /// <param name="teamId"> The team ID. The value must be greater than 0. The default value is 0, which means that the user is not on a team with other users.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetTeamId(int teamId);
  
        ///
        /// <summary>
        /// Sets the audio range mode.
        /// The SDK supports two audio range modes: everyone mode and team mode. The SDK uses everyone mode by default. If you want to change to team mode, call this method.
        /// A user can only use one mode at a time in a room.
        /// You can call this method either before or after EnterRoom , with the following differences:
        /// If you call this method before EnterRoom, this method takes effect when entering the room.
        /// If you call this method after EnterRoom, this method takes effect immediately and changes the current audio range mode.
        /// </summary>
        ///
        /// <param name="rangeMode"> The audio range mode. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioRangeMode(AUDIO_RANGE_MODE_TYPE rangeMode);

        ///
        /// <summary>
        /// Enters a room.
        /// The spatial audio effect does not take effect until you enter a room. After you call this method, the SDK triggers the OnConnectionStateChange callback.
        /// Call this method after JoinChannel [2/2] .
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter must be the same as the user ID passed in when the user joined the channel.</param>
        ///
        /// <param name="token"> The RTM token for authentication. You can generate the RTM token in the following ways:
        ///  Use to generate a temporary token.
        ///  Deploy your own server for generating tokens. 
        ///  The uid or userAccount for generating the RTM token is the combination of the roomName and uid set in EnterRoom . For example, if roomName is test and uid is 123, the uid or userAccount filled in when generating the RTM token is test123.</param>
        ///
        /// <param name="roomName"> The room name. This parameter must be the same as the channel name filled in when you join the channel.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnterRoom(string token, string roomName, uint uid);

        ///
        /// <summary>
        /// Exits the room.
        /// After the user exits the room, the spatial audio effect disappears immediately.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ExitRoom();

        ///
        /// <summary>
        /// Gets the information of teammates.
        /// After calling setTeamId to set the team ID and calling EnterRoom to enter the room, you can call this method to get the information of remote users in the same team (teammates).
        /// </summary>
        ///
        /// <param name="uids"> Output parameter. The user IDs of teammates.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetTeammates(ref uint[] uids, ref int userCount);

        ///
        /// <summary>
        /// Renews the RTM token.
        /// An RTM token is valid for 24 hours. When the SDK triggers the OnTokenWillExpire callback, the application should get a new RTM token and then call this method to pass in the new token; otherwise, the SDK cannot connect to the Agora Spatial Audio Server.
        /// </summary>
        ///
        /// <param name="token"> The RTM token for authentication. You can generate the RTM token in the following ways:
        ///  Use to generate a temporary token.
        ///  Deploy your own server for generating tokens. 
        ///  The uid or userAccount for generating the RTM token is the combination of the roomName and uid set in EnterRoom . For example, if roomName is test and uid is 123, the uid or userAccount filled in when generating the RTM token is test123.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RenewToken(string token);
    }

    ///
    /// <summary>
    /// This class calculates user positions through the SDK to implement the spatial audio effect.
    /// This class inherits from . Before calling other APIs in this class, you need to call the Initialize method to initialize this class.
    /// </summary>
    ///
    public abstract class ILocalSpatialAudioEngine
    {
        ///
        /// <summary>
        /// Destroys ILocalSpatialAudioEngine .
        /// This method releases all resources under ILocalSpatialAudioEngine. When the user does not need to use the spatial audio effect, you can call this method to release resources for other operations.
        /// After calling this method, you can no longer use any of the APIs under ILocalSpatialAudioEngine. To use the spatial audio effect again, you need to wait until the Dispose method execution to complete before calling Initialize to create a new ILocalSpatialAudioEngine.Call this method before the Dispose method under IRtcEngine .
        /// </summary>
        ///
        public abstract void Dispose();

        ///
        /// <summary>
        /// Initializes ILocalSpatialAudioEngine .
        /// Before calling other methods of the ILocalSpatialAudioEngine class, you need to call this method to initialize ILocalSpatialAudioEngine.
        /// The SDK supports creating only one ILocalSpatialAudioEngine instance for an app.
        /// </summary>
        ///
        /// <param name="config"> The configuration of ILocalSpatialAudioEngine. See LocalSpatialAudioConfig for details.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Initialize();

        ///
        /// <summary>
        /// Sets the maximum number of streams that a user can receive in a specified audio reception range.
        /// If the number of receivable streams exceeds the set value, the local user receives the maxCount streams that are closest to the local user. If there are users who belong to the same team as the local user in the room, the local user receives the audio of the teammates first. For example, when maxCount is set to 3, if there are five remote users in the room, two of whom belong to the same team as the local user, and three of whom belong to different teams but are within the audio reception range of the local user, the local user can hear the two teammates and the one user from a different team closest to the local user.
        /// You can call this method either before or after EnterRoom , with the following differences:
        /// If you call this method before EnterRoom, this method takes effect when entering the room.
        /// If you call this method after EnterRoom, this method takes effect immediately and changes the current maximum number of received streams of the local user.
        /// </summary>
        ///
        /// <param name="maxCount"> The maximum number of streams that a user can receive within a specified audio reception range.</param>
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
        /// After the setting is successful, the local user can only hear the remote users within the setting range or belonging to the same team. You can call this method at any time to update the audio reception range.
        /// Agora recommends calling this method before EnterRoom .
        /// </summary>
        ///
        /// <param name="range"> The maximum audio reception range. The unit is meters. The value must be greater than 0.</param>
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
        /// In a game engine, the unit of distance is customized, while in the Agora spatial audio algorithm, distance is measured in meters. By default, the SDK converts the game engine distance per unit to one meter. You can call this method to convert the game engine distance per unit to a specified number of meters.
        /// Agora recommends calling this method before EnterRoom .
        /// </summary>
        ///
        /// <param name="unit"> The number of meters that the game engine distance per unit is equal to. This parameter must be greater than 0.00. For example, setting unit as 2.00 means the game engine distance per unit equals 2 meters.The larger the value is, the faster the sound heard by the local user attenuates when the remote user moves far away from the local user.</param>
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
        /// When this method is called under different classes, the effect is different:
        /// When this method is called under the ICloudSpatialAudioEngine class, the SDK updates the spatial position of the local user to the Agora Spatial Audio Server. The Agora Spatial Audio Server calculates the user's spatial audio effect parameters according to the world coordinates and audio reception range of the local and remote users.
        /// Under the ILocalSpatialAudioEngine class, this method needs to be used with UpdateRemotePosition . The SDK calculates the relative position between the local and remote users according to this method and the parameter settings in UpdateRemotePosition, and then calculates the user's spatial audio effect parameters. 
        /// Call this method after EnterRoom .
        /// If you call this method under the ICloudSpatialAudioEngine class, note the following:
        /// When you call this method multiple times, Agora recommends a call interval of [120,7000) milliseconds; otherwise, the SDK and the Agora Spatial Audio Server lose synchronization.
        /// If the distance between the current spatial position and the last position is less than 0.2 meters or the rotation angle in each direction is less than 15 degrees, the SDK does not update the current spatial position.
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
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        ///
        /// <summary>
        /// Updates the spatial position of the media player.
        /// After a successful update, the local user can hear the change in the spatial position of the media player.
        /// </summary>
        ///
        /// <param name="playerId"> The media player ID, which can be obtained in GetId .</param>
        ///
        /// <param name="positionInfo"> The spatial position of the media player. See RemoteVoicePositionInfo for details.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward);

        public abstract int SetParameters(string @params);

        ///
        /// <summary>
        /// Stops or resumes publishing the local audio stream.
        /// This method does not affect any ongoing audio recording, because it does not disable the audio capture device.
        /// Call this method after JoinChannel [2/2] .
        /// When using the spatial audio effect, if you need to set whether to publish the local audio stream, Agora recommends calling this method instead of the MuteLocalAudioStream method under IRtcEngine .
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop publishing the local audio stream.
        ///  true: Stop publishing the local audio stream.
        ///  false: Publish the local audio stream.</param>
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
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users. Call this method after JoinChannel [2/2] .
        /// When using the spatial audio effect, if you need to set whether to stop subscribing to the audio streams of all remote users, Agora recommends calling this method instead of the MuteAllRemoteAudioStreams method under IRtcEngine .
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio streams of all remote users:
        ///  true: Stop subscribing to the audio streams of all remote users.
        ///  false: Subscribe to the audio streams of all remote users. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteAudioStreams(bool mute);

        ///
        /// <summary>
        /// Updates the spatial position of the specified remote user.
        /// After successfully calling this method, the SDK calculates the spatial audio parameters based on the relative position of the local and remote user.
        /// Call this method after JoinChannel [2/2] .
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter must be the same as the user ID passed in when the user joined the channel.</param>
        ///
        /// <param name="posInfo"> The spatial position of the remote user. See RemoteVoicePositionInfo for details.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateRemotePosition(uint uid, float[] position, float[] forward);

        public abstract int UpdateRemotePositionEx(uint uid, float[] position, float[] forward, RtcConnection connection);

        ///
        /// <summary>
        /// Removes the spatial position of the specified remote user.
        /// After successfully calling this method, the local user no longer hears the specified remote user.
        /// After leaving the channel, to avoid wasting resources, you can also call this method to delete the spatial position of the specified remote user.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter must be the same as the user ID passed in when the user joined the channel.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RemoveRemotePosition(uint uid);

        public abstract int RemoveRemotePositionEx(uint uid, RtcConnection connection);

        ///
        /// <summary>
        /// Removes the spatial positions of all remote users.
        /// After successfully calling this method, the local user no longer hears any remote users.
        /// After leaving the channel, to avoid wasting resources, you can also call this method to delete the spatial positions of all remote users.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ClearRemotePositions();

        public abstract int ClearRemotePositionsEx(RtcConnection connection);
    }

    ///
    /// <summary>
    /// The class that sends event notifications relating to the spatial audio effect.
    /// </summary>
    ///
    public abstract class ICloudSpatialAudioEventHandler
    {
        ///
        /// <summary>
        /// Occurs when the RTM token expires.
        /// Once the RTM token expires, the SDK triggers this callback to notify the app to renew the RTM token.
        /// When you receive this callback, you need to generate a new token on your server and call RenewToken to pass the new token to the SDK.
        /// </summary>
        ///
        public virtual void OnTokenWillExpire() {}
  
        ///
        /// <summary>
        /// Occurs when the connection state between the SDK and the Agora Spatial Audio Server changes.
        /// When the connection state between the SDK and the Agora Spatial Audio Server changes, the SDK triggers this callback to inform the user of the current connection state and the reason for the change.
        /// </summary>
        ///
        /// <param name="state"> The connection state between the SDK and the Agora Spatial Audio Server. </param>
        ///
        /// <param name="reason"> The reason for the change in the connection state between the SDK and the Agora Spatial Audio Server. </param>
        ///
        public virtual void OnConnectionStateChange(SAE_CONNECTION_STATE_TYPE state, SAE_CONNECTION_CHANGED_REASON_TYPE reason) {}

        ///
        /// <summary>
        /// Occurs when the user leaves the current team.
        /// When a remote user in the current team calls ExitRoom to leave the current room, the local user receives this callback.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user who leaves the current team.</param>
        ///
        public virtual void OnTeammateLeft(uint uid) {}

        ///
        /// <summary>
        /// Occurs when the user joins the current team.
        /// When a remote user with the same team ID calls EnterRoom to enter the current room, the local user receives this callback.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user who joins the current team.</param>
        ///
        public virtual void OnTeammateJoined(uint uid) {}
    }
}