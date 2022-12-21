using System;
using Agora.Rtc;

namespace Agora.Rtc
{
    public class UTMediaPlayerSourceObserver : IMediaPlayerSourceObserver
    {


        public bool OnPlayerSourceStateChanged_be_trigger = false;
        public MEDIA_PLAYER_STATE OnPlayerSourceStateChanged_state;
        public MEDIA_PLAYER_ERROR OnPlayerSourceStateChanged_ec;

        public override void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec)
        {
            OnPlayerSourceStateChanged_be_trigger = true;
            OnPlayerSourceStateChanged_state = state;
            OnPlayerSourceStateChanged_ec = ec;
        }

        public bool OnPlayerSourceStateChangedPassed(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec)
        {
            if (OnPlayerSourceStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareMEDIA_PLAYER_STATE(OnPlayerSourceStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareMEDIA_PLAYER_ERROR(OnPlayerSourceStateChanged_ec, ec) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPositionChanged_be_trigger = false;
        public long OnPositionChanged_position_ms = 0;

        public override void OnPositionChanged(long position_ms)
        {
            OnPositionChanged_be_trigger = true;
            OnPositionChanged_position_ms = position_ms;
        }

        public bool OnPositionChangedPassed(long position_ms)
        {
            if (OnPositionChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareLong(OnPositionChanged_position_ms, position_ms) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPlayerEvent_be_trigger = false;
        public MEDIA_PLAYER_EVENT OnPlayerEvent_eventCode;
        public long OnPlayerEvent_elapsedTime = 0;
        public string OnPlayerEvent_message = null;

        public override void OnPlayerEvent(MEDIA_PLAYER_EVENT eventCode, long elapsedTime, string message)
        {
            OnPlayerEvent_be_trigger = true;
            OnPlayerEvent_eventCode = eventCode;
            OnPlayerEvent_elapsedTime = elapsedTime;
            OnPlayerEvent_message = message;
        }

        public bool OnPlayerEventPassed(MEDIA_PLAYER_EVENT eventCode, long elapsedTime, string message)
        {
            if (OnPlayerEvent_be_trigger == false)
                return false;

            if (ParamsHelper.compareMEDIA_PLAYER_EVENT(OnPlayerEvent_eventCode, eventCode) == false)
                return false;
            if (ParamsHelper.compareLong(OnPlayerEvent_elapsedTime, elapsedTime) == false)
                return false;
            if (ParamsHelper.compareString(OnPlayerEvent_message, message) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnMetaData_be_trigger = false;
        public byte[] OnMetaData_data = null;
        public int OnMetaData_length = 0;

        public override void OnMetaData(byte[] data, int length)
        {
            OnMetaData_be_trigger = true;
            OnMetaData_data = data;
            OnMetaData_length = length;
        }

        public bool OnMetaDataPassed(byte[] data, int length)
        {
            if (OnMetaData_be_trigger == false)
                return false;

            if (ParamsHelper.compareByteArray(OnMetaData_data, data) == false)
                return false;
            if (ParamsHelper.compareInt(OnMetaData_length, length) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPlayBufferUpdated_be_trigger = false;
        public long OnPlayBufferUpdated_playCachedBuffer = 0;

        public override void OnPlayBufferUpdated(long playCachedBuffer)
        {
            OnPlayBufferUpdated_be_trigger = true;
            OnPlayBufferUpdated_playCachedBuffer = playCachedBuffer;
        }

        public bool OnPlayBufferUpdatedPassed(long playCachedBuffer)
        {
            if (OnPlayBufferUpdated_be_trigger == false)
                return false;

            if (ParamsHelper.compareLong(OnPlayBufferUpdated_playCachedBuffer, playCachedBuffer) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPreloadEvent_be_trigger = false;
        public string OnPreloadEvent_src = null;
        public PLAYER_PRELOAD_EVENT OnPreloadEvent_event;

        public override void OnPreloadEvent(string src, PLAYER_PRELOAD_EVENT @event)
        {
            OnPreloadEvent_be_trigger = true;
            OnPreloadEvent_src = src;
            OnPreloadEvent_event = @event;
        }

        public bool OnPreloadEventPassed(string src, PLAYER_PRELOAD_EVENT @event)
        {
            if (OnPreloadEvent_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnPreloadEvent_src, src) == false)
                return false;
            if (ParamsHelper.comparePLAYER_PRELOAD_EVENT(OnPreloadEvent_event, @event) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnCompleted_be_trigger = false;

        public override void OnCompleted()
        {
            OnCompleted_be_trigger = true;
        }

        public bool OnCompletedPassed()
        {
            if (OnCompleted_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnAgoraCDNTokenWillExpire_be_trigger = false;

        public override void OnAgoraCDNTokenWillExpire() { OnAgoraCDNTokenWillExpire_be_trigger = true; }

        public bool OnAgoraCDNTokenWillExpirePassed()
        {
            if (OnAgoraCDNTokenWillExpire_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPlayerSrcInfoChanged_be_trigger = false;
        public SrcInfo OnPlayerSrcInfoChanged_from = null;
        public SrcInfo OnPlayerSrcInfoChanged_to = null;

        public override void OnPlayerSrcInfoChanged(SrcInfo from, SrcInfo to)
        {
            OnPlayerSrcInfoChanged_be_trigger = true;
            OnPlayerSrcInfoChanged_from = from;
            OnPlayerSrcInfoChanged_to = to;
        }

        public bool OnPlayerSrcInfoChangedPassed(SrcInfo from, SrcInfo to)
        {
            if (OnPlayerSrcInfoChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareSrcInfo(OnPlayerSrcInfoChanged_from, from) == false)
                return false;
            if (ParamsHelper.compareSrcInfo(OnPlayerSrcInfoChanged_to, to) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPlayerInfoUpdated_be_trigger = false;
        public PlayerUpdatedInfo OnPlayerInfoUpdated_info = null;

        public override void OnPlayerInfoUpdated(PlayerUpdatedInfo info)
        {
            OnPlayerInfoUpdated_be_trigger = true;
            OnPlayerInfoUpdated_info = info;
        }

        public bool OnPlayerInfoUpdatedPassed(PlayerUpdatedInfo info)
        {
            if (OnPlayerInfoUpdated_be_trigger == false)
                return false;

            if (ParamsHelper.comparePlayerUpdatedInfo(OnPlayerInfoUpdated_info, info) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnAudioVolumeIndication_be_trigger = false;
        public int OnAudioVolumeIndication_volume = 0;

        public override void OnAudioVolumeIndication(int volume)
        {
            OnAudioVolumeIndication_be_trigger = true;
            OnAudioVolumeIndication_volume = volume;
        }

        public bool OnAudioVolumeIndicationPassed(int volume)
        {
            if (OnAudioVolumeIndication_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt(OnAudioVolumeIndication_volume, volume) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
