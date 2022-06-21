namespace Agora.Rtc
{
    #region IAgoraRtcEngineEx
    public class RtcConnection
    {
        public RtcConnection()
        {

        }

        public RtcConnection(string channelId, uint localUid)
        {
            this.channelId = channelId;
            this.localUid = localUid;
        }
        /**
        *  The unique channel name for the AgoraRTC session in the string format. The string
        * length must be less than 64 bytes. Supported character scopes are:
        * - All lowercase English letters: a to z.
        * - All uppercase English letters: A to Z.
        * - All numeric characters: 0 to 9.
        * - The space character.
        * - Punctuation characters and other symbols, including: "!", "#", "$", "%", "&", "(", ")", "+", "-",
        * ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", " {", "}", "|", "~", ",".
        */
        public string channelId { set; get; }
        /**
        * User ID: A 32-bit unsigned integer ranging from 1 to (2^32-1). It must be unique.
        */
        public uint localUid { set; get; }
    };
    #endregion
}
