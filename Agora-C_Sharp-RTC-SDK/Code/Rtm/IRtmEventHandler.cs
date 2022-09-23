namespace Agora.Rtm
{
    public abstract class IRtmEventHandler
    {
        public virtual void OnMessageEvent(MessageEvent @event) {}

        public virtual void OnPresenceEvent(PresenceEvent @event) {}

        public virtual void OnStatusEvent(StatusEvent @event) {}
    }
}